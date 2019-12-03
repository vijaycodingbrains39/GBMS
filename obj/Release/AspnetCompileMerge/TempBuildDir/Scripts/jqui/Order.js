
$(document).ready(function () {

    Currency();
    paymentterms();
    Taxes();
    warehouse();
    Department();
    Divisions();
    setdate();
  //   justbackgroundcolour();
});



var Add = "";
var City = "";
var Region = "";
var Country = "";
var PostalCode = "";
function warehouse() {

    var option = "<option></option>";
    $.ajax({
        type: "GET",
        contentType: "application/json; charset=utf-8",
        url: "/sale/tabledata/",
        async: false,
        data: 'tblname=warehouses',

        success: function (Result) {
            $.each(Result, function (key, value) {


                $("#ddlwarehouse").append($(option).val(value.ID).html(value.Description));
            });

        },
        error: function (Result) {
            alert("Error");
        }
    });

}

function Department() {

    var option = "<option></option>";
    $.ajax({
        type: "GET",
        contentType: "application/json; charset=utf-8",
        url: "/sale/tableDepartmentdata/",
        async: false,
        data: 'tblname=Departments&Column1=DepartmentID&Column2=DepartmentName',

        success: function (Result) {
            $.each(Result, function (key, value) {


                $("#ddlDepartment").append($(option).val(value.DepartmentID).html(value.DepartmentName));

            });

        },
        error: function (Result) {
            alert("Error");
        }
    });

}

function Divisions() {

    var option = "<option></option>";
    $.ajax({
        type: "GET",
        contentType: "application/json; charset=utf-8",
        url: "/sale/tableDevisiondata/",

        data: 'tblname=Divisions&Column1=DivisionID&Column2=DivisionName',

        success: function (Result) {
            $.each(Result, function (key, value) {


                $("#ddlDivisions").append($(option).val(value.DivisionID).html(value.DivisionName));
            });

        },
        error: function (Result) {
            alert("Error");
        }
    });

}

function Currency() {

    var option = "<option></option>";
    $.ajax({
        type: "GET",
        contentType: "application/json; charset=utf-8",
        cache: false,
        processData: true,
        url: "/sale/tableCurrencydata/",
        async: false,
        data: 'tblname=CurrencyTypes&Column1=CurrencyID&Column2=CurrencyType',

        success: function (Result) {

            $.each(Result, function (key, value) {


                $("#ddlCurrency").append($(option).val(value.CurrencyID).html(value.CurrencyType));


            });

        },
        error: function (Result) {
            alert("Error");
        }
    });

}

function setdate() {
    var d = new Date();
    var strDate = d.getFullYear() + "/" + (d.getMonth() + 1) + "/" + d.getDate();
    $('#OrderDate').val(strDate);
    $('#RequiredDate').val(strDate);

}

function paymentterms() {

    var option = "<option></option>";
    $.ajax({

        type: "GET",
        url: "/Sale/tableTermdata",
        contentType: "application/json; charset=utf-8",
        data: 'tblname=TermsCodes&Column1=ID&Column2=TermsDescription',
        async: false,
        success: function (Result) {

            $.each(Result, function (key, value) {



                $("#ddlpaymentterm").append($(option).val(value.ID).html(value.TermsDescription));
            });
        },
        error: function () {

            alert("Something Went Wrong");
        }


    });

}

function getautocomplete() {
    $('#CustomerID').autocomplete({
        source: function (request, response) {

            var obj = {};
            obj.term = request.term;
            var jsonData = JSON.stringify(obj);
            $.ajax({
                url: "Handler/Jqfastretrival.ashx",
                type: "POST",
                data: jsonData,
                success: function (data) {
                    var parsedata = JSON.parse(data);
                    var nameArray = $.map(parsedata, function (item) {
                        return { company: item.company, ID: item.ID };
                    });
                    response(nameArray);
                },
                error: function (XMLHttpRequest, textStatus, errorThrown) {

                }
            });
        },
        focus: function (event, ui) {
            $('#CustomerID').val(ui.item.ID);
            return false;
        },
        select: function (event, ui) {
            $('#CustomerID').val(ui.item.ID);
            GetdataByCompanyID(ui.item.ID);
            return false;
        },
    }).data("ui-autocomplete")._renderItem = function (ul, item) {
        return $("<li>")
            .append("<a>Company:" + item.company + "<br>ID: " + item.ID + "</a>")
            .appendTo(ul);
    };
}

