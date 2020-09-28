using System;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace XamarinFormApp.Helpers
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class ContactusView : ContentPage
    {
        public ContactusView()
        {
            InitializeComponent();
        }

        private void ContactMeSwitch_Toggled(object sender, ToggledEventArgs e)
        {
            //handle the switch change here
            DisplayAlert("Success", "Hey stop switching", "Done");
        }

        private void SendMessageButton_Clicked(object sender, EventArgs e)
        {
            DisplayAlert("Success", "Message sent successfully to Don", "Done");
        }
    }
}