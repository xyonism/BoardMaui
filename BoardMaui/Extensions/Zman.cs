namespace BoardMaui.Extensions;

/// <summary>
/// Wrapper class for an astronomical time, mostly used to sort collections of
/// astronomical times.
/// </summary>
/// <author>Eliyahu Hershfeld</author>
public class Zman
{
    /// <summary>
    /// Initializes a new instance of the <see cref="Zman"/> class.
    /// </summary>
    /// <param name="date">The date.</param>
    /// <param name="label">The label.</param>
    public Zman(DateTime date, string label)
    {
        ZmanLabel = label;
        ZmanTime = date;
    }

    /// <summary>
    /// Initializes a new instance of the <see cref="Zman"/> class.
    /// </summary>
    /// <param name="duration">The duration.</param>
    /// <param name="label">The label.</param>
    public Zman(long duration, string label)
    {
        ZmanLabel = label;
        Duration = duration;
    }

    /// <summary>
    /// Gets the duration.
    /// </summary>
    /// <value></value>
    public virtual long Duration
    {
        get; set;
    }

    /// <summary>
    /// Gets the zman.
    /// </summary>
    /// <value></value>
    public virtual DateTime ZmanTime
    {
        get; set;
    }

    /// <summary>
    /// Gets the zman label.
    /// </summary>
    /// <value></value>
    public virtual string ZmanLabel
    {
        get; set;
    }
}