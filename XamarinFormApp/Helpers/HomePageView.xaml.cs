﻿using System;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace XamarinFormApp.Helpers
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class HomePageView : ContentPage
    {
        public HomePageView()
        {
            InitializeComponent();

            //this.Navigation.PopAsync();
            //this.Navigation.PopToRootAsync();
            BirthDayDatePicker.Date = DateTime.Today;
            RegisterButton.IsEnabled = false;
        }
        private void BirthDayDatePicker_OnDateSelected(object sender, DateChangedEventArgs e)
        {
            if (e.NewDate == DateTime.Today)
            {
                //show warning that this is impossible
                DisplayAlert("Alert", "You weren't born today I guess", "OK, true!");
            }
        }

        private async void RegisterButton_OnClicked(object sender, EventArgs e)
        {
            await DisplayAlert("Success", "You have registered successfully", "Done");
        }

        private void UserNameEntry_OnTextChanged(object sender, TextChangedEventArgs e)
        {
            RegisterButton.IsEnabled = CheckCanRegister();
        }

        private void PasswordEntry_OnTextChanged(object sender, TextChangedEventArgs e)
        {

            RegisterButton.IsEnabled = CheckCanRegister();
        }

        private bool CheckCanRegister()
        {
            if (UserNameEntry.Text?.Length > 0 && PasswordEntry.Text?.Length > 0)
                return true;
            return false;
        }
    }
}