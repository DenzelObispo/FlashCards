using Flashcards.Controllers;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

namespace Flashcards.Views
{
    public partial class Main : Form
    {
        FileController fcontroller = new FileController();
        public Main()
        {
            InitializeComponent();
        }

        private void btnAdd_Click(object sender, EventArgs e)
        {
            var cd = new DeckForm();
            cd.ShowDialog();
        }

        private void Main_Load(object sender, EventArgs e)
        {
            fcontroller.getAllDecks(lvDecks);
        }
    }
}
