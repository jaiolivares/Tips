//Wiki arrays: https://developer.mozilla.org/en-US/docs/Web/JavaScript/Reference/Global_Objects/Array/forEach

const crearArray = [
  { title: "My New Post", body: "This is my first post!", Codigo: "111", Nombre: "nombre uno", Activo: "1" },
  { title: "My New Post", body: "This is my first post!", Codigo: "222", Nombre: "nombre dos", Activo: "0" },
];

//console.log(crearArray);

let array = ["AA", "AA", "BB", "CC"];
console.log("orignal => " + array + " <=");

//push: Agregar valor
array = ["AA", "AA", "BB", "CC"];
array.push("DD");
console.log("push -> " + array);

//unshift: Agregar valor al principio
array = ["AA", "AA", "BB", "CC"];
array.unshift("11");
console.log("unshift -> " + array);

//pop: Elimina último valor
array = ["AA", "AA", "BB", "CC"];
array.pop();
console.log("pop -> " + array);

//shift: Elimina el primer valor
array = ["AA", "AA", "BB", "CC"];
array.shift();
console.log("shift -> " + array);

//filter: Filtra elementos del array
array = ["AA", "AA", "BB", "CC"];
console.log("filter -> " + array.filter((array) => array === "AA"));

//map: Recorre array
array = ["AA", "AA", "BB", "CC"];
//array.map((array) => console.log(array)); // (equivalente al forEach)
console.log("map -> " + array.map((array) => array));
const array2 = [1, 4, 9, 16];
console.log("map -> " + array2.map((x) => x * 2));

//forEach: Recorre array
array = ["AA", "AA", "BB", "CC"];
array.forEach((array) => console.log("forEach -> " + array));
array.forEach((valor, posicion) => console.log("forEach -> Posición: " + posicion + " | " + "Valor: " + valor));
const array3 = [1, 4, 9, 16];
array3.forEach((array) => console.log("forEach -> " + array * 2));

//join: Unir array por caracter y convertirlo a string
array = ["AA", "AA", "BB", "CC"];
console.log("join -> " + array.join("-"));

//concat: Unir varios arrays
array = ["AA", "AA", "BB", "CC"];
console.log("concat -> " + array.concat(["EE", "FF"]));

//slice: filtrar elementos entre su posición
array = ["AA", "AA", "BB", "CC"];
console.log("slice -> " + array.slice(1, 4));

//reverse: revertir orden de valores
array = ["AA", "AA", "BB", "CC"];
console.log("reverse -> " + array.reverse(1, 4));

//fill: reemplaza valores de acuerdo a la posición asignada
const array1 = [1, 2, 3, 4];
// Fill with 0 from position 2 until position 4
console.log(array1.fill(0, 2, 4));
// Expected output: Array [1, 2, 0, 0]
// Fill with 5 from position 1
console.log(array1.fill(5, 1));
// Expected output: Array [1, 5, 5, 5]
console.log(array1.fill(6));
// Expected output: Array [6, 6, 6, 6]

//reduce: sumar, restar, multriplicar, dividir... todos los valore dentro del array
const array4 = [1, 2, 3, 4];
// 0 + 1 + 2 + 3 + 4
const initialValue = 0;
const sumWithInitial = array4.reduce((accumulator, currentValue) => accumulator + currentValue, initialValue);
console.log("reduce -> " + sumWithInitial);
// Expected output: 10
