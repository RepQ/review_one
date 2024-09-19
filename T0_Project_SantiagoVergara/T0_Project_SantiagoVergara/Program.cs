using System;
using System.Collections.Generic;

public class Constantes
{
    static public String APROBADO = "Aprobado";
    static public String SUSPENDIDO = "Suspendido";
    static public String PROMEDIO = "El promedio de las notas es: ";
    static public String CALIFICACION = "Introduzca la calificacion # ";
    static public String CONTINUE_MENSAJE = "Presione 0 para continuar, cualquier otra para terminar: ";
    static public String INGRE_CIUDAD = "Ingrese el nombre de la ciudad: ";
    static public String INGRE_COD_POSTAL = "Ingrese el codigo postal de la Ciudad";
    static public float MINIMO_PROMEDIO = 6;
}
public class Program
{
    //Funcion encargada de calcular el promedio de las notas
    public static void Promig(List<int> notas)
    {
        float promig;

        promig = (float)notas.Average();
        Console.WriteLine(Constantes.PROMEDIO + promig);
        if (promig >= Constantes.MINIMO_PROMEDIO)
            Console.WriteLine(Constantes.APROBADO);
        else
            Console.WriteLine(Constantes.SUSPENDIDO);
    }

    //Funcion encargada de obtener las 3 calificaciones
    public static void Qualificacion(List<int> notas)
    {
        int i;
        bool stop;

        i = 0;
        stop = false;
        while (!stop)
        {
            Console.WriteLine(Constantes.CALIFICACION + (i + 1));
            int note = Convert.ToInt32(Console.ReadLine());
            notas.Add(note);
            Console.WriteLine(Constantes.CONTINUE_MENSAJE);
            if (Convert.ToInt32(Console.ReadLine()) != 0)
                stop = true;
            i++;
            Console.Clear();
        }
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
            Console.WriteLine(Constantes.INGRE_CIUDAD);
            String City = Console.ReadLine();
            Console.WriteLine(Constantes.INGRE_COD_POSTAL);
            int CityPostal = Convert.ToInt32(Console.ReadLine());
            Cities.Add(City, CityPostal);
            Console.WriteLine(Constantes.CONTINUE_MENSAJE);
            if (Convert.ToInt32(Console.ReadLine()) != 0)
                stop = true;
            Console.Clear();
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
        Console.WriteLine("Presione Cualquier tecla para continuar: ");
        Console.ReadLine();
        Console.Clear();
    }
    static void Main(string[] args)
    {
        List<int> notas;

        notas = new List<int>();
        Cities();
        Qualificacion(notas);
        Promig(notas);
    }
}