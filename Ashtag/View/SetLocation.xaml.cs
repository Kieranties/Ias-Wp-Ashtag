using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Navigation;
using Microsoft.Phone.Controls;
using Microsoft.Phone.Shell;
using Windows.Devices.Geolocation;
using Microsoft.Phone.Maps.Controls;
using System.Device.Location;
using System.Windows.Media;
using System.Windows.Shapes;

namespace Ashtag
{
    public partial class SetLocation : PhoneApplicationPage
    {
        public SetLocation()
        {
            InitializeComponent();
        }

        private async void GetLocation_Click(object sender, RoutedEventArgs e)
        {
            Geolocator geolocator = new Geolocator();
            geolocator.DesiredAccuracy = PositionAccuracy.High;

            Geoposition position = null;

            try
            {
                position = await geolocator.GetGeopositionAsync(maximumAge: TimeSpan.FromMinutes(5), timeout: TimeSpan.FromSeconds(10));
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

            Rectangle pushpin = new Rectangle();
            pushpin.Fill = new SolidColorBrush(Colors.Blue);
            pushpin.Height = 20;
            pushpin.Width = 20;
            pushpin.SetValue(Grid.RowProperty, 0);
            pushpin.SetValue(Grid.ColumnProperty, 0);

            pushpinGrid.Children.Add(pushpin);

            return pushpinGrid;
        }
    }
}