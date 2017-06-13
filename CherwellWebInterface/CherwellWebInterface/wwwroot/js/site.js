$(document).ready(function () {

    $(".edit").click(function (evt) {
        var cell = $(evt.target).closest("tr").children().first();
        var recId = cell.text();
        console.log(recId);
        $.ajax({
            url: '/Customer/Create',
            data: { 'recId': recId },
            type: 'GET',
            cache: false,
            success: function (result) {
                $("#viewPlaceHolder").children().remove();
                $("#viewPlaceHolder").append(result);
                console.log(result);
            }
        });
        
        /*load("/Customer/Create", { data: { 'recId': recId }});*/
    });

    $(".delete").click(function (evt) {
        var cell = $(evt.target).closest("tr").children().first();
        var recId = cell.text();
        console.log(recId);
        $("#viewPlaceHolder").load("/Customer/Delete", recId);
    });
    $(".create").click(function (evt) {
        $("#viewPlaceHolder").load("/Customer/Create");
    });
});
