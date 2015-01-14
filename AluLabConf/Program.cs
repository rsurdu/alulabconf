using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;

/// Import des bibliotheques pour le streamreader et le parser XML
using System.Xml;
using System.Xml.Linq;
using System.IO;
using System.Text;
using log4net;
using log4net.Config;

namespace AluLabConf
{
    
    /// <summary>
    /// déclaration des classes privées
    /// </summary>
    
    public class BandFreq
    {
        public int BandName {get; set;}
        public int DownloadFreq { get; set; }
        public int UploadFreq { get; set; }
    }

    public class EnodeB
    {
        public long MacroEnb { get; set; }
        public int iDenodeB { get; set; }
        public int pCi1 { get; set; }
        public int pCi2 { get; set; }
        public int pCi3 { get; set; }
        public string iPvlan0 { get; set; }
        public string iPvlan1 { get; set; }
        public string uNiquename { get; set; }
        public string eNodeBname { get; set; }
        public string hOmeEnodeBname { get; set; }
    }

    public class interNeighboring
    {
        private Boolean bX2 { get; set; }
        private Boolean bS1 { get; set; }
        private EnodeB structInterEnodeB { get; set; }
        private BandFreq structInterBandFreq { get; set; }
        private short shortbandWidth { get; set; }
    }

    public class intraNeighboring
    {
        private Boolean bX2 { get; set; }
        private Boolean bS1 { get; set; }
        private EnodeB structInterEnodeB { get; set; }
        private BandFreq structInterBandFreq { get; set; }
        private short shortbandWidth { get; set; }
    }

    public class parentNodeName
    {
        public EnodeB cEnodeB { get; set; }
        public BandFreq cBandFreq { get; set; }

        public parentNodeName ()
        {
            this.cEnodeB = new EnodeB();
            this.cBandFreq = new BandFreq();
        }
    } 

    /// <summary>
    /// déclaration des classes publiques
    /// </summary>
   

    public class LabAlu
    {
        public List<BandFreq> BandFreqDuLab;
        public List<int> iDBandFreqDuLab;
        public List<EnodeB> EnodebDuLab;
        public List<int> iDEnodebDuLab;
        
        public LabAlu ()
        {
            this.BandFreqDuLab = new List<BandFreq>();
            this.iDBandFreqDuLab = new List<int>(0);
            this.EnodebDuLab = new List<EnodeB>();
            this.iDEnodebDuLab = new List<int>(0);
            
        }
    }

    public class cUserInput
    {

        public string xmlSourceFileName { get; set; }
        public parentNodeName selectedParentNodeName { get; set; }

        public cUserInput ()
        {
            this.selectedParentNodeName = new parentNodeName();
            
        }

    }

    static class Program
    {
        /// <summary>
        /// Point d'entrée principal de l'application.
        /// </summary>
        static LabAlu readAluLab = new LabAlu();
        static cUserInput userInput = new cUserInput();
        public static readonly ILog log = LogManager.GetLogger(System.Reflection.MethodBase.GetCurrentMethod().DeclaringType);

        [STAThread]

        static void Main()
        {

            log4net.Config.BasicConfigurator.Configure();
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            AluLabConfForm myform = new AluLabConfForm();

            LoadConf(readAluLab);

            // Ajout des données dans les contrôles oParentComboNodeB
            myform.oParentComboNodeB.DataSource = readAluLab.iDEnodebDuLab;
            myform.oParentComboFreq.DataSource = readAluLab.iDBandFreqDuLab;

            // Ajout des données dans les contrôles oInterComboNodeB
            myform.oInterComboNodeB.DataSource = readAluLab.iDEnodebDuLab;
            myform.oInterComboBandFreq.DataSource = readAluLab.iDBandFreqDuLab;

            // Ajout des données dans les contrôles oIntranComboNodeB
            myform.oIntranComboNodeB.DataSource = readAluLab.iDEnodebDuLab;

            //loadSampleFileToPatch();

            Application.Run(myform);

            System.Console.ReadLine();
                    
        }


