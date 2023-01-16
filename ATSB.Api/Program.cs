using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using ATSB.Api.Areas.Identity.Data;
using ATSB.Api.Areas.Identity.Entities.Security;
using Microsoft.IdentityModel.Tokens;
using System.Text;
using ATSB.Api.Areas.Identity.Data;
using ATSB.Helpers;
using ATSB.Api.Areas.Repositories.Parametros;
using ATSB.Api.Helpers;
using ATSB.Api.Areas.Repositories.Configuracion;
using ATSB.Api.Areas.Repositories.Contable;
using ATSB.Api.Areas.Repositories.Credito;
using ATSB.Api.Areas.Repositories.Liquidez;
using ATSB.Api.Areas.Repositories.Pasivo;
using ATSB.Api.Areas.Repositories.Seguridad;

var builder = WebApplication.CreateBuilder(args);
var connectionString = builder.Configuration.GetConnectionString("ATSBIdentityDbContextConnection") ?? throw new InvalidOperationException("Connection string 'ATSBIdentityDbContextConnection' not found.");

builder.Services.AddDbContext<ATSBIdentityDbContext>(options =>
    options.UseSqlServer(connectionString));

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

builder.Services.AddAuthentication()
        .AddCookie()
        .AddJwtBearer(options =>
        {
            options.TokenValidationParameters = new TokenValidationParameters
            {
                ValidIssuer = builder.Configuration["Tokens:Issuer"],
                ValidAudience = builder.Configuration["Tokens:Audience"],
                IssuerSigningKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(builder.Configuration["Tokens:Key"]))
            };
        });

builder.Services.AddIdentity<UserAtsb, IdentityRole>(options =>
{
    options.Tokens.AuthenticatorTokenProvider = TokenOptions.DefaultAuthenticatorProvider;
    options.SignIn.RequireConfirmedEmail = true;
    options.User.RequireUniqueEmail = true;
    options.Password.RequireDigit = false;
    options.Password.RequiredUniqueChars = 0;
    options.Password.RequireLowercase = false;
    options.Password.RequireNonAlphanumeric = false;
    options.Password.RequireUppercase = false;


}).AddEntityFrameworkStores<ATSBIdentityDbContext>().AddDefaultTokenProviders();

builder.Services.AddTransient<SeedDb>();
builder.Services.AddScoped<IUserHelper, UserHelper>();
builder.Services.AddScoped<IConsecutivoHelper, ConsecutivoHelper>();

builder.Services.AddScoped<IParEstadoRepository, ParEstadoRepository>();
builder.Services.AddScoped<IParPaisRepository, ParPaisRepository>();
builder.Services.AddScoped<IParTipoIdentificacionRepository , ParTipoIdentificacionRepository>();
builder.Services.AddScoped<IParEmpresaRepository, ParEmpresaRepository>();
builder.Services.AddScoped<IParConsecutivoRepository, ParConsecutivoRepository>();
builder.Services.AddScoped<IParProcesoRepository, ParProcesoRepository>();
builder.Services.AddScoped<IParTipoOrigenDatosRepository, ParTipoOrigenDatosRepository>();
builder.Services.AddScoped<IParCalificacionRiesgoRepository,ParCalificacionRiesgoRepository>();
builder.Services.AddScoped<IParMonedaRepository, ParMonedaRepository>();
builder.Services.AddScoped<IParTipoCambioRepository, ParTipoCambioRepository>();
builder.Services.AddScoped<IParSucursalRepository, ParSucursalRepository>();
builder.Services.AddScoped<ICnfCalificacionRiesgoEquivalenciaRepository, CnfCalificacionRiesgoEquivalenciaRepository>();
builder.Services.AddScoped<ICnfTablaGenericaRepository, CnfTablaGenericaRepository>();
builder.Services.AddScoped<ICnfTablaGenericaCamposRepository, CnfTablaGenericaCamposRepository>();
builder.Services.AddScoped<ICnfTablaRepository, CnfTablaRepository>();
builder.Services.AddScoped<ICnfTablaValorRepository, CnfTablaValorRepository>();
builder.Services.AddScoped<ICnfArchivoRepository, CnfArchivoRepository>();
builder.Services.AddScoped<ICnfArchivoCampoRepository,CnfArchivoCampoRepository>();
builder.Services.AddScoped<ICnfTablaGenericaValoresRepository, CnfTablaGenericaValoresRepository>();
builder.Services.AddScoped<ICnfEjecucionReportesRepository, CnfEjecucionReportesRepository>();
builder.Services.AddScoped<ICnfRangoMontoEncabezadoRepository, CnfRangoMontoEncabezadoRepository>();
builder.Services.AddScoped<ICnfEjecucionProcesosRepository, CnfEjecucionProcesosRepository>();
builder.Services.AddScoped<ICnfRangoMontoDetalleRepository, CnfRangoMontoDetalleRepository>();
builder.Services.AddScoped<IConTipoCuentaRepository, ConTipoCuentaRepository>();
builder.Services.AddScoped<IConCatalogoEquivalenciaRepository, ConCatalogoEquivalenciaRepository>();
builder.Services.AddScoped<IConCuentaLiquidezRepository, ConCuentaLiquidezRepository>();
builder.Services.AddScoped<IConBalanceHistoricoRepository, ConBalanceHistoricoRepository>();
builder.Services.AddScoped<IParCalificacionRiesgoPaisRepository, ParCalificacionRiesgoPaisRepository>();
builder.Services.AddScoped<ICreMaestroRepository, CreMaestroRepository>();
builder.Services.AddScoped<ILiqRubroProcesoRepository, LiqRubroProcesoRepository>();
builder.Services.AddScoped<ILiqIndiceRepository, LiqIndiceRepository>();
builder.Services.AddScoped<ILiqInstrumentoRubroRepository, LiqInstrumentoRubroRepository>();
builder.Services.AddScoped<IPasMaestroRepository, PasMaestroRepository>();
builder.Services.AddScoped<IPasCuentaLiquidezRepository, PasCuentaLiquidezRepository>();
builder.Services.AddScoped<IPasDetalleHistoricoRepository, PasDetalleHistoricoRepository>();
builder.Services.AddScoped<IPasGarantiaPIgnoradoRepository, PasGarantiaPIgnoradoRepository>();
builder.Services.AddScoped<ISegEstadoRepository, SegEstadoRepository>();
builder.Services.AddScoped<ISegEventoRepository, SegEventoRepository>();
builder.Services.AddScoped<ISegHistoricoPasswordRepository, SegHistoricoPasswordRepository>();
builder.Services.AddScoped<ISegConfiguracionRepository, SegConfiguracionRepository>();

var app = builder.Build();

if (args.Length == 1 && args[0].ToLower() == "seeddata")
    seeddata(app);

async void seeddata(IHost app)
{
    var scopeFactory = app.Services.GetService<IServiceScopeFactory>();
    using (var scope = scopeFactory.CreateScope())
    {
        var seeder = scope.ServiceProvider.GetService<SeedDb>();
        await seeder.SeedAsync();
    }
}

app.UseCors(options =>
           {
               options.WithOrigins("http://localhost:3000");
               options.AllowAnyMethod();
               options.AllowAnyHeader();
           });

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();
app.UseAuthentication(); ;

app.UseAuthorization();

app.MapControllers();

app.Run();

