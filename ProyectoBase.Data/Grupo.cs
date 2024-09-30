using System;
using System.Collections.Generic;
using ProyectoBase.Models;
using System.Data;

namespace ProyectoBase.Data
{
	public class Grupo

	{
        ManejoDatos b = new ManejoDatos();

        public List<Models.Grupo> Grupo_ListarPor_Id(Models.Grupo grupo)
        {
            b.ExecuteCommandSP("Grupo_ListarPor_Id");
            b.AddParameter("@Id", grupo.Id, SqlDbType.Int);

            List<Models.Grupo> resultado = new List<Models.Grupo>();
            var reader = b.ExecuteReader();
            while (reader.Read())
            {
                Models.Grupo item = new Models.Grupo()
                {
                    Id = Convert.ToInt32(reader["Id"].ToString()),
                    Nombre = reader["Nombre"].ToString(),
                    Fecha = reader["Fecha"].ToString(),
                    NombrePersona = reader["NombrePersona"].ToString()
                };
                resultado.Add(item);
            }
            reader = null;
            b.ConnectionCloseToTransaction();
            return resultado;
        }

        public List<Models.Grupo> GrupoPersona_listar(Models.Grupo grupo)
        {
            b.ExecuteCommandSP("GrupoPersona_listar");
            b.AddParameter("@IdGrupo", grupo.Id, SqlDbType.Int);

            List<Models.Grupo> resultado = new List<Models.Grupo>();
            var reader = b.ExecuteReader();
            while (reader.Read())
            {
                Models.Grupo item = new Models.Grupo()
                {
                    Id = Convert.ToInt32(reader["Id"].ToString()),
                    Nombre = reader["Nombre"].ToString(),
                    Fecha = reader["Fecha"].ToString()

                };
                resultado.Add(item);
            }
            reader = null;
            b.ConnectionCloseToTransaction();
            return resultado;
        }

        public List<Models.Grupo> GrupoPersona_listarFaltante(Models.Grupo grupo)
        {
            b.ExecuteCommandSP("GrupoPersona_listarFaltante");
            b.AddParameter("@IdGrupo", grupo.Id, SqlDbType.Int);

            List<Models.Grupo> resultado = new List<Models.Grupo>();
            var reader = b.ExecuteReader();
            while (reader.Read())
            {
                Models.Grupo item = new Models.Grupo()
                {
                    Id = Convert.ToInt32(reader["Id"].ToString()),
                    Nombre = reader["Nombre"].ToString(),
                    Empresa = reader["Empresa"].ToString()

                };
                resultado.Add(item);
            }
            reader = null;
            b.ConnectionCloseToTransaction();
            return resultado;
        }


        public Models.Grupo InsertarGrupoPersona(Models.Grupo grupo)

        {
            b.ExecuteCommandSP("InsertarGrupoPersona");
            b.AddParameter("@Idpersona", grupo.IdP, SqlDbType.Int);
            b.AddParameter("@Idgrupo ", grupo.Id, SqlDbType.Int);


            Models.Grupo resultado = new Models.Grupo();
            var reader = b.ExecuteReader();
            while (reader.Read())
            {
                resultado.Id = Convert.ToInt32(reader["Id"].ToString());

            }
            reader = null;
            b.ConnectionCloseToTransaction();
            return resultado;
        }


        public Models.Grupo EliminarGrupoPersona(Models.Grupo grupo)

        {
            b.ExecuteCommandSP("EliminarGrupoPersona");
            b.AddParameter("@Idpersona", grupo.IdP, SqlDbType.Int);
            b.AddParameter("@Idgrupo ", grupo.Id, SqlDbType.Int);


            Models.Grupo resultado = new Models.Grupo();
            var reader = b.ExecuteReader();
            while (reader.Read())
            {
                resultado.Id = Convert.ToInt32(reader["Id"].ToString());

            }
            reader = null;
            b.ConnectionCloseToTransaction();
            return resultado;
        }


        public Models.Grupo EmpresaGrupo_Agregar(Models.Grupo grupo)

        {
            b.ExecuteCommandSP("EmpresaGrupo_Agregar");
            b.AddParameter("@IdEmpresa", grupo.Id, SqlDbType.Int);
            b.AddParameter("@IdUser", grupo.IdP, SqlDbType.Int);
            b.AddParameter("@Nombre", grupo.Nombre, SqlDbType.NVarChar);

            Models.Grupo resultado = new Models.Grupo();
            var reader = b.ExecuteReader();
            while (reader.Read())
            {
                resultado.Id = Convert.ToInt32(reader["Id"].ToString());

            }
            reader = null;
            b.ConnectionCloseToTransaction();
            return resultado;
        }



