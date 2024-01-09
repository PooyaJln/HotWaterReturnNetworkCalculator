using System.Windows;
using System.Windows.Controls;

namespace HotWaterReturnNetworkCalculator.View.UserControls
{
    /// <summary>
    /// Interaction logic for MenuBar.xaml
    /// </summary>
    public partial class MenuBar : UserControl
    {
        public MenuBar()
        {
            InitializeComponent();
        }

        bool running = false;

        private void addPipe_Click(object sender, RoutedEventArgs e)
        {

        }

        private void editPipe_Click(object sender, RoutedEventArgs e)
        {

        }

        private void deletePipe_Click(object sender, RoutedEventArgs e)
        {

        }

        private void button_toggle_Click(object sender, RoutedEventArgs e)
        {

            //if (!running)
            //{
            //    app_status.Text = "Status: Calculating";
            //    button_toggle.Content = "Stop";
            //}
            //else
            //{
            //    app_status.Text = "Status: Finished";
            //    button_toggle.Content = "Calculate";
            //}
            //running = !running;
        }
        private void button_Save_Click(object sender, RoutedEventArgs e)
        {

        }

        private void button_Exit_Click(object sender, RoutedEventArgs e)
        {
            // Close the window when the exit button is clicked
            Window parentWindow = Window.GetWindow(this);
            if (parentWindow != null)
            {
                parentWindow.Close();
            }
        }
    }
}
