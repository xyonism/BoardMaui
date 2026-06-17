namespace BoardMaui.Extensions.TimeZone;

///<summary>
/// TimeZone based on the Gmt offset (this is very limited)
///</summary>
public class OffsetTimeZone : ITimeZone
{
    private readonly TimeSpan offsetFromGmt;

    ///<summary>
    ///</summary>
    ///<param name="hoursOffsetFromGmt">The amount of hours from gmt.</param>
    public OffsetTimeZone(int hoursOffsetFromGmt)
        : this(new TimeSpan(hoursOffsetFromGmt, 0, 0))
    {
    }

    ///<summary>
    ///</summary>
    ///<param name="offsetFromGmt">TimeSpan from Gmt</param>
    public OffsetTimeZone(TimeSpan offsetFromGmt) => this.offsetFromGmt = offsetFromGmt;

    public int UtcOffset(DateTime dateTime) => (int)offsetFromGmt.TotalMilliseconds;

    public bool IsDaylightSavingTime(DateTime dateTime) => false;

    public string GetId() => "Offset";

    public string GetDisplayName() => GetId();

    public int GetOffset(long timeFromEpoch) => UtcOffset(timeFromEpoch.ToDateTime());
}