function Taxes() {

    var option = "<option></option>";
    $.ajax({

        type: "GET",
        url: "/Sale/tableTaxdata",
        contentType: "application/json; charset=utf-8",
        data: 'tblname=Taxes&Column1=TaxID&Column2=TaxDescription',
        async: false,
        success: function (Result) {

            $.each(Result, function (key, value) {
                $("#ddtaxcode").append($(option).val(value.TaxID).html(value.TaxDescription));

            });
        },
        error: function () {

            alert("Something Went Wrong");
        }


    });

}

function GetdataByCompanyID(CustomerID) {

    var CustomerData = '';
    $.ajax({

        type: "GET",
        url: "/Sale/GetdataByCompanyID",
        contentType: "application/json; charset=utf-8",
        data: 'CustomerID=' + CustomerID,
        success: function (Result) {

            Add = Result[0].Address;
            City = Result[0].City;
            Region = Result[0].Region;
            Country = Result[0].Country;
            PostalCode = Result[0].PostalCode;

            var address = Add + ',' + City + ',' + Region + ',' + Country + ',' + PostalCode;
            $('#OrderCompany').html(Result[0].company);
            $('#address').html(address);
            $('#contactName').html(Result[0].ContactName);
            //   $('#Name').html(Result[0].ContactName);
            $('#Name').val(Result[0].ContactName);
            $('#phonenumber').val(Result[0].Phone);
            $('#OrderCompany').val(Result[0].Company);
            $('#ddlpaymentterm').val(Result[0].TermsCode).attr("selected", "selected");
            $('#ddtaxcode').val(Result[0].SalesTaxCodeID).attr("selected", "selected");
            $('#ddlCurrency').val(Result[0].CurrencyType).attr("selected", "selected");

        }


    });

}


function clickedOnSavebtn() {
    var tab = $('ul#tab_wrappers').find('li.active a').text();
    if (tab === 'Header') {

        alert('header');
        SaveOrder();

    } else if (tab === 'Shipping') {


        alert('shipping');
        ShipdataInsupd();
    }

    /*else if (tab === 'Lines') { } else if (tab === 'Notes') { } else if (tab === 'Commission') { } else if (tab === 'RelatedDocs') { } else if (tab == 'Attachments') { } else if (tab === 'CC#') { } else if (tab === 'Section') { } else if (tab === 'options') { }*/

    

}


function SaveOrder() {

    var orderRequest = new Object();
    orderRequest.ID = $("#salesorderID").val();
    orderRequest.OrderDate = $("#OrderDate").val();
    orderRequest.ArrivalDate = $("#RequiredDate").val();
    orderRequest.PONumber = $("#custPO").val();
    orderRequest.AltPONumber = $("#altpo").val();
    orderRequest.OrderTermsCode = $("#ddlpaymentterm").find(":selected").val();// $(dropdowname).find(":selected").val();
    orderRequest.SalesTaxCodeID = $("#ddtaxcode").find(":selected").val();
    orderRequest.CurrencyID = $("#ddlCurrency").find(":selected").val();
    orderRequest.CurrencyExchangeRate = $("#txtexchange").val();
    orderRequest.ContactName = $("#contactName").val();
    orderRequest.ContactPhone = $("#phonenumber").val();
    orderRequest.ContactFax = $("#idfax").val();
    orderRequest.ContactEmail = $("#ContactEmail").val();
    orderRequest.WrhsID = $("#ddlwarehouse").val();
    orderRequest.DepartmentID = $("#ddlDepartment").find(":selected").val();
   // orderRequest.BackOrder = $("#BackOrder").val();
    orderRequest.PartialOk = $("#ddlPartialOK").find(":selected").val();
    orderRequest.DivisionID = $("#ddlDivisions").find(":selected").val();
    orderRequest.Priority = $("#ddlPriority").find(":selected").val();
    orderRequest.BackOrder = $("#ddlbackorder").find(":selected").val();
    orderRequest.BackOrder = $("#ddlPartialOK").find(":selected").val();
    orderRequest.CustomerID = $("#CustomerID").val();
   
    orderRequest.OrderCompany = $("#OrderCompany").html();
    orderRequest.ShipAddress = Add;
    orderRequest.ShipCity = City;
    orderRequest.ShipRegion = Region;
    orderRequest.ShipCountry = Country;
    orderRequest.ShipPostalCode = PostalCode;
   var sts = $('#spnOrdersts').html();
   console.log(sts);
    if (sts === '') {
        sts = 'New';
        orderRequest.OrderStatus = sts; 
    }
    else {

        orderRequest.OrderStatus = sts;
    }   
    if ($('#chksalespreapproved').is(":checked")) {
        orderRequest.salespreapproved = 1;
    } else {

        orderRequest.salespreapproved = 0;
    }
   //if ($('#spnOrdersts').html() != null || $('#spnOrdersts').html() != '') {
    //  orderRequest.OrderStatus = $('#spnOrdersts').html();
    //} else {

    //    orderRequest.OrderStatus = 'New';
    //}
    $.ajax({
        type: "POST",
        url: "/Sale/savedata/",
        contentType: "application/json; charset=utf-8",
        data: JSON.stringify(orderRequest),
        cache: false,
        success: function (Result) { 

            $("#OrdertblID").empty();
            // alert(Result);
           var parsedata = JSON.parse(Result);
            var html = '';

            for (var j = 0; j < parsedata.Table.length; j++) {
           html += `<tr> 
                         <td>${parsedata.Table[j].ID}</td>
                                                         <td>${parsedata.Table[j].OrderDate}</td>
                                                         <td>${parsedata.Table[j].Company}</td>
                                                          </tr>`;
            }
            $('.Ordertable').html(html);
        }
   });
} 

