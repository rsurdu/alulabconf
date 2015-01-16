using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;
using log4net;



/// <summary>
/// Classe de stockage des chemins xPath du Parent à mettre à jour
/// </summary>

public class xPathToUpdate
{

    public static readonly ILog log = LogManager.GetLogger(System.Reflection.MethodBase.GetCurrentMethod().DeclaringType);

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

        if (log.IsInfoEnabled) log.Info("xPathToUpdate : Début Constructeur");

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

        if (log.IsInfoEnabled) log.Info("xPathToUpdate : Fin Constructeur");

    }


}


/// <summary>
/// Classe de stockage des chemins xPath à mettre à jour dans le Inter
/// </summary>


public class xPathToUpdateInter
{

    public static readonly ILog log = LogManager.GetLogger(System.Reflection.MethodBase.GetCurrentMethod().DeclaringType);

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

    public xPathToUpdateInter()
    {

        if (log.IsInfoEnabled) log.Info("xPathToUpdateInter : Début Constructeur");

        // INTER PATH
        this.mInterFreqPathMeasurementBandwidth = "//conf:config/enb:ENBEquipment/enb:Enb[enb:rdnId='0']/enb:LteCell[enb:uniqueName='1']/enb:LteNeighboring[enb:rdnId='0']/enb:LteNeighboringFreqConf[enb:rdnId='1']/enb:attributes/enb:measurementBandwidth";

        // INTER PATH
        this.mInterFreqLteNeighboringFreqConfDl = new List<String>();
        this.mInterFreqLteNeighboringFreqConfDl.Add("//conf:config/enb:ENBEquipment/enb:Enb[enb:rdnId='0']/enb:LteCell[enb:uniqueName='0']/enb:LteNeighboring[enb:rdnId='0']/enb:LteNeighboringFreqConf[enb:rdnId='1']/enb:attributes/enb:dlEARFCN");
        this.mInterFreqLteNeighboringFreqConfDl.Add("//conf:config/enb:ENBEquipment/enb:Enb[enb:rdnId='0']/enb:LteCell[enb:uniqueName='1']/enb:LteNeighboring[enb:rdnId='0']/enb:LteNeighboringFreqConf[enb:rdnId='1']/enb:attributes/enb:dlEARFCN");
        this.mInterFreqLteNeighboringFreqConfDl.Add("//conf:config/enb:ENBEquipment/enb:Enb[enb:rdnId='0']/enb:LteCell[enb:uniqueName='2']/enb:LteNeighboring[enb:rdnId='0']/enb:LteNeighboringFreqConf[enb:rdnId='1']/enb:attributes/enb:dlEARFCN");
        this.mInterFreqLteNeighboringFreqConfDl.Add("//conf:config/enb:ENBEquipment/enb:Enb[enb:rdnId='0']/enb:LteCell[enb:uniqueName='0']/enb:RrcMeasurementConf[enb:rdnId='0']/enb:MeasObject[enb:rdnId='0']/enb:MeasObjectEUTRA[enb:rdnId='0']/enb:attributes/enb:dlEARFCN");
        this.mInterFreqLteNeighboringFreqConfDl.Add("//conf:config/enb:ENBEquipment/enb:Enb[enb:rdnId='0']/enb:LteCell[enb:uniqueName='1']/enb:RrcMeasurementConf[enb:rdnId='0']/enb:MeasObject[enb:rdnId='0']/enb:MeasObjectEUTRA[enb:rdnId='0']/enb:attributes/enb:dlEARFCN");
        this.mInterFreqLteNeighboringFreqConfDl.Add("//conf:config/enb:ENBEquipment/enb:Enb[enb:rdnId='0']/enb:LteCell[enb:uniqueName='2']/enb:RrcMeasurementConf[enb:rdnId='0']/enb:MeasObject[enb:rdnId='0']/enb:MeasObjectEUTRA[enb:rdnId='0']/enb:attributes/enb:dlEARFCN");

        // INTER PATH
        this.LteNeighboringCellRelationSourcePath = "//conf:config/enb:ENBEquipment/enb:Enb[enb:rdnId='0']/enb:LteCell[enb:uniqueName='1']/enb:LteNeighboring[enb:rdnId='0']/enb:LteNeighboringFreqConf[enb:rdnId='0']/enb:LteNeighboringCellRelation[enb:uniqueName='2']";
        this.LteNeighboringCellRelationDestPath = "//conf:config/enb:ENBEquipment/enb:Enb[enb:rdnId='0']/enb:LteCell[enb:uniqueName='1']/enb:LteNeighboring[enb:rdnId='0']/enb:LteNeighboringFreqConf[enb:rdnId='1']/enb:LteNeighboringCellRelation[enb:uniqueName='2']";

        // INTER PATH
        this.mInterFreqDestPathMacroEnodeB = "//conf:config/enb:ENBEquipment/enb:Enb[enb:rdnId='0']/enb:LteCell[enb:uniqueName='1']/enb:LteNeighboring[enb:rdnId='0']/enb:LteNeighboringFreqConf[enb:rdnId='1']/enb:LteNeighboringCellRelation[enb:uniqueName='2']/enb:attributes/enb:macroEnbId";

        // INTER PATH
        this.mInterLteNeighboringCellRelationPci = "//conf:config/enb:ENBEquipment/enb:Enb[enb:rdnId='0']/enb:LteCell[enb:uniqueName='1']/enb:LteNeighboring[enb:rdnId='0']/enb:LteNeighboringFreqConf[enb:rdnId='1']/enb:LteNeighboringCellRelation[enb:uniqueName='2']/enb:attributes/enb:pci";

        if (log.IsInfoEnabled) log.Info("xPathToUpdateInter : Fin Constructeur");
    }
}

/// <summary>
/// Classe de stockage des chemins xPath à mettre à jour dans le Intra
/// </summary>


public class xPathToUpdateIntra
{
    public static readonly ILog log = LogManager.GetLogger(System.Reflection.MethodBase.GetCurrentMethod().DeclaringType);

    public xPathToUpdateIntra()
    {
        if (log.IsInfoEnabled) log.Info("xPathToUpdateIntra : Début Constructeur");

        if (log.IsInfoEnabled) log.Info("xPathToUpdateIntra : A Coder");

        if (log.IsInfoEnabled) log.Info("xPathToUpdateIntra : Fin Constructeur");
    }

}
