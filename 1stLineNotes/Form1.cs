// Created by Dylan Rose
// dylanrose@gmail.com


// WHAT TO ADD NEXT:  
//Undo/Redo functionality.
//Find feature to search for text.
//StatusBar to show line and column number or word count.
//Text formatting like bold, italic, font size, or colors.
//Autosave feature or recovery in case of app crashes.


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
            this.KeyDown += new KeyEventHandler(Form1_KeyDown);
        }

        // Event handler for key presses (to detect Shift + N)
        private void Form1_KeyDown(object sender, KeyEventArgs e)
        {
            // Check if Shift and N are pressed
            if (e.Alt && e.KeyCode == Keys.N)
            {
                // Call the method to append the new call details
                AppendCallDetails();
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
                                 "Merchant Trading Name -\n" +
                                 "Website Info -\n" +
                                 "Query:\n";

            // Append the text into the RichTextBox
            richTextBox.AppendText(callDetails);
        }

        private void newToolStripMenuItem_Click(object sender, EventArgs e)
        {
            richTextBox.Clear();
            this.Text = "Unsaved Notes";  // Set window title to "Untitled"
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

        private void newCallToolStripMenuItem_Click(object sender, EventArgs e)
        {
            AppendCallDetails();
        }
    }
}
