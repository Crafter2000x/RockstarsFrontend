var Page = 0;
var NoMoredata = false;
var inProgress = false;

$(document).ready(function () {

    LoadPartialViewPodcast();

    $(window).on("scroll", function () {
        var docHeight = $(document).height();
        var winScrolled = $(window).height() + $(window).scrollTop();

        if ((docHeight - winScrolled) < 1 && NoMoredata == false && inProgress == false) {

            console.log("module scrolled to bottom");

            inProgress = true;
            LoadPartialViewPodcast();
        }
    });
})

function LoadPartialViewPodcast()
{
    /* Request the partial view with .get request. */
    $.get('/Home/RequestPodcastPartial/?Page=' + Page, function (data) {

        if (data.trim() == '') {

            NoMoredata = true;

        } else {

            $("#loadingdiv").show();
            $('#WaitingForContent').hide();
            /* data is the pure html returned from action method, load it to your page */
            $('#partialPlaceHolder').append(data);
            /* little fade in effect */
            $('#partialPlaceHolder').fadeIn('fast');
            console.log(Page);
            Page++;
            inProgress = false;
            $("#loadingdiv").hide();
        }  
    });
}
