using System;

namespace Intervall;

internal class Intervall
{
    private int max;
    private int min;

    public Intervall(int maximum, int minimum)
    {
        max = maximum;
        min = minimum;
    }

    public float Avg()
    {
        // Cast um Kommazahl zu erhalten.
        return (float)(max - min) / 2;
    }

    public void Move(int offset)
    {
        max += offset;
        min = min + offset;
    }

    public void Output(string value)
    {
        Console.WriteLine(value);
        Console.WriteLine($"Max = {max}");
        Console.WriteLine($"Min = {min}\n");
    }

    public void Scale(int offset)
    {
        max *= offset;
        min = min * offset;
    }

    public int Size()
    {
        return max - min;
    }
}