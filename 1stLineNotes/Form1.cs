// Created by Dylan Rose
// dylanrose@gmail.com


// WHAT TO ADD NEXT:  
//Find feature to search for text.
//StatusBar to show line and column number or word count.
//Text formatting like bold (Added), italic, font size, or colors.
//Autosave feature or recovery in case of app crashes.
// "Relax" button using api to show either a motivational quote or a funny image or joke.


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

namespace _1stLineNotes
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
            // Enable double buffering
            this.DoubleBuffered = true;
            this.SetStyle(ControlStyles.OptimizedDoubleBuffer, true);
            // Set up KeyDown event handler for the form
            this.KeyPreview = true; 
            this.KeyDown += new KeyEventHandler(Form1_KeyDown);
        }

        // Event handler for key presses (to detect Alt + N or Alt + S)
        private void Form1_KeyDown(object sender, KeyEventArgs e)
        {
            // Check if Shift and N are pressed
            if (e.Alt && e.KeyCode == Keys.N)
            {
                // Call the method to append the new call details
                AppendCallDetails();
            }

            // Check if Shift and S are pressed
            else if (e.Alt && e.KeyCode == Keys.S)
            {
                // Call the method to append the new call details
                AppendSalesDetails();
            }

            else if (e.Control && e.KeyCode == Keys.B)
            {
                ToggleBoldText();
            }

        }


        // Method to append the new call details into the RichTextBox
        private void AppendCallDetails()
        {
            // Define the text to append
            string callDetails = " \n" +
                                 " \n" +
                                 "Caller Name -\n" +
                                 "Caller Number -\n" +
                                 "Caller Email -\n" +
                                 "Merchant Trading Name -\n" +
                                 "Website Info -\n" +
                                 "Query:\n";

            // Append the text into the RichTextBox
            richTextBox.AppendText(callDetails);
        }

        // Method to append the new call details into the RichTextBox
        private void AppendSalesDetails()
        {
            // Define the text to append
            string saleDetails = " \n" +
                                 " \n" +
                                 "Caller Name -\n" +
                                 "Caller Number -\n" +
                                 "Caller Email -\n" +
                                 "Region -\n" +
                                 "Merchant/Franchise Trading Name -\n" +
                                 "Website Info -\n" +
                                 "Query:\n";

            // Append the text into the RichTextBox
            richTextBox.AppendText(saleDetails);
        }

        private void ToggleBoldText()
        {
            if (richTextBox.SelectionFont != null)
            {
                Font currentFont = richTextBox.SelectionFont;
                FontStyle newFontStyle = richTextBox.SelectionFont.Bold ? FontStyle.Regular : FontStyle.Bold;
                richTextBox.SelectionFont = new Font(currentFont.FontFamily, currentFont.Size, newFontStyle);
            }
        }


        private void newToolStripMenuItem_Click(object sender, EventArgs e)
        {
            richTextBox.Clear();
            this.Text = "Unsaved - Dont forget to save";  // Set window title to "Untitled"
        }

        private void openToolStripMenuItem_Click(object sender, EventArgs e)
        {
            using (OpenFileDialog openFileDialog = new OpenFileDialog())
            {
                openFileDialog.Filter = "Text Files (*.txt)|*.txt|All Files (*.*)|*.*";
                if (openFileDialog.ShowDialog() == DialogResult.OK)
                {
                    richTextBox.Text = File.ReadAllText(openFileDialog.FileName);
                    this.Text = Path.GetFileName(openFileDialog.FileName) + " - Notepad";
                }
            }
        }

        private void saveToolStripMenuItem_Click(object sender, EventArgs e)
        {
            using (SaveFileDialog saveFileDialog = new SaveFileDialog())
            {
                saveFileDialog.Filter = "Text Files (*.txt)|*.txt|All Files (*.*)|*.*";
                if (saveFileDialog.ShowDialog() == DialogResult.OK)
                {
                    File.WriteAllText(saveFileDialog.FileName, richTextBox.Text);
                    this.Text = Path.GetFileName(saveFileDialog.FileName) + " - Notepad";
                }
            }
        }

        private void cutToolStripMenuItem_Click(object sender, EventArgs e)
        {
            richTextBox.Cut();
        }

        private void copyToolStripMenuItem_Click(object sender, EventArgs e)
        {
            richTextBox.Copy();
        }

        private void pasteToolStripMenuItem_Click(object sender, EventArgs e)
        {
            richTextBox.Paste();
        }

        private void undoToolStripMenuItem_Click(object sender, EventArgs e)
        {
            richTextBox.Undo();
            richTextBox.ClearUndo();
        }

        // New Call Button
        private void newCallToolStripMenuItem_Click(object sender, EventArgs e)
        {
            AppendCallDetails();
        }

        // New Sale Button
        private void newSaleToolStripMenuItem_Click(object sender, EventArgs e)
        {
            AppendSalesDetails();
        }

        // Clear Text Format
        private void clearFormattingToolStripMenuItem_Click(object sender, EventArgs e)
        {
            string richText = richTextBox.SelectedText;
            richTextBox.SelectedText = string.Empty;
            richTextBox.AppendText(richText);
        }

    }
}
