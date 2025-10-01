public class Fraction
{
    private int _top;
    private int _bottom;


    // Default constructor (1/1)
    public Fraction()
    {
        _top = 1;
        _bottom = 1;
    }

    // Constructor with whole number (e.g., 5 becomes 5/1)
    public Fraction(int wholenumber)
    {
        _top = wholenumber;
        _bottom = 1;
    }

    // Constructor with numerator and denominator
    public Fraction(int top, int bottom)
    {
        _top = top;
        _bottom = bottom;
    }

    // Getter for top
    public int GetTop()
    {
        return _top;
    }

    // Setter for top (numerator)
    public void SetTop(int top)
    {
        _top = top;
    }

    // Getter for bottom (denominator)
    public int GetBottom()
    {
        return _bottom;
    }

    // Setter for bottom (denominator)
    public void SetBottom(int bottom)
    {
        _bottom = bottom;
    }

     // Returns the fraction as a string
    public string GetFractionString()
    {
        return $"{_top}/{_bottom}";
    }

    // Returns the decimal value of the fraction
    public double GetDecimalValue()
    {
        return (double)_top / (double)_bottom;
    }
}