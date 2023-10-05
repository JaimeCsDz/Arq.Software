// See https://aka.ms/new-console-template for more information

using System;
using System.Collections.Generic;


// Clase abstracta Persona
public abstract class Persona
{
    public string Nombre { get; set; }
    public string Apellido { get; set; }
    public string CorreoElectronico { get; set; }
    public string Telefono { get; set; }
}

// Clase Ciudadano, subclase de Persona
public class Ciudadano : Persona
{
    public List<ReporteProblema> Reportes { get; set; }

    public Ciudadano(string nombre, string apellido, string correo, string telefono)
    {
        Nombre = nombre;
        Apellido = apellido;
        CorreoElectronico = correo;
        Telefono = telefono;
        Reportes = new List<ReporteProblema>();
    }

    public void ReportarProblema(string descripcion, Ubicacion ubicacion, CategoriaProblema categoria)
    {
        // Crear un nuevo reporte y agregarlo a la lista de reportes del ciudadano
        var nuevoReporte = new ReporteProblema(descripcion, ubicacion, categoria);
        Reportes.Add(nuevoReporte);

        Console.WriteLine("Reporte realizado con éxito.");

    }
}

// Clase ReporteProblema
public class ReporteProblema
{
    public string Descripcion { get; set; }
    public List<string> FotosOVideos { get; set; }
    public EstadoReporte Estado { get; set; }
    public CategoriaProblema Categoria { get; set; }
    public Ubicacion Ubicacion { get; set; }

    public ReporteProblema(string descripcion, Ubicacion ubicacion, CategoriaProblema categoria)
    {
        Descripcion = descripcion;
        FotosOVideos = new List<string>();
        Estado = EstadoReporte.EnRevision;
        Categoria = categoria;
        Ubicacion = ubicacion;

        Console.WriteLine("Nuevo reporte creado y registrado.");
    }
}

// Clase CategoriaProblema
public class CategoriaProblema
{
    public string Nombre { get; set; }

    public CategoriaProblema(string nombre)
    {
        Nombre = nombre;
    }
}

// Clase Ubicacion
public class Ubicacion
{
    public double Latitud { get; set; }
    public double Longitud { get; set; }
    public string Direccion { get; set; }
    public string Ciudad { get; set; }
    public string Pais { get; set; }

    public Ubicacion(double latitud, double longitud, string direccion, string ciudad, string pais)
    {
        Latitud = latitud;
        Longitud = longitud;
        Direccion = direccion;
        Ciudad = ciudad;
        Pais = pais;
    }
}

// Enumeración para el estado del reporte
public enum EstadoReporte
{
    EnRevision,
    Resuelto,
    Cerrado
}

