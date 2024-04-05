using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using TheEncryptKeeper4.Models;

namespace TheEncryptKeeper4.ViewModels
{
    public class HomeSceneViewModel
    {

        private const string fileName = @"C:\Users\Natedog769\Documents\_Documents\PWSheet.JSON";

        public LoginEntry loginModel;
        public ObservableCollection<LoginEntry> items { get; } = new ObservableCollection<LoginEntry>();

        public BrowseViewModel browseViewModel;
        public NewEntryViewModel entryViewModel;
        
        public HomeSceneViewModel()
        {
            Console.WriteLine("Initializing HomeSceneViewModel");
            browseViewModel = new BrowseViewModel();
            entryViewModel = new NewEntryViewModel();
        }


        public void LoadData()
        {
            if (!File.Exists(fileName))
            {
                MessageBox.Show("Error File Cannot Be found!");
            }

            var json = File.ReadAllText(fileName);

            List<LoginEntry> logins = JsonConvert.DeserializeObject<List<LoginEntry>>(json);

            items.Clear();

        }

        public void SaveEntry()
        {
            LoginEntry newEntry = new LoginEntry()
            {
                Website = loginModel.Website,
                Username = loginModel.Username,
                Email = loginModel.Email,
                Password = loginModel.Password,
                Notes = loginModel.Notes
            };

            items.Add(newEntry);
        }

        public void SaveData()
        {
            var json = JsonConvert.SerializeObject(items, Formatting.Indented);


            if (File.Exists(fileName))
            {
                File.Delete(fileName);
            }


            File.WriteAllText(fileName, json);
        }
    }
}