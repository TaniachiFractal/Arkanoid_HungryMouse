using System.Windows.Forms;

namespace Arkanoid_HungryMouse.Forms
{
    /// <summary>
    /// Форма поражения
    /// </summary>
    public partial class YouLostForm : Form
    {
        /// <summary>
        /// Конструктор формы поражения: вывести счёт
        /// </summary>
        public YouLostForm(int finScore)
        {
            InitializeComponent();
            ScoreLabel.Text = $"Счёт: {finScore}";
        }

        private void YouLostForm_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            { Close(); }
        }
    }
}
