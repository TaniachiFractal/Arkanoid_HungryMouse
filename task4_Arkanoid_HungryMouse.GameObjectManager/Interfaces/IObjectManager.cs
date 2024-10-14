using System;
using System.Collections.Generic;
using Arkanoid_HungryMouse.GameEntities.Enums;
using Arkanoid_HungryMouse.GameEntities.Interfaces;
using Arkanoid_HungryMouse.GameEntities.Models;
using task4_Arkanoid_HungryMouse.Storage.Interfaces;

namespace task4_Arkanoid_HungryMouse.GameObjectManager.Interfaces
{
    /// <summary>
    /// Прослойка между <see cref="IGameObjectStorage"/> и представлением
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
        /// <inheritdoc cref="IGameObjectStorage.ChangeObjectData(IGameObject, Action{IGameObject})"/>
        /// </summary>
        void ChangeObjectData(IGameObject gameObject, Action<IGameObject> action = null);

        /// <summary>
        /// <inheritdoc cref="IGameObjectStorage.GetRelativeLocation(IGameObject, IGameObject)"/>
        /// </summary>
        RelativeLocation GetRelativeLocation(IGameObject relativeTo, IGameObject gameObject);

    }
}
