using System;
using System.Collections.Generic;
using Arkanoid_HungryMouse.Enums;
using Arkanoid_HungryMouse.GameEntities.Models;
using Arkanoid_HungryMouse.Storage.Additions;
using Arkanoid_HungryMouse.Storage.Interfaces;

namespace Arkanoid_HungryMouse.Storage
{
    /// <inheritdoc cref="IGameObjectStorage"/>
    public class GameObjectStorage : IGameObjectStorage
    {

        #region fields

        /// <inheritdoc cref="GameEntities.Models.Mouse"/>
        private Mouse Mouse { get; }
        /// <inheritdoc cref="GameEntities.Models.PlayerTable"/>
        private PlayerTable PlayerTable { get; }
        /// <inheritdoc cref="GameEntities.Models.Field"/>
        private Field Field { get; }
        /// <summary>
        /// Лист всех <see cref="Box"/>
        /// </summary>
        private List<Box> Boxes { get; }
        /// <summary>
        /// Количество жизней
        /// </summary>
        private int LifesCount { get; set; }

        #endregion

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

        #region get fields

        /// <inheritdoc/>
        public List<Box> GetBoxes()
        {
            return Boxes;
        }

        /// <inheritdoc/>
        public Field GetField()
        {
            return Field;
        }

        /// <inheritdoc/>
        public Mouse GetMouse()
        {
            return Mouse;
        }

        /// <inheritdoc/>
        public PlayerTable GetPlayerTable()
        {
            return PlayerTable;
        }

        /// <inheritdoc/>
        public int GetLifesCount()
        {
            return LifesCount;
        }

        #endregion

        /// <inheritdoc/>
        public void DecreaseLifeCount()
        {
            LifesCount--;
        }

        private void GenerateBoxes()
        {
            var WhatPartOfFieldIsCoveredWithBoxes = 0.6;

            var field = GetField();

            var colCount = (field.Width - Const.BoxesMargin) / (Const.FullPartDimen + Const.BoxesMargin);
            var rowCount = field.Height * WhatPartOfFieldIsCoveredWithBoxes / (Const.HalfPartDimen + Const.BoxesMargin);

            var BoxTypes = (BoxTypes[])Enum.GetValues(typeof(BoxTypes));
            var rnd = new Random();
            for (var row = 0; row < rowCount; row++)
            {
                for (var col = 0; col < colCount; col++)
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
