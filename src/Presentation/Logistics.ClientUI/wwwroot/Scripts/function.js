var tableData = null;
var getVal = "";
var vals = [];
var textvals = [];
var val = [];
jQuery(function () {
   
  
    // Populate categories when the page is loaded.  
   
    //jQuery('#tbl').bind(
    //    {
    //        mouseover: function () {
    //            var w = jQuery(this).find('table').outerWidth();
    //            var hw = jQuery(document).width() - jQuery(this).offset().left - 20;
               
    //            /*
    //             * Test code.
    //             */
    //            /*var left, top;
    //            left = jQuery(this).offset().left;
    //            top = jQuery(this).offset().top;
    
    //            jQuery(this)
    //                .appendTo('body')
    //                .css({
    //                'position': 'absolute',
    //                'left': left + 'px',
    //                'top': top + 'px'
    //            });
    //            */

    //            if (w > jQuery(this).outerWidth()) {
    //                // jQuery(this).css({'position':'relative', 'z-index':'9999', 'box-shadow':'5px 5px 5px #888', 'width':(w > hw ? hw : w)+'px'});
    //                jQuery(this).css({ 'position': 'relative', 'z-index': '9999', 'width': (w > hw ? hw : w) + 'px' });
    //            }
    //        },
    //        mouseout: function () {
    //            // jQuery(this).removeAttr('style');
    //            jQuery(this).css({ 'position': 'relative', 'z-index': '', 'width': 'auto' });
    //        },
    //        dblclick: function () {
    //            //Create text area on top of code on double click
    //            //This can make copying of the code easier

    //            var jthis = jQuery(this);
    //            if (!jthis.data('hasTextArea')) {
    //                var code = jthis.find(".theCode").html();
    //                var ta = jQuery('<textarea spellcheck="false"/>');
    //                ta.html(code);

    //                var pre = jthis.find('.code > pre');

    //                ta.css({
    //                    'font-family': pre.css('font-family'),
    //                    'font-size': pre.css('font-size'),
    //                    'line-height': pre.css('line-height'),
    //                    'height': "100%",
    //                    'width': "100%",
    //                    'position': 'absolute',
    //                    'top': 0,
    //                    'left': 0,
    //                    'margin': pre.css('margin'),
    //                    'padding': pre.css('padding'),
    //                    'border': '0px'
    //                });

    //                ta.css('resize', 'none');
    //                ta.css('outline', 'none');

    //                ta.focusout(function () {
    //                    ta.remove();
    //                    jthis.data('hasTextArea', false);
    //                });

    //                //readjust position and width if using line numbers
    //                var line_numbers = jthis.find(".line_numbers");
    //                if (line_numbers.length != 0) {
    //                    var w = line_numbers.outerWidth();
    //                    ta.css('left', w + "px");
    //                    ta.css('width', jthis.width() - w + "px");
    //                }
    //                //readjust position and height if using caption
    //                var caption = jthis.find('caption');
    //                if (caption.length != 0) {
    //                    var h = caption.outerHeight();
    //                    ta.css('top', h + "px");
    //                    ta.css('height', jthis.height() - h + "px");
    //                }

    //                ta.appendTo(jthis);

    //                ta.select();
    //                ta.focus();

    //                jthis.data('hasTextArea', true);

    //            }
    //        }
    //    });
    
   
})


//****************Query database Tables (GET ALL,FIND BY ID) CRUD FUNCTIONS*********************************************

function LoadToDataTable(tbl,table, modelName, fromDate, toDate) {

  



    var dataString = "{"
    dataString += " 'item': '" + modelName + "',"
    dataString += " 'tbl': '" + table + "',"
    dataString += " 'dateField': '',"
    dataString += " 'FromDate': '" + fromDate + "',"
    dataString += " 'ToDate': '" + toDate + "',"
    dataString += " 'FieldVar': '',"
    dataString += " 'FilterVar': '',"
    dataString += " 'OrderByVar': '',"
    dataString += " 'OrderType': '',"
    dataString += " 'list': '" + true + "'"
    dataString += "}";

  //  jQuery("#tbl tbody").html("Loading...");
    //   alert(dataString);
    jQuery.ajax({
        url: '/Report/CreateReport/',
        type: "POST",
        contentType: "application/json; charset=utf-8",
        data: dataString,
        dataType: "json",
        success: function (data) {
            // alert(data[0][0]);
            if (data == "0") {

                jQuery("#tbl tbody").html("<b>No Records Found</b>");
                jQuery('#divReport').fadeToggle();
                jQuery('#divReportResult').show();
            } else {
                tableData = JSON.parse(data);


                var Columns = [];
                var tableData = JSON.parse(data);
                var TableHeader = "<thead><tr>";
                jQuery.each(tableData[0], function (key, value) {
                    
                    Columns.push({ "data": key })
                    TableHeader += "<th>" + key + "</th>"
                });
                TableHeader += "</thead></tr>";
                jQuery(tbl).append(TableHeader);
                jQuery(tbl).dataTable({
                    "data": tableData,
                    "columns": Columns                  
                });           

            }

        },
        error: function (xhr, ajaxOptions) {
            alert(xhr.status);
            // alert("Error with AJAX callback");
        }
    });

}

