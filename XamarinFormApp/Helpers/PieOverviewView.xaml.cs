
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace XamarinFormApp.Helpers
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class PieOverviewView : ContentPage
    {
        public PieOverviewView()
        {
            InitializeComponent();
        }

        private async void Button_Clicked(object sender, System.EventArgs e)
        {
            bool answer = await DisplayAlert("Question?", "Would you like to see this app working", "Yes", "No");
            
            //popupLayout.PopupView.AnimationMode = AnimationMode.Zoom;
        }
    }
}