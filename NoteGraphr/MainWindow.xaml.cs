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

namespace NoteGraphr
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();

            Title = "NoteGraphr - Untitled";
            StateChanged += WindowStateChanged;
            WindowStateChanged(this, null);
            MaxHeight = SystemParameters.MaximizedPrimaryScreenHeight;
        }

        private void RefreshMaximizeRestoreButton()
        {
            if (WindowState == WindowState.Maximized)
            {
                maximizeButton.Visibility = Visibility.Collapsed;
                restoreButton.Visibility = Visibility.Visible;
            }
            else
            {
                maximizeButton.Visibility = Visibility.Visible;
                restoreButton.Visibility = Visibility.Collapsed;
            }
        }

        public void OnMinimizeButtonClick(object sender, RoutedEventArgs e) => WindowState = WindowState.Minimized;
        public void OnMaximizeRestoreButtonClick(object sender, RoutedEventArgs e) => WindowState = WindowState == WindowState.Maximized ? WindowState.Normal : WindowState.Maximized;
        public void OnCloseButtonClick(object sender, RoutedEventArgs e) => Close();
        public void WindowStateChanged(object sender, EventArgs e) => RefreshMaximizeRestoreButton();
    }
}
