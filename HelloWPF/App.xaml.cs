using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Linq;
using System.Threading.Tasks;
using System.Windows;

namespace HelloWPF
{
    /// <summary>
    /// Interaction logic for App.xaml
    /// </summary>
    public partial class App : Application
    {
        private void Application_DispatcherUnhandledException(object sender, System.Windows.Threading.DispatcherUnhandledExceptionEventArgs e)
        {
            // However, sometimes even the simplest code can throw an exception, and instead of wrapping every single line of code with a try- catch block, WPF lets you handle all unhandled exceptions globally. This is done through the DispatcherUnhandledException event on the Application class. If subscribed to, WPF will call the subscribing method once an exception is thrown which is not handled in your own code. Here's a complete example, based on the stuff we just went through:
            // ==> DispatcherUnhandledException = "Application_DispatcherUnhandledException" on App.xaml
            MessageBox.Show("An unhandled exception just occurred by using App.xaml Magic with DispatcherUnhandledException= Application_DispatcherUnhandledException : " + e.Exception.Message, "App.xaml Exception Sample", MessageBoxButton.OK, MessageBoxImage.Question);
            e.Handled = true;
        }
    }
}
