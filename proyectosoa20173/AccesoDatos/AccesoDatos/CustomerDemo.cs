using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using EjemploNorthWindEmpleados.Entidades;//agregamos una directiva a entidades 
using System.Threading.Tasks;
using System.Data.SqlClient;

namespace EjemploNorthWindEmpleados.AccesoDatos
{ 
    public class CustomerDemo
    {
        // con el metodo getAll estamos esperado multiples valores y necesito todos ellos.
        public static List<CustomerDemos> getAll() 
        {
            //estamos  diciendole que con nos direige a nuestra clase ConexionBD
            ConexionBD con = new ConexionBD();
            // nos seleccione toda la tabla de nuesta base de datos 
            List<CustomerDemos> listaobjetos = new List<CustomerDemos>(); 
            SqlDataReader dr = con.executeQuery("SELECT * FROM CustomerCustomerDemo");
            //en nuna variable emp meteremos nuestros campos y los meteremos en una lista
            while (dr.Read())
            {
                CustomerDemos emp = new CustomerDemos();
                emp.CustomerID = dr.GetString(0);
                emp.CustomerTypeID = dr.GetString(1);
                /*emp.Title = dr.GetString(3);
                emp.FirstName = dr.GetString(2);*/
                listaobjetos.Add(emp);
            }
            con.close();

            return listaobjetos;
        }

        public static CustomerDemos getById(int id)
        {
            return null;
        }

        public static int edit(CustomerDemos e)
        {
            return 1;
        }

        public static int create(CustomerDemos e)
        {
            return 1;
        }

        public static int remove(int id)
        {
            ConexionBD con = new ConexionBD();
            int res = con.executeNonQuery("DELETE FROM employees WHERE id=" + id);
            con.close();
            return res;

        }

        //ivan customercustomerdemo
        //customers liove
        //ismael products
        //David Categories
        //jesus employeesterritories
        //region ivan
        //territories amiguito
        //orders noe 
        //ordersdetails alfredo
        //carlos shippers
        //karla suppliers
        //erika customerdemographis






    }
}
