using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Text;
using System.Windows;
using System.Windows.Controls;
using WorkspaceLauncher.Models;

namespace WorkspaceLauncher
{
    internal class BatchFileCreator
    {
        private static readonly string? ApplicationName = Application.Current.Resources["AppBrandName"] as string;
        public BatchFileCreator()
        {
        }

        public BatchFileCreator(string fileName)
        {
        }

        public BatchFileCreator(string workspaceId, ItemCollection listboxItems)
        {
            Debug.WriteLine("Starting Batch File Creation");
            try
            {
                string outputFileName = $@"{workspaceId}-workflow.bat";
                bool startFlag = true;
                //string directoryPath = $@"G:\My Drive\{dirName}\{folderName}";
                //string openNewChromePrefixCMD = "start chrome /new-window ";
                //string openLinkPrefixCMD = "start \"\" ";
                //List<string> allFilesList = new List<string>();

                string openLinkPrefixCmd = "start \"\" ";

                //Part 1
                // Get the path to the Application Data folder
                string appDataPath = Environment.GetFolderPath(Environment.SpecialFolder.ApplicationData);

                // Specify the subfolder name
                string? subfolderName = ApplicationName;

                // Combine the paths to create the full path to the subfolder
                if (subfolderName != null)
                {
                    string subfolderPath = Path.Combine(appDataPath, subfolderName);

                    // Check if the subfolder exists, and create it if not
                    if (!Directory.Exists(subfolderPath))
                    {
                        Directory.CreateDirectory(subfolderPath);
                        Debug.WriteLine($"Subfolder '{subfolderName}' created in the Application Data folder.");
                    }
                    else
                    {
                        Debug.WriteLine($"Subfolder '{subfolderName}' already exists in the Application Data folder.");
                    }

                    //Part 2
                    //Open the output file in write mode
                    Debug.WriteLine("Writing to output file");
                    string outputFilePath = Path.Combine(subfolderPath, outputFileName);

                    // Check if the output file exists and delete it
                    if (File.Exists(outputFilePath))
                    {
                        File.Delete(outputFilePath);
                        Debug.WriteLine($"Existing file '{outputFilePath}' deleted.");
                    }

                    //Part3

                    using (StreamWriter outputFile = new StreamWriter(outputFilePath, true, Encoding.UTF8))
                        //using (StreamWriter outputFile = new StreamWriter(Path.Combine(appDataPath, subfolderName)))
                    {
                        outputFile.WriteLine("@echo off");
                        Debug.WriteLine($"Sample file '{outputFilePath}' created in the subfolder.");
                        foreach (WorkspaceItem? item in listboxItems)
                        {
                            string? selectedApplicationPath = item?.ApplicationPath;
                            string? selectedFilePath = item?.FilePath;

                            // Write the list of files to the text file

                            outputFile.WriteLine(openLinkPrefixCmd + "\"" + selectedApplicationPath + "\" " + "\"" +
                                                 selectedFilePath + "\"" + "\n");
                        }
                        outputFile.WriteLine("exit");
                    }
                }

                Debug.WriteLine($"File list has been written to {outputFileName}");
            }
            catch (Exception e)
            {
                Console.WriteLine(e);
                throw;
            }
        }


        public string QuickOpen(string dirName, string folderName)
        {
            // i have to give explicit abs path for the output file to be written in for some reason
            Debug.WriteLine("Starting");
            //string outputFileName = $@"C:\Users\mauran\Documents\WorkspaceUI\WorkspaceUI\script\{dirName}-workflow.bat";
            string outputFileName = $@"{dirName}-workflow.bat";

            string directoryPath = $@"G:\My Drive\{dirName}\{folderName}";
            string openNewChromePrefixCmd = "start chrome /new-window ";
            string openLinkPrefixCmd = "start \"\" ";
            bool startFlag = true;
            List<string> allFilesList = new List<string>();
            //application data folder
            try
            {
                //Part 1
                // Get the path to the Application Data folder
                string appDataPath = Environment.GetFolderPath(Environment.SpecialFolder.ApplicationData);

                // Specify the subfolder name
                string subfolderName = "MyWorkspace"; // Change this to your actual application name

                // Combine the paths to create the full path to the subfolder
                string subfolderPath = Path.Combine(appDataPath, subfolderName);

                // Check if the subfolder exists, and create it if not
                if (!Directory.Exists(subfolderPath))
                {
                    Directory.CreateDirectory(subfolderPath);
                    Debug.WriteLine($"Subfolder '{subfolderName}' created in the Application Data folder.");
                }
                else
                {
                    Debug.WriteLine($"Subfolder '{subfolderName}' already exists in the Application Data folder.");
                }
            }
            catch (Exception ex)
            {
                Debug.WriteLine($"Error: {ex.Message}");
                return String.Empty;
            }

            return "g";
        }
    }
}