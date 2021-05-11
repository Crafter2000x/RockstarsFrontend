window.onload = function () {
    if (typeof jQuery == 'undefined') {
        // jQuery is not loaded
        alert("Doesn't Work");
    } else {
        // jQuery is loaded  
        alert("Yeah!");
    }
}