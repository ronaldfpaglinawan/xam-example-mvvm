using Example.Model;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Text;
using System.Windows.Input;
using Xamarin.Forms;

namespace Example.ViewModel
{
    public class MainVM : INotifyPropertyChanged
    {
        private string username;
        public string Username
        {
            get 
            { 
                return username; 
            }
            set 
            { 
                username = value;
                OnPropertyChanged("Username");
                OnPropertyChanged("Greeting");
            }
        }

        public string Greeting
        {
            get 
            { 
                return $"Hello {Username}!"; 
            }
        }

        public ICommand ClearCommand { get; set; }
        public ObservableCollection<Contact> Contacts { get; set; }
        public event PropertyChangedEventHandler PropertyChanged;

        public MainVM()
        {
            Contacts = new ObservableCollection<Contact>();
            Contacts.Add(new Contact
            {
                Name = "Ronald",
                Email = "ronald@ironman.com"
            });

            Contacts.Add(new Contact
            {
                Name = "Tony Stark",
                Email = "ironman@avengers.com"
            });

            Contacts.Add(new Contact
            {
                Name = "Steve Rogers",
                Email = "captainamerica@avengers.com"
            });


            ClearCommand = new Command(ClearUsername, ClearCanExecute);
        }

        private bool ClearCanExecute(object parameter)
        {
            return !string.IsNullOrEmpty(Username);
        }

        private void ClearUsername(object parameter)
        {
            Username = string.Empty;
        }

        private void OnPropertyChanged(string propertyName)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }
    }
}
