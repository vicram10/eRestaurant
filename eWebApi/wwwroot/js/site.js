$(document).ready(function () {

    const loader = $(".se-pre-con");

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

                Notificaciones(mensaje, 'error');
            }
            console.log('finalizamos la consulta para inicio de sesion');
        });
    });
});

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
