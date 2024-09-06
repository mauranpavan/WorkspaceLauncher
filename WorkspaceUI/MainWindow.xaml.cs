using System;
using System.Diagnostics;
using System.Windows;
using System.Windows.Input;
using WorkspaceLauncher.UserControls;
using Path = System.IO.Path;

namespace WorkspaceLauncher
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        // Get the path to the Application Data folder
        public string appDataPath = Environment.GetFolderPath(Environment.SpecialFolder.ApplicationData);

        // Specify the subfolder name
        public string subfolderName = "WorkspaceLauncher";

        public MainWindow()
        {
            InitializeComponent();
            WorkspaceOneBtn.Content = Settings.Default.workspaceOneBtn.ToString();
            WorkspaceTwoBtn.Content = Settings.Default.workspaceTwoBtn.ToString();
            WorkspaceThreeBtn.Content = Settings.Default.workspaceThreeBtn.ToString();
            WorkspaceFourBtn.Content = Settings.Default.workspaceFourBtn.ToString();
            WorkspaceFiveBtn.Content = Settings.Default.workspaceFiveBtn.ToString();

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
                Debug.WriteLine("=== WorkspaceOneBtn Pressed");
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
                Debug.WriteLine("=== WorkspaceTwoBtn Pressed");
                string subfolderPath = Path.Combine(appDataPath, subfolderName);
                string outputFileName = "W2-workflow.bat";

                Debug.WriteLine("=== outputFileName: " + outputFileName);
                string outputFilePath = Path.Combine(subfolderPath, outputFileName);

                Debug.WriteLine($"=== outputFilePath: {outputFilePath}");
                string batchFilePath = outputFilePath;

                Process process = new Process();
                ProcessStartInfo startInfo = new ProcessStartInfo
                {
                    FileName = "cmd.exe", 
                    Arguments = $"/C {batchFilePath}", 
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
                MessageBox.Show($"Error-workspaceTwoBtn_Click: {ex.Message}");
            }
        }

        private void workspaceThreeBtn_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                Debug.WriteLine("=== WorkspaceThreeBtn Pressed");
                string subfolderPath = Path.Combine(appDataPath, subfolderName);
                string outputFileName = "W3-workflow.bat";

                Debug.WriteLine("=== outputFileName: " + outputFileName);
                string outputFilePath = Path.Combine(subfolderPath, outputFileName);

                Debug.WriteLine($"=== outputFilePath: {outputFilePath}");
                string batchFilePath = outputFilePath;

                Process process = new Process();
                ProcessStartInfo startInfo = new ProcessStartInfo
                {
                    FileName = "cmd.exe",
                    Arguments = $"/C {batchFilePath}",
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
                MessageBox.Show($"Error-workspaceThreeBtn_Click: {ex.Message}");
            }

        }

        private void workspaceFourBtn_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                Debug.WriteLine("=== WorkspaceFourBtn Pressed");
                string subfolderPath = Path.Combine(appDataPath, subfolderName);
                string outputFileName = "W4-workflow.bat";

                Debug.WriteLine("=== outputFileName: " + outputFileName);
                string outputFilePath = Path.Combine(subfolderPath, outputFileName);

                Debug.WriteLine($"=== outputFilePath: {outputFilePath}");
                string batchFilePath = outputFilePath;

                Process process = new Process();
                ProcessStartInfo startInfo = new ProcessStartInfo
                {
                    FileName = "cmd.exe",
                    Arguments = $"/C {batchFilePath}",
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
                MessageBox.Show($"Error-workspaceFourBtn_Click: {ex.Message}");
            }

        }

        private void workspaceFiveBtn_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                Debug.WriteLine("=== WorkspaceFiveBtn Pressed");
                string subfolderPath = Path.Combine(appDataPath, subfolderName);
                string outputFileName = "W5-workflow.bat";

                Debug.WriteLine("=== outputFileName: " + outputFileName);
                string outputFilePath = Path.Combine(subfolderPath, outputFileName);

                Debug.WriteLine($"=== outputFilePath: {outputFilePath}");
                string batchFilePath = outputFilePath;

                Process process = new Process();
                ProcessStartInfo startInfo = new ProcessStartInfo
                {
                    FileName = "cmd.exe",
                    Arguments = $"/C {batchFilePath}",
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
                MessageBox.Show($"Error-workspaceFiveBtn_Click: {ex.Message}");
            }

        }

        private void OpenSettings(object sender, RoutedEventArgs e)
        {
            ActionConfigWindow actionConfigWindow = new ActionConfigWindow();
            actionConfigWindow.Show();
        }

        private void TitleBar_MouseDown(object sender, MouseButtonEventArgs e)
        {
            if (e.ChangedButton == MouseButton.Left)
            {
                this.DragMove();
            }
        }

        private void CloseButton_Click(object sender, RoutedEventArgs e)
        {
            this.Close();
        }


        private void workspaceSixBtn_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                string subfolderPath = Path.Combine(appDataPath, subfolderName);

                QuickOpenGoogleDrive quickOpenGoogleDrive = new QuickOpenGoogleDrive();
                string outputFilePath = quickOpenGoogleDrive.QuickOpen($@"{this.WorkspaceFourBtn.Content.ToString()}", "Lecture");

                Debug.WriteLine("=== outputFilePath: " + outputFilePath);
                string batchFilePath = outputFilePath;

                Process process = new Process();
                ProcessStartInfo startInfo = new ProcessStartInfo
                {
                    FileName = "cmd.exe", 
                    Arguments = $"/C {batchFilePath}", 
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
                MessageBox.Show($"Error-workspaceFourBtn_Click: {ex.Message}");
            }
        }

    }
}
