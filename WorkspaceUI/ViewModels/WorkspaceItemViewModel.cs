using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;

namespace WorkspaceUI.ViewModels
{
    class WorkspaceItemViewModel : INotifyPropertyChanged
    {
        // ObservableCollection to hold the list of items
        private ObservableCollection<string> _items = new ObservableCollection<string>{};
        public ObservableCollection<string> Items
        {
            get => _items;
            set { _items = value; OnPropertyChanged(); }
        }

        public WorkspaceItemViewModel()
        {
            Items = new ObservableCollection<string>
            {
                "Workspace Item 1",
                "Workspace Item 2",
                "Workspace Item 3"
            };
        }

        // Method to add an item
        public void AddItem(string item)
        {
            Items.Add(item);
        }

        // Method to remove an item
        public void RemoveItem(string item)
        { 
            Items.Remove(item);
        }

        public event PropertyChangedEventHandler? PropertyChanged;
        protected void OnPropertyChanged([CallerMemberName] string? name = null)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(name));
        }
    }
}


