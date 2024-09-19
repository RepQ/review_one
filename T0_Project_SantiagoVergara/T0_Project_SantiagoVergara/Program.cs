using System;
using System.Collections.Generic;
class Program
{
    //Funcion encargada de calcular el promedio de las notas
    public static void Promig(int[] notas)
    {
        int suma;
        float promig;

        suma = notas[0] + notas[1] + notas[2];
        promig = (float)suma / 3;
        Console.WriteLine("El promig de les notes es: " + promig);
        if (promig >= 6)
            Console.WriteLine("Aprovat");
        else
            Console.WriteLine("Suspés");
    }

    //Funcion encargada de obtener las 3 calificaciones
    public static void Qualificacion(int[] notas)
    {
        Console.WriteLine("Introdueix la primera qualificació");
        notas[0] = Convert.ToInt32(Console.ReadLine());

        Console.WriteLine("Introdueix la segona qualificació: ");
        notas[1] = Convert.ToInt32(Console.ReadLine());

        Console.WriteLine("Introdueix la tercera qualificació: ");
        notas[2] = Convert.ToInt32(Console.ReadLine());
    }

    //Funcion encargada de Obtener las ciudades y sus respectivos codigos postales
    public static void Cities()
    {
        bool stop;
        Dictionary<String, int> Cities;

        stop = false;
        Cities = new Dictionary<string, int>();
        do
        {
            Console.WriteLine($"Ingrese el nombre de la ciudad: ");
            String City = Console.ReadLine();
            Console.WriteLine($"Ingrese el codigo postal de la Ciudad {City}: ");
            int CityPostal = Convert.ToInt32(Console.ReadLine());
            Cities.Add(City, CityPostal);
            Console.WriteLine("Presione 0 para continuar, cualquier otra tecla para parar: ");
            if (Convert.ToInt32(Console.ReadLine()) != 0)
                stop = true;
        }
        while (!stop);

        ShowCities(Cities);
    }

    //Funcion encargada de mostrar por pantalla las ciudades y codigos postales obtenidos en un formato Ciudad - Codigo Postal
    public static void ShowCities(Dictionary<String, int> Cities)
    {
        foreach (var entry in Cities)
        {
            Console.WriteLine($"Ciudad: {entry.Key} - Codigo Postal {entry.Value}");
        }
    }
    static void Main(string[] args)
    {
        //Array de notas tipo int
        int[] notas;

        //Creacion del array
        notas = new int[3];

        //Llamado a funciones
        Cities();
        Qualificacion (notas);
        Promig(notas);
    }
}
