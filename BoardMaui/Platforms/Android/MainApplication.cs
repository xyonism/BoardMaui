using Android.App;
using Android.Runtime;

namespace BoardMaui.Platforms.Android;

[Application]
public class MainApplication : MauiApplication
{
    public MainApplication(nint handle, JniHandleOwnership ownership)
        : base(handle, ownership)
    {
    }

    [Obsolete]
    protected override MauiApp CreateMauiApp() => MauiProgram.CreateMauiApp().Build();
}
