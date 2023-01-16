namespace ATSB.Api.Models.Pasivo
{
    public class PasCuentaLiquidezRequest
    {
        public int CodigoEmpresa { get; set; }
        public int TipoDeposito { get; set; }
        public int TipoCliente { get; set; }
        public int CodigoCuentaLiquidez { get; set; }
        public string? DestinoLocalExtranjero { get; set; }
        public int? DiasRango1 { get; set; }
        public int? DiasRango2 { get; set; }
        public string? IdUsuario { get; set; }
    }
}
