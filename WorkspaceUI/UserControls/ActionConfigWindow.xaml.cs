using Microsoft.Win32;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System;
using System.IO;
using WorkspaceUI.ViewModels;

namespace WorkspaceUI.UserControls
{
    /// <summary>
    /// Interaction logic for ActionConfigWindow.xaml
    /// </summary>
    public partial class ActionConfigWindow : Window
    {
        private readonly Button? _workspaceOneBtn;
        private Button? _workspaceTwoBtn;
        private Button? _workspaceThreeBtn;
        private Button? _workspaceFourBtn;
        private Button? _workspaceFiveBtn;
        private WorkspaceItemViewModel? _viewModel;
        private string _selectedAppPath = String.Empty;
        private string _selectedAppName = String.Empty;     
        private string _selectedFilePath = String.Empty;
        private string _selectedFileName = String.Empty;

        public ActionConfigWindow()
        {
            InitializeComponent();
            if (Application.Current.MainWindow is MainWindow)
            {
                MainWindow mainWindow = (MainWindow)Application.Current.MainWindow;
                _viewModel = DataContext as WorkspaceItemViewModel;
                //Retrieve stored application settings values from previous session
                W1.Text = Settings.Default.workspaceOneBtn;
                 W2.Text = Settings.Default.workspaceTwoBtn;
                 //W3.Text = Settings.Default.workspaceThreeBtn;
                 //W4.Text = Settings.Default.workspaceFourBtn;
                 //W5.Text = Settings.Default.workspaceFiveBtn;


                 _workspaceOneBtn = (Button?)mainWindow.FindName("workspaceOneBtn");
                 _workspaceTwoBtn = (Button?)mainWindow.FindName("workspaceTwoBtn");
                 _workspaceThreeBtn = (Button?)mainWindow.FindName("workspaceThreeBtn");
                 _workspaceFourBtn = (Button?)mainWindow.FindName("workspaceFourBtn");
                 _workspaceFiveBtn = (Button?)mainWindow.FindName("workspaceFiveBtn");

                 W1SelectedApplicationName.Content = Settings.Default.W1SelectedAppName;
                 W1SelectedFileLabel.Content = Settings.Default.W1SelectedFileName; //rename to label
                 W2SelectedApplication.Content = Settings.Default.W2SelectedAppName;
                 W2SelectedFileLabel.Content = Settings.Default.W2SelectedFileName;
            }
            else
            {
                Debug.WriteLine("Null Error - MainWindow is null");
            }
        }

        private void saveBtn_Click(object sender, RoutedEventArgs e)
        {
            //After user makes changes to the TextBoxes, apply these to the main window buttons
            if (_workspaceOneBtn != null) _workspaceOneBtn.Content = W1.Text;
            if (_workspaceTwoBtn != null) _workspaceTwoBtn.Content = W2.Text;
            //workspaceThreeBtn.Content = W3.Text;
            //workspaceFourBtn.Content = W4.Text;
            //workspaceFiveBtn.Content = W5.Text;

            // Update the setting  so that they are stored between application sessions
            Settings.Default.workspaceOneBtn = W1.Text;
            Settings.Default.workspaceTwoBtn = W2.Text;
            //Settings.Default.workspaceThreeBtn = W3.Text;
            //Settings.Default.workspaceFourBtn = W4.Text;
            //Settings.Default.workspaceFiveBtn = W5.Text;

            //Settings.Default.W1SelectedAppName = W1SelectedApplicationName.Content.ToString();
            //Settings.Default.W1SelectedFileName = "test_file.html";

            // Save the changes to persist them
            Settings.Default.Save();

            BatchFileCreator w1BatchFileCreator = new BatchFileCreator("W1", Settings.Default.W1SelectedAppPath, Settings.Default.W1SelectedFilePath);
            BatchFileCreator w2BatchFileCreator = new BatchFileCreator("W2", Settings.Default.W2SelectedAppPath, Settings.Default.W2SelectedFilePath);
           

            this.Close();
        }

        private void cancelBtn_Click(object sender, RoutedEventArgs e)
        {
            this.Close();
        }

        private void openProgramFiles_Click(object sender, RoutedEventArgs e)
        {
            // Create an OpenFileDialog to select an executable file
            OpenFileDialog openFileDialog = new OpenFileDialog
            {
                InitialDirectory = System.Environment.GetFolderPath(System.Environment.SpecialFolder.ProgramFiles),
                Filter = "Executable files (*.exe)|*.exe|All files (*.*)|*.*",
                Title = "Select an Executable File"
            };
            
            // Show the dialog and get the result
            bool? result = openFileDialog.ShowDialog();

            // If the user selected a file, display the file path in the label
            if (result == true)
            {
                Debug.WriteLine($"=== Selected Application Path: {openFileDialog.FileName}");
                Debug.WriteLine($"=== Selected Application Name: {Path.GetFileName(openFileDialog.FileName)}");

                _selectedAppPath = openFileDialog.FileName;
                _selectedAppName = Path.GetFileName(_selectedAppPath);

                // Determine which select button was clicked based on the sender
                if (sender == W1SelectAppBtn) 
                {
                    W1SelectedApplicationName.Content = _selectedAppName;
                    Settings.Default.W1SelectedAppName = _selectedAppName;
                    Settings.Default.W1SelectedAppPath = _selectedAppPath;
                }             
                else if (sender == W2SelectAppBtn) // Assume W2Button is the button for W2SelectedApplication
                {
                    W2SelectedApplication.Content = _selectedAppName;
                    Settings.Default.W2SelectedAppName = _selectedAppName;
                    Settings.Default.W2SelectedAppPath = _selectedAppPath;
                }

            }
        }

        private void openMyDocuments_Click(object sender, RoutedEventArgs e)
        {
            // Create an OpenFileDialog to select an executable file
            OpenFileDialog openFileDialog = new OpenFileDialog
            {
                InitialDirectory = System.Environment.GetFolderPath(System.Environment.SpecialFolder.MyDocuments),
                Title = "Select the file to be run with the application"
            };

            // Show the dialog and get the result
            bool? result = openFileDialog.ShowDialog();

            // If the user selected a file, display the file path in the TextBox
            if (result == true)
            {
                Debug.WriteLine($"=== Selected File Path: {openFileDialog.FileName}");
                Debug.WriteLine($"=== Selected File Name: {Path.GetFileName(openFileDialog.FileName)}");

                _selectedFilePath = openFileDialog.FileName;
                _selectedFileName = Path.GetFileName(_selectedFilePath);

                if (sender == W1SelectFileBtn)
                {
                    W1SelectedFileLabel.Content = _selectedFileName;
                    Settings.Default.W1SelectedFileName = _selectedFileName;
                    Settings.Default.W1SelectedFilePath = _selectedFilePath;
                }
                else if (sender == W2SelectFileBtn)
                {
                    W2SelectedFileLabel.Content = _selectedFileName;
                    Settings.Default.W2SelectedFileName = _selectedFileName;
                    Settings.Default.W2SelectedFilePath = _selectedFilePath;
                }
            }
        }


        private void AddItem_Click(object sender, RoutedEventArgs e)
        {
            if (_viewModel != null) _viewModel.AddItem($"{_selectedAppName} ====> {_selectedFilePath}");
        }

        //private void RemoveItem_Click(object sender, RoutedEventArgs e)
        //{
        //    if (ItemsListBox.SelectedItem != null)
        //    {
        //        _viewModel.RemoveItem(ItemsListBox.SelectedItem.ToString());
        //    }
        //}
    }
}
