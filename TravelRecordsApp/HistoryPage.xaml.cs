using System;
using System.Linq;
using System.Collections.Generic;
using SQLite;
using TravelRecordsApp.Model;
using Xamarin.Forms;

namespace TravelRecordsApp
{
    public partial class HistoryPage : ContentPage
    {
        public HistoryPage()
        {
            InitializeComponent();
        }

        protected override void OnAppearing()
        {
            base.OnAppearing();
            using (SQLiteConnection conn = new SQLiteConnection(App.DatabaseLocation))
            {
                // the conn variable will exist just in the using statement scope

                // This is the first page that the user displays so it's important
                // that the table exist in the first place, if it's already created
                // this method call will not overwrite the current table.

                conn.CreateTable<Post>();

                // Reading from db with LINQ
                List<Post> posts = conn.Table<Post>().ToList();

                // since I'm using the using statement, once we are out of scope
                // the conn will no longer exist because the Dispose() method (implemented
                // in the SQLiteConnection and defined in the IDisposable a will be automatically
                // called and it's not necessary to close the connection manually
                // conn.Close();

                postsListView.ItemsSource = posts;
            }
        }

        private void PostListView_ItemSelected(object sender, SelectedItemChangedEventArgs e)
        {
            var selectedPost = e.SelectedItem as Post;
            if (selectedPost != null)
            {
                Navigation.PushAsync(new PostDetailPage(selectedPost));
            }
        }
    }
}
