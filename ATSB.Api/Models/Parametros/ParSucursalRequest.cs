namespace ATSB.Api.Models.Parametros
{
    public class ParSucursalRequest
    {
        public int CodigoEmpresa { get; set; }
        public int CodigoBanco { get; set; }
        public int CodigoSucursal { get; set; }
        public string NombreSucursal { get; set; }
        public int? CodigoSubsidiaria { get; set; }
        public string CodigoOrigen { get; set; }
        public int? CodigoPais { get; set; }
        public int? TipoEstablecimiento { get; set; }
        public string Direccion { get; set; }
        public string Telefono1 { get; set; }
        public string Encargado { get; set; }
        public string Telefono2 { get; set; }
        public string Fax { get; set; }
        public string NombreResponsable { get; set; }
        public int? CargoResposable { get; set; }
        public int? CodigoEstado { get; set; }
        public string IdUsuario { get; set; }
    }
}
