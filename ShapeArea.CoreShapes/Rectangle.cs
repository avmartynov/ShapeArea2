using System;
using Tech.ShapeArea.Core;

namespace Tech.ShapeArea.CoreShapes
{
    /// <summary>
    /// Геометрическая фигура - Прямоугольник
    /// </summary>
    public class Rectangle : IShape
    {
        public Rectangle(double a, double b)
        {
            if (a < 0 || b < 0)
                throw new ArgumentException("Side of rectangle must be nonnegative.");

            _a = a;
            _b = b;
        }

        /// <inheritdoc />
        public double CalculateArea()
        {
            if (_a < double.Epsilon || _b < double.Epsilon)
                return 0.0;

            return _a * _b;
        }

        private readonly double _a, _b;
    }

    /// <summary>
    /// Фабрика по производству треугольников.
    /// </summary>
    public class RectangleFactory : IShapeFactory
    {
        /// <inheritdoc />
        /// <inheritdoc />
        public IShape CreateShape(params object[] parameters)
        {
            if (parameters.Length < 1 || !(parameters[0] is double a)
                                      || !(parameters[1] is double b))
            {
                throw new ArgumentException("Incorrect parameters", nameof(parameters));
            }

            return new Rectangle(a, b);
        }
    }
}
