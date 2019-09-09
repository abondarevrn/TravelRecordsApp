using System;
using System.Collections.Generic;
using SQLite;
using TravelRecordsApp.Model;
using Xamarin.Forms;

namespace TravelRecordsApp
{
    public partial class NewTravelPage : ContentPage
    {
        public NewTravelPage()
        {
            InitializeComponent();
        }

        private void Save_Clicked(object sender, EventArgs e)
        {
            Post post = new Post
            {
                Experience = experienceEntry.Text
            };

            using (SQLiteConnection conn = new SQLiteConnection(App.DatabaseLocation))
            {
                conn.CreateTable<Post>();
                int rows = conn.Insert(post);

                if (rows > 0)
                {
                    DisplayAlert("Success", "Experience succesfully inserted", "Close");
                }
                else
                {
                    DisplayAlert("Error", "Experience insertion failed", "Close");
                }
            }
        }
    }
}
