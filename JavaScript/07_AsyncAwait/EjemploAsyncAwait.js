//Ejemplo Sincrono
function encenderCarbonSync() {
  setTimeout(() => {
    console.log("2. Carbón encendido Sync.");
  }, 1500);
}

function prepararParrillaSync() {
  console.log("<-- INICIO Ejemplo Sincrono -->");
  console.log("1. Encendiendo el carbón...");
  encenderCarbonSync();
  console.log("3. Preparando la carne...");
  console.log("<-- FIN Ejemplo Sincrono -->");
}
prepararParrillaSync();

console.log("<------------------------------->");

//Ejemplo Asincrono

prepararParrillaAsync();

function encenderCarbonAsync() {
  return new Promise((resolve) => {
    setTimeout(() => {
      resolve("2. Carbón encendido Async.");
    }, 2000);
  });
}

async function prepararParrillaAsync() {
  console.log("<-- INICIO Ejemplo Asincrono -->");
  console.log("1. Encendiendo el carbón 2...");
  const carbonListo = await encenderCarbonAsync();
  console.log(carbonListo);
  console.log("3. Preparando la carne 2...");
  console.log("<-- FIN Ejemplo Asincrono -->");
}
