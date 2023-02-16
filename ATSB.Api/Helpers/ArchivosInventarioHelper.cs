using Microsoft.AspNetCore.Identity;
using System.Threading.Tasks;
using System.Linq;
using System.Collections.Generic;
using System.Threading.Tasks;
using System;
using Microsoft.EntityFrameworkCore;
using ATSB.Api.Areas.Identity.Data;
using System;
using System.IO;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using ATSB.Api.Areas.Entities.Tools.Generales;
using ATSB.Api.Helpers;
using NuGet.Packaging;
using ATSB.Api.Areas.Entities.Configuracion;
using ATSB.Models;
using ATSB.Api.Areas.Entities.Contable;

namespace ATSB.Api.Helpers
{
    public class ArchivosInventarioHelper : IArchivosInventarioHelper
    {
        private readonly ATSBIdentityDbContext _context;
        public ArchivosInventarioHelper(ATSBIdentityDbContext dbcontext)
        {
            _context = dbcontext;
        }

        public List<string> ValidarInventarioArchivosProceso(int CodigoProceso, string Ruta)
        {
            bool archivoEncontrado = false;
            string extension = "";
            List<string> lstArchivosNoEncontrados = new List<string>();
            var ejecucionProcesos = (from p in _context.CnfEjecucionprocesos
                                     where p.CodigoProceso == CodigoProceso
                                     select p).ToList();

            if (!Directory.Exists(Ruta))
            {
                throw new Exception("No se encontró la ruta especificada");
            }

            string[] archivos = Directory.GetFiles(Ruta);


            foreach (var file in archivos)
            {
                var filename = file.Replace(Ruta + "\\", "");
                //while (archivoEncontrado == false)
                //{
                for (int i = 0; i < ejecucionProcesos.Count; i++)
                {
                    if (filename.Contains(ejecucionProcesos[i].DescripcionOrigenDatos) == true)
                    {
                        switch (ejecucionProcesos[i].CodigoOrigenDatos)
                        {
                            //Valida que CodigoOrigenDatos (1) == txt, sino agrega a lista
                            case 1:
                                if (Path.GetExtension(filename) == ".txt")
                                {
                                    ejecucionProcesos.RemoveAt(i);
                                }
                                break;

                            //Valida que CodigoOrigenDatos (2) == xls/xlsx, sino agrega a lista
                            case 2:
                                if (Path.GetExtension(filename) == ".xls" || Path.GetExtension(filename) != ".xlsx")
                                {
                                    ejecucionProcesos.RemoveAt(i);
                                }
                                break;
                        }
                        //ejecucionProcesos.RemoveAt(i);
                        break;
                    }
                }
                //}
            }

            for (int i = 0; i < ejecucionProcesos.Count; i++)
            {
                if (ejecucionProcesos[i].CodigoOrigenDatos == 1)
                {
                    extension = ".txt";
                }
                else if (ejecucionProcesos[i].CodigoOrigenDatos == 2)
                {
                    extension = ".xls";
                }
                lstArchivosNoEncontrados.Add(ejecucionProcesos[i].DescripcionOrigenDatos.ToString() + extension);
            }

            return lstArchivosNoEncontrados;
        }

        public async Task<Response<object>> CopiaArchivosAServidor(string Ruta, DateTime FechaProceso)
        {
            string nombreArchivo = "";
            string rutaDestino = ""; //SE DEBE INGRESAR LA RUTA DE DESTINO EN SERVIDOR
            string archivoFin = "";
            string nombreCarpeta = FechaProceso.Year.ToString() + FechaProceso.Month.ToString() + FechaProceso.Day.ToString();

            rutaDestino = Path.Combine(rutaDestino, nombreCarpeta);
            if (!Directory.Exists(rutaDestino))
            {
                Directory.CreateDirectory(rutaDestino);
            }

            if (!Directory.Exists(Ruta))
            {
                throw new Exception("No se encontró la ruta especificada");
            }

            string[] archivos = Directory.GetFiles(Ruta);


            foreach (var archivo in archivos)
            {
                nombreArchivo = Path.GetFileName(archivo);
                archivoFin = Path.Combine(rutaDestino, nombreArchivo);
                File.Copy(archivo, archivoFin, true);
            }

            return (new Response<object>
            {
                IsSuccess = true,
                Message = "Se realizó la copia de los archivos",
                Result = ""
            });
        }

    }
}
