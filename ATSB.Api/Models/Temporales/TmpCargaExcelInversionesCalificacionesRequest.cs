using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ATSB.Api.Models.Temporales
{
    public class TmpCargaExcelInversionesCalificacionesRequest
    {
        public string? Fecha { get; set; }
        public string? Libro { get; set; }
        public string? CodigoIsin { get; set; }
        public string? Producto { get; set; }
        public string? Instrumento { get; set; }
        public string? Emisor { get; set; }
        public string? MontoNominal { get; set; }
        public string? Pais { get; set; }
        public string? CountryOfRisk { get; set; }
        public string? Pais1 { get; set; }
        public string? CountryOfRisk1 { get; set; }
        public string? CodEmisorBloomberg { get; set; }
        public string? CalificacionSp { get; set; }
        public string? CalificacionSpNational { get; set; }
        public string? CalifSpFcurLtdebt { get; set; }
        public string? CalificacionMoodys { get; set; }
        public string? CalifMoodysLtcra { get; set; }
        public string? CalifMoodysFccurlR { get; set; }
        public string? CalificacionFitch { get; set; }
        public string? CalificacionFitchNational { get; set; }
        public string? CalificacionFitchNationalEmisor { get; set; }
        public string? CalifFitchFcltdebt { get; set; }
        public string? CalifSpInternational { get; set; }
        public string? CalifSpNational { get; set; }
        public string? CalifSpFcurLtdebt1 { get; set; }
        public string? CalifMoodys { get; set; }
        public string? CalifMoodysLtCounterpartyRa { get; set; }
        public string? CalifMoodysFccurlRating { get; set; }
        public string? CalifFitch { get; set; }
        public string? CalifFitchNational { get; set; }
        public string? CalifFitchNationalEmisor { get; set; }
        public string? CalifFitchFcltDebt1 { get; set; }
        public string? CalifSpNo { get; set; }
        public string? CalifSpNatNo { get; set; }
        public string? CalifSpForCurLtdebtNo { get; set; }
        public string? CalifMoodyNo { get; set; }
        public string? CalifMoodyLtcountRikAssNo { get; set; }
        public string? CalifMoodyFcCurrissuerRatNo { get; set; }
        public string? CalifFitchNo { get; set; }
        public string? CalifFitchNatNo { get; set; }
        public string? CalifFitchNatEmisorNo { get; set; }
        public string? CalifFitchForCurLtdebtNo { get; set; }
    }
}
