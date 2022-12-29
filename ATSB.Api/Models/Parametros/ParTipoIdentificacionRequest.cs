using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ATSB.Api.Models.Parametros
{
    public class ParTipoIdentificacionRequest
    {
        public int CodigoPais { get; set; }
        public int CodigoTipoIdentificacion { get; set; }
        public string Descripcion { get; set; }
        public string Formato { get; set; }
        public int Longitud { get; set; }
        public string IndicadorFisica { get; set; }
        public DateTime FechaUltimaModificacion { get; set; }
        public string UsuarioModifica { get; set; }
        public int CantidadModificaciones { get; set; }
        public string CodigoFacturaElectronica { get; set; }
    }
}
