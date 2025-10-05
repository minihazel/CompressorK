using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xabe.FFmpeg;
using System.Text.Json;
using System.Diagnostics;

namespace CompressorK
{
    public class VideoCompressor
    {
        public event EventHandler<int> ProgressChanged;

        public async Task CompressToTargetSize(string inputPath, string outputPath, int targetSizeMB)
        {
            var mediaInfo = await FFmpeg.GetMediaInfo(inputPath);
            var video = mediaInfo.VideoStreams.FirstOrDefault();
            var audio = mediaInfo.AudioStreams.FirstOrDefault();

            if (video == null)
                throw new Exception("No video stream found in the file");

            double durationSeconds = mediaInfo.Duration.TotalSeconds;
            int targetSizeKB = targetSizeMB * 1024;

            int audioBitrate = audio != null ? (int)(audio.Bitrate / 1000) : 0;
            if (audioBitrate == 0 && audio != null)
            {
                audioBitrate = 128; // fallback if bitrate is unavailable
            }

            int videoBitrate = (int)((targetSizeKB * 8) / durationSeconds) - audioBitrate;

            if (videoBitrate < 100)
                throw new Exception($"Target size ({targetSizeMB} MB) is too small for a {durationSeconds:F0} second video. Minimum recommended: {CalculateMinimumSizeMB(durationSeconds, audioBitrate)} MB");

            var conversion = FFmpeg.Conversions.New()
                .AddStream(video)
                .SetVideoBitrate(videoBitrate * 1000)
                .AddParameter("-c:v libx264")
                .AddParameter("-c:a copy")
                .AddParameter("-preset medium")
                .AddParameter("-movflags +faststart") // enable streaming
                .SetOutput(outputPath);

            if (audio != null)
            {
                conversion.AddStream(audio)
                    .AddParameter("-c:a copy");
            }

            // Track progress
            conversion.OnProgress += (sender, args) =>
            {
                var percent = (int)(args.Duration.TotalSeconds / args.TotalLength.TotalSeconds * 100);
                ProgressChanged?.Invoke(this, Math.Min(percent, 100));
            };

            await conversion.Start();
        }

        public async Task CompressToPercentage(string inputPath, string outputPath, int targetSizePercentage)
        {
            if (targetSizePercentage < 1 || targetSizePercentage > 99)
                throw new ArgumentException("Target percentage must be between 1 and 99");

            FileInfo fileInfo = new FileInfo(inputPath);

            long originalSizeBytes = fileInfo.Length;
            double targetSizeMB = (originalSizeBytes * targetSizePercentage / 100.0) / (1024.0 * 1024.0);

            Debug.WriteLine(originalSizeBytes);
            Debug.WriteLine(targetSizePercentage);
            Debug.WriteLine(targetSizeMB);

            await CompressToTargetSize(inputPath, outputPath, (int)Math.Ceiling(targetSizeMB));
        }

        public async Task CompressWithQuality(string inputPath, string outputPath, int crf = 23, string preset = "medium")
        {
            // CRF (Constant Rate Factor):
            // 0 = lossless, 23 = default (high quality), 51 = worst quality
            // Recommended range: 18-28
            // Lower = better quality but larger file

            if (crf < 0 || crf > 51)
                throw new ArgumentException("CRF must be between 0 and 51");

            var mediaInfo = await FFmpeg.GetMediaInfo(inputPath);
            var video = mediaInfo.VideoStreams.FirstOrDefault();
            var audio = mediaInfo.AudioStreams.FirstOrDefault();

            if (video == null)
                throw new Exception("No video stream found");

            var conversion = FFmpeg.Conversions.New()
                .AddStream(video)
                .AddParameter($"-crf {crf}")
                .AddParameter("-c:v libx264")
                .AddParameter("-c:a copy")
                .AddParameter($"-preset {preset}")
                .AddParameter("-movflags +faststart")
                .SetOutput(outputPath);

            if (audio != null)
            {
                conversion.AddStream(audio)
                    .AddParameter("-c:a copy");
            }

            conversion.OnProgress += (sender, args) =>
            {
                var percent = (int)(args.Duration.TotalSeconds / args.TotalLength.TotalSeconds * 100);
                ProgressChanged?.Invoke(this, Math.Min(percent, 100));
            };

            await conversion.Start();
        }

