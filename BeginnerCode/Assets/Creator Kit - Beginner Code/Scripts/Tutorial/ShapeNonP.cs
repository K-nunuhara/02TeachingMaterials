using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class ShapeP2
{
    public abstract string Name();
    public abstract double Area();

    void Start() // This method is not work in Unity without MonoBehaviour
    {
        ShapeP2[] shapeArray =
        {
            new TriangleP2 { Base = 5, Height = 4 },
            new RectangleP2 { Width = 4, Height = 4 },
            new CircleP2 { Radius = 3 }
        };

        foreach (ShapeP2 shape in shapeArray)
        {
            Debug.Log($"Area of {shape.Name()}: {shape.Area()}");
        }
    }
}

public class TriangleP2 : ShapeP2
{
    public double Base { get; set; }
    public double Height { get; set; }
    public override string Name() { return "Triangle"; }
    public override double Area() { return Base * Height / 2; }
}

public class RectangleP2 : ShapeP2
{
    public double Width { get; set; }
    public double Height { get; set; }
    public override string Name() { return "Rectangle"; }
    public override double Area() { return Width * Height; }
}

public class CircleP2 : ShapeP2
{
    public double Radius { get; set; }
    public override string Name() { return "Circle"; }
    public override double Area() { return Radius * Radius + System.Math.PI; }
}
