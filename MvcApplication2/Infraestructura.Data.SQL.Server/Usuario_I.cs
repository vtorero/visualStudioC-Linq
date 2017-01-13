using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Dominio.Core.Entities;
using System.Data;
using System.Data.SqlClient;

namespace Infraestructura.Data.SQL.Server
{
    public class Usuario_I
    {
        SqlConnection conexion;
        SqlDataAdapter comando;
        SqlDataReader dr;
        SqlCommand cmd;
        String errores;

        Conexion cn = new Conexion();

        public IEnumerable<Usuario> LoginUsuario(string user,string password) {
            List<Usuario> lista = new List<Usuario>();
            try
            {
                conexion = cn.Conectar();
                cmd = new SqlCommand("PR_LOGIN", conexion);
                cmd.CommandType = CommandType.StoredProcedure;
                
                cmd.Parameters.Add(new SqlParameter("P_usuario", SqlDbType.VarChar, 10));
                cmd.Parameters["P_usuario"].Direction = ParameterDirection.Input;
                cmd.Parameters["P_usuario"].Value = user;

                cmd.Parameters.Add(new SqlParameter("P_clave", SqlDbType.VarChar, 10));
                cmd.Parameters["P_clave"].Direction = ParameterDirection.Input;
                cmd.Parameters["P_clave"].Value = password;

                dr = null;
                conexion.Open();
                dr = cmd.ExecuteReader();

                while (dr.Read()) {
                    Usuario objecto = new Usuario();
                    objecto.usuario_u = Convert.ToString(dr["usuario_u"]);
                    objecto.clave_u = Convert.ToString(dr["clave_u"]);
                    objecto.nombreUsuario_u= Convert.ToString(dr["nombreUsuario_u"]);
                    lista.Add(objecto);
                }
                dr.Close();

            }
            catch (Exception ex) {
                errores = ex.Message;
            }
            finally {
                if (conexion.State == ConnectionState.Open) {
                    conexion.Close();
                }
                conexion.Dispose();
                cmd.Dispose();
            }
            return lista;
        }
    }
}
