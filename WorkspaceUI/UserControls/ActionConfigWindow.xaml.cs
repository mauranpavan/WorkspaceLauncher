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
using System.Collections.Specialized;
using WorkspaceUI.Models;
using System.Collections.ObjectModel;

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

        //private WorkspaceItemViewModel? _viewModel;
        private WorkspaceItemViewModel? _viewModelWorkspace1;

        private WorkspaceItemViewModel? _viewModelWorkspace2;

        //private string _selectedAppPath = String.Empty;
        //private string _selectedAppName = String.Empty;
        //private string _selectedFilePath = String.Empty;
        //private string _selectedFileName = String.Empty;
        private SettingsHelper settingsHelper = new SettingsHelper();

        public ActionConfigWindow()
        {
            InitializeComponent();
            if (Application.Current.MainWindow is MainWindow)
            {
                MainWindow mainWindow = (MainWindow)Application.Current.MainWindow;

                // Initialize separate ViewModels
                _viewModelWorkspace1 = new WorkspaceItemViewModel();
                _viewModelWorkspace2 = new WorkspaceItemViewModel();
                // Assign each ViewModel to a different DataContext 
                WorkspaceOneStackPanel.DataContext = _viewModelWorkspace1;
                WorkspaceTwoStackPanel.DataContext = _viewModelWorkspace2;

                //Retrieve stored application settings values from previous session
                W1.Text = Settings.Default.workspaceOneBtn;
                W2.Text = Settings.Default.workspaceTwoBtn;
                //W3.Text = Settings.Default.workspaceThreeBtn;
                //W4.Text = Settings.Default.workspaceFourBtn;
                //W5.Text = Settings.Default.workspaceFiveBtn;
                if (_viewModelWorkspace1 != null)
                    _viewModelWorkspace1.AddAllItems(_viewModelWorkspace1.WorkspaceItems,
                        settingsHelper.DeserializeJsonToList(Settings.Default.W1WorkspaceItemsJsonString));
                if (_viewModelWorkspace2 != null)
                    _viewModelWorkspace2.AddAllItems(_viewModelWorkspace2.WorkspaceItems,
                        settingsHelper.DeserializeJsonToList(Settings.Default.W2WorkspaceItemsJsonString));

                _workspaceOneBtn = (Button?)mainWindow.FindName("workspaceOneBtn");
                _workspaceTwoBtn = (Button?)mainWindow.FindName("workspaceTwoBtn");
                _workspaceThreeBtn = (Button?)mainWindow.FindName("workspaceThreeBtn");
                _workspaceFourBtn = (Button?)mainWindow.FindName("workspaceFourBtn");
                _workspaceFiveBtn = (Button?)mainWindow.FindName("workspaceFiveBtn");
            }
            else
            {
                Debug.WriteLine("Null Error - MainWindow is null");
            }
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

                // Determine which select button was clicked based on the sender
                if (Equals(sender, W1SelectAppBtn))
                {
                    if (_viewModelWorkspace1 != null)
                    {
                        _viewModelWorkspace1.SelectedAppPath = openFileDialog.FileName;
                        _viewModelWorkspace1.SelectedAppName = Path.GetFileName(_viewModelWorkspace1.SelectedAppPath);
                        Settings.Default.W1SelectedAppName = _viewModelWorkspace1.SelectedAppName;
                        Settings.Default.W1SelectedAppPath = _viewModelWorkspace1.SelectedAppPath;
                    }
                }
                else if (Equals(sender, W2SelectAppBtn)) // Assume W2Button is the button for W2SelectedApplication
                {
                    if (_viewModelWorkspace2 != null)
                    {
                        _viewModelWorkspace2.SelectedAppPath = openFileDialog.FileName;
                        _viewModelWorkspace2.SelectedAppName = Path.GetFileName(_viewModelWorkspace2.SelectedAppPath);
                        Settings.Default.W1SelectedAppName = _viewModelWorkspace2.SelectedAppName;
                        Settings.Default.W1SelectedAppPath = _viewModelWorkspace2.SelectedAppPath;
                    }
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

                //_selectedFilePath = openFileDialog.FileName;
                //_selectedFileName = Path.GetFileName(_selectedFilePath);

                if (Equals(sender, W1SelectFileBtn))
                {
                    if (_viewModelWorkspace1 != null)
                    {
                        _viewModelWorkspace1.SelectedFilePath = openFileDialog.FileName;
                        _viewModelWorkspace1.SelectedFileName = Path.GetFileName(_viewModelWorkspace1.SelectedFilePath);
                        Settings.Default.W1SelectedFileName = _viewModelWorkspace1.SelectedFileName;
                        Settings.Default.W1SelectedFilePath = _viewModelWorkspace1.SelectedFilePath;
                    }
                }
                else if (Equals(sender, W2SelectFileBtn))
                {
                    if (_viewModelWorkspace2 != null)
                    {
                        _viewModelWorkspace2.SelectedFilePath = openFileDialog.FileName;
                        _viewModelWorkspace2.SelectedFileName = Path.GetFileName(_viewModelWorkspace2.SelectedFilePath);
                        Settings.Default.W2SelectedFileName = _viewModelWorkspace2.SelectedFileName;
                        Settings.Default.W2SelectedFilePath = _viewModelWorkspace2.SelectedFilePath;
                    }
                }
            }
        }


        private void AddItem_Click(object sender, RoutedEventArgs e)
        {
            /*TODO: Suppose user selects appl and file on W1 but clicks the add button in W2 */
            if (Equals(sender, W1AddButton))
            {
                if (_viewModelWorkspace1 != null)
                {
                    WorkspaceItem newWorkspaceItem =
                        new WorkspaceItem(_viewModelWorkspace1.SelectedAppName, _viewModelWorkspace1.SelectedAppPath,
                            _viewModelWorkspace1.SelectedFileName, _viewModelWorkspace1.SelectedFilePath);

                    var collection = W1ListBox.ItemsSource as ObservableCollection<WorkspaceItem>;
                    if (_viewModelWorkspace1 != null)
                    {
                        _viewModelWorkspace1.AddItem(collection, newWorkspaceItem);

                        //Clearing values
                        _viewModelWorkspace1.SelectedAppName = String.Empty;
                        _viewModelWorkspace1.SelectedAppPath = String.Empty;
                        _viewModelWorkspace1.SelectedFileName = String.Empty;
                        _viewModelWorkspace1.SelectedFilePath = String.Empty;
                    }
                }
            }
            else if (Equals(sender, W2AddButton))
            {
                if (_viewModelWorkspace2 != null)
                {
                    WorkspaceItem newWorkspaceItem =
                        new WorkspaceItem(_viewModelWorkspace2.SelectedAppName, _viewModelWorkspace2.SelectedAppPath,
                            _viewModelWorkspace2.SelectedFileName, _viewModelWorkspace2.SelectedFilePath);

                    var collection = W2ListBox.ItemsSource as ObservableCollection<WorkspaceItem>;

                    _viewModelWorkspace2.AddItem(collection, newWorkspaceItem);

                    //Clearing values
                    _viewModelWorkspace2.SelectedAppName = String.Empty;
                    _viewModelWorkspace2.SelectedAppPath = String.Empty;
                    _viewModelWorkspace2.SelectedFileName = String.Empty;
                    _viewModelWorkspace2.SelectedFilePath = String.Empty;
                }
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

            Settings.Default.W1WorkspaceItemsJsonString =
                settingsHelper.SerializeItemCollectionToJson(W1ListBox.Items);
            Debug.WriteLine("W1WorkspaceItemsJsonString: ");
            Debug.WriteLine(Settings.Default.W1WorkspaceItemsJsonString);
            Settings.Default.W2WorkspaceItemsJsonString =
                settingsHelper.SerializeItemCollectionToJson(W2ListBox.Items);
            Debug.WriteLine("W2WorkspaceItemsJsonString: ");
            Debug.WriteLine(Settings.Default.W2WorkspaceItemsJsonString);

            BatchFileCreator w1BatchFileCreator = new BatchFileCreator("W1", W1ListBox.Items);
            BatchFileCreator w2BatchFileCreator = new BatchFileCreator("W2", W2ListBox.Items);


            this.Close();
        }

        private void cancelBtn_Click(object sender, RoutedEventArgs e)
        {
            this.Close();
        }
    }
}