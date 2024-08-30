using System;
using System.Collections.Generic;
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
using System.Windows.Shapes;

namespace WorkspaceUI.UserControls
{
    /// <summary>
    /// Interaction logic for SettingsWindow.xaml
    /// </summary>
    public partial class SettingsWindow : Window
    {
        Button workspaceOneBtn;
        Button workspaceTwoBtn;
        Button workspaceThreeBtn;
        Button workspaceFourBtn;
        Button workspaceFiveBtn;

        public SettingsWindow()
        {
            InitializeComponent();
            MainWindow mainWindow = (MainWindow)Application.Current.MainWindow;

            //Retrieve stored application settings values from previous session
            W1.Text = Settings.Default.workspaceOneBtn;
            W2.Text = Settings.Default.workspaceTwoBtn;
            W3.Text = Settings.Default.workspaceThreeBtn;
            W4.Text = Settings.Default.workspaceFourBtn;
            W5.Text = Settings.Default.workspaceFiveBtn;


            workspaceOneBtn = (Button)mainWindow.FindName("workspaceOneBtn");
            workspaceTwoBtn = (Button)mainWindow.FindName("workspaceTwoBtn");
            workspaceThreeBtn = (Button)mainWindow.FindName("workspaceThreeBtn");
            workspaceFourBtn = (Button)mainWindow.FindName("workspaceFourBtn");
            workspaceFiveBtn = (Button)mainWindow.FindName("workspaceFiveBtn");

        }

        private void saveBtn_Click(object sender, RoutedEventArgs e)
        {
            //After user makes changes to the TextBoxes, apply these to the main window buttons
            workspaceOneBtn.Content = W1.Text;
            workspaceTwoBtn.Content = W2.Text;
            workspaceThreeBtn.Content = W3.Text;
            workspaceFourBtn.Content = W4.Text;
            workspaceFiveBtn.Content = W5.Text;

            // Update the setting  so that they are stored between application sessions
            Settings.Default.workspaceOneBtn = W1.Text;
            Settings.Default.workspaceTwoBtn = W2.Text;
            Settings.Default.workspaceThreeBtn = W3.Text;
            Settings.Default.workspaceFourBtn = W4.Text;
            Settings.Default.workspaceFiveBtn = W5.Text;

            // Save the changes to persist them
            Settings.Default.Save();

            this.Close();
        }

        private void cancelBtn_Click(object sender, RoutedEventArgs e)
        {
            this.Close();
        }

        private void openActionConfigWindow(object sender, RoutedEventArgs e)
        {
            ActionConfigWindow actionConfigWindow = new ActionConfigWindow();
            actionConfigWindow.Show();
        }
    }
}
