function showForCreating () {
    $(".for-creating").css("visibility", "visible");

    $("#od").html("<option selected value=\"8\">08:00</option>");

    for (var i = 9; i < 20; i++) {
        $("#od").append("<option value=\"" + i + "\">" + i +":00</option>");
    }

    $("#do").html("<option value=\"9\">09:00</option>");

    for (var i = 10; i < 21; i++) {
        if (i != 16) {
            $("#do").append("<option value=\"" + i + "\">" + i + ":00</option>");
        }
        else {
            $("#do").append("<option selected value=\"" + i + "\">" + i + ":00</option>");
        }

    }


}

function updateDo() {
    var eOd = document.getElementById("od");
    var selectedOd = eOd.options[eOd.selectedIndex].value;

    var variable = parseInt(selectedOd) + 1;

    $("#do").html("<option selected value=\"" + variable + "\">" + variable + ":00</option>");

    for (var i = variable + 1; i < 21; i++) {
        if (i != 16) {
            $("#do").append("<option value=\"" + i + "\">" + i + ":00</option>");
        }
        else {
            $("#do").append("<option selected value=\"" + i + "\">" + i + ":00</option>");
        }
    }
}
