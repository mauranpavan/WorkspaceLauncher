using System;
using System.Collections.Generic;
using System.Collections.Specialized;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Controls;
using Newtonsoft.Json;
using WorkspaceUI.Models;

namespace WorkspaceUI
{
    internal class SettingsHelper
    {
        public string SerializeItemCollectionToJson(ItemCollection itemCollection)
        {
            Debug.WriteLine("SerializeItemCollectionToJson");

            // Convert ItemCollection to List<WorkspaceItem>
            List<WorkspaceItem> workspaceItemsList = itemCollection.Cast<WorkspaceItem>().ToList();
            string json = JsonConvert.SerializeObject(workspaceItemsList, Formatting.Indented);
            Debug.WriteLine("Serialized list of WorkspaceItems");
            Debug.WriteLine(json);
            return json;
        }

        public List<WorkspaceItem>? DeserializeJsonToList(string json)
        {
            Debug.WriteLine("DeserializeJsonToItemCollection");
            List<WorkspaceItem>? deserializedList = JsonConvert.DeserializeObject<List<WorkspaceItem>>(json);
            Debug.WriteLine("Deserialized json into list of WorkspaceItems");
            Debug.WriteLine(deserializedList);
            return deserializedList;
        }


        public string ConvertStringCollectionToString(StringCollection stringCollection)
        {
            // Use a StringBuilder to concatenate the strings
            StringBuilder sb = new StringBuilder();
            foreach (string str in stringCollection)
            {
                sb.AppendLine(str); // Append each string with a newline
            }

            // Convert the StringBuilder to a single string
            string resultingString = sb.ToString();

            return resultingString;
        }

        public StringCollection ConvertStringToStringCollection(string inputString)
        {
            // Create a new StringCollection
            StringCollection resultingStringCollection = new StringCollection();

            // Split the input string into lines
            string[] lines = inputString.Split(new[] { '\r', '\n' }, System.StringSplitOptions.RemoveEmptyEntries);

            // Add each line to the StringCollection
            foreach (string line in lines)
            {
                resultingStringCollection.Add(line);
            }

            return resultingStringCollection;
        }

        public StringCollection ConvertItemCollectionToStringCollection(ItemCollection itemCollection)
        {
            StringCollection resultingStringCollection = new StringCollection();
            Debug.WriteLine("items in itemCollection");
            foreach (var item in itemCollection)
            {
                Debug.WriteLine(item.ToString());
                resultingStringCollection.Add(item.ToString());
            }

            return resultingStringCollection;
        }
    }
}