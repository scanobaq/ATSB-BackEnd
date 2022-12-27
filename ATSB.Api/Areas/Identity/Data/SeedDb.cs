using ATSB.Api.Areas.Identity.Entities.Security;
using ATSB.Api.Areas.Identity.Data;
using ATSB.Helpers;

namespace ATSB.Api.Areas.Identity.Data
{
    public class SeedDb
    {
        private readonly ATSBIdentityDbContext _dbContext;
        private readonly IUserHelper _userHelper;

        public SeedDb(ATSBIdentityDbContext dbContext, IUserHelper userHelper)
        {
            _dbContext = dbContext;
            _userHelper = userHelper;
        }

        public async Task SeedAsync()
        {
            await _dbContext.Database.EnsureCreatedAsync();
            await CheckRoles();
            //var manager = await CheckUserAsync(0, "Cano", "Baquero", "Esneider", "Usuario prueba", DateTime.Now, true, "1", DateTime.Now, DateTime.Now, "snayder.cano@gmail.com", "Admin");
            //var customer = await CheckUserAsync(0, "Cano", "Baquero", "Esneider", "Usuario prueba", DateTime.Now, true, "1", DateTime.Now, DateTime.Now, "snayder.cano@gmail.com", "Admin");
            var customer = await CheckUserAsync(0, "Cano", "Baquero", "Esneider", "Usuario prueba", DateTime.Now, true, "1", DateTime.Now, DateTime.Now, "ecano@dmdintersoft.com", "Customer");

            // await CheckManagerAsync(manager);
            // await CheckExchangeRates();
            // await CheckPayTypesAsync();
            // await CheckCountryAsync();
            // await CheckCityAsync();

            //await CheckAgendasAsync();
        }

        private async Task CheckRoles()
        {
            await _userHelper.CheckRoleAsync("Admin");
            await _userHelper.CheckRoleAsync("Customer");
        }

        private async Task<UserAtsb> CheckUserAsync(
            int codigoEmpresa,
            string apellido1,
            string apellido2,
            string nombre,
            string descripcion,
            DateTime fechaExpiracionPassword,
            bool indicadorReinicioPassword,
            string codigoEstado,
            DateTime fechaIngreso,
            DateTime fechaSalida,
            string email,
            string role)
        {
            var user = await _userHelper.GetUserByEmailAsync(email);
            if (user == null)
            {
                user = new UserAtsb
                {
                    Apellido1 = apellido1,
                    Apellido2 = apellido2,
                    UserName = email,
                    Nombre = nombre,
                    Email = email
                };

                await _userHelper.AddUserAsync(user, "Atsb2023?");
                await _userHelper.AddUserToRoleAsync(user, role);
                await _dbContext.SaveChangesAsync();

                //var token = await _userHelper.GenerateEmailConfirmationTokenAsync(user);
                //await _userHelper.ConfirmEmailAsync(user, token);
            }

            return user;
        }

    }
}