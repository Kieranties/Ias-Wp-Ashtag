using Ashtag.Helpers;
using Ashtag.Resources;
using Microsoft.Phone.Controls;
using Microsoft.Phone.Shell;
using System;
using System.IO.IsolatedStorage;
using System.Windows;

namespace Ashtag
{
    public partial class MainPage : PhoneApplicationPage
    {
        public MainPage()
        {
            InitializeComponent();

            Loaded += MainPage_Loaded;

            InitializePageControls();
        }

        private void MainPage_Loaded(object sender, RoutedEventArgs args)
        {
            this.BuildApplicationBar();
        }

        private void InitializePageControls()
        {
            if (IsolatedStorageSettings.ApplicationSettings.Contains("emailAddress"))
            {
                EmailAddress.Text = IsolatedStorageSettings.ApplicationSettings["emailAddress"].ToString();
            } // End If
        }

        public void BuildApplicationBar()
        {
            ApplicationBar appBar = new ApplicationBar();

            appBar.IsMenuEnabled = false;
            appBar.Mode = ApplicationBarMode.Default;

            var cameraButton = new ApplicationBarIconButton(new Uri("/Assets/AppBar/feature.camera.png", UriKind.Relative))
            {
                Text = AppResources.AppBar_SubmitSightingButtonText
            };
            cameraButton.Click += SubmitSightingButton_Click;
            appBar.Buttons.Add(cameraButton);

            var contactButton = new ApplicationBarIconButton(new Uri("/Assets/AppBar/feature.email.png", UriKind.Relative))
            {
                Text = AppResources.AppBar_ContactButtonText
            };
            appBar.Buttons.Add(contactButton);

            this.ApplicationBar = appBar;
        }

        private void SubmitSightingButton_Click(object sender, System.EventArgs e)
        {
            if (!String.IsNullOrEmpty(EmailAddress.Text))
            {
                if (!InputValidationHelper.IsValidEmailAddress(EmailAddress.Text))
                {
                    MessageBox.Show(AppResources.MainPage_InvalidEmailAddressMessageBoxText, AppResources.MainPage_InvalidEmailAddressMessageBoxCaption, MessageBoxButton.OK);
                } // End If
                else
                {
                    IsolatedStorageSettings.ApplicationSettings["emailAddress"] = EmailAddress.Text;
                    IsolatedStorageSettings.ApplicationSettings.Save();

                    PhoneApplicationFrame root = Application.Current.RootVisual as PhoneApplicationFrame;
                    root.Navigate(new Uri("/SelectImage.xaml", UriKind.Relative));
                } // End Else
            } // End If
            else
            {
                MessageBox.Show(AppResources.MainPage_EmptyEmailAddressMessageBoxText, AppResources.MainPage_EmptyEmailAddressMessageBoxCaption, MessageBoxButton.OK);
            } // End Else
        }
    }
}