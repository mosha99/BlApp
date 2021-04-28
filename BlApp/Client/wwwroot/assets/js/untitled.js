$(document).ready(function () {
    var wh =$("body").outerHeight() - $("footer").outerHeight() - $(".static-top").outerHeight();
    $("#general").height(wh);
});
$(window).resize(function () { 
    var wd =$("body").outerHeight() - $("footer").outerHeight() - $(".static-top").outerHeight();
    $("#general").height(wd);
});
$(window).scroll(function () {
    var wd = $("body").outerHeight() - $("footer").outerHeight() - $(".static-top").outerHeight();
    $("#general").height(wd);
});
$("#content-wrapper").scroll(function () {
    alert("helo");
    var wd = $("body").outerHeight() - $("footer").outerHeight() - $(".static-top").outerHeight();
    $("#general").height(wd);
});
$("#content").scroll(function () {
    alert("helo1");
    var wd = $("body").outerHeight() - $("footer").outerHeight() - $(".static-top").outerHeight();
    $("#general").height(wd);
});
function Rsize() {
    alert("helo2");
    var wd = $("body").outerHeight() - $("footer").outerHeight() - $(".static-top").outerHeight();
    $("#general").height(wd);
}