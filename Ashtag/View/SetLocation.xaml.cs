using Ashtag.Resources;
using Microsoft.Phone.Controls;
using Microsoft.Phone.Maps.Controls;
using System;
using System.Device.Location;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Shapes;
using Windows.Devices.Geolocation;

namespace Ashtag
{
    public partial class SetLocation : PhoneApplicationPage
    {
        public SetLocation()
        {
            InitializeComponent();

            this.GetLocation();
        }

        private async void GetLocation()
        {
            Geolocator geolocator = new Geolocator();
            geolocator.DesiredAccuracy = PositionAccuracy.High;

            Geoposition position = null;

            try
            {
                position = await geolocator.GetGeopositionAsync(maximumAge: TimeSpan.FromSeconds(5), timeout: TimeSpan.FromSeconds(10));
            } // End Try
            catch (UnauthorizedAccessException ex)
            {
                MessageBox.Show("Unable to get location");
            } // End Catch

            this.LocationMap.Center = new GeoCoordinate(position.Coordinate.Latitude, position.Coordinate.Longitude);
            this.LocationMap.ZoomLevel = 15;

            this.AddPushpinOverlay();
        }

        private void AddPushpinOverlay()
        {
            Grid pushpinGrid = this.CreatePushpin();

            MapOverlay overlay = new MapOverlay();
            overlay.Content = pushpinGrid;
            overlay.GeoCoordinate = this.LocationMap.Center;
            overlay.PositionOrigin = new Point(0, 0.5);

            MapLayer layer = new MapLayer();
            layer.Add(overlay);
            this.LocationMap.Layers.Add(layer);
        }

        private Grid CreatePushpin()
        {
            Grid pushpinGrid = new Grid();
            pushpinGrid.RowDefinitions.Add(new RowDefinition());
            pushpinGrid.ColumnDefinitions.Add(new ColumnDefinition());
            pushpinGrid.Background = new SolidColorBrush(Colors.Transparent);

            Ellipse pushpin = new Ellipse();
            pushpin.Fill = new SolidColorBrush(Colors.Red);
            pushpin.Height = 20;
            pushpin.Width = 20;
            pushpin.SetValue(Grid.RowProperty, 0);
            pushpin.SetValue(Grid.ColumnProperty, 0);

            pushpinGrid.Children.Add(pushpin);

            return pushpinGrid;
        }

        private void LocationMap_Hold(object sender, GestureEventArgs e)
        {
            this.GetLocation();
        }

        private void LocationMap_DoubleTap(object sender, GestureEventArgs e)
        {
            this.GetLocation();
        }

        private void Submit_Click(object sender, EventArgs e)
        {
            string requestUrl = String.Format("{0}{1}", AppSettings.IASApiBaseUri, AppSettings.SubmitSightingUri);

            // TODO: Upload the image and location to IAS website

            MessageBox.Show("Your details have been sent.");

            PhoneApplicationFrame root = Application.Current.RootVisual as PhoneApplicationFrame;
            root.Navigate(new Uri("/MainPage.xaml", UriKind.Relative));
        }
    }
}