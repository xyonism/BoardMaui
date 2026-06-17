using Google.Cloud.Firestore;

namespace BoardMaui.Models;

[FirestoreData]
public record Synagogue
{
	[FirestoreProperty]
	public required string Guid { get; set; }
	[FirestoreProperty]
	public List<Person>? RIPs { get; set; }
	[FirestoreProperty]
	public List<Donation>? Donations { get; set; }
	[FirestoreProperty]
	public List<Event>? Events { get; set; }
	[FirestoreProperty]
	public List<Message>? Messages { get; set; }
	[FirestoreProperty]
	public List<Pray>? HolidayPrays { get; set; }
	[FirestoreProperty]
	public List<Pray>? ShaharitPrays { get; set; }
	[FirestoreProperty]
	public List<Pray>? MinhaPrays { get; set; }
	[FirestoreProperty]
	public List<Pray>? ArvitPrays { get; set; }
	[FirestoreProperty]
	public Settings Settings { get; set; } = new();
}