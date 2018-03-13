using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using ListaWeb.Models;

namespace ListaWeb.Services
{
    public interface IPendienteItemService
    {
        IEnumerable<PendienteItem> GetPendientesIncompletos();

        bool AgregarPendiente(PendienteItem pendienteItem);
        
        bool MarcarHecho(Guid id);
    }
}