        static void LoadConf(LabAlu readAluLab)
        {

            //Déclaration des variables nécessaires à l'exécution du code
            XElement root = XElement.Load(@"C:\romelia\lab_conf.xml");

            IEnumerable<XElement> lInQueryNodeB = from el in root.Elements("ENBEquipment").Elements("eNobeB") select el;

            foreach (XElement el in lInQueryNodeB)
            {

                if (log.IsDebugEnabled)
                {
                    log.Debug(String.Format("eNodeB {0}, macroEnodeB {1}, pci1 {2}, pci2 {3}, pci3 {4}, ipVlan0 {5}, ipVlan1 {6}", (string)el.Element("id"), (string)el.Element("macroEnodeB"), (string)el.Element("pci1"), (string)el.Element("pci2"), (string)el.Element("pci3"), (string)el.Element("ipVlan0"), (string)el.Element("ipVlan1")));
                    //System.Console.WriteLine("eNodeB {0}, macroEnodeB {1}, pci1 {2}, pci2 {3}, pci3 {4}, ipVlan0 {5}, ipVlan1 {6}", (string)el.Element("id"), (string)el.Element("macroEnodeB"), (string)el.Element("pci1"), (string)el.Element("pci2"), (string)el.Element("pci3"), (string)el.Element("ipVlan0"), (string)el.Element("ipVlan1"));
                }

                EnodeB eNodeBlu = new EnodeB();

                eNodeBlu.iDenodeB = (int)el.Element("id");
                eNodeBlu.MacroEnb = (long)el.Element("macroEnodeB");
                eNodeBlu.pCi1 = (int)el.Element("pci1");
                eNodeBlu.pCi2 = (int)el.Element("pci2");
                eNodeBlu.pCi3 = (int)el.Element("pci3");
                eNodeBlu.iPvlan0 = (string)el.Element("ipVlan0");
                eNodeBlu.iPvlan1 = (string)el.Element("ipVlan1");
                
                readAluLab.iDEnodebDuLab.Add((int)el.Element("id"));
                readAluLab.EnodebDuLab.Add(eNodeBlu);

            }

            if (log.IsDebugEnabled)
            {
                //foreach (EnodeB el in readAluLab.EnodebDuLab)
                //{
                //    System.Console.WriteLine("iDenodeB {0}", el.iDenodeB.ToString());
                //    System.Console.WriteLine("MacroEnb {0}", el.MacroEnb.ToString());
                //    System.Console.WriteLine("pCi1 {0}", el.pCi1.ToString());
                //    System.Console.WriteLine("pCi2 {0}", el.pCi2.ToString());
                //    System.Console.WriteLine("pCi3 {0}", el.pCi3.ToString());
                //    System.Console.WriteLine("iPvlan0 {0}", el.iPvlan0);
                //    System.Console.WriteLine("iPvlan1 {0}", el.iPvlan1);
                //}

                log.Debug(String.Format("Ajout de {0} enodeB dans EnodebDuLab", readAluLab.EnodebDuLab.Count()));
                log.Debug(String.Format("Ajout de {0} enodeB dans iDEnodebDuLab", readAluLab.iDEnodebDuLab.Count()));

                //System.Console.WriteLine("Ajout de {0} enodeB dans EnodebDuLab", readAluLab.EnodebDuLab.Count());
                //System.Console.WriteLine("Ajout de {0} enodeB dans iDEnodebDuLab", readAluLab.iDEnodebDuLab.Count());
            }
            
            IEnumerable<XElement> lInQueryFreq = from el in root.Elements("BandSet").Elements("Band") select el;

            foreach (XElement el in lInQueryFreq)
            {

                if (log.IsDebugEnabled)
                {
                    log.Debug(String.Format("id {0}, DownLoadFreq {1}, UpLoadFreq {2}", (string)el.Element("id"), (string)el.Element("DownLoadFreq"), (string)el.Element("UpLoadFreq")));
                    //System.Console.WriteLine("id {0}, DownLoadFreq {1}, UpLoadFreq {2}", (string)el.Element("id"), (string)el.Element("DownLoadFreq"), (string)el.Element("UpLoadFreq"));
                }
                
                BandFreq oBandFreq = new BandFreq();
                oBandFreq.BandName = (int)el.Element("id");
                oBandFreq.DownloadFreq = (int)el.Element("DownLoadFreq");
                oBandFreq.UploadFreq = (int)el.Element("UpLoadFreq");

                readAluLab.iDBandFreqDuLab.Add((int)el.Element("id"));
                readAluLab.BandFreqDuLab.Add(oBandFreq);
            }

            if (log.IsDebugEnabled)
            {

                //foreach (BandFreq el in readAluLab.BandFreqDuLab)
                //{
                //    System.Console.WriteLine("Bandname {0}", el.BandName);
                //    System.Console.WriteLine("DownloadFreq {0}", el.DownloadFreq.ToString());
                //    System.Console.WriteLine("UploadFreq {0}", el.UploadFreq.ToString());
                //}

                log.Debug(String.Format("Ajout de {0} Bandes de fréquence dans BandFreqDuLab", readAluLab.BandFreqDuLab.Count()));
                log.Debug(String.Format("Ajout de {0} Bandes de fréquence dans iDBandFreqDuLab", readAluLab.iDBandFreqDuLab.Count()));

                //System.Console.WriteLine("Ajout de {0} Bandes de fréquence dans BandFreqDuLab", readAluLab.BandFreqDuLab.Count());
                //System.Console.WriteLine("Ajout de {0} Bandes de fréquence dans iDBandFreqDuLab", readAluLab.iDBandFreqDuLab.Count());
            }
        }

