import React from 'react';
import FileUpload from './FileUpload';

const App: React.FC = () => {
    const handleFileUpload = (file: File) => {
        console.log(file);
    };

    return (
        <div>
            <FileUpload onFileUpload={handleFileUpload} />
        </div>
    );
};

export default App;