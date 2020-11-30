function changeBg() {
    var bgBtn = document.getElementById("bgBtn");
    var body = document.getElementsByTagName("body")[0];
    var content = document.getElementById("content");
    if (bgBtn.value === "night") {
        body.style.backgroundColor = "black";
        body.style.color = "white";
        content.style.color = "white";
        var text = document.getElementsByClassName("text");
        if (text.length !== 0) {
            for (let i of text) {
                i.style.color = "white";
            }
        }
        bgBtn.value = "day";
    }
    else {
        body.style.backgroundColor = "white";
        body.style.color = "black";
        content.style.color = "black";
        content.style.color = "white";
        var text = document.getElementsByClassName("text");
        if (text.length !== 0) {
            for (let i of text) {
                i.style.color = "black";
            }
        }
        bgBtn.value = "night";
    }
}