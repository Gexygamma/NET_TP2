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
        // Clave por defecto a utilizar para la cadena de conexión.
        const string consKeyDefaultCnnString = "ConnStringIntegratedSecurity";

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

        protected abstract BE CrearDesdeReader(SqlDataReader dr);
        protected abstract void CargarParametrosSql(SqlCommand cmd, BE be);

        protected abstract void Insert(BE be);
        protected abstract void Update(BE be);
        protected abstract void Delete(int ID);

        public void Save(BE be)
        {
            if (be.State == BusinessEntity.States.New)
            {
                Insert(be);
            }
            else if (be.State == BusinessEntity.States.Modified)
            {
                Update(be);
            }
            else if (be.State == BusinessEntity.States.Deleted)
            {
                Delete(be.ID);
            }
            be.State = BusinessEntity.States.Unmodified;
        }
    }
}
