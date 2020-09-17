using System.Windows;

namespace NoteGraphr
{
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();

            Title = "NoteGraphr - Untitled";
            MaxHeight = SystemParameters.MaximizedPrimaryScreenHeight;
        }
    }
}
