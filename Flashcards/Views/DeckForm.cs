using Flashcards.Controllers;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Xml.Linq;


namespace Flashcards.Views
{
    public partial class DeckForm : Form
    {
        FileController fcontroller = new FileController();
        public DeckForm()
        {
            InitializeComponent();
        }

        private void btnAdd_Click(object sender, EventArgs e)
        {
            var check = fcontroller.canCreateDeck(txtName, dataGridView1);
            if (check)
            {
                var Cards = fcontroller.getCardData(dataGridView1);
                fcontroller.canCreateDeck(Cards, txtName, txtDesc);
                MessageBox.Show("Deck succesfully created", "Message", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }

        private void txtName_KeyPress(object sender, KeyPressEventArgs e)
        {
            e.Handled = (e.KeyChar == (char)Keys.Space);
        }
    }
}
