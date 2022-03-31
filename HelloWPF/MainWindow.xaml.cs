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
using System.Threading;
using System.Globalization;

namespace HelloWPF
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
            pnlMainGrid.MouseUp += new MouseButtonEventHandler(pnlMainGrid_MouseUp);
            txtHelloWPF.MouseDown += new MouseButtonEventHandler(helloWPF_MouseDown);

            // Formatting text from C#/Code-Behind ==> As you can see, formatting text through XAML is very easy, but in some cases, you might prefer or even need to do it from your C#/Code-Behind file. This is a bit more cumbersome, but here's an example on how you may do it:
            /* TextBlock tb = new TextBlock();
            tb.TextWrapping = TextWrapping.Wrap;
            tb.Margin = new Thickness(10);
            tb.Inlines.Add("An example on ");
            tb.Inlines.Add(new Run("the TextBlock control ") { FontWeight = FontWeights.Bold });
            tb.Inlines.Add("using ");
            tb.Inlines.Add(new Run("inline ") { FontStyle = FontStyles.Italic });
            tb.Inlines.Add(new Run("text formatting ") { Foreground = Brushes.Blue });
            tb.Inlines.Add("from ");
            tb.Inlines.Add(new Run("Code-Behind") { TextDecorations = TextDecorations.Underline });
            tb.Inlines.Add(".");
            this.Content = tb;
           */
        }

        private void pnlMainGrid_MouseUp(object sender, MouseButtonEventArgs e)
        {
            MessageBox.Show("You clicked me at " + e.GetPosition(this).ToString());
        }

        private void helloWPF_MouseDown(object sender, MouseButtonEventArgs e)
        {
            MessageBox.Show("You clicked me at Hello WPF !");
        }

        private void btnClickMe_Click(object sender, RoutedEventArgs e)
        {
            lbResult.Items.Add("\n");
            lbResult.Items.Add(pnlMain.FindResource("strPanel").ToString());
            lbResult.Items.Add(this.FindResource("strWindow").ToString());
            lbResult.Items.Add(Application.Current.FindResource("strApp").ToString());

            // Ad-hoc formatting ==> If you only need to apply formatting for a specific piece of information, e.g. the contents of a single Label control, you can easily do this, on-the-fly, using a combination of the ToString() method and the CultureInfo class. For instance, in the example above, I applied different, culture-based formatting like this:
            double largeNumber = 123456789.42;
            CultureInfo usCulture = new CultureInfo("en-US");
            CultureInfo deCulture = new CultureInfo("de-DE");
            CultureInfo seCulture = new CultureInfo("sv-SE");
            lbResult.Items.Add("\n");
            lbResult.Items.Add("Large Number With Culture / UICulture :" + largeNumber);
            lbResult.Items.Add("English(US) : " + largeNumber.ToString("N2", usCulture));
            lbResult.Items.Add("German(DE) : " + largeNumber.ToString("N2", deCulture));
            lbResult.Items.Add("Swedish(SE) : " + largeNumber.ToString("N2", seCulture));

            // Handling exceptions in WPF ==> In this case, the user would be forced to close your application, due to such a simple and easily avoided error. So, if you know that things might go wrong, then you should use a try-catch block, like this:
            string s = null;
            try
            {
                s.Trim();
            }
            catch (Exception ex)
            {
                MessageBox.Show("A handled exception just occurred: " + ex.Message, "Exception Sample", MessageBoxButton.OK, MessageBoxImage.Error);
            }
        }

        private void HandelingExceptionButton_Click(object sender, RoutedEventArgs e)
        {
            string s = null;
            try
            {
                s.Trim();
            }
            catch (Exception ex)
            {
                MessageBox.Show("A handled exception just occurred from using try and catch exception : " + ex.Message, "Try Catch Exception Sample", MessageBoxButton.OK, MessageBoxImage.Warning);
            }
            // Notice that I call the Trim() method an extra time, outside of the try-catch block, so that the first call is handled, while the second is not. For the second one, we need the App.xaml magic ==> DispatcherUnhandledException="Application_DispatcherUnhandledException" :
            s.Trim();
        }

        private void CultureInfoSwitchButton_Click(object sender, RoutedEventArgs e)
        {
            // Dealing with the culture of your WPF application is very important, but fortunately for you, WPF will do a lot of it for you completely out-of-the-box. If you need to change the default behavior, it's quite easy as well, using the CurrentCulture and CurrentUICulture properties, as illustrated in the numerous examples of this article. The interesting part is found in the CultureInfoSwitchButton_Click event, where we set CurrentCulture based on which of the buttons were clicked, and then update the two labels containing a number and a date:
            Thread.CurrentThread.CurrentCulture = new CultureInfo((sender as Button).Tag.ToString());
            lblNumber.Content = (123456789.42d).ToString("N2");
            lblDate.Content = DateTime.Now.ToString();
        }

        private void Hyperlink_RequestNavigate(object sender, RequestNavigateEventArgs e)
        {
            // The Hyperlink is also used inside of WPF Page's, where it can be used to navigate between pages. In that case, you won't have to specifically handle the RequestNavigate event, like we do in the example, but for launching external URL's from a regular WPF application, we need a bit of help from this event and the Process class. We subscribe to the RequestNavigate event, which allows us to launch the linked URL in the users default browser with a simple event handler like this one in the code behind file:
            System.Diagnostics.Process.Start(e.Uri.AbsoluteUri);
        }

        private void TextBox_SelectionChanged(object sender, RoutedEventArgs e)
        {
            // The example consists of two TextBox controls: One for editing and one for outputting the current selection status to. For this, we set the IsReadOnly property to true, to prevent editing of the status TextBox. We subscribe the SelectionChanged event on the first TextBox, which we handle in the Code-behind:
            TextBox textBox = sender as TextBox;
            txtStatus.Text = "Selection starts at character #" + textBox.SelectionStart + Environment.NewLine;
            txtStatus.Text += "Selection is " + textBox.SelectionLength + " character(s) long" + Environment.NewLine;
            txtStatus.Text += "Selected text: '" + textBox.SelectedText + "'";
        }

        private void HelloButton_Click(object sender, RoutedEventArgs e)
        {
            MessageBox.Show("Hello, Button just clicked !");
        }

        private void FormattedButton_Click(object sender, RoutedEventArgs e)
        {
            MessageBox.Show("Formatted Button Just Clicked !");
        }

        private void VariousFormattedButton_Click(object sender, RoutedEventArgs e)
        {
            MessageBox.Show("Various Formatted Button Just Clicked !");
        }

        private void ImageButton_Click(object sender, RoutedEventArgs e)
        {
          //  MessageBox.Show("Image Button Just Clicked !");
        //  this.NavigationService
        }
    }
}

