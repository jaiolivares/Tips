const xhr = new XMLHttpRequest();

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

    console.log(data.results);

    data.results.forEach((element) => {
      console.log(element.id);
    });
  }
}

xhr.addEventListener("load", onRequestHandler); //estado 0
xhr.open("GET", "https://randomuser.me/api/"); //estado 1
xhr.send(); //estado 2
