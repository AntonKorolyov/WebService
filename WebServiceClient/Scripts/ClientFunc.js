$(document).ready(function () {
    var t = $('#example').DataTable();
    $.ajax({
        url: "/Home/ListPerson",
        type: "POST",
        contentType: "application/json",
        dataType: 'json',
        success: function (data) {
            $.each(data, function (i, v) {
                t.row.add([
               '<p class="id">' + v.ID + '</p>',
               '<p class="name">' + v.Name + '</p>',
               '<p class="lname">' + v.Fname + '</p>',
               '<a class="update" style="cursor:pointer;color:blue">update</a>',
               '<a class="delete"  style="cursor:pointer;color:blue">delete</a>',
                ]).draw(false);
            });

        }
    });

});

$('body').on('click', '.delete', function () {

    var id = $(this).parent().parent().find(".id").text();
    $.ajax({
        url: "/Home/DeletePerson",
        type: "POST",
        contentType: "application/json",
        data: JSON.stringify({ id: id }),
        dataType: 'json',
        success: function (data) {
        }
    });
    location.reload();
});
$('body').on('click', '.update', function () {
    var name = $(this).parent().parent().find(".name").text();
    var lname = $(this).parent().parent().find(".lname").text();
    var uname = $(this).parent().parent().find(".name");
    var ulname = $(this).parent().parent().find(".lname");
    uname.replaceWith('<input id="updname" type="text"/>')
    ulname.replaceWith('<input id="updlname" type="text"/>')
    $("#updname").val(name);
    $("#updlname").val(lname);
    $(this).replaceWith('<a id="saveupdates" style="cursor:pointer;color:blue">save<a>')
});
$('body').on('click', '#saveupdates', function () {
    var id = $(this).parent().parent().find(".id").text();;
    var name = $(this).parent().parent().find("#updname").val();
    var lname = $(this).parent().parent().find("#updlname").val();
    var updatePerson = {
        ID: id,
        Name: name,
        Fname: lname
    }
    $.ajax({
        url: "/Home/UpdatePerson",
        type: "POST",
        contentType: "application/json",
        data: JSON.stringify(updatePerson),
        dataType: 'json',
        success: function (data) {
        }
    });
    location.reload();
});
$('body').on('click', '#createPerson', function () {

    var name = $("#createname").val();
    var lname = $("#createlastname").val();
    var CreatePerson = {
        ID: "",
        Name: name,
        Fname: lname
    }
    $.ajax({
        url: "/Home/CreatePerson",
        type: "POST",
        contentType: "application/json",
        data: JSON.stringify(CreatePerson),
        dataType: 'json',
        success: function (data) {
        }
    });
    location.reload();
});