var LastId = 0;
var NoMoredata = false;
var inProgress = false;

$(document).ready(function () {

    LoadPartialViewArtikel();

    $(window).on("scroll", function () {
        var docHeight = $(document).height();
        var winScrolled = $(window).height() + $(window).scrollTop();

        if ((docHeight - winScrolled) < 1 && NoMoredata == false && inProgress == false) {

            console.log("module scrolled to bottom");

            inProgress = true;
            $("#loadingdiv").show();
            LoadPartialViewArtikel();
        }
    });
})


function LoadPartialViewArtikel()
{
    /* Request the partial view with .get request. */
    $.get('/Home/RequestArtikelPartial/?LastId=' + LastId, function (data) {

        /* data is the pure html returned from action method, load it to your page */
        $('#partialPlaceHolder').append(data);
        /* little fade in effect */
        $('#partialPlaceHolder').fadeIn('fast');

        GetLastArtikelId();
    });
}

function GetLastArtikelId()
{
    var values = $("input[id='ArtikelId']")
        .map(function () { return $(this).val(); }).get();

    if (values[values.length - 1] == LastId) {
        NoMoredata = true;
    }

    values.forEach(function (number) {

        LastId = number; 
     });

    console.log(LastId);
    inProgress = false;
    $("#loadingdiv").hide();
}
