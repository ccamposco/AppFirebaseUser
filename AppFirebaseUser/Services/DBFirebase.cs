using AppFirebaseUser.Model;
using Firebase.Database;
using Firebase.Database.Query;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AppFirebaseUser.Services
{
    public class DBFirebase

    {
        public FirebaseClient client;

        public DBFirebase()
        {
            client = new FirebaseClient(
                "https://myusers-f1961-default-rtdb.firebaseio.com/");
        }

        public ObservableCollection<Users> GetUsersList()
        {
            var userdata = client
                .Child("Users")
                .AsObservable<Users>()
                .AsObservableCollection();
            return userdata;

        }

        public async Task AddUser(string firstName, string lastName, int age)
        {
            Users u = new Users()
            {
                FirstName = firstName,
                LastName = lastName,
                Age = age

            };
            await client
                .Child("Users")
                .PostAsync(u);
        }

        public async Task UpdateUser(string firstName, string lastName, int age)
        {
            var toUpdateUser = (await client
                .Child("Users")
                .OnceAsync<Users>())
                .FirstOrDefault(a => a.Object.FirstName == firstName);

            Users u = new Users()
            {
                FirstName = firstName,
                LastName = lastName,
                Age = age
            };
            await client
                .Child("Users")
                .Child(toUpdateUser.Key)
                .PutAsync(u);
        }
    }
}
