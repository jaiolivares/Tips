function getHelloMundo(req, res) {
  res.status(200).send({ msg: "HelloMundo desde controllers" });
}

module.exports = { getHelloMundo };
