using Microsoft.Phone.Controls;
using NV.ElevationMap.Altimeter.ViewModels;

namespace ElevationMap.Altimeter
{
    public partial class MainPage : PhoneApplicationPage
    {
        // Constructor
        public MainPage()
        {
            DataContext = new MainViewModel();
            InitializeComponent();
        }
    }
}