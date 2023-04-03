
function validForm() {
    const formulario = document.getElementById('FormProfesional');

    const camposInvalidos = Array.from(formulario.elements).filter(
        campo => !campo.checkValidity()
    );

    for (let campoInvalido of camposInvalidos) {
        campoInvalido.style.borderColor = "red";
    }
}

function inyeccionCheck() {
     let VacunaSaramRubParoti1 = document.getElementById('VacunaSaramRubParoti1');
  let VacunaTetHepAoBInfl1 = document.getElementById('VacunaTetHepAoBInfl1');

  if (VacunaSaramRubParoti1.checked) {
      VacunaSaramRubParoti1.value = "true";
  } else {
      VacunaSaramRubParoti1.value = "false";
  }
  if (VacunaTetHepAoBInfl1.checked) {
      VacunaTetHepAoBInfl1.value = "true";
  } else {
      VacunaTetHepAoBInfl1.value = "false";
  }
  
}

function FillForm() {
    const formulario = document.getElementById('FormProfesional');
    const boton = document.getElementById('btnSave');
 

    const camposVacios = Array.from(formulario.elements).filter(
        campo => (campo.value.length == 0)
    );

    if (camposVacios.length > 0) {
     //  boton.disabled = true;
    } else {
        boton.disabled = false;
    }

  
}
function EnableDisableCovidData() {
    let section1 = document.getElementById("subSectCovid1");
    let section2 = document.getElementById("subSectCovid2");
    let comment = document.getElementById("CovidComent1");

    if (document.getElementById("YES").checked) {
        section1.className = "ShowSectCovid";
        section2.className = "HideSectCovid";
        comment.value = "Paciente Vacunado";
    } else {
        section1.className = "HideSectCovid";
        section2.className = "ShowSectCovid";
        comment.value = "";
    }

}

function buscarProfesional() {
    var identificacion = document.getElementById("Identificacion").value;
    fetch("/RegistroProfesional/GetRegistroProfesional/" + identificacion)
        .then(response => response.json())
        .then(data => {
            document.getElementById("CodigoProfesional").value = data.codigoProfesional1;
            document.getElementById("NombreCompleto").value = data.nombreCompleto1;
            document.getElementById("Correo").value = data.correo;
            document.getElementById("Pais").value = data.pais1;
            document.getElementById("Estado").value = data.estado1;
            document.getElementById("Provincia").value = data.provincia1;
            validForm();
            FillForm();
        })
       
}

function buscarClinica() {
    var identificacion = document.getElementById("CedulaJuridica").value;
    fetch("/RegistroClinica/GetRegistroClinica/" + identificacion)
        .then(response => response.json())
        .then(data => {
            document.getElementById("NombreClinica").value = data.nombreClinica1;
            document.getElementById("pais").value = data.pais;
            document.getElementById("provinciaEstado").value = data.provinciaEstado;
            document.getElementById("distrito").value = data.distrito;
            document.getElementById("Telefono").value = data.telefono1;
            document.getElementById("Correo").value = data.correo;
            document.getElementById("sitioweb").value = data.direccionWeb;
            validForm();
            FillForm();
        })

}

function buscarPaciente() {
    var identificacion = document.getElementById("Identificacion").value;
    fetch("/RegistroPaciente/GetRegistroPaciente/" + identificacion)
        .then(response => response.json())
        .then(data => {
            document.getElementById("Nombre").value = data.nombre;
            document.getElementById("PrimerApellido").value = data.primerApellido;
            document.getElementById("SegundoApellido").value = data.segundoApellido;
            document.getElementById("FechaNacimiento").value = data.fechaNacimiento;
            document.getElementById("Genero").value = data.genero;
            document.getElementById("NumeroContacto").value = data.numeroContacto;
            document.getElementById("Pais").value = data.pais;

            document.getElementById("ProvinciaOestado").value = data.provinciaOestado;
            document.getElementById("Distrito").value = data.distrito;
            document.getElementById("Habita").value = data.dondehabita;
            document.getElementById("EstadoCivil").value = data.estadoCivil;
            document.getElementById("CorreoElectronico").value = data.correoElectronico;
            document.getElementById("FechaRegistro").value = data.fechaRegistro;
            document.getElementById("Ocupacion").value = data.ocupacion;
            validForm();
            FillForm();
        })

}

function SaltarRegistro() {
    const reason = "reason";
    const url = `/RegistroClinica/SaltRegistro?reason=${reason}`;

    fetch(url, {
        method: 'POST',
        headers: {
            'Content-Type': 'application/json'
        }
    })
        .then(response => response.json())
        .then(data => {
            window.location.href = data.url;
        })
        .catch((error) => {
            console.error('Error:', error);
        });
}