        public static String loadSampleFileToPatch(String fileName, String enodebName, String bandFreq)
        {

            if (log.IsDebugEnabled)
            {
                log.Debug(String.Format("loadSampleFileToPatch:Fichier sélecionné {0} ", fileName));
                log.Debug(String.Format("loadSampleFileToPatch:enodebName sélecionné {0} ", enodebName));
                log.Debug(String.Format("loadSampleFileToPatch:bandFreq sélecionné {0} ", bandFreq));

                //System.Console.WriteLine("Début Fonction : loadSampleFileToPatch");
                //System.Console.WriteLine("loadSampleFileToPatch:Fichier sélecionné {0} ", fileName);
                //System.Console.WriteLine("loadSampleFileToPatch:enodebName sélecionné {0} ", enodebName);
                //System.Console.WriteLine("loadSampleFileToPatch:bandFreq sélecionné {0} ", bandFreq);
            }
            xPathToUpdate pathToPatch = new xPathToUpdate();

            userInput.xmlSourceFileName = fileName;
            BandFreq selectedBandeFreq = new BandFreq();

            string FolderName = System.IO.Path.GetDirectoryName(fileName);
            
            //recherche de la bandefreq dans les données du datamodel
            findSelectedBandFreqInLab(bandFreq);
            //recherche du nodeB dans les données du datamodel
            findSelectedEnodeBInLab(enodebName);

            String strUniqueName = "eNB" + userInput.selectedParentNodeName.cEnodeB.iDenodeB.ToString() + "B" + userInput.selectedParentNodeName.cBandFreq.BandName.ToString() + "_10MHz";
            String strNodeBName = "eNB" + userInput.selectedParentNodeName.cEnodeB.iDenodeB.ToString() + "B" + userInput.selectedParentNodeName.cBandFreq.BandName.ToString();

            XmlDocument doc = new XmlDocument();

            doc.Load(@fileName);            
            
            XmlElement root = doc.DocumentElement;

           XmlNamespaceManager ns = new XmlNamespaceManager(doc.NameTable);
           ns.AddNamespace("conf", "http://tail-f.com/ns/config/1.0");
           ns.AddNamespace("enb", "http://alcatel-lucent.com/lte/enb");
           ns.AddNamespace(String.Empty, "http://alcatel-lucent.com/lte/enb");

           readXMLDocWithFieldsToUpdate(root, ns, pathToPatch);

           updateXMLDoc(root, ns, pathToPatch, strUniqueName, strNodeBName);

           string savingFileName = @FolderName + @"\" + strUniqueName + ".xml";

           if (log.IsDebugEnabled)
           {
               log.Debug(string.Format("loadSampleFileToPatch : Ecriture du fichier résultat dans {0}", savingFileName));
               //System.Console.WriteLine("loadSampleFileToPatch : Ecriture du fichier résultat dans {0}", savingFileName);
           }
           
           doc.Save(savingFileName);

           return savingFileName;
        }

        public static void findSelectedBandFreqInLab(String bandFreq)
        {


            int localBandeFreq;

            if (int.TryParse(bandFreq, out localBandeFreq))
            {

                if (log.IsDebugEnabled)
                {
                    log.Debug(string.Format("findSelectedBandFreqInLab : localBandeFreq == {0}", localBandeFreq.ToString()));
                    //System.Console.WriteLine("findSelectedBandFreqInLab : localBandeFreq == {0}", localBandeFreq.ToString());
                }
                
                if (null == readAluLab.BandFreqDuLab.Find(delegate(BandFreq a) { return a.BandName == localBandeFreq; }))
                {
                    log.Error(string.Format("findSelectedBandFreqInLab : La valeur recherchée n'est pas présente dans le fichier de configuration"));
                    //System.Console.WriteLine("findSelectedBandFreqInLab : La valeur recherchée n'est pas présente dans le fichier de configuration");
                }
                else
                {
                    userInput.selectedParentNodeName.cBandFreq = readAluLab.BandFreqDuLab.Find(delegate(BandFreq a) { return a.BandName == localBandeFreq; });
                    if (log.IsDebugEnabled)
                    {
                        log.Debug(string.Format("findSelectedBandFreqInLab : ENFIN !!!!!!!!!!!!!!!!!!!!!!!!"));
                        //System.Console.WriteLine("findSelectedBandFreqInLab : ENFIN !!!!!!!!!!!!!!!!!!!!!!!!");
                    }
                }
            }
            else
            {
                log.Error(string.Format("findSelectedBandFreqInLab : Erreur de conversion string bandFred en Int"));
                //System.Console.WriteLine("findSelectedBandFreqInLab : Erreur de conversion string bandFred en Int");
            }

        }

        public static void findSelectedEnodeBInLab(String enodebName)
        {


            int localEnodebName;

            if (int.TryParse(enodebName, out localEnodebName))
            {

                    if (log.IsDebugEnabled) log.Debug(string.Format("localEnodebName == {0}", localEnodebName.ToString()));
                    //System.Console.WriteLine("localEnodebName == {0}", localEnodebName.ToString());

                if (null == readAluLab.EnodebDuLab.Find(delegate(EnodeB a) { return a.iDenodeB == localEnodebName; }))
                {
                    if (log.IsErrorEnabled) log.Error("findSelectedEnodeBInLab : La valeur recherchée n'est pas présente dans le fichier de configuration");
                    //System.Console.WriteLine("findSelectedEnodeBInLab : La valeur recherchée n'est pas présente dans le fichier de configuration");
                }
                else
                {
                    userInput.selectedParentNodeName.cEnodeB = readAluLab.EnodebDuLab.Find(delegate(EnodeB a) { return a.iDenodeB == localEnodebName; });
                    if (log.IsDebugEnabled)
                    {
                            if (log.IsDebugEnabled) log.Debug("findSelectedEnodeBInLab : ENFIN !!!!!!!!!!!!!!!!!!!!!!!!");
                            //System.Console.WriteLine("findSelectedEnodeBInLab : ENFIN !!!!!!!!!!!!!!!!!!!!!!!!");
                    }
                }
            }
            else
            {
                if (log.IsErrorEnabled) log.Error("Erreur de conversion string bandFred en Int");
                //System.Console.WriteLine("findSelectedEnodeBInLab : Erreur de conversion string bandFred en Int");
            }

        }

