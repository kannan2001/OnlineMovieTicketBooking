function checkfname() {
    var isName = /^[a-zA-Z]+$/;
    let fnameValue = document.getElementById("FirstName")
    if (fnameValue.value.trim() === "") {
        setErrorFor(fnameValue, "Please type the name!");
    }
    else if (!isName.test(fnameValue.value.trim())) {
        setErrorFor(fnameValue, 'Name cannot be a numbers or special characters');
    }
    else {
        setSuccessFor(fnameValue);
    }
}
function checkLname() {
    var isName = /^[a-zA-Z]+$/;
    let LnameValue = document.getElementById("LastName")
    if (LnameValue.value.trim() === "") {
        setErrorFor(LnameValue, "Please type the name!");
    }
    else if (!isName.test(LnameValue.value.trim())) {
        setErrorFor(LnameValue, 'Name cannot be a numbers or special characters');
    }
    else {
        setSuccessFor(LnameValue);
    }
}
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
function checkpassword() {
    var isPassword = /^(?=.*\d)(?=.*[0-9])(?=.[a-z])(?=.*[A-Z]).{8,20}$/;
    let passwordValue = document.getElementById("Password")
    let cpasswordValue = document.getElementById("cpassword")
    if (passwordValue.value.trim() === "") {
        setErrorFor(passwordValue, " password Required");
    }
    else if (passwordValue.value.trim() !== cpasswordValue.value.trim()) {
        setErrorFor(passwordValue, "The password does not match");
    }
    else if (!isPassword.test(passwordValue.value.trim())) {
        setErrorFor(passwordValue, 'Password should only contain 8-20 characters and contains combination of uppercase and lowercase');

    }
    else {
        setSuccessFor(passwordValue);
    }
}
function checkcontact() {
    var isNumber = /^\d{10}$/;
    let contactValue = document.getElementById("MobNumber")
    if (contactValue.value.trim() === "") {
        setErrorFor(contactValue, 'Phonenumber Required');
    }
    else if (!isNumber.test(contactValue.value.trim())) {
        setErrorFor(contactValue, 'Check Phonenumber');

    }
    else {
        setSuccessFor(contactValue);
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




//Shows your Error message

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
    checkname();
    checkemail();
    checkpassword();
    checkcontact();
}