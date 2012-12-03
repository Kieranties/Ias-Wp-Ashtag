using Microsoft.Phone.Controls;
using System;
using System.Windows.Navigation;

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
    }
}