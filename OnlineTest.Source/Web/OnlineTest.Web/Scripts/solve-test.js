function previous(e) {
    $('#direction').val(-1);
    history.back();
    return false;
}

$('form').submit(function (e) {
    let selectedAnswerId = $('input[name="radio"]:checked').val();
    $('#selectedAnswerId').val(selectedAnswerId || -1);
    $('#direction').val(1);
    return true;
});