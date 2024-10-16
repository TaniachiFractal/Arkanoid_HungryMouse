using System;
using System.Windows.Forms;
using Arkanoid_HungryMouse.Forms;
using Arkanoid_HungryMouse.ObjectManager;
using Arkanoid_HungryMouse.Storage;

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
