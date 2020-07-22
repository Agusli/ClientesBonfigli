// Please see documentation at https://docs.microsoft.com/aspnet/core/client-side/bundling-and-minification
// for details on configuring this project to bundle and minify static web assets.

// Write your JavaScript code.


function btn(id) {

    $.ajax({
      url:'HomeController.cs', //'urlcontroller',ruta de controller
    dataType: 'json',
        type: "POST",
        data: { Id: id },
    error: function (data) {

    },
    success: function (data) {
        if (success === true) {
            alert('se elimino con exito')
        }
        else {
           return alert('Error');
        }
    }
    }); 
}