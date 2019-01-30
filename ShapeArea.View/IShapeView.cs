using System;

namespace Tech.ShapeArea.View
{
    public interface IShapeView
    {
        object[] GetShapeParameters(string[] args, IFormatProvider formatProvider);
    }
}
