var popupNotification = $("#ToastBox").kendoNotification().data("kendoNotification"); // Sets #ToastBox to be a Notification Container


$(document).ready(function () {

    // There is no property to give size for grid filter texbox yet. So until it is added we are giving size with that workaround
    // Since we are not using row filter type on the grid for now, this function is useless
    $("[data-role=filtercell]").find(".k-autocomplete.k-header").addClass("GridFilterBox");
    $("[data-role=filtercell]").find(".k-widget.k-numerictextbox").addClass("GridFilterBox");
    $("[data-role=filtercell]").find(".k-widget.k-datepicker.k-header").addClass("GridFilterBox");
    $("[data-role=filtercell]").find(".k-widget.k-combobox.k-header").addClass("GridFilterBox");

    var FilterHeaderWidth = $(".grid-filter-header");

    FilterHeaderWidth.each(function () {
        var pwidth = $(this).parent('th').width();
        var InnerWidth = pwidth - 30 + "px"
        $(this).find(".GridFilterBox").css("width", InnerWidth);

    });
    //----------------------------

    // We are adding tooltip text to grid headers and grid cells if it is defined in grid schema
    var MainGrid = $("#DefaultGrid").data("kendoGrid");

    if (MainGrid) {

        MainGrid.thead.kendoTooltip({
            filter: "th[data-tooltip-text]",
            content: function (e) {
                var target = e.target;
                return $(target).attr("data-tooltip-text");
            }
        });

        MainGrid.table.kendoTooltip({
            filter: "td[data-cell-tooltip=show]",
            content: function (e) {
                var target = e.target;
                if ($(target).attr("data-cell-tooltip") == "show") {
                    return $(target).text();
                }
            }
        });

    }


    //----------------------------



});

