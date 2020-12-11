using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Xml.Linq;

namespace Flashcards.Controllers
{
    public class FileController
    {
        public bool canCreateDeck(TextBox txtName, DataGridView dgCards)
        {
            if (txtName.Text != "")
            {
                if (dgCards.RowCount > 1)
                {
                    return true;
                }
                else
                {
                    MessageBox.Show("Atleast 1 card is required to create a deck.", "Message", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    return false;
                }
            }
            else
            {
                MessageBox.Show("A name a required to create a deck.", "Message", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return false;
            }
        }

        public Dictionary<string, string> getCardData(DataGridView dgcards)
        {
            var Cards = new Dictionary<string, string>();
            foreach (DataGridViewRow row in dgcards.Rows)
            {
                if (row.Cells["Key"].Value != null && row.Cells["Value"].Value != null)
                {
                    Cards.Add(row.Cells["Key"].Value.ToString(), row.Cells["Value"].Value.ToString());
                }
            }
            return Cards;
        }

        public void canCreateDeck(Dictionary<string, string> Cards, TextBox txtName, TextBox txtDesc)
        {
            XDocument doc =
                    new XDocument(
                    new XElement("File",
                    new XElement("Name", new XAttribute("filename", txtName.Text)),
                    new XElement("Description", new XAttribute("description", txtDesc.Text)),
                    new XElement("Date", new XAttribute("created", DateTime.Now)),
                        new XElement("Cards",
                            Cards.Select(x => new XElement("Card", new XAttribute("front", x.Key), new XAttribute("back", x.Value)))
                        )
                  )
            );
            doc.Save(txtName.Text + ".xml");
        }

        public void getAllDecks()
        {

        }
    }
}
