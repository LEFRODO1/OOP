using System;


public class Point
{
    public double X { get; set; }
    public double Y { get; set; }

    public Point(double x, double y)
    {
        X = x;
        Y = y;
    }

    public override string ToString()
    {
        return $"({X}, {Y})";
    }

    public double DistanceTo(Point other)
    {
        return Math.Sqrt((X - other.X) * (X - other.X) + (Y - other.Y) * (Y - other.Y));
    }
}

public class Triangle
{
    public Point A { get; set; }
    public Point B { get; set; }
    public Point C { get; set; }

    public Triangle(Point a, Point b, Point c)
    {
        A = a;
        B = b;
        C = c;
    }

    public double GetPerimeter()
    {
        return A.DistanceTo(B) + B.DistanceTo(C) + C.DistanceTo(A);
    }

    public double GetArea()
    {
        var s = GetPerimeter() / 2;
        return Math.Sqrt(s * (s - A.DistanceTo(B)) * (s - B.DistanceTo(C)) * (s - C.DistanceTo(A)));
    }

    public override string ToString()
    {
        return $"{A} {B} {C}";
    }
}
 
 
public class Cone
{
    public Point A { get; set; }
    public Point B { get; set; }
    public double R { get; set; }

    public Cone(Point a, Point b, double r)
    {
        A = a;
        B = b;
        R = r;
    }

    public double GetHeight()
    {
        return A.DistanceTo(B);
    }

    public double GetVolume()
    {
        return Math.PI * Math.Pow(R, 2) * GetHeight() / 3;
    }

    public override string ToString()
    {
        return $"{A} {B} {R}";
    }
}


namespace ConsoleApplication1
{
    class Program
    {
        static void Main(string[] args)
        {
            // Создаем треугольник
            var triangle = new Triangle(new Point(0, 0), new Point(1, 0), new Point(0.5, Math.Sqrt(3) / 2));

            // Выводим периметр и площадь треугольника
            Console.WriteLine("Периметр треугольника: {0}", triangle.GetPerimeter());
            Console.WriteLine("Площадь треугольника: {0}", triangle.GetArea());

            // Создаем конус
            var cone = new Cone(new Point(0, 0), new Point(1, 0), 1);

            // Выводим высоту и объем конуса
            Console.WriteLine("Высота конуса: {0}", cone.GetHeight());
            Console.WriteLine("Объем конуса: {0}", cone.GetVolume());
        }
    }
}
