const { Alert } = require("bootstrap");

$(document).ready(function () {
    GetData();

    $(window).scroll(function () {
        if ($(window).scrollTop() ==
            $(document).height() - $(window).height()) {
            GetData();
        }
    });
});

function GetData() {

    Alert("This is a alert")

}