using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Globalization;
using System.Linq;
using System.Threading;
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

        private void Application_Startup(object sender, StartupEventArgs e)
        {
            // Changing the application Culture ==> With that in mind, you now have to decide whether to change the CurrentCulture and / or the CurrentUICulture. It can be done pretty much whenever you want, but it makes the most sense to do it when starting your application -otherwise, some output might already be generated with the default culture, before the switch.Here's an example where we change the Culture, as well as the UICulture, in the Application_Startup() event which can be used in the App.xaml.cs file of your WPF application:
            /* CurrentCulture & CurrentUICulture ==> Applying another culture to your WPF application is quite easy. You will, potentially, be dealing with two attributes, found on the CurrentThread property of the Thread class: CurrentCulture and CurrentUICulture. But what's the difference?
               ==> The CurrentCulture property is the one that controls how numbers and dates etc. are formatted. The default value comes from the operating system of the computer executing the application and can be changed independently of the language used by their operating system. It is, for instance, very common for a person living in Germany to install Windows with English as their interface language, while still preferring German-notation for numbers and dates. For a situation like this, the CurrentCulture property would default to German.
               ==> The CurrentUICulture property specifies the language that the interface should use. This is only relevant if your application supports multiple languages, e.g. through the use of language-resource files. Once again, this allows you to use one culture for the language (e.g. English), while using another (e.g. German) when dealing with input/output of numbers, dates etc.
           */
            Thread.CurrentThread.CurrentCulture = new CultureInfo("de-DE");
            Thread.CurrentThread.CurrentUICulture = new CultureInfo("en-US");
            // If your application uses more than one thread, you should consider using the DefaultThreadCurrentCulture property. It can be found on the CultureInfo class (introduced in .NET framework version 4.5) and will ensure that not only the current thread, but also future threads will use the same culture. You can use it like this, e.g. in the Application_Startup event:
            CultureInfo.DefaultThreadCurrentCulture = new CultureInfo("de-DE");
        }
    }
}
