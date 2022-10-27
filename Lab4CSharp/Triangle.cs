namespace Lab4CSharp;

public class Triangle
{
    private int _sideA;
    private int _sideB;
    private int _sideC;

    public int SideA
    {
        get => _sideA;
        set => _sideA = value;
    }
    public int SideB
    {
        get => _sideB;
        set => _sideB = value;
    }
    public int SideC
    {
        get => _sideC;
        set => _sideC = value;
    }
    public int Color { get; }

    public int this[int i]
    {
        get
        {
            if (i < 0 || i > 3) 
                throw new Exception("Invalid index");

            var value = 0;
            
            if (i == 0)
                value =  _sideA;

            if (i == 1)
                value = _sideB;

            if (i == 2)
                value = _sideC;

            if (i == 3)
                value = Color;

            return value;
        }
    }

    public static Triangle operator ++(Triangle t)
    {
        var temp = new Triangle(++t._sideA, ++t._sideB, ++t._sideC, t.Color);
        return temp;
    }

    public static bool operator true(Triangle t)
    {
        var ab = t._sideA + t._sideB;
        var ac = t._sideA + t._sideC;
        var bc = t._sideB + t._sideC;

        if (ab < t._sideC && ac < t._sideB && bc < t._sideA)
            return false;
        
        return true;
    }

    public static bool operator false(Triangle t)
    {
        var ab = t._sideA + t._sideB;
        var ac = t._sideA + t._sideC;
        var bc = t._sideB + t._sideC;
        
        if (ab > t._sideC && ac > t._sideB && bc > t._sideA)
            return true;

        return false;
    }

    public static Triangle operator *(Triangle t, int a)
    {
        var temp = new Triangle(t._sideA * a, t._sideB * a, t._sideC * a, t.Color);
        return temp;
    }

    public Triangle(int a, int b, int c) => (_sideA, _sideB, _sideC) = (a, b, c);
    public Triangle(int a, int b, int c, int color) => (_sideA, _sideB, _sideC, Color) = (a, b, c, color);

    public int CalculatePerimeter()
    {
        return SideA + SideB + SideC;
    }

    public double CalculateSquare()
    {
        var p = CalculatePerimeter() / 2;
        var square = Math.Sqrt(p * (p - SideA) * (p - SideB) * (p - SideC));
        return square;
    }

    public override string ToString()
    {
        return $"Side A: {SideA};\n Side B: {SideB};\n Side C {SideC};\n Color: {Color}\n";
    }
}