        public static void readXMLDocWithFieldsToUpdate(XmlElement xmlDocument, XmlNamespaceManager ns, xPathToUpdate pathToPatch)
        {

            if (log.IsInfoEnabled) log.Info("readXMLDocWithFieldsToUpdate : Début Fonction");

            readXpathValue(xmlDocument, ns, pathToPatch.mPathUniqueName);

            foreach (String xPath in pathToPatch.mEnodebName)
            {
                readXpathValue(xmlDocument, ns, xPath);
            }

            foreach (String xPath in pathToPatch.mPathMacroEnbId)
            {
                readXpathValue(xmlDocument, ns, xPath);
            }

            readXpathValue(xmlDocument, ns, pathToPatch.mPathiPvlan0);
            readXpathValue(xmlDocument, ns, pathToPatch.mPathiPvlan1);

            foreach (String xPath in pathToPatch.mPathPci1)
            {
                readXpathValue(xmlDocument, ns, xPath);
            }

            foreach (String xPath in pathToPatch.mPathPci2)
            {
                readXpathValue(xmlDocument, ns, xPath);
            }

            foreach (String xPath in pathToPatch.mPathPci3)
            {
                readXpathValue(xmlDocument, ns, xPath);
            }

            foreach (String xPath in pathToPatch.mPathDlFqn)
            {
                readXpathValue(xmlDocument, ns, xPath);
            }

            foreach (String xPath in pathToPatch.mPathUlFqn)
            {
                readXpathValue(xmlDocument, ns, xPath);
            }
            
            //INTER FREQ
            readXpathValue(xmlDocument, ns, pathToPatch.mInterFreqPathMeasurementBandwidth);

            //INTER FREQ
            foreach (String xPath in pathToPatch.mInterFreqLteNeighboringFreqConfDl)
            {
                readXpathValue(xmlDocument, ns, xPath);
            }

            //INTER FREQ
            readXpathNode(xmlDocument, ns, pathToPatch.LteNeighboringCellRelationSourcePath);
            
            //INTER FREQ
            readXpathValue(xmlDocument, ns, pathToPatch.mInterFreqDestPathMacroEnodeB);
            
            //INTER FREQ
            readXpathValue(xmlDocument, ns, pathToPatch.mInterLteNeighboringCellRelationPci);

            if (log.IsInfoEnabled) log.Info("readXMLDocWithFieldsToUpdate : FIn Fonction");
        }



        public static void updateXMLDoc(XmlElement xmlDocument, XmlNamespaceManager ns, xPathToUpdate pathToPatch, String strUniqueName, String strNodeBName)
        {

            if (log.IsInfoEnabled) log.Info("updateXMLDoc : Début Fonction");

            updateXpathValue(xmlDocument, ns, pathToPatch.mPathUniqueName, strUniqueName);

            foreach (String xPath in pathToPatch.mEnodebName)
            {
                updateXpathValue(xmlDocument, ns, xPath, strNodeBName);
            }

            foreach (String xPath in pathToPatch.mPathMacroEnbId)
            {
                updateXpathValue(xmlDocument, ns, xPath, userInput.selectedParentNodeName.cEnodeB.MacroEnb.ToString());
            }

            updateXpathValue(xmlDocument, ns, pathToPatch.mPathiPvlan0, userInput.selectedParentNodeName.cEnodeB.iPvlan0);
            updateXpathValue(xmlDocument, ns, pathToPatch.mPathiPvlan1, userInput.selectedParentNodeName.cEnodeB.iPvlan1);

            foreach (String xPath in pathToPatch.mPathPci1)
            {
                updateXpathValue(xmlDocument, ns, xPath, userInput.selectedParentNodeName.cEnodeB.pCi1.ToString());
            }

            foreach (String xPath in pathToPatch.mPathPci2)
            {
                updateXpathValue(xmlDocument, ns, xPath, userInput.selectedParentNodeName.cEnodeB.pCi2.ToString());
            }

            foreach (String xPath in pathToPatch.mPathPci3)
            {
                updateXpathValue(xmlDocument, ns, xPath, userInput.selectedParentNodeName.cEnodeB.pCi3.ToString());
            }

            foreach (String xPath in pathToPatch.mPathDlFqn)
            {
                updateXpathValue(xmlDocument, ns, xPath, userInput.selectedParentNodeName.cBandFreq.DownloadFreq.ToString());
            }

            foreach (String xPath in pathToPatch.mPathUlFqn)
            {
                updateXpathValue(xmlDocument, ns, xPath, userInput.selectedParentNodeName.cBandFreq.UploadFreq.ToString());
            }

            if (log.IsInfoEnabled) log.Info("updateXMLDoc : Fin Fonction");

        }


