﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;
using System.Data.SqlClient;
using Entity;

namespace Data
{
    public class DCategoria
    {
        public List<Categoria> Listar(Categoria categoria)
        {
            SqlParameter[] parameters = null;
            string commandText = string.Empty;
            List<Categoria> categorias = null;

            try
            {
                commandText = "USP_GetCategoria";
                parameters = new SqlParameter[1];
                parameters[0] = new SqlParameter("@idcategoria", SqlDbType.Int);
                parameters[0].Value = categoria.IdCategoria;
                categorias = new List<Categoria>();

                using (SqlDataReader reader = SqlHelper.ExecuteReader(SqlHelper.Connection, commandText, CommandType.StoredProcedure, parameters))
                {
                    while (reader.Read())
                    {
                        categorias.Add(new Categoria
                        {
                            IdCategoria = reader["idcategoria"] != null ? Convert.ToInt32(reader["idcategoria"]) : 0,
                            NombreCategoria = reader["nombrecategoria"] != null ? Convert.ToString(reader["nombrecategoria"]): "",
                            Descripcion = reader["descripcion"] != null ? Convert.ToString(reader["descripcion"]): ""
                        });
                    }
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
            return categorias;
        }

        public void Insertar(Categoria categoria)
        {
            SqlParameter[] parameters = null;
            string commandText = string.Empty;
            try
            {
                commandText = "USP_InstCategoria";
                parameters = new SqlParameter[3];
                parameters[0] = new SqlParameter("@idcategoria", SqlDbType.Int);
                parameters[0].Value = categoria.IdCategoria;
                parameters[1] = new SqlParameter("@nombrecategoria", SqlDbType.VarChar);
                parameters[1].Value = categoria.NombreCategoria;
                parameters[2] = new SqlParameter("@descripcion", SqlDbType.Text);
                parameters[2].Value = categoria.Descripcion;
                SqlHelper.ExecuteNonQuery(SqlHelper.Connection, commandText, CommandType.StoredProcedure, parameters);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public void Actualizar(Categoria categoria)
        {
            SqlParameter[] parameters = null;
            string comandText = string.Empty;
            try
            {
                comandText = "USP_UpdCategoria";
                parameters = new SqlParameter[3];
                parameters[0] = new SqlParameter("@idcategoria", SqlDbType.Int);
                parameters[0].Value = categoria.IdCategoria;
                parameters[1] = new SqlParameter("@nombrecategoria", SqlDbType.VarChar);
                parameters[1].Value = categoria.NombreCategoria;
                parameters[2] = new SqlParameter("@descripcion", SqlDbType.Text);
                parameters[2].Value = categoria.IdCategoria;
                SqlHelper.ExecuteNonQuery(SqlHelper.Connection, comandText, CommandType.StoredProcedure, parameters);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public void Eliminar(int IdCategoria)
        {
            SqlParameter[] parameters = null;
            string comandText = string.Empty;
            try
            {
                comandText = "USP_DelCategoria";
                parameters = new SqlParameter[1];
                parameters[0] = new SqlParameter("@idcategoria", SqlDbType.Int);
                parameters[0].Value = IdCategoria;
                SqlHelper.ExecuteNonQuery(SqlHelper.Connection, comandText, CommandType.StoredProcedure, parameters);
            }
            catch (Exception ex) 
            {
                throw ex;
            }
        }
    }
}
