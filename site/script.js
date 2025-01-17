document.addEventListener("DOMContentLoaded", () => {
    const logButton = document.getElementById("loginButton");

    logButton.addEventListener("click", () => {
        const Username = document.getElementById("Username");
        let userNameText = Username.value;

        const Password = document.getElementById("password");
        let passwordText = Password.value;
        Login(userNameText,passwordText);
    })

});

async function Login(userNameText,passwordText) {
    const response = await fetch("http://127.0.0.1:5027/session",{
        method:"POST",
        headers:{
            'content-Type': "application/json"
        },
        body: JSON.stringify({ email: userNameText, password: passwordText })
    })
    if (!response.ok) {
        console.log("login failed")
        return;
    }
    
}