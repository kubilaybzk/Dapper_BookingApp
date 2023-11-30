using System;
using System.Linq;
using Dapper;
using Dapper_Web_Api.DTOs.WhoWeAre;
using Dapper_Web_Api.DTOs.WhoWeAreServices;
using Dapper_Web_Api.Models.DapperContext;
using Dapper_Web_Api.Repositorys.WhoWeAre;

namespace Dapper_Web_Api.Concrete
{
    public class WhoWeAreServicesRepositoy : IWhoWeAreServicesRepository
    {

        public readonly DapperContext _context;

        public WhoWeAreServicesRepositoy(DapperContext context)
        {
            _context = context;
        }

        public async void CreateWhoWeAreServices(CreateWhoWeAreServicesDTOs createWhoWeAreServicesDTOs)
        {
            string query = "insert into WhoWeAreServices (ServicesName,ServiceStatus) values (@ServicesName,@ServiceStatus)";
            var parameters = new DynamicParameters();
            parameters.Add("ServicesName", createWhoWeAreServicesDTOs.ServicesName);
            parameters.Add("ServiceStatus", createWhoWeAreServicesDTOs.ServiceStatus);
            using (var connection = _context.CreateConnection())
            {
                await connection.ExecuteAsync(query, parameters);
            }
        }

        public async void DeleteWhoWeAreServices(int id)
        {
            string query = "Delete From WhoWeAreServices Where WhoWeAreServiceID=@id";
            var parameters = new DynamicParameters();
            parameters.Add("@id", id);
            using (var connection = _context.CreateConnection())
            {
                await connection.ExecuteAsync(query, parameters);
            }
        }

        public async Task<List<ResultWhoWeAreServicesDTOs>> GetAllWhoWeAreServicesAsync()
        {
            string query = "Select * From WhoWeAreServices";
            using (var connection = _context.CreateConnection())
            {
                var values = await connection.QueryAsync<ResultWhoWeAreServicesDTOs>(query);
                return values.ToList();
            }
        }

        public async Task<GetByIDWhoWeAreServicesDTOs> GetByIDWhoWeAreServices(int id)
        {
            string query = "Select * From WhoWeAreServices where WhoWeAreServiceID=@WhoWeAreServiceID ";
            var parameter = new DynamicParameters();
            parameter.Add("WhoWeAreServiceID", id);
            using (var connection = _context.CreateConnection())
            {
                var values = await connection.QueryFirstOrDefaultAsync<GetByIDWhoWeAreServicesDTOs>(query,parameter);
                return values;
            }
        }

        public async void UpdateWhoWeAreServices(UpdateWhoWeAreServicesDTOs updateWhoWeAreDetailDto)
        {
            string query = "Update WhoWeAreServices Set ServicesName=@ServicesName, ServiceStatus=@ServiceStatus  Where WhoWeAreServiceID=@WhoWeAreServiceID";
    
            var parameters = new DynamicParameters();

            // Sadece null olmayan değerleri parametrelere ekle


            if (updateWhoWeAreDetailDto.ServicesName != null)
                parameters.Add("@ServicesName", updateWhoWeAreDetailDto.ServicesName);

            if (updateWhoWeAreDetailDto.ServiceStatus != null)
                parameters.Add("@ServiceStatus", updateWhoWeAreDetailDto.ServiceStatus);

            

            parameters.Add("@WhoWeAreServiceID", updateWhoWeAreDetailDto.WhoWeAreServiceID);

            using (var connectiont = _context.CreateConnection())
            {
                await connectiont.ExecuteAsync(query, parameters);
            }
        }
    }
}

