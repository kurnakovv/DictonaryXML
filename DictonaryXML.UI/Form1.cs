using DictonaryXML.Domain.Entities;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Xml.Serialization;

namespace DictonaryXML.UI
{
    public partial class Form1 : Form
    {
        private const string _fillFields = "Fill fields!";
        private const string _successfulChange = "Word change was successful!";
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
            EditWord();
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
                EditBtn.Visible = true;
            }
            else if (listView1.SelectedItems.Count == 0)
            {
                ClearInput();
                EditBtn.Visible = false;
            }
            label6.Text = string.Empty;
            label6.BackColor = Color.FromArgb(180, 180, 180);
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

        private void EditWord()
        {
            var msb = MessageBoxButtons.YesNo;
            string message = "Are you sure you want to change the word?";
            string caption = "Edit word";
            if (MessageBox.Show(message, caption, msb) == DialogResult.Yes)
            {
                Word word = new Word(MainWordTextBox.Text,
                                 TranslationWordTextBox.Text,
                                 comboBox1.SelectedIndex,
                                 comboBox2.SelectedIndex,
                                 DescriptionTextBox.Text);

                if (!string.IsNullOrEmpty(MainWordTextBox.Text)
                    && !string.IsNullOrEmpty(TranslationWordTextBox.Text))
                {
                    AddWord(word);
                    RemoveWord();
                    label6.BackColor = Color.Green;
                    label6.Text = _successfulChange;
                }
                else
                {
                    label6.BackColor = Color.Red;
                    label6.Text = _fillFields;
                }
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
        
        private void RemoveWord()
        {
            listView1.Items.RemoveAt(listView1.SelectedIndices[0]);
        }
    }
}
