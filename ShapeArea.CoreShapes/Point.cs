using Tech.ShapeArea.Core;

namespace Tech.ShapeArea.CoreShapes
{
    /// <summary>
    /// Геометрическая фигура - Точка
    /// </summary>
    internal sealed class Point : IShape
    {
        /// <inheritdoc />
        public double CalculateArea() 
            => 0.0;
    }

    /// <summary>
    /// Фабрика по производству точек.
    /// </summary>
    public class PointFactory : IShapeFactory
    {
        /// <inheritdoc />
        public IShape CreateShape(params object[] parameters) 
            => new Point();
    }
}
