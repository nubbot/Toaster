using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;
using System.Windows.Threading;

namespace Toaster
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class Toast : Window
    {
        private DispatcherTimer dispatcherTimer;
        public Toast()
        {
            InitializeComponent();
            this.dispatcherTimer = new DispatcherTimer();
            this.dispatcherTimer.Tick += DispatcherTimer_Tick;

            this.Loaded += Toast_Loaded;
        }

        private void Toast_Loaded(object sender, RoutedEventArgs e)
        {
            this.dispatcherTimer.Start();
        }

        private void DispatcherTimer_Tick(object sender, EventArgs e)
        {
            this.Dismiss();
        }

        internal void SetMessage(string message)
        {
            this.tbMessage.Text = message;
        }

        internal void SetPosition(Point point)
        {
            if (point.X == 0 && point.Y == 0)
            {
                this.WindowStartupLocation = WindowStartupLocation.CenterScreen;
            }
            else
            {
                this.WindowStartupLocation = WindowStartupLocation.Manual;
                this.Left = point.X;
                this.Top = point.Y;
            }
        }

        internal void SetIntervalInMs(int intervalInMs)
        {
            this.dispatcherTimer.Interval = TimeSpan.FromMilliseconds(intervalInMs);
        }

        internal void SetBackground(System.Windows.Media.Color color)
        {
            this.Background = new SolidColorBrush(color);
        }

        private void Dismiss()
        {
            this.dispatcherTimer.Stop();
            this.Close();
        }
    }
}
