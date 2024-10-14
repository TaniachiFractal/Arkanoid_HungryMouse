using System;
using System.Collections.Generic;
using Arkanoid_HungryMouse.GameEntities.Enums;
using Arkanoid_HungryMouse.GameEntities.Interfaces;
using Arkanoid_HungryMouse.GameEntities.Models;
using task4_Arkanoid_HungryMouse.GameObjectManager.Interfaces;
using task4_Arkanoid_HungryMouse.Storage.Storage;

namespace task4_Arkanoid_HungryMouse.GameObjectManager.Manager
{
    /// <summary>
    /// <inheritdoc cref="IObjectManager"/>
    /// </summary>
    public class GameObjectManager : IObjectManager
    {
        private GameObjectStorage objectStorage;

        /// <summary>
        /// Конструктор прослойки: Указать хранилище
        /// </summary>
        public GameObjectManager(GameObjectStorage objectStorage)
        {
            this.objectStorage = objectStorage;
        }

        public void ChangeObjectData(IGameObject gameObject, Action<IGameObject> action) =>
            objectStorage.ChangeObjectData(gameObject, action);

        public List<Box> GetBoxes()
        {
            return objectStorage.Boxes;
        }
        public Field GetField()
        {
            return objectStorage.Field;
        }
        public Mouse GetMouse()
        {
            return objectStorage.Mouse;
        }
        public PlayerTable GetPlayerTable()
        {
            return objectStorage.PlayerTable;
        }

        public RelativeLocation GetRelativeLocation(IGameObject relativeTo, IGameObject gameObject) =>
            objectStorage.GetRelativeLocation(relativeTo, gameObject);
    }
}
