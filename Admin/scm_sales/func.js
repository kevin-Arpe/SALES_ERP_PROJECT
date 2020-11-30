var sum = {
    'ae40ac00c5f0': {ea: 0, price: 0, supply: 0, vat: 0, total: 0},
    'c624bbfcc900': {ea: 0, price: 0, supply: 0, vat: 0, total: 0},
    'c774c815d604': {ea: 0, price: 0, supply: 0, vat: 0, total: 0},
    'c7a5c9c0c778': {ea: 0, price: 0, supply: 0, vat: 0, total: 0}
};

var addComma = (num) => { // 3자리마다 숫자에 콤마를 추가하는 함수
    var regexp = /\B(?=(\d{3})+(?!\d))/g;
    return num.toString().replace(regexp, ',');
  }

var getSum = () => {
    // 클래스명이 salesman인 박스들 배열에 저장
    var salesman = document.getElementsByClassName('salesman');
    console.log(salesman);
    // 동일한 방식으로 계산할 박스들을 각각의 배열에 저장
    var ea = document.getElementsByClassName('ea');
    var price = document.getElementsByClassName('price');
    var supply = document.getElementsByClassName('supply');
    var vat = document.getElementsByClassName('vat');
    var total = document.getElementsByClassName('total');
    for (let i=0; i<salesman.length; i++) {
        var name = salesman[i].innerHTML.trim(); // salesman 내부 담당자명 공백제거
        var uni = makeToUni(name); // 에러방지를 위해 한글화된 이름을 유니코드화 (해당 함수는 아래에 정의)
        if (uni == 'ae40ac00c5f0') { // 미리 저장된 코드에 맞추어 조건문 실행
            console.log(ea);
            valFilter(i, uni, ea, price, supply, vat, total); // 각각의 수량, 단가, 공급가, 부가세, 합계를 매개변수로 필터링 함수 실행
        }
        else if (uni == 'c624bbfcc900') {
            valFilter(i, uni, ea, price, supply, vat, total);
        }
        else if (uni == 'c774c815d604') {
            valFilter(i, uni, ea, price, supply, vat, total);
        }
        else if (uni == 'c7a5c9c0c778') {
            valFilter(i, uni, ea, price, supply, vat, total);
        }
    }

    for (let i=0; i<sum.length; i++) { // 전처리하여 sum 객체에 저장된 값에 세 자리마다 끊어 ','추가
        sum[i].ea = addComma(sum[i].ea); // addComma 함수는 상단에 정의
        sum[i].price = addComma(sum[i].price);
        sum[i].supply = addComma(sum[i].supply);
        sum[i].vat = addComma(sum[i].vat);
        sum[i].total = addComma(sum[i].total);
    }
    // getSum 모듈 종료
}

// 받은 수량, 단가, 공급가, 부가세, 합계를 전처리 (','구분 제거 및 공백제거)
var valFilter = (i, uni, ea, price, supply, vat, total) => {
    var ea_filtered =  ea[i].innerHTML.trim().split(',').join("");
    var price_filtered =  price[i].innerHTML.trim().split(',').join("");
    var supply_filtered =  supply[i].innerHTML.trim().split(',').join("");
    var vat_filtered =  vat[i].innerHTML.trim().split(',').join("");
    var total_filtered = total[i].innerHTML.trim().split(',').join("");

    sum[uni].ea += parseInt(ea_filtered); // 전처리된 값들을 객체 sum의 각각의 값에 더하여 저장
    sum[uni].price += parseInt(price_filtered);
    sum[uni].supply += parseInt(supply_filtered);
    sum[uni].vat += parseInt(vat_filtered);
    sum[uni].total += parseInt(total_filtered);
}

// 받은 string 값을 유니코드화 하는 함수
var makeToUni = (str) => {
    var lis = [];
    for (let i=0; i<str.length; i++) {
        lis.push(str[i].charCodeAt(0).toString(16));
    }
    return lis.join("");
}

