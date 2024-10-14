using System;
using System.Collections.Generic;
using Arkanoid_HungryMouse.GameEntities.Interfaces;
using Arkanoid_HungryMouse.GameEntities.Models;
using task4_Arkanoid_HungryMouse.Storage.Classes;
using task4_Arkanoid_HungryMouse.Storage.Interfaces;

namespace task4_Arkanoid_HungryMouse.Storage.Storage
{
    /// <summary>
    /// <inheritdoc cref="IGameObjectStorage"/>
    /// </summary>
    public class GameObjectStorage : IGameObjectStorage
    {
        #region fields

        /// <summary>
        /// <inheritdoc cref="Arkanoid_HungryMouse.GameEntities.Models.Mouse"/>
        /// </summary>
        private Mouse Mouse { get; }

        /// <summary>
        /// <inheritdoc cref="Arkanoid_HungryMouse.GameEntities.Models.PlayerTable"/>
        /// </summary>
        private PlayerTable PlayerTable { get; }

        /// <summary>
        /// <inheritdoc cref="Arkanoid_HungryMouse.GameEntities.Models.Field"/>
        /// </summary>
        private Field Field { get; }

        /// <summary>
        /// Лист всех <see cref="Boxes"/>
        /// </summary>
        private List<Box> Boxes { get; }

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
            for (var row = 0; row < Const.BoxListRows; row++)
            {
                for (var col = 0; col < Const.BoxListCols; col++)
                {
                    var box = new Box
                    {
                        X = Const.BoxesMargin + row * Const.LongDimen,
                        Y = Const.BoxesMargin + row * Const.ShortDimen,
                        Height = Const.ShortDimen,
                        Width = Const.LongDimen,
                        Destroyed = false,
                    };
                }
            }
        }

        public void ChangeObjectData(IGameObject gameObject, Action<IGameObject> action = null)
        {
            action?.Invoke(gameObject);
        }

        public RelativeLocation GetRelativeLocation(IGameObject relativeTo, IGameObject gameObject)
        {
            if (gameObject.Y > relativeTo.Y + relativeTo.Height)
            {
                return RelativeLocation.AtTheBottom;
            }
            else if (gameObject.Y < relativeTo.Y)
            {
                return RelativeLocation.AtTheTop;
            }
            else if (gameObject.X > relativeTo.X + relativeTo.Width)
            {
                return RelativeLocation.AtTheRight;
            }
            else if (gameObject.X < relativeTo.X)
            {
                return RelativeLocation.AtTheLeft;
            }
            else
            {
                return RelativeLocation.Inside;
            }
        }
    }
}