        public async Task SmartCompress(string inputPath, string outputPath, int targetSizeMB)
        {
            var mediaInfo = await FFmpeg.GetMediaInfo(inputPath);
            var video = mediaInfo.VideoStreams.FirstOrDefault();
            var audio = mediaInfo.AudioStreams.FirstOrDefault();

            if (video == null)
                throw new Exception("No video stream found");

            double durationSeconds = mediaInfo.Duration.TotalSeconds;
            int targetSizeKB = targetSizeMB * 1024;
            int audioBitrate = audio != null ? 128 : 0;
            int videoBitrate = (int)((targetSizeKB * 8) / durationSeconds) - audioBitrate;

            if (videoBitrate < 100)
                throw new Exception($"Target size too small. Minimum: {CalculateMinimumSizeMB(durationSeconds, audioBitrate)} MB");

            // Two-pass encoding for better quality
            string passLogFile = Path.Combine(Path.GetTempPath(), "ffmpeg2pass");

            // First pass
            var firstPass = FFmpeg.Conversions.New()
                .AddStream(video)
                .SetVideoBitrate(videoBitrate)
                .AddParameter("-c:v libx264")
                .AddParameter("-c:a copy")
                .AddParameter($"-pass 1")
                .AddParameter($"-passlogfile \"{passLogFile}\"")
                .AddParameter("-preset medium")
                .AddParameter("-f mp4")
                .SetOutput(Path.Combine(Path.GetTempPath(), "null.mp4"));

            firstPass.OnProgress += (sender, args) =>
            {
                var percent = (int)(args.Duration.TotalSeconds / args.TotalLength.TotalSeconds * 50); // First pass = 0-50%
                ProgressChanged?.Invoke(this, percent);
            };

            await firstPass.Start();

            // Second pass
            var secondPass = FFmpeg.Conversions.New()
                .AddStream(video)
                .SetVideoBitrate(videoBitrate)
                .AddParameter("-c:v libx264")
                .AddParameter("-c:a copy")
                .AddParameter($"-pass 2")
                .AddParameter($"-passlogfile \"{passLogFile}\"")
                .AddParameter("-preset medium")
                .AddParameter("-movflags +faststart")
                .SetOutput(outputPath);

            if (audio != null)
            {
                secondPass.AddStream(audio)
                    .AddParameter("-c:a copy");
            }

            secondPass.OnProgress += (sender, args) =>
            {
                var percent = 50 + (int)(args.Duration.TotalSeconds / args.TotalLength.TotalSeconds * 50); // Second pass = 50-100%
                ProgressChanged?.Invoke(this, Math.Min(percent, 100));
            };

            await secondPass.Start();

            // Clean up pass log files
            try
            {
                if (File.Exists(passLogFile)) File.Delete(passLogFile);
                if (File.Exists(passLogFile + "-0.log")) File.Delete(passLogFile + "-0.log");
            }
            catch { /* Ignore cleanup errors */ }
        }

        public async Task<VideoInfo> GetVideoInfo(string filePath)
        {
            var mediaInfo = await FFmpeg.GetMediaInfo(filePath);
            var video = mediaInfo.VideoStreams.FirstOrDefault();
            var audio = mediaInfo.AudioStreams.FirstOrDefault();

            FileInfo fileInfo = new FileInfo(filePath);

            return new VideoInfo
            {
                FilePath = filePath,
                FileName = Path.GetFileName(filePath),
                FileSizeMB = fileInfo.Length / (1024.0 * 1024.0),
                Duration = mediaInfo.Duration,
                Width = video?.Width ?? 0,
                Height = video?.Height ?? 0,
                Framerate = video?.Framerate ?? 0,
                VideoBitrate = video?.Bitrate ?? 0,
                AudioBitrate = audio?.Bitrate ?? 0,
                HasAudio = audio != null
            };
        }

        private double CalculateMinimumSizeMB(double durationSeconds, int audioBitrate)
        {
            int minimumVideoBitrate = 100; // kbps
            int totalBitrate = minimumVideoBitrate + audioBitrate;
            return Math.Ceiling((totalBitrate * durationSeconds) / (8 * 1024));
        }
    }

    public class VideoInfo
    {
        public string FilePath { get; set; }
        public string FileName { get; set; }
        public double FileSizeMB { get; set; }
        public TimeSpan Duration { get; set; }
        public int Width { get; set; }
        public int Height { get; set; }
        public double Framerate { get; set; }
        public long VideoBitrate { get; set; }
        public long AudioBitrate { get; set; }
        public bool HasAudio { get; set; }

        public override string ToString()
        {
            return $"{FileName}\n" +
                    $"Size: {FileSizeMB:F2} MB\n" +
                    $"Duration: {Duration:hh\\:mm\\:ss}\n" +
                    $"Resolution: {Width}x{Height}\n" +
                    $"Bitrate: Video {VideoBitrate / 1000} kbps, Audio {AudioBitrate / 1000} kbps";
        }
    }
}
