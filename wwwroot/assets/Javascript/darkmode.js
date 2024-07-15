window.onload=function() {
  if(localStorage.darkMode=="true") {
    document.body.classList.toggle('dark');
    document.getElementById("chk").checked=true;
  }
  else {
    document.body.classList.toggle('light');
  }
};
document.getElementById("chk").addEventListener('change', () => {
  document.body.classList.toggle('dark');
  document.body.classList.toggle('light');
  localStorage.darkMode=(localStorage.darkMode=="true")?"false":"true";
});