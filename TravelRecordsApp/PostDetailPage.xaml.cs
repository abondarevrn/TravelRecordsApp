using System;
using System.Collections.Generic;
using SQLite;
using TravelRecordsApp.Model;
using Xamarin.Forms;

namespace TravelRecordsApp
{
    public partial class PostDetailPage : ContentPage
    {
        Post selectedPost;

        public PostDetailPage(Post post)
        {
            InitializeComponent();
            postNameEntry.Text = post.Experience;
            selectedPost = post;
        }

        void PostUpdateButton_Clicked(object sender, EventArgs e)
        {
            selectedPost.Experience = postNameEntry.Text;
            using (SQLiteConnection conn = new SQLiteConnection(App.DatabaseLocation))
            {
                conn.Update(selectedPost);
                DisplayAlert("Success", "Experience succesfully updated", "Close");
            }
        }

        async void PostDeleteButton_Clicked(object sender, EventArgs e)
        {
            using (SQLiteConnection conn = new SQLiteConnection(App.DatabaseLocation))
            {
                int currentRows = conn.Table<Post>().Count();
                int rows = conn.Delete(selectedPost);

                if (rows < currentRows)
                {
                    await DisplayAlert("Success", "Experience succesfully delete", "Close");
                    await Navigation.PopAsync();
                }
                else
                {
                    await DisplayAlert("Error", "Experience deletion failed", "Close");
                }
            }
        }
    }
}
