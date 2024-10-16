using System.Collections.Generic;
using Arkanoid_HungryMouse.Enums;
using Arkanoid_HungryMouse.GameEntities.AbstractClasses;
using Arkanoid_HungryMouse.GameEntities.Models;
using Arkanoid_HungryMouse.ObjectManager.Interfaces;
using Arkanoid_HungryMouse.Storage.Additions;
using Arkanoid_HungryMouse.Storage.Interfaces;

namespace Arkanoid_HungryMouse.ObjectManager
{
    /// <summary>
    /// <inheritdoc cref="IObjectManager"/>
    /// </summary>
    public class GameObjectManager : IObjectManager
    {

        private readonly IGameObjectStorage objectStorage;

        /// <summary>
        /// Конструктор прослойки: Указать хранилище
        /// </summary>
        public GameObjectManager(IGameObjectStorage objectStorage)
        {
            this.objectStorage = objectStorage;
        }

        #region interface implementation

        #region get fields

        public List<Box> GetBoxes() => objectStorage.GetBoxes();

        public Field GetField() => objectStorage.GetField();

        public Mouse GetMouse() => objectStorage.GetMouse();

        public PlayerTable GetPlayerTable() => objectStorage.GetPlayerTable();
        public int GetLifesCount() => objectStorage.GetLifesCount();

        #endregion

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

        public void SetSizesAndLocations(int width, int height)
        {
            var mouse = GetMouse();
            var table = GetPlayerTable();
            var field = GetField();

            field.Width = width;
            field.Height = height;

            table.Y = field.Height - table.Height;
            table.X = (field.Width / 2) - (table.Width / 2);

            mouse.X = (field.Width / 2) - (mouse.Width / 2);
            mouse.Y = field.Height - (mouse.Height * 2);
        }

        public void DecreaseLifeCount() => objectStorage.DecreaseLifeCount();

        #endregion

        #region game logic

        public GameState UpdateAll(Direction tableDirection)
        {
            var mouse = GetMouse();
            var table = GetPlayerTable();

            var futureMouse = new Mouse
            {
                X = mouse.X + (int)mouse.SpeedX,
                Y = mouse.Y + (mouse.VerticalDirection == Direction.Up ? mouse.Step : -mouse.Step),
                Width = mouse.Width,
                Height = mouse.Height,
                SpeedX = mouse.SpeedX,
                VerticalDirection = mouse.VerticalDirection,
            };

            var futureTable = new PlayerTable
            {
                X = table.X + (tableDirection == Direction.Right ? table.Step : -table.Step),
                Y = table.Y,
                Width = table.Width,
                Height = table.Height,
            };

            foreach (var box in GetBoxes())
            {
                if (GetRelativeLocation(box, futureMouse) == RelativeLocation.Intersect && !box.Destroyed)
                {
                    box.Destroyed = true;
                    switch (GetRelativeLocation(box, mouse))
                    {
                        case RelativeLocation.AtTheLeft:
                            {
                                mouse.SpeedX = -mouse.SpeedX;
                                break;
                            }
                        case RelativeLocation.AtTheRight:
                            {
                                mouse.SpeedX = -mouse.SpeedX;
                                break;
                            }
                        case RelativeLocation.AtTheTop:
                            {
                                mouse.VerticalDirection = Direction.Down;
                                break;
                            }
                        case RelativeLocation.AtTheBottom:
                            {
                                mouse.VerticalDirection = Direction.Up;
                                break;
                            }
                        default:
                            {
                                mouse.VerticalDirection = mouse.VerticalDirection == Direction.Up ? Direction.Down : Direction.Up;
                                break;
                            }
                    }
                }
            } // Обработка коробок

            switch (GetRelativeToFieldLocation(futureMouse))
            {
                case RelativeLocation.AtTheLeft:
                    {
                        mouse.SpeedX = -mouse.SpeedX;
                        break;
                    }
                case RelativeLocation.AtTheRight:
                    {
                        mouse.SpeedX = -mouse.SpeedX;
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
                default:
                    {
                        break;
                    }
            } // Обработка стен

            if (GetRelativeLocation(table, mouse) == RelativeLocation.Intersect)
            {
                mouse.VerticalDirection = Direction.Up;
                var distance = ((mouse.X + mouse.Width) / 2) - ((table.X + table.Width) / 2);
                mouse.SpeedX = distance * Const.SpeedMultiplier;
            } // Обработка столика

            if (GetRelativeToFieldLocation(futureTable) == RelativeLocation.Intersect)
            {
                Move(table, tableDirection);
            } // Сдвинуть столик, если он не попадет за стену

            Move(mouse, mouse.VerticalDirection);
            Move(mouse);

            if (GetDestroyedCount() == GetBoxes().Count)
            {
                return GameState.Won;
            } // Условие победы: коробок не осталось

            return GameState.Playing;
        }

        private void Move(Mouse mouse)
        {
            mouse.X += (int)mouse.SpeedX;
        }

        private void Move(GameObject gameObject, Direction direction)
        {
            switch (direction)
            {
                case Direction.Left:
                    {
                        gameObject.X -= gameObject.Step;
                        break;
                    }
                case Direction.Right:
                    {
                        gameObject.X += gameObject.Step;
                        break;
                    }
                case Direction.Up:
                    {
                        gameObject.Y -= gameObject.Step;
                        break;
                    }
                case Direction.Down:
                    {
                        gameObject.Y += gameObject.Step;
                        break;
                    }
            }
        }

        private bool ObjectsIntersect(GameObject relativeTo, GameObject gameObject)
        {
            if (gameObject.X >= relativeTo.X + relativeTo.Width || relativeTo.X >= gameObject.X + gameObject.Width)
            { return false; }

            if (gameObject.Y >= relativeTo.Y + relativeTo.Height || relativeTo.Y >= gameObject.Y + gameObject.Height)
            { return false; }

            return true;
        }

        private RelativeLocation GetRelativeLocation(GameObject relativeTo, GameObject gameObject)
        {
            if (ObjectsIntersect(relativeTo, gameObject))
            {
                return RelativeLocation.Intersect;
            }

            if (gameObject.X + gameObject.Width < relativeTo.X)
            {
                return RelativeLocation.AtTheLeft;
            }
            if (gameObject.X > relativeTo.X + relativeTo.Width)
            {
                return RelativeLocation.AtTheRight;
            }
            if (gameObject.Y + gameObject.Height < relativeTo.Y)
            {
                return RelativeLocation.AtTheTop;
            }
            if (gameObject.Y + gameObject.Height > relativeTo.Y + relativeTo.Height)
            {
                return RelativeLocation.AtTheBottom;
            }
            return RelativeLocation.Outside;
        }

        private RelativeLocation GetRelativeToFieldLocation(GameObject gameObject)
        {
            var field = objectStorage.GetField();
            if (gameObject.X < 0)
            {
                return RelativeLocation.AtTheLeft;
            }
            if (gameObject.Y < 0)
            {
                return RelativeLocation.AtTheTop;
            }
            if (gameObject.Y + gameObject.Height > field.Height)
            {
                return RelativeLocation.AtTheBottom;
            }
            if (gameObject.X + gameObject.Width > field.Width)
            {
                return RelativeLocation.AtTheRight;
            }
            return RelativeLocation.Intersect;
        }

        #endregion

    }
}

