using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ATSB.Api.Models.Contable
{
    public class ConCatalogoEquivalenciaRequest
    {
        public int CodigoEmpresa { get; set; }
        public int IdCuenta { get; set; }
        public string? CuentaContableLocal { get; set; }
        public int? CuentaContableAnteriorSuperIntendencia { get; set; }
        public string? NombreCuenta { get; set; }
        public int? CodigoTipo { get; set; }
        public string? Destino { get; set; }
        public int? CodigoPais { get; set; }
        public int? CuentaContableSuperIntendencia { get; set; }
        public string? IdUsuario { get; set; }
    }
}