function LoadDataTable(tbl,url) {

   
        jQuery.getJSON(url, { /*id: n, fromDate: from, toDate: to */}, function (data) {
           
           
            //Check Data Table has if already initialize then need to destroy first!

            //if (jQuery.fn.DataTable.isDataTable(tbl)) {
            //    jQuery(tbl).DataTable().destroy();
            //    jQuery(tbl).empty();
            //}

            //Listing Columns (Table Header) from json ajax response
           var Columns = [];
           var  tableData = JSON.parse(data);
            var TableHeader = "<thead><tr>";
            jQuery.each(tableData[0], function (key, value) {
               // alert(key);
                Columns.push({ "data": key })
                TableHeader += "<th>" + key + "</th>"
            });
            TableHeader += "</thead></tr>";
            jQuery(tbl).append(TableHeader);
            jQuery(tbl).DataTable({
                "data": tableData,
                "columns": Columns,
                "JQueryUI": true,
                dom: 'Bfrtip',
                dom: 'lBfrtip',
            });           



           
        }).fail(function (jqXHR, textStatus, errorThrown) {
            // Ajax fail callback function.
            alert('Error getting data!');
        });
    }













function loadTblBySearch(url, from, to) {


    jQuery.getJSON(url, { /*id: n,*/ fromDate: from, toDate: to }, function (data) {

        // Populate table from Json data returned from server.

        //  PopulateTable(data, 1);
        PopulateTable(data[0], data, 1, true, field, editURL, table, colArray, rowArray, sortArray);
        tableData = data.slice(0);
    }).fail(function (jqXHR, textStatus, errorThrown) {
        // Ajax fail callback function.
        alert('Error getting data!');
    });
}


function loadTbl(url, table, field, editURL, colArray = [], rowArray = [], sortArray = [], header, hFlag) {
    //var jQuerybody = jQuery('body');
    //jQuerybody.showLoading();
    //  fnBlockUI('..loading');
    //jQuery("#tbl tbody").html("Loading...");
    jQuery.getJSON(url, true, function (data) {
       
        if (data=="0") {
            
            jQuery("#tbl tbody").html("<b>No Records Found</b>");
        } else {
            PopulateTable(data[0], data, 1, true, field, editURL, table, colArray, rowArray, sortArray, header, hFlag);
            tableData = data.slice(0);

    }
      
            
    }).fail(function (jqXHR, textStatus, errorThrown) {
        // Ajax fail callback function.
        alert(errorThrown);
    });


}
// Link Product ID click event handler
jQuery('#lnkID').click(function (e) {
    e.preventDefault();
    if (tableData != null) {
        // Sort data
        tableData.sort(function (a, b) {
            return a.id <= b.id ? -1 : 1;
        });
        PopulateTable(tableData, rowData, 1);
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
        PopulateTable(tableData, rowData, 1);
    }
});

function myJsFunc(e, innerWidth, innerHeight) {

    var id = e.id;
  
    var url = jQuery("#" + id).attr("rel");


    //  jQuery.colorbox({ iframe: true, innerWidth: 500, innerHeight: 600, maxWidth: 500, maxHeight: 650, scrolling: false, top: 10, href: url });
    jQuery.colorbox({ iframe: true, innerWidth: innerWidth, innerHeight: innerHeight, maxWidth: innerWidth, maxHeight: innerHeight, scrolling: false, top: 10, href: url });
}


function addNewRecord(addURL) {

    var s = new Array()
    var $this = null;
    var url = "";
    var a = 0;
   
    location.href = addURL;


}

function callEditPage() {

   
    var ID = new Array()
    var $this = null;
    var url = "";
   var a = 0;
    jQuery("input.del:checked").each(function () {
        a++;
       
      
    })

    if (a < 1) {
        alert("Select checkbox for this operation!");
        return false;
    }

    if (a > 1) {
        alert("Check only one box for this operation!");
        return false;
    }
    //if (a == 1) {
    //    jQuery("input.del:checked").find("td").each(function () {

    //        url = jQuery(this).find('a').attr("rel");
    //        alert(url);

    //    });

  //  }
  //  url = jQuery("input.del:checked").closest('td').next('td').next('td').find('a').attr("rel");
    url = jQuery("input.del:checked").closest('td').next('td').find('a').attr("rel");
  
 //  jQuery.colorbox({ iframe: true, innerWidth: 500, innerHeight: 600, maxWidth: 500, maxHeight: 650, scrolling: false, top: 10, href: url });
    jQuery.colorbox({ iframe: true, innerWidth: innerWidth, innerHeight: innerHeight, maxWidth: innerWidth, maxHeight: innerHeight, scrolling: false, top: 10, href: url });

}



function del(tbl, fld) {

    //  var page = jQuery(this).attr("href");
    var ID = new Array()
    a = 0;
    jQuery("input.del:checked").each(function () {
        ID[a] = jQuery(this).val();
        a++;

    })


    if (confirm("Are you sure you want to delete?")) {

        el = jQuery(this)
        jQuery.ajax({
            url: "/Setting/del",
            data: "table=" + tbl + "&field=" + fld + "&fieldVal=" + ID,
            type: "POST",
            success: function (res) {
                //  if (res == 1) {
                jQuery("input.del:checked").each(function () {
                    jQuery(this).parent().parent().remove();
                })



                //  }
            }
        })
    }
    return false;
}

jQuery("form").validate({

            onsubmit: false
          });


function submitForm(f, m,validate=true) {
  
  var isValid = jQuery(f).valid();
  
    
    if (validate) {
      
        if (!isValid) {
           
            return false;
        } else {
            if (confirm(m)) {

             jQuery.ajax(
                {
                    url: jQuery(f).attr("action"),
                    dataType: 'json',
                    data: jQuery(f).serialize(),
                    type: 'POST',
                    success: function (result) {
                        alert(result);
                        clear_form_elements(f);

                    },
                    error: function (xhr) {
                        alert(xhr.statusText);
                    }
                });


                // event.preventDefault();
                //  });
            }
           

        }



    } else {

        if (confirm(m)) {

         jQuery.ajax(
            {
                url: jQuery(f).attr("action"),
                dataType: 'json',
                data: jQuery(f).serialize(),
                type: 'POST',
                success: function (result) {
                    alert(result);
                    clear_form_elements(f);
                },
                error: function (xhr) {
                    alert(xhr.statusText);
                }
            });

            // event.preventDefault();
            //  });
        }
       


    }



  
    //}
}



