using System;
using System.Collections.Generic;

namespace ProyectoBase.Application
{
	public class Grupo
	{
        Data.Grupo _Grupo = new Data.Grupo();

        public List<Models.Grupo> Grupo_ListarPor_Id(Models.Grupo grupo)
        {
            return _Grupo.Grupo_ListarPor_Id(grupo);
        }

        public List<Models.Grupo> GrupoPersona_listar(Models.Grupo grupo)
        {
            return _Grupo.GrupoPersona_listar(grupo);
        }

        public List<Models.Grupo> GrupoPersona_listarFaltante(Models.Grupo grupo)
        {
            return _Grupo.GrupoPersona_listarFaltante(grupo);
        }

        public Models.Grupo InsertarGrupoPersona(Models.Grupo grupo)
        {
            return _Grupo.InsertarGrupoPersona(grupo);
        }

        public Models.Grupo EliminarGrupoPersona(Models.Grupo grupo)
        {
            return _Grupo.EliminarGrupoPersona(grupo);
        }

        public Models.Grupo EmpresaGrupo_Agregar(Models.Grupo grupo)
        {
            return _Grupo.EmpresaGrupo_Agregar(grupo);
        }

        public Models.Grupo EmpresaGrupo_Eliminar(Models.Grupo grupo)
        {
            return _Grupo.EmpresaGrupo_Eliminar(grupo);
        }



        public List<Models.Grupo> Cat_ClasificacionArchivo_Listar_Id(Models.Grupo Datacarpeta)
        {
            return _Grupo.Cat_ClasificacionArchivo_Listar_Id(Datacarpeta);
        }


        public List<Models.Grupo> Cat_ClasificacionArchivo_Listar_Faltante(Models.Grupo Datacarpeta)
        {
            return _Grupo.Cat_ClasificacionArchivo_Listar_Faltante(Datacarpeta);
        }



        public List<Models.Grupo> Cat_ClasificacionArchivo_Listar_Permiso(Models.Grupo Datacarpeta)
        {
            return _Grupo.Cat_ClasificacionArchivo_Listar_Permiso(Datacarpeta);
        }
        public Models.Grupo Usuario_Carpeta_Insertar(int DataIdP, int  Datacarpeta)
        {
            return _Grupo.Usuario_Carpeta_Insertar(DataIdP,Datacarpeta);
        }

        public Models.Grupo Usuario_Carpeta_Borrar(int DataIdP, int Datacarpeta)
        {
            return _Grupo.Usuario_Carpeta_Borrar(DataIdP, Datacarpeta);
        }
    }

}

