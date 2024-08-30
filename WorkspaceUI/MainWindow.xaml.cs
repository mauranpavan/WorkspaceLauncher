﻿using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;
using System.IO;
using Path = System.IO.Path;
using WorkspaceUI.UserControls;

namespace WorkspaceUI
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        // Get the path to the Application Data folder
        public string appDataPath = Environment.GetFolderPath(Environment.SpecialFolder.ApplicationData);

        // Specify the subfolder name
        public string subfolderName = "MyWorkspace";

        public MainWindow()
        {
            InitializeComponent();
            workspaceOneBtn.Content = Settings.Default.workspaceOneBtn.ToString();
            workspaceTwoBtn.Content = Settings.Default.workspaceTwoBtn.ToString();
            workspaceThreeBtn.Content = Settings.Default.workspaceThreeBtn.ToString();
            workspaceFourBtn.Content = Settings.Default.workspaceFourBtn.ToString();
            workspaceFiveBtn.Content = Settings.Default.workspaceFiveBtn.ToString();

            //SettingsWindow settingsWindow = new SettingsWindow();
            //TextBox W1 = (TextBox)settingsWindow.FindName("workspaceOneBtn");
            //TextBox W2 = (TextBox)settingsWindow.FindName("workspaceTwoBtn");
            //TextBox W3 = (TextBox)settingsWindow.FindName("workspaceThreeBtn");
            //TextBox W4 = (TextBox)settingsWindow.FindName("workspaceFourBtn");
            //TextBox W5 = (TextBox)settingsWindow.FindName("workspaceFiveBtn");

            //ActionConfigWindow actionConfigWindow = new ActionConfigWindow();
            //TextBox W1 = (TextBox)actionConfigWindow.FindName("workspaceOneBtn");
            //TextBox W2 = (TextBox)actionConfigWindow.FindName("workspaceTwoBtn");
            //TextBox W3 = (TextBox)actionConfigWindow.FindName("workspaceThreeBtn");
            //TextBox W4 = (TextBox)actionConfigWindow.FindName("workspaceFourBtn");
            //TextBox W5 = (TextBox)actionConfigWindow.FindName("workspaceFiveBtn");

            //W1.Text = Settings.Default.workspaceOneBtn.ToString();
            //W2.Text = Settings.Default.workspaceTwoBtn.ToString();
            //W3.Text = Settings.Default.workspaceThreeBtn.ToString();
            //W4.Text = Settings.Default.workspaceFourBtn.ToString();
            //W5.Text = Settings.Default.workspaceFiveBtn.ToString();


        }

        //private void workspaceOneBtn_Click(object sender, RoutedEventArgs e)
        //{
        //    try
        //    {
        //        string batchFilePath = "C:\\Users\\mauran\\Desktop\\workflowTest\\personal_project.bat"; // Replace with the actual path to your .bat file

        //        // Create a new process to run the batch file
        //        Process process = new Process();
        //        ProcessStartInfo startInfo = new ProcessStartInfo
        //        {
        //            FileName = "cmd.exe", // Run the batch file via the command prompt
        //            Arguments = $"/C {batchFilePath}", // /C carries out the command specified and then terminates
        //            RedirectStandardOutput = false,
        //            UseShellExecute = false,
        //            CreateNoWindow = true
        //        };
        //        process.StartInfo = startInfo;
        //        process.Start();

        //        process.WaitForExit();
        //    }
        //    catch (Exception ex)
        //    {
        //        // Handle any exceptions that may occur during execution
        //        MessageBox.Show($"Error-workspaceOneBtn_Click: {ex.Message}");
        //    }

        //}

        private void workspaceOneBtn_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                Debug.WriteLine("=== workspaceOneBtn Pressed");
                // Combine the paths to create the full path to the subfolder
                string subfolderPath = Path.Combine(appDataPath, subfolderName);

                string outputFileName = "W1-workflow.bat";

                Debug.WriteLine("=== outputFileName: " + outputFileName);
                string outputFilePath = Path.Combine(subfolderPath, outputFileName);

                Debug.WriteLine($"=== outputFilePath: {outputFilePath}");
                string batchFilePath = outputFilePath;

                // Create a new process to run the batch file
                Process process = new Process();
                ProcessStartInfo startInfo = new ProcessStartInfo
                {
                    FileName = "cmd.exe", // Run the batch file via the command prompt
                    Arguments = $"/C {batchFilePath}", // /C carries out the command specified and then terminates
                    RedirectStandardOutput = false,
                    UseShellExecute = false,
                    CreateNoWindow = true
                };
                process.StartInfo = startInfo;
                process.Start();

                process.WaitForExit();
            }
            catch (Exception ex)
            {
                // Handle any exceptions that may occur during execution
                MessageBox.Show($"Error-workspaceOneBtn_Click: {ex.Message}");
            }

        }

        private void workspaceTwoBtn_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                Debug.WriteLine("=== workspaceTwoBtn Pressed");
                // Combine the paths to create the full path to the subfolder
                string subfolderPath = Path.Combine(appDataPath, subfolderName);

                /* the workflow file name should be the selected folder directory, not the button name  */
                //string outputFileName = $@"{this.workspaceTwoBtn.Content.ToString()}-workflow.bat";
                string outputFileName = "W2-workflow.bat";

                Debug.WriteLine("=== outputFileName: " + outputFileName);
                string outputFilePath = Path.Combine(subfolderPath, outputFileName);

                Debug.WriteLine($"=== outputFilePath: {outputFilePath}");
                string batchFilePath = outputFilePath; 

                // Create a new process to run the batch file
                Process process = new Process();
                ProcessStartInfo startInfo = new ProcessStartInfo
                {
                    FileName = "cmd.exe", // Run the batch file via the command prompt
                    Arguments = $"/C {batchFilePath}", // /C carries out the command specified and then terminates
                    RedirectStandardOutput = false,
                    UseShellExecute = false,
                    CreateNoWindow = true
                };
                process.StartInfo = startInfo;
                process.Start();

                process.WaitForExit();
            }
            catch (Exception ex)
            {
                // Handle any exceptions that may occur during execution
                MessageBox.Show($"Error-workspaceTwoBtn_Click: {ex.Message}");
            }
        }

        private void workspaceThreeBtn_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                Debug.WriteLine("=== workspaceThreeBtn Pressed");
                string subfolderPath = Path.Combine(appDataPath, subfolderName);
                string outputFilePath = $@"{this.workspaceThreeBtn.Content.ToString()}-workflow.bat";


                //batch file
                if (File.Exists(outputFilePath))
                {
                    File.Delete(outputFilePath);
                }
                QuickOpenGoogleDrive quickOpenGoogleDrive = new QuickOpenGoogleDrive();
                outputFilePath = quickOpenGoogleDrive.QuickOpen($@"{this.workspaceThreeBtn.Content.ToString()}", "Lecture");

                Debug.WriteLine("=== outputFilePath: " + outputFilePath);
                string batchFilePath = outputFilePath;



                // Create a new process to run the batch file
                Process process = new Process();
                ProcessStartInfo startInfo = new ProcessStartInfo
                {
                    FileName = "cmd.exe", // Run the batch file via the command prompt
                    Arguments = $"/C {batchFilePath}", // /C carries out the command specified and then terminates
                    RedirectStandardOutput = false,
                    UseShellExecute = false,
                    CreateNoWindow = true
                };
                process.StartInfo = startInfo;
                process.Start();

                process.WaitForExit();
            }
            catch (Exception ex)
            {
                // Handle any exceptions that may occur during execution
                MessageBox.Show($"Error-workspaceThreeBtn_Click: {ex.Message}");
            }
        }

        private void workspaceFourBtn_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                Debug.WriteLine("=== workspaceFourBtn Pressed");
                // Combine the paths to create the full path to the subfolder
                string subfolderPath = Path.Combine(appDataPath, subfolderName);

                /* the workflow file name should be the selected folder directory, not the button name  */

                //batch file
                QuickOpenGoogleDrive quickOpenGoogleDrive = new QuickOpenGoogleDrive();
                string outputFilePath = quickOpenGoogleDrive.QuickOpen($@"{this.workspaceFourBtn.Content.ToString()}", "Lecture");

                //string outputFileName = $@"{this.workspaceFourBtn.Content.ToString()}-workflow.bat";
                //Debug.WriteLine("=== outputFileName: " + outputFileName);
                //string outputFilePath = Path.Combine(subfolderPath, outputFileName);

                Debug.WriteLine("=== outputFilePath: " + outputFilePath);
                string batchFilePath = outputFilePath;

      

                // Create a new process to run the batch file
                Process process = new Process();
                ProcessStartInfo startInfo = new ProcessStartInfo
                {
                    FileName = "cmd.exe", // Run the batch file via the command prompt
                    Arguments = $"/C {batchFilePath}", // /C carries out the command specified and then terminates
                    RedirectStandardOutput = false,
                    UseShellExecute = false,
                    CreateNoWindow = true
                };
                process.StartInfo = startInfo;
                process.Start();

                process.WaitForExit();
            }
            catch (Exception ex)
            {
                // Handle any exceptions that may occur during execution
                MessageBox.Show($"Error-workspaceFourBtn_Click: {ex.Message}");
            }
        }

        private void workspaceFiveBtn_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                Debug.WriteLine("=== workspaceFiveBtn Pressed");
                string subfolderPath = Path.Combine(appDataPath, subfolderName);


                //batch file
                QuickOpenGoogleDrive quickOpenGoogleDrive = new QuickOpenGoogleDrive();
                string outputFilePath = quickOpenGoogleDrive.QuickOpen($@"{this.workspaceFiveBtn.Content.ToString()}", "Lecture");

                Debug.WriteLine("=== outputFilePath: " + outputFilePath);
                string batchFilePath = outputFilePath;

                // Create a new process to run the batch file
                Process process = new Process();
                ProcessStartInfo startInfo = new ProcessStartInfo
                {
                    FileName = "cmd.exe", // Run the batch file via the command prompt
                    Arguments = $"/C {batchFilePath}", // /C carries out the command specified and then terminates
                    RedirectStandardOutput = false,
                    UseShellExecute = false,
                    CreateNoWindow = true
                };
                process.StartInfo = startInfo;
                process.Start();

                process.WaitForExit();
            }
            catch (Exception ex)
            {
                // Handle any exceptions that may occur during execution
                MessageBox.Show($"Error-workspaceFiveBtn_Click: {ex.Message}");
            }
        }

        private void openSettings(object sender, RoutedEventArgs e)
        {
            //SettingsWindow settingsWindow = new SettingsWindow();
            //settingsWindow.Show();
            ActionConfigWindow actionConfigWindow = new ActionConfigWindow();
            actionConfigWindow.Show();
        }
    }
}
