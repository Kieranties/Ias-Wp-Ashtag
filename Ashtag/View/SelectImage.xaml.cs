using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Navigation;
using Microsoft.Phone.Controls;
using Microsoft.Phone.Shell;
using Microsoft.Phone.Tasks;
using System.Windows.Media.Imaging;

namespace Ashtag
{
    public partial class SelectImage : PhoneApplicationPage
    {
        private PhotoChooserTask _photoChooserTask;
        private CameraCaptureTask _cameraCaptureTask;

        public SelectImage()
        {
            InitializeComponent();

            this._photoChooserTask = new PhotoChooserTask();
            this._photoChooserTask.Completed += new EventHandler<PhotoResult>(PhotoChooserTask_Completed);

            this._cameraCaptureTask = new CameraCaptureTask();
            this._cameraCaptureTask.Completed += new EventHandler<PhotoResult>(CameraCaptureTask_Completed);
        }

        private void ChoosePicture_Click(object sender, System.EventArgs e)
        {
            this._photoChooserTask.Show();
        }

        private void TakePicture_Click(object sender, System.EventArgs e)
        {
            this._cameraCaptureTask.Show();
        }

        private void PhotoChooserTask_Completed(object sender, PhotoResult e)
        {
            if (e.TaskResult == TaskResult.OK)
            {
                MessageBox.Show(e.ChosenPhoto.Length.ToString());

                BitmapImage bmp = new BitmapImage();
                bmp.SetSource(e.ChosenPhoto);
                SelectedImage.Source = bmp;
            }
        }

        private void CameraCaptureTask_Completed(object sender, PhotoResult e)
        {
            if (e.TaskResult == TaskResult.OK)
            {
                BitmapImage bmp = new BitmapImage();
                bmp.SetSource(e.ChosenPhoto);
                SelectedImage.Source = bmp;
            }
        }

        private void ApplicationBarIconButton_Click_1(object sender, System.EventArgs e)
        {
            PhoneApplicationFrame root = Application.Current.RootVisual as PhoneApplicationFrame;
        	root.Navigate(new Uri("/View/SetLocation.xaml", UriKind.Relative));
        }
    }
}