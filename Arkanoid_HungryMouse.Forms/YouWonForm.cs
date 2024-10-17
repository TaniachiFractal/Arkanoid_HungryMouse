using System.Windows.Forms;

namespace Arkanoid_HungryMouse.Forms
{
    public partial class YouWonForm : Form
    {
        public YouWonForm()
        {
            InitializeComponent();
        }

        private void YouWonForm_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            { Close(); }
        }
    }
}
