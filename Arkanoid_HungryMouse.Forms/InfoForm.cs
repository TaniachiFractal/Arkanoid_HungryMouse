﻿using System.Windows.Forms;

namespace Arkanoid_HungryMouse.Forms
{
    /// <summary>
    /// Форма справки об игре
    /// </summary>
    public partial class InfoForm : Form
    {
        /// <summary>
        /// Коструктор формы справки
        /// </summary>
        public InfoForm()
        {
            InitializeComponent();
        }

        private void InfoForm_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            { Close(); }
        }
    }
}
