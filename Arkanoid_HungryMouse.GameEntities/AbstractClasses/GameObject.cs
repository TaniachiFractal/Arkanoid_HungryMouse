using System;
using Arkanoid_HungryMouse.Enums;
using Arkanoid_HungryMouse.GameEntities.Models;

namespace Arkanoid_HungryMouse.GameEntities.AbstractClasses
{
    /// <summary>
    /// Игровой объект
    /// </summary>
    public abstract class GameObject
    {

        /// <summary>
        /// Координата по ширине
        /// </summary>
        public int X { get; set; }

        /// <summary>
        /// Координата по высоте
        /// </summary>
        public int Y { get; set; }

        /// <summary>
        /// Ширина объекта
        /// </summary>
        public int Width { get; set; }

        /// <summary>
        /// Высота объекта
        /// </summary>
        public int Height { get; set; }

        /// <summary>
        /// Базовая скорость 
        /// </summary>
        public int Step { get; set; }

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
                if (relativeTo.GetType() == typeof(Field))
                {
                    if (gameObject.X < 0)
                    {
                        return RelativeLocation.AtTheLeft;
                    }
                    if (gameObject.Y < 0)
                    {
                        return RelativeLocation.AtTheTop;
                    }
                    if (gameObject.X + gameObject.Width > relativeTo.Width)
                    {
                        return RelativeLocation.AtTheRight;
                    }
                    if (gameObject.Y + gameObject.Height > relativeTo.Height)
                    {
                        return RelativeLocation.AtTheBottom;
                    }
                    return RelativeLocation.Intersect;
                }
                else
                { return RelativeLocation.Intersect; }
            }

        }
    }
}
