using System.Collections.Generic;
using Arkanoid_HungryMouse.Enums;
using Arkanoid_HungryMouse.GameEntities.Models;

namespace Arkanoid_HungryMouse.ObjectManager.Interfaces
{
    /// <summary>
    /// Прослойка между хранилищем и представлением, также обработчик игры
    /// </summary>
    public interface IObjectManager
    {

        #region get fields

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

        #endregion

        /// <summary>
        /// Обновить все объекты: Проверить пересечения, уничтожить то, что надо; Сдвинуть <see cref="Mouse"/> и <see cref="PlayerTable"/>
        /// </summary>
        /// <returns>Состояние игры после обновления</returns>
        GameState UpdateAll(Direction tableDirection);

        /// <summary>
        /// Получить количество разрушенных коробок
        /// </summary>
        int GetDestroyedCount();

        /// <summary>
        /// Указать размер поля и по этим данным разместить другие объекты
        /// </summary>
        void SetSizesAndLocations(int width, int height);

        /// <summary>
        /// Получить количество оставшихся жизней
        /// </summary>
        int GetLifesCount();

        /// <summary>
        /// Уменьшить количество жизней на 1
        /// </summary>
        void DecreaseLifeCount();
    }
}
