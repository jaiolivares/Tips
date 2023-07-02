const mongoose = require("mongoose");
const app = require("./app");
const port = 3000;
const urlMongDb =
  "mongodb+srv://admin:admin@clusterjolivares.ooqb3is.mongodb.net/mydb";

mongoose.connect(
  urlMongDb,
  { useNewUrlParser: true, useUnifiedTopology: true, useFindAndModify: false },
  (err, res) => {
    try {
      if (err) {
        throw err;
      } else {
        console.log("La conexión a la Base de datos es correcta");

        app.listen(port, () => {
          console.log(
            "Servidor del API REST está funcionando en http://localhost:3000"
          );
        });
      }
    } catch (error) {
      console.error("catch " + error);
    }
  }
);
