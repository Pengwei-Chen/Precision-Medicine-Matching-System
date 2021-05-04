package Utils;

import DAO.*;
import crawler.DosingGuidelineCrawler;
import crawler.DrugLabelCrawler;

public class SystemInit {
    /**
     * Run ONLY once when the system is first deployed
     * Insert data, Muted next time
     * TODO: implement self-muting function (read and store init success information in the app properties file)
     * 
     */

    private ClinicAnnDAO clinicAnnDAO = new ClinicAnnDAO();
    private DrugLabelDAO drugLabelDAO = new DrugLabelDAO();
    private VarDrugAnnDAO varDrugAnnDAO = new VarDrugAnnDAO();
    private GeneDAO geneDAO = new GeneDAO();
    private DosingGuidelineDAO dosingGuidelineDAO = new DosingGuidelineDAO();
    private DrugLabelCrawler drugLabelCrawler = new DrugLabelCrawler();
    private DosingGuidelineCrawler dosingGuidelineCrawler = new DosingGuidelineCrawler();

    public void doInit() {
        // Schema, function created by admin
        // Insert data
        clinicAnnDAO.doImport(false);
        varDrugAnnDAO.doImportVarDrugAnn(false);
        varDrugAnnDAO.doImportVariant(false);
        geneDAO.doImport(false);
        drugLabelCrawler.doCrawlerDrug();
        drugLabelCrawler.doCrawlerDrugLabel();
        dosingGuidelineCrawler.doCrawlerDosingGuidelineList();
        drugLabelDAO.doImportDrugName(false);
        dosingGuidelineDAO.doImportGuidelineName(false);
        // Mute myself

    }
}
