namespace GeometrischeFormen;

internal abstract class Form
{
    public string Name { get; set; }

    public virtual double BerechneFlaeche()
    {
        return 0;
    }
}