function checkForm() {
    var email = document.getElementById("emailText").value;
    var password = document.getElementById("passwordText").value
    var cansubmit = (email.length > 0);
    var subButton = document.getElementById("submitBtt");

    if (email.value === '' || password.value === '') {
        subButton.disabled = true;
        console.log("Inside disable")
    }
    else {
        subButton.disabled = false;
        console.log("Inside enable")
    }
};

document.querySelector('#submitBtt').disabled = true;
document.getElementById('register-form').addEventListener('keyup', checkForm)