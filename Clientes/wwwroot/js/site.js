// Client-side actions for the customer manager.

function escapeHtml(value) {
    return $('<div>').text(value == null ? '' : String(value)).html();
}

function getTipo(id) {
    switch (parseInt(id, 10)) {
        case 1:
            return 'Netflix';
        case 2:
            return 'Flow';
        case 3:
            return 'IPTV';
        case 4:
            return 'DirecTVGo';
        case 5:
            return 'AmazonPrime';
        case 6:
            return 'Spotify';
        case 7:
            return 'DisneyPlus';
        case 8:
            return 'HBOMax';
        case 9:
            return 'StarPlus';
        case 10:
            return 'ParamountPlus';
        case 11:
            return 'Telecentro';
        case 12:
            return 'WOWPlus';
        case 13:
            return 'WOWTV';
        case 14:
            return 'Devex';
        default:
            return 'Sin tipo';
    }
}

function getTipoLabel(element) {
        if (element.tipoNombre !== null && element.tipoNombre !== undefined && element.tipoNombre !== '') {
        return element.tipoNombre;
    }

    return getTipo(element.tipoId || element.tipo);
}

function buildRow(element) {
    var tipo = escapeHtml(getTipoLabel(element));
    var nombre = escapeHtml(element.nombre);
    var cuenta = escapeHtml(element.cuenta);
    var contrasena = escapeHtml(element.contraseña);
    var vencimientoC = escapeHtml(element.vencimientoC);
    var vencimientoP = escapeHtml(element.vencimientoP);
    var pantallas = escapeHtml(element.pantallas);
    var comentario = escapeHtml(element.comentario);

    return "<tr id='" + element.id + "' class='DataRows'>"
        + "<td>" + tipo + "</td>"
        + "<td>" + nombre + "</td>"
        + "<td>" + cuenta + "</td>"
        + "<td>" + contrasena + "</td>"
        + "<td>" + vencimientoC + "</td>"
        + "<td>" + vencimientoP + "</td>"
        + "<td>" + pantallas + "</td>"
        + "<td>" + comentario + "</td>"
        + "<td><button type='button' onclick='Borrar(" + element.id + ")' class='IconBtn IconBtn-danger' title='Eliminar'><i class='fas fa-trash-alt'></i></button></td>"
        + "<td><button type='button' onclick='Editar(" + element.id + ")' class='IconBtn IconBtn-primary' title='Editar'><i class='far fa-edit'></i></button></td>"
        + "</tr>";
}

function renderClientes(data) {
    var tbody = $('#customers tbody');
    if (!tbody.length) {
        tbody = $('#customers');
    }

    tbody.find('.DataRows').remove();

    if (!Array.isArray(data) || data.length === 0) {
        tbody.append("<tr class='DataRows empty-row'><td colspan='10' class='text-center text-muted py-4'>No hay resultados para mostrar.</td></tr>");
        return;
    }

    data.forEach(function (element) {
        tbody.append(buildRow(element));
    });
}

function ajaxJson(url, payload, onSuccess) {
    $.ajax({
        url: url,
        dataType: 'json',
        type: 'POST',
        data: payload,
        success: onSuccess,
        error: function () {
            alert('Ocurrio un problema inesperado. Intenta de nuevo.');
        }
    });
}

function Borrar(id) {
    if (!confirm('Seguro de eliminar el dato?')) {
        return;
    }

    ajaxJson('/Home/Borrar', { id: id }, function (data) {
        if (data === true) {
            $('#' + id).remove();
            alert('Se elimino con exito');
        }
        else {
            alert('No se pudo eliminar');
        }
    });
}

function Editar(id) {
    window.location.href = '/Home/Editar?id=' + id;
}

function agregar() {
    window.location.href = '/Home/NuevoCliente';
}

function MostrarTodas() {
    ajaxJson('/Home/MostrarTodas', {}, function (data) {
        renderClientes(data);
    });
}

$(document).ready(function () {
    var currentSortColumn = '';
    var currentSortDirection = 'asc';

    $('#customers thead th[data-sort]').on('click', function () {
        var column = $(this).data('sort');
        var direction = 'asc';

        if (currentSortColumn === column) {
            direction = (currentSortDirection === 'asc') ? 'desc' : 'asc';
        }

        // Update sort classes
        $('#customers thead th[data-sort]').removeClass('sort-asc sort-desc');
        $(this).addClass(direction === 'asc' ? 'sort-asc' : 'sort-desc');

        currentSortColumn = column;
        currentSortDirection = direction;

        ajaxJson('/Home/SortClients', { column: column, direction: direction }, function (data) {
            renderClientes(data);
        });
    });
});

