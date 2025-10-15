class Program
{
    static void Main(string[] args)
    {
      
        Console.WriteLine("Testing individual shapes:");
        Console.WriteLine();


        Square square = new Square("Red", 5);
        Console.WriteLine($"Square - Color: {square.GetColor()}, Area: {square.GetArea()}");


        Rectangle rectangle = new Rectangle("Blue", 4, 6);
        Console.WriteLine($"Rectangle - Color: {rectangle.GetColor()}, Area: {rectangle.GetArea()}");


        Circle circle = new Circle("Green", 3);
        Console.WriteLine($"Circle - Color: {circle.GetColor()}, Area: {circle.GetArea()}");


        Console.WriteLine();
        Console.WriteLine("--------------------");
        Console.WriteLine();

        List<Shape> shapes = new List<Shape>();



        shapes.Add(new Square("Yellow", 4));
        shapes.Add(new Rectangle("Purple", 5, 3));
        shapes.Add(new Circle("Orange", 2.5));
        shapes.Add(new Square("Pink", 7));
        shapes.Add(new Circle("Cyan", 4));
        

        Console.WriteLine("Iterating through list of shapes:");
        Console.WriteLine();

        foreach (Shape shape in shapes)
        {
            string color = shape.GetColor();
            double area = shape.GetArea();
            Console.WriteLine($"The {color} shape has an area of {area}");
        }
    }
}