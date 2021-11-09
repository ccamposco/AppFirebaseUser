using AppFirebaseUser.Model;
using AppFirebaseUser.ViewModel;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Forms;

namespace AppFirebaseUser
{
    public partial class MainPage : ContentPage
    {
        public MainPage()
        {
            InitializeComponent();
            BindingContext = new UsersVM();
        }

        private async void ListView_OnItemTapped(object sender, ItemTappedEventArgs e)
        {
            var users = e.Item as Users;
            if (users == null)
                return;
            
        }
    }
}
