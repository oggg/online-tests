$(document).ready(function () {
    $('#back-button:enabled').on('click', function (event) {
        event.preventDefault();
        history.back();
    });

    $('form').submit(function () {
        let selectedAnswerId = $('input[name="selectedAnswerId"]:checked').val();
        $('#selectedAnswerId').val(selectedAnswerId || -1);
        return true;
    });
});