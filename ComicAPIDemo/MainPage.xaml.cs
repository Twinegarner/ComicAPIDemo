using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Runtime.InteropServices.WindowsRuntime;
using System.Threading.Tasks;
using Windows.Foundation;
using Windows.Foundation.Collections;
using Windows.UI.Xaml;
using Windows.UI.Xaml.Controls;
using Windows.UI.Xaml.Controls.Primitives;
using Windows.UI.Xaml.Data;
using Windows.UI.Xaml.Input;
using Windows.UI.Xaml.Media;
using Windows.UI.Xaml.Media.Imaging;
using Windows.UI.Xaml.Navigation;

// The Blank Page item template is documented at https://go.microsoft.com/fwlink/?LinkId=402352&clcid=0x409

namespace ComicAPIDemo
{
    /// <summary>
    /// An empty page that can be used on its own or navigated to within a Frame.
    /// </summary>
    public partial class MainPage : Page
    {
        //vars for the comic number
        private int maxNumber = 0;
        private int currentNumber = 0;
        public MainPage()
        {
            this.InitializeComponent();
            //helper makes calls on the internet
            ApiHelper.InitializeClient();
            //its false if the user is at the latest comic
            NextButton.IsEnabled = false;
        }

        private async Task LoadImage(int imageNumber = 0)
        {
            var comic = await ComicProcessor.LoadComic(imageNumber);
            //if no comic is chosen
            if(imageNumber == 0)
            {
                maxNumber = comic.Num;
            }

            currentNumber = comic.Num;
            //grabs the url in full
            var uriSource = new Uri(comic.Img, UriKind.Absolute);
            //place in xaml page
            comicImage.Source = new BitmapImage(uriSource);
        }

        private async void Page_Loaded(object sender, RoutedEventArgs e)
        {
            await LoadImage();
        }

        private async void PreviousButton_Click(object sender, RoutedEventArgs e)
        {
            //guessing that the first image starts with 1 
            if (currentNumber > 1)
            {
                currentNumber -= 1;
                NextButton.IsEnabled = true;
                await LoadImage(currentNumber);
                //if at the end dont go further back
                if (currentNumber == 1)
                {
                    PreviousButton.IsEnabled = false;
                }
            }
        }

        private async void NextButton_Click(object sender, RoutedEventArgs e)
        {
            //if not max the find a newer comic
            if (currentNumber < maxNumber)
            {
                currentNumber += 1;
                //if previous is false then make it ture 
                PreviousButton.IsEnabled = true;
                //load new image 
                await LoadImage(currentNumber);
                if (currentNumber == maxNumber)
                {
                    NextButton.IsEnabled = false;
                }
            }
        }
    }
}
