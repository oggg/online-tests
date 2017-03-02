$(document).ready(function() {
    $('#selectTest').on('click', function () {
        let hostAddr = window.location.origin;
        let urlAttr = $(this).data('url');
        let addr = hostAddr + urlAttr;
        console.log(addr);
        $(this).prop('disabled', true);
        window.open(addr);
    });
});