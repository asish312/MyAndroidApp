using Xamarin.Forms.PlatformConfiguration;
using Xamarin.Forms.PlatformConfiguration.AndroidSpecific;
using Xamarin.Forms.Xaml;

namespace XamarinFormApp
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class TabedPageView : Xamarin.Forms.TabbedPage
    {
        public TabedPageView()
        {
            InitializeComponent();
            On<Android>().SetToolbarPlacement(ToolbarPlacement.Bottom);
        }
    }
}