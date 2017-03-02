function selectTest(event) {
    let hostAddress = window.location.host;
    let button = event.target;
    button.disabled = true;
    window.open('http://' + hostAddress + '/Question/Solve?testId=' + @Model.Id + '&question=' + @Model.Question);
}