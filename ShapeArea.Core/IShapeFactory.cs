namespace Tech.ShapeArea.Core
{
    /// <summary>
    /// Интерфейс фабрики, производящей геометрическую фигуру. 
    /// </summary>
    public interface IShapeFactory
    {
        /// <summary>
        /// Создаёт геометрическую фигуру определённого типа и инициализирует её заданными параметрами.
        /// </summary>
        IShape CreateShape(params object[] parameters);
    }
}
