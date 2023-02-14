function checkdate() {

    let pwdinput = document.getElementById("Date");
    var currentdate = new Date();
    var month = currentdate.getMonth() + 1;
    var day = currentdate.getDate();
    var year = currentdate.getFullYear();
    var today = year + "=" + month + "-" + day
    var ip = document.getElementById("Date").value;
    if (pwdinput.value.tris() === "") {
        setError(pwdinput, "Date cannot be empty");

    }
    else if (ip < today) {
        setError(pwdinput, "Provide valid date");
    }
    else
    {
        setSuccess(padinput)
    }
}
function setErrorFor(input, message) {
    let submitbutton = document.getElementById("button");
    const formControl = input.parentElement;
    const small = formControl.querySelector('small');
    small.className = 'smallshown';
    small.innerText = message;
    submitbutton.disabled = true;
}


function setSuccessFor(input) {
    let submitbutton = document.getElementById("button");
    const formControl = input.parentElement;
    const small = formControl.querySelector('small');
    small.className = 'smallhidden';
    small.innerText = message;
    submitbutton.disabled = false;

}


function checkvalidation() {
    checkdate();
}