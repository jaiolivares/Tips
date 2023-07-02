function getHelloMundo(req, res) {
  console.log("Servidor: HelloMundo desde controllers");
  res.status(200).send({ msg: "Cliente: HelloMundo desde controllers" });
}

module.exports = { getHelloMundo };
