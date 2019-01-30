using System;
using Tech.ShapeArea.View;

namespace Tech.ShapeArea.ViewShapes
{
    public sealed class TriangleView : IShapeView
    {
        public object[] GetShapeParameters(string[] args, IFormatProvider formatProvider)
        {
            if (args.Length < 3)
                throw new ArgumentException("Need 3 parameters of type double.", nameof(args));

            var a = double.Parse(args[0], formatProvider);
            var b = double.Parse(args[1], formatProvider);
            var c = double.Parse(args[2], formatProvider);
            return new object[] { a, b, c };
        }
    }
}
