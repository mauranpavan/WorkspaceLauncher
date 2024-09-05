using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WorkspaceUI.Models
{
    internal class WorkspaceItem
    {
        //public string? ApplicationName { get; set; }
        public string? ApplicationPath { get; set; }
        public string? FileName { get; set; }
        public string? FilePath { get; set; }

        private string _applicationName;

        public string ApplicationName
        {
            get => _applicationName;
            set
            {
                if (_applicationName != value)
                {
                    _applicationName = value;
                    OnPropertyChanged(nameof(ApplicationName)); // Ensure that the correct property name is passed
                }
            }
        }

        public WorkspaceItem() { }

        public WorkspaceItem(int workspaceIndex)
        {
            ApplicationName = "Workspace Application " + workspaceIndex;
            ApplicationPath = "Workspace Application Path " + workspaceIndex;
            FileName = "Workspace File " + workspaceIndex;
            FilePath = "Workspace File Path " + workspaceIndex;
        }

        public WorkspaceItem(string? applicationName, string? applicationPath, string? fileName, string? filePath)
        {
            this.ApplicationName = applicationName;
            this.ApplicationPath = applicationPath;
            this.FileName = fileName;
            this.FilePath = filePath;
        }

        public override string ToString()
        {

            return String.Format("{0}==> {1}{2}{3}==> {4}", ApplicationName, ApplicationPath, Environment.NewLine,
                FileName, FilePath);
        }

        public event PropertyChangedEventHandler PropertyChanged;

        protected void OnPropertyChanged(string propertyName)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }
    }

}
