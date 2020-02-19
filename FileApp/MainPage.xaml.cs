using ManagedBass.Wasapi;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Runtime.InteropServices.WindowsRuntime;
using System.Threading.Tasks;
using Windows.Foundation;
using Windows.Foundation.Collections;
using Windows.Storage;
using Windows.UI.Xaml;
using Windows.UI.Xaml.Controls;
using Windows.UI.Xaml.Controls.Primitives;
using Windows.UI.Xaml.Data;
using Windows.UI.Xaml.Input;
using Windows.UI.Xaml.Media;
using Windows.UI.Xaml.Navigation;

// The Blank Page item template is documented at https://go.microsoft.com/fwlink/?LinkId=402352&clcid=0x409

namespace FileApp
{
    /// <summary>
    /// An empty page that can be used on its own or navigated to within a Frame.
    /// </summary>
    public sealed partial class MainPage : Page
    {
        public MainPage()
        {
            this.InitializeComponent();
        }

        const string fileOwnerProperty = "System.Media.DateEncoded";

        public async Task<bool> SaveDateEncoded(StorageFile file)
        {
            var propertyNames = new List<string>();
            propertyNames.Add(fileOwnerProperty);
            IDictionary<string, object> dd = await file.Properties.RetrievePropertiesAsync(propertyNames);
            foreach (string key in dd.Keys)
            {
                object value = dd[key];
            }

            try
            {
                var dateTimeOffset = new DateTimeOffset(2000, 09, 03, 3, 50, 13, new TimeSpan(2, 0, 0));
                var props = new List<KeyValuePair<string, object>>()
            {
                        new KeyValuePair<string, object>("System.Media.DateEncoded", dateTimeOffset),
            };
                await file.Properties.SavePropertiesAsync(props);
                return true;
            }
            catch (Exception ex)
            {
                return false;
            }
        }

        private async void Button_Click(object sender, RoutedEventArgs e)
        {
            StorageFolder f = KnownFolders.VideosLibrary;
            StorageFile MyMp4file = await StorageFile.GetFileFromApplicationUriAsync(new Uri("ms-appx:///Assets/MyMp4.mp4"));
            await SaveDateEncoded(MyMp4file);
            
        }

        private async void Button_Click_1(object sender, RoutedEventArgs e)
        {
            StorageFolder f = KnownFolders.VideosLibrary;
            StorageFile OpMp4file = await StorageFile.GetFileFromApplicationUriAsync(new Uri("ms-appx:///Assets/VID_20191007_164325.mp4"));
            await SaveDateEncoded(OpMp4file);
        }
    }
}
