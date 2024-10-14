using System;
using System.Collections.Generic;
using System.Windows.Forms;
using Arkanoid_HungryMouse.GameEntities.Enums;
using Arkanoid_HungryMouse.GameEntities.Interfaces;
using Arkanoid_HungryMouse.GameEntities.Models;
using task4_Arkanoid_HungryMouse.GameObjectManager.Interfaces;
using task4_Arkanoid_HungryMouse.Storage.Classes;
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

        /// <summary>
        /// Получить количество разрушенных коробок
        /// </summary>
        public int GetDestroyedCount()
        {
            var destroyedCount = 0;
            foreach (var box in GetBoxes())
            {
                if (box.Destroyed)
                {
                    destroyedCount++;
                }
            }
            return destroyedCount;
        }

        public RelativeLocation GetRelativeLocation(IGameObject relativeTo, IGameObject gameObject) =>
            objectStorage.GetRelativeLocation(relativeTo, gameObject);

        public void Move(IGameObject gameObject, Direction direction)
        {
            switch (direction)
            {
                case Direction.Left:
                    {
                        gameObject.X -= Const.Step;
                        break;
                    }
                case Direction.Right:
                    {
                        gameObject.X += Const.Step;
                        break;
                    }
                case Direction.Up:
                    {
                        gameObject.Y -= Const.Step;
                        break;
                    }
                case Direction.Down:
                    {
                        gameObject.Y += Const.Step;
                        break;
                    }
            }
        }

        /// <summary>
        /// Сдвинуть мышь по её скорости
        /// </summary>
        public void Move(Mouse mouse)
        {
            mouse.X += mouse.SpeedX;
        }

        public void SetDestroyed(IGameObject gameObject)
        {
            gameObject.Destroyed = true;
        }

        public GameState UpdateAll(Direction tableDirection)
        {
            var mouse = GetMouse();
            var table = GetPlayerTable();
            var field = GetField();

            foreach (var box in GetBoxes())
            {
                if (GetRelativeLocation(box, mouse) == RelativeLocation.Intersect)
                {
                    SetDestroyed(box);
                }
            } // Разрушение коробок

            if (GetDestroyedCount() == GetBoxes().Count)
            {
                return GameState.Won;
            }

            if (GetRelativeLocation(table, mouse) == RelativeLocation.Intersect)
            {
                mouse.VerticalDirection = Direction.Up;
            } // Отскакивание от столика

            switch (GetRelativeLocation(field, mouse))
            {
                case RelativeLocation.Intersect:
                    {
                        break;
                    }
                case RelativeLocation.AtTheLeft:
                    {
                        mouse.SpeedX = Const.Step;
                        break;
                    }
                case RelativeLocation.AtTheRight:
                    {
                        mouse.SpeedX = -Const.Step;
                        break;
                    }
                case RelativeLocation.AtTheTop:
                    {
                        mouse.VerticalDirection = Direction.Down;
                        break;
                    }
                case RelativeLocation.AtTheBottom:
                    {
                        return GameState.Lost;
                    }
            } // Отскакивание от стен или проигрыш - попадание за низ поля

            Move(mouse, mouse.VerticalDirection);
            Move(mouse);

            Move(table, tableDirection);

            return GameState.Playing;
        }
    }
}

