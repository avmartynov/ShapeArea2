using System;
using Tech.ShapeArea.View;

namespace Tech.ShapeArea.ViewShapes
{
    public sealed class CircleView : IShapeView
    {
        public object[] GetShapeParameters(string[] args, IFormatProvider formatProvider)
        {
            if (args.Length < 1)
                throw new ArgumentException("Need parameter of type double.", nameof(args));

            var radius = double.Parse(args[0], formatProvider);
            return new object [] {radius};
        }
    }
}
