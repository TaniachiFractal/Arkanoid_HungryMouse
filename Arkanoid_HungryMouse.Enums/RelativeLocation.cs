namespace Arkanoid_HungryMouse.Enums
{
    /// <summary>
    /// Варианты расположений объекта относительно другого
    /// </summary>
    public enum RelativeLocation
    {
        /// <summary>
        /// Сверху
        /// </summary>
        AtTheTop = 1,

        /// <summary>
        /// Слева
        /// </summary>
        AtTheLeft = 2,

        /// <summary>
        /// Справа
        /// </summary>
        AtTheRight = 3,

        /// <summary>
        /// Снизу
        /// </summary>
        AtTheBottom = 4,

        /// <summary>
        /// Пересечение
        /// </summary>
        Intersect = 5,

        /// <summary>
        /// Снаружи
        /// </summary>
        Outside = 6,
    }
}
