## Overview

This app is a file upload and parsing application that uses a React frontend and a C# API backend. The application allows users to upload CAN bus files, which are then parsed and processed by the API to locate specifically the service 36 tag. This could easily be modified in the future to accept multiple codes. This code is being uploaded as a project for Integrated Engineering and will be taken down within a month.

## Features

* File upload and parsing using React and C# API
* Uses FileController.cs to handle file uploads and parsing
* Uses FileUpload.tsx to render the file upload component
* Uses Program.cs to configure the API and handle requests
* Uses index.tsx to render the React application
* Uses App.tsx to render the main application component

## Installation

1. Start by cloning the repository from Github or if you're using the zip just continue ahead

### Start the API

* Navigate to the `IE_DataExtraction\api\FileApi` directory in your terminal
* You might need to run `dotnet restore` to install the C# API dependencies
* Run the following command to start the API: `dotnet run` from the previously mentioned directory

### Start the React Application

* Navigate to the `IE_DataExtraction` directory in your terminal
* Run the command `npm install` to install the React dependencies
* Run the following command to start the React application: `npm start`

### Access the Application

* Open a web browser and navigate to `http://localhost:3000` to access the React application. It should automatically open a window when you start the React application
* The API will be running on `http://localhost:3001`

## File Documentation

The API is documented in the api\FileApi\ directory: FileController.cs, Program.cs files.
The frontend is documented in the src directory: FileUpload.tsx, index.tsx, and App.tsx files.
These were all the files I personally edited while creating this project, the rest are automatically generated.

## License

My app is licensed under the MIT License.
