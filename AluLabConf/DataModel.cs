using System;
using System.Collections.Generic;
using System.Threading.Tasks;


namespace AluLabConf
{

    /// <summary>
    /// déclaration des classes publiques
    /// </summary>

    public class ConfigData
    {
        public String loggerCfgFile { get; set; }
        public String labAluCfgFile { get; set; }

        public ConfigData()
        {
            this.loggerCfgFile = @"C:\romelia\log4net-cfg.xml";
            this.labAluCfgFile = @"C:\romelia\lab_conf.xml";
        }
    }

    public class BandFreq
    {
        public int BandName { get; set; }
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
        public Boolean interActivated { get; set; }
        public Boolean bX2 { get; set; }
        public Boolean bS1 { get; set; }
        public string selectedInterEnodeB { get; set; }
        public string selectedInterBandFreq { get; set; }
        public short shortbandWidth { get; set; }
        public EnodeB structInterEnodeB { get; set; }
        public BandFreq structInterBandFreq { get; set; }

        /// Constructueur
        public interNeighboring()
        {
            this.interActivated = false;
            this.structInterEnodeB = new EnodeB();
            this.structInterBandFreq = new BandFreq();
        }
    }

    public class intraNeighboring
    {
        public Boolean intraActivated { get; set; }
        public Boolean bX2 { get; set; }
        public Boolean bS1 { get; set; }
        public string selectedIntraEnodeB { get; set; }
        public short shortbandWidth { get; set; }
        public EnodeB structIntraEnodeB { get; set; }
        
        /// Constructueur
        public intraNeighboring()
        {
            this.intraActivated = false;
            this.structIntraEnodeB = new EnodeB();
        }
    }

    public class parentNodeName
    {
        public EnodeB cEnodeB { get; set; }
        public BandFreq cBandFreq { get; set; }

        public parentNodeName()
        {
            this.cEnodeB = new EnodeB();
            this.cBandFreq = new BandFreq();
        }
    }


    public class LabAlu
    {
        public List<BandFreq> BandFreqDuLab;
        public List<int> iDBandFreqDuLab;
        public List<EnodeB> EnodebDuLab;
        public List<int> iDEnodebDuLab;

        public LabAlu()
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
        public string selectedParentNodeB { get; set; }
        public string selectedParentBandeFreq { get; set; }
        public parentNodeName selectedParentNodeName { get; set; }
        public intraNeighboring selectedIntra { get; set; }
        public interNeighboring selectedInter { get; set; }

        public cUserInput()
        {
            this.selectedParentNodeName = new parentNodeName();
            this.selectedIntra = new intraNeighboring();
            this.selectedInter = new interNeighboring();
        }
    }



}