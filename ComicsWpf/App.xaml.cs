using System.Configuration;
using System.Data;
using System.Windows;
using LoginComicsWpf.View;

namespace ComicsWpf
{
    /// <summary>
    /// Interaction logic for App.xaml
    /// </summary>
    public partial class App : Application
    {
        protected void ApplicationsStart(object sender, StartupEventArgs e)
        {
            var loginView = new Login();
            loginView.Show();
            loginView.IsVisibleChanged += (s, ev) =>
            {
                if (loginView.IsVisible == false && loginView.IsLoaded)
                {


                }
            };
        }
    }

}
