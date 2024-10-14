using System.Drawing;
using System.Windows.Forms;
using Arkanoid_HungryMouse.GameEntities.Enums;
using task4_Arkanoid_HungryMouse.GameObjectManager.Manager;

namespace Arkanoid_HungryMouse
{
    /// <summary>
    /// Основная форма приложения
    /// </summary>
    public partial class MainGameForm : Form
    {
        private readonly GameObjectManager mgr;
        private readonly Graphics canvas;
        private Direction tableDirection;
        private readonly Timer animTimer;

        /// <summary>
        /// Конструктор: указать прослойку
        /// </summary>
        public MainGameForm(GameObjectManager objectManager)
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
            mgr.ChangeObjectData(mgr.GetField(), field =>
            {
                field.Width = GameField.Width;
                field.Height = GameField.Height;
            });
            mgr.ChangeObjectData(mgr.GetPlayerTable(), table =>
            {
                table.Y = GameField.Height - (table.Height / 2);
                table.X = (GameField.Width / 2) - (table.Width / 2);
            });
            mgr.ChangeObjectData(mgr.GetMouse(), mouse =>
            {
                mouse.X = (GameField.Width / 2) - (mouse.Width / 2);
                mouse.Y = GameField.Height - mouse.Height * 2;
            });
        }

        private void Draw()
        {
            var newImage = new Bitmap(GameField.Width, GameField.Height);
            var newGraphics = Graphics.FromImage(newImage);
            newGraphics.DrawImage(Properties.Resources.gradientBG, 0, 0);
            newGraphics.DrawImage(Properties.Resources.mouse, mgr.GetMouse().X, mgr.GetMouse().Y);
            newGraphics.DrawImage(Properties.Resources.table, mgr.GetPlayerTable().X, mgr.GetPlayerTable().Y);
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
                    return Properties.Resources.apples;
                case BoxTypes.Bread:
                    return Properties.Resources.bread;
                case BoxTypes.Eggs:
                    return Properties.Resources.eggs;
                case BoxTypes.Nuts:
                    return Properties.Resources.nuts;
                case BoxTypes.Peaches:
                    return Properties.Resources.peaches;
                case BoxTypes.Pumpkins:
                    return Properties.Resources.pumpkins;
                case BoxTypes.Sausage:
                    return Properties.Resources.sausage;
                case BoxTypes.Wheat:
                    return Properties.Resources.wheat;
                default:
                    return Properties.Resources.wheat;
            }
        }

    }
}
