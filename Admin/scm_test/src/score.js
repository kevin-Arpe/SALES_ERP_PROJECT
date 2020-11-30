var txtpf = document.getElementsByClassName('pf')[0];
var submitBtn = document.getElementById('submitBtn');
submitBtn.addEventListener('click', (e) => {
    e.preventDefault();

    var tester = document.getElementsByClassName('tester')[0].value;
    var langScore = document.getElementsByClassName('langScore')[0].value;
    var engScore = document.getElementsByClassName('engScore')[0].value;
    var mathScore = document.getElementsByClassName('mathScore')[0].value;
    var txttotalScore = document.getElementsByClassName('totalScore')[0];
    
    if (tester === '') {
        alert('이름을 입력해 주세요');
    }
    else if (langScore === '') {
        alert('국어 점수를 입력해 주세요');
    }
    else if (engScore === '') {
        alert('영어 점수를 입력해 주세요');
    }
    else if (mathScore === '') {
        alert('수학 점수를 입력해 주세요');
    }
    txttotalScore.value = parseInt(langScore) + parseInt(engScore) + parseInt(mathScore);
    if (txttotalScore.value>=240) {
        txtpf.value = 'pass';
        txtpf.style.color = 'blue';
    }
    else {
        txtpf.value = 'fail';
        txtpf.style.color = 'red';
    }
})