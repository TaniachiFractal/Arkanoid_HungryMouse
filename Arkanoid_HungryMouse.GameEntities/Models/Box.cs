using Arkanoid_HungryMouse.GameEntities.Enums;
using Arkanoid_HungryMouse.GameEntities.Interfaces;

namespace Arkanoid_HungryMouse.GameEntities.Models
{
    /// <summary>
    /// <see cref="IGameObject"/> Коробка, которую разрушает <see cref="Mouse"/>
    /// </summary>
    public class Box : IGameObject
    {
        public int X { get; set; }
        public int Y { get; set; }
        public int Width { get; set; }
        public int Height { get; set; }
        public bool Destroyed { get; set; }
        public BoxTypes BoxType { get; set; }
    }
}
