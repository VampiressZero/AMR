"use strict";
let divWeekDay = document.querySelector(".WeekDay"),
    ongoingsWeekDay = document.querySelectorAll(".ongoingsWeekDay"),
    nameWeekDay = document.querySelectorAll(".nameWeekDay");
divWeekDay.addEventListener('click', function(event){
    let target = event.target;
    if (target && target.classList.contains('nameWeekDay')){
        for (let i = 0; i < nameWeekDay.length; i++){
            if (target == nameWeekDay[i] && ongoingsWeekDay[i].classList.contains('displayNone')){
                ongoingsWeekDay[i].classList.remove('displayNone');
                ongoingsWeekDay[i].classList.add('displayInline-block');
                break;
            }else if (target == nameWeekDay[i] && ongoingsWeekDay[i].classList.contains('displayInline-block')){
                ongoingsWeekDay[i].classList.remove('displayInline-block');
                ongoingsWeekDay[i].classList.add('displayNone');
                break;
            }


        }
    }
});

let divAuthorization = document.querySelector('.sectionAuthorization'),
    popupClose = document.querySelector('.popup-close'),
    authorization = document.getElementById('authorization');


function popupWindow (clickButton, window, popupClose){
    clickButton.addEventListener('click', function(){
        window.classList.remove('displayNone');
    });
    popupClose.addEventListener('click', function(){
        window.classList.add('displayNone');
    })

}
popupWindow(authorization, divAuthorization, popupClose);
