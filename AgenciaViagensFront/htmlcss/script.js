let time = 3000,
    currentImageIndex = 0,
    images = document
                .querySelectorAll("#slider img")
    max = images.length;

function nextImage() {

    images[currentImageIndex]
        .classList.remove("selected")

    currentImageIndex++

    if(currentImageIndex >= max)
        currentImageIndex = 0

    images[currentImageIndex]
        .classList.add("selected")
}

function start() {
    setInterval(() => {
        // troca de imagem
        nextImage()
    }, time)
}

window.addEventListener("load", start)

function exibir_categoria(categorias){
    //alert(categorias)
    let elementos = document.getElementsByClassName('produto');
    console.log(elementos);
    for(var i=0; i < elementos.length; i++){
        console.log(elementos[i].id);
        if(categorias == elementos[i].id)
        elementos[i].style = "display:inline-block";
        else
        elementos[i].style = "display:none";
    }
}

let exibir_todos = () => {
    let elementos = document.getElementsByClassName('produto');

    for(var i=0; i < elementos.length; i++){
        elementos[i].style = "display:inline-block";
    }
}

let destaque = (imagem) => {
    console.log(imagem);
    if (imagem.width == 240)
    imagem.width = 120;
    else
    imagem.width = 240;
}

var dialog = $('#wrapper').dialog({
    autoOpen: false,
    resizable: false,
    title: 'Caixa de info'
});
$('#opener').click(function () {
    $('#wrapper').dialog('open');
    dialogPosition = $('.ui-dialog').offset().top;
    dialogHeight = $('.ui-dialog').outerHeight();
    ultimoScroll = $(window).scrollTop();
});


var dialog, dialogPosition, dialogHeight, ultimoScroll;
$(window).on('scroll', function () {
    var scroll = $(this).scrollTop();
    var foraDoLimite = scroll > dialogPosition + dialogHeight || scroll < dialogPosition;
    if (dialog.dialog( "isOpen" ) && foraDoLimite) $(window).scrollTop(ultimoScroll);
    else ultimoScroll = scroll;
});