class Program
{
    static void Main()
    {
        // Crear una instancia de Ciudadano (simulando el usuario registrado)
        var ciudadano = new Ciudadano("IDYGS73", "IDYGS73", "correo@example.com", "123456789");

        bool continuar = true;

        while (continuar)
        {
            Console.WriteLine("¡Bienvenido, " + ciudadano.Nombre + "!");
            Console.WriteLine("¿Qué acción quieres realizar hoy?");
            Console.WriteLine("1 - Reportar un problema");
            Console.WriteLine("2 - Consultar estatus de un reporte");
            Console.WriteLine("3 - Buscar problemas por categoría");
            Console.WriteLine("4 - Cerrar sesión");
            int opc;
            if (!int.TryParse(Console.ReadLine(), out opc))
            {
                Console.WriteLine("Opción no válida. Debes ingresar un número del 1 al 4.");
                continue;
            }
            switch (opc)
            {
                case 1:
                    Console.WriteLine("Describe de manera breve el problema: ");
                    string desc = Console.ReadLine();
                    Console.WriteLine("Ingresa la categoría del reporte (Contaminación, Deforestación, Gestión de residuos): ");
                    string cat ="" ;
                    Console.WriteLine("Ingresa de manera breve la dirección: ");
                    string ubi = Console.ReadLine();
                    double latitud = 0.0; // Asigna un valor a la latitud
                    double longitud = 0.0; // Asigna un valor a la longitud
                    string ciudad = "Ciudad Ejemplo";
                    string pais = "País Ejemplo";

                    // Llamar al método para reportar el problema del ciudadano
                    ciudadano.ReportarProblema(desc, new Ubicacion(latitud, longitud, ubi, ciudad, pais), new CategoriaProblema(cat)); 
                    break;

                case 2:
                    Console.WriteLine("Estatus de reportes");
                    foreach (var reporte in ciudadano.Reportes)
                    {
                        Console.WriteLine("Descripción del reporte: " + reporte.Descripcion);
                        Console.WriteLine("Categoría del reporte: " + reporte.Categoria.Nombre);
                        Console.WriteLine("Ubicación del reporte: " + reporte.Ubicacion.Direccion);
                        Console.WriteLine("Estatus del reporte: " + reporte.Estado);
                        Console.WriteLine("---------------------------------------");
                    }
                    break;
                case 3:
                    Console.WriteLine("Buscar reportes por categoría");
                    Console.WriteLine("Escoge una de las categorías");
                    Console.WriteLine("1 - Contaminación");
                    Console.WriteLine("2 - Deforestación");
                    Console.WriteLine("3 - Gestión de residuos");
                    int op2;
                    if (!int.TryParse(Console.ReadLine(), out op2))
                    {
                        Console.WriteLine("Opción no válida. Debes ingresar un número del 1 al 3.");
                        break;
                    }
                    switch (op2)
                    {
                        case 1:
                            Console.WriteLine("Reportes de Contaminación:");
                            foreach (var reporte in ciudadano.Reportes)
                            {
                                if (reporte.Categoria.Nombre == "Contaminacion")
                                {
                                    Console.WriteLine("Descripción del reporte: " + reporte.Descripcion);
                                    Console.WriteLine("Ubicación del reporte: " + reporte.Ubicacion.Direccion);
                                    Console.WriteLine("Estatus del reporte: " + reporte.Estado);
                                }
                            }
                            Console.WriteLine("1 - Contaminacón en playa langostas");
                            Console.WriteLine("2 - Aguas negras sobre avenida Uxmal");
                            Console.WriteLine("Fin de las busquedas");
                            break;
                        case 2:
                            Console.WriteLine("Deforestacion:");
                            foreach (var reporte in ciudadano.Reportes)
                            {
                                if (reporte.Categoria.Nombre == "Deforestacion")
                                {
                                    Console.WriteLine("Descripción del reporte: " + reporte.Descripcion);
                                    Console.WriteLine("Ubicación del reporte: " + reporte.Ubicacion.Direccion);
                                    Console.WriteLine("Estatus del reporte: " + reporte.Estado);
                                }
                            }
                            Console.WriteLine("Sin resultados");
                            break;
                        case 3:
                            Console.WriteLine("Gestion de residuos:");
                            foreach (var reporte in ciudadano.Reportes)
                            {
                                if (reporte.Categoria.Nombre == "Gestion de residuos")
                                {
                                    Console.WriteLine("Descripción del reporte: " + reporte.Descripcion);
                                    Console.WriteLine("Ubicación del reporte: " + reporte.Ubicacion.Direccion);
                                    Console.WriteLine("Estatus del reporte: " + reporte.Estado);
                                }
                            }
                            Console.WriteLine("1 - Acumulación de basura sobre Av. Nichupte");
                            Console.WriteLine("3 - Falta de servicio de gestión de residuos en la reg. 99");
                            Console.WriteLine("Fin de las busquedas");

                            break;
                        default:
                            Console.WriteLine("Opción no válida. Debes ingresar un número del 1 al 3.");
                            break;
                    }
                    break;
                case 4:
                    Console.WriteLine("Cerrando sesión. ¡Vuelva pronto!");
                    continuar = false;
                    break;
                default:
                    Console.WriteLine("Opción no válida. Debes ingresar un número del 1 al 4.");
                    break;
            }

            Console.WriteLine("¿Deseas realizar otra acción? (S/N): ");
            string respuesta = Console.ReadLine();
            if (respuesta.ToLower() != "s")
            {
                continuar = false; // Si el usuario no quiere realizar otra acción, salir del bucle.
            }
        }
    }
}