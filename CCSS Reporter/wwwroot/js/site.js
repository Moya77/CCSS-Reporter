
function validForm() {
    const formulario = document.getElementById('FormProfesional');

    const camposInvalidos = Array.from(formulario.elements).filter(
        campo => !campo.checkValidity()
    );

    for (let campoInvalido of camposInvalidos) {
        campoInvalido.style.borderColor = "red";
    }
}

function FillForm() {
    const formulario = document.getElementById('FormProfesional');
    const boton = document.getElementById('btnSave');

    const camposVacios = Array.from(formulario.elements).filter(
        campo => (campo.value.length == 0)
    );

    if (camposVacios.length > 0) {
        boton.disabled = true;
    } else {
        boton.disabled = false;
    }

    function RegistrarClinica() {
        $(document).ready(function () {
            $('#FormProfesional').submit(function (event) {
                event.preventDefault(); // Prevenir el envío del formulario por defecto
                var form = $(this);
                $.ajax({
                    url: '/api/RegistroClinica/RegistrarClinica',
                    type: 'POST',
                    data: form.serialize(),
                    success: function () {
                        alert('Registro exitoso');
                    },
                    error: function () {
                        alert('Error al registrar');
                    }
                });
            });
        });
    }
}
