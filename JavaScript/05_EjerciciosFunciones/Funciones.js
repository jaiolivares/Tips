//Función que devuelva la diferencia entre el menor y mayor de una lista
function DiferenciaMinimoMaximo(lista = []) {
  if (lista.length <= 0) return "Lista vacía.";

  let valorMinimo = Math.min(...lista);
  let valorMaximo = Math.max(...lista);

  return valorMaximo - valorMinimo;
}
console.log(DiferenciaMinimoMaximo());
console.log("La diferencia entre el mayor y menos es: " + DiferenciaMinimoMaximo([9, 5, 4, 3, 4, 9, 10, 22, 2, 7]));

//Función que entrega la cantidad de palabras de una frase
function CantidadPalabrasDeUnaFrase(frase) {
  if (frase == "") return "Frase no puede ser vacía.";

  let fraseSplit = frase.split(" ");

  return fraseSplit.length;
}

console.log(CantidadPalabrasDeUnaFrase(""));
console.log("La cantidad de palabras que tiene la frase es: " + CantidadPalabrasDeUnaFrase("Contar la cantidad de palabras que tiene esta frase"));

//Función que crea una lista de números enteros al azar entre un rango definido
function ListaAlAzarDeRango(cantidadNumeros, min, max) {
  let lstNumeros = [];
  for (let i = 0; i < cantidadNumeros; i++) {
    lstNumeros.push(Math.floor(Math.random() * (max - min + 1) + min));
  }

  return lstNumeros;
}

console.log("Lista de números aleatorios: " + ListaAlAzarDeRango(20, 5, 15));

//Función que devuelva los números pares entre rango
function SoloNumerosPares(min, max) {
  let lstNumerosPares = [];
  for (let i = min; i <= max; i++) {
    if (i % 2 === 0) {
      lstNumerosPares.push(i);
    }
  }
  return lstNumerosPares;
}

console.log("Los números pares son: " + SoloNumerosPares(41, 100));

//Función para sumar solo números impares entre un rango
function SumaSoloNumerosImpares(min, max) {
  let sumaNumerosImpares = 0;
  for (let i = min; i <= max; i++) {
    if (i % 2 === 1) {
      sumaNumerosImpares += i;
    }
  }
  return sumaNumerosImpares;
}

console.log("La suma de los números impares es: " + SumaSoloNumerosImpares(1, 3));

//Función para recorrer array y concatenar resultados
function ArrayConcatenado(array) {
  let concatenados = "";
  // array.forEach((item) => {
  //   concatenados += item.charAt().toUpperCase() + item.slice(1);
  // });

  //Alternativa 2
  /*for (let item of array) {
    concatenados += item.charAt().toUpperCase() + item.slice(1);
  }*/

  //Alternativa 3
  /*concatenados = array.join("");*/
  return concatenados;
}

console.log("Array concatenado: " + ArrayConcatenado(["junta", "todo", "el", "texto"]));

//Función que devuelva el área y permímetro de un cirulo
function RadioPerimetro(cmsCirculo) {
  let area = Math.PI * cmsCirculo ** 2;
  let perimetro = Math.PI * cmsCirculo * 2;
  return "Área: " + area + ", Perímetro: " + perimetro + ", de un círculo de " + cmsCirculo + "cms.";
}

//Función que reversa array sin unsar .reverse()
function ReversarArray(array) {
  //return array.reverse();

  let arrayOrdenadoAlReves = [];
  for (i = array.length - 1; i >= 0; i--) {
    arrayOrdenadoAlReves.push(array[i]);
  }
  return arrayOrdenadoAlReves;
}

console.log("El array ordenado sin usar .reverse() es: " + ReversarArray([1, 2, 3, 4, 5, 6, 7, 8, 9, 10, 11, 12, 13, 14, 15, 16]));

//Función SerieFibonachi
function SerieFibonachi(cantidadRegistros) {
  let lstSerieFibo = [];

  let valor1 = 0;
  let valor2 = 1;
  let resultado = valor1 + valor2;

  lstSerieFibo.push(0);

  for (let i = 0; i < cantidadRegistros - 1; i++) {
    lstSerieFibo.push(resultado);
    valor2 = valor1;
    valor1 = resultado;
    resultado = valor1 + valor2;
  }

  return lstSerieFibo;
}

console.log("Serie Fibonachi: " + SerieFibonachi(13));
