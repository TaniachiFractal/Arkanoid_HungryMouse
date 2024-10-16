using System;
using System.Collections.Generic;
using Arkanoid_HungryMouse.Enums;
using Arkanoid_HungryMouse.GameEntities.AbstractClasses;
using Arkanoid_HungryMouse.GameEntities.Models;
using Arkanoid_HungryMouse.Storage.Classes;
using Arkanoid_HungryMouse.Storage.Interfaces;

namespace Arkanoid_HungryMouse.Storage
{
    /// <summary>
    /// <inheritdoc cref="IGameObjectStorage"/>
    /// </summary>
    public class GameObjectStorage : IGameObjectStorage
    {
        #region fields

        /// <summary>
        /// <inheritdoc cref="GameEntities.Models.Mouse"/>
        /// </summary>
        public Mouse Mouse { get; }

        /// <summary>
        /// <inheritdoc cref="GameEntities.Models.PlayerTable"/>
        /// </summary>
        public PlayerTable PlayerTable { get; }

        /// <summary>
        /// <inheritdoc cref="GameEntities.Models.Field"/>
        /// </summary>
        public Field Field { get; }

        /// <summary>
        /// Лист всех <see cref="Boxes"/>
        /// </summary>
        public List<Box> Boxes { get; }

        #endregion

        /// <summary>
        /// Конструктор: Инициализация полей
        /// </summary>
        public GameObjectStorage()
        {
            Boxes = new List<Box>();

            Mouse = new Mouse
            {
                X = Const.MouseStartX,
                Y = Const.MouseStartY,
                Height = Const.ShortDimen,
                Width = Const.ShortDimen,
                Destroyed = false,
                VerticalDirection = Direction.Up,
                SpeedX = -Const.Step,
            };

            PlayerTable = new PlayerTable
            {
                X = Const.TableStartX,
                Y = Const.TableStartY,
                Height = Const.ShortDimen,
                Width = Const.LongDimen,
                Destroyed = false,
            };

            Field = new Field
            {
                X = 0,
                Y = 0,
                Height = Const.FieldHeight,
                Width = Const.FieldWidth,
                Destroyed = false,
            };

            GenerateBoxes();
        }

        private void GenerateBoxes()
        {
            var BoxTypes = (BoxTypes[])Enum.GetValues(typeof(BoxTypes));
            var rnd = new Random();
            for (var row = 0; row < Const.BoxListRows; row++)
            {
                for (var col = 0; col < Const.BoxListCols; col++)
                {
                    var box = new Box
                    {
                        X = (Const.BoxesMargin * 2) + (Const.BoxesMargin * (col + 1)) + (col * Const.LongDimen),
                        Y = (Const.BoxesMargin * 2) + (Const.BoxesMargin * (row + 1)) + (row * Const.ShortDimen),
                        Height = Const.ShortDimen,
                        Width = Const.LongDimen,
                        Destroyed = false,
                        BoxType = BoxTypes[rnd.Next(BoxTypes.Length)],
                    };
                    Boxes.Add(box);
                }
            }
        }

        public void ChangeObjectData(GameObject gameObject, Action<GameObject> action = null)
        {
            action?.Invoke(gameObject);
        }

        public RelativeLocation GetRelativeLocation(GameObject relativeTo, GameObject gameObject)
        {
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
            else
            {
                return RelativeLocation.Intersect;
            }

        }
    }
}
