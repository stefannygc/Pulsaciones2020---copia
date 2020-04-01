using Entity;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL
{
    public class PersonaRepository
    {
        private string ruta = "Persona.txt";
         List<Persona> personas = new List<Persona>();
        public void Guardar(Persona persona)
        {
            FileStream fileStream = new FileStream(ruta, FileMode.Append);
            StreamWriter writer = new StreamWriter(fileStream);
            writer.WriteLine(persona.ToString());
            writer.Close();
            fileStream.Close();
            
        }
        public void Eliminar(Persona persona) 
        {
            personas.Clear();
            personas = Consultar();
            personas.Remove(persona);
            FileStream fileStream = new FileStream(ruta, FileMode.Create);
            fileStream.Close();

            foreach (var item in personas)
            {
                if (item.Identificacion != persona.Identificacion)
                {
                    Guardar(item);
                }
            }

        }

        public void Modificar(Persona persona)
        {
            personas.Clear();
            personas = Consultar();
            FileStream fileStream = new FileStream(ruta, FileMode.Create);
            fileStream.Close();

            foreach (var item in personas)
            {
                if (item.Identificacion != persona. Identificacion)
                {
                    Guardar(item);
                }
                else
                {
                    Guardar (persona);
                }
            }

        }
        public Persona Buscar(string identificacion) 
        {
            personas.Clear();
            personas = Consultar();

            foreach (var item in personas)
            { 
                if (item.Identificacion.Equals(identificacion))
                {
                    return item;
                }
            } 
            return null;
        }
        public Persona Buscar(Persona persona)
        {
            foreach (var item in personas)
            {
                if (item.Identificacion.Equals(persona.Identificacion))
                {
                    return item;
                }
            }
            return null;
        }



        public List<Persona> Consultar()
        {
            personas = new List<Persona>();
            string Linea = string.Empty;
           personas.Clear();
            FileStream fileStream = new FileStream(ruta, FileMode.OpenOrCreate);
            StreamReader Reader = new StreamReader(fileStream);

            while ((Linea = Reader.ReadLine()) != null)
            {
                Persona persona = MapearPersona(Linea);
                personas.Add(persona);
            }
            Reader.Close();
            fileStream.Close();
            return personas;
        }

        private static Persona MapearPersona(string Linea)
        {
            Persona persona = new Persona();
            char delimiter = ';';
            string[] DatosPersona = Linea.Split(delimiter);
            persona = new Persona();
            persona.Identificacion = DatosPersona[0];
            persona.Nombre = DatosPersona[1];
            persona.Edad = int.Parse(DatosPersona[2]);
            persona.Sexo = DatosPersona[3];
            persona.Pulsacion = Convert.ToDecimal(DatosPersona[2]);
            return persona;
        }

    }

}

