using System;
using System.Collections.Generic;
using Arkanoid_HungryMouse.Enums;
using Arkanoid_HungryMouse.GameEntities.AbstractClasses;
using Arkanoid_HungryMouse.GameEntities.Models;

namespace Arkanoid_HungryMouse.ObjectManager.Interfaces
{
    /// <summary>
    /// Прослойка между хранилищем и представлением
    /// </summary>
    public interface IObjectManager
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
        /// Изменить данные объекта
        /// </summary>
        void ChangeObjectData(GameObject gameObject, Action<GameObject> action = null);

        /// <summary>
        /// <inheritdoc cref="IGameObjectStorage.GetRelativeLocation(GameObject, GameObject)"/>
        /// </summary>
        RelativeLocation GetRelativeLocation(GameObject relativeTo, GameObject gameObject);

        /// <summary>
        /// Установить объекту статус "Разрушен"
        /// </summary>
        void SetDestroyed(GameObject gameObject);

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
    }
}
