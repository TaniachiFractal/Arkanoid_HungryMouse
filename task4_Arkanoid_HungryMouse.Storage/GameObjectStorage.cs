using System;
using System.Collections.Generic;
using Arkanoid_HungryMouse.Enums;
using Arkanoid_HungryMouse.GameEntities.Models;
using Arkanoid_HungryMouse.Storage.Additions;
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
        private Mouse Mouse { get; }

        /// <summary>
        /// <inheritdoc cref="GameEntities.Models.PlayerTable"/>
        /// </summary>
        private PlayerTable PlayerTable { get; }

        /// <summary>
        /// <inheritdoc cref="GameEntities.Models.Field"/>
        /// </summary>
        private Field Field { get; }

        /// <summary>
        /// Лист всех <see cref="Boxes"/>
        /// </summary>
        private List<Box> Boxes { get; }

        /// <summary>
        /// Количество жизней
        /// </summary>
        private int LifesCount { get; set; }

        #endregion

        #region get fields

        public List<Box> GetBoxes()
        {
            return Boxes;
        }

        public Field GetField()
        {
            return Field;
        }

        public Mouse GetMouse()
        {
            return Mouse;
        }

        public PlayerTable GetPlayerTable()
        {
            return PlayerTable;
        }

        public int GetLifesCount()
        {
            return LifesCount;
        }

        #endregion

        public void DecreaseLifeCount()
        {
            LifesCount--;
        }

        /// <summary>
        /// Конструктор: Инициализация полей
        /// </summary>
        public GameObjectStorage()
        {
            LifesCount = Const.StartLifesCount;

            Boxes = new List<Box>();

            Mouse = new Mouse
            {
                X = Const.MouseStartX,
                Y = Const.MouseStartY,
                Height = Const.HalfPartDimen,
                Width = Const.HalfPartDimen,
                VerticalDirection = Direction.Up,
                SpeedX = -Const.MouseStep,
                Step = Const.MouseStep,
            };

            PlayerTable = new PlayerTable
            {
                X = Const.TableStartX,
                Y = Const.TableStartY,
                Height = Const.QuarterPartDimen,
                Width = Const.FullPartDimen,
                Step = Const.TableStep,
            };

            Field = new Field
            {
                X = 0,
                Y = 0,
                Height = Const.FieldHeight,
                Width = Const.FieldWidth,
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
                        X = (Const.BoxesMargin * 2) + (Const.BoxesMargin * (col + 1)) + (col * Const.FullPartDimen),
                        Y = (Const.BoxesMargin * 2) + (Const.BoxesMargin * (row + 1)) + (row * Const.HalfPartDimen),
                        Height = Const.HalfPartDimen,
                        Width = Const.FullPartDimen,
                        Destroyed = false,
                        BoxType = BoxTypes[rnd.Next(BoxTypes.Length)],
                    };
                    Boxes.Add(box);
                }
            }
        }

    }
}
