using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace DictonaryXML.UI
{
    public partial class HelpForm : Form
    {
        public HelpForm()
        {
            InitializeComponent();
            TextBox();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            this.Hide();
            this.Show();
            Close();
        }

        private void TextBox()
        {
            textBox1.Text = "Functions:\r\n\r\n 1 Add word\r\n\r\nTo add a new word, click on the 'Add new word' button, you will see a form with input fields: (Main word, Translation word, Part of speech, Gender, Description). Be sure to fill in 1 and 2 fields and press the button 'Add word', after this it will be added to the list.\r\n\r\n2 View word\r\n\r\nIn the list, click on a word, it will be highlighted in blue, and on the right there will be a detailed description of this word.\r\n\r\n3 Change word\r\n\r\nIn the list, click on a word, it will be highlighted in blue, and on the right, change the input fields and click edit button.\r\n\r\n4 Delete word\r\n\r\nIn the list, click on a word, it will be highlighted in blue, and the 'Delete' button will be on the right, click on it and the word will be deleted.\r\n\r\n5 Word search\r\n\r\nTo find a word in the list, you need to write it down the search box, and click the 'Search' button. After this words that has letters from the search field will be highlighted in green. To cancel the highlighting, enter an empty string in the search field and click the 'Search' button.";
        }
    }
}
