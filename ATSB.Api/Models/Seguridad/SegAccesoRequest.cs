using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ATSB.Api.Models.Seguridad
{
    public class SegAccesoRequest
    {
        public int CodigoEmpresa { get; set; }
        public int CodigoTipoAcceso { get; set; }
        public string? Descripcion { get; set; }
        public string? IndicadorLunes { get; set; }
        public int? HoraInicioLunes { get; set; }
        public int? HoraFinLunes { get; set; }
        public string? IndicadorMartes { get; set; }
        public int? HoraInicioMartes { get; set; }
        public int? HoraFinMartes { get; set; }
        public string? IndicadorMiercoles { get; set; }
        public int? HoraInicioMiercoles { get; set; }
        public int? HoraFinMiercoles { get; set; }
        public string? IndicadorJueves { get; set; }
        public int? HoraInicioJueves { get; set; }
        public int? HoraFinJueves { get; set; }
        public string? IndicadorViernes { get; set; }
        public int? HoraInicioViernes { get; set; }
        public int? HoraFinViernes { get; set; }
        public string? IndicadorSabado { get; set; }
        public int? HoraInicioSabado { get; set; }
        public int? HoraFinSabado { get; set; }
        public string? IndicadorDomingo { get; set; }
        public int? HoraInicioDomingo { get; set; }
        public int? HoraFinDomingo { get; set; }
        public string? IndicadorFestivo { get; set; }
        public int? HoraInicioFestivo { get; set; }
        public int? HoraFinFestivo { get; set; }
        public string? IdUsuario { get; set; }
        public string? Id { get; set; }
    }
}
