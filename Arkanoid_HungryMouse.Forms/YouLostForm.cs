using System.Windows.Forms;

namespace Arkanoid_HungryMouse.Forms
{
    public partial class YouLostForm : Form
    {
        public YouLostForm()
        {
            InitializeComponent();
        }

        private void YouLostForm_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            { Close(); }
        }
    }
}
