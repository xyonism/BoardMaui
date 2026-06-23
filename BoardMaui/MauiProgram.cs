
using BoardMaui.Extensions;
using BoardMaui.Extensions.Calculator;
using BoardMaui.Models;
using Google.Cloud.Firestore;
using Microsoft.Win32;
using System.Reflection;
using System.Text.Json;

namespace BoardMaui;

public static class MauiProgram
{
	public static string ConfigPath => Path.Combine(FileSystem.Current.AppDataDirectory, "Synagogue.json");
	public static string? CurrentPage
	{
		get; set;
	}
	public static Synagogue Synagogue { get; set; } = new() { Guid = Guid.NewGuid().ToString() };
	public static ComplexZmanimCalendar Calendar
	{
		get; set;
	} = new ComplexZmanimCalendar(DateTime.Today, new GeoLocation("Jerusalem, IL", Synagogue.Settings.Latitude, Synagogue.Settings.Longitude, 0, new OlsonTimeZone("Asia/Jerusalem")))
	{
		AstronomicalCalculator = new SunTimesCalculator()
	};

	public static MauiAppBuilder CreateMauiApp()
	{
		MauiAppBuilder? builder = MauiApp.CreateBuilder();

		

		builder.Services.AddSingleton<DatabaseUtility>();
		builder.Services.AddTransient<AutoNavigation>();

		builder.UseMauiApp<App>()
		.ConfigureFonts(fonts => fonts.AddFont("OpenSans-Regular.ttf", "OpenSansRegular"))
		.ConfigureEssentials(essentials =>
		{
			essentials.UseMapServiceToken("Ah1ArSpFtSpdp10xK5hh~rW_VnksRRXLjE7Ii-2xryg~Av4UKUUU7Pn50A35CUbq7ZdSqOkWtWESwQeG-cPnAob-fH8cjyT9jsUF7HWF8VE1");
			essentials.UseVersionTracking();
		});

		builder.Services.AddMauiBlazorWebView();
		builder.Services.AddBlazorWebViewDeveloperTools();

#if DEBUG
			builder.Services.AddBlazorWebViewDeveloperTools();
#endif
		if (OperatingSystem.IsWindows())
		{
			string exePath = Environment.ProcessPath ?? Assembly.GetExecutingAssembly().Location;
			string appName = Assembly.GetExecutingAssembly().GetName().Name ?? "BoardMaui";
			try
			{
				using RegistryKey? key = Registry.CurrentUser.OpenSubKey(
					@"Software\Microsoft\Windows\CurrentVersion\Run", writable: true);

				key?.SetValue(appName, exePath);
			}
			catch (Exception ex)
			{
				Console.WriteLine($"Failed to add to registry startup: {ex.Message}");
			}

			try
			{
				string normalizedPath = exePath.Replace("\\", "/");
				string content =
					"[InternetShortcut]\n" +
					$"URL=file:///{normalizedPath}\n" +
					$"IconFile={normalizedPath}\n";

				File.WriteAllText(Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.Startup), $"{appName}.url"), content);
			}
			catch (Exception ex)
			{
				Console.WriteLine($"Failed to create startup shortcut: {ex.Message}");
			}
		}

		return builder;
	}
	//public static async Task LoadSynagogueDataAsync()
	//{
	//	try
	//	{
	//		FirestoreDb firestoreDb = new FirestoreDbBuilder
	//		{
	//			Credential = Variables.GoogleCredential,
	//			ProjectId = Variables.JsonCredentialParameters.ProjectId
	//		}.Build();

	//		// 1. Get the GUID from preferences
	//		var synagogueGuid = Preferences.Get("Synagogue.Guid", null);
	//		Synagogue? synagogue = null;

	//		try
	//		{
	//			var cts = new CancellationTokenSource(TimeSpan.FromSeconds(5));

	//			await firestoreDb.ListRootCollectionsAsync().ToListAsync();
	//			// 2. Try to find the existing Synagogue
	//			if (!string.IsNullOrEmpty(synagogueGuid))
	//			{
	//				var snapshot = await firestoreDb.Collection("Synagogues")
	//					.WhereEqualTo("Guid", synagogueGuid)
	//					.GetSnapshotAsync(cts.Token);

	//				if (snapshot.Documents.Count > 0)
	//				{
	//					synagogue = snapshot.Documents[0].ConvertTo<Synagogue>();
	//				}
	//			}

	//			// 3. If not found, create a new one
	//			if (synagogue == null)
	//			{
	//				var newSynagogue = new Synagogue { Guid = Guid.NewGuid().ToString() };
	//				var docRef = await firestoreDb.Collection("Synagogues").AddAsync(newSynagogue).ConfigureAwait(false);

	//				// Fetch the created doc to ensure we have the server-side state
	//				var newSnapshot = await docRef.GetSnapshotAsync(cts.Token);
	//				synagogue = newSnapshot.ConvertTo<Synagogue>();

	//				// 4. Save the new GUID to preferences
	//				Preferences.Set("Synagogue.Guid", synagogue.Guid);
	//			}

	//			Synagogue = synagogue;
	//		}
	//		catch (OperationCanceledException)
	//		{
	//			// Handle timeout
	//			Debug.WriteLine("Firestore call timed out.");
	//		}
	//		catch (Exception ex)
	//		{
	//			// Handle other errors (Network, Permissions, etc.)
	//			Debug.WriteLine($"Error: {ex.Message}");
	//		}
	//	}
	//	catch
	//	{
	//		if (File.Exists(ConfigPath))
	//		{
	//			Synagogue = JsonSerializer.Deserialize<Synagogue>(File.ReadAllText(ConfigPath)) ?? new()
	//			{
	//				Guid = Guid.NewGuid().ToString()
	//			};
	//		}
	//	}
	//	finally
	//	{
	//		File.WriteAllText(ConfigPath, JsonSerializer.Serialize(Synagogue));
	//	}
	//}
	public static async Task LoadSynagogueDataAsync()
	{
		try
		{
			// Use Task.Run to ensure we aren't blocking the main thread during heavy initialization
			await Task.Run(async () => {
				FirestoreDb firestoreDb = new FirestoreDbBuilder
				{
					Credential = Variables.GoogleCredential,
					ProjectId = Variables.JsonCredentialParameters.ProjectId
				}.Build();

				var synagogueGuid = Preferences.Get("Synagogue.Guid", null);

				var cts = new CancellationTokenSource(TimeSpan.FromSeconds(10));

				if (!string.IsNullOrEmpty(synagogueGuid))
				{
					// Try to load existing synagogue
					var query = firestoreDb.Collection("Synagogues")
										   .WhereEqualTo("Guid", synagogueGuid);

					var snapshot = await query.GetSnapshotAsync(cts.Token);
					Synagogue = snapshot.Documents[0].ConvertTo<Synagogue>();

					if (Synagogue == null)
					{
						// Create new synagogue if GUID not found in Firestore
						Synagogue = new Synagogue { Guid = Guid.NewGuid().ToString() };

						var docRef = await firestoreDb.Collection("Synagogues")
													  .AddAsync(Synagogue)
													  .ConfigureAwait(false);

						var newSnapshot = await docRef.GetSnapshotAsync(cts.Token);
						Synagogue = newSnapshot.ConvertTo<Synagogue>();
					}
				}
				else
				{
					// No GUID in preferences → create new synagogue
					Synagogue = new Synagogue { Guid = Guid.NewGuid().ToString() };

					var docRef = await firestoreDb.Collection("Synagogues")
												  .AddAsync(Synagogue)
												  .ConfigureAwait(false);

					var newSnapshot = await docRef.GetSnapshotAsync(cts.Token);
					Synagogue = newSnapshot.ConvertTo<Synagogue>();
				}

				// Always update preferences with the final GUID

			});
		}
		catch
		{
			if (File.Exists(ConfigPath))
			{
				Synagogue = JsonSerializer.Deserialize<Synagogue>(File.ReadAllText(ConfigPath)) ?? new()
				{
					Guid = Guid.NewGuid().ToString()
				};
			}
		}
		finally
		{
			Preferences.Set("Synagogue.Guid", Synagogue.Guid);
			File.WriteAllText(ConfigPath, JsonSerializer.Serialize(Synagogue));
		}
	}
}