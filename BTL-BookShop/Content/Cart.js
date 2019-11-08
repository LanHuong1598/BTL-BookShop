
function _delete(id) {
    var cf = confirm('Are you sure want to permanently delete this row?');
    if (cf) {
        $.ajax({
            url: '/Home/Delete/' + id,
            type: "POST",
            contentType: "application/json; charset=utf-8",
            dataType: "json",
            async: true,
            success: function (result) {
                _getAll();
            },
            error: function (errormessage) {
                alert(errormessage.responseText);
            }
        });
    }
}