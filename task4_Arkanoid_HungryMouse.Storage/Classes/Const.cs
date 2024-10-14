using Arkanoid_HungryMouse.GameEntities.Models;

namespace task4_Arkanoid_HungryMouse.Storage.Classes
{
    /// <summary>
    /// Константы
    /// </summary>
    public class Const
    {
        /// <summary>
        /// Начальная X координата <see cref="Mouse"/>
        /// </summary>
        public const int MouseStartX = 300;
        /// <summary>
        /// Начальная Y координата <see cref="Mouse"/>
        /// </summary>
        public const int MouseStartY = 300;

        /// <summary>
        /// Начальная X координата <see cref="PlayerTable"/>
        /// </summary>
        public const int TableStartX = 500;
        /// <summary>
        /// Начальная Y координата <see cref="PlayerTable"/>
        /// </summary>
        public const int TableStartY = 700;
        /// <summary>
        /// Шаг сдвига столика
        /// </summary>
        public const int Step = 10;

        /// <summary>
        /// Ввысота <see cref="Field"/>
        /// </summary>
        public const int FieldHeight = 750;
        /// <summary>
        /// Ширина <see cref="Field"/>
        /// </summary>
        public const int FieldWidth = 750;

        /// <summary>
        /// Расстояние между <see cref="Box"/> в списке
        /// </summary>
        public const int BoxesMargin = 10;
        /// <summary>
        /// Количество колонок в списке <see cref="Box"/>
        /// </summary>
        public const int BoxListCols = 5;
        /// <summary>
        /// Количество строк в списке <see cref="Box"/>
        /// </summary>
        public const int BoxListRows = 7;

        /// <summary>
        /// Размер длинного объекта
        /// </summary>
        public const int LongDimen = 128;
        /// <summary>
        /// Размер короткого объекта
        /// </summary>
        public const int ShortDimen = 64;

    }
}