function checkall() {
    var checkboxes = document.getElementsByTagName('input'), val = null;
    for (var i = 0; i < checkboxes.length; i++) {
        if (checkboxes[i].type == 'checkbox') {
            if (val === null) val = checkboxes[i].checked;
            checkboxes[i].checked = val;
        }
    }
}

function PopulateTable(colData, rowData, pageNum, editFlag = false, field, editURL, table, colArray = [], rowArray = [], sortArray = [], header,hFlag) {
    var rowsPerPage = 4;
    var pages;
    var i;
    var pager = '';
    var startIndex;
    var endIndex;
    var row;
    var chk = 0;
    
    jQuery(table + ' tr:gt(0)').remove();
    jQuery(table + ' tr:gt(1)').remove();
    var tbl = "";

    if (hFlag == null) {



   

    if (colArray != null && header == true) {

        tbl = " <thead> <tr style='background:#e4e4e4'>";

        for (var t = 0; t <= colArray.length - 1; t++) {


            if (colArray[t] == '') {


                tbl += '<th><input id="chk" type="checkbox" class="del" value="" onclick="javascript: checkall();"/></th>';

            } else {

                if (sortArray != null) {
                    for (var p = 0; p <= sortArray.length - 1; p++) {
                        if (sortArray[p] == colArray[t]) {


                            tbl += '<th><a id= "lnkID" href= "#" >' + sortArray[p] + '</a></th>';
                            //break;
                        } else {

                            tbl += "<th>" + colArray[t] + "</th>"
                        }
                    }
                }
                else {
                    alert(colArray[t]);
                    tbl += "<th>" + colArray[t] + "</th>"

                }



            }



        }
        tbl += "</tr></thead>";

        jQuery(table).append(tbl);



    } else {

        tbl = " <thead> <tr style='background:#e4e4e4'>";

        var keys = [];
        for (var key in colData) {

            if (colData.hasOwnProperty(key)) {
                if (key.indexOf("id") > -1 || key === "id") {
                    // alert(parseJsonDate(o[key]));

                    tbl += '<th><input id="chk" type="checkbox" class="del" value="" onclick="javascript: checkall();"/></th>';
                } else {




                    tbl += "<th id='cell" + key + "'>" + key + "</th>";


                }

            }



        }
        tbl += "</tr></thead>";

        jQuery(table).append(tbl);
      

    }
    

  }


    if (rowData != null) {

        // Populate table with data in the current page.
        startIndex = (pageNum - 1) * rowsPerPage;
        endIndex = pageNum * rowsPerPage > rowData.length ?
            rowData.length - 1 : pageNum * rowsPerPage - 1;
       
        var FullName = "";
        var colModelsArray = [];

        row = "<tbody>";

        for (i = startIndex; i <= endIndex; i++) {

            row += '<tr>';

            var o = rowData[i];
            // alert(o);
            //  var o = arrData[i];
            // Begin when row array is not null
            if (rowArray !== null) {

              
                var m = 0;
                var counter = rowArray.length - 1;
                for (var key in o) {




                    

                    if (o.hasOwnProperty(key)) {
                      

                        if (rowArray[m] === "ID" || rowArray[m] === "id") {

                        

                            row += '<td><input id="chk' + o[rowArray[m]] + '" type="checkbox" class="del"  value="' + o[rowArray[m]] + '"/></td>';

                           

                        }
                        else if (rowArray[m].indexOf("Date") > -1 || rowArray[m].indexOf("date") > -1) {

                            if (editFlag = true && rowArray[m] == field ) {
                                

                                row += '<td><a  id="' + o["id"] + '"  onclick="myJsFunc(this,innerWidth,innerHeight);" rel="' + editURL + o["id"] + '" href="#">' + parseJsonDate(o[rowArray[m]]) + '</a></td>';

                            } else {


                                row += '<td>' + parseJsonDate(o[rowArray[m]]) + '</td>';

                            }

                          


                        }

                        else if (editFlag = true && rowArray[m] == field) {
                           

                            row += '<td><a  id="' + o["id"] + '"  onclick="myJsFunc(this,innerWidth,innerHeight);" rel="' + editURL + o["id"] + '" href="#">' + o[rowArray[m]] + '</a></td>';

                        }

                        else if ( rowArray[m].indexOf("Amt") > -1) {

                            row += '<td>' + formatNumber(o[rowArray[m]]) + '</td>';
                        }
                        else {

                      
                            row += '<td>' + o[rowArray[m]] + '</td>';
                        }


                    }
                    // }
                    if (m < counter) {
                        m++;
                    }
                    else { break; }





                }
            }
            // End when row array is not null
            else {
               
                //Begin when rowArray is null
                for (var key in o) {


                    if (o.hasOwnProperty(key)) {






                        // alert(key + " -> " + o[key]);|| key.indexOf("Time") > 1
                        if (key.indexOf("Date") > -1 || rowArray[m].indexOf("date") ) {
                            // alert(parseJsonDate(o[key]));
                            row += '<td>' + parseJsonDate(o[key]) + '</td>';
                        }
                        else if (editURL = true || key.indexOf(field) > -1) {
                            var url = editURL + 0["id"] + '" class="task"';

                            row += '<td><a  id="' + i + '" onclick="myJsFunc(this,innerWidth,innerHeight);" rel="' + url + '" href="#">' + o[key] + '</a></td>';
                        }
                        else if (key.indexOf("Fee") > -1 || key.indexOf("Amt") > -1) {

                            row += '<td>' + formatNumber(o[key]) + '</td>';
                        }
                        else {

                            row += '<td>' + o[key] + '</td>';
                        }


                    }





                }
                //End when rowArray is null 
            }






            row += '</tr>';
        }

    }

    jQuery(table).append(row);
    jQuery(table).append("</tbody>");
    // Show pager row if there is more than one page
    pages = Math.floor(rowData.length / rowsPerPage);
    if (pages < rowData.length / rowsPerPage) {
        pages += 1;
    }
    if (pages > 1) {
        for (i = 0; i < pages; i++) {
            if (i == pageNum - 1) {
                pager += '<li class="active"><a href="#" >' + (i + 1) + '</a></li>';
            }
            else {
                pager += '<li><a href="#" >' + (i + 1) + '</a></li>'
            }
        }


        //  pager = '<tr><td colspan="9" class="pagerRow">' +
        //  pager + '</td></tr>';
        // $('#tblProducts').append(pager);
        jQuery('#pager').html(pager);

        // Pager link event handler
        //  $('#tblProducts tr td.pagerRow a').click(function (e) {
        jQuery('#pager li a').click(function (e) {
            e.preventDefault();
            var pNum = parseInt(jQuery(this).text());

            // PopulateTable(tableData, rowData, pNum);
            //  PopulateTable(tableData, rowData, pNum);
            PopulateTable(tableData, rowData, pNum, editFlag, field, editURL, table, colArray, rowArray, sortArray, header, hFlag="yes");
        });

        // Pager link event handler

    }

}
//*******************************END CRUD FUNCTIONS************************************************************************



