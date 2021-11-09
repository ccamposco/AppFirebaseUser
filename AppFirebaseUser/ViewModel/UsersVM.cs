using AppFirebaseUser.Model;
using AppFirebaseUser.Services;
using MvvmHelpers;
using MvvmHelpers.Commands;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Text;
using System.Threading.Tasks;

namespace AppFirebaseUser.ViewModel
{
    public class UsersVM : BaseViewModel
    {
        private DBFirebase services;

        public string FirstName { get; set; }
        public string LastName { get; set; }
        public int Age { get; set; }

        public Command SaveUsersCommand { get; set; }

        private ObservableCollection<Users> users = new ObservableCollection<Users>();

        public ObservableCollection<Users> UserList
        {
            get { return users; }

            set
            {
                users = value;
                OnPropertyChanged();
            }
        }

        public UsersVM()
        {
            services = new DBFirebase();
            UserList = services.GetUsersList();
            SaveUsersCommand = new Command(
                async () => await SaveUsersAsync(FirstName, LastName, Age));
        }

        public async Task SaveUsersAsync(string firstname, string lastname, int age)
        {
            await services.AddUser(firstname, lastname,age);
        }
    }
}
