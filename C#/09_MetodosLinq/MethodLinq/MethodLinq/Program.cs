Method_Union();
Method_Zip();
Method_All();
Method_Join();
Method_SelectMany();

static void Method_Union()
{
    var numeros1 = new int[] { 1, 2, 3, 4, 5, 6, 6, 6, 6 };
    var numeros2 = new int[] { 6, 7, 8, 9, 10, 10, 10, 10, 10 };

    var numerosWithUnion = numeros1.Union(numeros2);

    //El número 6 no se repite, a pesar de que está en los dos arreglos.
    numerosWithUnion.ToList().ForEach(x => Console.WriteLine(x));
    Console.WriteLine("-----------------------------------------------");
}

static void Method_Zip()
{
    var numeros1 = new int[] { 1, 2, 3, 5, 6, 7, 8, 9, 10 };
    var numerosTexto = new string[] { "uno", "dos", "tres", "cuatro", "cinco" };

    var numerosWithZip = numeros1.Zip(numerosTexto, (num, text) =>
    {
        return num + " - " + text;
    });

    //Solo se consideran los elementos que se encuentran en la misma posición
    numerosWithZip.ToList().ForEach(x => Console.WriteLine(x));
    Console.WriteLine("-----------------------------------------------");
}

static void Method_All()
{
    var numeros1 = new int[] { 1, 2, 3, 4, 5 };
    var numeros2 = new int[] { 6, 7, 8, 9, 10 };
    var numeros3 = new int[] { 11, 12, 3, 13, 14 };

    //Valida que todos los elementos sean mayor a 5
    Console.WriteLine(numeros1.All(x => x > 5));
    Console.WriteLine(numeros2.All(x => x > 5));
    Console.WriteLine(numeros3.All(x => x > 5));
}

static void Method_Join()
{
    var modelos = new List<(string Nombre, int IdMarca)>
    {
        ("Alto",1),
        ("Maruti",1),
        ("Aveo",2),
        ("Tracker",2),
        ("Sail",2),
        ("March",3)
    };

    var marcas = new List<(int IdMarca, string Nombre)>
    {
        (1, "Suzuki"),
        (2, "Chevrolet"),
        (3, "Nissan")
    };

    var marcaModelo = modelos.Join(marcas, ma => ma.IdMarca, mo => mo.IdMarca, (modelo, marca) =>
    {
        return new
        {
            Marca = marca.Nombre,
            Modelo = modelo.Nombre
        };
    });

    //Realiza una unión de los campos por el Id en común, como ForeingKey de BD
    marcaModelo.ToList().ForEach(Console.WriteLine);
    marcaModelo.ToList().ForEach(x =>
    {
        Console.WriteLine(x.Marca + " - " + x.Modelo);
    });
    Console.WriteLine("-----------------------------------------------");
}

static void Method_SelectMany()
{
    var marcaModelo = new List<(string Marcas, List<string> Modelos)>
    {
        ("Suzuki", new List<string>{"Alto","Maruti"}),
        ("Chevrolet", new List<string>{"Aveo","Tracker","Sail"}),
        ("Nissan", new List<string>{"March" })
    };

    var detalle = marcaModelo.SelectMany(x => x.Modelos, (marca, modelo) => new { marca, modelo }).Select(marca =>
    {
        return new
        {
            ModeloNombre = marca.modelo,
            MarcaNombre = marca.marca.Marcas
        };
    });

    detalle.ToList().ForEach(x =>
    {
        Console.WriteLine($"{x.MarcaNombre}" + " | " + $"{x.ModeloNombre}");
    });
}