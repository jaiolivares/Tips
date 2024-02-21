const API_URL = "http://jsonplaceholder.typicode.com/";

const xhr = new XMLHttpRequest();

console.log("Sitio Iniciado");

function onRequestHandler() {
  if (this.readyState == 4 && this.status == 200) {
    // 0 = UNSET, no se ha llamado al método open
    // 1 = OPENED, se ha llamado al método open
    // 2 = HEADERS_RECEIVED, se está llamando al método SEND()
    // 3 = LOADING, está cargando, está recibiendo la respuesta
    // 4 = DONE, se ha completado la operación
    console.log(this.response);

    const data = JSON.parse(this.response);
    console.log(data);

    const HTMLResponse = document.querySelector("#app");

    const tpl = data.map((u) => `<li>${u.name} |M| ${u.email}</li>`);
    HTMLResponse.innerHTML = `<ul>${tpl}</ul>`;
  }
}

xhr.addEventListener("load", onRequestHandler); //estado 0
xhr.open("GET", `${API_URL}/users`); //estado 1
xhr.send(); //estado 2
