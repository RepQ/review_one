/* **************************************************************************** */
/*                                                                              */
/*                                               ######   #######   ######      */
/*    Program.cs                                   ##        #      #     #     */
/*                                                 ##        #      #     #     */
/*    By: santi <santi@itb>                        ##        #      #######     */
/*                                                 ##        #      #     #     */
/*    Created: 2024/09/19 22:32:40 by santi        ##        #      #     #     */
/*    Updated: 2024/09/19 22:32:52 by santi      ######      #      ######      */
/*                                                                              */
/* **************************************************************************** */

using System;
using System.Collections.Generic;

// Clase encargada de administrar las constantes del programa
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
    public const String UNKNOW = "UNKNOW City";
    public const String NUMERO_NO_VALIDO = "Número no válido, intente de nuevo: ";
    public const float MINIMO_PROMEDIO = 6;
    public const int PRESIONA_CONTINUAR = 0;
}
public class Program
{
    //  Función genérica encargada de recolectar datos. Esta función evita la repetición de código.
    public static void RecolectarDatos<T>(Action<int> Mensaje, Func<T> ObtenerDatos, Action<T> ProcesarDatos)
    {
        // Variable que lleva el conteo de iteraciones, utilizada para mostrar al usuario cuántos datos ha ingresado
        int i;
        // Variable booleana para controlar cuándo detener el bucle
        bool stop;

        // Inicializamos el índice de iteración a 1 y stop a falso
        i = 1;
        stop = false;
        // Bucle que continuará ejecutándose hasta que el usuario decida detenerse
        while (!stop)
        {
            // Se ejecuta 'Mensaje' para mostrar un mensaje personalizado al usuario. Se le pasa el índice 'i'
            Mensaje(i);
            // Se obtiene el dato mediante la función 'ObtenerDatos', el cual retorna un valor del tipo genérico 'T'
            T dato = ObtenerDatos();
            // El dato obtenido se procesa utilizando el delegado 'ProcesarDatos', que recibe como parámetro el dato 'T'
            ProcesarDatos(dato);
            // Se muestra el mensaje para continuar o terminar
            Console.WriteLine(Constantes.CONTINUE_MENSAJE);
            // Se verifica si el usuario desea detenerse. Si el valor ingresado no es igual a 'PRESIONA_CONTINUAR', se rompe el bucle
            if (NumeroSeguro() != Constantes.PRESIONA_CONTINUAR)
                stop = true;
            // Incrementamos el índice 'i' para la próxima iteración
            i++;
            // Limpiamos la consola después de cada iteración
            Console.Clear();
        }
    }

    //Funcion encargada de validar la String antes de ser usada
    public static String StringSegura()
    {
        //Se valida que la String no sea NULL y se retorna, en caso de serlo se retorna la constante UNKNOW
        return (Console.ReadLine() ?? Constantes.UNKNOW);
    }
    //Funcion encargada de validar el numero ingresado por el usuario
    public static int NumeroSeguro()
    {
        int Calificacion;

        //Bucle que controla la validacion del input, si no se logra convertir a un int se sigue pidiendo el numero
        while (!int.TryParse(Console.ReadLine(), out Calificacion))
            Console.WriteLine(Constantes.NUMERO_NO_VALIDO);
        return (Calificacion);
    }
    //Funcion encargada de mostrar si se aprobó o suspendió dependiendo del promedio
    public static void MostrarResultadoPromedio(float promedio)
    {
        //Condicional para verificar si Aprueba o Suspende, dependiendo del valor de la constante MINIMO_PROMEDIO
        if (promedio >= Constantes.MINIMO_PROMEDIO)
            Console.WriteLine(Constantes.APROBADO);
        else
            Console.WriteLine(Constantes.SUSPENDIDO);
    }
    //Funcion encargada de calcular el promedio de las notas
    public static void CalculoPromedio(List<int> notas)
    {
        float Promedio;

        //Se usa la funcion Average de las listas para obtener el promedio del total de elementos de la lista
        Promedio = (float)notas.Average();
        Console.WriteLine(Constantes.PROMEDIO + Promedio);
        MostrarResultadoPromedio(Promedio);
    }

    //Funcion encargada de obtener las calificaciones
    public static void Calificaciones(List<int> notas, Func<int>ObtenerCalificacion)
    {
        RecolectarDatos
            (
                //Le indicamos al usuario cuantas calificaciones lleva
                i => Console.WriteLine(Constantes.CALIFICACION + i),
                //Se obtiene la calificacion por input del usuario
                () => ObtenerCalificacion(),
                //Se añade la calificacion obtenida a la lista notas
                (nota) => notas.Add(nota)
            );
    }

    //Funcion encargada de Obtener las ciudades y sus respectivos codigos postales
    public static void ListCities(Dictionary<String, int> Cities, Func<String>ObtenerCiudad, Func<int>ObtenerCodigoPostal)
    {
        RecolectarDatos
            (
                i => Console.WriteLine(Constantes.INGRE_CIUDAD),
                () => ObtenerCiudad(),
                (City) =>
                {
                    Console.WriteLine($"{Constantes.INGRE_COD_POSTAL} {City}");
                    int CityPostal = ObtenerCodigoPostal();
                    Cities.Add(City, CityPostal);
                }
            );
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
        //Para guardar las ciudades junto a sus codigos postales usamos una estructura de Diccionarios 
        Dictionary<String, int> Cities;
        //Para guardar las notas ingresadas por el usuario usamos una lista de enteros
        List<int> notas;

        //Creamos la lista y guardamos su referencia en notas
        notas = new List<int>();
        //Creamos el diccionario y guardamos su referencia en Cities
        Cities = new Dictionary<string, int>();
        ListCities(Cities, ()=>StringSegura(), ()=>NumeroSeguro());
        Calificaciones(notas, ()=>NumeroSeguro());
        CalculoPromedio(notas);
    }
}
