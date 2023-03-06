using System;
using System.Collections.Generic;

namespace ATSB.Api.Areas.Entities.Temporales
{
    public partial class TmpCargaExcelInversione
    {
        /// <summary>
        /// 1-Fecha
        /// </summary>
        public string Fecha { get; set; }
        /// <summary>
        /// 2-Código Banco
        /// </summary>
        public string CodBanco { get; set; }
        /// <summary>
        /// 3-Código Subsidiaria
        /// </summary>
        public string CodSubsidiaria { get; set; }
        /// <summary>
        /// 4-Código Rubro
        /// </summary>
        public string CodRubro { get; set; }
        /// <summary>
        /// 5-Fecha Emisión
        /// </summary>
        public string FechaEmision { get; set; }
        /// <summary>
        /// 6-Fecha Adquisición
        /// </summary>
        public string FechaAdquisicion { get; set; }
        /// <summary>
        /// 7-Fecha Vencimiento
        /// </summary>
        public string FechaVencimiento { get; set; }
        /// <summary>
        /// 8-Ente
        /// </summary>
        public string Ente { get; set; }
        /// <summary>
        /// 9-Destino
        /// </summary>
        public string Destino { get; set; }
        /// <summary>
        /// 10-Código Región
        /// </summary>
        public string CodRegion { get; set; }
        /// <summary>
        /// 11-Banco Relación
        /// </summary>
        public string BancoRelacion { get; set; }
        /// <summary>
        /// 12-Instr Obligación
        /// </summary>
        public string InstrObligacion { get; set; }
        /// <summary>
        /// 13-Riesgo Fitch
        /// </summary>
        public string RiesgoFitch { get; set; }
        /// <summary>
        /// 14-Riesgo Moody
        /// </summary>
        public string RiesgoMoody { get; set; }
        /// <summary>
        /// 15-Riesgo SP
        /// </summary>
        public string RiesgoSp { get; set; }
        /// <summary>
        /// 16-Garante
        /// </summary>
        public string Garante { get; set; }
        /// <summary>
        /// 17-Valor Libros
        /// </summary>
        public string ValLibros { get; set; }
        /// <summary>
        /// 18-Valor Nominal
        /// </summary>
        public string ValNominal { get; set; }
        /// <summary>
        /// 19-Valor Mercado
        /// </summary>
        public string ValorMercado { get; set; }
        /// <summary>
        /// 20-Tasa
        /// </summary>
        public string Tasa { get; set; }
        /// <summary>
        /// 21-Interés Por Cobrar
        /// </summary>
        public string IntXCobrar { get; set; }
        /// <summary>
        /// 22-Ticket
        /// </summary>
        public string Ticket { get; set; }
        /// <summary>
        /// 23-Cupón
        /// </summary>
        public string Cupon { get; set; }
        /// <summary>
        /// 24-Escalada Fitch
        /// </summary>
        public string EscaladaFitch { get; set; }
        /// <summary>
        /// 25-Escalada Moody
        /// </summary>
        public string EscaladaMoody { get; set; }
        /// <summary>
        /// 26-Escalada SP
        /// </summary>
        public string EscaladaSp { get; set; }
        /// <summary>
        /// 0-NA
        /// </summary>
        public Guid Llave { get; set; }
    }
}