function Nuevo() {
    var data = {
        Nombre: $('#Nombre').val(),
        Cuenta: $('#Cuenta').val(),
        Email: $('#Email').val(),
        Telefono: $('#Telefono').val(),
        Contraseña: $('#Contraseña').val(),
        VencimientoP: $('#VencimientoP').val(),
        VencimientoC: $('#VencimientoC').val(),
        Tipo: $('#Tipo').val(),
        Pantallas: $('#Pantallas').val(),
        Comentario: $('#Comentario').val()
    };

    ajaxJson('/Home/NuevoCliente', { data: data }, function (response) {
        if (response === true) {
            window.location.href = '/Home/Index';
        }
        else {
            alert('No se pudo crear el cliente');
        }
    });
}

function EnviarEdicion(id) {
    // Collect form values and trim whitespace
    var data = {
        Id: id,
        Nombre: $('#Nombre').val().trim(),
        Cuenta: $('#Cuenta').val().trim(),
        Email: $('#Email').val().trim(),
        Telefono: $('#Telefono').val().trim(),
        Contraseña: $('#Contraseña').val().trim(),
        VencimientoP: $('#VencimientoP').val().trim(),
        VencimientoC: $('#VencimientoC').val().trim(),
        Tipo: $('#Tipo').val().trim(),
        Pantallas: $('#Pantallas').val().trim(),
        Comentario: $('#Comentario').val().trim()
    };

    // Basic validation: ensure required fields are not empty
    if (!data.Nombre) {
        alert('El nombre es obligatorio.');
        return;
    }
    if (!data.Cuenta) {
        alert('La cuenta es obligatoria.');
        return;
    }

    ajaxJson('/Home/Editar', { data: data }, function (response) {
        if (response === true) {
            window.location.href = '/Home/Index';
        }
        else {
            alert('Error al guardar los cambios');
        }
    });
}

$('#LogInBtn').on('click', function (event) {
    event.preventDefault();

    var data = {
        Usuario1: $('#UserInput').val(),
        Password: $('#PasswordInput').val()
    };

    ajaxJson('/User/Login', { Data: data }, function (response) {
        if (response === true) {
            window.location.href = '/Home/Index';
        }
        else {
            $('#Message').removeAttr('hidden');
            $('#Message').html('Usuario o contraseña incorrecto');
        }
    });
});

function UnifiedSearch() {
    var searchText = $('#searchText').val();
            ajaxJson('/Home/UnifiedSearch', { search: searchText.toLowerCase() }, function (data) {
                renderClientes(data);
            });
}

function BuscarCliente() {
    UnifiedSearch();
}

function MostrarTodas() {
    ajaxJson('/Home/MostrarTodas', {}, function (data) {
        renderClientes(data);
    });
}

function cuentasLibre() {
    ajaxJson('/Home/CuentaLibre', {}, function (data) {
        renderClientes(data);
    });
}

function filtrarPorTipo() {
    var tipoId = $('#filtroTipo').val();
    if (tipoId == 0) {
        MostrarTodas();
    } else {
        ajaxJson('/Home/FiltrarPorTipo', { tipoId: tipoId }, function (data) {
            renderClientes(data);
        });
    }
}

function BuscarPorFecha() {
    ajaxJson('/Home/BuscarPorFecha', {}, function (data) {
        renderClientes(data);
    });
}

function BuscarPorFechaCuenta() {
    ajaxJson('/Home/BuscarPorFechaCuenta', {}, function (data) {
        renderClientes(data);
    });
}

function BuscarCuenta() {
    ajaxJson('/Home/BuscarCuenta', {}, function (data) {
        renderClientes(data);
    });
}

function agregarTipo() {
    var nombre = $('#NuevoTipoNombre').val();
    if (!nombre || !nombre.trim()) {
        alert('Escribi un nombre para el tipo');
        return;
    }

    ajaxJson('/Home/AgregarTipo', { nombre: nombre }, function (response) {
        if (response && response.success) {
            window.location.reload();
        }
        else {
            alert((response && response.message) || 'No se pudo agregar el tipo');
        }
    });
}

function editarTipo(id) {
    var nombreActual = $('#tipo-name-' + id).text();
    var nuevoNombre = prompt('Nuevo nombre para el tipo', nombreActual);

    if (!nuevoNombre || !nuevoNombre.trim()) {
        return;
    }

    ajaxJson('/Home/EditarTipo', { id: id, nombre: nuevoNombre }, function (response) {
        if (response && response.success) {
            window.location.reload();
        }
        else {
            alert((response && response.message) || 'No se pudo editar el tipo');
        }
    });
}

function eliminarTipo(id) {
    if (!confirm('Seguro de borrar este tipo? Si ya esta en uso, no se eliminara.')) {
        return;
    }

    ajaxJson('/Home/EliminarTipo', { id: id }, function (response) {
        if (response && response.success) {
            window.location.reload();
        }
        else {
            alert((response && response.message) || 'No se pudo eliminar el tipo');
        }
    });
}