        public static void readXpathValue(XmlElement xmlDocument, XmlNamespaceManager ns, String pathToRead)
        {



            XmlNode theSelectedNode = xmlDocument.SelectSingleNode(pathToRead, ns);

            if (log.IsDebugEnabled) log.Debug(string.Format(" Xpath TO READ {0} ", pathToRead));
            //System.Console.WriteLine(" Xpath TO READ {0} ", pathToRead);

            if (theSelectedNode != null)
            {
                if (log.IsDebugEnabled) log.Debug(string.Format("Valeur du UniqueName {0} ", theSelectedNode.InnerText));
                //System.Console.WriteLine("Valeur du UniqueName {0} ", theSelectedNode.InnerText);
            }
            else
            {
                if(log.IsDebugEnabled) log.Debug(string.Format("Le Chemin Xpath {0} n'éxiste pas ou le champ est vide ", pathToRead));
                //System.Console.WriteLine("Le Chemin Xpath {0} n'éxiste pas ou le champ est vide ", pathToRead);
            }

        }

        public static void readXpathNode(XmlElement xmlDocument, XmlNamespaceManager ns, String pathToRead)
        {

            XmlNode theSelectedNode = xmlDocument.SelectSingleNode(pathToRead, ns);

            if (log.IsDebugEnabled) log.Debug(string.Format("Xpath NODE TO READ {0} ", pathToRead));
            //System.Console.WriteLine("Xpath NODE TO READ {0} ", pathToRead);

            if (theSelectedNode != null)
            {
                if (log.IsDebugEnabled) log.Debug(string.Format("Valeur du Noeud {0} ", theSelectedNode.InnerXml));
                //System.Console.WriteLine("Valeur du Noeud {0} ", theSelectedNode.InnerXml);
            }
            else
            {
                if (log.IsDebugEnabled) log.Debug(string.Format("Le Chemin Xpath {0} n'éxiste pas ou le noeud est vide ", pathToRead));
                //System.Console.WriteLine("Le Chemin Xpath {0} n'éxiste pas ou le noeud est vide ", pathToRead);
            }
        }

        public static void updateXpathValue(XmlElement xmlDocument, XmlNamespaceManager ns, String pathToPatch, String strToUpdate)
        {

            XmlNode theSelectedNode = xmlDocument.SelectSingleNode(pathToPatch, ns);

            if (log.IsDebugEnabled) log.Debug(string.Format("Update Xpath {0} with value {1} ", pathToPatch, strToUpdate));
            //System.Console.WriteLine("Update Xpath {0} with value {1} ", pathToPatch, strToUpdate);

            if (theSelectedNode != null)
            {
                if (log.IsDebugEnabled) log.Debug(string.Format("Valeur du theSelectedNode avant update {0} ", theSelectedNode.InnerText));
                //System.Console.WriteLine("Valeur du theSelectedNode avant update {0} ", theSelectedNode.InnerText);
                theSelectedNode.InnerText = strToUpdate;
                if (log.IsDebugEnabled) log.Debug(string.Format("Valeur du theSelectedNode après update {0} ", theSelectedNode.InnerText));
                //System.Console.WriteLine("Valeur du theSelectedNode après update {0} ", theSelectedNode.InnerText);
            }

        }




    }


    public class xPathToUpdate
    {  
        /// <summary>
        /// Classe de gestion des chemins xPath à mettre à jour
        /// </summary>
        
        /// PARENT : Déclaration de la Variable de stockage du Unique name
        public string mPathUniqueName { get; set; }

        // PARENT : Déclaration de la Variable de stockage du Unique name
        public List<string> mEnodebName { get; set; }

        // PARENT : Déclaration de la collection de stockage des chemins Xpath du MacroEnbId
        public List<string> mPathMacroEnbId { get; set; }

        // PARENT : Déclaration de la collection de stockage des chemins Xpath pour modifier les IPV4
        public string mPathiPvlan0 { get; set; }
        public string mPathiPvlan1 { get; set; }

        // PARENT : Déclaration de la collection de stockage des chemins Xpath pour modifier le PCI1
        public List<string> mPathPci1 { get; set; }

        // PARENT : Déclaration de la collection de stockage des chemins Xpath pour modifier le PCI2
        public List<string> mPathPci2 { get; set; }

        // PARENT : Déclaration de la collection de stockage des chemins Xpath pour modifier le PCI3
        public List<string> mPathPci3 { get; set; }

        // PARENT : Déclaration de la collection de stockage des chemins Xpath pour modifier les Frequances de DL
        public List<string> mPathDlFqn { get; set; }

        // PARENT : Déclaration de la collection de stockage des chemins Xpath pour modifier les Frequances de UL
        public List<string> mPathUlFqn { get; set; }

