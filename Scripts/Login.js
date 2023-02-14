//Checking username
function checkemail() {
    var isMail = /^\w+([\.-]?\w+)@\w+([\.-]?\w+)(\.\w{2,3})+$/;
    let mailValue = document.getElementById("Username")
    if (mailValue.value.trim() === '') {
        setErrorFor(mailValue, 'Email Rquried');
    }
    else if (!isMail.test(mailValue.value.trim())) {
        setErrorFor(mailValue, 'Email ID is not valid');

    }
    else {
        setSuccessFor(mailValue);
    }
}
//Checking password
function checkpassword() {
    var isPassword = /^(?=.*\d)(?=.*[0-9])(?=.[a-z])(?=.*[A-Z]).{8,20}$/;
    let passwordValue = document.getElementById("Password")
    let cpasswordValue = document.getElementById("cpassword")
    if (passwordValue.value.trim() === "") {
        setErrorFor(passwordValue, " password Required");
    }
    else {
        setSuccessFor(passwordValue);
    }
}
function NoNumber(input) {
    var isNumber = /^[0-9]+$/;
    input.value = input.value.replace(isNumber, "");
}



function NoText(input) {
    isName = /^[a-zA-Z]+$/
    input.value = input.value.replace(isName, "");
}

//funcrtion are used ever where to sho error msg in <small> tag
function setError(input, message) {
    let submitbutton = document.getElementById("button")
    const formControl = input.parentElement;
    const small = formControl.querySelector('small');
    small.className = 'smallshown';
    small.innerText = message;
    submitbutton.disabled = true

}
function setSuccess(input) {
    let submitbutton = document.getElementById("button")
    const formControl = input.parentElement;
    const small = formControl.querySelector('small');
    small.className = "smallhidden"
    small.innerHTML = ""
    submitbutton.disabled = false
}
//till here
function checkvalidation() {
    checkname();
    checkpwd();
}