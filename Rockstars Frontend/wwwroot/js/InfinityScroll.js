var LastId = 0;
var NoMoredata = false;
var inProgress = false;

$(document).ready(function () {
    
    $(window).on("scroll", function () {
        var docHeight = $(document).height();
        var winScrolled = $(window).height() + $(window).scrollTop();
        if ((docHeight - winScrolled) < 1 && NoMoredata == false && inProgress == false) {
            console.log("module scrolled to bottom");
            inProgress = true;
            $("#loadingdiv").show();
            ShowMoreData();
        }
    });
})

function ShowMoreData()
{
    $.ajax({
        url: '/Home/GetArtikelen/?LastId=' + LastId,
        type: 'post',
        contentType: 'application/json',
        success: function (data)
        {
            if (data.length == 0) {
                NoMoredata = true;
            }

            console.log(data);
            $.each(data, function (key, article) {
                console.log(article.Title);
                console.log(article.CreatedAt);
                LastId = article.Id;
            });
        }
    });
    $("#loadingdiv").hide();
    inProgress = false;
    console.log(LastId);
    console.log(NoMoredata);
    console.log(inProgress);
}
