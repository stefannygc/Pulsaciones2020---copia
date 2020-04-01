using BLL;
using Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Pulsaciones2020
{
    class Program
    { 
        static Persona persona;
        static List<Persona> personas = new List<Persona>();
        static PersonaService personaService = new PersonaService();
        static void Main(string[] args)
        {
            Menu();

        }
        public static void Menu()
        {
            int opcion;
            do
            {
                Console.Clear();
                Console.WriteLine("\n******* Menu de pulsaciones *******");
                Console.WriteLine(" 1. Registrar");
                Console.WriteLine(" 2. BuscarPersona");
                Console.WriteLine(" 3. Modificar");
                Console.WriteLine(" 4. Consultar");
                Console.WriteLine(" 5. Eliminar");
                Console.WriteLine(" 6. Salir");

                Console.WriteLine("**************************************");

                Console.Write("\n DIGITE UNA OPCION: "); opcion = Int32.Parse(Console.ReadLine());
                switch (opcion)
                {
                    case 1: Registrar(); break;
                    case 2: BuscarPersona(); break;
                    case 3: Modificar();break;
                    case 4: Consultar(); break;
                    case 5: Eliminar();break;
                    case 6: Console.Write("\n Presione enter para salir..."); Console.ReadKey(); break;
                    default: Console.WriteLine("\n Numero fuera de rango intente de nuevo..."); break;
                }
            } while (opcion != 3);
        }

        public static void Registrar()
        {
            string mensaje;
            persona = new Persona();
            PersonaService personaService = new PersonaService();
            Console.WriteLine("\n Digite su informacion....");

            Console.Write(" Identificacion: "); persona.Identificacion = Console.ReadLine();
            Console.Write(" Nombre: "); persona.Nombre = Console.ReadLine();
            Console.Write(" Edad: "); persona.Edad = Int32.Parse(Console.ReadLine());
            Console.Write(" Sexo[M/F]: "); persona.Sexo = Console.ReadLine();
            persona.CalcularPulsacion();
            mensaje= personaService.Guardar(persona);
            Console.WriteLine(persona.ToString());
            Console.WriteLine(mensaje);
            Console.Write("\n Pulse enter para continuar..."); Console.ReadKey();
            personas.Add(persona);
        }
        public static void BuscarPersona()
        {
            string identificacion;
            Console.WriteLine($"\n Digite identificacion : "); identificacion = Console.ReadLine();
            persona = personaService.Buscar(identificacion);
            if (persona == null)
            {
                Console.WriteLine($"\n el numero de identificacion[{identificacion}] no existe");
            }
            else
            {
           
                    Console.WriteLine("\ninformacion de personas");
                    Console.WriteLine("\n ******************");
                    Console.WriteLine($" Identificacion: {persona.Identificacion}");
                    Console.WriteLine($" Nombre: {persona.Nombre}");
                    Console.WriteLine($" Edad: {persona.Edad}");
                    Console.WriteLine($" Sexo: {persona.Sexo}");
                    Console.WriteLine($" Pulsaciones: {persona.Pulsacion}");
                    Console.WriteLine(" ***************************");
                  
            }
            Console.Write("\n Pulse enter para continuar......"); Console.ReadKey();


        }

        public static void Modificar() 
        {
            Persona persona = new Persona();
            Console.WriteLine("Digite la identificacion a modificar :");
            persona.Identificacion = Console.ReadLine();
            if (personaService.Buscar(persona.Identificacion) != null)
            {
                Console.WriteLine("Digite el Nombre a modificar :");
                persona.Nombre = Console.ReadLine();
                Console.WriteLine("Digite la Edad a modificar: ");
                persona.Edad = Convert.ToInt32(Console.ReadLine());
                Console.WriteLine("Digite el sexo a modificar :");
                persona.Sexo = Console.ReadLine();
                persona.CalcularPulsacion();
                string mensaje = personaService.Modificar(persona);
                Console.WriteLine(mensaje);
                Menu();

            }

            Console.ReadKey();

        }
        public static void Eliminar()
        {
            ConsoleKeyInfo continuar;
            Console.WriteLine("Digite la identificacion que desea eliminar :");
            string identificacion = Console.ReadLine();
            string mensajeEliminar = personaService.Eliminar(identificacion);
            Console.WriteLine(mensajeEliminar);
            continuar = Console.ReadKey();
        }

        public static void Consultar() 
        {
            List<Persona> personas = personaService.Consultar();
            if (personas.Count == 0)
            {
                Console.WriteLine("\n No hay personas registradas");
            }
            else 
            {
                foreach (var itemPersona in personas)
                {
                    Console.WriteLine();
                    Console.WriteLine("\n Cosulta de Persona");
                    Console.WriteLine("\n ******************");
                    Console.WriteLine($" Identificacion: {itemPersona.Identificacion}");
                    Console.WriteLine($" Nombre: {itemPersona.Nombre}");
                    Console.WriteLine($" Edad: {itemPersona.Edad}");
                    Console.WriteLine($" Sexo: {itemPersona.Sexo}");
                    Console.WriteLine($" Pulsaciones: {itemPersona.Pulsacion}");
                    Console.WriteLine(" ***************************");
                }
            }
            Console.WriteLine("\n Pulse enter para continuar...."); Console.ReadKey();
        }
    }
}


