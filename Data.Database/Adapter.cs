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
        const string consKeyDefaultCnnString = "ConnStringIntegratedSecurity";

        /// <summary>
        /// Conexión con la base de datos de academia.
        /// </summary>
        protected SqlConnection SqlConn { get; set; }

        protected void OpenConnection()
        {
            string strConn = ConfigurationManager.ConnectionStrings[consKeyDefaultCnnString].ConnectionString;
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
        protected abstract void CargarParametrosSql(SqlCommand cmd, BE be);

        protected abstract void Insert(BE be);
        protected abstract void Update(BE be);
        protected abstract void Delete(int ID);

        /// <summary>
        /// Persiste la entidad de negocio en la base de datos.
        /// </summary>
        /// <param name="be">La entidad de negocio a guardarse.</param>
        public void Save(BE be)
        {
            switch (be.State)
            {
                case BusinessEntity.States.New:
                    Insert(be);
                    break;
                case BusinessEntity.States.Modified:
                    Update(be);
                    break;
                case BusinessEntity.States.Deleted:
                    Delete(be.ID);
                    break;
            }
            be.State = BusinessEntity.States.Unmodified;
        }
    }
}
