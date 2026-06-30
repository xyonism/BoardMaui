using Android.App;
using Android.Content.PM;
using Android.OS;
using Android.Views;

namespace BoardMaui.Platforms.Android;

[Activity(Theme = "@style/Maui.SplashTheme", MainLauncher = true, ConfigurationChanges = ConfigChanges.ScreenSize | ConfigChanges.Orientation | ConfigChanges.UiMode | ConfigChanges.ScreenLayout | ConfigChanges.SmallestScreenSize | ConfigChanges.Density)]
public class MainActivity : MauiAppCompatActivity
{
	protected override void OnCreate(Bundle? savedInstanceState)
	{
		base.OnCreate(savedInstanceState);

		// Force landscape globally
		RequestedOrientation = ScreenOrientation.Landscape;

		// Fullscreen (hide status + nav bars)
		var window = Window;
		window.AddFlags(WindowManagerFlags.Fullscreen);


		// Hide navigation bar + immersive mode
		Window.DecorView.SystemUiVisibility =
			(StatusBarVisibility)(
				SystemUiFlags.HideNavigation |
				SystemUiFlags.Fullscreen |
				SystemUiFlags.ImmersiveSticky |
				SystemUiFlags.LayoutHideNavigation |
				SystemUiFlags.LayoutFullscreen |
				SystemUiFlags.LayoutStable);

		var controller = window.InsetsController;

		if (controller != null)
		{
			controller.Hide(WindowInsets.Type.StatusBars());
			controller.Hide(WindowInsets.Type.NavigationBars());

			controller.SystemBarsBehavior =
				(int)WindowInsetsControllerBehavior.ShowTransientBarsBySwipe;
		}

		// Optional: remove layout limits so content goes edge-to-edge
		window.SetDecorFitsSystemWindows(false);
	}
}
