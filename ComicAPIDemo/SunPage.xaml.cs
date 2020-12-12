using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Runtime.InteropServices.WindowsRuntime;
using Windows.Foundation;
using Windows.Foundation.Collections;
using Windows.UI.Xaml;
using Windows.UI.Xaml.Shapes;
using Windows.UI.Xaml.Controls;
using Windows.UI.Xaml.Controls.Primitives;
using Windows.UI.Xaml.Data;
using Windows.UI.Xaml.Input;
using Windows.UI.Xaml.Media;
using Windows.UI.Xaml.Navigation;

// The Blank Page item template is documented at https://go.microsoft.com/fwlink/?LinkId=234238

namespace ComicAPIDemo
{
    /// <summary>
    /// An empty page that can be used on its own or navigated to within a Frame.
    /// </summary>
    public partial class SunPage : Page
    {
        public SunPage()
        {
            InitializeComponent();
        }

        private async void LoadSunInfo_Click(object sender, RoutedEventArgs e)
        {
            //first get the sun information for the processor
            var sunInfo = await SunProcessor.LoadSunInformation();

            SunriseText.Text = $"Sunrise is at {sunInfo.Sunrise.ToLocalTime().ToShortTimeString() }";
            SunsetText.Text = $"Sunset is at {sunInfo.Sunset.ToLocalTime().ToShortTimeString() }";


        }

    }
}
