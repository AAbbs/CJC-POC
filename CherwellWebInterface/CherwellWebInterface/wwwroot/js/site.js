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
    //get subscribers
    //get services

        console.log(recId);
        $.ajax({
            url: '/Customer/Save',
            data: { 'recId': recId, 'name': name, 'address': address, 'hotline': hotline },
            //need to send both
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

    var search = $("#searchBarSub").val();
    var length = search.length;
    if (length > 1) {
        $(elements).children().hide();
        $("div[id*='" + search.toUpperCase() + "']").show();
    }
    else {
        $(elements).children().show();
    }
}

function showSubs()
{
    var subs = $('.sub-id').children();
    var checkboxes = $('.subs').children("input");
    $(checkboxes).prop("checked", false);
    for (var i = 0; i < subs.length; i++) {
        $("input[id*='" + subs[i].value + "']").prop("checked", true);
    }
}

function addSubs()
{
    var subs = $("input:checked").parent()
    $("#Subscribers").children().remove();
    for (var i = 0; i < subs.length; i++) {
        var recId = $("#" + subs[i].id).children("input").prop("id")
        var name = $("#" + subs[i].id).children("label").prop("innerText")
        $("#Subscribers").append("<div class='sub-field'><input type='text' value='" + name+ "'></div><div class='sub-id' hidden> <input type='text' value='" + recId+ "'> </div> ");
    }
   
}
