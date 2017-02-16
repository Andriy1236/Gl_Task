using System;
using System.IO;
using System.Runtime.Serialization;
using System.Windows.Forms;
using Bl.Services;

namespace GL_TEST.Deserializator
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
            _folderBrowserDialog1 = new FolderBrowserDialog();
            openFileDialog1 = new OpenFileDialog() { Filter = "Binary File (*.dat)|*.dat" };
        }
        private readonly FolderBrowserDialog _folderBrowserDialog1;
        private Stream _myStream;

        private void button3_Click(object sender, EventArgs e)
        {
            try
            {
                using (_myStream)
                {
                    if (label1.Text == "")
                    {
                        MessageBox.Show("Please, add file for deserialization");
                        return;
                    }
                    if (label2.Text == "")
                    {
                        MessageBox.Show("Please, add foler for deserialization folder");
                        return;
                    }
                    DeSerializeManager serializeManager = new DeSerializeManager();
                    serializeManager.SaveSerializedFolder(serializeManager.DeSerialize(_myStream), label2.Text);
                    MessageBox.Show("The serialized file was deserialized and added to folder");
                }

            }
            catch (SerializationException ex)
            {
                MessageBox.Show(ex.Message);
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
            finally
            {
                _myStream = null;
                label1.Text = null;
                label2.Text = null;
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            if (openFileDialog1.ShowDialog() == DialogResult.OK)
            {
                try
                {
                    _myStream = openFileDialog1.OpenFile();
                    label1.Text = openFileDialog1.FileName;
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Error: Could not read file from disk. Original error: " + ex.Message);
                }
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            DialogResult dialog = _folderBrowserDialog1.ShowDialog();
            if (dialog == DialogResult.OK)
            {
                label2.Text = _folderBrowserDialog1.SelectedPath;
            }
        }

    }
}
