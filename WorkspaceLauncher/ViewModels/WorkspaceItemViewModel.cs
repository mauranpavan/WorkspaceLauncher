using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Diagnostics;
using System.Runtime.CompilerServices;
using System.Windows.Input;
using WorkspaceLauncher.Models;

namespace WorkspaceLauncher.ViewModels
{
    class WorkspaceItemViewModel : INotifyPropertyChanged
    {
        private string _selectedAppPath = string.Empty;
        private string _selectedAppName = string.Empty;
        private string _selectedFilePath = string.Empty;
        private string _selectedFileName = string.Empty;

        public string SelectedAppPath
        {
            get => _selectedAppPath;
            set
            {
                if (_selectedAppPath != value)
                {
                    _selectedAppPath = value;
                    OnPropertyChanged(nameof(SelectedAppPath));
                }
            }
        }

        public string SelectedAppName
        {
            get => _selectedAppName;
            set
            {
                if (_selectedAppName != value)
                {
                    _selectedAppName = value;
                    OnPropertyChanged(nameof(SelectedAppName));
                }
            }
        }

        public string SelectedFilePath
        {
            get => _selectedFilePath;
            set
            {
                if (_selectedFilePath != value)
                {
                    _selectedFilePath = value;
                    OnPropertyChanged(nameof(SelectedFilePath));
                }
            }
        }

        public string SelectedFileName
        {
            get => _selectedFileName;
            set
            {
                if (_selectedFileName != value)
                {
                    _selectedFileName = value;
                    OnPropertyChanged(nameof(SelectedFileName));
                }
            }
        }

        private ObservableCollection<WorkspaceItem> _workspaceItems;

        public ObservableCollection<WorkspaceItem> WorkspaceItems
        {
            get => _workspaceItems;
            set
            {
                if (_workspaceItems != value)
                {
                    _workspaceItems = value;
                    OnPropertyChanged();
                }
            }
        }

        
        public ICommand RemoveItemCommand { get; }

        public WorkspaceItemViewModel()
        {
            WorkspaceItems = new ObservableCollection<WorkspaceItem> { };

            //RemoveItemCommand = new RelayCommand<WorkspaceItem>(RemoveItem);
            RemoveItemCommand =
                new RelayCommand<(ObservableCollection<WorkspaceItem> collection, WorkspaceItem item)>(RemoveItem);
        }

        // Generic method to add an item to any collection
        public void AddItem(ObservableCollection<WorkspaceItem>? collection, WorkspaceItem? item)
        {
            if (collection == null)
            {
                Debug.WriteLine("Null collection");
                return;
            }

            if (item == null)
            {
                Debug.WriteLine("Null Item not added to non-null collection");
                return;
            }

            collection.Add(item);
        }

        public void AddAllItems(ObservableCollection<WorkspaceItem> collection, List<WorkspaceItem>? listOfItems)
        {
            if (listOfItems == null) return;

            foreach (var item in listOfItems)
            {
                AddItem(collection, item);
            }
        }

        // Method to remove an item
        private void RemoveItem((ObservableCollection<WorkspaceItem> collection, WorkspaceItem item) parameter)
        {
            if (parameter.collection.Contains(parameter.item))
            {
                parameter.collection.Remove(parameter.item);
            }
        }

        public event PropertyChangedEventHandler? PropertyChanged;

        protected void OnPropertyChanged([CallerMemberName] string? name = null)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(name));
        }
    }
}