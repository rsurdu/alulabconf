using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.IO;
using log4net;


namespace AluLabConf
{

    public partial class AluLabConfForm : Form
    {

        private static readonly log4net.ILog log = log4net.LogManager.GetLogger(System.Reflection.MethodBase.GetCurrentMethod().DeclaringType);

        public AluLabConfForm()
        {
            InitializeComponent();

            if (!oCheckBoxIntraActivate.Checked)
            {
                oIntraComboNodeB.Visible = false;
                checkBox1.Visible = false;
                oIntraTxtNodeB.Visible = false;
            }

            if (!oCheckBoxInterActivate.Checked)
            {
                oInterComboNodeB.Visible = false;
                oInterComboBandFreq.Visible = false;
                oCheckBoxInterX2.Visible = false;
                oCheckBoxInterS1.Visible = false;
                oInterRadio5.Visible = false;
                oInterRadio10.Visible = false;
                oInterTxtNodeB.Visible = false;
                oInterTxtBandeFreq.Visible = false;
            }

        }

        private void label1_Click(object sender, EventArgs e)
        {
            
            Stream myStream = null;
            OpenFileDialog openFileDialog1 = new OpenFileDialog();


            openFileDialog1.InitialDirectory = @"c:\";
            openFileDialog1.Filter = "xml files (*.xml)|*.xml|All files (*.*)|*.*";
            openFileDialog1.FilterIndex = 2;
            openFileDialog1.RestoreDirectory = true;
            openFileDialog1.Multiselect = false;

            if (openFileDialog1.ShowDialog() == DialogResult.OK)
            {
                try
                {
                                                            
                    if ((myStream = openFileDialog1.OpenFile()) != null)
                    {
                        if (log.IsDebugEnabled)
                        {
                            if (log.IsDebugEnabled) log.Debug(string.Format("Source File  To Update : {0}", openFileDialog1.FileName));
                            //System.Console.WriteLine("Source File  To Update : {0}", openFileDialog1.FileName);
                        }
                        textBox1.Text = openFileDialog1.FileName;
                
                    }
                }
                catch (Exception ex)
                {
                    if (log.IsErrorEnabled) log.Error(string.Format("Error: Could not read file from disk. Original error: " + ex.Message));
                    MessageBox.Show("Error: Could not read file from disk. Original error: " + ex.Message);
                }
            }


        }

        private void ButtonGenerate(object sender, EventArgs e)
        {
            if (log.IsDebugEnabled)
            {
                if (log.IsDebugEnabled) log.Debug("Lancement du parsing du fichier sélectionné");
                //System.Console.WriteLine("Lancement du parsing du fichier sélectionné");
            }

            if (!oInterRadio10.Checked && !oInterRadio5.Checked)
            {

            }
            
            if ((textBox1.Text != string.Empty))
            {
                textBox2.Text = Program.loadSampleFileToPatch(textBox1.Text, oParentComboNodeB.Text, oParentComboFreq.Text);
            }
            else
            {
                if (log.IsErrorEnabled) log.Error("Veuillez sélectionner un fichier XML à modifier");
                MessageBox.Show("Veuillez sélectionner un fichier XML à modifier");
            }
        
        }


        private void click_CheckBoxInterActivate(object sender, EventArgs e)
        {
            if (!oCheckBoxInterActivate.Checked)
            {
                oInterComboNodeB.Visible = false;
                oInterComboBandFreq.Visible = false;
                oCheckBoxInterX2.Visible = false;
                oCheckBoxInterS1.Visible = false;
                oInterRadio5.Visible = false;
                oInterRadio10.Visible = false;
                oInterTxtNodeB.Visible = false;
                oInterTxtBandeFreq.Visible = false;
            }
            else
            {
                oInterComboNodeB.Visible = true;
                oInterComboBandFreq.Visible = true;
                oCheckBoxInterX2.Visible = true;
                oCheckBoxInterS1.Visible = true;
                oInterRadio5.Visible = true;
                oInterRadio10.Visible = true;
                oInterTxtNodeB.Visible = true;
                oInterTxtBandeFreq.Visible = true;
            }
        }


        private void click_CheckBoxIntraActivate(object sender, EventArgs e)
        {

            if (!oCheckBoxIntraActivate.Checked)
            {
                oIntraComboNodeB.Visible = false;
                checkBox1.Visible = false;
                oIntraTxtNodeB.Visible = false;
            }
            else
            {
                oIntraComboNodeB.Visible = true;
                checkBox1.Visible = true;
                oIntraTxtNodeB.Visible = true;
            }
        }


        private void Form1_Load(object sender, EventArgs e)
        {

        }

        private void radioButton2_CheckedChanged(object sender, EventArgs e)
        {

        }

        private void openFileDialog1_FileOk(object sender, CancelEventArgs e)
        {

        }

        private void folderBrowserDialog1_HelpRequest(object sender, EventArgs e)
        {

        }

        private void checkBox1_CheckedChanged(object sender, EventArgs e)
        {

        }

        private void labAluBindingSource_CurrentChanged(object sender, EventArgs e)
        {

        }

       




        private void openFileDialog1_FileOk_1(object sender, CancelEventArgs e)
        {



        }

        private void button1_Click(object sender, EventArgs e)
        {

        }

        private void oParentComboFreq_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void labAluBindingSource_CurrentChanged_1(object sender, EventArgs e)
        {

        }
    
    
    }
}
