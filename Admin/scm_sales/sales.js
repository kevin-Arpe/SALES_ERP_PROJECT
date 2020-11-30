function calculate() {
    var ea1=document.getElementsByClassName('txtea1')[0].value;
    var price1=document.getElementsByClassName('txtprice1')[0].value;
    var ea2=ea1.replace(/\,/g, ""); // 콤마( , )의 경우도 문자로 인식되기때문에 콤마를 따로 제거한다.
    var price2=price1.replace(/\,/g, ""); 
    var supply1=parseInt(ea2)*parseInt(price2); //공급가액 계산
    var vat1=supply1*0.1; //부가세 계산
    var total1=supply1+vat1; //합계 계산
    var supply2=supply1.toString().replace(/\B(?=(\d{3})+(?!\d))/g, ","); //공급가액, 부가세, 합계가 계산될 때 자동으로 천 단위 표시
    var vat2=vat1.toString().replace(/\B(?=(\d{3})+(?!\d))/g, ",");
    var total2=total1.toString().replace(/\B(?=(\d{3})+(?!\d))/g, ",");
    document.getElementsByClassName('txtsupply1')[0].value=supply2;
    document.getElementsByClassName('txtvat1')[0].value=vat2;
    document.getElementsByClassName('txttotal1')[0].value=total2;
}

function inputNumberAutoComma(obj) {  //수량, 단가를 입력할 때 자동으로 천 단위 표시
       
    // 콤마( , )의 경우도 문자로 인식되기때문에 콤마를 따로 제거한다.
    var deleteComma = obj.value.replace(/\,/g, "");

    // 콤마( , )를 제외하고 문자가 입력되었는지를 확인한다.
    if(isFinite(deleteComma) == false) {
        alert("문자는 입력하실 수 없습니다.");
        obj.value = "";
        return false;
    }
   
    // 기존에 들어가있던 콤마( , )를 제거한 이 후의 입력값에 다시 콤마( , )를 삽입한다.
    obj.value = inputNumberWithComma(inputNumberRemoveComma(obj.value));
}

// 천단위 이상의 숫자에 콤마( , )를 삽입하는 함수
function inputNumberWithComma(str) {

    str = String(str);
    return str.replace(/(\d)(?=(?:\d{3})+(?!\d))/g, "$1,");
}

// 콤마( , )가 들어간 값에 콤마를 제거하는 함수
function inputNumberRemoveComma(str) {

    str = String(str);
    return str.replace(/[^\d]+/g, "");
}



$("a").click(function() {  //메뉴 선택시 색상 변경 및 유지
    toggleClass(".active-color");
});



 
function clickColor() {  //메뉴 선택시 색상 변경 및 유지
    var div2 = document.getElementsByClassName('div2');

    for (var i = 0; i < div2.length; i++) {
      div2[i].addEventListener('click', function(){
        for (var j = 0; j < div2.length; j++) {
          div2[j].style.color = "black";
        }
        this.style.color = "red";
      })
    }
}
