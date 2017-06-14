$(document).ready(function () {
    $(".edit").click(function (evt) {
        var cell = $(evt.target).closest("tr").children().first();
        var recId = cell.text();
        $.ajax({
            url: '/Customer/Create',
            data: { 'recId': recId },
            type: 'GET',
            cache: false,
            success: function (result) {
                $("#viewPlaceHolder").children().remove();
                $("#viewPlaceHolder").append(result);
            }
        });
    });

    $(".delete").click(function (evt) {
        
        $("#viewPlaceHolder").load("/Customer/Delete", recId);
    });

    $(".create").click(function (evt) {
        $("#viewPlaceHolder").load("/Customer/Create");
    });

   
});

function save()
{
        var recId = $("#RecId").val();
        var name = $("#Name").val();
        var address = $("#Address").val();
        var hotline = $("#Hotline").val();

        console.log(recId);
        $.ajax({
            url: '/Customer/Save',
            data: { 'recId': recId, 'name': name, 'address': address, 'hotline': hotline },
            type: 'GET',
            cache: false,
            success: function (result) {
                $("#resultPlaceHolder").children().remove();
                $("#resultPlaceHolder").append(result);
            }
        });
};

function filterRows()
{

    var elements = $('.rows');
    $(elements).children().show();

    var search = $("#searchBar").val();
    var length = search.length;
    console.log(elements);
    console.log(search);
    if (length > 1) {
        $(elements).hide();
        $("tr[id*='" + search.toUpperCase() + "']").show();
    }
    else {
        $(elements).show();
    }
}


function filterSubs() {

    var elements = $('#checkboxes');
    $(elements).children().show();

    var search = $("#searchBar").val();
    var length = search.length;
    console.log(elements);
    console.log(search);
    if (length > 1) {
        $(elements).children().hide();
        $("div[id*='" + search.toUpperCase() + "']").show();
    }
    else {
        $(elements).children().show();
    }
}
