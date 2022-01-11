let infoTitle = document.querySelector(".columnInfoTitle"),
    chaptersTitle = document.querySelector(".columnChaptersTitle"),
    commentsTitle = document.querySelector(".columnCommentsTitle"),
    menuTitle = document.querySelector(".menuTitle"),
    menuInfo = document.getElementById("menuInfo"),
    menuChapters = document.getElementById("menuChapters"),
    menuComments = document.getElementById("menuComments");

menuTitle.addEventListener('click', function(event){
    let target = event.target;
    if (target == menuInfo){
        infoTitle.classList.remove('displayNone');
        chaptersTitle.classList.add('displayNone');
        commentsTitle.classList.add('displayNone');
    }else if(target == menuChapters){
        infoTitle.classList.add('displayNone');
        chaptersTitle.classList.remove('displayNone');
        commentsTitle.classList.add('displayNone');
    }else if(target == menuComments){
        infoTitle.classList.add('displayNone');
        chaptersTitle.classList.add('displayNone');
        commentsTitle.classList.remove('displayNone');
    }
});
