## Overview

This app is a file upload and parsing application that uses a React frontend, Typescript, and a C# API backend. The application allows users to upload CAN bus files, which are then parsed and processed by the API to locate specifically the service 36 tag. This could easily be modified in the future to accept multiple codes. This code is being uploaded as a project for Integrated Engineering and will be made private in the future.

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
* You might need to run `dotnet restore` to install the C# API dependencies
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
