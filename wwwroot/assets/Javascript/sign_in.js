//sign in page

    var x = document.getElementById("login");
    var y = document.getElementById("register");
    var z = document.getElementById("btn4");
     
    function register(){
      x.style.left="120%";
      y.style.left="50px";
      z.style.left="110px";

    }

    function login(){
      x.style.left="50px";
      y.style.left="120%";
      z.style.left="0px";

    }

function registered(){
form.addEventListener('submit', (e) => {
  let messages = []
  if (name.value === ''|| name.vale == null ){
    massages.push('Name is required')
  }

  if (password.value.length <= 6){
    messages.push('password must be longer than 6 characters')
  }

  if (password.value.length >= 20){
    messages.push('password must be less than 20 characters')
  }

  if (password.value.length === 'password' ){
    messages.push('password cannot be password') 
  }

  if (messages.length > 0){
e.preventDefault()
errorElement.innerText = messages.join(',')
  }
})}
 
function registered() {
 var txt;
 if (confirm("Please fill all of the required fields")) {
   txt = "You pressed OK!";
   } else {
   txt = "You pressed Cancel!";
 }
document.getElementById("demo").innerHTML = txt;
}

