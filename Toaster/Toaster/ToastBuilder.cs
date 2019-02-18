using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Media;

namespace Toaster
{
    public class ToastBuilder
    {
        private string message = "";
        private int pos_x;
        private int pos_y;
        private int intervalInMs;
        private string color = "";
        public ToastBuilder SetMessage(string message)
        {
            this.message = message;
            return this;
        }
        public ToastBuilder SetPosition(int pos_x, int pos_y)
        {
            this.pos_x = pos_x;
            this.pos_y = pos_y;
            return this;
        }
        public ToastBuilder SetIntervalInMs(int intervalInMs)
        {
            this.intervalInMs = intervalInMs;
            return this;
        }
        public ToastBuilder SetBackgroundColor(string colorInHex)
        {
            this.color = colorInHex;
            return this;
        }
        public void Show()
        {
            var toast = new Toast();
            toast.SetMessage(this.message);
            toast.SetPosition(new Point(pos_x, pos_y));
            toast.SetIntervalInMs(this.intervalInMs);
            toast.SetBackground((Color)ColorConverter.ConvertFromString(this.color));
            toast.Show();
        }
    }
}
