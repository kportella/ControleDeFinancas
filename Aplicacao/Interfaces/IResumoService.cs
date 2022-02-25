using Dominio;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Aplicacao.Interfaces
{
    public interface IResumoService
    {
        Task<ResumoDominio> BuscarResumoMes(int ano, int mes);
    }
}
