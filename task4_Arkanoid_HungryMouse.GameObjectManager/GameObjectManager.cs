using System;
using System.Collections.Generic;
using Arkanoid_HungryMouse.Enums;
using Arkanoid_HungryMouse.GameEntities.AbstractClasses;
using Arkanoid_HungryMouse.GameEntities.Models;
using Arkanoid_HungryMouse.ObjectManager.Interfaces;
using Arkanoid_HungryMouse.Storage;
using Arkanoid_HungryMouse.Storage.Classes;

namespace Arkanoid_HungryMouse.ObjectManager
{
    /// <summary>
    /// <inheritdoc cref="IObjectManager"/>
    /// </summary>
    public class GameObjectManager : IObjectManager
    {
        private readonly GameObjectStorage objectStorage;

        /// <summary>
        /// Конструктор прослойки: Указать хранилище
        /// </summary>
        public GameObjectManager(GameObjectStorage objectStorage)
        {
            this.objectStorage = objectStorage;
        }

        #region interface implementation

        public void ChangeObjectData(GameObject gameObject, Action<GameObject> action) =>
            objectStorage.ChangeObjectData(gameObject, action);

        public RelativeLocation GetRelativeLocation(GameObject relativeTo, GameObject gameObject) =>
            objectStorage.GetRelativeLocation(relativeTo, gameObject);

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

        public void SetDestroyed(GameObject gameObject)
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

        public void SetSizesAndLocations(int width, int height)
        {
            var mouse = GetMouse();
            var table = GetPlayerTable();
            var field = GetField();

            field.Width = width;
            field.Height = height;

            table.Y = field.Height - (table.Height / 2);
            table.X = (field.Width / 2) - (table.Width / 2);

            mouse.X = (field.Width / 2) - (mouse.Width / 2);
            mouse.Y = field.Height - (mouse.Height * 2);
        }

        #endregion

        #region get fields
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
        #endregion

        /// <summary>
        /// Сдвинуть мышь по её скорости
        /// </summary>
        private void Move(Mouse mouse)
        {
            mouse.X += mouse.SpeedX;
        }

        /// <summary>
        /// Сдвинуть объект в направлении
        /// </summary>
        private void Move(GameObject gameObject, Direction direction)
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

    }
}

