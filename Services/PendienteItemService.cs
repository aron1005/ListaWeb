using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ListaWeb.Models;
using Microsoft.EntityFrameworkCore;

namespace ListaWeb.Services
{
    public class PendienteItemService : IPendienteItemService
    {
        private readonly ListaDbContext _context;



        /// Aquí usamamos DI para obtener el DbContext
        public PendienteItemService(ListaDbContext context)
        {
            _context = context;
        }


        /// Aquí tienen que crear el nuevo Pendiente y guardarlo
        
        public bool AgregarPendiente(PendienteItem pendiente)
        {
         //se añade el pediente en la variable pendiente
            _context.Pendientes.Add(pendiente);



            /// no quitar estas dos lineas
            var saveResult =  _context.SaveChanges();
            /// Regresa cierto si solo se guardó un registro (pendiente)
            return saveResult == 1;
        }

        /// Regresar la lista de todos los pendientes incompletos, o sea que  EstaHecho == False
        public IEnumerable<PendienteItem> GetPendientesIncompletos()
        {
        // si cumple la condiccion si esta terminada o no
            return _context.Pendientes.Where( p => p.EstaHecha == false);
                             


        }



        public bool MarcarHecho(Guid id)
        {
           /// 1
           /// Buscar el id de la tarea 
           /// utilizar el método de LINQ FirstOrDefault 
           /// Regresa el pendiente si lo encontró null si no 
           // este es si hace la condiccion
           var pendiente = _context.Pendientes.FirstOrDefault(p => p.Id == id);

            /// 2
            /// Verificar que el pendiente no sea null en ese caso regresar false
            if (pendiente == null){
                return false;
            }

            /// 3
            /// Marcar como hecho el pendiente
            // si la esta echo el pedinete
            pendiente.EstaHecha = true;


            /// 4
            /// Guardar el pendiente Modificado



            var saveResult =  _context.SaveChanges();
            return saveResult == 1; // Solo un registro se debió haber actualizado
        }
    }
}
