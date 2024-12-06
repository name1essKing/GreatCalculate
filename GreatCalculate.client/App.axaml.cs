using Autofac;

using Avalonia;
using Avalonia.Controls.ApplicationLifetimes;
using Avalonia.Markup.Xaml;
using GreatCalculate.Client.Views;
using GreatCalculate.Services;

namespace GreatCalculate.Client
{
    public partial class App : Application
    {
        private IContainer? _container;

        public override void Initialize()
        {
            AvaloniaXamlLoader.Load(this);
        }

        public override void OnFrameworkInitializationCompleted()
        {
            _container = RegistrationService.CreateContainer();

            var mainWindow = GetMainWindow(_container);
            if (ApplicationLifetime is IClassicDesktopStyleApplicationLifetime desktop)
            {
                desktop.MainWindow = mainWindow;
            } 

            mainWindow.Closed += OnMainWindowClosed;
            mainWindow.Show();
            mainWindow.Activate();

            base.OnFrameworkInitializationCompleted();
        }

        /// <summary>
        /// Get main window view.
        /// </summary> 
        private MainWindowView GetMainWindow(IContainer container)
        {
            var mainWindow = container.Resolve<MainWindowView>();
            mainWindow.DataContext = container.Resolve<MainWindowViewModel>();

            return mainWindow;
        }

        /// <summary>
        /// Ons the main window closed.
        /// </summary> 
        private async void OnMainWindowClosed(object? sender, System.EventArgs e)
        {
            if (ApplicationLifetime is IClassicDesktopStyleApplicationLifetime desktop)
            { 
                desktop.Shutdown(0);
            }
        }
    }
}
