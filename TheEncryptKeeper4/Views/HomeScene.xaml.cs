using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.IO;
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
using System.Windows.Navigation;
using System.Windows.Shapes;
using TheEncryptKeeper4.DataAccess.Entities;
using TheEncryptKeeper4.Models;
using TheEncryptKeeper4.Services;

namespace TheEncryptKeeper4.Views
{
    /// <summary>
    /// Interaction logic for BrowsingScene.xaml
    /// </summary>
    public partial class HomeScene : UserControl, INotifyPropertyChanged
    {
        private const string fileName = @"C:\Users\Natedog769\Documents\_Documents\PWSheet.JSON";

        private string actionMessageOutput;
        public string ActionMessageOutput
        {
            get => actionMessageOutput;
            set
            {
                actionMessageOutput = value;
                OnPropertyChanged(nameof(ActionMessageOutput));
            }
        }

        public LoginEntry LoginModel { get; set; } = new LoginEntry();

        public List<LoginEntry> LoginList { get; set; } = new List<LoginEntry>();

        public List<LoginEntity> LoginEntityList { get; set; } = new List<LoginEntity>();

        public DatabaseService databaseService;

        public event PropertyChangedEventHandler PropertyChanged;
        protected void OnPropertyChanged(string propertyName)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }

        public HomeScene()
        {
            DataContext = this;
            InitializeComponent();
            ActionMessageOutput = string.Empty;
            
        }

        public void SaveJSONData()
        {
            var json = JsonConvert.SerializeObject(LoginList, Formatting.Indented);

            if (File.Exists(fileName))
            {
                File.Delete(fileName);
            }

            File.WriteAllText(fileName, json);

            ActionMessageOutput = "Data saved!";
        }

        public void LoadJSONData()
        {
            if (!File.Exists(fileName))
            {
                MessageBox.Show("Error File Cannot Be found! Creating new empty file");
                SaveJSONData();
            }
            else
            {
                var json = File.ReadAllText(fileName);

                List<LoginEntry> logins = JsonConvert.DeserializeObject<List<LoginEntry>>(json);

                LoginList.Clear();

                if (logins != null)
                {
                    LoginList.AddRange(logins);
                }

                LoginGrid.Items.Refresh();
            }
            ActionMessageOutput = "Data Loaded";
        }

        public void LoadData()
        {
            IList<LoginEntity> logins = databaseService.GetLoginEntities();

        }

        public void SaveEntry()
        {
            LoginEntry newEntry = new LoginEntry()
            {
                Website = LoginModel.Website,
                Username = LoginModel.Username,
                Email = LoginModel.Email,
                Password = LoginModel.Password,
                Notes = LoginModel.Notes
            };
            ClearInputs();

            LoginList.Add(newEntry);
            LoginGrid.Items.Refresh();

            SaveJSONData();
            ActionMessageOutput = "New Entry Saved";
        }

        public void SaveEntity()
        {
            LoginEntity newEntry = new LoginEntity()
            {
                ID = new Guid(),
                Website = LoginModel.Website,
                Username = LoginModel.Username,
                Email = LoginModel.Email,
                Password = LoginModel.Password,
                Notes = LoginModel.Notes
            };
            ClearInputs();

            LoginEntityList.Add(newEntry);
            LoginGrid.Items.Refresh();

            LoginEntity retVal = databaseService.CreateOrUpdateEntity(newEntry);
            SaveJSONData();
        }

        public void DeleteEntries()
        {
            List<LoginEntry> indexToDelete = new List<LoginEntry>();

            for (int i =0; i< LoginList.Count; i++)
            {
                if (LoginList[i].IsSelected)
                {
                    indexToDelete.Add(LoginList[i]);
                }
            }

            foreach(LoginEntry i in indexToDelete)
            {
                LoginList.Remove(i);
            }
            LoginGrid.Items.Refresh();

            SaveJSONData();
            ActionMessageOutput = "Entries Deleted";
        }


        public void ClearInputs()
        {
            LoginModel.ClearValues();
            txtWebsite.Clear();
            txtUsername.Clear();
            txtEmail.Clear();
            txtPassword.Clear();
            txtNotes.Clear();            
        }


        private void SaveBtn_Click(object sender, RoutedEventArgs e)
        {
            SaveEntry();
        }

        private void ResetBtn_Click(object sender, RoutedEventArgs e)
        {
            ClearInputs();
        }

        private void UserControl_Unloaded(object sender, RoutedEventArgs e)
        {
            SaveJSONData();
        }

        private void UserControl_Loaded(object sender, RoutedEventArgs e)
        {
            LoadJSONData();
        }

        private void SaveListButton_Click(object sender, RoutedEventArgs e)
        {
            SaveJSONData();
        }

        private void DeleteButton_Click(object sender, RoutedEventArgs e)
        {
            DeleteEntries();
        }

        private void LoginGrid_RowEditEnding(object sender, DataGridRowEditEndingEventArgs e)
        {
            SaveJSONData();
        }
        
        private void RefreshButton_Click(object sender, RoutedEventArgs e)
        {
            ActionMessageOutput = "Refreshed List";
            LoadJSONData();
            LoginGrid.Items.Refresh();
        }
    }
}
