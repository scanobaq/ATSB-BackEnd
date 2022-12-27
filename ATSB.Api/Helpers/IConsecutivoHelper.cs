using Microsoft.AspNetCore.Identity;
using System.Threading.Tasks;

namespace ATSB.Api.Helpers
{
    public interface IConsecutivoHelper
    {
        Task<int> GetConsecutivo(int CodigoEmpresa, string IdConsecutivo);
        Task<bool> updateConsecutivo(int CodigoEmpresa, string IdConsecutivo);
    }
}
