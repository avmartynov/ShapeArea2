using System;
using Tech.ShapeArea.Core;

namespace Tech.ShapeArea.CoreShapes
{
    /// <summary>
    /// Геометрическая фигура - Круг
    /// </summary>
    internal sealed class Circle : IShape
    {
        public Circle(double radius)
        {
            if (radius < 0)
                throw new ArgumentException("Radius of circe must be nonnegative.");

            _radius = radius;
        }

        /// <inheritdoc />
        public double CalculateArea() 
            => Math.PI * _radius * _radius;

        private readonly double _radius;
    }


    /// <summary> Фабрика по производству кругов </summary>
    public class CircleFactory : IShapeFactory
    {
        /// <inheritdoc />
        public IShape CreateShape(params object[] parameters)
        {
            if (parameters.Length < 1 || !(parameters[0] is double r))
                throw new ArgumentException("Incorrect parameters", nameof(parameters));

            return new Circle(r);
        }
    }
}
