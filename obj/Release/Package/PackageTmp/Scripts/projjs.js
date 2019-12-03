$(document).ready(function () {

    DdlGroups();
    documnetTypeStatus();
    warehouse();
    shipingMethod();
    carrier();
});

function DdlGroups() {

    var option = "<option></option>";
    $.ajax({
         type: "GET",
        contentType: "application/json; charset=utf-8",
        url: "/sale/tabledata/",

        data: 'tblname=Groups',
       
        success: function (Result) {
        $.each(Result, function (key, value) {
             $("#ddlgroup").append($(option).val(value.ID).html(value.Description));
            });
           
        },
        error: function (Result) {
            alert("Error");
        }
    });

}

function documnetTypeStatus() {

    var option = "<option></option>";
    $.ajax({
        type:"GET",
        contentType:"application/json; charset=utf-8",
        url:"/sale/datawithclause/",
        data: 'tblname=DocumentStatus&clause=where DocumentType=1',

        success: function (Result) { 
            $.each(Result, function (key, value) {

            $("#ddlstatus").append($(option).val(value.ID).html(value.Description));
            });

        },
        error: function (Result) {
            alert("Error");
        }



    });





} 

function warehouse() {

    var option = "<option></option>";
    $.ajax({
        type: "GET",
        contentType: "application/json; charset=utf-8",
        url: "/sale/tabledata/",

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

function shipingMethod() {

    var option = "<option></option>";
    $.ajax({
        type: "GET",
        contentType: "application/json; charset=utf-8",
        url: "/sale/tabledata/",

        data: 'tblname=ShippingMethods',

        success: function (Result) {
            $.each(Result, function (key, value) {

                $("#ddlshipmethod").append($(option).val(value.ID).html(value.Description));
            });

        },
        error: function (Result) {
            alert("Error");
        }
    });

}

 function carrier() {

    var option = "<option></option>";
    $.ajax({
        type: "GET",
        contentType: "application/json; charset=utf-8",
        url: "/sale/Carrierdata/",

        data: 'tblname=Carrier',

        success: function (Result) {
            $.each(Result, function (key, value) {

                $("#ddlcarrier").append($(option).val(value.ID).html(value.Description));
            });

        },
        error: function (Result) {
            alert("Error");
        }
    });

}  


function mfgpartnumber() {



    var option = "<option></option>";
    $.ajax({
        type: "GET",
        contentType: "application/json; charset=utf-8",
        url: "/sale/MfgpartNumber/",

        data: 'tblname=products',

        success: function (Result) {
            $.each(Result, function (key, value) {

                $("#ddlcarrier").append($(option).val(value.ID).html(value.Description));
            });

        },
        error: function (Result) {
            alert("Error");
        }
    });

}


function getItemInfoAutofill() {
    $('#txtItemNum').autocomplete({
        source: function (request, response) {

            var obj = {};
            obj.term = request.term;
            var jsonData = JSON.stringify(obj);
            $.ajax({
                url: "/sale/Handler/LinestabForProducts.ashx", 
                type: "POST",
                data: jsonData,
                success: function (data) {
                    //console.log("result", data);S
                    //response($.map(data, function (item) {
                    //    return {
                    //        company: item.company,
                    //        ID: item.ID

                    //    }
                    //}))
                    var parsedata = JSON.parse(data);
                    var nameArray = $.map(parsedata, function (item) {
                        return { Description: item.Description, ID: item.ID };
                    });
                    response(nameArray);
                },
                error: function (XMLHttpRequest, textStatus, errorThrown) {
                    alert(textStatus);
                }
            });
        },
        focus: function (event, ui) {
            $('#txtItemNum').val(ui.item.ID);
            return false;
        },
        select: function (event, ui) {
            $('#txtItemNum').val(ui.item.ID);
            return false;
        },
    }).data("ui-autocomplete")._renderItem = function (ul, item) {
        return $("<li>")
            .append("<a>Description:" + item.Description + "<br>ID: " + item.ID + "</a>")
            .appendTo(ul);
    };
} 
