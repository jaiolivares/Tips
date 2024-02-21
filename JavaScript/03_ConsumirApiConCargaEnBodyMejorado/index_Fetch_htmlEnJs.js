const API_URL = "http://jsonplaceholder.typicode.com/";

const HTMLResponse = document.querySelector("#app");
const ul = document.createElement("ul");

fetch(`${API_URL}/users`)
  .then((response) => response.json())
  .then((users) => {
    users.forEach((user) => {
      let element = document.createElement("li");
      element.appendChild(
        document.createTextNode(`${user.name} |M| ${user.email}`)
      );
      ul.appendChild(element);
    });

    HTMLResponse.appendChild(ul);
  });
