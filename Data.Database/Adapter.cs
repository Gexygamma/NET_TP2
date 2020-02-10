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
        protected static string StrConn => ConfigurationManager.ConnectionStrings[KeyDefaultCnnString].ConnectionString;

        protected void OpenConnection()
        {
            SqlConn = new SqlConnection(StrConn);
            SqlConn.Open();
        }

        protected void CloseConnection()
        {
            SqlConn.Close();
            SqlConn = null;
        }

        public static void TruncarBaseDatos()
        {
            using (SqlConnection sqlConn = new SqlConnection(StrConn))
            {
                sqlConn.Open();
                SqlCommand cmdTruncate = new SqlCommand();
                SqlTransaction transaction = sqlConn.BeginTransaction();
                cmdTruncate.Connection = sqlConn;
                cmdTruncate.Transaction = transaction;

                string[] tableNames = { "usuarios", "personas", "alumnos_inscripciones", "docentes_cursos",
                    "cursos", "comisiones", "materias", "planes", "especialidades" };

                try
                {
                    foreach (string table in tableNames)
                    {
                        cmdTruncate.CommandText = string.Format("DELETE FROM {0}; DBCC CHECKIDENT({0}, RESEED, 0)", table);
                        cmdTruncate.ExecuteNonQuery();
                    }

                    cmdTruncate.CommandText = "INSERT INTO especialidades(desc_especialidad) VALUES ('default')" +
                        "INSERT INTO planes(desc_plan, id_especialidad) VALUES ('default', 1);";
                    cmdTruncate.ExecuteNonQuery();

                    transaction.Commit();
                }
                catch (Exception)
                {
                    transaction.Rollback();
                    throw;
                }
            }
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
