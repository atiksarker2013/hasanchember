function DoNothing() {
    return false;
}

$(window).load(function () {
    SideMenuManager(); // It is decides whether menu will be hidden or not according to window size.
});

$(window).resize(function () {
    SideMenuManager(); // It is decides whether menu will be hidden or not according to window size.
});

// It is decides whether side menu will be hidden or not according to window size.
function SideMenuManager() {

    var DocumentWidth = $(document).width();

    if (DocumentWidth <= 768)
    {
        $('#SideMenu').addClass('SideMenu-Hide');

        $('.MainContent').addClass('SideMenu-Merge');
        
        if ($('.Header').hasClass('SideMenu-Open-Right-Panel')) {
            $('.Header').removeClass('SideMenu-Open-Right-Panel')
        }
        if ($('#Header').hasClass('SideMenu-Merge-Header')) {
            $('#Header').removeClass('SideMenu-Merge-Header')
        }
    }

    if (DocumentWidth > 768) {
        $('#SideMenu').removeClass('SideMenu-Hide');

        $('.MainContent').removeClass('SideMenu-Merge');
        
        if ($('.Header').hasClass('SideMenu-Open-Right-Panel')) {
            $('.Header').removeClass('SideMenu-Open-Right-Panel')
        }
        if ($('#Header').hasClass('SideMenu-Merge-Header')) {
            $('#Header').removeClass('SideMenu-Merge-Header')
        }
    }

    
    return false;
}
//----------------------------


// Function for closing or opening the side menu
function SideMenuClickManager() {

    $('#SideMenu').toggleClass('SideMenu-Hide');

    $('.MainContent').toggleClass('SideMenu-Merge');
    
    if ($('.Header').hasClass('SideMenu-Open-Right-Panel')) {
        $('.Header').removeClass('SideMenu-Open-Right-Panel')
    }
    if ($('#Header').hasClass('SideMenu-Merge-Header')) {
        $('#Header').removeClass('SideMenu-Merge-Header')
    }

    return false;

}
//----------------------------

$(function () {
    $('[data-toggle="popover"]').popover()
})

$(document).ready(function () {

    

    // Updates the panel icon when we open or close it
    $('.panel .fa').click(function () {
        var el = $(this).parents(".panel").children(".panel-body");
        if ($(this).hasClass("fa-chevron-down")) {
            $(this).removeClass("fa-chevron-down").addClass("fa-chevron-up");
            el.slideUp(200);
        } else {
            $(this).removeClass("fa-chevron-up").addClass("fa-chevron-down");
            el.slideDown(200);
        }
    });
    //----------------------------

    // Open or close side menu when we click the menu button
    $('#btnSideMenu').click(function (e) {
        SideMenuClickManager();
    });
    //----------------------------

    // Open or close side menu sub menus when we click to first level of menu items
    $('#Side-Accordion').find('.Sub-Accordion a').click(function () {

        $(".Sub-AccordionList").not($(this).next()).slideUp('fast');
        $(this).next().slideToggle('fast');

    });
    //----------------------------


    // Loading Spinner
    var opts = {
        lines: 11, // The number of lines to draw
        length: 10, // The length of each line
        width: 10, // The line thickness
        radius: 24, // The radius of the inner circle
        corners: 0.5, // Corner roundness (0..1)
        rotate: 32, // The rotation offset
        direction: 1, // 1: clockwise, -1: counterclockwise
        color: '#000', // #rgb or #rrggbb or array of colors
        speed: 1, // Rounds per second
        trail: 50, // Afterglow percentage
        shadow: true, // Whether to render a shadow
        hwaccel: false, // Whether to use hardware acceleration
        className: 'spinner', // The CSS class to assign to the spinner
        zIndex: 2e9, // The z-index (defaults to 2000000000)
        top: '50%', // Top position relative to parent
        left: '50%' // Left position relative to parent
    };
    var target = document.getElementById('foo');
    var spinner = new Spinner(opts).spin(target);
    //----------------------------


    // Sets with of labels in the list type of "Kendo Form" Container
    var FormLabelMaxWidth = 0;
    $('.Form-ListContainer label').each(function () {
        w = $(this).outerWidth(true);
        if (w > FormLabelMaxWidth)
            FormLabelMaxWidth = w;
    });
    
    $('.Form-ListContainer label').width(FormLabelMaxWidth);
    //----------------------------

    // Simple Tab
    $('.TabStrap a').click(function (e) {
        e.preventDefault()
        $(this).tab('show')
    })
    //----------------------------

    $('#SideMenu').height($(document).height()); // Decides side menu height according to windows height.

    $('.Kendo-TextBox').addClass('k-textbox'); // Sets CSS class to turn text boxs to a Kendo Textbox

    $(".Kendo-Numeric").kendoNumericTextBox();

    $('.ToolTips').tooltip();

    $('.PopOvers').popover();

    $(".WarningArea").alert();

    $('.ModalOpened').modal();

    $(".Kendo-Combo").kendoComboBox();

    $(".Kendo-DropDown").kendoDropDownList();

    $(".Kendo-Button").kendoButton();

    $(".Kendo-DateTimePicker").kendoDateTimePicker();

    $(".Kendo-DatePicker").kendoDatePicker();

    $(".Kendo-Tab").kendoTabStrip();

    // Example fow how to show a notification
    $("#ShowToast").click(function () {
        popupNotification.show('Hola.. This is a message', "error");
    });
    //----------------------------
    


    

});

