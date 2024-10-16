using Arkanoid_HungryMouse.Enums;
using Arkanoid_HungryMouse.GameEntities.AbstractClasses;

namespace Arkanoid_HungryMouse.GameEntities.Models
{
    /// <summary>
    /// <see cref="GameObject"/> мыши, который прыгает по экрану 
    /// </summary>
    public class Mouse : GameObject
    {
        /// <summary>
        /// Скорость мыши по горизонтали
        /// </summary>
        public int SpeedX { get; set; }

        /// <summary>
        /// Направление мыши по вертикали
        /// </summary>
        public Direction VerticalDirection { get; set; }
    }
}
