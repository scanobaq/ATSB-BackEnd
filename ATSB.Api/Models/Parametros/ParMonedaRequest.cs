namespace ATSB.Api.Models.Parametros
{
    public class ParMonedaRequest
    {
        public int CodigoEmpresa { get; set; }
        public int CodigoMoneda { get; set; }
        public string Descripcion { get; set; }
        public string DescripcionCorta { get; set; }
        public string IdUsuario { get; set; }
    }
}
