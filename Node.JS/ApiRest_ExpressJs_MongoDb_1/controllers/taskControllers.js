const Task = require("../models/taskModels");

async function getHealth(){
  res.status(200).send({msg: "Controller OK"});
}

async function createTask(req, res) {
  console.log("Servidor: Creando nuestra primera tarea");
  console.log("Servidor: ParametrosJSON: " + req.body);

  const task = new Task();
  const params = req.body;

  task.title = params.title;
  task.description = params.description;

  try {
    const taskStore = await task.save();

    if (!taskStore) {
      res.status(400).send({ msg: "No se ha guardado la tarea" });
    } else {
      res.status(200).send({ task: taskStore });
    }
  } catch (error) {
    res.status(500).send("Error TryCatch: " + error);
  }
}

async function getTasks(req, res) {
  console.log("Servidor: Retorna todas las tareas");

  try {
    const tasks = await Task.find({ completed: false }).sort({
      created_at: -1,
    });

    if (!tasks) {
      res.status(401).send({ msg: "No se encuentran tareas" });
    } else {
      res.status(200).send({ AllTasks: tasks });
    }
  } catch (error) {
    res.status(500).send("Error TryCatch: " + error);
  }
}

async function getTask(req, res) {
  console.log("Servidor: Retorna una tarea por el ID");

  const idTask = req.params.id;

  try {
    const task = await Task.findById(idTask);

    if (!task) {
      res.status(401).send({ msg: "No se encuentran la tarea con el ID" });
    } else {
      res.status(200).send({ Task: task });
    }
  } catch (error) {
    res.status(500).send("Error TryCatch: " + error);
  }
}

async function updateTask(req, res) {
  console.log("Servidor: EndPoint update");

  const idTask = req.params.id;
  const params = req.body;
  try {
    const task = await Task.findByIdAndUpdate(idTask, params);

    if (!task) {
      res.status(400).send({ msg: "No se ha actualizado la tarea" });
    } else {
      res.status(200).send({ taskUpdate: params });
    }
  } catch (error) {
    res.status(500).send("Error TryCatch: " + error);
  }
}

async function deleteTask(req, res) {
  console.log("Servidor: EndPoint delete");

  const idTask = req.params.id;

  try {
    const task = await Task.findByIdAndDelete(idTask);

    if (!task) {
      res.status(400).send({ msg: "No se ha eliminado la tarea" });
    } else {
      res.status(200).send({ tareaEliminada: task });
    }
  } catch (error) {
    res.status(500).send("Error TryCatch: " + error);
  }
}

module.exports = { getHealth, createTask, getTasks, getTask, updateTask, deleteTask };
