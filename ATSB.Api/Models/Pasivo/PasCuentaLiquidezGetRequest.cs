namespace ATSB.Api.Models.Pasivo
{
    public class PasCuentaLiquidezGetRequest
    {
        public int CodigoEmpresa { get; set; }
        public int TipoDeposito { get; set; }
        public int TipoCliente { get; set; }
        public int CodigoCuentaLiquidez { get; set; }
        public string? DestinoLocalExtranjero { get; set; }
    }
}
