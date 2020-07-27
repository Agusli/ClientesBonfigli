﻿// Please see documentation at https://docs.microsoft.com/aspnet/core/client-side/bundling-and-minification
// for details on configuring this project to bundle and minify static web assets.

// Write your JavaScript code.


function Borrar(id) {

    $.ajax({
        url: '/Home/Borrar', //'urlcontroller',ruta de controller
        dataType: 'json',
        type: "POST",
        data: { Id: id },
        error: function (data) {

        },
        success: function (data) {
            if (data === true) {
                $("#" + id).remove();
                alert('se elimino con exito')
            }
            else {
                return alert('Error');
            }
        }
    });
}

function Editar(id) {

    window.location.href = '/Home/Editar/' + id;

}

function agregar() {
    window.location.href = '/Home/NuevoCliente/';
}

function Nuevo() {

    data = {
        Nombre: $("#Nombre").val(),
        Cuenta: $("#Cuenta").val(),
        Email: $("#Email").val(),
        Contraseña: $("#Contraseña").val(),
        VencimientoP: $("#VencimientoP").val(),
        VencimientoC: $("#VencimientoC").val(),
        Tipo: $("#Tipo").val(),
        Pantallas: $("#Pantallas").val(),

    }


    $.ajax({
        url: '/Home/NuevoCliente', //'urlcontroller',ruta de controller
        dataType: 'json',
        type: "POST",
        data: { data: data },
        error: function (data) {
 

        },
        success: function (data) {
            if (data === true){
                window.location.href = '/Home/Index/';
            }

            else {
                alert('error')
            }
        },

    });

}

function EnviarEdicion(id) {

    data = {
        Id: id,
        Nombre: $("#Nombre").val(),
        Cuenta: $("#Cuenta").val(),
        Email: $("#Email").val(),
        Contraseña: $("#Contraseña").val(),
        VencimientoP: $("#VencimientoP").val(),
        VencimientoC: $("#VencimientoC").val(),
        Tipo: $("#Tipo").val(),
        Pantallas: $("#Pantallas").val(),

    }


    $.ajax({
        url: '/Home/Editar', //'urlcontroller',ruta de controller
        dataType: 'json',
        type: "POST",
        data: { data: data},
        error: function (data) {
        
        },
        success: function (data) {
            if (data ===true)
            {
                window.location.href = '/Home';
            }
            else {
                alert('Error');
            }

        },

    });
    
    
}

function BuscarCliente()
{
    $.ajax({
        url: '/Home/Filtrar', //'urlcontroller',ruta de controller
        dataType: 'json',
        type: "POST",
        data: {
            Search: $("#Search").value(),
            
            },
        error: function (data) {

        },
        success: function (data) {
            if (data === true) {
                window.location.href = '/Home';
            }
            else {
                alert('Error');
            }

        },

    });



}
