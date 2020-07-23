// Please see documentation at https://docs.microsoft.com/aspnet/core/client-side/bundling-and-minification
// for details on configuring this project to bundle and minify static web assets.

// Write your JavaScript code.


function btn(id) {

    $.ajax({
      url:'/Home/Recibir', //'urlcontroller',ruta de controller
    dataType: 'json',
        type: "POST",
        data: { Id: id },
    error: function (data) {

    },
    success: function (data) {
        if (data == true) {
            $("#" + id).remove();
            alert('se elimino con exito')
        }
        else {
           return alert('Error');
        }
    }
    }); 
}

function btnE(id) {

    window.location.href = '/Home/Editar/' + id;

}

function agregar() {
    window.location.href = '/Home/NuevoCliente/';
}

function submit() {

}
