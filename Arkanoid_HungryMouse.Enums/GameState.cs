namespace Arkanoid_HungryMouse.Enums
{
    /// <summary>
    /// Состояния игры
    /// </summary>
    public enum GameState
    {
        /// <summary>
        /// В процессе игры
        /// </summary>
        Playing = 1,

        /// <summary>
        /// Победа
        /// </summary>
        Won = 2,

        /// <summary>
        /// Поражение
        /// </summary>
        Lost = 3,

        /// <summary>
        /// Пауза
        /// </summary>
        Paused = 4,
    }
}