        // INTER FREQ : Déclaration de la Variable de stockage du Unique name
        public string mInterFreqPathMeasurementBandwidth { get; set; }

        // INTER FREQ : Déclaration de la collection de stockage des chemins Xpath pour modifier les Frequances de UL
        public List<string> mInterFreqLteNeighboringFreqConfDl { get; set; }
        
        // INTER FREQ : XPatxh Node source to copy
        public String LteNeighboringCellRelationSourcePath { get; set; }
        // INTER FREQ : XPatxh Node dest where to copy
        public String LteNeighboringCellRelationDestPath { get; set; }

        // INTER FREQ : MacroEnodeB
        public String mInterFreqDestPathMacroEnodeB { get; set; }

        // INTER FREQ : Pci
        public String mInterLteNeighboringCellRelationPci { get; set; }


        public xPathToUpdate()
        {
            // PARENT PATH
            this.mPathUniqueName = "//conf:config/enb:ENBEquipment/enb:attributes/enb:uniqueName";

            this.mEnodebName = new List<String>();
            this.mEnodebName.Add("//conf:config/enb:ENBEquipment/enb:Enb/enb:attributes/enb:eNBname");
            this.mEnodebName.Add("//conf:config/enb:ENBEquipment/enb:Enb/enb:attributes/enb:homeEnbName");

            this.mPathMacroEnbId = new List<String>();
            this.mPathMacroEnbId.Add("//conf:config/enb:ENBEquipment/enb:Enb/enb:attributes/enb:macroEnbId");
            this.mPathMacroEnbId.Add("//conf:config/enb:ENBEquipment/enb:Enb[enb:rdnId='0']/enb:LteCell[enb:uniqueName='0']/enb:LteNeighboring[enb:rdnId='0']/enb:LteNeighboringFreqConf[enb:rdnId='0']/enb:LteNeighboringCellRelation[enb:uniqueName='1']/enb:attributes/enb:macroEnbId");
            this.mPathMacroEnbId.Add("//conf:config/enb:ENBEquipment/enb:Enb[enb:rdnId='0']/enb:LteCell[enb:uniqueName='0']/enb:LteNeighboring[enb:rdnId='0']/enb:LteNeighboringFreqConf[enb:rdnId='0']/enb:LteNeighboringCellRelation[enb:uniqueName='2']/enb:attributes/enb:macroEnbId");
            this.mPathMacroEnbId.Add("//conf:config/enb:ENBEquipment/enb:Enb[enb:rdnId='0']/enb:LteCell[enb:uniqueName='1']/enb:LteNeighboring[enb:rdnId='0']/enb:LteNeighboringFreqConf[enb:rdnId='0']/enb:LteNeighboringCellRelation[enb:uniqueName='0']/enb:attributes/enb:macroEnbId");
            this.mPathMacroEnbId.Add("//conf:config/enb:ENBEquipment/enb:Enb[enb:rdnId='0']/enb:LteCell[enb:uniqueName='1']/enb:LteNeighboring[enb:rdnId='0']/enb:LteNeighboringFreqConf[enb:rdnId='0']/enb:LteNeighboringCellRelation[enb:uniqueName='2']/enb:attributes/enb:macroEnbId");
            this.mPathMacroEnbId.Add("//conf:config/enb:ENBEquipment/enb:Enb[enb:rdnId='0']/enb:LteCell[enb:uniqueName='2']/enb:LteNeighboring[enb:rdnId='0']/enb:LteNeighboringFreqConf[enb:rdnId='0']/enb:LteNeighboringCellRelation[enb:uniqueName='0']/enb:attributes/enb:macroEnbId");
            this.mPathMacroEnbId.Add("//conf:config/enb:ENBEquipment/enb:Enb[enb:rdnId='0']/enb:LteCell[enb:uniqueName='2']/enb:LteNeighboring[enb:rdnId='0']/enb:LteNeighboringFreqConf[enb:rdnId='0']/enb:LteNeighboringCellRelation[enb:uniqueName='1']/enb:attributes/enb:macroEnbId");


            this.mPathiPvlan0 = "//conf:config/enb:ENBEquipment/enb:Enb[enb:rdnId='0']/enb:EnbTransportConf[enb:rdnId='0']/enb:RanBackhaul[enb:rdnId='0']/enb:Vlan[enb:rdnId='0']/enb:TrafficDescriptor[enb:rdnId='0']/enb:attributes/enb:ipv4Address";
            this.mPathiPvlan1 = "//conf:config/enb:ENBEquipment/enb:Enb[enb:rdnId='0']/enb:EnbTransportConf[enb:rdnId='0']/enb:RanBackhaul[enb:rdnId='0']/enb:Vlan[enb:rdnId='1']/enb:TrafficDescriptor[enb:rdnId='0']/enb:attributes/enb:ipv4Address";

            this.mPathPci1 = new List<String>();
            this.mPathPci1.Add("//conf:config/enb:ENBEquipment/enb:Enb[enb:rdnId='0']/enb:LteCell[enb:uniqueName='0']/enb:attributes/enb:pci");
            this.mPathPci1.Add("//conf:config/enb:ENBEquipment/enb:Enb[enb:rdnId='0']/enb:LteCell[enb:uniqueName='1']/enb:LteNeighboring[enb:rdnId='0']/enb:LteNeighboringFreqConf[enb:rdnId='0']/enb:LteNeighboringCellRelation[enb:uniqueName='0']/enb:attributes/enb:pci");
            this.mPathPci1.Add("//conf:config/enb:ENBEquipment/enb:Enb[enb:rdnId='0']/enb:LteCell[enb:uniqueName='2']/enb:LteNeighboring[enb:rdnId='0']/enb:LteNeighboringFreqConf[enb:rdnId='0']/enb:LteNeighboringCellRelation[enb:uniqueName='0']/enb:attributes/enb:pci");

            this.mPathPci2 = new List<String>();
            this.mPathPci2.Add("//conf:config/enb:ENBEquipment/enb:Enb[enb:rdnId='0']/enb:LteCell[enb:uniqueName='1']/enb:attributes/enb:pci");
            this.mPathPci2.Add("//conf:config/enb:ENBEquipment/enb:Enb[enb:rdnId='0']/enb:LteCell[enb:uniqueName='0']/enb:LteNeighboring[enb:rdnId='0']/enb:LteNeighboringFreqConf[enb:rdnId='0']/enb:LteNeighboringCellRelation[enb:uniqueName='1']/enb:attributes/enb:pci");
            this.mPathPci2.Add("//conf:config/enb:ENBEquipment/enb:Enb[enb:rdnId='0']/enb:LteCell[enb:uniqueName='2']/enb:LteNeighboring[enb:rdnId='0']/enb:LteNeighboringFreqConf[enb:rdnId='0']/enb:LteNeighboringCellRelation[enb:uniqueName='1']/enb:attributes/enb:pci");
            
            this.mPathPci3 = new List<String>();
            this.mPathPci3.Add("//conf:config/enb:ENBEquipment/enb:Enb[enb:rdnId='0']/enb:LteCell[enb:uniqueName='2']/enb:attributes/enb:pci");
            this.mPathPci3.Add("//conf:config/enb:ENBEquipment/enb:Enb[enb:rdnId='0']/enb:LteCell[enb:uniqueName='0']/enb:LteNeighboring[enb:rdnId='0']/enb:LteNeighboringFreqConf[enb:rdnId='0']/enb:LteNeighboringCellRelation[enb:uniqueName='2']/enb:attributes/enb:pci");
            this.mPathPci3.Add("//conf:config/enb:ENBEquipment/enb:Enb[enb:rdnId='0']/enb:LteCell[enb:uniqueName='1']/enb:LteNeighboring[enb:rdnId='0']/enb:LteNeighboringFreqConf[enb:rdnId='0']/enb:LteNeighboringCellRelation[enb:uniqueName='2']/enb:attributes/enb:pci");

            this.mPathDlFqn = new List<String>();
            this.mPathDlFqn.Add("//conf:config/enb:ENBEquipment/enb:Enb[enb:rdnId='0']/enb:LteCell[enb:uniqueName='0']/enb:FrequencyAndBandwidthFDD[enb:rdnId='0']/enb:attributes/enb:dlEARFCN");
            this.mPathDlFqn.Add("//conf:config/enb:ENBEquipment/enb:Enb[enb:rdnId='0']/enb:LteCell[enb:uniqueName='1']/enb:FrequencyAndBandwidthFDD[enb:rdnId='0']/enb:attributes/enb:dlEARFCN");
            this.mPathDlFqn.Add("//conf:config/enb:ENBEquipment/enb:Enb[enb:rdnId='0']/enb:LteCell[enb:uniqueName='2']/enb:FrequencyAndBandwidthFDD[enb:rdnId='0']/enb:attributes/enb:dlEARFCN");

            this.mPathDlFqn.Add("//conf:config/enb:ENBEquipment/enb:Enb[enb:rdnId='0']/enb:LteCell[enb:uniqueName='0']/enb:RrcMeasurementConf[enb:rdnId='0']/enb:MeasObject[enb:rdnId='0']/enb:MeasObjectEUTRA[enb:rdnId='0']/enb:attributes/enb:dlEARFCN");
            this.mPathDlFqn.Add("//conf:config/enb:ENBEquipment/enb:Enb[enb:rdnId='0']/enb:LteCell[enb:uniqueName='1']/enb:RrcMeasurementConf[enb:rdnId='0']/enb:MeasObject[enb:rdnId='0']/enb:MeasObjectEUTRA[enb:rdnId='0']/enb:attributes/enb:dlEARFCN");
            this.mPathDlFqn.Add("//conf:config/enb:ENBEquipment/enb:Enb[enb:rdnId='0']/enb:LteCell[enb:uniqueName='2']/enb:RrcMeasurementConf[enb:rdnId='0']/enb:MeasObject[enb:rdnId='0']/enb:MeasObjectEUTRA[enb:rdnId='0']/enb:attributes/enb:dlEARFCN");

            this.mPathDlFqn.Add("//conf:config/enb:ENBEquipment/enb:Enb[enb:rdnId='0']/enb:LteCell[enb:uniqueName='0']/enb:LteNeighboring[enb:rdnId='0']/enb:LteNeighboringFreqConf[enb:rdnId='0']/enb:attributes/enb:dlEARFCN");
            this.mPathDlFqn.Add("//conf:config/enb:ENBEquipment/enb:Enb[enb:rdnId='0']/enb:LteCell[enb:uniqueName='1']/enb:LteNeighboring[enb:rdnId='0']/enb:LteNeighboringFreqConf[enb:rdnId='0']/enb:attributes/enb:dlEARFCN");
            this.mPathDlFqn.Add("//conf:config/enb:ENBEquipment/enb:Enb[enb:rdnId='0']/enb:LteCell[enb:uniqueName='2']/enb:LteNeighboring[enb:rdnId='0']/enb:LteNeighboringFreqConf[enb:rdnId='0']/enb:attributes/enb:dlEARFCN");

            this.mPathUlFqn = new List<String>();
            this.mPathUlFqn.Add("//conf:config/enb:ENBEquipment/enb:Enb[enb:rdnId='0']/enb:LteCell[enb:uniqueName='0']/enb:FrequencyAndBandwidthFDD[enb:rdnId='0']/enb:attributes/enb:ulEARFCN");
            this.mPathUlFqn.Add("//conf:config/enb:ENBEquipment/enb:Enb[enb:rdnId='0']/enb:LteCell[enb:uniqueName='1']/enb:FrequencyAndBandwidthFDD[enb:rdnId='0']/enb:attributes/enb:ulEARFCN");
            this.mPathUlFqn.Add("//conf:config/enb:ENBEquipment/enb:Enb[enb:rdnId='0']/enb:LteCell[enb:uniqueName='2']/enb:FrequencyAndBandwidthFDD[enb:rdnId='0']/enb:attributes/enb:ulEARFCN");

            // INTER PATH
            this.mInterFreqPathMeasurementBandwidth = "//conf:config/enb:ENBEquipment/enb:Enb[enb:rdnId='0']/enb:LteCell[enb:uniqueName='1']/enb:LteNeighboring[enb:rdnId='0']/enb:LteNeighboringFreqConf[enb:rdnId='1']/enb:attributes/enb:measurementBandwidth";
            
            // INTER PATH
            this.mInterFreqLteNeighboringFreqConfDl = new List<String>();
            this.mInterFreqLteNeighboringFreqConfDl.Add("//conf:config/enb:ENBEquipment/enb:Enb[enb:rdnId='0']/enb:LteCell[enb:uniqueName='1']/enb:LteNeighboring[enb:rdnId='0']/enb:LteNeighboringFreqConf[enb:rdnId='1']/enb:attributes/enb:dlEARFCN");
            this.mInterFreqLteNeighboringFreqConfDl.Add("//conf:config/enb:ENBEquipment/enb:Enb[enb:rdnId='0']/enb:LteCell[enb:uniqueName='0']/enb:RrcMeasurementConf[enb:rdnId='0']/enb:MeasObject[enb:rdnId='0']/enb:MeasObjectEUTRA[enb:rdnId='0']/enb:attributes/enb:dlEARFCN");

            // INTER PATH
            this.LteNeighboringCellRelationSourcePath = "//conf:config/enb:ENBEquipment/enb:Enb[enb:rdnId='0']/enb:LteCell[enb:uniqueName='1']/enb:LteNeighboring[enb:rdnId='0']/enb:LteNeighboringFreqConf[enb:rdnId='0']/enb:LteNeighboringCellRelation[enb:uniqueName='2']";
            this.LteNeighboringCellRelationDestPath = "//conf:config/enb:ENBEquipment/enb:Enb[enb:rdnId='0']/enb:LteCell[enb:uniqueName='1']/enb:LteNeighboring[enb:rdnId='0']/enb:LteNeighboringFreqConf[enb:rdnId='1']/enb:LteNeighboringCellRelation[enb:uniqueName='2']";

            // INTER PATH
            this.mInterFreqDestPathMacroEnodeB = "//conf:config/enb:ENBEquipment/enb:Enb[enb:rdnId='0']/enb:LteCell[enb:uniqueName='1']/enb:LteNeighboring[enb:rdnId='0']/enb:LteNeighboringFreqConf[enb:rdnId='1']/enb:LteNeighboringCellRelation[enb:uniqueName='2']/enb:attributes/enb:macroEnbId";

            // INTER PATH
            this.mInterLteNeighboringCellRelationPci = "//conf:config/enb:ENBEquipment/enb:Enb[enb:rdnId='0']/enb:LteCell[enb:uniqueName='1']/enb:LteNeighboring[enb:rdnId='0']/enb:LteNeighboringFreqConf[enb:rdnId='1']/enb:LteNeighboringCellRelation[enb:uniqueName='2']/enb:attributes/enb:pci";


        }


    }
    
}
