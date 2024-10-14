using System;
using System.Runtime.Serialization;
using System.Windows.Forms;
using task4_Arkanoid_HungryMouse.GameObjectManager.Manager;
using task4_Arkanoid_HungryMouse.Storage.Storage;

namespace Arkanoid_HungryMouse
{
    static internal class Program
    {
        /// <summary>
        /// The main entry point for the application.
        /// </summary>
        [STAThread]
        private static void Main()
        {
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            var objectStorage = new GameObjectStorage();
            var objectManager = new GameObjectManager(objectStorage);
            Application.Run(new MainGameForm(objectManager));
        }
    }
}
