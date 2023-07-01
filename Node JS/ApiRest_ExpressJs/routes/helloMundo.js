const express = require("express");
const HelloMundoController = require("../controllers/helloMundo");

const api = express.Router();

api.get("/helloMundo", HelloMundoController.getHelloMundo);

module.exports = api;
