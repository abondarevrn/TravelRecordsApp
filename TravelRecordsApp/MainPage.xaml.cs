using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Forms;

namespace TravelRecordsApp
{
    [DesignTimeVisible(true)]
    public partial class MainPage : ContentPage
    {
        public MainPage()
        {
            InitializeComponent();
        }

        public void LoginButton_Clicked(object sender, EventArgs e)
        {
            bool isUsernameValid = !string.IsNullOrEmpty(usernameEntry.Text);
            bool isPasswordValid = !string.IsNullOrEmpty(passwordEntry.Text);
            if (isUsernameValid && isPasswordValid)
            {
                Navigation.PushAsync(new HomePage());
            } 
        }
    }
}
