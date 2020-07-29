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
    else
    {
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
        Comentario:$("#Comentario").val(),

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
                window.location.href = '/Home/Index';
            }
            else {
                alert('Error');
            }

        },

    });
    
}
$("#LogInBtn").click(function (){

    console.log("Hola");
    data = {
        Usuario1: $("#UserInput").val(),
        Password: $("#PasswordInput").val()
    }

    $.ajax({
        url:'/User/Login', //'urlcontroller',ruta de controller
        dataType: 'json',
          type: "POST",
          data: { Data: data },
      error: function (data) {
  
      },
      success: function (data) {
          if (data === true) {
              window.location.href = "/Home/Index";
          }
          else
          {
              $("#Message").removeAttr('hidden');
              $("#Message").html("Usuario o contraseña incorrecto");
          }
         }
      }); 
})

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
                        +"<td id='" + element.id + "'</td>"
                        + "<td>" + element.id + "</td>"
                        +"<td>" + element.nombre + "</td>"
                        + "<td>" + element.cuenta + "</td>"
                        + "<td>" + element.email + "</td>"
                        + "<td>" + element.contraseña + "</td >"
                        + "<td>" + element.vencimientoC + "</td >"
                        + "<td>" + element.vencimientoP + "</td>"
                        + "<td>" + element.pantallas + "</td >"
                        + "<td>" + element.comentario + "</td>"
                        + "<td>" + "<a onclick='Borrar('"+element.id+"')' class='IconBtn'> <i class='fas fa-trash-alt'> </i></a ></td>"
                        + "<td>" + "<a onclick='Editar('"+element.Id+"')' class='IconBtn'> <i class='far fa-edit'> </i></a></td>"
                        + "<tr />");
                })
            }

        },

    });
}
