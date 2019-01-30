using System;
using Tech.ShapeArea.Core;

namespace Tech.ShapeArea.CoreShapes
{
    /// <summary>
    /// Геометрическая фигура - Треугольник
    /// </summary>
    internal sealed class Triangle : IShape
    {
        public Triangle(double a, double b, double c)
        {
            if (a < 0 || b < 0 || c < 0)
                throw new ArgumentException("Side of triangle must be nonnegative.");

            _a = a;
            _b = b;
            _c = c;
        }

        /// <inheritdoc />
        public double CalculateArea()
        {
            if (_a < double.Epsilon || _b < double.Epsilon || _c < double.Epsilon)
                return 0.0;

            var p = (_a + _b + _c) / 2;
            return Math.Sqrt(p * (p - _a) * (p - _b) * (p - _c));
        }

        /// <summary>
        /// Возвращает признак того, что треугольник прямоугольный.
        /// </summary>
        /// <returns> Признак того, что треугольник прямоугольный</returns>
        public bool IsRightAngled()
        {
            double a2 = _a * _a, b2 = _b * _b, c2 = _c * _c;
            return Math.Abs( a2 + b2 - c2) < double.Epsilon
                || Math.Abs( a2 - b2 + c2) < double.Epsilon
                || Math.Abs(-a2 + b2 + c2) < double.Epsilon;
        }

        private readonly double _a, _b, _c;
    }


    /// <summary>
    /// Фабрика по производству треугольников.
    /// </summary>
    public class TriangleFactory : IShapeFactory
    {
        /// <inheritdoc />
        /// <inheritdoc />
        public IShape CreateShape(params object[] parameters)
        {
            if (parameters.Length < 3 || !(parameters[0] is double a)
                                      || !(parameters[1] is double b)
                                      || !(parameters[2] is double c))
            {
                throw new ArgumentException("Incorrect parameters", nameof(parameters));
            }

            return new Triangle(a, b, c);
        }
    }

    public static class ShapeExtensions
    {
        public static bool IsRightAngledTriangle(this IShape shape)
        {
            if (!(shape is Triangle triangle))
                throw new ArgumentException("Incorrect type of shape", nameof(shape));

            return triangle.IsRightAngled();
        }
    }
}
