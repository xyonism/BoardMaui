using BoardMaui.Components.Pages;
using Google.Cloud.Firestore;

namespace BoardMaui.Models;

[FirestoreData]
public record Settings
{
	[FirestoreProperty]
	public string? Background
	{
		get; set;
	}
	[FirestoreProperty]
	public string? Dedication
	{
		get; set;
	}
	[FirestoreProperty]
	public double Latitude { get; set; } = 31.771959;
	[FirestoreProperty]
	public double Longitude { get; set; } = 35.217018;
	[FirestoreProperty]
	public string? Title
	{
		get; set;
	}
	[FirestoreProperty]
	public int TransitionTime { get; set; } = 15;

	[FirestoreProperty]
	public bool ShowRIP { get; set; } = true;
	[FirestoreProperty]
	public bool ShowDonations { get; set; } = true;
	[FirestoreProperty]
	public bool ShowEvents { get; set; } = true;
	[FirestoreProperty]
	public bool ShowPraysBoard { get; set; } = true;
	[FirestoreProperty]
	public bool ShowMessages { get; set; } = true;
	[FirestoreProperty]
	public string? CurrentHoliday { get; set; }
	[FirestoreProperty]
	public bool IsHoliday { get; set; } = false;
	[FirestoreProperty]
	public int FontIncrease { get; set; } = 0;

	[FirestoreProperty]
	public Dictionary<string, int> FontSize { get; set; } = new()
	{
		{ nameof(Home), 0 },
		{ nameof(Donations), 0 },
		{ nameof(Holiday), 0 },
		{ nameof(PraysBoard), 0 },
		{ nameof(Messages), 0 },
		{ nameof(Welcome), 0 },
		{ nameof(RIP), 0 },
		{ nameof(Events), 0 }
	};
}
