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