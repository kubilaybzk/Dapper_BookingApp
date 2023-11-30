using System;
using Dapper;
using Dapper_Web_Api.DTOs.WhoWeAre;
using Dapper_Web_Api.Models.DapperContext;
using Dapper_Web_Api.Repositorys;

namespace Dapper_Web_Api.Concrete.WhoWeAre
{
    public class WhoWeAreRepository : IWhoWeAreRepository
    {


        public readonly DapperContext _context;

        public WhoWeAreRepository(DapperContext context)
        {
            _context = context;
        }

        public async void CreateWhoWeAre(CreateWhoWeAreDTO createWhoWeAreDetailDto)
        {
            string query = "insert into WhoWeAre (Title,Subtitle,Description,Description2) values (@title,@subTitle,@description,@description2)";
            var parameters = new DynamicParameters();
            parameters.Add("@title", createWhoWeAreDetailDto.Title);
            parameters.Add("@subTitle", createWhoWeAreDetailDto.Subtitle);
            parameters.Add("@description", createWhoWeAreDetailDto.Description);
            parameters.Add("@description2", createWhoWeAreDetailDto.Description2);
            using (var connection = _context.CreateConnection())
            {
                await connection.ExecuteAsync(query, parameters);
            }
        }

        public async void DeleteWhoWeAre(int id)
        {
            string query = "Delete From WhoWeAre Where WhoWeAreDetailID=@whoWeAreID";
            var parameters = new DynamicParameters();
            parameters.Add("@whoWeAreID", id);
            using (var connection = _context.CreateConnection())
            {
                await connection.ExecuteAsync(query, parameters);
            }
        }

        public async Task<List<ResultWhoWeAreDTO>> GetAllWhoWeAreAsync()
        {
            string query = "Select * From WhoWeAre";
            using (var connection = _context.CreateConnection())
            {
                var values = await connection.QueryAsync<ResultWhoWeAreDTO>(query);
                return values.ToList();
            }
        }

        public async Task<ResultWhoWeAreDTO> GetWhoWeAre(int id)
        {
            string getElement = "Select * from WhoWeAre where WhoWeAreDetailID=@whoWeAreDetailID ";
            var parametersFirst = new DynamicParameters();
            parametersFirst.Add("@whoWeAreDetailID", id);

            using (var connection = _context.CreateConnection())
            {
                var values = await connection.QueryFirstOrDefaultAsync<ResultWhoWeAreDTO>(getElement, parametersFirst);
                return values;
            }

        }

        public async void UpdateWhoWeAre(UpdateWhoWeAre updateWhoWeAreDetailDto)
        {



            string query = "Update WhoWeAre Set Title=@title, Subtitle=@subTitle, Description=@description, Description2=@description2 where WhoWeAreDetailID=@whoWeAreDetailID";
            var parameters = new DynamicParameters();

            // Sadece null olmayan değerleri parametrelere ekle
            if (updateWhoWeAreDetailDto.Title != null)
                parameters.Add("@title", updateWhoWeAreDetailDto.Title);

            if (updateWhoWeAreDetailDto.Subtitle != null)
                parameters.Add("@Subtitle", updateWhoWeAreDetailDto.Subtitle);

            if (updateWhoWeAreDetailDto.Description != null)
                parameters.Add("@description", updateWhoWeAreDetailDto.Description);

            if (updateWhoWeAreDetailDto.Description2 != null)
                parameters.Add("@description2", updateWhoWeAreDetailDto.Description2);

            parameters.Add("@whoWeAreDetailID", updateWhoWeAreDetailDto.WhoWeAreDetailID);

            using (var connectiont = _context.CreateConnection())
            {
                await connectiont.ExecuteAsync(query, parameters);
            }

        }
    }
}

