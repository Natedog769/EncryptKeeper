using MahApps.Metro.Controls;
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
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace TheEncryptKeeper4
{
    /// <summary>
    /// The return of the encrypt keeper for the 4th time first was the web dev class
    /// second was in python console. and the 3rd was at work which this will essentially
    /// be the same but on my my machine and hopefully can have a working build.
    /// 
    /// buut so its a simple application with a page to enter new log in info
    /// a page to browse the items
    /// 
    /// The project will use entity framework for Database management
    /// and we can go easy or go proper with MVVM 
    /// but we will try to exercise good design here.
    /// 
    /// 
    /// </summary>
    public partial class MainWindow : MetroWindow
    {
        public MainWindow()
        {
            InitializeComponent();
        }
    }
}
