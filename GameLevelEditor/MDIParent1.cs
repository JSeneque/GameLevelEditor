using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.IO;

namespace GameLevelEditor
{
    public partial class MDIParent1 : Form
    {
        private int childFormNumber = 0;

        public MDIParent1()
        {
            InitializeComponent();
        }

        private void ShowNewForm(object sender, EventArgs e)
        {
            //Form childForm = new Form();
            //childForm.MdiParent = this;
            //childForm.Text = "Window " + childFormNumber++;
            //childForm.Show();
            Form childForm = new LevelDesigner();
            childForm.MdiParent = this;
            childForm.Text = "Unnamed Level";
            childForm.Show();
        }

        private void OpenFile(object sender, EventArgs e)
        {
            OpenFileDialog openFileDialog = new OpenFileDialog();
            //openFileDialog.InitialDirectory = Environment.GetFolderPath(Environment.SpecialFolder.Personal);
            string directory = Directory.GetCurrentDirectory();
            openFileDialog.InitialDirectory = directory;
            //openFileDialog.Filter = "JNS Files (*.jns)|*.jns|Text Files (*.txt)|*.txt|All Files (*.*)|*.*";
            openFileDialog.Filter = "JNS Files (*.jns)|*.jns";

            //LevelDesigner levelDesigner = this.ActiveMdiChild as LevelDesigner;

            if (openFileDialog.ShowDialog(this) == DialogResult.OK)
            {
                string path = openFileDialog.FileName;
                string filename = openFileDialog.SafeFileName;


                Form childForm = new LevelDesigner();

                
                childForm.MdiParent = this;
                childForm.Text = filename;
                childForm.Show();

                // load file into leveldesigner
                LevelDesigner levelDesigner = this.ActiveMdiChild as LevelDesigner;
                levelDesigner.LoadFromFile(path);

                
            }
        }

        private void SaveAsToolStripMenuItem_Click(object sender, EventArgs e)
        {
            SaveFileDialog saveFileDialog = new SaveFileDialog();
            //saveFileDialog.InitialDirectory = Environment.GetFolderPath(Environment.SpecialFolder.Personal);
            string directory = Directory.GetCurrentDirectory();
            saveFileDialog.InitialDirectory = directory;
            saveFileDialog.Filter = "Text Files (*.txt)|*.txt|All Files (*.*)|*.*";
            
            if (saveFileDialog.ShowDialog(this) == DialogResult.OK)
            {
                string FileName = saveFileDialog.FileName;
                
            }
        }

        private void ExitToolsStripMenuItem_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        //private void CutToolStripMenuItem_Click(object sender, EventArgs e)
        //{
        //}

        //private void CopyToolStripMenuItem_Click(object sender, EventArgs e)
        //{
        //}

        //private void PasteToolStripMenuItem_Click(object sender, EventArgs e)
        //{
        //}

        private void ToolBarToolStripMenuItem_Click(object sender, EventArgs e)
        {
            toolStrip.Visible = toolBarToolStripMenuItem.Checked;
        }

        private void StatusBarToolStripMenuItem_Click(object sender, EventArgs e)
        {
            statusStrip.Visible = statusBarToolStripMenuItem.Checked;
        }

        private void CascadeToolStripMenuItem_Click(object sender, EventArgs e)
        {
            LayoutMdi(MdiLayout.Cascade);
        }

        private void TileVerticalToolStripMenuItem_Click(object sender, EventArgs e)
        {
            LayoutMdi(MdiLayout.TileVertical);
        }

        private void TileHorizontalToolStripMenuItem_Click(object sender, EventArgs e)
        {
            LayoutMdi(MdiLayout.TileHorizontal);
        }

        private void ArrangeIconsToolStripMenuItem_Click(object sender, EventArgs e)
        {
            LayoutMdi(MdiLayout.ArrangeIcons);
        }

        private void CloseAllToolStripMenuItem_Click(object sender, EventArgs e)
        {
            foreach (Form childForm in MdiChildren)
            {
                childForm.Close();
            }
        }

        private void newLevel_Click(object sender, EventArgs e)
        {
            Form childForm = new LevelDesigner();
            childForm.MdiParent = this;
            childForm.Text = "Level " + childFormNumber++;
            childForm.Show();
        }

        private void saveToolStripButton_Click(object sender, EventArgs e)
        {

            if (this.ActiveMdiChild != null)
            {
                if (this.ActiveMdiChild.Text == "Unnamed Level")
                {

                    SaveFileDialog saveFileDialog = new SaveFileDialog();
                    //saveFileDialog.InitialDirectory = Environment.GetFolderPath(Environment.SpecialFolder.Personal);
                    //saveFileDialog.InitialDirectory = Environment.GetFolderPath(Environment.SpecialFolder.Personal);
                    string directory = Directory.GetCurrentDirectory();
                    saveFileDialog.InitialDirectory = directory;
                    saveFileDialog.Filter = "JNS Files (*.jns)|*.jns";

                    if (saveFileDialog.ShowDialog(this) == DialogResult.OK)
                    {
                        string path = saveFileDialog.FileName;
                        FileInfo filename = new FileInfo(saveFileDialog.FileName);

                        LevelDesigner levelDesigner = this.ActiveMdiChild as LevelDesigner;
                        levelDesigner.SaveToFile(path);
                        this.ActiveMdiChild.Text = filename.Name;
                    }
                } else
                {
                    LevelDesigner levelDesigner = this.ActiveMdiChild as LevelDesigner;
                    levelDesigner.SaveToFile(this.ActiveMdiChild.Text);
                }

            }

        }
    }
}
