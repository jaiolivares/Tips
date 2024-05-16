const CLIENTES = [
  { id: 1, nombre: "Juan", pais: "CHILE", perfilInversionista: "ACTIVO", saldoConsolidado: 5000000 },
  { id: 2, nombre: "María", pais: "COLOMBIA", perfilInversionista: "MODERADO", saldoConsolidado: 7000000 },
  { id: 3, nombre: "Carlos", pais: "MEXICO", perfilInversionista: "CONSERVADOR", saldoConsolidado: 12000000 },
  { id: 4, nombre: "Ana", pais: "PERU", perfilInversionista: "AGRESIVO", saldoConsolidado: 8500000 },
  { id: 5, nombre: "Luis", pais: "URUGUAY", perfilInversionista: "ACTIVO", saldoConsolidado: 3000000 },
  { id: 6, nombre: "Laura", pais: "ARGENTINA", perfilInversionista: "MODERADO", saldoConsolidado: 9500000 },
  { id: 24, nombre: "Raul", pais: "ARGENTINA", perfilInversionista: "AGRESIVO", saldoConsolidado: 6000000 },
  { id: 7, nombre: "Pedro", pais: "CHILE", perfilInversionista: "CONSERVADOR", saldoConsolidado: 11000000 },
  { id: 8, nombre: "Sofía", pais: "COLOMBIA", perfilInversionista: "AGRESIVO", saldoConsolidado: 8000000 },
  { id: 9, nombre: "Javier", pais: "MEXICO", perfilInversionista: "ACTIVO", saldoConsolidado: 13000000 },
  { id: "10", nombre: "Elena", pais: "PERU", perfilInversionista: "MODERADO", saldoConsolidado: 5500000 },
  { id: 11, nombre: "Diego", pais: "URUGUAY", perfilInversionista: "CONSERVADOR", saldoConsolidado: 7400000 },
  { id: 12, nombre: "Gabriela", pais: "ARGENTINA", perfilInversionista: "AGRESIVO", saldoConsolidado: 8800000 },
  { id: 13, nombre: "Andrés", pais: "CHILE", perfilInversionista: "ACTIVO", saldoConsolidado: 4200000 },
  { id: 14, nombre: "Paula", pais: "COLOMBIA", perfilInversionista: "MODERADO", saldoConsolidado: 6800000 },
  { id: 15, nombre: "Fernando", pais: "MEXICO", perfilInversionista: "CONSERVADOR", saldoConsolidado: 9900000 },
  { id: 16, nombre: "Lucía", pais: "PERU", perfilInversionista: "AGRESIVO", saldoConsolidado: 6300000 },
  { id: 17, nombre: "Gonzalo", pais: "URUGUAY", perfilInversionista: "ACTIVO", saldoConsolidado: 3800000 },
  { id: 28, nombre: "Martha", pais: "CHILE", perfilInversionista: "AGRESIVO", saldoConsolidado: 5670000 },
  { id: 18, nombre: "Valeria", pais: "ARGENTINA", perfilInversionista: "MODERADO", saldoConsolidado: 7200000 },
  { id: 19, nombre: "Marta", pais: "CHILE", perfilInversionista: "CONSERVADOR", saldoConsolidado: 10500000 },
  { id: 20, nombre: "Camilo", pais: "COLOMBIA", perfilInversionista: "AGRESIVO", saldoConsolidado: 4700000 },
  { id: 25, nombre: "Eduardo", pais: "CHILE", perfilInversionista: "CONSERVADOR", saldoConsolidado: 8900000 },
];
/* ...Resultado esperado...
    {
      "CHILE": [....],
      "ARGENTINA": [...]
    }
*/

/*Solución 1*/
let lstPaises = [];
let lstClientesPorPais = [];

CLIENTES.forEach((c) => {
  let pais = c.pais;
  if (lstPaises.findIndex((x) => x === pais) < 0) {
    lstPaises.push(pais);
  }
});

lstPaises.forEach((p) => {
  lstClientesPorPais.push(
    p,
    CLIENTES.filter((x) => x.pais === p)
  );
});

console.log(lstClientesPorPais);

/*Solución 2*/
function filtrarClientesPorPais(clientes) {
  const clientesPorPais = {};

  clientes.forEach((cliente) => {
    const pais = cliente.pais;
    if (!clientesPorPais[pais]) {
      clientesPorPais[pais] = [];
    }
    clientesPorPais[pais].push(cliente);
  });

  return clientesPorPais;
}

const clientesFiltradosPorPais = filtrarClientesPorPais(CLIENTES);
console.log(clientesFiltradosPorPais);
