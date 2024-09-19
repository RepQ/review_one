using System;
using System.Collections.Generic;

public class Constantes
{
    public const String APROBADO = "Aprobado";
    public const String SUSPENDIDO = "Suspendido";
    public const String PROMEDIO = "El promedio de las notas es: ";
    public const String CALIFICACION = "Introduzca la calificacion # ";
    public const String CONTINUE_MENSAJE = "Presione 0 para continuar, cualquier otra para terminar: ";
    public const String INGRE_CIUDAD = "Ingrese el nombre de la ciudad: ";
    public const String INGRE_COD_POSTAL = "Ingrese el codigo postal de la Ciudad";
    public const String SEPARADOR = "  -   ";
    public const String FORMATO_CIUDAD = "CIUDAD   -   CODIGO POSTAL";
    public const String CONTINUAR = "Ingrese cualquier valor para continuar";
    public const String UNKWON = "Unkwon City";
    public const String NUMERO_NO_VALIDO = "Número no válido";
    public const float MINIMO_PROMEDIO = 6;
    public const int PRESIONA_CONTINUAR = 0;
}
public class Program
{
    public static String StringSegura()
    {
        String texto;
        
        texto = Console.ReadLine() ?? Constantes.UNKWON;
        return (texto);
    }
    public static int NumeroSeguro()
    {
        int Calificacion;

        while (!int.TryParse(Console.ReadLine(), out Calificacion))
            Console.WriteLine(Constantes.NUMERO_NO_VALIDO);
        return (Calificacion);
    }
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
    public static void Qualificacion(List<int> notas, Func<int>ObtenerCalificacion, Func<int>Continuar)
    {
        int i;
        int note;
        bool stop;

        i = 0;
        stop = false;
        while (!stop)
        {
            Console.WriteLine(Constantes.CALIFICACION + (i + 1));
            note = ObtenerCalificacion();
            notas.Add(note);
            Console.WriteLine(Constantes.CONTINUE_MENSAJE);
            if (Continuar() != Constantes.PRESIONA_CONTINUAR)
                stop = true;
            i++;
            Console.Clear();
        }
    }

    //Funcion encargada de Obtener las ciudades y sus respectivos codigos postales
    public static void ListCities(Dictionary<String, int> Cities, Func<String>ObtenerCiudad, Func<int>ObtenerCodigoPostal)
    {
        String City;
        int CityPostal;
        bool stop;

        stop = false;
        while (!stop)
        {
            Console.WriteLine(Constantes.INGRE_CIUDAD);
            City = ObtenerCiudad() ?? Constantes.UNKWON;
            Console.WriteLine($"{Constantes.INGRE_COD_POSTAL} {City}");
            CityPostal = ObtenerCodigoPostal();
            Cities.Add(City, CityPostal);
            Console.WriteLine(Constantes.CONTINUE_MENSAJE);
            if (NumeroSeguro() != Constantes.PRESIONA_CONTINUAR)
                stop = true;
            Console.Clear();
        }
        ShowCities(Cities);
    }

    //Funcion encargada de mostrar por pantalla las ciudades y codigos postales obtenidos en un formato Ciudad - Codigo Postal
    public static void ShowCities(Dictionary<String, int> Cities)
    {
        Console.WriteLine(Constantes.FORMATO_CIUDAD);
        foreach (var entry in Cities)
        {
            Console.WriteLine($"{entry.Key}{Constantes.SEPARADOR}{entry.Value}");
        }
        Console.WriteLine(Constantes.CONTINUAR);
        Console.ReadLine();
        Console.Clear();
    }
    static void Main(string[] args)
    {
        Dictionary<String, int> Cities;
        List<int> notas;

        notas = new List<int>();
        Cities = new Dictionary<string, int>();
        ListCities(Cities, ()=>StringSegura(), ()=>NumeroSeguro());
        Qualificacion(notas, ()=>NumeroSeguro(), ()=>NumeroSeguro());
        Promig(notas);
    }
}