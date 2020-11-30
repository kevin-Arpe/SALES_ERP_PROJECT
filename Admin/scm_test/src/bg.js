function changeBg() {
    var bgBtn = document.getElementById("bgBtn");
    var body = document.getElementsByTagName("body")[0];
    if (bgBtn.value === "night") {
        body.style.backgroundColor = "black";
        body.style.color = "white";
        bgBtn.value = "day";
    }
    else {
        body.style.backgroundColor = "white";
        body.style.color = "black";
        bgBtn.value = "night";
    }
}