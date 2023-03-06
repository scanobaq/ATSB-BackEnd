using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ATSB.Api.Models.Temporales
{
    public class TmpCargaExcelInversionesCalificacionesDefRequest
    {
        public DateTime? Fecha { get; set; }
        public string? Libro { get; set; }
        public string? CodigoIsin { get; set; }
        public string? Producto { get; set; }
        public string? Instrumento { get; set; }
        public string? Emisor { get; set; }
        public double? MontoNominal { get; set; }
        public string? Pais { get; set; }
        public string? CountryOfRisk { get; set; }
        public string? País1 { get; set; }
        public string? CountryOfRisk1 { get; set; }
        public string? CodEmisorBloomberg { get; set; }
        public string? CalificacionSp { get; set; }
        public string? CalificacionSpNational { get; set; }
        public string? CalifSpFcurLtdebt { get; set; }
        public string? CalificacionMoodys { get; set; }
        public string? CalifMoodysLtcra { get; set; }
        public string? CalifMoodyFccurIr { get; set; }
        public string? CalificacionFitch { get; set; }
        public string? CalificacionFitchNational { get; set; }
        public string? CalificacionFitchNationalEmisor { get; set; }
        public string? CalifFitchFcltdebt { get; set; }
        public string? CalifSpInternational { get; set; }
        public string? CalifiSpNational { get; set; }
        public string? CalifSpFcurLtdebt1 { get; set; }
        public string? CalifMoodys { get; set; }
        public string? CalifMoodysLtCounterpartyRa { get; set; }
        public string? CalifMoodysFccurIrating { get; set; }
        public string? CalifFitch { get; set; }
        public string? CalifFitchNational { get; set; }
        public string? CalifFitchNationalEmisor { get; set; }
        public string? CalifFitchFcltDebt1 { get; set; }
        public short? CalifSpNo { get; set; }
        public short? CalifSpNatNo { get; set; }
        public short? CalifSpForCurLtdebtNo { get; set; }
        public short? CalifMoodyNo { get; set; }
        public short? CalifMoodyLtcountRikAssNo { get; set; }
        public short? CalifMoodyFcCurrIssuerRatNo { get; set; }
        public short? CalifFitchNo { get; set; }
        public short? CalifFitchNatNo { get; set; }
        public short? CalifFitchNatEmisorNo { get; set; }
        public short? CalifFitchForCurLtdebtNo { get; set; }
    }
}
