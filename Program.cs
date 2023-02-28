using Clg_Dept_Student_APIs.Services;
using Clg_Dept_Student_APIs.DBContext;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Newtonsoft.Json;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
builder.Services.AddMvc()
     .AddNewtonsoftJson(
          options => {
              options.SerializerSettings.ReferenceLoopHandling = ReferenceLoopHandling.Ignore;
          });

builder.Services.AddDbContext<ClgDeptStudentDbContext>(c => c.UseSqlServer(builder.Configuration.GetConnectionString("DefaultConnection")));
//builder.Services.AddIdentity<ApplicationUser, IdentityRole>().AddEntityFrameworkStores<ApplicationDBContext>().AddDefaultTokenProviders();
builder.Services.AddTransient<ICollegeService, CollegeService>();
builder.Services.AddTransient<IDepartmentService, DepartmentService>();
builder.Services.AddTransient<IStudentService, StudentService>();
//builder.Services.AddCors(opt =>
//{
//    opt.AddDefaultPolicy(c=>c.AddPolicy("MyPolicy",builder =>
//    {
//        builder.AllowAnyOrigin()
//        .AllowAnyHeader()
//        .AllowAnyMethod();
//    }));
//});
//builder.Services.AddCors(c => c.AddPolicy("MyPolicy", builder => {
//    builder.AllowAnyOrigin()
//    .AllowAnyMethod()
//    .AllowAnyHeader(); 
//}));
builder.Services.AddCors(p => p.AddPolicy("corspolicy", build => {
    build.WithOrigins("http://localhost:3000");
}));
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}
app.UseCors("corspolicy");
app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();
