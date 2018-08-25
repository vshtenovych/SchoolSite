
$(document).ready(function () {
    $("#teachers").hide();
});

$(document).ready(function () {
    $("#type").change(function () {
        $("#sec-sel").children("optgroup").children().prop("disabled", "disabled").prop("selected", false);
        var arr = $(this).val();

        if (arr == "teachers") {
            $("#changing-text").text("Вчитель");
            $("#classes").hide();
            $("#teachers").show();
        }
        if (arr == "classes") {
            $("#changing-text").text("Клас");
            $("#classes").show();
            $("#teachers").hide();
        }
        if (arr == "bells") {
            $("#changing-text").text("");
            $("#classes").hide();
            $("#teachers").hide();
        }
        if (arr == "halfs") {
            $("#changing-text").text("");
            $("#classes").hide();
            $("#teachers").hide();
        }
    });
});