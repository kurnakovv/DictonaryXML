using DictonaryXML.Domain.Entities;
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
    public partial class AddNewWordForm : Form
    {

        private const string _fillFields = "Fill fields!";
        Form1 form1 = new Form1();

        public AddNewWordForm(Form1 f1)
        {
            form1 = f1;
            InitializeComponent();
            ClearInput();
        }

        private void AddBtn_Click(object sender, EventArgs e)
        {
            FillFields();
        }

        private void GoBackBtn_Click(object sender, EventArgs e)
        {
            this.Hide();
            this.Show();
            Close();
        }

        private void ClearInput()
        {
            MainWordTextBox.Text = string.Empty;
            TranslationWordTextBox.Text = string.Empty;
            comboBox1.SelectedIndex = 0;
            comboBox2.SelectedIndex = 0;
            DescriptionTextBox.Text = string.Empty;
        }

        private void FillFields()
        {
            var msb = MessageBoxButtons.YesNo;
            string message = "Вы действительно хотите добавить слово?";
            string caption = "Добавить слово";
            if (MessageBox.Show(message, caption, msb) == DialogResult.Yes)
            {
                Word word = new Word(MainWordTextBox.Text,
                                     TranslationWordTextBox.Text,
                                     comboBox1.SelectedIndex,
                                     comboBox2.SelectedIndex,
                                     DescriptionTextBox.Text);

                if (!string.IsNullOrEmpty(MainWordTextBox.Text)
                    && !string.IsNullOrEmpty(TranslationWordTextBox.Text)
                    && !string.IsNullOrEmpty(comboBox1.Text)
                    && !string.IsNullOrEmpty(DescriptionTextBox.Text))
                {
                    form1.AddWord(word);
                    this.Close();
                }
                else
                {
                    label6.BackColor = Color.Red;
                    label6.Text = _fillFields;
                }
            }
        }
    }
}
