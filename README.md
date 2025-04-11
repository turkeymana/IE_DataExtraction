## Overview

This app is a file upload and parsing application that uses a React frontend, Typescript, and a C# API backend. The application allows users to upload CAN bus files, which are then parsed and processed by the API to locate specifically the service 36 tag. This could easily be modified in the future to accept multiple codes. This code is being uploaded as a project for Integrated Engineering and will be made private in the future.

## Notes

If I had to redo this assignment there is a lot I would do differently. My main problem had to do with learning and understanding the CAN data properly while I was coding. figuring out some of the more niche formatting like removing any 55 codes at the end of each service response caused my solution to be built piece by piece on top of each other. Doing this introduced a few bugs and edge cases I had to manually solve like adding a 0000 to the front of my regex since one part of the data has an 07E8 located in the response Bytes causing my regex to think it was the end of the current code. I would seperate the data out into blocks in the future so that when looking for individual pieces I am ONLY looking in the potential correct location. I felt rather than redoing everything that the first solution I came to should be shown since it was fully functional for the test case. Having access to more CAN data would allow me to better check but if anything fails I imagine it would be in obscure edge cases. I would love to talk about how I would solve this differently if tasked with it again.

## Features

* File upload and parsing using React and C# API
* Uses FileController.cs to handle file uploads and parsing
* Uses FileUpload.tsx to render the file upload component
* Uses Program.cs to configure the API and handle requests
* Uses index.tsx to render the React application
* Uses App.tsx to render the main application component

## Initial Installation

1. Start by downloading the zip of this repository
2. Unzip the files to the location you'd like
3. open up the command prompt
4. Navigate to the unzipped folders location
5. Download Node JS from `https://nodejs.org/en/download/` and install
6. Download Dotnet from `https://dotnet.microsoft.com/download` and install

### Start the API

* Navigate to the `IE_DataExtraction-master\api\FileApi` directory in your terminal
* One of the times I ran my app on a virtual machine it couldn't find dotnet even when doing `dotnet --version`
* To fix this I simply went to the dotnet file directory around `C:\Program Files\dotnet` and ran `dotnet.exe`
* Then Navigate back to the FileApi directory and retry.
* Run the following command to start the API: `dotnet run`

### Start the React Application

* Open another command prompt window or tab
* Navigate to the `IE_DataExtraction-master` directory in your terminal
* Run the command `npm install` to install the React dependencies
* Run the following command to start the React application: `npm start`

### Access the Application

* Open a web browser and navigate to `http://localhost:3000` to access the React application. It should automatically open a window when you start the React application
* The API will be running on `http://localhost:3001`
* Select the .candata file and click Upload and Parse. You can view it's progress in the API's command prompt or wait until it says completed
* Select the Download button and it should return you a .bin file that has extracted the codes for the service 36

## File Documentation

The API is documented in the api\FileApi\ directory: FileController.cs, Program.cs files.
The frontend is documented in the src directory: FileUpload.tsx, index.tsx, and App.tsx files.
These were all the files I personally edited while creating this project, the rest are automatically generated.

## License

My app is licensed under the MIT License.