// 화면에 합을 프린트 해주는 모듈
var printSum = () => {
    var lastOne1; // 각 담당자의 마지막 행을 저장할 변수 정의
    var lastOne2;
    var lastOne3;
    var lastOne4;
    var salesman = document.getElementsByClassName('salesman'); // 담당자 명이 담겨있는 박스 호출
    for (let i=0; i<salesman.length; i++) {
        var name = salesman[i].innerHTML.trim(); // 담당자 명 전처리(공백제거)
        var uni = makeToUni(name); // 에러방지를 위해 담당자 명을 유니코드로 변환

        // 각각의 담당자 명에 대한 마지막 행을 찾아 변수에 저장하는 조건문
        if (uni == 'ae40ac00c5f0') {
            lastOne1 = salesman[i];
            console.log('c');
        }
        if (uni == 'c624bbfcc900') {
            lastOne2 = salesman[i];
        }
        if (uni == 'c774c815d604') {
            lastOne3 = salesman[i];
        }
        if (uni == 'c7a5c9c0c778') {
            lastOne4 = salesman[i];
        }
    }

    // 각각의 변수에 저장된 마지막 행의 다음 행을 만드는 함수 실행
    if (lastOne1 != undefined) {
        makeList(lastOne1, sum['ae40ac00c5f0'].ea, sum['ae40ac00c5f0'].price, sum['ae40ac00c5f0'].supply, sum['ae40ac00c5f0'].vat, sum['ae40ac00c5f0'].total);
    }
    if (lastOne2 != undefined) {
        makeList(lastOne2, sum['c624bbfcc900'].ea, sum['c624bbfcc900'].price, sum['c624bbfcc900'].supply, sum['c624bbfcc900'].vat, sum['c624bbfcc900'].total);
    }
    if (lastOne3 != undefined) {
        makeList(lastOne3, sum['c774c815d604'].ea, sum['c774c815d604'].price, sum['c774c815d604'].supply, sum['c774c815d604'].vat, sum['c774c815d604'].total);
    }
    if (lastOne4 != undefined) {
        makeList(lastOne4, sum['c7a5c9c0c778'].ea, sum['c7a5c9c0c778'].price, sum['c7a5c9c0c778'].supply, sum['c7a5c9c0c778'].vat, sum['c7a5c9c0c778'].total);
    }
}

// Sum 객체의 값을 담은 tr+td 생성
var makeList = (lastOne, ea, price, supply, vat, total) => {
    console.log('make');
    var parent = lastOne.parentNode.parentNode; // 각 담당자 마지막 행 매개변수로 받아 저장
        var tr = document.createElement('tr'); // tr, td 요소 생성
        var td1 = document.createElement('td');
        var td2 = document.createElement('td');
        var td3 = document.createElement('td');
        var td4 = document.createElement('td');
        var td5 = document.createElement('td');
        var td6 = document.createElement('td');
        var td7 = document.createElement('td');

        td1.innerHTML = lastOne.innerHTML.trim(); // 담당자 명을 lastOne에서 추출하여 td1에 저장

        tr.classList += 'sum_line'; // 각각의 tr, td에 css를 적용하기 위해 클래스명 정의
        td1.classList += 'val1';
        td2.classList += 'val2';
        td3.classList += 'val2';
        td4.classList += 'val2';
        td5.classList += 'val2';
        td6.classList += 'val2';
        td7.classList += 'val1';

        td1.setAttribute('colspan', '5');
        td2.innerHTML += addComma(ea); // 각각의 td에 각 담당자에 대한 판매수량, 가격, 공급가, 부가세, 합계금액의 총합을 저장
        td3.innerHTML += addComma(price);
        td4.innerHTML += addComma(supply);
        td5.innerHTML += addComma(vat);
        td6.innerHTML += addComma(total);
        td7.innerHTML += '-';
        td7.setAttribute('colspan', '3');

        tr.appendChild(td1); // 값이 저장된 td들을 tr에 저장
        tr.appendChild(td2);
        tr.appendChild(td3);
        tr.appendChild(td4);
        tr.appendChild(td5);
        tr.appendChild(td6);
        tr.appendChild(td7);

        parent.insertAdjacentElement('afterend', tr); // 최종 SUM 데이터가 담긴 행을 마지막 담당자 행 밑에 추가
        // printSum 모듈종료
}

getSum();
printSum();
console.log('d');