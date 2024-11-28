using System.Collections.Generic;
using Arkanoid_HungryMouse.GameEntities.AbstractClasses;
using Arkanoid_HungryMouse.GameEntities.Models;

namespace Arkanoid_HungryMouse.Storage.Interfaces
{
    /// <summary>
    /// Хранилище <see cref="GameObject"/>
    /// </summary>
    public interface IGameObjectStorage
    {

        /// <summary>
        /// Получить объект <see cref="Mouse"/> из хранилища
        /// </summary>
        Mouse GetMouse();

        /// <summary>
        /// Получить объект <see cref="Field"/> из хранилища
        /// </summary>
        Field GetField();

        /// <summary>
        /// Получить объект <see cref="PlayerTable"/> из хранилища
        /// </summary>
        PlayerTable GetPlayerTable();

        /// <summary>
        /// Получить список <see cref="Box"/> из хранилища
        /// </summary>
        List<Box> GetBoxes();

        /// <summary>
        /// Получить количество оставшихся жизней
        /// </summary>
        int GetLifesCount();

        /// <summary>
        /// Уменьшить количество оставшихся жизней
        /// </summary>
        void DecreaseLifeCount();

    }
}
