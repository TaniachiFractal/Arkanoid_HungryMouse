using Arkanoid_HungryMouse.GameEntities.Interfaces;

namespace Arkanoid_HungryMouse.GameEntities.Models
{
    /// <summary>
    /// <see cref="IGameObject"/> игрока - столика, от которого прыгает <see cref="Mouse"/>
    /// </summary>
    public class PlayerTable : IGameObject
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
        public int Width => 128;

        /// <summary>
        /// <inheritdoc cref="IGameObject.Height"/>
        /// </summary>
        public int Height => 64;

    }
}
