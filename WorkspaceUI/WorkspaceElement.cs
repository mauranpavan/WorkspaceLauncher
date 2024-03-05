using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WorkspaceUI
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