        public Models.Grupo EmpresaGrupo_Eliminar(Models.Grupo grupo)

        {
            b.ExecuteCommandSP("EmpresaGrupo_Eliminar");
            b.AddParameter("@Idgrupo", grupo.Id, SqlDbType.Int);


            Models.Grupo resultado = new Models.Grupo();
            var reader = b.ExecuteReader();
            while (reader.Read())
            {
                resultado.Id = Convert.ToInt32(reader["Id"].ToString());

            }
            reader = null;
            b.ConnectionCloseToTransaction();
            return resultado;
        }





        public List<Models.Grupo> Cat_ClasificacionArchivo_Listar_Id(Models.Grupo Datacarpeta)
        {
            b.ExecuteCommandSP("Cat_ClasificacionArchivo_Listar_Id");
            b.AddParameter("@Id", Datacarpeta.Id, SqlDbType.Int);

            List<Models.Grupo> resultado = new List<Models.Grupo>();
            var reader = b.ExecuteReader();
            while (reader.Read())
            {
                Models.Grupo item = new Models.Grupo()
                {
                    Id = Convert.ToInt32(reader["Id"].ToString()),
                    Nombre = reader["Nombre"].ToString()
                   
                };
                resultado.Add(item);
            }
            reader = null;
            b.ConnectionCloseToTransaction();
            return resultado;
        }

        public List<Models.Grupo> Cat_ClasificacionArchivo_Listar_Faltante(Models.Grupo Datacarpeta)
        {
            b.ExecuteCommandSP("Cat_ClasificacionArchivo_Listar_Faltante");
            b.AddParameter("@Id", Datacarpeta.Id, SqlDbType.Int);

            List<Models.Grupo> resultado = new List<Models.Grupo>();
            var reader = b.ExecuteReader();
            while (reader.Read())
            {
                Models.Grupo item = new Models.Grupo()
                {
                    Id = Convert.ToInt32(reader["Id"].ToString()),
                    Nombre = reader["Nombre"].ToString(),
                    Empresa = reader["Empresa"].ToString()

                };
                resultado.Add(item);
            }
            reader = null;
            b.ConnectionCloseToTransaction();
            return resultado;
        }


        public List<Models.Grupo> Cat_ClasificacionArchivo_Listar_Permiso(Models.Grupo Datacarpeta)
        {
            b.ExecuteCommandSP("Cat_ClasificacionArchivo_Listar_Permiso");
            b.AddParameter("@Id", Datacarpeta.Id, SqlDbType.Int);

            List<Models.Grupo> resultado = new List<Models.Grupo>();
            var reader = b.ExecuteReader();
            while (reader.Read())
            {
                Models.Grupo item = new Models.Grupo()
                {
                    Id = Convert.ToInt32(reader["Id"].ToString()),
                    Nombre = reader["Nombre"].ToString(),
                    email = reader["EMail"].ToString(),
                    Empresa = reader["Alias"].ToString(),
                };
                resultado.Add(item);
            }
            reader = null;
            b.ConnectionCloseToTransaction();
            return resultado;
        }


        public Models.Grupo Usuario_Carpeta_Insertar(int DataIdP,int Datacarpeta)

        {
            b.ExecuteCommandSP("Usuario_Carpeta_Insertar");
            b.AddParameter("@UserId", DataIdP, SqlDbType.Int);
            b.AddParameter("@Idcarpeta", Datacarpeta, SqlDbType.Int);


            Models.Grupo resultado = new Models.Grupo();
            var reader = b.ExecuteReader();
            while (reader.Read())
            {
                resultado.Id = Convert.ToInt32(reader["Id"].ToString());

            }
            reader = null;
            b.ConnectionCloseToTransaction();
            return resultado;
        }

    
        public Models.Grupo Usuario_Carpeta_Borrar(int DataIdP, int Datacarpeta)

        {
            b.ExecuteCommandSP("Usuario_Carpeta_Borrar");
            b.AddParameter("@UserId", DataIdP, SqlDbType.Int);
            b.AddParameter("@Idcarpeta", Datacarpeta, SqlDbType.Int);


            Models.Grupo resultado = new Models.Grupo();
            var reader = b.ExecuteReader();
            while (reader.Read())
            {
                resultado.Id = Convert.ToInt32(reader["Id"].ToString());

            }
            reader = null;
            b.ConnectionCloseToTransaction();
            return resultado;
        }

    }
}

