using DictonaryXML.Domain;
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
using System.Xml;
using System.Xml.Linq;
using System.Xml.Serialization;

namespace DictonaryXML.UI
{
    public partial class Form1 : Form
    {
        private const string _fillFields = "Fill fields!";
        private const string _successfulChange = "Word change was successful!";
        private const string _successfulDelete = "Word delete was successful!";
        public string _searchText = "All words with the text: ";

        private readonly SerializeDeserializeXML _serializeDeserializeXML = new SerializeDeserializeXML();

        public Form1()
        {
            InitializeComponent();
            DownloadDataFromXML();
        }

        public Form1(SerializeDeserializeXML serializeDeserializeXML)
        {
            _serializeDeserializeXML = serializeDeserializeXML;
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

        private void DeleteBtn_Click(object sender, EventArgs e)
        {
            DeleteWord();
        }

        private void SearchBtn_Click(object sender, EventArgs e)
        {
            SearchWord(SearchTextBox.Text);
        }

        private void listView1_SelectedIndexChanged(object sender, EventArgs e)
        {
            SelectWord();
        }

        private void helpToolStripMenuItem_Click(object sender, EventArgs e)
        {
            var form = new HelpForm();
            form.ShowDialog();
        }

        private void exitToolStripMenuItem_Click(object sender, EventArgs e)
        {
            MessageBoxButtons msb = MessageBoxButtons.YesNo;
            string message = "Are you sure want to exit?";
            string caption = "Exit";
            if (MessageBox.Show(message, caption, msb) == DialogResult.Yes)
                Close();
        }

        internal void AddWord(Word word)
        {
            var listWords = new ListViewItem($"{word.MainWord} - {word.TranslationWord}");
            listWords.Tag = word;

            listView1.Items.Add(listWords);
            SaveDataInXML();
        }

        private void SelectWord()
        {
            if (listView1.SelectedItems.Count == 1)
            {
                CheckWordForNull();
                panel1.Visible = true;
                EditBtn.Visible = true;
                DeleteBtn.Visible = true;
            }
            else if (listView1.SelectedItems.Count == 0)
            {
                ClearInput();
                panel1.Visible = false;
                EditBtn.Visible = false;
                DeleteBtn.Visible = false;
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
                    RemoveWord();
                    AddWord(word);
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

        private void DeleteWord()
        {
            var msb = MessageBoxButtons.YesNo;
            string message = "Are you sure you want to delete the word?";
            string caption = "Delete word";
            if (MessageBox.Show(message, caption, msb) == DialogResult.Yes)
            {
                RemoveWord();
                SaveDataInXML();
                label6.BackColor = Color.Orange;
                label6.Text = _successfulDelete;
            }
        }

        private void ClearInput()
        {
            MainWordTextBox.Text = string.Empty;
            TranslationWordTextBox.Text = string.Empty;
            comboBox1.SelectedIndex = 0;
            comboBox2.SelectedIndex = 0;
            DescriptionTextBox.Text = string.Empty;
            SearchTextBox.Text = string.Empty;
        }

        private void ClearListView()
        {
            listView1.Items.Clear();
        }

        private void RemoveWord()
        {
            listView1.Items.RemoveAt(listView1.SelectedIndices[0]);
        }

        private void SearchWord(string searchWord)
        {
            foreach (ListViewItem listViewItem in listView1.Items)
            {
                if (listViewItem.ToString().Contains(searchWord) 
                    && !string.IsNullOrEmpty(searchWord))
                {
                    listViewItem.BackColor = Color.Green;
                    listViewItem.ForeColor = Color.White;
                    label7.Text = _searchText + 
                                  $"\"{searchWord}\"";
                }
                else if(string.IsNullOrEmpty(searchWord)) 
                {
                    listViewItem.BackColor = Color.Silver;
                    listViewItem.ForeColor = Color.Black;
                    label7.Text = string.Empty;
                }
                else
                {
                    listViewItem.BackColor = Color.Silver;
                    listViewItem.ForeColor = Color.Black;
                }
            }

            ClearInput();
        }

        private void SaveDataInXML()
        {
            var words = new Words();

            foreach (ListViewItem item in listView1.Items)
            {
                if (item.Tag != null)
                {
                    words.WordsList.Add((Word)item.Tag);
                }
            }

            _serializeDeserializeXML.SerializeXML(words);
        }

        private void DownloadDataFromXML()
        {
            ClearInput();
            ClearListView();

            Words words = _serializeDeserializeXML.DeserializeXML();

            foreach (Word word in words.WordsList)
            {
                AddWord(word);
            }
        }       
    }
}
