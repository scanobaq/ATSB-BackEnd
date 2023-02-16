using System;
using System.Collections.Generic;
using ATSB.Api.Areas.Entities.Parametros;

namespace ATSB.Api.Areas.Entities.Seguridad
{
    public partial class SegAcceso
    {
        public int CodigoEmpresa { get; set; }
        public int CodigoTipoAcceso { get; set; }
        public string? Descripcion { get; set; }
        public bool? IndicadorLunes { get; set; }
        public int? HoraInicioLunes { get; set; }
        public int? HoraFinLunes { get; set; }
        public bool? IndicadorMartes { get; set; }
        public int? HoraInicioMartes { get; set; }
        public int? HoraFinMartes { get; set; }
        public bool? IndicadorMiercoles { get; set; }
        public int? HoraInicioMiercoles { get; set; }
        public int? HoraFinMiercoles { get; set; }
        public bool? IndicadorJueves { get; set; }
        public int? HoraInicioJueves { get; set; }
        public int? HoraFinJueves { get; set; }
        public bool? IndicadorViernes { get; set; }
        public int? HoraInicioViernes { get; set; }
        public int? HoraFinViernes { get; set; }
        public bool? IndicadorSabado { get; set; }
        public int? HoraInicioSabado { get; set; }
        public int? HoraFinSabado { get; set; }
        public bool? IndicadorDomingo { get; set; }
        public int? HoraInicioDomingo { get; set; }
        public int? HoraFinDomingo { get; set; }
        public bool? IndicadorFestivo { get; set; }
        public int? HoraInicioFestivo { get; set; }
        public int? HoraFinFestivo { get; set; }
        public string? IdUsuario { get; set; }
        public string? Id { get; set; }

        public virtual ParEmpresa CodigoEmpresaNavigation { get; set; }
    }
}
