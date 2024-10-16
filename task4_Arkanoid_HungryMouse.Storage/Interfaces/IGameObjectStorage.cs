using System;
using Arkanoid_HungryMouse.Enums;
using Arkanoid_HungryMouse.GameEntities.AbstractClasses;

namespace Arkanoid_HungryMouse.Storage.Interfaces
{
    /// <summary>
    /// Хранилище <see cref="GameObject"/>
    /// </summary>
    public interface IGameObjectStorage
    {
        /// <summary>
        /// Изменить объект
        /// </summary>
        void ChangeObjectData(GameObject gameObject, Action<GameObject> action);

        /// <summary>
        /// Получить относительное расположение двух объектов
        /// </summary>
        RelativeLocation GetRelativeLocation(GameObject relativeTo, GameObject gameObject);
    }
}
