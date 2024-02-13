const moment = require("moment");
const jwt = require("../services/jwt");

const SECRET_KEY = "SD89361RUIVFNBskdj6578flksdf"; //Valor aleatorio

function ensureAuth(req, res, next) {
  if (!req.headers.authorization) {
    return res
      .status(403)
      .send({ msg: "La petición no tiene la cabecera de Autenticación" });
  }

  const token = req.headers.authorization.replace(/['"]+/g, "");

  try {
    const payload = jwt.decodeToken(token, SECRET_KEY);

    if (payload.exp <= moment().unix()) {
      return res.status(400).send({ msg: "El token ha expirado" });
    }

    req.user = payload;
    next();
  } catch (error) {
    return res.status(400).send({ msg: "Token inválido" });
  }
}

module.exports = {
  ensureAuth,
};
