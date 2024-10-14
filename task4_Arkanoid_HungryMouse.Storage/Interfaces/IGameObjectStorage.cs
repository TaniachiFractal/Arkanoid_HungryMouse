using System;
using Arkanoid_HungryMouse.GameEntities.Enums;
using Arkanoid_HungryMouse.GameEntities.Interfaces;

namespace task4_Arkanoid_HungryMouse.Storage.Interfaces
{
    /// <summary>
    /// Хранилище <see cref="IGameObject"/>
    /// </summary>
    public interface IGameObjectStorage
    {
        /// <summary>
        /// Изменить объект
        /// </summary>
        void ChangeObjectData(IGameObject gameObject, Action<IGameObject> action);

        /// <summary>
        /// Получить относительное расположение двух объектов
        /// </summary>
        RelativeLocation GetRelativeLocation(IGameObject relativeTo, IGameObject gameObject);
    }
}
