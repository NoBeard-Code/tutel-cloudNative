using AutoMapper;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
using NSubstitute;
using Tutel.EduWork.BusinessLayer.DTOs;
using Tutel.EduWork.BusinessLayer.maps;
using Tutel.EduWork.BusinessLayer.Services;
using Tutel.EduWork.Data;
using Tutel.EduWork.DataAccessLayer.Repositories;
namespace Tutel.EduWork.BusinessLayer.Test
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Testing!");

            var test = new SickLeaveServiceTest();
            var result = test.RunTest().GetAwaiter().GetResult();
            Console.WriteLine(result.Count);
        }
    }

    public class SickLeaveServiceTest
    {
        public async Task<List<SickLeaveDTO>> RunTest()
        {
            var configuration = new MapperConfiguration(cfg => { cfg.AddProfile<SickLeaveMap>(); });
            var mapper = configuration.CreateMapper();
            var logger = Substitute.For<ILogger<SickLeaveService>>();
            var options = new DbContextOptionsBuilder<ApplicationDbContext>()
                .UseSqlServer("Server=(localdb)\\mssqllocaldb;Database=aspnet-Tutel.EduWork-cac7e9af-090e-4348-b16c-2f2be0366ccb;Trusted_Connection=True;MultipleActiveResultSets=true")
                .Options;
            var context = new ApplicationDbContext(options);
            var repo = new SickLeaveRepository(context);
            var service = new SickLeaveService(repo, mapper, logger);
            return await service.GetAllAsync();
        }
    }
}
