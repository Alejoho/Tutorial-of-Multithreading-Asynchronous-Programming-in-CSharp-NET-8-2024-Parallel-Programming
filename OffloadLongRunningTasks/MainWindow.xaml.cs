using System.Text;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace OffloadLongRunningTasks;

/// <summary>
/// Interaction logic for MainWindow.xaml
/// </summary>
public partial class MainWindow : Window
{
    public MainWindow()
    {
        InitializeComponent();
    }

    private void Button1_OnClick(object sender, RoutedEventArgs e)
    {
        Thread.Sleep(2000);
        LblMessage.Content = "First Message";
    }

    private void Button2_OnClick(object sender, RoutedEventArgs e)
    {
        Thread.Sleep(3000);
        LblMessage.Content = "Second Message";
    }
}