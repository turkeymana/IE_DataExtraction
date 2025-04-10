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

To install my app, follow these steps:

1. Clone the repository
2. Run `npm install` to install the React dependencies
3. Run `dotnet restore` to install the C# API dependencies
4. Run `dotnet run` to start the API
5. Run `npm start` to start the React application

## Running the Project

To run the project, follow these steps:

### Install Dependencies

* Install Node.js from the official website: <https://nodejs.org/en/download/>
* Install .NET Core from the official website: <https://dotnet.microsoft.com/download>
* Install npm by running the following command in your terminal: `npm install`
* Install the required packages for the React frontend by running the following command in your terminal: `npm install react react-dom`
* Install the required packages for the C# API backend by running the following command in your terminal: `dotnet restore`

### Start the API

* Navigate to the `api` directory in your terminal
* Run the following command to start the API: `dotnet run`

### Start the React Application

* Navigate to the `src` directory in your terminal
* Run the following command to start the React application: `npm start`

### Access the Application

* Open a web browser and navigate to `http://localhost:3000` to access the React application. It should automatically open when you start up the React application
* The API will be running on `http://localhost:3001`

## API Documentation

The API is documented in the FileController.cs file.

## Frontend Documentation

The frontend is documented in the FileUpload.tsx, index.tsx, and App.tsx files.

## License

My app is licensed under the MIT License.
