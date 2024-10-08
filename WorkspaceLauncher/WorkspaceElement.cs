using System.Collections.ObjectModel;

namespace WorkspaceLauncher
{
    internal class WorkspaceElement : ObservableCollection<string>
    {
            public WorkspaceElement()
            {

                Add("OneDrive");
                Add("GoogleDrive");
                Add("Custom");
            }
        
    }
}
