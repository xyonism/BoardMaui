using Google.Cloud.Firestore;

namespace BoardMaui.Models;

[FirestoreData]
public record Event
{
    [FirestoreProperty]
    public string? Day
    {
        get; set;
    }
    [FirestoreProperty]
    public TimeOnly? Time
    {
        get; set;
    }
    [FirestoreProperty]
    public string? Title { get; set; } = "אירוע";
    [FirestoreProperty]
    public DateOnly? ExpirationDate
    {
        get; set;
    }
}
