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
using System.Windows.Threading;

namespace ThreadAffinityWPF;

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
        ShowMessage("First Message", 3000);
    }

    private void Button2_OnClick(object sender, RoutedEventArgs e)
    {
        Thread thread = new Thread(() => ShowMessage("Second Message", 5000));
        thread.Start();
    }

    private void ShowMessage(string message, int delay)
    {
        Thread.Sleep(delay);
        // This line throws this error:
        // Unhandled exception. System.InvalidOperationException: The calling thread
        // cannot access this object because a different thread owns it.
        // this is because this was originally in the tutorial a WinForm app not a WPF one. 
        //LblMessage.Content = message;

        // I need to use it like this to make it works.
        //LblMessage.Dispatcher.Invoke(() => LblMessage.Content = message);

        // But it's better use it like this
        // if (LblMessage.Dispatcher.CheckAccess())
        // {
        //     LblMessage.Content = message;
        // }
        // else
        // {
        //     LblMessage.Dispatcher.Invoke(() => LblMessage.Content = message);
        // }
        //     
        LblMessage.Content = message;
    }
}