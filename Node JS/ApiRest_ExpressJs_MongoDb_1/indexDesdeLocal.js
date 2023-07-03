console.log("Hola mundo");

// const express = require("express");
// const app = express();
//Las lineas anteriores ya no van para el ejemplo del primer app.get, ya que en el "routes" se declaró el "./app.js"

const app = require("./app");
const port = 3000;

app.get("/helloWord", (req, res) => {
  //res.send()
  console.log(
    "Respuesta por parte del servidor al ejecutar en EndPoint /helloWord port 3000"
  );
  res
    .status(200)
    .send({ msg: "Mensaje de respuesta para el cliente (Hola Mundo!!)" });
});

app.listen(port, () => {
  console.log("Servidor del API REST está funcionando en localhost:3000");
});
