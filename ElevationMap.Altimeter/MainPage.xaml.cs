using Microsoft.Phone.Controls;
using NV.ElevationMap.Altimeter.Annotations;
using NV.ElevationMap.Altimeter.ViewModels;

namespace NV.ElevationMap.Altimeter
{
    // ReSharper disable once RedundantExtendsListEntry
    [UsedImplicitly]
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