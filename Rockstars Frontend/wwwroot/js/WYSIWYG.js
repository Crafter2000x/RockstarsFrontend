$(document).ready(function () {
    var value = '<%=content%>'
    MakeHTML(value);
})

function MakeHTML(htmlString)
{
    var div = document.createElement('div');
    div.innerHTML = htmlString
}