using System;
using System.Collections.Generic;
using System.Text;

namespace Domain.Repositories.Interfaces
{
    public interface IRepositorio<T>
    {
        List<T> Lista();
        T RetornaPorId(int id);
        void Insere(T entidade);
        void Exclui(T entidade);
        void Atualiza(T entidade);

    }
}
