var modal, btn, span;
function getirlen(id) {
    modal = document.getElementById(id + '+modal');

    btn = document.getElementById(id);

    span = document.getElementsByClassName("close")[0];

    btn.onclick = function () {
        modal.style.display = "block";
    }
}
function kapat() {
    modal.style.display = "none";
}

window.onclick = function (event) {
    if (event.target == modal) {
        modal.style.display = "none";
    }
}