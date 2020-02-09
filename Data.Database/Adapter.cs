using System;
using System.Collections.Generic;
using System.Text;
using System.Data.SqlClient;
using System.Configuration;
using Business.Entities;

namespace Data.Database
{
    public abstract class Adapter<BE> where BE : BusinessEntity
    {
        /// <summary>
        /// Clave por defecto a utilizar para la cadena de conexión.
        /// </summary>
        const string KeyDefaultCnnString = "ConnStringIntegratedSecurity";

        /// <summary>
        /// Conexión con la base de datos de academia.
        /// </summary>
        protected SqlConnection SqlConn { get; set; }

        protected void OpenConnection()
        {
            string strConn = ConfigurationManager.ConnectionStrings[KeyDefaultCnnString].ConnectionString;
            SqlConn = new SqlConnection(strConn);
            SqlConn.Open();
        }

        protected void CloseConnection()
        {
            SqlConn.Close();
            SqlConn = null;
        }

        /// <summary>
        /// Crea una entidad de negocio cargado con los atributos provistos por un DataReader.
        /// </summary>
        /// <param name="dr">El DataReader que contiene los atributos.</param>
        protected abstract BE CrearDesdeReader(SqlDataReader dr);
        /// <summary>
        /// Carga el comando SQL con parámetros pertenecientes a la entidad de negocio.
        /// </summary>
        /// <param name="cmd">El comando SQL a ser cargado.</param>
        /// <param name="be">La entidad de negocio que contiene los parámetros</param>
        internal abstract void CargarParametrosSql(SqlCommand cmd, BE be);
    }
}
