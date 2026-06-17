using Google.Cloud.Firestore;

namespace BoardMaui.Models;

[FirestoreData]
public record Pray
{
    [FirestoreProperty]
    public string? Title
    {
        get; set;
    }
    [FirestoreProperty]
    public TimeOnly? Time
    {
        get; set;
    }
    [FirestoreProperty]
    public bool Dynamic
    {
        get; set;
    }
    [FirestoreProperty]
    public bool Shabbat
    {
        get; set;
    }
    [FirestoreProperty]
    public string? DayOfWeek
    {
        get; set;
    }
}
