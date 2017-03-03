$(document).ready(function () {
    $('#back-button').on('click', function () {
        history.back();
    });

    $('form').submit(function () {
        let selectedAnswerId = $('input[name="selectedAnswerId"]:checked').val();
        $('#selectedAnswerId').val(selectedAnswerId || -1);
        return true;
    });
});