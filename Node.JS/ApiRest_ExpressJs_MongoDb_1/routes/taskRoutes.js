const express = require("express");
const TaskController = require("../controllers/taskControllers");

const api = express.Router();

api.get("/health", TaskController.getHealth);
api.post("/task", TaskController.createTask);
api.get("/task", TaskController.getTasks);
api.get("/task/:id", TaskController.getTask);
api.put("/task/:id", TaskController.updateTask);
api.delete("/task/:id", TaskController.deleteTask);

module.exports = api;
