using BoardMaui.Models;
using Google.Cloud.Firestore;
using System.Text.Json;

namespace BoardMaui.Extensions;

public class DatabaseUtility()
{

	public async Task RemoveFromList<T>(List<T>? list, T item)
	{
		if (list == null)
			return;

		int i = list.IndexOf(item);
		if (i >= 0 && i < list.Count)
		{
			list.RemoveAt(i);
			await SaveAll().ConfigureAwait(false);
		}
	}

	public async Task SaveAll()
	{
		// Ensure Synagogue has a GUID
		if (string.IsNullOrWhiteSpace(MauiProgram.Synagogue.Guid))
		{
			MauiProgram.Synagogue.Guid = Guid.NewGuid().ToString();
		}

		try
		{
			FirestoreDb FirestoreDb = new FirestoreDbBuilder
			{
				Credential = Variables.GoogleCredential,
				ProjectId = Variables.JsonCredentialParameters.ProjectId
			}.Build();

			Query query = FirestoreDb
				.Collection("Synagogues")
				.WhereEqualTo("Guid", MauiProgram.Synagogue.Guid)
				.Limit(1);

			QuerySnapshot snapshot = await query.GetSnapshotAsync().ConfigureAwait(false);
			if (snapshot.Documents.Count == 0)
			{
				_ = await FirestoreDb.Collection("Synagogues").AddAsync(MauiProgram.Synagogue).ConfigureAwait(false);
				return;
			}

			DocumentSnapshot? firstDocument = snapshot.Documents[0];

			Dictionary<string, object?> updateDict = typeof(Synagogue)
					.GetProperties()
					.ToDictionary(p => p.Name, p => p.GetValue(MauiProgram.Synagogue));

			_ = await firstDocument.Reference.UpdateAsync(updateDict).ConfigureAwait(false);
		}
		catch (Exception ex)
		{
			// Minimal diagnostics; in production consider more robust logging
			Console.WriteLine(ex.ToString());
		}

		// Persist local config file
		try
		{
			await File.WriteAllTextAsync(MauiProgram.ConfigPath, JsonSerializer.Serialize(MauiProgram.Synagogue)).ConfigureAwait(false);
		}
		catch
		{
		}
	}
}
