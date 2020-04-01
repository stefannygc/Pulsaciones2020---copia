using DAL;
using Entity;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BLL
{
    public class PersonaService
    {

        private PersonaRepository personaRepository;
        public PersonaService()
        {
            personaRepository = new PersonaRepository();
        }

        public string Guardar(Persona persona)
        {
            try
            {
                if ((personaRepository.Buscar(persona.Identificacion)) == null)
                {
                    personaRepository.Guardar(persona);
                    return $"se guardaron los datos sactifactoriamente ";
                }
                return $"No es posible registrar a la persona. la persona con Identificacion {persona.Identificacion} ya se encuentra registrada ";

            }
            catch (Exception ex)
            {

                return $"Error de datos " + ex.Message;
            }

        }



        public string Eliminar(string identificacion)
        {
            Persona persona = personaRepository.Buscar(identificacion);
            if (persona != null)
            {

                personaRepository.Eliminar(persona);
                return $"Los datos de  {persona.Nombre} ha sido eliminada satisfacatoriamente";
            }
            else { 
            return $"error la persona que desea eliminar no se encuentra registrada por favor verifique los datos";
            }
        }

        
    

        public string Modificar(Persona persona)
        { 
                try
                {
                    if (personaRepository.Buscar(persona.Identificacion) != null)
                    {

                        personaRepository.Modificar(persona);
                        return $"Los Persona con identificacion {persona.Identificacion} ha sido modificada satisfacatoriamente";
                    }
                    return $"La identificacion {persona.Identificacion} no se encuentra registrada por favor verifique los datos";

                }
                catch (Exception ex)
                {

                    return "Error de datos" + ex.Message;
                }
            
        }
        public List<Persona> Consultar()
        {
            return personaRepository.Consultar();
        }

        public Persona Buscar(string identificacion)
        {
            return personaRepository.Buscar(identificacion);
            
        }


    }
}

