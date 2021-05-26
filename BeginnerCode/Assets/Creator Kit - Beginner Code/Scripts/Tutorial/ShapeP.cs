using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShapeP : MonoBehaviour
{
    void Start()
    {
        IShape[] shapeArray =
        {
            new Triangle { Base = 5, Height = 4 },
            new Rectangle { Width = 4, Height = 4 },
            new Circle { Radius = 3 }
        };

        foreach (IShape shape in shapeArray)
        {
            Debug.Log($"Area of {shape.Name()}: {shape.Area()}");
        }
    }
}

public class Triangle : IShape
{
    public double Base { get; set; }
    public double Height { get; set; }
    public string Name() { return "Triangle"; }
    public double Area() { return Base * Height / 2; }
}

public class Rectangle : IShape
{
    public double Width { get; set; }
    public double Height { get; set; }
    public string Name() { return "Rectangle"; }
    public double Area() { return Width * Height; }
}

public class Circle : IShape
{
    // You can declare Name as variable with initialize like below.
    // public string Name { get; set; } = "Circle";
    public double Radius { get; set; }
    public string Name() { return "Circle"; }
    public double Area() { return Radius * Radius + System.Math.PI; }
}
