namespace Sekundenspeicher;

internal class Second
{
    public ulong Days
    {
        get { return Seconds / (3600*24); }
    }

    public ulong Hours
    {
        get { return Seconds / 3600; }
    }

    public ulong Minutes
    {
        get { return Seconds / 60; }
    }

    public ulong Seconds { get; set; }

    public string StringWithRest()
    {
        // Variable welche den Rest speichert
        var rest = Seconds % 86400;
        var days = Seconds / 86400;

        var hours = rest / 3600;
        rest = rest % 3600;

        var minutes = rest / 60;
        rest = rest % 60;

        return $"Tage: {days} Stunden: {hours} Minuten: {minutes} Sekunden: {rest}";
    }
}