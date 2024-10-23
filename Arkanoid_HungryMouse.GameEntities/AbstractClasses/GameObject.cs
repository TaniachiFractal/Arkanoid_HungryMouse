using System;
using Arkanoid_HungryMouse.Enums;
using Arkanoid_HungryMouse.GameEntities.Models;

namespace Arkanoid_HungryMouse.GameEntities.AbstractClasses
{
    /// <summary>
    /// Игровой объект
    /// </summary>
    public abstract class GameObject
    {

        /// <summary>
        /// Координата по ширине
        /// </summary>
        public int X { get; set; }

        /// <summary>
        /// Координата по высоте
        /// </summary>
        public int Y { get; set; }

        /// <summary>
        /// Ширина объекта
        /// </summary>
        public int Width { get; set; }

        /// <summary>
        /// Высота объекта
        /// </summary>
        public int Height { get; set; }

        /// <summary>
        /// Базовая скорость 
        /// </summary>
        public int Step { get; set; }

    }
}
