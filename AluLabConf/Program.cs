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
 
    static class Program
    {
        /// <summary>
        /// Point d'entrée principal de l'application.
        /// </summary>
        static LabAlu readAluLab = new LabAlu();
        public static cUserInput userInput = new cUserInput();
        public static readonly ConfigData Conf = new ConfigData();
        public static readonly ILog log = LogManager.GetLogger(System.Reflection.MethodBase.GetCurrentMethod().DeclaringType);
        

        [STAThread]

        static void Main()
        {

            if (log.IsInfoEnabled) log.Info("Main : Début Fonction");

            XmlConfigurator.Configure(new System.IO.FileInfo(@Conf.loggerCfgFile));

            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            AluLabConfForm myform = new AluLabConfForm();

            LoadConf(readAluLab);

            // Ajout des données dans les contrôles oParentComboNodeB
            myform.oParentComboNodeB.BindingContext = new BindingContext();
            myform.oParentComboNodeB.DataSource = readAluLab.iDEnodebDuLab;
            myform.oParentComboFreq.BindingContext = new BindingContext(); 
            myform.oParentComboFreq.DataSource = readAluLab.iDBandFreqDuLab;

            // Ajout des données dans les contrôles oInterComboNodeB
            myform.oInterComboNodeB.BindingContext = new BindingContext();
            myform.oInterComboNodeB.DataSource = readAluLab.iDEnodebDuLab;
            myform.oInterComboBandFreq.BindingContext = new BindingContext();
            myform.oInterComboBandFreq.DataSource = readAluLab.iDBandFreqDuLab;

            // Ajout des données dans les contrôles oIntraComboNodeB
            myform.oIntraComboNodeB.BindingContext = new BindingContext();
            myform.oIntraComboNodeB.DataSource = readAluLab.iDEnodebDuLab;

            //loadSampleFileToPatch();

            Application.Run(myform);

            System.Console.ReadLine();
            if (log.IsInfoEnabled) log.Info("Main : Fin Fonction");        
        }


        static void LoadConf(LabAlu readAluLab)
        {
            if (log.IsInfoEnabled) log.Info("LoadConf : Début Fonction");

            //Déclaration des variables nécessaires à l'exécution du code
            String startUpFolder = Application.StartupPath.ToString() + @"\lab_conf.xml";

            log.Debug(@startUpFolder);

            XElement root = XElement.Load(@Conf.labAluCfgFile);

            IEnumerable<XElement> lInQueryNodeB = from el in root.Elements("ENBEquipment").Elements("eNobeB") select el;

            foreach (XElement el in lInQueryNodeB)
            {

                if (log.IsDebugEnabled) log.Debug(String.Format("eNodeB {0}, macroEnodeB {1}, pci1 {2}, pci2 {3}, pci3 {4}, ipVlan0 {5}, ipVlan1 {6}", (string)el.Element("id"), (string)el.Element("macroEnodeB"), (string)el.Element("pci1"), (string)el.Element("pci2"), (string)el.Element("pci3"), (string)el.Element("ipVlan0"), (string)el.Element("ipVlan1")));

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
                foreach (EnodeB el in readAluLab.EnodebDuLab)
                {
                    log.Debug(string.Format("iDenodeB {0}", el.iDenodeB.ToString()));
                    log.Debug(string.Format("MacroEnb {0}", el.MacroEnb.ToString()));
                    log.Debug(string.Format("pCi1 {0}", el.pCi1.ToString()));
                    log.Debug(string.Format("pCi2 {0}", el.pCi2.ToString()));
                    log.Debug(string.Format("pCi3 {0}", el.pCi3.ToString()));
                    log.Debug(string.Format("iPvlan0 {0}", el.iPvlan0));
                    log.Debug(string.Format("iPvlan1 {0}", el.iPvlan1));
                }

                log.Debug(String.Format("Ajout de {0} enodeB dans EnodebDuLab", readAluLab.EnodebDuLab.Count()));
                log.Debug(String.Format("Ajout de {0} enodeB dans iDEnodebDuLab", readAluLab.iDEnodebDuLab.Count()));

            }
            
            IEnumerable<XElement> lInQueryFreq = from el in root.Elements("BandSet").Elements("Band") select el;

            foreach (XElement el in lInQueryFreq)
            {

                if (log.IsDebugEnabled) log.Debug(String.Format("id {0}, DownLoadFreq {1}, UpLoadFreq {2}", (string)el.Element("id"), (string)el.Element("DownLoadFreq"), (string)el.Element("UpLoadFreq")));

                BandFreq oBandFreq = new BandFreq();
                oBandFreq.BandName = (int)el.Element("id");
                oBandFreq.DownloadFreq = (int)el.Element("DownLoadFreq");
                oBandFreq.UploadFreq = (int)el.Element("UpLoadFreq");

                readAluLab.iDBandFreqDuLab.Add((int)el.Element("id"));
                readAluLab.BandFreqDuLab.Add(oBandFreq);
            }

            if (log.IsDebugEnabled)
            {

                foreach (BandFreq el in readAluLab.BandFreqDuLab)
                {
                    log.Debug(String.Format("Bandname {0}", el.BandName));
                    log.Debug(String.Format("DownloadFreq {0}", el.DownloadFreq.ToString()));
                    log.Debug(String.Format("UploadFreq {0}", el.UploadFreq.ToString()));
                }

                log.Debug(String.Format("Ajout de {0} Bandes de fréquence dans BandFreqDuLab", readAluLab.BandFreqDuLab.Count()));
                log.Debug(String.Format("Ajout de {0} Bandes de fréquence dans iDBandFreqDuLab", readAluLab.iDBandFreqDuLab.Count()));
            }

            if (log.IsInfoEnabled) log.Info("LoadConf : Fin Fonction");

        }

        public static void FctTest(cUserInput UserInputContext)
        {
            if (log.IsInfoEnabled) log.Info("FctTest : Début Fonction !!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!");

            userInput = UserInputContext;

            log.Debug(String.Format("userInput.xmlSourceFileName {0}", userInput.xmlSourceFileName));
            log.Debug(String.Format("userInput.selectedParentNodeB {0}", userInput.selectedParentNodeB));
            log.Debug(String.Format("userInput.selectedParentBandeFreq {0}", userInput.selectedParentBandeFreq));
            log.Debug(String.Format("userInput.selectedIntra.intraActivated {0} ", userInput.selectedIntra.intraActivated.ToString()));
            log.Debug(String.Format("userInput.selectedInter.interActivated {0} ", userInput.selectedInter.interActivated.ToString()));
            log.Debug(String.Format("userInput.selectedInter.structInterEnodeB {0} ", userInput.selectedInter.selectedInterEnodeB));
            log.Debug(String.Format("userInput.selectedInter.structInterEnodeB {0} ", userInput.selectedInter.selectedInterBandFreq));

            log.Debug(String.Format("Contenu de l'Objet enodeB sélectionné par le client"));
            log.Debug(String.Format("userInput.selectedInter.structInterEnodeB {0} ", userInput.selectedInter.structInterEnodeB.iDenodeB.ToString()));
            log.Debug(String.Format("userInput.selectedInter.structInterEnodeB {0} ", userInput.selectedInter.structInterEnodeB.iPvlan0));
            log.Debug(String.Format("userInput.selectedInter.structInterEnodeB {0} ", userInput.selectedInter.structInterEnodeB.iPvlan1));
            log.Debug(String.Format("userInput.selectedInter.structInterEnodeB {0} ", userInput.selectedInter.structInterEnodeB.MacroEnb.ToString()));
            log.Debug(String.Format("userInput.selectedInter.structInterEnodeB {0} ", userInput.selectedInter.structInterEnodeB.pCi1.ToString()));
            log.Debug(String.Format("userInput.selectedInter.structInterEnodeB {0} ", userInput.selectedInter.structInterEnodeB.pCi2.ToString()));
            log.Debug(String.Format("userInput.selectedInter.structInterEnodeB {0} ", userInput.selectedInter.structInterEnodeB.pCi3.ToString()));

            log.Debug(String.Format("Contenu de l'Objet BandeFreq sélectionné par le client"));
            log.Debug(String.Format("userInput.selectedInter.structInterBandFreq.BandName {0} ", userInput.selectedInter.structInterBandFreq.BandName.ToString()));
            log.Debug(String.Format("userInput.selectedInter.structInterEnodeB {0} ", userInput.selectedInter.structInterBandFreq.DownloadFreq.ToString()));
            log.Debug(String.Format("userInput.selectedInter.structInterEnodeB {0} ", userInput.selectedInter.structInterBandFreq.UploadFreq.ToString()));

        
        }


        //public static String loadSampleFileToPatch(String fileName, String enodebName, String bandFreq)
        public static String loadSampleFileToPatch(cUserInput UserInputContext)
        {
            if (log.IsInfoEnabled) log.Info("loadSampleFileToPatch : Début Fonction");

            userInput = UserInputContext;

            if (log.IsDebugEnabled)
            {
                log.Debug(String.Format("loadSampleFileToPatch:Fichier sélecionné {0} ", userInput.xmlSourceFileName));
                log.Debug(String.Format("loadSampleFileToPatch:enodebName sélecionné {0} ", userInput.selectedParentNodeB));
                log.Debug(String.Format("loadSampleFileToPatch:bandFreq sélecionné {0} ", userInput.selectedParentBandeFreq));

            }

            xPathToUpdate pathToPatch = new xPathToUpdate();
            xPathToUpdateInter pathToPatchInter = new xPathToUpdateInter();
            xPathToUpdateIntra pathToPatchIntra = new xPathToUpdateIntra();

            string FolderName = System.IO.Path.GetDirectoryName(userInput.xmlSourceFileName);

            String strUniqueName = "eNB" + userInput.selectedParentNodeName.cEnodeB.iDenodeB.ToString() + "B" + userInput.selectedParentNodeName.cBandFreq.BandName.ToString() + "_10MHz";
            String strNodeBName = "eNB" + userInput.selectedParentNodeName.cEnodeB.iDenodeB.ToString() + "B" + userInput.selectedParentNodeName.cBandFreq.BandName.ToString();

            XmlDocument doc = new XmlDocument();

            doc.Load(@userInput.xmlSourceFileName);                        
            XmlElement root = doc.DocumentElement;

           XmlNamespaceManager ns = new XmlNamespaceManager(doc.NameTable);
           ns.AddNamespace("conf", "http://tail-f.com/ns/config/1.0");
           ns.AddNamespace("enb", "http://alcatel-lucent.com/lte/enb");
           ns.AddNamespace(String.Empty, "http://alcatel-lucent.com/lte/enb");

            //Lecture des valeurs à modifier au niveau du parent
           readXMLDocWithFieldsToUpdate(root, ns, pathToPatch);
           // Update du document XML pour le parent
           updateXMLDoc(root, ns, pathToPatch, strUniqueName, strNodeBName);


            // Lecture des valeurs à modifier au niveau de l'inter
           readXMLDocWithInterFieldsToUpdate(root, ns, pathToPatchInter);
           // Update du document XML pour l'inter
           updateXMLDocInterFreq(root, ns, pathToPatchInter);

            //lecture des valeurs à modifier au niveau de l'intra
           readXMLDocWithIntraFieldsToUpdate(root, ns, pathToPatchIntra);
           // Update du document XML pour l'intra
           updateXMLDocIntraFreq(root, ns, pathToPatchIntra);

            string savingFileName = @FolderName + @"\" + strUniqueName + ".xml";

           if (log.IsDebugEnabled) log.Debug(string.Format("loadSampleFileToPatch : Ecriture du fichier résultat dans {0}", savingFileName));
           
           doc.Save(savingFileName);

           if (log.IsInfoEnabled) log.Info("loadSampleFileToPatch : Fin Fonction");

           return savingFileName;
        }

        public static void findSelectedBandFreqInLab(String bandFreq)
        {

            int localBandeFreq;

            if (int.TryParse(bandFreq, out localBandeFreq))
            {

                if (log.IsDebugEnabled) log.Debug(string.Format("findSelectedBandFreqInLab : localBandeFreq == {0}", localBandeFreq.ToString()));

                
                if (null == readAluLab.BandFreqDuLab.Find(delegate(BandFreq a) { return a.BandName == localBandeFreq; }))
                {
                    if (log.IsErrorEnabled) log.Error(string.Format("findSelectedBandFreqInLab : La valeur recherchée n'est pas présente dans le fichier de configuration"));

                }
                else
                {
                    userInput.selectedParentNodeName.cBandFreq = readAluLab.BandFreqDuLab.Find(delegate(BandFreq a) { return a.BandName == localBandeFreq; });

                    if (log.IsDebugEnabled) log.Debug(string.Format("findSelectedBandFreqInLab : ENFIN !!!!!!!!!!!!!!!!!!!!!!!!"));
                }
            }
            else
            {
                if (log.IsErrorEnabled) log.Error(string.Format("findSelectedBandFreqInLab : Erreur de conversion string bandFreq en Int"));
            }

        }

        public static BandFreq newFindSelectedBandFreqInLab(String bandFreq)
        {

            int localBandeFreq;
            BandFreq objBandeFreq = new BandFreq();

            if (int.TryParse(bandFreq, out localBandeFreq))
            {

                if (log.IsDebugEnabled) log.Debug(string.Format("findSelectedBandFreqInLab : localBandeFreq == {0}", localBandeFreq.ToString()));


                if (null == readAluLab.BandFreqDuLab.Find(delegate(BandFreq a) { return a.BandName == localBandeFreq; }))
                {
                    if (log.IsErrorEnabled) log.Error(string.Format("findSelectedBandFreqInLab : La valeur recherchée n'est pas présente dans le fichier de configuration"));

                }
                else
                {
                    if (log.IsDebugEnabled) log.Debug(string.Format("findSelectedBandFreqInLab : ENFIN !!!!!!!!!!!!!!!!!!!!!!!!"));

                    objBandeFreq = readAluLab.BandFreqDuLab.Find(delegate(BandFreq a) { return a.BandName == localBandeFreq; });

                }
            }
            else
            {
                if (log.IsErrorEnabled) log.Error(string.Format("findSelectedBandFreqInLab : Erreur de conversion string bandFreq en Int"));
            }

            return objBandeFreq;

        }

        public static void findSelectedEnodeBInLab(String enodebName)
        {
            int localEnodebName;

            if (int.TryParse(enodebName, out localEnodebName))
            {

                    if (log.IsDebugEnabled) log.Debug(string.Format("localEnodebName == {0}", localEnodebName.ToString()));

                if (null == readAluLab.EnodebDuLab.Find(delegate(EnodeB a) { return a.iDenodeB == localEnodebName; }))
                {
                    if (log.IsErrorEnabled) log.Error("findSelectedEnodeBInLab : La valeur recherchée n'est pas présente dans le fichier de configuration");
                }
                else
                {
                    userInput.selectedParentNodeName.cEnodeB = readAluLab.EnodebDuLab.Find(delegate(EnodeB a) { return a.iDenodeB == localEnodebName; });

                    if (log.IsDebugEnabled) log.Debug("findSelectedEnodeBInLab : ENFIN !!!!!!!!!!!!!!!!!!!!!!!!");

                }
            }
            else
            {
                if (log.IsErrorEnabled) log.Error("Erreur de conversion string bandFred en Int");
            }

        }

        public static EnodeB newFindSelectedEnodeBInLab(String enodebName)
        {
            int localEnodebName;
            EnodeB objEnodeB = new EnodeB();

            if (int.TryParse(enodebName, out localEnodebName))
            {

                if (log.IsDebugEnabled) log.Debug(string.Format("localEnodebName == {0}", localEnodebName.ToString()));

                if (null == readAluLab.EnodebDuLab.Find(delegate(EnodeB a) { return a.iDenodeB == localEnodebName; }))
                {
                    if (log.IsErrorEnabled) log.Error("findSelectedEnodeBInLab : La valeur recherchée n'est pas présente dans le fichier de configuration");
                }
                else
                {
                    objEnodeB = readAluLab.EnodebDuLab.Find(delegate(EnodeB a) { return a.iDenodeB == localEnodebName; });

                    if (log.IsDebugEnabled) log.Debug("findSelectedEnodeBInLab : ENFIN !!!!!!!!!!!!!!!!!!!!!!!!");

                }
            }
            else
            {
                if (log.IsErrorEnabled) log.Error("Erreur de conversion string bandFred en Int");
            }

            return objEnodeB;
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
            
            if (log.IsInfoEnabled) log.Info("readXMLDocWithFieldsToUpdate : FIn Fonction");
        }


        public static void readXMLDocWithInterFieldsToUpdate(XmlElement xmlDocument, XmlNamespaceManager ns, xPathToUpdateInter pathToPatchInter)
        {
            if (log.IsInfoEnabled) log.Info("readXMLDocWithInterFieldsToUpdate : FIn Fonction");
            
            //INTER FREQ
            readXpathValue(xmlDocument, ns, pathToPatchInter.mInterFreqPathMeasurementBandwidth);

            //INTER FREQ
            foreach (String xPath in pathToPatchInter.mInterFreqLteNeighboringFreqConfDl)
            {
                readXpathValue(xmlDocument, ns, xPath);
            }

            //INTER FREQ
            readXpathNode(xmlDocument, ns, pathToPatchInter.LteNeighboringCellRelationSourcePath);

            //INTER FREQ
            readXpathValue(xmlDocument, ns, pathToPatchInter.mInterFreqDestPathMacroEnodeB);

            //INTER FREQ
            readXpathValue(xmlDocument, ns, pathToPatchInter.mInterLteNeighboringCellRelationPci);

            if (log.IsInfoEnabled) log.Info("readXMLDocWithInterFieldsToUpdate : FIn Fonction");

        }

        public static void readXMLDocWithIntraFieldsToUpdate(XmlElement xmlDocument, XmlNamespaceManager ns, xPathToUpdateIntra pathToPatchIntra)
        {
            if (log.IsInfoEnabled) log.Info("readXMLDocWithIntraFieldsToUpdate : Début Fonction");
            if (log.IsInfoEnabled) log.Info("readXMLDocWithIntraFieldsToUpdate : A CODER ........");
            if (log.IsInfoEnabled) log.Info("readXMLDocWithIntraFieldsToUpdate : FIn Fonction");
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


        public static void updateXMLDocInterFreq(XmlElement xmlDocument, XmlNamespaceManager ns, xPathToUpdateInter pathToPatchInter)
        {
            if (log.IsInfoEnabled) log.Info("updateXMLDocInterFreq : Début Fonction");

            if (log.IsInfoEnabled) log.Info("updateXMLDocIntraFreq A CODER !!!!!!!!!!!!!!!!!!!!!!!!!!!!!!");

            if (log.IsInfoEnabled) log.Info("updateXMLDocInterFreq : Fin Fonction");

        }


        public static void updateXMLDocIntraFreq(XmlElement xmlDocument, XmlNamespaceManager ns, xPathToUpdateIntra pathToPatchIntra)
        {
            if (log.IsInfoEnabled) log.Info("updateXMLDocIntraFreq : Début Fonction");

            if (log.IsInfoEnabled) log.Info("updateXMLDocIntraFreq A CODER !!!!!!!!!!!!!!!!!!!!!!!!!!!!!!");

            if (log.IsInfoEnabled) log.Info("updateXMLDocIntraFreq : Fin Fonction");

        }


        public static void readXpathValue(XmlElement xmlDocument, XmlNamespaceManager ns, String pathToRead)
        {

            XmlNode theSelectedNode = xmlDocument.SelectSingleNode(pathToRead, ns);

            if (log.IsDebugEnabled) log.Debug(string.Format(" Xpath TO READ {0} ", pathToRead));


            if (theSelectedNode != null)
            {
                if (log.IsDebugEnabled) log.Debug(string.Format("Valeur du UniqueName {0} ", theSelectedNode.InnerText));
            }
            else
            {
                if(log.IsDebugEnabled) log.Debug(string.Format("Le Chemin Xpath {0} n'éxiste pas ou le champ est vide ", pathToRead));
            }

        }

        public static void readXpathNode(XmlElement xmlDocument, XmlNamespaceManager ns, String pathToRead)
        {

            XmlNode theSelectedNode = xmlDocument.SelectSingleNode(pathToRead, ns);

            if (log.IsDebugEnabled) log.Debug(string.Format("Xpath NODE TO READ {0} ", pathToRead));

            if (theSelectedNode != null)
            {
                if (log.IsDebugEnabled) log.Debug(string.Format("Valeur du Noeud {0} ", theSelectedNode.InnerXml));
            }
            else
            {
                if (log.IsDebugEnabled) log.Debug(string.Format("Le Chemin Xpath {0} n'éxiste pas ou le noeud est vide ", pathToRead));
            }
        }

        public static void updateXpathValue(XmlElement xmlDocument, XmlNamespaceManager ns, String pathToPatch, String strToUpdate)
        {

            XmlNode theSelectedNode = xmlDocument.SelectSingleNode(pathToPatch, ns);

            if (log.IsDebugEnabled) log.Debug(string.Format("Update Xpath {0} with value {1} ", pathToPatch, strToUpdate));

            if (theSelectedNode != null)
            {
                if (log.IsDebugEnabled) log.Debug(string.Format("Valeur du theSelectedNode avant update {0} ", theSelectedNode.InnerText));
                theSelectedNode.InnerText = strToUpdate;
                if (log.IsDebugEnabled) log.Debug(string.Format("Valeur du theSelectedNode après update {0} ", theSelectedNode.InnerText));
            }

        }




    }


   


}
