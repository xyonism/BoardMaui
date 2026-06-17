using Google.Cloud.Firestore;

namespace BoardMaui.Models;

[FirestoreData]
public record Message
{
    [FirestoreProperty]
    public string? Title
    {
        get; set;
    }
    [FirestoreProperty]
    public string? Body
    {
        get; set;
    }
}
