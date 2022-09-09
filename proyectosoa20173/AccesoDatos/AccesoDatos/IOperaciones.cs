using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EjemploNorthWindEmpleados.AccesoDatos
{
    public interface IOperaciones<T>
    {
        List<T> getAll();
        T getById();
        int create(T t);
        int edit(T t);
        int remove(int id);
    }
}
