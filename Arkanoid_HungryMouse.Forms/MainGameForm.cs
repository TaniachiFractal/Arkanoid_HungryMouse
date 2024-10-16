using System.Drawing;
using System.Windows.Forms;
using Arkanoid_HungryMouse.Enums;
using Arkanoid_HungryMouse.ObjectManager.Interfaces;

namespace Arkanoid_HungryMouse.Forms
{
    /// <summary>
    /// Основная форма приложения
    /// </summary>
    public partial class MainGameForm : Form
    {
        private readonly IObjectManager mgr;
        private readonly Graphics canvas;
        private Direction tableDirection;
        private readonly Timer animTimer;

        /// <summary>
        /// Конструктор: указать прослойку
        /// </summary>
        public MainGameForm(IObjectManager objectManager)
        {
            InitializeComponent();

            mgr = objectManager;
            InitObjectData();

            canvas = GameField.CreateGraphics();

            animTimer = new Timer
            {
                Interval = 30
            };
            animTimer.Tick += AnimationTimer_Tick;
            animTimer.Start();
        }

        private void MainGameForm_KeyUp(object sender, KeyEventArgs e)
        {
            tableDirection = Direction.Stay;
        }

        private void MainGameForm_KeyDown(object sender, KeyEventArgs e)
        {
            switch (e.KeyCode)
            {
                case Keys.Left:
                    {
                        tableDirection = Direction.Left;
                        break;
                    }
                case Keys.Right:
                    {
                        tableDirection = Direction.Right;
                        break;
                    }
            }
        }

        private void AnimationTimer_Tick(object sender, System.EventArgs e)
        {
            var gameState = mgr.UpdateAll(tableDirection);
            switch (gameState)
            {
                case GameState.Won:
                    {
                        UpdateOutput();
                        animTimer.Stop();
                        animTimer.Enabled = false;
                        MessageBox.Show("Победа!", "Победа!", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        Application.Exit();
                        break;
                    }
                case GameState.Lost:
                    {
                        UpdateOutput();
                        animTimer.Stop();
                        animTimer.Enabled = false;
                        MessageBox.Show("Поражение!", "Поражение!", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                        Application.Exit();
                        break;
                    }
            }
            UpdateOutput();
        }

        private void InitObjectData()
        {
            mgr.SetSizesAndLocations(GameField.Width, GameField.Height);
        }

        private void Draw()
        {
            var newImage = new Bitmap(GameField.Width, GameField.Height);
            var newGraphics = Graphics.FromImage(newImage);
            newGraphics.DrawImage(Forms.Properties.Resources.gradientBG, 0, 0);
            newGraphics.DrawImage(Forms.Properties.Resources.mouse, mgr.GetMouse().X, mgr.GetMouse().Y);
            newGraphics.DrawImage(Forms.Properties.Resources.table, mgr.GetPlayerTable().X, mgr.GetPlayerTable().Y);
            foreach (var box in mgr.GetBoxes())
            {
                if (!box.Destroyed)
                { newGraphics.DrawImage(GetBoxImage(box.BoxType), box.X, box.Y); }
            }
            canvas.DrawImage(newImage, 0, 0);
        }

        private void UpdateOutput()
        {
            Draw();
            InfoLabel.Text = $"Счёт: {mgr.GetDestroyedCount()}";
        }

        private Bitmap GetBoxImage(BoxTypes boxType)
        {
            switch (boxType)
            {
                case BoxTypes.Apples:
                    return Forms.Properties.Resources.apples;
                case BoxTypes.Bread:
                    return Forms.Properties.Resources.bread;
                case BoxTypes.Eggs:
                    return Forms.Properties.Resources.eggs;
                case BoxTypes.Nuts:
                    return Forms.Properties.Resources.nuts;
                case BoxTypes.Peaches:
                    return Forms.Properties.Resources.peaches;
                case BoxTypes.Pumpkins:
                    return Forms.Properties.Resources.pumpkins;
                case BoxTypes.Sausage:
                    return Forms.Properties.Resources.sausage;
                case BoxTypes.Wheat:
                    return Forms.Properties.Resources.wheat;
                default:
                    return Forms.Properties.Resources.wheat;
            }
        }

    }
}
