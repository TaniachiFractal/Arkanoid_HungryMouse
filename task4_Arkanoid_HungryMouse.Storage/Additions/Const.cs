namespace Arkanoid_HungryMouse.Storage.Additions
{
    /// <summary>
    /// Константы
    /// </summary>
    public class Const
    {
        /// <summary>
        /// Начальная X координата мыши
        /// </summary>
        public const int MouseStartX = 300;
        /// <summary>
        /// Начальная Y координата мыши
        /// </summary>
        public const int MouseStartY = 300;
        /// <summary>
        /// Базовая скорость мыши
        /// </summary>
        public const int MouseStep = 8;
        /// <summary>
        /// Коэффицент умножения вычисляемой скорости мыши
        /// </summary>
        public const double SpeedMultiplier = 0.2;

        /// <summary>
        /// Начальная X координата столика
        /// </summary>
        public const int TableStartX = 500;
        /// <summary>
        /// Начальная Y координата столика
        /// </summary>
        public const int TableStartY = 700;
        /// <summary>
        /// Скорость столика
        /// </summary>
        public const int TableStep = 15;

        /// <summary>
        /// Высота поля
        /// </summary>
        public const int FieldHeight = 750;
        /// <summary>
        /// Ширина поля
        /// </summary>
        public const int FieldWidth = 750;

        /// <summary>
        /// Расстояние между коробками в списке
        /// </summary>
        public const int BoxesMargin = 10;

        /// <summary>
        /// Размер объекта, самый длинный - 1 часть
        /// </summary>
        public const int FullPartDimen = 128;
        /// <summary>
        /// Размер объекта, более короткий - 1/2 часть
        /// </summary>
        public const int HalfPartDimen = 64;
        /// <summary>
        /// Размер еще более короткого объекта - 1/4 часть
        /// </summary>
        public const int QuarterPartDimen = 32;

        /// <summary>
        /// Начальное количество жизней
        /// </summary>
        public const int StartLifesCount = 3;

    }
}
