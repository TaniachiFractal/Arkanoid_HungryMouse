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
            animTimer.Enabled = false;
            UpdateOutput();
        }

        #region key down methods

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
                        LeftKeyDown();
                        break;
                    }
                case Keys.Right:
                    {
                        RightKeyDown();
                        break;
                    }
                case Keys.Enter:
                    {
                        EnterKeyDown();
                        break;
                    }
            }
        }

        private void LeftKeyDown()
        {

            tableDirection = Direction.Left;
        }

        private void RightKeyDown()
        {

            tableDirection = Direction.Right;
        }

        private void EnterKeyDown()
        {
            TogglePaused();
        }

        #endregion

        private void TogglePaused()
        {
            animTimer.Enabled = !animTimer.Enabled;
            LabelHowToStart.Visible = !LabelHowToStart.Visible;
        }

        private void AnimationTimer_Tick(object sender, System.EventArgs e)
        {
            var gameState = mgr.UpdateAll(tableDirection);

            UpdateOutput();
            switch (gameState)
            {
                case GameState.Won:
                    {
                        animTimer.Stop();
                        animTimer.Enabled = false;
                        MessageBox.Show("Победа!", "Победа!", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        Application.Exit();
                        break;
                    }
                case GameState.Lost:
                    {
                        if (mgr.GetLifesCount() > 0)
                        {
                            TogglePaused();
                            InitObjectData();
                            mgr.DecreaseLifeCount();
                        }
                        else
                        {
                            animTimer.Stop();
                            animTimer.Enabled = false;
                            MessageBox.Show("Поражение!", "Поражение!", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                            Application.Exit();
                        }
                        break;
                    }
            }
        }

        private void InitObjectData()
        {
            mgr.SetSizesAndLocations(GameField.Width, GameField.Height);
        }

        private void RenderMainGameplay()
        {
            var mouse = mgr.GetMouse();
            var table = mgr.GetPlayerTable();

            var newImage = new Bitmap(GameField.Width, GameField.Height);
            var newGraphics = Graphics.FromImage(newImage);
            newGraphics.DrawImage(Properties.Resources.gradientBG, 0, 0);
            newGraphics.DrawImage(Properties.Resources.table, new Rectangle(table.X, table.Y, table.Width, table.Height));
            foreach (var box in mgr.GetBoxes())
            {
                if (!box.Destroyed)
                { newGraphics.DrawImage(GetBoxImage(box.BoxType), new Rectangle(box.X, box.Y, box.Width, box.Height)); }
            }
            newGraphics.DrawImage(Properties.Resources.mouse, new Rectangle(mouse.X, mouse.Y, mouse.Width, mouse.Height));
            canvas.DrawImage(newImage, 0, 0);
        }

        private void RenderToolStripOutput()
        {
            InfoStrip.Items.Clear();

            InfoStrip.Items.Add($"Счёт: {mgr.GetDestroyedCount()}  Жизни: ");

            for (var i = 0; i < mgr.GetLifesCount(); i++)
            {
                var newMouseLifeImage = new ToolStripButton
                {
                    Image = Properties.Resources.mouse
                };
                InfoStrip.Items.Add(newMouseLifeImage);
            }
        }

        private void UpdateOutput()
        {
            RenderMainGameplay();
            RenderToolStripOutput();
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
