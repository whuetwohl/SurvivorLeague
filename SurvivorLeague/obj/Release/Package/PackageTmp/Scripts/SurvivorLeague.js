
function TeamToWinFade(Winner, Loser) {
    //$().ready(function () {
        $("#" + Winner).fadeTo('0.5', 1).css({ "cursor": "not-allowed" });
        $("#" + Loser).fadeTo('0.5', 0.5).css({ "cursor": "pointer" });
    //});
};

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
};

function ShowMenu(menuClass) {
    $("." + menuClass).slideDown(250);
};

function HideMenu(menuClass) {
    $("." + menuClass).slideUp(250);
};

//function SwapColors(id, fcolor, bcolor) {
//    $(id).css({ "color": fcolor, "background-color": bcolor });
//};

function AddBorder(element) {
    $(element).addClass('border');
};
function RemoveBorder(element) {
    $(element).removeClass('border');
};

function DimSelectedTeams(id) {
    $('#' + id).css({ 'opacity': .5 });
};

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

    //$(document).ready(function () {
    //    $('#weekly-matchups').click(function (e) {
    //        $('#helmet').show().css({ "z-index": 2 }).animate({
    //            top: e.pageY,
    //            left: e.pageX
    //        }, 800);
    //    });
    //});
})