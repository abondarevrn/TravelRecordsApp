﻿using System;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace TravelRecordsApp
{
    public partial class App : Application
    {
        // Database location is different on Android and iOS
        public static string DatabaseLocation = string.Empty;

        public App()
        {
            InitializeComponent();

            MainPage = new NavigationPage(new MainPage());
        }

        public App(string databaseLocation)
        {
            InitializeComponent();

            DatabaseLocation = databaseLocation;

            MainPage = new NavigationPage(new MainPage());
        }

        protected override void OnStart()
        {
            // Handle when your app starts
        }

        protected override void OnSleep()
        {
            // Handle when your app sleeps
        }

        protected override void OnResume()
        {
            // Handle when your app resumes
        }
    }
}
