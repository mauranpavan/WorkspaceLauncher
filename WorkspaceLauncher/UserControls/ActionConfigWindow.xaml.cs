using System;
using System.Collections.ObjectModel;
using System.Diagnostics;
using System.IO;
using System.Windows;
using System.Windows.Controls;
using Microsoft.Win32;
using WorkspaceLauncher.Models;
using WorkspaceLauncher.ViewModels;

namespace WorkspaceLauncher.UserControls
{
    /// <summary>
    /// Interaction logic for ActionConfigWindow.xaml
    /// </summary>
    public partial class ActionConfigWindow : Window
    {
        private readonly Button? _workspaceOneBtn;
        private readonly Button? _workspaceTwoBtn;
        private readonly Button? _workspaceThreeBtn;
        private readonly Button? _workspaceFourBtn;
        private readonly Button? _workspaceFiveBtn;
        private WorkspaceItemViewModel? _workspace1ViewModel;
        private WorkspaceItemViewModel? _workspace2ViewModel;
        private WorkspaceItemViewModel? _workspace3ViewModel;
        private WorkspaceItemViewModel? _workspace4ViewModel;
        private WorkspaceItemViewModel? _workspace5ViewModel;
        private SettingsHelper _settingsHelper = new SettingsHelper();

        public ActionConfigWindow()
        {
            InitializeComponent();
            if (Application.Current.MainWindow is MainWindow)
            {
                MainWindow mainWindow = (MainWindow)Application.Current.MainWindow;

                // Initialize separate ViewModels
                _workspace1ViewModel = new WorkspaceItemViewModel();
                _workspace2ViewModel = new WorkspaceItemViewModel();
                _workspace3ViewModel = new WorkspaceItemViewModel();
                _workspace4ViewModel = new WorkspaceItemViewModel();
                _workspace5ViewModel = new WorkspaceItemViewModel();

                // Assign each ViewModel to their respective DataContext 
                WorkspaceOneStackPanel.DataContext = _workspace1ViewModel;
                WorkspaceTwoStackPanel.DataContext = _workspace2ViewModel;
                WorkspaceThreeStackPanel.DataContext = _workspace3ViewModel;
                WorkspaceFourStackPanel.DataContext = _workspace4ViewModel;
                WorkspaceFiveStackPanel.DataContext = _workspace5ViewModel;

                //Retrieve stored application settings: populate workspace names
                W1NameTextBox.Text = Settings.Default.workspaceOneBtn;
                W2NameTextBox.Text = Settings.Default.workspaceTwoBtn;
                W3NameTextBox.Text = Settings.Default.workspaceThreeBtn;
                W4NameTextBox.Text = Settings.Default.workspaceFourBtn;
                W5NameTextBox.Text = Settings.Default.workspaceFiveBtn;
                SelectStartupCheckbox.IsChecked = Settings.Default.SelectStartupCheckboxValue;

                //Retrieve stored application settings: populate listbox with workspace items
                Debug.WriteLine("Initializing - Loading workspace items to workspaces");
                //Debug.WriteLine("Workspace 1 workspace items");
                Debug.WriteLine(_workspace1ViewModel.WorkspaceItems);
                Debug.WriteLine("Settings.Default.W1WorkspaceItemsJsonString");
                Debug.WriteLine(Settings.Default.W1WorkspaceItemsJsonString);
                if (_workspace1ViewModel != null)
                    _workspace1ViewModel.AddAllItems(_workspace1ViewModel.WorkspaceItems,
                        _settingsHelper.DeserializeJsonToList(Settings.Default.W1WorkspaceItemsJsonString));
                if (_workspace2ViewModel != null)
                    _workspace2ViewModel.AddAllItems(_workspace2ViewModel.WorkspaceItems,
                        _settingsHelper.DeserializeJsonToList(Settings.Default.W2WorkspaceItemsJsonString));
                if (_workspace3ViewModel != null)
                    _workspace3ViewModel.AddAllItems(_workspace3ViewModel.WorkspaceItems,
                        _settingsHelper.DeserializeJsonToList(Settings.Default.W3WorkspaceItemsJsonString));
                if (_workspace4ViewModel != null)
                    _workspace4ViewModel.AddAllItems(_workspace4ViewModel.WorkspaceItems,
                        _settingsHelper.DeserializeJsonToList(Settings.Default.W4WorkspaceItemsJsonString));
                if (_workspace5ViewModel != null)
                    _workspace5ViewModel.AddAllItems(_workspace5ViewModel.WorkspaceItems,
                        _settingsHelper.DeserializeJsonToList(Settings.Default.W5WorkspaceItemsJsonString));

                _workspaceOneBtn = (Button?)mainWindow.FindName("WorkspaceOneBtn");
                _workspaceTwoBtn = (Button?)mainWindow.FindName("WorkspaceTwoBtn");
                _workspaceThreeBtn = (Button?)mainWindow.FindName("WorkspaceThreeBtn");
                _workspaceFourBtn = (Button?)mainWindow.FindName("WorkspaceFourBtn");
                _workspaceFiveBtn = (Button?)mainWindow.FindName("WorkspaceFiveBtn");
            }
            else
            {
                Debug.WriteLine("Null Error - MainWindow is null");
            }
        }

