using System.Configuration;
using System.Data.SqlClient;


namespace EjemploNorthWindEmpleados.AccesoDatos
{
    /**
     * Clase que se encarga de hacer una conexion a BD
     * esta clase solo permite conexiones a SQLServer
     * */

    public class ConexionBD
    {
        private SqlConnection con;
        private SqlCommand cmd;
        
        public ConexionBD()
        {
            string cadena = ConfigurationManager.ConnectionStrings["MiCadena"].ConnectionString;
            con = new SqlConnection(cadena);
            cmd = new SqlCommand();
            cmd.Connection = con;
        }

        public int executeNonQuery(string consulta)
        {
            cmd.CommandText = consulta;
            open();
            int retorno= cmd.ExecuteNonQuery();
            close();
            return retorno;
        }

        public SqlDataReader executeQuery(string consulta)
        {
            cmd.CommandType = System.Data.CommandType.Text;
            cmd.CommandText = consulta;
            open();
            return cmd.ExecuteReader();
        }

        public SqlDataReader executeQuery(string comando,SqlParameterCollection p)
        {
            cmd.CommandType = System.Data.CommandType.StoredProcedure;
            cmd.CommandText = comando;
            foreach (SqlParameter item in p)
                cmd.Parameters.Add(item);
            open();
            return cmd.ExecuteReader();
        }

        public int executeNonQuery(string comando,SqlParameterCollection p)
        {
            cmd.CommandType = System.Data.CommandType.StoredProcedure;
            cmd.CommandText = comando;
            foreach (SqlParameter item in p)
                cmd.Parameters.Add(item);
            open();
            int retorno = cmd.ExecuteNonQuery();
            close();
            return retorno;
        }


        public void open()
        {
            if(con !=null && con.State == System.Data.ConnectionState.Closed)
            {
                con.Open();
            }
        }

        public void close()
        {
            if(con !=null  && con.State == System.Data.ConnectionState.Open)
            {
                con.Close();
            }
        }


    }
}
