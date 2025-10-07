## What is CompressorK?
This is a neat little tool that allows you to compress videos with most of the common and popular video format types (mp4, mkv, mov, wav, etc.) completely offline.

It uses [ffmpeg](https://www.ffmpeg.org/download.html) to do its magic. There are many videos and text-written guides on how to install ffmpeg, so I will not cover it here.

## Installation
Download the release, then extract the executable `CompressorK.exe` somewhere and run it. Windows may require additional frameworks to be installed for it to work.

FFmpeg is required to be installed, see the top of the README for more information.

## Usage
- Extract `CompressorK.exe` from the archive somewhere
- Open / Run / Launch `CompressorK.exe`
- Drag-and-drop a local video file into the app; alternatively click anywhere and use the file browser.
- If the selected file is valid, there will be two methods available:
  - Target size based: compress the video until it has a certain file size
  - Percentage based: compress the video with a % amount of compression
- Select the options you want
- Hit the `Compress` button on the bottom right
- Wait until the compression has completed
- Profit

## Known problems
- While I've tested this tool pretty extensively on several MP4-format videos, the percentage-based compression method might not be 100% accurate. *It works well enough*.
- The app may error out if used in unintentional ways. I hereby waive any and all responsibility and will not provide support if the app errors out. It works fine on my machine.
