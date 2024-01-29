using DataHelper;
using Model;
using Repository;
using Services;
using static Dapper.SqlMapper;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

var connectionDict = new Dictionary<ConnectionStrings, string>
            {
                {ConnectionStrings.LiveConnectionString, builder.Configuration.GetConnectionString("LiveConnectionString") },
            };

//Inject connection string dict
builder.Services.AddSingleton<IDictionary<ConnectionStrings, string>>(connectionDict);
builder.Services.AddTransient<IDbConnectionFactory, DapperDbConnectionFactory>();
builder.Services.AddSingleton<ICompanies, CompaniesRepo>();
builder.Services.AddSingleton<IDepartment, DepartmentsRepo>();
builder.Services.AddSingleton<IPlant, PlantsRepo>();
builder.Services.AddSingleton<IAuthentications, AuthenticationsRepo>();
builder.Services.AddSingleton<IMenus, MenusRepo>();
builder.Services.AddSingleton<IUserRights, UserRightsRepo>();
builder.Services.AddSingleton<ILevels, LevelsRepo>();
builder.Services.AddSingleton<IEmployees, EmployeesRepo>();
builder.Services.AddSingleton<IKaizen, KaizenRepo>();
builder.Services.AddSingleton<IApproval, ApprovalRepo>();
builder.Services.AddSingleton<IProducts, ProductsRepo>();
builder.Services.AddSingleton<IDashBoard2, DashBoard2Repo>();
builder.Services.AddSingleton<IRedeem, RedeemReo>();
builder.Services.AddSingleton<IReports, ReportsRepo>();
builder.Services.AddSingleton<IUsers, UsersRepo>();
builder.Services.AddSingleton<IPokoYoko, PokoYokoRepo>();
builder.Services.AddSingleton<IPokaYokeDashboard, PokaYokeDashboardRepo>();
builder.Services.AddSingleton<IGiftVersion, GiftVersionRepo>();

var UploadFolderPath = builder.Configuration["UploadFolderPath"];


var app = builder.Build();

app.UseCors(x => x.AllowAnyHeader()
      .AllowAnyMethod()
      .AllowAnyOrigin());

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

//app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();
