using Arkanoid_HungryMouse.Enums;
using Arkanoid_HungryMouse.GameEntities.AbstractClasses;

namespace Arkanoid_HungryMouse.GameEntities.Models
{
    /// <summary>
    /// <see cref="GameObject"/> Коробка, которую разрушает <see cref="Mouse"/>
    /// </summary>
    public class Box : GameObject
    {
        /// <summary>
        /// Тип коробки (какой она будет рисоваться)
        /// </summary>
        public BoxTypes BoxType { get; set; }
    }
}
