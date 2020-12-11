using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using System.Xml;

namespace Flashcards.Views
{
    public partial class EditDeck : Form
    {
        public EditDeck()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            using (XmlWriter writer = XmlWriter.Create(textBox1.Text + ".xml"))
            {
                writer.WriteStartElement("Card");
                writer.WriteElementString("Front", "か");
                writer.WriteElementString("Back", "ka");
                writer.WriteEndElement();
                writer.Flush();
            }
        }
    }
}
