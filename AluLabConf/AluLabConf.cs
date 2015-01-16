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

        private static cUserInput userInput;
        
        public AluLabConfForm()
        {
                       
            InitializeComponent();

            userInput = new cUserInput();
            
            if (!oCheckBoxIntraActivate.Checked)
            {
                oIntraComboNodeB.Visible = false;
                oCheckBoxIntraX2.Visible = false;
                oCheckBoxIntraS1.Visible = false;
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

            if (textBox1.Text == string.Empty)
            {
                if (log.IsErrorEnabled) log.Error("Veuillez sélectionner un fichier XML à modifier");
                MessageBox.Show("Veuillez sélectionner un fichier XML à modifier");
            }
            else if (oCheckBoxInterActivate.Checked && ((int)oParentComboFreq.SelectedValue == (int)oInterComboBandFreq.SelectedValue))
            {
                MessageBox.Show("La Bande de fréquence ne peut pas être identique sur le parent sur l'inter");
            }
            else if (oCheckBoxInterActivate.Checked && (!oInterRadio10.Checked && !oInterRadio5.Checked))
            {
                log.Debug("Mode Inter : Veuillez sélectionner 5Mhz ou 10Mhz");
                MessageBox.Show("Veuillez sélectionner 5Mhz ou 10Mhz");
            }
            else
            {
                /// remplissage de la structure du DataModel avec les données du parent
                userInput.xmlSourceFileName = textBox1.Text;
                userInput.selectedParentNodeB = oParentComboNodeB.SelectedValue.ToString();
                userInput.selectedParentBandeFreq = oParentComboFreq.SelectedValue.ToString();

                /// remplissage de la structure du DataModel avec les données du mode inter
                if (!oCheckBoxInterActivate.Checked)
                {
                    log.Debug("Mode Inter non sélectionné");
                } 
                else
                {
                    log.Debug("Mode Inter sélectionné");

                    userInput.selectedInter.interActivated = true;
                    userInput.selectedInter.selectedInterBandFreq = oInterComboBandFreq.Text;
                    userInput.selectedInter.selectedInterEnodeB = oInterComboNodeB.Text;

                    if (oInterRadio10.Checked)
                    {
                        userInput.selectedInter.shortbandWidth = 10;
                    }
                    else 
                    {
                        userInput.selectedInter.shortbandWidth = 5;
                    }

                    if (oCheckBoxInterS1.Checked)
                    {
                        userInput.selectedInter.bS1 = true;
                    }

                    if (oCheckBoxInterX2.Checked)
                    {
                        userInput.selectedInter.bX2 = true;
                    }
                }

                /// remplissage de la structure du DataModel avec les données du mode intra

                if (!oCheckBoxIntraActivate.Checked)
                {
                    log.Debug("Mode Intra non sélectionné");
                }
                else
                {
                    userInput.selectedIntra.intraActivated= true;
                    userInput.selectedIntra.selectedIntraEnodeB = oIntraComboNodeB.Text;

                    if (oCheckBoxIntraS1.Checked)
                    {
                        userInput.selectedIntra.bS1 = true;
                    }

                    if (oCheckBoxIntraX2.Checked)
                    {
                        userInput.selectedIntra.bX2 = true;
                    }
                }


                //textBox2.Text = Program.loadSampleFileToPatch(textBox1.Text, oParentComboNodeB.Text, oParentComboFreq.Text);
                Program.FctTest(userInput);
            
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
                oCheckBoxIntraX2.Visible = false;
                oCheckBoxIntraS1.Visible = false;
                oIntraTxtNodeB.Visible = false;
            }
            else
            {
                oIntraComboNodeB.Visible = true;
                oCheckBoxIntraX2.Visible = true;
                oCheckBoxIntraS1.Visible = true;
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
            MessageBox.Show("Daube N°1 !!!!!!!!!!!!!!!!!!!!");
        }

        private void oParentComboFreq_SelectedValueChanged(object sender, EventArgs e)
        {
            log.Debug(string.Format("Valeur du oParentComboFreq {0} ", oParentComboFreq.SelectedValue.ToString()));
            log.Debug(string.Format("Valeur du oInterComboBandFreq {0} ", oInterComboBandFreq.SelectedValue.ToString()));

            if (oCheckBoxInterActivate.Checked && ((int)oParentComboFreq.SelectedValue == (int)oInterComboBandFreq.SelectedValue))
            {
                log.Debug(string.Format("oCheckBoxInterActivate.Checked = TRUE", oCheckBoxInterActivate.Checked));
                MessageBox.Show("La Bande de fréquence ne peut pas être identique sur le parent sur l'inter");
            }
            else
            {
                log.Debug(string.Format("oCheckBoxInterActivate.Checked = FALSE"));
            }

        }


        private void labAluBindingSource_CurrentChanged_1(object sender, EventArgs e)
        {

        }

        private void checkBox1_CheckedChanged_1(object sender, EventArgs e)
        {

        }
    
    
    }
}
