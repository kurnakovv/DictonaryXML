using DictonaryXML.Domain.Entities;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Xml.Serialization;

namespace DictonaryXML.UI
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
            ClearInput();
        }

        private void AddNewWordBtn_Click(object sender, EventArgs e)
        {
            var form = new AddNewWordForm(this);
            form.ShowDialog();
        }        

        private void EditBtn_Click(object sender, EventArgs e)
        {

        }

        private void listView1_SelectedIndexChanged(object sender, EventArgs e)
        {
            SelectWord();
        }

        internal void AddWord(Word word)
        {
            var listWords = new ListViewItem($"{word.MainWord} - {word.TranslationWord}");
            listWords.Tag = word;

            listView1.Items.Add(listWords);
        }

        private void SelectWord()
        {
            if (listView1.SelectedItems.Count == 1)
            {
                CheckWordForNull();
            }
            else if (listView1.SelectedItems.Count == 0)
            {
                ClearInput();
            }
        }

        private void CheckWordForNull()
        {
            Word word = (Word)listView1.SelectedItems[0].Tag;

            if (word != null)
            {
                MainWordTextBox.Text = word.MainWord;
                TranslationWordTextBox.Text = word.TranslationWord;
                comboBox1.SelectedIndex = word.PartOfSpeech;
                comboBox2.SelectedIndex = word.Gender;
                DescriptionTextBox.Text = word.Description;
            }
        }

        private void ClearInput()
        {
            MainWordTextBox.Text = string.Empty;
            TranslationWordTextBox.Text = string.Empty;
            comboBox1.SelectedIndex = 0;
            comboBox2.SelectedIndex = 0;
            DescriptionTextBox.Text = string.Empty;
        }       
    }
}
