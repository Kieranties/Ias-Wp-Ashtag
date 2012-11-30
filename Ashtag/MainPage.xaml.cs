using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Navigation;
using Microsoft.Phone.Controls;
using Microsoft.Phone.Shell;
using Ashtag.Resources;
using System.IO.IsolatedStorage;

namespace Ashtag
{
    public partial class MainPage : PhoneApplicationPage
    {
        public MainPage()
        {
            InitializeComponent();
            InitializePageControls();
        }

        private void InitializePageControls()
        {
            if (IsolatedStorageSettings.ApplicationSettings.Contains("emailAddress"))
            {
                EmailAddress.Text = IsolatedStorageSettings.ApplicationSettings["emailAddress"].ToString();
            } // End If
        }

        private void SubmitSightingButton_Click(object sender, System.EventArgs e)
        {
            // TODO: Needs email address validation.
            if (!String.IsNullOrEmpty(EmailAddress.Text))
            {
                IsolatedStorageSettings.ApplicationSettings["emailAddress"] = EmailAddress.Text;
                IsolatedStorageSettings.ApplicationSettings.Save();

                PhoneApplicationFrame root = Application.Current.RootVisual as PhoneApplicationFrame;
                root.Navigate(new Uri("/SelectImage.xaml", UriKind.Relative));
            } // End If
            else
            {
                MessageBox.Show(AppResources.MainPage_EmptyEmailAddressMessageBoxText, AppResources.MainPage_EmptyEmailAddressMessageBoxCaption, MessageBoxButton.OK);
            } // End Else
        }
    }
}