//Put page variables
//Put page variables
var table = "#tbl";
var tblReport = "#tblReport";
var pageNum = "1";
var editURL = "";
var arrData = [];
var i = 0;

var innerWidth = "750";
var innerHeight = "600";
var colArray = ['', 'Date', 'Report Date', 'Report Time', 'Reported By', 'Hazard Source', 'Hazard Type', 'Project', 'Dept.', 'Location', 'Facility', 'Investigator', 'Supervisor', 'Initial Action', 'Hazard Severity', 'Probability', 'Risk Assesment', 'Cost', 'Consequence', 'Action Type', 'Action Desc.', 'Action By.','Status'];
var rowArray = ['id', 'entryDate', 'reportDate', 'reportTime', 'reportBy', 'hazardSource', 'hazardType', 'projectName', 'Department', 'location', 'facility', 'investigator', 'supervisor', 'initialAction', 'severity', 'probability', 'evaluation', 'cost', 'consequence', 'actionType', 'actionDesc', 'actionBy', 'status'];
var sortArray = ['Dept.'];
var colArrayReport = null;
var rowArrayReport = null;
var sortArrayReport = null;
//List possible row td variabales/values
var modelName='QHSE.Web.Models.Entities.tblHazard';
//List possible row td variabales/values



jQuery(function () {

  

    loadTbl('/Hazard/GetHazard', "#tbl", "entryDate", "/Hazard/Edit/?ID=", colArray,rowArray,sortArray,header=true); 
    

    jQuery("#btnSearch").click(function () {

        var from = jQuery("#txtStartDate").val(); var to = jQuery("#txtEndDate").val();
        loadTblBySearch('/Hazard/getHazardByQueryReport', from, to);

    });

    //Add Record

   
    jQuery("#btnSubmit").click(function () {

       
        submitForm("#tblHazard","Do you want to save the information?");  //

    });

    jQuery("#btnSave").click(function () {

       
        submitForm("#tblHazard", "Do you want to Edit the information?");
        parent.$.fn.colorbox.close();
    });

    jQuery("#btnReport").click(function () {

      
        createReport('tblHazards',modelName, '');   //

    });

  jQuery("#ddlAction").bind('change', function (){

        if (jQuery(this).val() == "edit") {


            callEditPage();

        }

        if  (jQuery(this).val() == "delete"){
        del('tblHazards', 'id');

        }
       
      if (jQuery(this).val() == "add") {
          addNewRecord(addURL);

      }


    });
   
    jQuery("input.del").bind('click', function () {
       
        if (jQuery("#ddlAction").val() == "edit") {

            callEditPage();

        }


    })
})




// Link Product ID click event handler
jQuery('#lnkID').click(function (e) {
    e.preventDefault();
    if (tableData != null) {
        // Sort data
        tableData.sort(function (a, b) {
            return a.id <= b.id ? -1 : 1;
        });
        PopulateTable(tbl, tableData, 1, mrow, editURL);
    }
});

// Link Product Name click event handler
jQuery('#lnkName').click(function (e) {
    e.preventDefault();
    if (tableData != null) {
        // Sort data
        tableData.sort(function (a, b) {
            return a.AcctNum <= b.accountNo ? -1 : 1;
        });
        PopulateTable(tbl, tableData, 1, mrow, editURL);
    }
});



 


jQuery(document).ready(function () {
   

    jQuery('.datepicker').datepicker({
        format: "mm/dd/yyyy"
    });

    jQuery('#searchBox').hide();
    jQuery('#divReportResult').hide();
    jQuery('#txtSQL').hide();
    jQuery('#lnkShowDIV').click(function () {
        jQuery('#searchBox').fadeToggle();
        jQuery('#addProjectCollapse3').fadeToggle();

        // Sort data

    });
    jQuery('#lnkShowReport').click(function () {
        jQuery('#divReport').fadeToggle();
        jQuery('#divReportResult').fadeToggle();

        // Sort data

    });
    jQuery("#RdlSummary_1").click(function () {
        showColumns(modelName,"tblHazards");


    });
    showColumnsDDL("ddlFilter", "tblHazards", modelName);
    showColumnsDDL("ddlOrderBy", "tblHazards", modelName);

    ddl("Status", "/Setting/GetGlobalVariablesById/", "", "Label", "Status");
    var varpdfFontSize = '7';
    jQuery('#exportexcel').bind('click', function (e) {
        tableToExcel('tbl', 'Hazard Info Report');
        //  jQuery('#activity').tableExport({ type: 'pdf', escape: 'false' });
        // jQuery('#grid').tableExport({ type: 'excel', escape: 'false', pdfFontSize: varpdfFontSize });

    });
    jQuery('#printtbl').bind('click', function (e) {
        printReportData('tbl');

        //  jQuery('#activity').tableExport({ type: 'pdf', escape: 'false' });


    });



});