//***************************REPORT FUNCTIONS********************************************************************************



function getColNames(data) {
    var keys = [];
    for (var key in data) {
        if (data.hasOwnProperty(key)) {
            keys.push(key);
        }
    }

    return keys;
}
function getColModels(data) {
    var colNames = getColNames(data);
    var colModelsArray = [];
    for (var i = 0; i < colNames.length; i++) {
        var str;
        if (i === 0) {

            str = {
                name: colNames[i],
                index: colNames[i],
                key: true,
                editable: true
            };
        } else {
            str = {
                name: colNames[i],
                index: colNames[i],
                editable: true
            };
        }
        colModelsArray.push(str);
    }

    return colModelsArray;
}

//function showColumnsDDL(ele, t,modelName) {
//    //var ddl = "";


//    jQuery.getJSON('@Url.Action("getTableColumn", "Report")', { tbl: t ,m:modelName}, function (data) {

//        // alert(data);

//        jQuery("#" + ele).append("<option value=''>--Select --</option>");
//        jQuery.each(data, function (index, opt) {

//            jQuery("#" + ele).append("<option value='" + opt + "'>" + opt + "</option>");
//        });




//    })





//    //jQuery.colorbox({ iframe: true, innerWidth: 700, innerHeight: 550, href: url });
//}




function createReport(tbl,modelName, dateField) {

    var fromDate = jQuery("#txtStartDate").val(); var toDate = jQuery("#txtEndDate").val();
    var fieldVar = jQuery("#hdSQL").val();
    var ddlFilter = jQuery("#ddlFilter").val(); var operand = jQuery("#ddlFilterOperand").val(); var txtFilter = jQuery("#txtFilter").val();
    var ddlOrderBy = jQuery("#ddlOrderBy").val(); var ddlOrderType = jQuery("#ddlOrderType").val();



    var dataString = "{"
    dataString += " 'item': '" + modelName + "',"
    dataString += " 'tbl': '" + tbl + "',"
    dataString += " 'dateField': '" + dateField + "',"
    dataString += " 'FromDate': '" + fromDate + "',"
    dataString += " 'ToDate': '" + toDate + "',"
    dataString += " 'FieldVar': '" + fieldVar + "',"
    dataString += " 'FilterVar': '" + ddlFilter + operand + txtFilter + "',"
    dataString += " 'OrderByVar': '" + ddlOrderBy + "',"
    dataString += " 'OrderType': '" + ddlOrderType + "',"
    dataString += " 'list': '" + true + "'"


    dataString += "}";

   // jQuery("#tbl tbody").html("Loading...");
  
    //   alert(dataString);
    jQuery.ajax({
        url: '/Report/CreateReport/',
        type: "POST",
        contentType: "application/json; charset=utf-8",
        data: dataString,
        dataType: "json",
        success: function (data) {
            // alert(data[0][0]);
            if (data == "0") {

              //  jQuery("#tbl tbody").html("<b>No Records Found</b>");
                jQuery('#divReport').fadeToggle();
                jQuery('#tblReport tr').remove();
               
              //  jQuery('#divReportResult').remove();
                jQuery("#hReport").text("No Records Found");
               // jQuery('#divReportResult ').prepend("<b>No Records Found</b>");
                jQuery('#divReportResult').show();
                
            } else {

                jQuery('#divReportResult').prepend("");
                tableData = JSON.parse(data);


                PopulateReportTable(tableData, tableData, 1, "#tblReport", null, null, null, false);
                jQuery('#divReport').fadeToggle();
                jQuery('#divReportResult').show();
            }
            
        },
        error: function (xhr, ajaxOptions) {
            alert(xhr.status);
            // alert("Error with AJAX callback");
        }
    });

}

function getColumnNames(modelName, fieldName) {

    jQuery.getJSON("/report/displayName", { item: modelName, field: fieldName }, function (data) {

        // Populate table from Json data returned from server.
       // alert(data);     return 
  jQuery("#cell" + fieldName).innerHTML(data);
      //  alert(data);
    }).fail(function (jqXHR, textStatus, errorThrown) {
        // Ajax fail callback function.
        alert(errorThrown);
    });




}



