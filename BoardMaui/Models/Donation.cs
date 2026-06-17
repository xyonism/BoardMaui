using Google.Cloud.Firestore;

namespace BoardMaui.Models;

[FirestoreData]
public record Donation
{
    [FirestoreProperty]
    public string? Name
    {
        get; set;
    }
    [FirestoreProperty]
    public int Dontation { get; set; } = 0;
    [FirestoreProperty]
    public int Paid { get; set; } = 0;
}
