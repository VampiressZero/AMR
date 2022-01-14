let sliderDiv = document.querySelector('.sliderForReading'),
    sliderItem = document.querySelectorAll('.sliderForReading-img'),
    slideIndex = 0,
    page = document.querySelectorAll('.mangaPage-item'),
    pageSelect = document.querySelector('.mangaPage');


function next (item){

}
// if (target && target.classList.contains('nameWeekDay')){
//     for (let i = 0; i < nameWeekDay.length; i++){
showSlide(slideIndex);
function showSlide(n){
    sliderItem.forEach((item) => item.style.display = "none");
    sliderItem[n].style.display = "block";
    pageSelect.options[n].selected=true;
    slideIndex = n;


}
function plusSlide(n){
    showSlide(slideIndex += n);
}

sliderDiv.addEventListener('click', function(event){
    target = event.target;
    if(target && target.classList.contains('sliderForReading-img')){
        // for(let i = 0; i < )
        plusSlide(1);
    }
});
pageSelect.addEventListener('change', function(event){
    target = event.target;
    showSlide(--target.value);
    
});