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
        private bool playing;

        /// <summary>
        /// Конструктор
        /// </summary>
        public MainGameForm(IObjectManager objectManager)
        {
            InitializeComponent();

            mgr = objectManager;
            InitObjectData();

            canvas = GameField.CreateGraphics();

            animTimer = new Timer
            {
                Interval = 10
            };
            animTimer.Tick += AnimationTimer_Tick;
            animTimer.Start();
            animTimer.Enabled = false;
            playing = false;

            UpdateOutput();
        }

        #region key down methods

        private void MainGameForm_KeyUp(object sender, KeyEventArgs e)
        {
            switch (e.KeyCode)
            {
                case Keys.Left:
                    {
                        LeftKeyUp();
                        break;
                    }
                case Keys.Right:
                    {
                        RightKeyUp();
                        break;
                    }
            }
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
                case Keys.F1:
                    {
                        F1KeyDown();
                        break;
                    }
            }
        }

        #region left
        private void LeftKeyDown()
        {

            tableDirection = Direction.Left;
        }
        private void LeftKeyUp()
        {
            tableDirection = Direction.Stay;
        }
        #endregion

        #region right
        private void RightKeyDown()
        {

            tableDirection = Direction.Right;
        }
        private void RightKeyUp()
        {
            tableDirection = Direction.Stay;
        }
        #endregion

        private void EnterKeyDown()
        {
            TogglePlaying();
        }

        private void F1KeyDown()
        {
            playing = false;
            UpdatePlaying();
            new InfoForm().ShowDialog();
        }

        #endregion

        private void TogglePlaying()
        {
            playing = !playing;
            UpdatePlaying();
        }

        private void UpdatePlaying()
        {
            animTimer.Enabled = playing;
            InfoLabel.Visible = !playing;
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
                        new YouWonForm().ShowDialog();
                        Application.Exit();
                        break;
                    }
                case GameState.Lost:
                    {
                        System.Threading.Thread.Sleep(500);
                        if (mgr.GetLifesCount() > 0)
                        {
                            TogglePlaying();
                            InitObjectData();
                            mgr.DecreaseLifeCount();
                        }
                        else
                        {
                            UpdateOutput();
                            animTimer.Stop();
                            animTimer.Enabled = false;
                            new YouLostForm(mgr.GetDestroyedCount()).ShowDialog();
                            Application.Exit();
                        }
                        break;
                    }
            }
            UpdateOutput();
        }

        #region render

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

        #endregion
    }
}
