using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Runtime.InteropServices.WindowsRuntime;
using System.Threading.Tasks;
using Windows.Foundation;
using Windows.Foundation.Collections;
using Windows.UI.Composition;
using Windows.UI;
using Windows.UI.Xaml;
using Windows.UI.Xaml.Controls;
using Windows.UI.Xaml.Controls.Primitives;
using Windows.UI.Xaml.Data;
using Windows.UI.Xaml.Input;
using Windows.UI.Xaml.Media;
using Windows.UI.Xaml.Navigation;
using Windows.UI.Xaml.Media.Animation;

// The Blank Page item template is documented at http://go.microsoft.com/fwlink/?LinkId=402352&clcid=0x409

namespace App1
{
    /// <summary>
    /// An empty page that can be used on its own or navigated to within a Frame.
    /// </summary>
    public sealed partial class MainPage : Page
    {
        Point startpoint;
        Point lastPostition;
        public static MainPage current;
        bool isopen = false;
        public MainPage()
        {
            this.InitializeComponent();
           
        }

        
        #region PanelAnimate
        private void gridMain_ManipulationDelta(object sender, ManipulationDeltaRoutedEventArgs e)
        {
            // ManipulationDelta hamzaman ba tagheire positione angosht ya mouse emal mishe
            // ma niyaz darim akharin jaei ke manipulate anjam shode begirim

            if (e.Position.Y < gridMain.MinHeight) return;

            if (lastPostition.Y < 565 && !isopen)
            {
                try
                {
                   // detstack.Opacity += e.Delta.Translation.Y / 100;
                    myScaleTransform.Y += e.Delta.Translation.Y;
                    lastPostition.Y += e.Delta.Translation.Y;
                }
                catch { }
            }
            else if (lastPostition.Y >= 185 && isopen)
            {
                try
                {
                   // detstack.Opacity += e.Delta.Translation.Y / 100;
                    myScaleTransform.Y += e.Delta.Translation.Y;
                    lastPostition.Y += e.Delta.Translation.Y;
                }
                catch { }
            }
            //
        }
        private void btnShowHide_Click(object sender, RoutedEventArgs e)
        {
            animate();
        }

        private async void animate()
        {
            if (isopen == false)
            {
               // Pashmz.BlurAmount = 30;
                myStoryboard.Begin();
                    rotate.Begin();
                    await Task.Delay(500);
                   
                    isopen = !isopen;
              

            }
            else
            {
                Storyboard storyboard = new Storyboard();

              //  Pashmz.BlurAmount = 10;
                urStoryboard.Begin();
                    unrotate.Begin();
                    await Task.Delay(300);
                

                    isopen = !isopen;
                
            }
        }

        private void gridMain_ManipulationCompleted(object sender, ManipulationCompletedRoutedEventArgs e)
        {
            if (e.Cumulative.Translation.Y > 0 && !isopen) isopen = false;
            if (e.Cumulative.Translation.Y < 0 && isopen) isopen = true;
            if (e.Cumulative.Translation.Y == 0) return;
            animate();
        }


        private void gridMain_ManipulationStarted(object sender, ManipulationStartedRoutedEventArgs e)
        {
            startpoint = e.Position;
            lastPostition = e.Position;
        }

        #endregion
    }
}
