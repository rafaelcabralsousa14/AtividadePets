using AtividadPets.Domains;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace AtividadPets.Interfaces
{
    interface iClinica
    {
        List<Clinica> ListarTodos();
        Clinica BuscarPorID(int id);
        Clinica Cadastrar(Clinica a);
        Clinica Alterar(int id, Clinica a);
        void Excluir(int id);
    }
}
