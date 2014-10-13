using System;
using System.Collections.Generic;
using System.Text;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;
using System.Windows.Threading;

namespace SimpleStyles
{
    /// <summary>
    /// Interaction logic for TouchFriendlyWindow.xaml
    /// </summary>
    public partial class TouchFriendlyWindow : Window
    {
        DispatcherTimer t = new DispatcherTimer(); 

        public TouchFriendlyWindow()
        {
            InitializeComponent();
            t.Interval = TimeSpan.FromMilliseconds(3000);
            t.Tick += (s, e) =>
            {
                MessageBox.Show("Hello world!");
                t.Stop();
            };
        }

                 

        private void PushButton_PressedChanged(object sender, bool IsPressed)
        {
            cbPressedChangedEvent.IsChecked = IsPressed;
            if (IsPressed)
            {
                t.Start();
            }
            else
            {
                t.Stop();
            }
        }

        private void btnPreviewMouseLeftButtonDown(object sender, MouseButtonEventArgs e)
        {
            cbPreviewEvent.IsChecked = true;
            t.Start();
        }

        private void btnPreviewMouseLeftButtonUp(object sender, MouseButtonEventArgs e)
        {
            cbPreviewEvent.IsChecked = false;
            t.Stop();
        }
    }
}
