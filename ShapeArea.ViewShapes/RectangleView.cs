using System;
using Tech.ShapeArea.View;

namespace Tech.ShapeArea.ViewShapes
{
    public sealed class RectangleView : IShapeView
    {
        public object[] GetShapeParameters(string[] args, IFormatProvider formatProvider)
        {
            if (args.Length < 2)
                throw new ArgumentException("Need 2 parameters of type double.", nameof(args));

            var a = double.Parse(args[0], formatProvider);
            var b = double.Parse(args[1], formatProvider);
            return new object[] { a, b };
        }
    }
}
