using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data.SqlClient;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.Services;



namespace WebServiceDataAccessSunat
{
    /// <summary>
    /// Descripción breve de WebService1
    /// </summary>
    [WebService(Namespace = "http://tempuri.org/")]
    [WebServiceBinding(ConformsTo = WsiProfiles.BasicProfile1_1)]
    [System.ComponentModel.ToolboxItem(false)]
    // Para permitir que se llame a este servicio web desde un script, usando ASP.NET AJAX, quite la marca de comentario de la línea siguiente. 
    // [System.Web.Script.Services.ScriptService]
    public class WebService1 : System.Web.Services.WebService
    {

        //Accesder a la cadena de conexion o enrutamiento
        //por medio de una variable privada extraemos el enrutamiento a la base de datos de SQL server
        private static string cadena = ConfigurationManager.ConnectionStrings["Cadena"].ConnectionString;
        //empaquetar el string "cadena" para llevar a la base de datos
        //uso del enrutamiento
        private static SqlConnection conexion = new SqlConnection(cadena);

        //Entorno desconectado
        //No tenemos q aperturar conexion y desconeccion es automatico
        [WebMethod(Description = "Listar la tabla Sunat")]
        public DataSet Listar()
        {
            //la consulta sql que se va hacer a la DB
            string consulta = "select * from TSunat";
            //entorno desconectado para acceder a la tabla TEscuela
            SqlDataAdapter adapter = new SqlDataAdapter(consulta, conexion);

            //metodo para setear los datos a algun lado
            DataSet data = new DataSet();
            //adaptar los datos a un adapter
            adapter.Fill(data);
            return data;
        }


        //Entorno conectado
        //Servicios criticos como eliminar o agregar datos
        //tenemos q aperturar conexion y desconeccion
        [WebMethod(Description = "Agregar un registro a la tabla Alumno")]
        public bool Agregar(string Ruc, string Nombre, string TipoDocumento, string Estado, string Condicion, string Direccion, string Ubigeo, string ViaTipo, string ViaNombre, string ZonaCodi, string ZonaTipo, string numero, string Interior, string Lote, string Dpto, string Manzana, string Kilometro, string Distrito, string Provincia, string Departamento)
        {

            try
            {
                //la consulta sql que se va hacer a la DB
                string consulta = "insert into TSunat values ('" + Ruc + "','" + Nombre + "','" + TipoDocumento + "','" + Estado + "','" + Condicion + "','" + Direccion + "','" + Ubigeo + "','" + ViaTipo + "','" + ViaNombre + "','" + ZonaCodi + "','" + ZonaTipo + "','" + numero + "','" + Interior + "','" + Lote + "','" + Dpto + "','" + Manzana + "','" + Kilometro + "','" + Distrito + "','" + Distrito + "','" + Provincia + "','" + Departamento + "')";
                //Entorno de conexion 
                //procesos criticos donde yo genero al tipo de conexion
                SqlCommand comando = new SqlCommand(consulta, conexion);
                //abirmos la conexion a la DB
                conexion.Open();
                //ejecutar la consulta para addItem to data base
                //nos devuelve cuantos registros se hicieron o se ejecutaron
                byte i = Convert.ToByte(comando.ExecuteNonQuery());
                //cerramos conexion
                conexion.Close();
                //condicional si se agrego datos o no
                if (i == 1) return true;
                else return false;
            }
            catch (Exception)
            {
                conexion.Close();
                return false;
            }
        }

        //Buscar
        [WebMethod(Description = "Buscar en la tabla Sunat")]
        public DataSet Buscar(string texto, string criterio)
        {
            string consulta = string.Empty;
            SqlCommand comando;
            SqlDataAdapter adapter;
            DataSet data = new DataSet();
            if (criterio == "Ruc")
            {
                // Busqueda exacta
                consulta = "select * from TSunat where Ruc = @texto";
                comando = new SqlCommand(consulta, conexion);
                comando.Parameters.AddWithValue("@texto", texto);
                adapter = new SqlDataAdapter(comando);
                adapter.Fill(data);
            }
            else if (criterio == "Nombre")
            {
                // Busqueda sensitiva
                consulta = "select * from TSunat where Nombre like @texto + '%'";
                comando = new SqlCommand(consulta, conexion);
                comando.Parameters.AddWithValue("@texto", texto);
                adapter = new SqlDataAdapter(comando);
                adapter.Fill(data);
            }
            return data;
        }





    }
}
