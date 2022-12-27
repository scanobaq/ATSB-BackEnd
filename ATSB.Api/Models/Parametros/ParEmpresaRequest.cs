using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ATSB.Api.Models.Parametros
{
    public class ParEmpresaRequest
    {
        public int CodigoEmpresa { get; set; }
        public string Nombre { get; set; }
        public string NumeroId { get; set; }
        public string Telefono1 { get; set; }
        public string Telefono2 { get; set; }
        public DateTime FechaIngreso { get; set; }
        public string IdUsuario { get; set; }
        public DateTime FechaUltimaModificacion { get; set; }
        public string UsuarioModifica { get; set; }
        public int CantidadModificaciones { get; set; }
        public int CodigoTipoIdentificacion { get; set; }
        public int CodigoPais { get; set; }
        public int CodigoEstado { get; set; }
        public string CodigoBancoRegulador { get; set; }
    }
}