//----------------------------------------------------------------------------------------------------------------------------------------------------

function ShipdataInsupd() {

    var Shipdata = new Object();
    Shipdata.NewShipToID = $("#NewShipToID").val();
    Shipdata.ShipCompany = $("#ShipCompany").val();
    Shipdata.ShipAddress = $("#ShipAddress").val();
    Shipdata.ShipPostalCode = $("#ShipPostalCode").val();
    Shipdata.ShipName = $("#ShipName").val();
    Shipdata.ShipPhone = $("#ShipPhone").val();
    Shipdata.ShipmentAccountNo = $("#ShipmentAccountNo").val();
    Shipdata.FOB = $("#FOB").val();
    Shipdata.FOBDescription = $("#FOBDescription").val();
    Shipdata.ThirdPartyShipID = $("#ThirdPartyShipID").val();
    Shipdata.RMAExpirationDays = $("#RMAExpirationDays").val();
    Shipdata.OrderStatus = $("#spnOrdersts").html();
    Shipdata.orderID = $("#salesorderID").val();
    

    $.ajax({
        type: "POST",
        url: "/Sale/ShipdataInsupd/",
        contentType: "application/json; charset=utf-8",
        data: JSON.stringify(Shipdata),
        success: function (Result) {
            $("#OrdertblID").empty();
            // alert(Result);
            var parsedata = JSON.parse(Result);
            $('#modaldata').html(parsedata.Table[0].Message).css("font-weight", "Bold").css("color", "green");
            $('#Mymodal').modal(); 
            $('#Mymodal').show();
          
        }
    });
} 


function newsalesOrderId() {

    $.ajax({
    type: "GET",
        url: "/sale/newsalesId",
        contenttype: "application/json; charset=utf-8",
        data: '',
        success: function (result) {
        alert(result);
        },
        error: function (err) {
            alert(err);
        }
      });



}
//---------------------------------------------------------------------------------traversing for background colour set ---------------------------------

function justbackgroundcolour() {


    $("#OrdertblID tr").each(function () {
        
        var currentRow = $(this);

        var col1_value = currentRow.find("td:eq(0)").text();

        if (col1_value.trim() === $('#salesorderID').html()) {

            currentRow.css("background-color", "orange");
        }
    });

}




//------------------------------------------------------------------------------------------------------ Opening  window -------

function winOpen(url) {
    //-to open the selected url at once time
    //return window.open(url, getWinName(url), 'left=30,top=30,width=1300,height=650,toolbar=1,resizable=0');
    var popup;
    //-to open the selected url at once time
    //return window.open(url, getWinName(url), 'left=30,top=30,width=1300,height=650,toolbar=1,resizable=0');
    popup = window.open(url, getWinName(url), 'left=30,top=30,width=1300,height=650,toolbar=1,resizable=0');
    popup.focus();
}
function winClose(url) {
    var win = window.open("", getWinName(url));
    win.close();
}
function getWinName(url) {
    return "win" + url.replace(/[^A-Za-z0-9\-\_]*/g, "");
}

