using System;
using System.Windows.Forms;
using Bl.Services;

namespace GL_TEST
{
    public partial class Form1 : Form
    {
        private readonly FolderBrowserDialog _folderBrowserDialog1;
    
        public Form1()
        {
            InitializeComponent();
            _folderBrowserDialog1 = new FolderBrowserDialog ();

        }

        private void button1_Click(object sender, EventArgs e)
        {
            DialogResult dialog = _folderBrowserDialog1.ShowDialog();
            if (dialog == DialogResult.OK)
            {
                label1.Text =_folderBrowserDialog1.SelectedPath;
               
            }
        }

        private void button2_Click_1(object sender, EventArgs e)
        {
            DialogResult dialog = _folderBrowserDialog1.ShowDialog();
            if (dialog == DialogResult.OK)
            {
                label2.Text = _folderBrowserDialog1.SelectedPath;
               
            }
        }

        private void Form1_Load(object sender, EventArgs e)
        {

        }

        private void button3_Click(object sender, EventArgs e)
        {
            try
            {
                if (label1.Text == string.Empty)
                {
                    MessageBox.Show("Please, add folder for serialization");
                    return;
                }
                if (label2.Text == string.Empty)
                {
                    MessageBox.Show("Please, add a folder for serialized file");
                    return;
                }
                SerializeManager serializeManager = new SerializeManager();
                var folder = serializeManager.GetFolder(label1.Text);
                serializeManager.SerializeFolder(folder, label2.Text);
                
                MessageBox.Show("The folder was serialized");

            }
            catch (OutOfMemoryException)
            {
                MessageBox.Show("The folder size too big");
            }
            catch (UnauthorizedAccessException ex)
            {
                MessageBox.Show(ex.Message);
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
            finally
            {
                label1.Text = string.Empty;
                label2.Text = string.Empty;
            }

        }
    }
}
