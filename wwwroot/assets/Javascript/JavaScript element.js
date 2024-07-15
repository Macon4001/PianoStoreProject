
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
  x.style.left="00%";
  y.style.left="50px";
  z.style.left="110px";

}

  // BUTTON HIGHLIGHT FONT
  
  let buttons = document.querySelector('.buttons-2');
  let btn = buttons.querySelectorAll('btn-2');
  for (var i = 0; i <btn.length; i++){
   btn[i].addEventListener('click',function(){
     let current = document.
     getElementsByClassName("active");
     current[0].className = current[0].className.
     replace("active","");
     this.className += " active";
   })
 }
  
 //Product Image Animation<script>

// Get the Backdrop
var Backdrop = document.getElementById("myBackdrop");

// Get the image and insert it inside the backdrop- use its "alt" text as a caption
var img = document.getElementById("img1");
var BackdropImg = document.getElementById("img01");
var captionText = document.getElementById("caption");
img.onclick = function(){
  Backdrop.style.display = "block";
  BackdropImg.src = this.src;
  captionText.innerHTML = this.alt;
}

// Get the <span> element that closes the Backdrop
var span = document.getElementsByClassName("Backdrop")[0];

// When the user clicks on <span> (x), close the Backdrop
span.onclick = function() { 
  Backdrop.style.display = "none";
}