/* Important Window properties
The WPF Window class has a bunch of interesting attributes that you may set to control the look and behavior of your application window. Here's a short list of the most interesting ones:

Icon - Allows you to define the icon of the window, which is usually shown in the upper left corner, to the left of the window title.

ResizeMode - This controls whether and how the end-user can resize your window. The default is CanResize, which allows the user to resize the window like any other window, either by using the maximize/minimize buttons or by dragging one of the edges. CanMinimize will allow the user to minimize the window, but not to maximize it or drag it bigger or smaller. NoResize is the strictest one, where the maximize and minimize buttons are removed and the window can't be dragged bigger or smaller.

ShowInTaskbar - The default is true, but if you set it to false, your window won't be represented in the Windows taskbar. Useful for non-primary windows or for applications that should minimize to the tray.

SizeToContent - Decide if the Window should resize itself to automatically fit its content. The default is Manual, which means that the window doesn't automatically resize. Other options are Width, Height and WidthAndHeight, and each of them will automatically adjust the window size horizontally, vertically or both.

Topmost - The default is false, but if set to true, your Window will stay on top of other windows unless minimized. Only useful for special situations.

WindowStartupLocation - Controls the initial position of your window. The default is Manual, which means that the window will be initially positioned according to the Top and Left properties of your window. Other options are CenterOwner, which will position the window in the center of it's owner window, and CenterScreen, which will position the window in the center of the screen.

WindowState - Controls the initial window state. It can be either Normal, Maximized or Minimized. The default is Normal, which is what you should use unless you want your window to start either maximized or minimized.
 */