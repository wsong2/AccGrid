using System.Diagnostics;
using System.Reflection;
using System.Windows;

namespace GridForm
{
    /// <summary>
    /// Interaction logic for App.xaml
    /// </summary>
    public partial class App : Application
    {
        private static readonly string location = Assembly.GetExecutingAssembly().Location;
        internal static readonly string Version = FileVersionInfo.GetVersionInfo(location).ProductVersion;
    }
}
