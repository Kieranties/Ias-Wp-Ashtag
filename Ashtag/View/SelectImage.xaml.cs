using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Navigation;
using Microsoft.Phone.Controls;
using Microsoft.Phone.Shell;

namespace Ashtag
{
    public partial class SelectImage : PhoneApplicationPage
    {
        public SelectImage()
        {
            InitializeComponent();
        }

        private void ApplicationBarIconButton_Click_1(object sender, System.EventArgs e)
        {
            PhoneApplicationFrame root = Application.Current.RootVisual as PhoneApplicationFrame;
        	root.Navigate(new Uri("/View/SetLocation.xaml", UriKind.Relative));
        }
    }
}