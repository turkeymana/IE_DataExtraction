using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.IO;
using System.Linq;
using System.Text;
using Microsoft.AspNetCore.Mvc;

namespace MyApi.Controllers
{
    //This can be removed but left in since I used it for API testing
    [ApiController]
    [Route("api/[controller]")] //Testing API call for PostMan 
    public class HelloWorldController : ControllerBase
    {
        //simple Get call for postman API testing
        [HttpGet]
        public IActionResult HelloWorld()
        {
            return Ok("Hello, World!");
        }
    }

    [ApiController]
    [Route("api/[controller]")]
    public class ParseCandataController : ControllerBase
    {
        [HttpPost]//Post request for parsing the candata file
        public IActionResult ParseCandata(IFormFile file)
        {
            Console.WriteLine("ParseCandata method called");

            //dummy  check for making sure a file is uploaded
            if (file == null)
            {
                Console.WriteLine("No file uploaded");
                return BadRequest("No file uploaded");
            }

            Console.WriteLine("File uploaded: " + file.FileName);

            using (var reader = new BinaryReader(file.OpenReadStream()))
            {
                Console.WriteLine("Reading file contents...");

                //some local variables for storing data
                string parsedData = "";
                int count = 0;
                int hexCounter = 1;
                string line = "";
                bool found = false;
                bool seenFirstOccurrence = false;

                while (reader.BaseStream.Position < reader.BaseStream.Length)
                {
                    // Read 1 byte (1 hex code) and convert it to a string
                    var hexCode = reader.ReadByte();
                    var hexString = hexCode.ToString("X2");
                    line += hexString;

                    //Grabs the length of each line with an offset of 17 bytes
                    if (count % 17 == 16)
                    {
                        //if it ends in 55's remove them before adding it, then look for the next starting point
                        if (System.Text.RegularExpressions.Regex.IsMatch(line, @".*000007E8.*") && found)
                        {
                            //Skips over the next line which is always a 0708
                            if (!seenFirstOccurrence)
                            {
                                seenFirstOccurrence = true;
                            }
                            else //looks at the end of the parsedData to remove 55 codes appropriatly, loop through since there can be multiple
                            {
                                while (parsedData.EndsWith("55") && parsedData.Length >= 2)
                                {
                                    parsedData = parsedData.Substring(0, parsedData.Length - 2);
                                }
                                //since this is the end of a code set found to false and start looking for next "36" + hexCounter byte
                                found = false;
                            }
                                
                        }

                        //We're in a set of data we want to write so grab the last 7 bytes and add them
                        if (System.Text.RegularExpressions.Regex.IsMatch(line, @".*000007E0.*") && found)
                        {
                            var last14Chars = line.Substring(line.Length - 14);
                            parsedData += last14Chars;
                        }

                        //Check for the appropriate regex formula for service 36 then the hex counter
                        if (System.Text.RegularExpressions.Regex.IsMatch(line, $@".*07E0......36{hexCounter:X2}.*") && !found)
                        {
                            //Display starting point for debugging. Could be removed but will be left in for readability
                            Console.Write($"Found new starting point at {hexCounter.ToString("X2")}: {line} ");

                            //locate the index of "36 and the hex byte"
                            var index = line.IndexOf($"36{hexCounter:X2}");
                            var bytesAfter36 = line.Substring(index + 4); // skip "36 and next byte"

                            //debug info, also intentionally left in for readability
                            Console.WriteLine(bytesAfter36);

                            //add parsedData to the string
                            parsedData += bytesAfter36;

                            //update some local variables so we can decide which data to save
                            seenFirstOccurrence = false;
                            hexCounter++;
                            found = true;
                        }
                        line = "";
                    }
                    count++;
                }

                Console.WriteLine($"finishing up and sending file back...");

                //convert the hex string back to binary data to match the bin file
                byte[] binaryData = new byte[parsedData.Length / 2];
                for (int i = 0; i < parsedData.Length; i += 2)
                {
                    binaryData[i / 2] = Convert.ToByte(parsedData.Substring(i, 2), 16);
                }
                //return the file
                return File(binaryData, "application/octet-stream", "parsed-data.bin");
            }
        }
    }
}