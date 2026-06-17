using Google.Cloud.Firestore;

namespace BoardMaui.Models;

[FirestoreData]
public record Person
{
	[FirestoreProperty]
	public string? Name
	{
		get; set;
	}
	[FirestoreProperty]
	public string? Date
	{
		get; set;
	}
}
