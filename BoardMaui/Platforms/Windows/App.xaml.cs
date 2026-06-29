using Microsoft.Maui.LifecycleEvents;
using Microsoft.UI.Windowing;
// To learn more about WinUI, the WinUI project structure,
// and more about our project templates, see: http://aka.ms/winui-project-info.

namespace BoardMaui.WinUI;

/// <summary>
/// Provides application-specific behavior to supplement the default Application class.
/// </summary>
public partial class App : MauiWinUIApplication
{
    /// <summary>
    /// Initializes the singleton application object.  This is the first line of authored code
    /// executed, and as such is the logical equivalent of main() or WinMain().
    /// </summary>
    public App() => InitializeComponent();

    protected override MauiApp CreateMauiApp() => MauiProgram.CreateMauiApp()
            .ConfigureLifecycleEvents(
            events => events.AddWindows(
                w => w.OnWindowCreated
                (
                    window =>
                    {
                        window.ExtendsContentIntoTitleBar = false;
                        AppWindow.GetFromWindowId(Microsoft.UI.Win32Interop.GetWindowIdFromWindow(WinRT.Interop.WindowNative.GetWindowHandle(window))).SetPresenter(AppWindowPresenterKind.FullScreen);
                    })
            )
        )
        .Build();
}
