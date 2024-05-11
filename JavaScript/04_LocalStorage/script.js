const elemntTbody = document.getElementById("tbody");
const btnEliminarStorage = document.getElementById("btnEliminarStorage");
const formularioAgregar = document.querySelector("#formAgregar");
var lstAgregados = [];

PintarTabla();
ValorPorDefectoEnTxt();

function PintarTabla() {
  lstAgregadosLocalStorage = localStorage.getItem("lstAgregados");

  if (lstAgregadosLocalStorage === null) {
    console.log("No hay data en el LocalStorage para pintar tabla");
    lstAgregados = [];
    elemntTbody.innerHTML = "<tbody><tr><td>No hay data</td><td></td><td></td><td></td></tr></tbody>";
    return;
  } else {
    if (lstAgregadosLocalStorage.length > 0) {
      lstAgregados = JSON.parse(lstAgregadosLocalStorage);
      if (lstAgregados.length <= 0) {
        console.log("No hay data en el LocalStorage para pintar tabla");
        lstAgregados = [];
        elemntTbody.innerHTML = "<tbody><tr><td>No hay data</td><td></td><td></td><td></td></tr></tbody>";
      }
    } else {
      console.log("No hay data en el LocalStorage para pintar tabla");
      lstAgregados = [];
      elemntTbody.innerHTML = "<tbody><tr><td>No hay data</td><td></td><td></td><td></td></tr></tbody>";
    }
  }

  if (lstAgregados.length > 0) {
    let elementos = lstAgregados
      .map((x) => `<tbody id='tbody'><tr><td>${x.id}</td><td>${x.uuid}</td><td>${x.codigo}</td><td>${x.nombre}</td><td><button type='submit' class="btn btn-secondary" onClick="EliminarItem(${x.id})">Eliminar</td></tr></tbody>`)
      .join("");
    elemntTbody.innerHTML = elementos;
  }
}

btnEliminarStorage.addEventListener("click", (e) => {
  e.preventDefault();
  localStorage.setItem("lstAgregados", []);
  localStorage.setItem("counter", 0);
  PintarTabla();
  ValorPorDefectoEnTxt();
  document.getElementById("resultadoContador").innerHTML = 0;
});

formularioAgregar.addEventListener("submit", (e) => {
  e.preventDefault();
  Agregar();
  PintarTabla();
});

function Agregar() {
  if (lstAgregados === null) {
    lstAgregados = [];
  }

  let id = 1;
  let codigo = document.getElementById("txtCodigo").value;
  let nombre = document.getElementById("txtNombre").value;

  if (lstAgregados.length > 0) {
    let ids = lstAgregados.map((x) => x.id);
    id = Math.max.apply(null, ids) + 1;
  }

  let newElemento = {
    id: id,
    uuid: crypto.randomUUID(),
    codigo: codigo,
    nombre: nombre,
  };

  lstAgregados.push(newElemento);
  localStorage.setItem("lstAgregados", JSON.stringify(lstAgregados));

  ValorPorDefectoEnTxt();
}

function EliminarItem(id) {
  let index = lstAgregados.findIndex((x) => x.id === id);
  if (index > -1) {
    lstAgregados.splice(index, 1);
    localStorage.setItem("lstAgregados", JSON.stringify(lstAgregados));
    PintarTabla();
  }
}

function ValorPorDefectoEnTxt() {
  document.getElementById("txtCodigo").value = Math.floor(Math.random() * 1000);
  document.getElementById("txtNombre").value = TextAleatorio();
}

function TextAleatorio() {
  var text = "";
  var alphabet = "A,B,C,D,E,F,G,H,I,J,K,L,M,N,O,P,Q,R,S,T,U,V,W,X,Y,Z,a,b,c,d,e,f,g,h,i,j,k,l,m,n,o,p,r,s,t,u,v,w,x,y,z".split(",");
  var wordCount = 1;
  for (var i = 0; i < wordCount; i++) {
    var rand = null;
    for (var x = 0; x < 7; x++) {
      rand = Math.floor(Math.random() * alphabet.length);
      text += alphabet[rand];
    }
  }
  return text;
}

var counter = localStorage.getItem("counter") || 0;

//#region CONTADOR INCREMENTAR
window.addEventListener("storage", (e) => {
  if (e.key === "counter") {
    const newCounterValue = +e.newValue;
    document.getElementById("resultadoContador").innerHTML = newCounterValue;
  }
});

document.getElementById("btnContador").addEventListener("click", (e) => {
  counter = localStorage.getItem("counter") || 0;
  counter++;
  document.getElementById("resultadoContador").innerHTML = counter;
  localStorage.setItem("counter", counter);
});
//#endregion CONTADOR INCREMENTAR
