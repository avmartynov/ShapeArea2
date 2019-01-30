using System;
using Tech.ShapeArea.View;

namespace Tech.ShapeArea.ViewShapes
{
    public sealed class PointView : IShapeView
    {
        public object[] GetShapeParameters(string[] args, IFormatProvider formatProvider)
            => new object[0];
    }
}
