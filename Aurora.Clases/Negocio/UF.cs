using System;
using System.Collections.Generic;
using System.Linq;
using System.Data;
using System.Text;
using Aurora.Clases.Base.Enums;
using Aurora.Clases.Entidad;
namespace Aurora.Clases.Negocio
{
    public class UF
    {
        public static InfoUF Crear(InfoUF uf)
        {
            InfoUF ufaux = Buscar(uf.Mes,uf.Ano);
            if (ufaux == null)
            {
                if (!(uf.Ano > DateTime.Now.Year || (uf.Ano == DateTime.Now.Year && uf.Mes > DateTime.Now.Month)))
                    return Datos.UF.Crear(uf);
                else
                {
                    throw new Exception(" No se debe crear una UF posterior");
                }
            }
            else
            {
                throw new Exception(" Ya existe la UF!");
            }
        }
        public static InfoUF Modificar(InfoUF uf)
        {
            return Datos.UF.Modificar(uf);
        }
        public static void Eliminar(int mes, int ano)
        {
            Datos.UF.Eliminar(mes, ano);
        }
        public static InfoUF Buscar(int mes, int ano)
        {
            return Datos.UF.Buscar(mes, ano);
            
        }
        public static DataTable Listar()
        {
            return Datos.UF.Listar();
        }
    }
}
