using Arkanoid_HungryMouse.GameEntities.Interfaces;

namespace Arkanoid_HungryMouse.GameEntities.Models
{
    /// <summary>
    /// <see cref="IGameObject"/> Коробка, которую разрушает <see cref="Mouse"/>
    /// </summary>
    internal class Box : IGameObject
    {
        /// <summary>
        /// <inheritdoc cref="IGameObject.X"/>
        /// </summary>
        public int X { get; set; }

        /// <summary>
        /// <inheritdoc cref="IGameObject.Y"/>
        /// </summary>
        public int Y { get; set; }

        /// <summary>
        /// <inheritdoc cref="IGameObject.Width"/>
        /// </summary>
        public int Width => 64;

        /// <summary>
        /// <inheritdoc cref="IGameObject.Height"/>
        /// </summary>
        public int Height => 64;

        /// <summary>
        /// Разрушена ли коробка
        /// </summary>
        public bool Destroyed { get; set; }
    }
}
