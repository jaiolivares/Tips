const fileSystem = require("fs");
const path = require("path");

const User = require("../models/user");
const bcryptjs = require("bcryptjs");
const jwt = require("../services/jwt");
const { restart } = require("nodemon");

async function register(req, res) {
  console.log("Servidor: Registrando usuarios");

  const user = new User(req.body);
  const { email, password } = req.body;

  try {
    if (!email) throw { msg: "El email es obligatorio" };
    if (!password) throw { msg: "El password es obligatorio" };

    //Revisamos si el email está en uso
    const foundEmail = await User.findOne({ email: email });

    if (foundEmail) throw { msg: "El email ya está en uso" + foundEmail };

    const salt = bcryptjs.genSaltSync(10);
    user.password = await bcryptjs.hash(password, salt);
    user.save();

    res.status(200).send(user);

    console.log(salt + " | " + user.password);
  } catch (error) {
    res.status(500).send(error);
  }
}

async function login(req, res) {
  console.log("Servidor: Login...");

  const { email, password } = req.body;

  try {
    const user = await User.findOne({ email });
    if (!user) throw { msg: "Error en el email o contraseña" };

    const passwordSucces = await bcryptjs.compare(password, user.password);
    if (!passwordSucces) throw { msg: "--Error en el email o contraseña--" };

    const newToken = jwt.createToken(user, "4m"); //12 horas "12h"

    res.status(200).send({ token: newToken });
  } catch (error) {
    res.status(500).send(error);
  }
}

function protected(req, res) {
  res.status(200).send({ msg: "Contenido del Endpoint protegido" });
}

function uploadAvatar(req, res) {
  console.log("Servidor: Upload Avatar...");

  const params = req.params;

  console.log(req.files);

  User.findById({ _id: params.id }, (err, userData) => {
    if (err) {
      res.status(500).send({ msg: "Error del servidor" });
    } else {
      if (!userData) {
        res.status(404).send({ msg: "No se ha encontrado el usuario" });
      } else {
        let user = userData;
        if (req.files) {
          const filePath = req.files.avatar.path;
          const fileSplit = filePath.split("\\");
          const fileName = fileSplit[1];

          const extSplit = fileName.split(".");
          const fileExt = extSplit[1];

          if (fileExt !== "png" && fileExt !== "jfif") {
            res.status(400).send({
              msg: "La extensión de la imagen no es válida (Solo se permite png o jpg",
            });
          } else {
            user.avatar = fileName;

            User.findByIdAndUpdate(
              { _id: params.id },
              user,
              (err, userResult) => {
                if (err) {
                  res.status(500).send({ msg: "Error del servidor" });
                } else {
                  if (!userResult) {
                    res
                      .status(404)
                      .send({ msg: "No se ha encontrado el usuario" });
                  } else {
                    res.status(200).send({ msg: "Avatar actualizado" });
                  }
                }
              }
            );
          }
        }
      }
    }
  });
}

function getAvatar(req, res) {
  console.log("Servidor: Obteniendo Avatar");

  const { avatarName } = req.params;

  //const filePath = "../uploads/" + avatarName;
  const filePath = `C:\\000_DEV\\GIT\\jaiolivares\\Node JS\\ApiREst_ExpressJs_MongoDb_2\\uploads\\${avatarName}`;

  console.log(filePath);

  fileSystem.stat(filePath, (err, stat) => {
    if (err) {
      console.log(err);
      res.status(404).send({ msg: "El avatar no existe" });
    } else {
      res.sendFile(path.resolve(filePath));
    }
  });
}

module.exports = {
  register,
  login,
  protected,
  uploadAvatar,
  getAvatar,
};
