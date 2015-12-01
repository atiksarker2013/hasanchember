$(document).ready(function () {
    document.onkeypress = keyPress;
    SetWinTimeout();
});
var Focus_Global_Browser_Version;
// Calculate Kendo UI Window Max Height
var windowHeight = parseInt(window.innerHeight);
var MaxKendoWindowHeight = windowHeight - 200;

function keyPress(e) {
    var x = e || window.event;
    var key = (x.keyCode || x.which);
    if (key == 13 || key == 3) {
        $.each($('.btnActive'), function () {
            if ($(this).closest(".modal-dialog").parent().attr('class') == "modal fade in")
                $(this).click();
        });
        $('.k-primary').click();
    }
    ResetTimer();
}
////getting global data to script  
//$.getJSON('Script/GetGlobalVarible', function (data) {
//    Focus_Global_Browser_Version = data.FocusAppVersion;
//    console.log(Focus_Global_Browser_Version);
//});



var timeout = 1200000; // 20 minutes

var wintimeout;

function SetWinTimeout() {
    wintimeout = window.setTimeout(redirectWindow, timeout); // In millisecods
}
 
function redirectWindow() {
    if ($('#LoginBox').length==0) {
        window.location.replace('Lock');
    }
}

function ResetTimer() {
    window.clearTimeout(wintimeout);
    SetWinTimeout();
}

$(document).click(function (event) {
  //when user clicks remove timeout and reset it
    ResetTimer();
});


function strfilter(kendofilter) {
    
    var filters = kendofilter == undefined ? "" : kendofilter.filters;
    var logic = kendofilter == undefined ? "" : kendofilter.logic;

    var data = "";
    if (filters != null && filters.length > 0) {
        for (var i = 0; i < filters.length; i++) {
            var filter = filters[i];
            if (data.length > 0)
                data += "~" + logic + "~";
            if (filter.logic != null) {
                if (filter.filters.length > 0) {
                    var innerData = "";
                    for (var j = 0; j < filter.filters.length; j++) {
                        var innerFilter = filter.filters[j];
                        if (innerData.length > 0)
                            innerData += "~" + filter.logic + "~";

                        innerData += innerFilter.field + "~" + innerFilter.operator + "~" + innerFilter.value;
                    }

                    data += "(" + innerData + ")";
                }
            } else {
                var data1 = filter.field + "~" + filter.operator + "~" + filter.value;
                if (filters.length == 1)
                    data = "(" + data1 + ")";
                else if (filters.length >= 2 && i == 0) {
                    data +=  data1 ;
                } else if (filters.length >= 2 && i == 1)
                    data = "(" + data + data1 + ")";
                else {
                    data = data + "(" + data1 + ")";
                }
            }
        }

    }
    if (data == "") data = "null";
    return data;
}

function strSort(sort) {

    var sortData = sort == undefined || sort.length == 0 ? "null" : sort[0]['field'] + "~" + sort[0]['dir'];
    return sortData;
}
