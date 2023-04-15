// Please see documentation at https://docs.microsoft.com/aspnet/core/client-side/bundling-and-minification
// for details on configuring this project to bundle and minify static web assets.

// Write your JavaScript code.



function Borrar(id) {
    var bool = confirm("Seguro de eliminar el dato?");
    if (bool === true) {

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
    else {
        alert("cancelo la solicitud");
    }

}

function Editar(id) {

    window.location.href = '/Home/Editar?id=' + id;

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
        Comentario: $("#Comentario").val(),

    }


    $.ajax({
        url: '/Home/NuevoCliente', //'urlcontroller',ruta de controller
        dataType: 'json',
        type: "POST",
        data: { data: data },
        error: function (data) {


        },
        success: function (data) {
            if (data === true) {
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
        Comentario: $("#Comentario").val(),

    }
    $.ajax({
        url: '/Home/Editar', //'urlcontroller',ruta de controller
        dataType: 'json',
        type: "POST",
        data: { data: data },
        error: function (data) {

        },
        success: function (data) {
            if (data === true) {
                window.location.href = '/Home/Index';
            }
            else {
                alert('Error');
            }

        },

    });

}
$("#LogInBtn").click(function () {

    data = {
        Usuario1: $("#UserInput").val(),
        Password: $("#PasswordInput").val()
    }

    $.ajax({
        url: '/User/Login', //'urlcontroller',ruta de controller
        dataType: 'json',
        type: "POST",
        data: { Data: data },
        error: function (data) {

        },
        success: function (data) {
            if (data === true) {
                window.location.href = "/Home/Index";
            }
            else {
                $("#Message").removeAttr('hidden');
                $("#Message").html("Usuario o contraseña incorrecto");
            }
        }
    });
})


function Filtro() {

    if ($("#opciFiltro").val() === "Nombre") {
        BuscarCliente();
    }

    if ($("#opciFiltro").val() === "Cuenta") {
        filtrarCuenta();
    }

    if ($("#opciFiltro").val() === "Comentario") {
        filtrarComentario();
    }

}



function cuentasLibre() {
    $.ajax({
        url: '/Home/CuentaLibre', //'urlcontroller',ruta de controller
        dataType: 'json',
        type: "POST",
        data: {
            Libres: $("#Libres").val(),

        },
        error: function (data) {

        },
        success: function (data) {
            if (data !== null) {
                $(".DataRows").remove("");
                data.forEach(function (element) {
                    $("#customers").append(
                        "<tr id='" + element.id + "' class='DataRows'>"
                        + "<td>" + getTipo(element.tipo) + "</td>"
                        //+ "<td>" + element.id + "</td>"
                        + "<td>" + element.nombre + "</td>"
                        + "<td>" + element.cuenta + "</td>"
                        //+ "<td>" + element.email + "</td>"
                        + "<td>" + element.contraseña + "</td >"
                        + "<td>" + element.vencimientoC + "</td >"
                        + "<td>" + element.vencimientoP + "</td>"
                        + "<td>" + element.pantallas + "</td >"
                        + "<td>" + element.comentario + "</td>"
                        + "<td>" + "<a onclick='Borrar(" + element.id + ")' class='IconBtn'> <i class='fas fa-trash-alt'> </i></a ></td>"
                        + "<td>" + "<a onclick='Editar(" + element.id + ")' class='IconBtn'> <i class='far fa-edit'> </i></a></td>"
                        + "<tr/>");
                })
            }

        },

    });

}

function BuscarCliente() {
    $.ajax({
        url: '/Home/Filtrar', //'urlcontroller',ruta de controller
        dataType: 'json',
        type: "POST",
        data: {
            Search: $("#Search").val(),

        },
        error: function (data) {

        },
        success: function (data) {
            if (data !== null) {
                $(".DataRows").remove("");
                data.forEach(function (element) {
                    $("#customers").append(
                        "<tr id='" + element.id + "' class='DataRows'>"
                        + "<td>" + getTipo(element.tipo) + "</td>"
                        //+ "<td>" + element.id + "</td>"
                        + "<td>" + element.nombre + "</td>"
                        + "<td>" + element.cuenta + "</td>"
                        //+ "<td>" + element.email + "</td>"
                        + "<td>" + element.contraseña + "</td >"
                        + "<td>" + element.vencimientoC + "</td >"
                        + "<td>" + element.vencimientoP + "</td>"
                        + "<td>" + element.pantallas + "</td >"
                        + "<td>" + element.comentario + "</td>"
                        + "<td>" + "<a onclick='Borrar(" + element.id + ")' class='IconBtn'> <i class='fas fa-trash-alt'> </i></a ></td>"
                        + "<td>" + "<a onclick='Editar(" + element.id + ")' class='IconBtn'> <i class='far fa-edit'> </i></a></td>"
                        + "<tr/>");
                })
            }

        },

    });
}


function getTipo(id) {

    var Tipo = "";

    switch (id) {

        case 1:
            Tipo = "Netflix"
            break;
        case 2:
            Tipo = "Flow"
            break;
        case 3:
            Tipo = "IPTV"
            break;
        case 4:
            Tipo = "DirecTVGo"
            break;
        case 5:
            Tipo = "AmazonPrime"
            break;
        case 6:
            Tipo = "Spotify"
            break;
        case 7:
            Tipo = "DisneyPlus"
            break;
        case 8:
            Tipo = "HBOMax";
            break;
        case 9:
            Tipo = "StarPlus";
            break;
        case 10:
            Tipo = "ParamountPlus";
            break;
        case 11:
            Tipo = "Telecentro";
            break;
        case 12:
            Tipo = "CinemaPlus";
            break;
        case 13:
            Tipo = "TvMundosDigital";
            break;
    }

    return Tipo;
}

function BuscarPorFecha() {

    $.ajax({
        url: '/Home/BuscarPorFecha', //'urlcontroller',ruta de controller
        dataType: 'json',
        type: "POST",
        data: {
            Cuenta: $("#FechaVenci").val(),
        },
        error: function (data) {

        },
        success: function (data) {
            if (data !== null) {
                $(".DataRows").remove("");
                data.forEach(function (element) {
                    $("#customers").append(
                        "<tr id='" + element.id + "' class='DataRows'>"
                        + "<td>" + getTipo(element.tipo) + "</td>"
                        //+ "<td>" + element.id + "</td>"
                        + "<td>" + element.nombre + "</td>"
                        + "<td>" + element.cuenta + "</td>"
                        //+ "<td>" + element.email + "</td>"
                        + "<td>" + element.contraseña + "</td >"
                        + "<td>" + element.vencimientoC + "</td >"
                        + "<td>" + element.vencimientoP + "</td>"
                        + "<td>" + element.pantallas + "</td >"
                        + "<td>" + element.comentario + "</td>"
                        + "<td>" + "<a onclick='Borrar(" + element.id + ")' class='IconBtn'> <i class='fas fa-trash-alt'> </i></a ></td>"
                        + "<td>" + "<a onclick='Editar(" + element.id + ")' class='IconBtn'> <i class='far fa-edit'> </i></a></td>"
                        + "<tr/>");
                })
            }

        },

    });
}

function BuscarPorFechaCuenta() {

    $.ajax({
        url: '/Home/BuscarPorFechaCuenta', //'urlcontroller',ruta de controller
        dataType: 'json',
        type: "POST",
        data: {
            Cuenta: $("#FechaVenciCuenta").val(),
        },
        error: function (data) {

        },
        success: function (data) {
            if (data !== null) {
                $(".DataRows").remove("");
                data.forEach(function (element) {
                    $("#customers").append(
                        "<tr id='" + element.id + "' class='DataRows'>"
                        + "<td>" + getTipo(element.tipo) + "</td>"
                        //+ "<td>" + element.id + "</td>"
                        + "<td>" + element.nombre + "</td>"
                        + "<td>" + element.cuenta + "</td>"
                        //+ "<td>" + element.email + "</td>"
                        + "<td>" + element.contraseña + "</td >"
                        + "<td>" + element.vencimientoC + "</td >"
                        + "<td>" + element.vencimientoP + "</td>"
                        + "<td>" + element.pantallas + "</td >"
                        + "<td>" + element.comentario + "</td>"
                        + "<td>" + "<a onclick='Borrar(" + element.id + ")' class='IconBtn'> <i class='fas fa-trash-alt'> </i></a ></td>"
                        + "<td>" + "<a onclick='Editar(" + element.id + ")' class='IconBtn'> <i class='far fa-edit'> </i></a></td>"
                        + "<tr/>");
                })
            }

        },

    });
}

function FiltroTipo() {

    $.ajax({
        url: '/Home/FiltrarTipo', //'urlcontroller',ruta de controller
        dataType: 'json',
        type: "POST",
        data: {
            Tipo: $("#Tipo").val(),
        },
        error: function (data) {

        },
        success: function (data) {
            if (data !== null) {
                $(".DataRows").remove("");
                data.forEach(function (element) {
                    $("#customers").append(
                        "<tr id='" + element.id + "' class='DataRows'>"
                        + "<td>" + getTipo(element.tipo) + "</td>"
                        //+ "<td>" + element.id + "</td>"
                        + "<td>" + element.nombre + "</td>"
                        + "<td>" + element.cuenta + "</td>"
                        //+ "<td>" + element.email + "</td>"
                        + "<td>" + element.contraseña + "</td >"
                        + "<td>" + element.vencimientoC + "</td >"
                        + "<td>" + element.vencimientoP + "</td>"
                        + "<td>" + element.pantallas + "</td >"
                        + "<td>" + element.comentario + "</td>"
                        + "<td>" + "<a onclick='Borrar(" + element.id + ")' class='IconBtn'> <i class='fas fa-trash-alt'> </i></a ></td>"
                        + "<td>" + "<a onclick='Editar(" + element.id + ")' class='IconBtn'> <i class='far fa-edit'> </i></a></td>"
                        + "<tr/>");
                })
            }

        },

    });

}

function BuscarCuenta() {

    $.ajax({
        url: '/Home/BuscarCuenta', //'urlcontroller',ruta de controller
        dataType: 'json',
        type: "POST",
        data: {
            Cuenta: $("#CuentaN").val(),
        },
        error: function (data) {

        },
        success: function (data) {
            if (data !== null) {
                $(".DataRows").remove("");
                data.forEach(function (element) {
                    $("#customers").append(
                        "<tr id='" + element.id + "' class='DataRows'>"
                        + "<td>" + getTipo(element.tipo) + "</td>"
                        //+ "<td>" + element.id + "</td>"
                        + "<td>" + element.nombre + "</td>"
                        + "<td>" + element.cuenta + "</td>"
                        //+ "<td>" + element.email + "</td>"
                        + "<td>" + element.contraseña + "</td >"
                        + "<td>" + element.vencimientoC + "</td >"
                        + "<td>" + element.vencimientoP + "</td>"
                        + "<td>" + element.pantallas + "</td >"
                        + "<td>" + element.comentario + "</td>"
                        + "<td>" + "<a onclick='Borrar(" + element.id + ")' class='IconBtn'> <i class='fas fa-trash-alt'> </i></a ></td>"
                        + "<td>" + "<a onclick='Editar(" + element.id + ")' class='IconBtn'> <i class='far fa-edit'> </i></a></td>"
                        + "<tr/>");
                })
            }

        },

    });

}



function filtrarCuenta() {
    $.ajax({
        url: '/Home/FiltrarCuenta', //'urlcontroller',ruta de controller
        dataType: 'json',
        type: "POST",
        data: {
            Cuenta: $("#Search").val(),

        },
        error: function (data) {

        },
        success: function (data) {
            if (data !== null) {
                $(".DataRows").remove("");
                data.forEach(function (element) {
                    $("#customers").append(
                        "<tr id='" + element.id + "' class='DataRows'>"
                        + "<td>" + getTipo(element.tipo) + "</td>"
                        //+ "<td>" + element.id + "</td>"
                        + "<td>" + element.nombre + "</td>"
                        + "<td>" + element.cuenta + "</td>"
                        //+ "<td>" + element.email + "</td>"
                        + "<td>" + element.contraseña + "</td >"
                        + "<td>" + element.vencimientoC + "</td >"
                        + "<td>" + element.vencimientoP + "</td>"
                        + "<td>" + element.pantallas + "</td >"
                        + "<td>" + element.comentario + "</td>"
                        + "<td>" + "<a onclick='Borrar(" + element.id + ")' class='IconBtn'> <i class='fas fa-trash-alt'> </i></a ></td>"
                        + "<td>" + "<a onclick='Editar(" + element.id + ")' class='IconBtn'> <i class='far fa-edit'> </i></a></td>"
                        + "<tr/>");
                })
            }

        },

    });
}

function filtrarComentario() {
    $.ajax({
        url: '/Home/FiltrarComentario', //'urlcontroller',ruta de controller
        dataType: 'json',
        type: "POST",
        data: {
            Coment: $("#Search").val(),

        },
        error: function (data) {

        },
        success: function (data) {
            if (data !== null) {
                $(".DataRows").remove("");
                data.forEach(function (element) {
                    $("#customers").append(
                        "<tr id='" + element.id + "' class='DataRows'>"
                        + "<td>" + getTipo(element.tipo) + "</td>"
                        //+ "<td>" + element.id + "</td>"
                        + "<td>" + element.nombre + "</td>"
                        + "<td>" + element.cuenta + "</td>"
                        //+ "<td>" + element.email + "</td>"
                        + "<td>" + element.contraseña + "</td >"
                        + "<td>" + element.vencimientoC + "</td >"
                        + "<td>" + element.vencimientoP + "</td>"
                        + "<td>" + element.pantallas + "</td >"
                        + "<td>" + element.comentario + "</td>"
                        + "<td>" + "<a onclick='Borrar(" + element.id + ")' class='IconBtn'> <i class='fas fa-trash-alt'> </i></a ></td>"
                        + "<td>" + "<a onclick='Editar(" + element.id + ")' class='IconBtn'> <i class='far fa-edit'> </i></a></td>"
                        + "<tr/>");
                })
            }

        },

    });
}



