using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace BlackJack
{
    public partial class InitialForm : Form
    {
        public InitialForm()
        {
            InitializeComponent();
            newGameButton.Click += NewGameButton_Click;
        }

        private void NewGameButton_Click(object sender, EventArgs e)
        {
            Hide();
            Form1 gameForm = new Form1();
            gameForm.WindowState = FormWindowState.Maximized;
            gameForm.ShowDialog();
            Close();
        }
    }
}
