import React, { useState } from 'react';

// Define the interface for the FileUpload component's props
interface FileUploadProps {
    // Optional callback function to handle file upload
    onFileUpload?: (file: File) => void;
}

const FileUpload: React.FC<FileUploadProps> = ({ onFileUpload }) => {
    // Initialize state variables to track the selected file, uploaded file, and upload status
    const [selectedFile, setSelectedFile] = useState<File | null>(null);
    const [uploading, setUploading] = useState(false);
    const [uploadSuccess, setUploadSuccess] = useState(false);
    const [error, setError] = useState<string | null>(null);
    const [parsedFile, setParsedFile] = useState<Blob | null>(null);

    // Handle file selection
    const handleFileChange = (event: React.ChangeEvent<HTMLInputElement>) => {
        setSelectedFile(event.target.files![0]);
    };

    // Handle upload button click event
    const handleUpload = () => {
        // Check if a file has been selected else throw error
        if (!selectedFile) {
            setError('Please select a file to upload');
        } else {
            setUploading(true);

            // Create a new FormData object to send the file to the server
            const formData = new FormData();
            formData.append('file', selectedFile);

            // Send the file to the server using the fetch API, Uses 3001 since 3000 is already in use
            fetch('http://localhost:3001/api/ParseCandata', {
                method: 'POST',
                body: formData,
            })
                .then(response => {
                    // Log the response and return the blob
                    console.log(response);
                    return response.blob();
                })
                .then(blob => {
                    // Update state variables to reflect successful file upload and parsing
                    setParsedFile(blob);
                    setUploadSuccess(true);
                    setUploading(false);
                    setError(null);
                })
                .catch(error => {
                    // Log error and stop the uploading state
                    console.error(error);
                    setError('Error uploading file');
                    setUploading(false);
                });
        }
    };

    // Handle download button click event
    const handleDownload = () => {
        // Check if a parsed file exists
        if (parsedFile) {
            // Create a new filename by replacing the .candata extension with .bin
            const filename = selectedFile!.name.replace('.candata', '.bin');
            const url = URL.createObjectURL(parsedFile);

            // Create a new anchor element to trigger the download
            const a = document.createElement('a');
            a.href = url;
            a.download = filename;
            a.click();
        }
    };

    // Render the components
    return (
        <div style={{
            position: 'absolute',
            top: 0,
            left: 0,
            width: '100%',
            height: '100vh',
            backgroundColor: '#777',
            padding: '20px',
            boxSizing: 'border-box'
        }}>
            <h1>Hello Damon</h1>
            <br />
            <div style={{ marginLeft: 0, paddingLeft: 0 }}>
                <input type="file" accept=".candata" style={{ padding: '10px 20px', fontSize: '18px', width: '1000px' }} onChange={handleFileChange} />
            </div>
            <br />
            <br />
            <button style={{ padding: '10px 20px', fontSize: '18px' }} onClick={handleUpload}>Upload and Parse</button>
            <br /><br /><br />
            <button style={{ padding: '10px 20px', fontSize: '18px' }} onClick={uploadSuccess ? handleDownload : undefined} disabled={!uploadSuccess}>Download Parsed File</button>
            {uploading ? (
                <p>Uploading...</p>
            ) : error ? (
                <p style={{ color: 'red' }}>{error}</p>
            ) : uploadSuccess ? (
                <p>Upload successful!</p>
            ) : (
                <></>
            )}
        </div>
    );
};

// Export the components
export default FileUpload;