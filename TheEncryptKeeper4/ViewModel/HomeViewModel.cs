using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using TheEncryptKeeper4.DataAccess.Entities;
using TheEncryptKeeper4.Models;
using TheEncryptKeeper4.Services;

namespace TheEncryptKeeper4.ViewModel
{
    public class HomeViewModel: INotifyPropertyChanged
    {
        private const string fileName = @"pack:application:,,,\Resouces\PWSheet.JSON";

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
        //VM constructor
        public HomeViewModel()
        {

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
            Console.WriteLine("Data saved");
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

            SaveJSONData();
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

            LoginEntity retVal = databaseService.CreateOrUpdateEntity(newEntry);
            SaveJSONData();
        }

        public void DeleteEntries()
        {
            List<int> indexToDelete = new List<int>();

            for (int i = 0; i < LoginList.Count; i++)
            {
                if (LoginList[i].IsSelected)
                {
                    indexToDelete.Add(i);
                }
            }

            foreach (int i in indexToDelete)
            {
                LoginList.RemoveAt(i);
            }

            ActionMessageOutput = "Entries Deleted";
            SaveJSONData();
        }


        public void ClearInputs()
        {
            LoginModel.ClearValues();
        }
    }
}
