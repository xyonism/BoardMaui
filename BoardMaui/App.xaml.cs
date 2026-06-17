namespace BoardMaui;

public partial class App : Application
{
	public App() => InitializeComponent();

	protected override Window CreateWindow(IActivationState? activationState)
	{
		return new(new MainPage())
		{
			Title = "SynagogaBoard"
		};
	}


	protected override async void OnStart()
	{
		base.OnStart();
		// Fire and forget or handle properly without blocking the UI thread
		await MauiProgram.LoadSynagogueDataAsync();
	}
}
