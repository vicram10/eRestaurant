$(document).ready(function () {

    const loader = $(".se-pre-con");

    var tooltipTriggerList = [].slice.call(document.querySelectorAll('[data-bs-toggle="tooltip"]'))
    var tooltipList = tooltipTriggerList.map(function (tooltipTriggerEl) {
        return new bootstrap.Tooltip(tooltipTriggerEl)
    })

    $('#FormLogin').submit(function (evento) {

        evento.preventDefault();

        loader.show("slow");

        console.log('procesando el login del usuario');

        //hacemos ahora el trabajo del login
        var $form = $(this),
            accion = '/Usuario/IniciarSesion',
            codigo = "",
            mensaje = "";

        var posting = $.post(accion, $form.serialize());

        posting.done(function (data) {

            console.log(data);

            var respuesta = JSON.parse(data);

            codigo = respuesta['CodRespuesta'];

            mensaje = respuesta['MensajeRespuesta'];

            loader.fadeOut("slow");

            if (codigo == 0) {

                window.location.href = '/Portal/Inicio';

            } else {

                NotificacionError(mensaje);
            }
            console.log('finalizamos la consulta para inicio de sesion');
        });
    });
    
    $(".displayDataTableSearch").DataTable({

        language: {
            url: HOST_URL + '/js/datatable.es.json'
        },

    });

    $(".displayDataTableSearch2").DataTable({

        language: {
            url: HOST_URL + '/js/datatable.es.json'
        },

        scrollY: '50vh',

        scrollX: true,

        scrollCollapse: true,

        paging: false,

        ordering: false

    });
});

//para poder agregar dinamicamente al carrito
function AgregarCarrito(IdProducto)
{
    const loader = $(".se-pre-con");

    loader.show("slow");

    console.log('Agregando al carrito de compras');

    //hacemos ahora el trabajo del login
    var $form = $(this),
        accion = '/Producto/AgregarCarrito/' + IdProducto,
        codigo = "",
        mensaje = "";

    var posting = $.get(accion);

    posting.done(function (data) {

        console.log(data);

        var respuesta = JSON.parse(data);

        codigo = respuesta['CodRespuesta'];

        mensaje = respuesta['MensajeRespuesta'];

        loader.fadeOut("slow");

        if (codigo == 0) {

            console.log('Ok agregado al carrito con exito');

            NotificacionOk(mensaje);

        } else {

            NotificacionError(mensaje);
        }
    });
}

//para poder emitir un mensaje de OK
function NotificacionOk(v_mensaje, reload = false, redireccion = '') {
    const SwalConstante = Swal.mixin({
        title: 'Informacion',
        text: v_mensaje,
        icon: 'success',
        confirmButtonText: 'Aceptar'
    });

    if (reload) {

        SwalConstante.fire().then((value) => {

            location.reload();

        });

    } else {


        SwalConstante.fire({}).then((value) => {

            if (redireccion != '') {

                console.log("Redireccionando a => " + redireccion);

                window.location.href = redireccion;
            }

        });



    }
}

//para emitir un mensaje de error
function NotificacionError(v_mensaje) {
    Swal.fire({
        title: 'Error!',
        text: v_mensaje,
        icon: 'error',
        confirmButtonText: 'Aceptar'
    })
}