        /*
         * Application Selection
         */
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
                    if (_workspace1ViewModel == null)
                    {
                        Debug.WriteLine("Workspace 1 ViewModel is null");
                        return;
                    }
                    _workspace1ViewModel.SelectedAppPath = openFileDialog.FileName;
                        _workspace1ViewModel.SelectedAppName = Path.GetFileName(_workspace1ViewModel.SelectedAppPath);
                        Settings.Default.W1SelectedAppName = _workspace1ViewModel.SelectedAppName;
                        Settings.Default.W1SelectedAppPath = _workspace1ViewModel.SelectedAppPath;
                    
                }
                else if (Equals(sender, W2SelectAppBtn))
                {
                    if (_workspace2ViewModel == null)
                    {
                        Debug.WriteLine("Workspace 2 ViewModel is null");
                        return;
                    }
                    _workspace2ViewModel.SelectedAppPath = openFileDialog.FileName;
                        _workspace2ViewModel.SelectedAppName = Path.GetFileName(_workspace2ViewModel.SelectedAppPath);
                        Settings.Default.W1SelectedAppName = _workspace2ViewModel.SelectedAppName;
                        Settings.Default.W1SelectedAppPath = _workspace2ViewModel.SelectedAppPath;
                    
                }
                else if (Equals(sender, W3SelectAppBtn))
                {
                    if (_workspace3ViewModel == null)
                    {
                        Debug.WriteLine("Workspace 3 ViewModel is null");
                        return;
                    }
                    _workspace3ViewModel.SelectedAppPath = openFileDialog.FileName;
                        _workspace3ViewModel.SelectedAppName = Path.GetFileName(_workspace3ViewModel.SelectedAppPath);
                        Settings.Default.W3SelectedAppName = _workspace3ViewModel.SelectedAppName;
                        Settings.Default.W3SelectedAppPath = _workspace3ViewModel.SelectedAppPath;
                    
                }
                else if (Equals(sender, W4SelectAppBtn))
                {
                    if (_workspace4ViewModel == null)
                    {
                        Debug.WriteLine("Workspace 4 ViewModel is null");
                        return;
                    }
                    _workspace4ViewModel.SelectedAppPath = openFileDialog.FileName;
                        _workspace4ViewModel.SelectedAppName = Path.GetFileName(_workspace4ViewModel.SelectedAppPath);
                        Settings.Default.W4SelectedAppName = _workspace4ViewModel.SelectedAppName;
                        Settings.Default.W4SelectedAppPath = _workspace4ViewModel.SelectedAppPath;
                    
                }
                else if (Equals(sender, W5SelectAppBtn))
                {

                    if (_workspace5ViewModel == null)
                    {
                        Debug.WriteLine("Workspace 5 ViewModel is null");
                        return;
                    }
                    _workspace5ViewModel.SelectedAppPath = openFileDialog.FileName;
                        _workspace5ViewModel.SelectedAppName = Path.GetFileName(_workspace5ViewModel.SelectedAppPath);
                        Settings.Default.W5SelectedAppName = _workspace5ViewModel.SelectedAppName;
                        Settings.Default.W5SelectedAppPath = _workspace5ViewModel.SelectedAppPath;
                    
                }
            }
        }

        /**
         * Associated File To Run With The Application
         */
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

                if (Equals(sender, W1SelectFileBtn))
                {
                    if (_workspace1ViewModel == null)
                    {
                        Debug.WriteLine("Workspace 1 ViewModel is null");
                        return;
                    }

                    _workspace1ViewModel.SelectedFilePath = openFileDialog.FileName;
                    _workspace1ViewModel.SelectedFileName = Path.GetFileName(_workspace1ViewModel.SelectedFilePath);
                    Settings.Default.W1SelectedFileName = _workspace1ViewModel.SelectedFileName;
                    Settings.Default.W1SelectedFilePath = _workspace1ViewModel.SelectedFilePath;
                }
                else if (Equals(sender, W2SelectFileBtn))
                {
                    if (_workspace2ViewModel == null)
                    {
                        Debug.WriteLine("Workspace 2 ViewModel is null");
                        return;
                    }

                    _workspace2ViewModel.SelectedFilePath = openFileDialog.FileName;
                    _workspace2ViewModel.SelectedFileName = Path.GetFileName(_workspace2ViewModel.SelectedFilePath);
                    Settings.Default.W2SelectedFileName = _workspace2ViewModel.SelectedFileName;
                    Settings.Default.W2SelectedFilePath = _workspace2ViewModel.SelectedFilePath;
                }
                else if (Equals(sender, W3SelectFileBtn))
                {
                    if (_workspace3ViewModel == null)
                    {
                        Debug.WriteLine("Workspace 3 ViewModel is null");
                        return;
                    }

                    _workspace3ViewModel.SelectedFilePath = openFileDialog.FileName;
                    _workspace3ViewModel.SelectedFileName = Path.GetFileName(_workspace3ViewModel.SelectedFilePath);
                    Settings.Default.W3SelectedFileName = _workspace3ViewModel.SelectedFileName;
                    Settings.Default.W3SelectedFilePath = _workspace3ViewModel.SelectedFilePath;
                }
                else if (Equals(sender, W4SelectFileBtn))
                {
                    if (_workspace4ViewModel == null)
                    {
                        Debug.WriteLine("Workspace 4 ViewModel is null");
                        return;
                    }

                    _workspace4ViewModel.SelectedFilePath = openFileDialog.FileName;
                    _workspace4ViewModel.SelectedFileName = Path.GetFileName(_workspace4ViewModel.SelectedFilePath);
                    Settings.Default.W4SelectedFileName = _workspace4ViewModel.SelectedFileName;
                    Settings.Default.W4SelectedFilePath = _workspace4ViewModel.SelectedFilePath;
                }
                else if (Equals(sender, W5SelectFileBtn))
                {
                    if (_workspace5ViewModel == null)
                    {
                        Debug.WriteLine("Workspace 5 ViewModel is null");
                        return;
                    }

                    _workspace5ViewModel.SelectedFilePath = openFileDialog.FileName;
                    _workspace5ViewModel.SelectedFileName = Path.GetFileName(_workspace5ViewModel.SelectedFilePath);
                    Settings.Default.W5SelectedFileName = _workspace5ViewModel.SelectedFileName;
                    Settings.Default.W5SelectedFilePath = _workspace5ViewModel.SelectedFilePath;
                }
            }
        }


        private void AddItem_Click(object sender, RoutedEventArgs e)
        {
            /*TODO: Suppose user selects appl and file on W1 but clicks the add button in W2 */
            if (Equals(sender, W1AddButton))
            {
                if (_workspace1ViewModel == null)
                {
                    Debug.WriteLine("Workspace 1 ViewModel is null");
                    return;
                }

                // Create a new WorkspaceItem
                WorkspaceItem newWorkspaceItem =
                    new WorkspaceItem(_workspace1ViewModel.SelectedAppName, _workspace1ViewModel.SelectedAppPath,
                        _workspace1ViewModel.SelectedFileName, _workspace1ViewModel.SelectedFilePath);

                // Get the collection from W1ListBox
                var collection = W1ListBox.ItemsSource as ObservableCollection<WorkspaceItem>;

                // Add the new WorkspaceItem to the collection
                _workspace1ViewModel.AddItem(collection, newWorkspaceItem);

                // Clearing values
                _workspace1ViewModel.SelectedAppName = String.Empty;
                _workspace1ViewModel.SelectedAppPath = String.Empty;
                _workspace1ViewModel.SelectedFileName = String.Empty;
                _workspace1ViewModel.SelectedFilePath = String.Empty;

            }
            else if (Equals(sender, W2AddButton))
            {
                if (_workspace2ViewModel == null)
                {
                    Debug.WriteLine("Workspace 2 ViewModel is null");
                    return;
                }

                WorkspaceItem newWorkspaceItem =
                    new WorkspaceItem(_workspace2ViewModel.SelectedAppName, _workspace2ViewModel.SelectedAppPath,
                        _workspace2ViewModel.SelectedFileName, _workspace2ViewModel.SelectedFilePath);

                var collection = W2ListBox.ItemsSource as ObservableCollection<WorkspaceItem>;

                _workspace2ViewModel.AddItem(collection, newWorkspaceItem);

                // Clearing values
                _workspace2ViewModel.SelectedAppName = String.Empty;
                _workspace2ViewModel.SelectedAppPath = String.Empty;
                _workspace2ViewModel.SelectedFileName = String.Empty;
                _workspace2ViewModel.SelectedFilePath = String.Empty;

            }
            else if (Equals(sender, W3AddButton))
            {
                if (_workspace3ViewModel == null)
                {
                    Debug.WriteLine("Workspace 3 ViewModel is null");
                    return;
                }

                WorkspaceItem newWorkspaceItem =
                    new WorkspaceItem(_workspace3ViewModel.SelectedAppName, _workspace3ViewModel.SelectedAppPath,
                        _workspace3ViewModel.SelectedFileName, _workspace3ViewModel.SelectedFilePath);

                var collection = W3ListBox.ItemsSource as ObservableCollection<WorkspaceItem>;

                _workspace3ViewModel.AddItem(collection, newWorkspaceItem);

                // Clearing values
                _workspace3ViewModel.SelectedAppName = String.Empty;
                _workspace3ViewModel.SelectedAppPath = String.Empty;
                _workspace3ViewModel.SelectedFileName = String.Empty;
                _workspace3ViewModel.SelectedFilePath = String.Empty;
            }
            else if (Equals(sender, W4AddButton))
            {
                if (_workspace4ViewModel == null)
                {
                    Debug.WriteLine("Workspace 4 ViewModel is null");
                    return;
                }

                WorkspaceItem newWorkspaceItem =
                    new WorkspaceItem(_workspace4ViewModel.SelectedAppName, _workspace4ViewModel.SelectedAppPath,
                        _workspace4ViewModel.SelectedFileName, _workspace4ViewModel.SelectedFilePath);

                var collection = W4ListBox.ItemsSource as ObservableCollection<WorkspaceItem>;

                _workspace4ViewModel.AddItem(collection, newWorkspaceItem);

                // Clearing values
                _workspace4ViewModel.SelectedAppName = String.Empty;
                _workspace4ViewModel.SelectedAppPath = String.Empty;
                _workspace4ViewModel.SelectedFileName = String.Empty;
                _workspace4ViewModel.SelectedFilePath = String.Empty;
            }
            else if (Equals(sender, W5AddButton))
            {
                if (_workspace5ViewModel == null)
                {
                    Debug.WriteLine("Workspace 5 ViewModel is null");
                    return;
                }

                WorkspaceItem newWorkspaceItem =
                    new WorkspaceItem(_workspace5ViewModel.SelectedAppName, _workspace5ViewModel.SelectedAppPath,
                        _workspace5ViewModel.SelectedFileName, _workspace5ViewModel.SelectedFilePath);

                var collection = W5ListBox.ItemsSource as ObservableCollection<WorkspaceItem>;

                _workspace5ViewModel.AddItem(collection, newWorkspaceItem);

                // Clearing values
                _workspace5ViewModel.SelectedAppName = String.Empty;
                _workspace5ViewModel.SelectedAppPath = String.Empty;
                _workspace5ViewModel.SelectedFileName = String.Empty;
                _workspace5ViewModel.SelectedFilePath = String.Empty;
            }
        }

        private void saveBtn_Click(object sender, RoutedEventArgs e)
        {
            Debug.WriteLine("-->saveBtn_Click");
            //After user makes changes to the TextBoxes, apply these to the main window buttons
            if (_workspaceOneBtn != null) _workspaceOneBtn.Content = W1NameTextBox.Text;
            if (_workspaceTwoBtn != null) _workspaceTwoBtn.Content = W2NameTextBox.Text;
            if (_workspaceThreeBtn != null) _workspaceThreeBtn.Content = W3NameTextBox.Text;
            if (_workspaceFourBtn != null) _workspaceFourBtn.Content = W4NameTextBox.Text;
            if (_workspaceFiveBtn != null) _workspaceFiveBtn.Content = W5NameTextBox.Text;

            // Update the setting  so that they are stored between application sessions
            Settings.Default.workspaceOneBtn = W1NameTextBox.Text;
            Settings.Default.workspaceTwoBtn = W2NameTextBox.Text;
            Settings.Default.workspaceThreeBtn = W3NameTextBox.Text;
            Settings.Default.workspaceFourBtn = W4NameTextBox.Text;
            Settings.Default.workspaceFiveBtn = W5NameTextBox.Text;

            //Serialization
            Settings.Default.W1WorkspaceItemsJsonString =
                _settingsHelper.SerializeItemCollectionToJson(W1ListBox.Items);
            Debug.WriteLine("W1WorkspaceItemsJsonString: ");
            Debug.WriteLine(Settings.Default.W1WorkspaceItemsJsonString);

            Settings.Default.W2WorkspaceItemsJsonString =
                _settingsHelper.SerializeItemCollectionToJson(W2ListBox.Items);
            Debug.WriteLine("W2WorkspaceItemsJsonString: ");
            Debug.WriteLine(Settings.Default.W2WorkspaceItemsJsonString);

            Settings.Default.W3WorkspaceItemsJsonString =
                _settingsHelper.SerializeItemCollectionToJson(W3ListBox.Items);
            Debug.WriteLine("W3WorkspaceItemsJsonString: ");
            Debug.WriteLine(Settings.Default.W3WorkspaceItemsJsonString);

            Settings.Default.W4WorkspaceItemsJsonString =
                _settingsHelper.SerializeItemCollectionToJson(W4ListBox.Items);
            Debug.WriteLine("W4WorkspaceItemsJsonString: ");
            Debug.WriteLine(Settings.Default.W4WorkspaceItemsJsonString);

            Settings.Default.W5WorkspaceItemsJsonString =
                _settingsHelper.SerializeItemCollectionToJson(W5ListBox.Items);
            Debug.WriteLine("W5WorkspaceItemsJsonString: ");
            Debug.WriteLine(Settings.Default.W5WorkspaceItemsJsonString);

            //Batch file creation
            BatchFileCreator w1BatchFileCreator = new BatchFileCreator("W1", W1ListBox.Items);
            BatchFileCreator w2BatchFileCreator = new BatchFileCreator("W2", W2ListBox.Items);
            BatchFileCreator w3BatchFileCreator = new BatchFileCreator("W3", W3ListBox.Items);
            BatchFileCreator w4BatchFileCreator = new BatchFileCreator("W4", W4ListBox.Items);
            BatchFileCreator w5BatchFileCreator = new BatchFileCreator("W5", W5ListBox.Items);

            // Save the changes to persist them
            Settings.Default.Save();

            this.Close();
        }

        private void cancelBtn_Click(object sender, RoutedEventArgs e)
        {
            this.Close();
        }

        private void SelectStartupCheckbox_OnChecked(object sender, RoutedEventArgs e)
        {
            if (SelectStartupCheckbox.IsChecked == true)
            {
                Debug.WriteLine("CheckBox is checked");
                Settings.Default.SelectStartupCheckboxValue = true;
                UpdateApplicationToStartup(true);
            }
            else if (SelectStartupCheckbox.IsChecked == false)
            {
                Debug.WriteLine("CheckBox is unchecked when it is suppose to be checked");
            }
            else
            {
                Debug.WriteLine("CheckBox state is indeterminate");
            }
        }

        private void SelectStartupCheckbox_OnUnchecked(object sender, RoutedEventArgs e)
        {

            if (SelectStartupCheckbox.IsChecked == false)
            {
                Debug.WriteLine("CheckBox is unchecked");
                Settings.Default.SelectStartupCheckboxValue = false;
                UpdateApplicationToStartup(false);
            }
            else if (SelectStartupCheckbox.IsChecked == true)
            {
                Debug.WriteLine("CheckBox is checked when it is suppose to be unchecked");
            }
            else
            {
                Debug.WriteLine("CheckBox state is indeterminate");
            }
        }

        private void UpdateApplicationToStartup(bool flagCheckbox)
        {
            var startupManager = new StartupManager();
            startupManager.EnableStartup(flagCheckbox);
        }
    }
}