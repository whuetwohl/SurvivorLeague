
function TeamToWinFade(Winner, Loser) {
    //$().ready(function () {
    $("#" + Winner).fadeTo('0.5', 1).css({ "cursor": "not-allowed" });
    $("#" + Loser).fadeTo('0.5', 0.5).css({ "cursor": "pointer" });
    //});
}

//function ApplyColors(color1, color2) {
//    //$("body").css({ "color": color1, "background-color": color2 });
//    $(".team-colors").css({ "color": color1, "background-color": color2 });
//    $(".team-colors-reversed").css({ "color": color2, "background-color": color1 });
//};

function SwapColorScheme() {
    $(".team-colors").addClass("tc").removeClass("team-colors");
    $(".team-colors-reversed").addClass("tcr").removeClass("team-colors-reversed");
    $(".tc").addClass("team-colors-reversed").removeClass("tc");
    $(".tcr").addClass("team-colors").removeClass("tcr");
}

function ShowMenu(menuClass) {
    $("." + menuClass).slideDown(250);
}

function HideMenu(menuClass) {
    $("." + menuClass).slideUp(250);
}

//function SwapColors(id, fcolor, bcolor) {
//    $(id).css({ "color": fcolor, "background-color": bcolor });
//};

function AddBorder(element) {
    $(element).addClass('border');
}
function RemoveBorder(element) {
    $(element).removeClass('border');
}

function DimSelectedTeams(id) {
    $('#' + id).css({ 'opacity': .5 });
}

//function SelectTeam(element) {
//    $('.select-team').css({ 'border': 'none' });
//    $(element).css({ 'border': 'solid', 'border-color': 'white'});
//};

$(document).ready(function () {
    $('.date-picker').datepicker({
        //showButtonPanel: true,
        changeMonth: true,
        changeYear: true,
        showOtherMonths: false,
        //selectOtherMonths: false
        yearRange: "-100:+0"
    });
});

$("#PlayerCount").change(function () {
    //alert($(this).val());
});

//$(".add-team").click(function () {
//    $(this).addClass("fa-minus remove-team").removeClass("fa-plus add-team");
//});

//$(".remove-team").click(function () {
//    $(this).addClass("fa-plus add-team").removeClass("fa-minus remove-team");
//});

$(document).on('click', '.add-team', function (e) {
    // TODO: Put in Ajax to add the team to the VM, listing the line with a fa-minus at the end
    // and put in similar code to update if minused

    $(this).addClass("fa-minus remove-team").removeClass("fa-plus add-team");
    let index = $('#Invitees .row').length;
    e.preventDefault();
    let newItem = '<input name="Invitees.Index" type="hidden" value="' + index + '" />\
        <div class="row">\
                <div class="col-4">\
                    <input class="form-control text-box single-line" id="Invitees_' + index + '__Name" name="Invitees[' + index + '].Name" placeholder="Player Name" type="text" />\
                </div>\
                <div class="col-5">\
                    <input class="form-control text-box single-line" data-val="true" data-val-email="The Player Email field is not a valid e-mail address." id="Invitees_' + index + '__Email" name="Invitees[' + index + '].Email" placeholder="Email" type="email" />\
                </div>\
                <div class="col-2">\
                    <select class="form-control" data-val="true" data-val-number="The field Qty must be a number." data-val-required="The Qty field is required." id="Invitees_' + index + '__NumberOfEntries" name="Invitees[' + index + '].NumberOfEntries"><option value="">Teams</option>\
                        <option value="1" selected>1</option>\
                        <option value="2">2</option>\
                    </select>\
                </div>\
                <div class="col-1 fa fa-plus add-team"></div>\
            </div>'
    $('#Invitees').append(newItem);


});

$(document).on('click', '.remove-team', function () {
    //$(this).addClass("fa-plus add-team").removeClass("fa-minus remove-team");
    $(this).parent('.row:first').remove();
});


//$(".NoSelection").click(function () {
//    if (!this.classList.contains('PastGame')) {
//        $(".CurrentSelection").removeClass("CurrentSelection").addClass("NoSelection");
//        $(this).removeClass("NoSelection").addClass("CurrentSelection");
//        //pulse(this);
//        //$(".CurrentSelection").css({ 'border-color': 'pink' });
//        // $(".Selected").css({ opacity: 0.5 });
//        //$(".NoSelection").animate({ opacity: .7 }, 'slow');
//        alert('script in file');
//    }
//});

//$().ready(function () {
//    $('.dropdown').click(function () {
//        $('.dropdown-menu').fadeToggle();
//    });
//});