function exportTableToCSV($table, filename) {

    var $rows = $table.find('tr:has(td)'),

        // Temporary delimiter characters unlikely to be typed by keyboard
        // This is to avoid accidentally splitting the actual contents
        tmpColDelim = String.fromCharCode(11), // vertical tab character
        tmpRowDelim = String.fromCharCode(0), // null character

        // actual delimiter characters for CSV format
        colDelim = '","',
        rowDelim = '"\r\n"',

        // Grab text from table into CSV formatted string
        csv = '"' + $rows.map(function (i, row) {
            var $row = jQuery(row),
                $cols = $row.find('td');

            return $cols.map(function (j, col) {
                var $col = jQuery(col),
                    text = $col.text();

                return text.replace(/"/g, '""'); // escape double quotes

            }).get().join(tmpColDelim);

        }).get().join(tmpRowDelim)
            .split(tmpRowDelim).join(rowDelim)
            .split(tmpColDelim).join(colDelim) + '"',

        // Data URI
        csvData = 'data:application/csv;charset=utf-8,' + encodeURIComponent(csv);

    jQuery(this)
        .attr({
            'download': filename,
            'href': csvData,
            'target': '_blank'
        });
}

var tableToExcel = (function () {
    var uri = 'data:application/vnd.ms-excel;base64,', template = '<html xmlns:o="urn:schemas-microsoft-com:office:office" xmlns:x="urn:schemas-microsoft-com:office:excel" xmlns="http://www.w3.org/TR/REC-html40"><head><!--[if gte mso 9]><xml><x:ExcelWorkbook><x:ExcelWorksheets><x:ExcelWorksheet><x:Name>{worksheet}</x:Name><x:WorksheetOptions><x:DisplayGridlines/></x:WorksheetOptions></x:ExcelWorksheet></x:ExcelWorksheets></x:ExcelWorkbook></xml><![endif]--></head><body><table>{table}</table></body></html>', base64 = function (s) {
        return window.btoa(unescape(encodeURIComponent(s)));
    },
        format = function (s, c) {
            return s.replace(/{(\w+)}/g, function (m, p) { return c[p]; });
        };
    return function (table, name) {
        if (!table.nodeType) {
            table = document.getElementById(table);
        }
        var ctx =
            {
                worksheet: name || 'Worksheet',
                table: table.innerHTML
            };
        window.location.href = uri + base64(format(template, ctx));
    };
})();


function printReportData(id) {
    

    var stylStr = '<link href="~/bootstrap/css/bootstrap.min.css" rel="stylesheet" type="text/css" /><style type="text/css">.newTable {width: 100%; color: #333;font-family: "Segoe UI",Verdana,Helvetica,Sans-Serif;padding: 0.25em 2em 0.25em 0em;}body {color: #333;font-size: 0.85em;font-family: "Segoe UI",Verdana,Helvetica,Sans-Serif;}'
        + ' .newTable th {width: auto; text-align: left;font-size: 10px;color: #008000;}.newTable tr {color: black;}fieldset {margin: 0px;padding: 0px;border: 1px solid #808080;border-radius: 3px;}.allcontent {margin-left: auto;margin-right: auto;width: 100%;height: auto;min-height: 60%;top: 30%;}'
        + '.tr2{ font-size: 10pt;background-color:green;color:#f9f9f9;}.newTable td {width: auto; text-align: left;font-size: 10px;}.customlegend22 {width: 100%;position: relative;font-weight: bold;font-size: 7pt;padding: 7px 0px 6px 7px;background-color: #008000;color: #F9F9F9;}html {background-color: #E2E2E2;margin: 0px;padding: 0px;}*, *:before, *:after {box-sizing: border-box;}</style> ';

    var xxt = '<script type="text/javascript"> $(document).ready(function (){$("#" + id2).remove();});</script>';

    $('<div id= "ftx" style="width:100%"></div>');

    var winpops = window.open('', "Transaction Voucher", "fullscreen=no,toolbar=no,status=yes, " +
        "menubar=no,scrollbars=yes,resizable=yes,directories=yes,location=no, " +
        "width=1100,height=500,left=100,top=100,screenX=100,screenY=100");
    winpops.document.write(stylStr + jQuery('#' + id).html());

    winpops.print();
    
}
function showColumnsDDL(ele, dataTable, modelName) {

    var ddl = "";

    jQuery("#" + ele).empty();
    jQuery.getJSON('/Report/getTableColumn/', { tbl: dataTable, m: modelName }, function (data) {

     

        jQuery("#" + ele).append("<option value=''>--Select --</option>");
        jQuery.each(data, function (index, opt) {

            var f = []; f = opt.split(",");

            jQuery("#" + ele).append("<option value='" + f[1] + "'>" + f[0] + "</option>");
        });




    })
}

function showColumns(modelName,dataTable) {
    var ddl = "";
    jQuery.getJSON('/Report/getTableColumn/', { tbl: dataTable,m:modelName }, function (data) {

        // Populate table from Json data returned from server.
        //  alert(data.length);
        ddl += "<table><tr><td></td><td>Field</td><td>Alias</td></tr>";
        var i = 1;
        jQuery.each(data, function (index, opt) {
            //  for (var i = 1; i <= data.length - 1; i++) {

            var d = []; d = opt.split(",");
           
            if (d[0].indexOf("Date") > -1) {
                //  alert(data[i]);
                ddl += "<tr>"

                ddl += " <td><input type='checkbox'  class='chk'   id='chk-" + i + "' ></input></td>"
                ddl += "<td><input type='text'  readonly ='readonly' class='txtFieldID'  id='txtFieldID" + i + "' value='outer." + d[1] + "' ></input></td>"
                ddl += "<td><input type='text'  readonly ='readonly' class='txtFieldName' id='txtFieldName" + i + "' value=' As " + d[0] + "'></input></td>"

                ddl += "</tr>"

            } else {


                ddl += "<tr>"

                ddl += " <td><input type='checkbox'  class='chk'   id='chk-" + i + "' ></input></td>"
                ddl += "<td><input type='text' class='txtFieldID'  id='txtFieldID" + i + "' value='outer." + d[1] + "' ></input></td>"
                ddl += "<td><input type='text'  class='txtFieldName' id='txtFieldName" + i + "' value=' As " + d[0] + "'></input></td>"

                ddl += "</tr>"



            }
            i++;
            //if (i == data.length - 1) {
            //    //  alert("hello");
            //    ddl += "<tr>"

            //    ddl += " <td><input type='checkbox'  class='chk'   id='chk-" + i + 1 + "' ></input></td>"
            //    ddl += "<td><input type='text' class='txtFieldID'  id='txtFieldID" + i + 1 + "' value='inner.Name' ></input></td>"
            //    ddl += "<td><input type='text'  class='txtFieldName' id='txtFieldName" + i + 1 + "' value=' As Name'></input></td>"

            //    ddl += "</tr>"

            //}
      //  }
      });
        ddl += "</table>";
      //  jQuery("#hdCount").val(data.length);
        //alert(data[i]); 
        // alert(ddl);
       // $.prompt(ddl, { buttons: { Submit: 0 }, submit: addFieldsList });
        showPrompt(ddl, addFieldsList);
        // $.blockUI(ddl, { buttons: { Submit: 0 }, submit: addFieldsList });
    })





    //jQuery.colorbox({ iframe: true, innerWidth: 700, innerHeight: 550, href: url });
}

function showPrompt(s, a) {
    
    $.prompt(s, { buttons: { Submit: 0 }, submit: a });


}




function PopulateReportTable(colData, rowData, pageNum, table, colArrayReport = [], rowArrayArray = [], sortArrayReport = [], header = true) {
    var rowsPerPage = 100;
    var pages;
    var i;
    var pager = '';
    var startIndex;
    var endIndex;
    var row;
    var chk = 0;

   
    jQuery(table +" tr ").remove();
   // jQuery(table + ' tr:gt(1)').remove();
    var tbl = " <thead> <tr style='background:#e4e4e4'>";



    if (colArrayReport != null && header == true) {

        for (var t = 0; t <= colArrayReport.length - 1; t++) {


            if (sortArrayReport != null) {
                for (var p = 0; p <= sortArray.length - 1; p++) {
                    if (sortArrayReport[p] == colArrayReport[t]) {
                        
                        tbl += '<th><a id= "lnkID" href= "#" >' + sortArrayReport[p] + '</a></th>';
                        //break;
                    } else {

                        tbl += "<th>" + colArrayReport[t] + "</th>"
                    }
                }
            }
            else {

                tbl += "<th>" + colArrayReport[t] + "</th>"

            }


        }
        tbl += "</tr></thead>";

        jQuery(table).append(tbl);



    } else {
        
        var keys = [];
        for (var key in colData[0]) {

            if (colData[0].hasOwnProperty(key)) {
                if (key.indexOf("id") > -1 || key == "ID") {
                   
                    tbl += '';
                } else {
                                      

                    tbl += "<th id='cell"+key+"'>" + key + "</th>"
                }
               
            }
        }
        tbl += "</tr></thead>";
      
        jQuery(table).append(tbl);

    }
   

    if (rowData != null) {

        // Populate table with data in the current page.
        startIndex = (pageNum - 1) * rowsPerPage;
        endIndex = pageNum * rowsPerPage > rowData.length ?
            rowData.length - 1 : pageNum * rowsPerPage - 1;
        var colNames = getColNames(colData);
        var FullName = "";
        var colModelsArray = [];

        row = "<tbody>";

        for (i = startIndex; i <= endIndex; i++) {

            row += '<tr>';

            var o = rowData[i];
            // alert(o);
            //  var o = arrData[i];
            // Begin when row array is not null
            if (rowArrayReport != null) {
                var m = 0;
                var counter = rowArrayReport.length - 1;
                for (var key in o) {




                    // for (var m = 0; m <= rowArray.length - 1; m++) {

                    if (o.hasOwnProperty(key)) {
                        //    alert(rowArray[m] + " -> " + o[rowArray[m]])

                        if (rowArrayReport[m].indexOf("id") > -1 || rowArrayReport[m] === "id" || rowArrayReport[m] === "ID") {

                            //  if (chk == 1) {

                            row += '<td><input id="chk' + o[rowArrayReport[m]] + '" type="checkbox" class="del"  value="' + o[rowArrayReport[m]] + '"/></td>';

                            //  }

                        }

                        else if (editFlag == true && rowArrayReport[m] == field) {
                            // alert(parseJsonDate(o[key]));

                            row += '<td><a  id="' + o["id"] + '"  onclick="myJsFunc(this,innerWidth,innerHeight);" rel="' + editURL + o["id"] + '" href="#">' + o[rowArrayReport[m]] + '</a></td>';

                        }
                        else if (rowArrayReport[m].indexOf("Date") > -1 || rowArrayReport[m].indexOf("date") > -1) {
                            
                            // alert(parseJsonDate(o[key]));

                            row += '<td>' + parseJsonDate(o[rowArrayReport[m]]) + '</td>';

                        }

                        else if (rowArrayReport[m].indexOf("Fee") > -1 || rowArrayReport[m].indexOf("Amt") > -1) {

                            row += '<td>' + formatNumber(o[rowArrayReport[m]]) + '</td>';
                        }
                        else {

                            row += '<td>' + o[rowArrayReport[m]] + '</td>';
                        }


                    }
                    // }
                    if (m < counter) {
                        m++;
                    }
                    else { break; }





                }
            }
            // End when row array is not null
            else {
                //Begin when rowArray is null
                for (var key in o) {


                    if (o.hasOwnProperty(key)) {




                        if (key.indexOf("id") > -1 || key === "id" || key === "ID" ) {
                            // alert(parseJsonDate(o[key]));
                            row += '';
                        }

                        // alert(key + " -> " + o[key]);
                        else if (key.indexOf("Date") > -1 || key.indexOf("date") > -1 || key.indexOf("Time") > -1) {

                            row += '<td>' + parseJsonDate(o[key]) + '</td>';
                        }

                        else if (key.indexOf("Fee") > -1 || key.indexOf("Amt") > -1) {

                            row += '<td>' + formatNumber(o[key]) + '</td>';
                        }
                        else {
                            //  alert(key);
                            row += '<td>' + o[key] + '</td>';
                        }


                    }





                }
                //End when rowArray is null 
            }






            row += '</tr>';
        }

    }

    jQuery(table).append(row);
    jQuery(table).append("</tbody>");
    // Show pager row if there is more than one page
    pages = Math.floor(rowData.length / rowsPerPage);
    if (pages < rowData.length / rowsPerPage) {
        pages += 1;
    }
    if (pages > 1) {
        for (i = 0; i < pages; i++) {
            if (i == pageNum - 1) {
                pager += '<li class="active"><a href="#" >' + (i + 1) + '</a></li>';
            }
            else {
                pager += '<li><a href="#" >' + (i + 1) + '</a></li>'
            }
        }


        //  pager = '<tr><td colspan="9" class="pagerRow">' +
        //  pager + '</td></tr>';
        // $('#tblProducts').append(pager);
        jQuery('#pager').html(pager);

        // Pager link event handler
        //  $('#tblProducts tr td.pagerRow a').click(function (e) {
        jQuery('#pager li a').click(function (e) {
            e.preventDefault();
            var pNum = parseInt(jQuery(this).text());

            // PopulateTable(tableData, rowData, pNum);
            //  PopulateTable(tableData, rowData, pNum);
            PopulateReportTable(tableData, rowData, pNum, table, colArrayReport, rowArrayReport, sortArrayReport, false);
        });

        // Pager link event handler

    }

}


//************************END REPORT FUNCTIONS**********************************************************************************



//***************GLOBAL FUNCTIONS**********************************************************************************************
function ddl(ele, url, tbl, fld, criteria) {
   
    jQuery("#" + ele).empty();
    jQuery("#" + ele).append("<option value='0'>--Select --</option>");

    jQuery.getJSON(url, { tbl: tbl, fldName: fld, criteria: criteria}, function (data) {

        // Populate table from Json data returned from server. 
        jQuery("#" + ele).empty();
        jQuery("#" + ele).append("<option value='0'>--Select --</option>");
        
        jQuery.each(data, function (index, opt) {
            if (tbl == "") { 
            jQuery("#" + ele).append("<option value='" + opt[fld] + "'>" + opt[fld] + "</option>");

            }
            else {


                jQuery("#" + ele).append("<option value='" + opt + "'>" + opt + "</option>");

            }

        });
        
    }).fail(function (jqXHR, textStatus, errorThrown) {
        // Ajax fail callback function.
        alert(errorThrown);
    });
   
}

function getQuerystring(key, default_) {
    if (default_ == null) default_ = "";
    key = key.replace(/[\[]/, "\\\[").replace(/[\]]/, "\\\]");
    var regex = new RegExp("[\\?&]" + key + "=([^&#]*)");
    var qs = regex.exec(window.location.href);
    if (qs == null)
        return default_;
    else
        return qs[1];
}


function addFieldsList() {
    var fld = "";
    var cnt = jQuery("#hdCount").val();
    var id = "";
    var i = 0;
    var chkID = "";
    var numberChecked = jQuery('input:checkbox:checked').length
    jQuery("input.chk:checked").each(function () {

        i++;

        if (i < numberChecked) {
            fld += jQuery(this).closest("tr").find("input.txtFieldID").val() + "" + jQuery(this).closest("tr").find("input.txtFieldName").val() + ",";

        } else if (i == numberChecked) {

            fld += jQuery(this).closest("tr").find("input.txtFieldID").val() + "" + jQuery(this).closest("tr").find("input.txtFieldName").val();


        }

       
        jQuery("#hdSQL").val(fld); jQuery("#txtSQL").val(fld); jQuery("#txtSQL").show();


    })


    //loop thru the fieldlist and select if checkbox is checked.


}









function parseJsonDate(json) {
    var date = "";

    if (json != null && json != '') {
    var dateString = json.substr(6);
    var currentTime = new Date(parseInt(dateString));
    var month = currentTime.getMonth() + 1;
    var day = currentTime.getDate();
    var year = currentTime.getFullYear();
    date = month + "/" + day + "/" + year;

    }
    return date;
}
function formatNumber(num) {
    return num.toString().replace(/(\d)(?=(\d{3})+(?!\d))/g, "$1,")
}
function parsePotentiallyGroupedFloat(stringValue) {
    stringValue = stringValue.trim();
    var result = stringValue.replace(/[^0-9]/g, '');
    if (/[,\.]\d{2}$/.test(stringValue)) {
        result = result.replace(/(\d{2})$/, '.$1');
    }
    return parseFloat(result);
}




function addApp(e) {

    var se = "";
    var count;
    var getProjectResult = new Array();
    var getProjectResult1 = new Array();
    //  e.style
    var r = $o("#" + e.id).attr("rel");


    var ddl = "";

    jQuery.getJSON("/App/addApp", true, function (data) {

        // Populate table from Json data returned from server.
        getProjectResult = data.split("|");

        //  alert(getResult);
        ddl += "<br/><h4>Select App for User </h4><br/>"
        ddl += "<select id='proddl'  multiple>"
        "<select id='ddl'  multiple>"
        for (count = 0; count < getProjectResult.length - 1; count++) {

            getProjectResult1 = getProjectResult[count].split(":");
            ddl += "<option value='" + getProjectResult1[0] + "'>" + getProjectResult1[1] + "</option>";


            //alert(idPrefix + f)
        }
        ddl += "<input type='hidden'  id='hdProject' value='" + r + "' />"
        //  alert(ddl);

        jQuery.prompt(ddl, { buttons: { Submit: 0 }, submit: getddl });


    }).fail(function (jqXHR, textStatus, errorThrown) {
        // Ajax fail callback function.
        alert(errorThrown);
    });


   

}

function getddl() {

    getMultipleSelectVals('proddl');
    //   alert(selectedValues);
}

function getMultipleSelectVals(id) {
    jQuery('#' + id + ' :selected').each(function (i, selected) {
        vals[i] = $o(selected).val();
        textvals[i] = $o(selected).text();


    });

    var dataString = "{"
    dataString += " 'pList': '" + vals + "',"
    dataString += " 'userID': '" + $o("#hdProject").val() + "'"
    dataString += "}";

   jQuery.ajax({
        type: "POST",
        url: "user.aspx/mapProjectToUser",
        data: dataString,
        contentType: "application/json; charset=utf-8",
        dataType: "json",
        success: OnSuccess,
        failure: function (response) {
            alert(response.d);
        }
    });
    function OnSuccess(response) {
        jQuery("#tbl").load("userCall.aspx?random=" + Math.random() * 99999);
    }


}



function removeProject(e) {

    var j = e.id.split("_")


    var g = document.getElementById('ListProject_' + j[1]);
    var ID = g.options[g.selectedIndex].value;

    //   alert(ID);

    $o.ajax({
        url: "../ajaxCall_PPM/deltblbySQL.ashx",
        data: "table=tblProjectMap_PPM" + "&criteria= username='" + j[1] + "' and projectID='" + ID + "'",
        type: "GET",
        success: function (res) {
            $o("#tbl").load("userCall.aspx?random=" + Math.random() * 99999);

        }
    });

}


function getMultipleSelection(elementName, array) {
    var selected = new Array();
    var mySelect = document.getElementById(elementName);
    for (j = 0; j < mySelect.options.length; j++) {
        if (mySelect.options[j].selected) {
            selected.push(mySelect.options[j].value);
        }
    }
    if (array != 'true') return selected.toString();
    else return selected;


}
function clear_form_elements(ele) {
    jQuery(ele).find(':input').each(function () {
        switch (this.type) {
            case 'password':
            case 'password':
            case 'select-multiple':
            case 'select-one':
            case 'text':
            case 'textarea':
               jQuery(this).val('');
                break;
            case 'checkbox':
                break;
            case 'checkbox':

                this.checked = false;
        }
    });

}


function createFormWizard(frm) {




    var form = jQuery(frm);
    form.validate({
        errorPlacement: function errorPlacement(error, element) { element.before(error); },
        rules: {
            confirm: {
                equalTo: "#password"
            }
        }
    });
    form.children("div").steps({
        headerTag: "h3",
        bodyTag: "section",
        transitionEffect: "slideLeft",
        onStepChanging: function (event, currentIndex, newIndex) {
            form.validate().settings.ignore = ":disabled,:hidden";
            return form.valid();
        },
        onFinishing: function (event, currentIndex) {
            form.validate().settings.ignore = ":disabled";
            return form.valid();
        },
        onFinished: function (event, currentIndex) {
            alert("Submitted!");
        }
    });
}

function validateTime(t) {
    var time = document.getElementById(t).value;
    //alert(time);
    var re = /^([0-9]|0[0-9]|1[0-9]|2[0-3]):[0-5][0-9]$/;


    if (re.test(time)) {
        //alert(re.test(time));
        document.getElementById(t).innerHTML = "Time is valid";
    } else {
        document.getElementById("result").innerHTML = "Time is invalid";
    }

}


   
function exportTableToCSV($table, filename) {
    var $headers = $table.find('tr:has(th)')
        , $rows = $table.find('tr:has(td)')
        // Temporary delimiter characters unlikely to be typed by keyboard
        // This is to avoid accidentally splitting the actual contents
        , tmpColDelim = String.fromCharCode(11) // vertical tab character
        , tmpRowDelim = String.fromCharCode(0) // null character
        // actual delimiter characters for CSV format
        , colDelim = '","'
        , rowDelim = '"\r\n"';
    // Grab text from table into CSV formatted string
    var csv = '"';
    csv += formatRows($headers.map(grabRow));
    csv += rowDelim;
    csv += formatRows($rows.map(grabRow)) + '"';
    // Data URI
    var csvData = 'data:application/csv;charset=utf-8,' + encodeURIComponent(csv);
    $(this)
        .attr({
            'download': filename
            , 'href': csvData
            //,'target' : '_blank' //if you want it to open in a new window
        });
    //------------------------------------------------------------
    // Helper Functions 
    //------------------------------------------------------------
    // Format the output so it has the appropriate delimiters
    function formatRows(rows) {
        return rows.get().join(tmpRowDelim)
            .split(tmpRowDelim).join(rowDelim)
            .split(tmpColDelim).join(colDelim);
    }
    // Grab and format a row from the table
    function grabRow(i, row) {

        var $row = $(row);
        //for some reason $cols = $row.find('td') || $row.find('th') won't work...
        var $cols = $row.find('td');
        if (!$cols.length) $cols = $row.find('th');
        return $cols.map(grabCol)
            .get().join(tmpColDelim);
    }
    // Grab and format a column from the table 
    function grabCol(j, col) {
        var $col = $(col),
            $text = $col.text();
        return $text.replace('"', '""'); // escape double quotes
    }
}





//*****************************END GLOBAL FUNCTIONS***********************************************************