$(function () {
    init();
    registerEvent();
});
function init() {
    ;
}
$(document).ready(function () {
    $("#note1").hide();
    $("#note2").hide();
});
function registerEvent() {
    $("#Nam").change(function () {
        var current = window.location.href;
        var temp = current.substring(0, current.lastIndexOf("/")) +"/" + $("#Nam").val();
        location.href = temp;
    });
    $("#comment").click(function () {
        var traLoi = $("#TraLoi").val();
        var hoTen = $("#HoTen").val();
        if (traLoi !== "" && hoTen !== "") {
            $("#form").submit();
        }
    });
    $("#dangnhap").click(function () {
        ;
    });
}