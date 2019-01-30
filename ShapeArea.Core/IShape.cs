namespace Tech.ShapeArea.Core
{
    /// <summary>
    /// Интерфейс произвольной геометрической фигуры
    /// </summary>
    public interface IShape
    {
        /// <summary>
        /// Вычисляет площадь фигуры
        /// </summary>
        double CalculateArea();
    }
}
