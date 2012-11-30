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
    public partial class GuidPage : PhoneApplicationPage
    {
        public GuidPage()
        {
            InitializeComponent();
        }

        protected override void OnNavigatedTo(NavigationEventArgs e)
        {
            string selectedGuideStep;
            int guideStep = 1;

            if (NavigationContext.QueryString.TryGetValue("step", out selectedGuideStep))
            {
                guideStep = Convert.ToInt32(selectedGuideStep);
            } // End If

            guideStep -= 1;
            GuidePivot.SelectedIndex = guideStep;

            base.OnNavigatedTo(e);
        }

        private void SubmitSightingButton_Click(object sender, System.EventArgs e)
        {
            PhoneApplicationFrame root = Application.Current.RootVisual as PhoneApplicationFrame;
            root.Navigate(new Uri("/SelectImage.xaml", UriKind.Relative));
        }
    }
}