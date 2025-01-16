async function login() {
   const response = await fetch("http://127.0.0.1:5027/session", {
      method: "POST",
      headers: {
         'content-Type': "application/json"

      },
      body: JSON.stringify({ email: "egal5@egal5.com", password: "egal.123" })

   })
   if (!response.ok) {
      console.log("login failed")
      return;
   }
   const credentials = await response.json();
   localStorage.setItem("session",credentials.token)
   localStorage.setItem("expiry",credentials.expiry)
}

async function getUser() {
   const token = localStorage.getItem("session")

   if(token == null){
      alert("bitte erst einloggen")
      return;
   }

   const response = await fetch("http://127.0.0.1:5027/users/current", {
      method: "GET",
      headers: {
         'Authorization': `Bearer ${credentials.token}`
      }
   });

   if (!response.ok) {
      console.log("fetch current user failed")
      return;
   }

   const user = await response.json()
   console.log(user)
}


async function logout() {
   const token = localStorage.getItem("session")

   if(token == null){
      alert("bitte erst einloggen")
      return;
   }

   //localStorage.clear();
   localStorage.removeItem("session")
   localStorage.removeItem("expiry")

   const response = await fetch("http://127.0.0.1:5027/session/current", {
      method: "DELETE",
      headers: {
         'Authorization': `Bearer ${token}`
      }
   });

   if (!response.ok) {
      console.log("logout failed")
      return;
   }
   console.log("logout success")
}



document.addEventListener("DOMContentLoaded", () => {
   const loginButton = document.getElementById("loginButton")
   loginButton.addEventListener("click", async () => {

      await login();
      //console.log(credentials.token)
      //console.log(credentials.expiry)
      await getUser()
      await logout()
   })


   //console.log(response)
})

//tableButton
const tableButton = document.getElementById("tableButton")
tableButton.addEventListener("click", () => {
   const s1 = "bla"

   const table = document.getElementById("table")
   const row = document.createElement("tr")
   row.innerHTML = `
      <td>${s1}</td>    
      <td>${s1}</td>    
      <td>${s1}</td>    
      <td>${s1}</td>    
      `
   table.appendChild(row);

})

//clearButton
const clearButton = document.getElementById("clearButton")
clearButton.addEventListener("click", () => {
   const table = document.getElementById("table")
   table.innerHTML = ''
   table.appendChild(row);

});
