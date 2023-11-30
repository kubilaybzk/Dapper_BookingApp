using System;
using Dapper;
using Dapper_Web_Api.DTOs.BottomGrid;
using Dapper_Web_Api.Models.DapperContext;
using Dapper_Web_Api.Repositorys.BottomGrid;

namespace Dapper_Web_Api.Concrete.BottomGrid
{
    public class BottomGridRepository : IBottomGridRepository
    {
        public readonly DapperContext _context;

        public BottomGridRepository(DapperContext context)
        {
            _context = context;
        }

        public async void CreateBottomGrid(CreateBottomGridDTOs createBottomGridDto)
        {

            string query = "insert into BottomGrid (Icon,Title,Description,GoToLink) values(@Icon,@Title,@Description,@GoToLink)";

            var parameters = new DynamicParameters();

            parameters.Add("Icon", createBottomGridDto.Icon);

            parameters.Add("Title", createBottomGridDto.Title);

            parameters.Add("Description", createBottomGridDto.Description);

            parameters.Add("GoToLink", createBottomGridDto.GoToLink);

            using(var connection = _context.CreateConnection())
            {
                await connection.ExecuteAsync(query, parameters);
            }
        }

        public async void DeleteBottomGrid(int id)
        {
            string query = "Delete from BottomGrid where BottomGridID=@BottomGridID";

            var parameters = new DynamicParameters();

            parameters.Add("BottomGridID", id);

            using (var connection = _context.CreateConnection())
            {
                await connection.ExecuteAsync(query,parameters);
            }



        }

        public async Task<List<ResultBottomGridDTOs>> GetAllBottomGridAsync()
        {
            string query = "select * from BottomGrid";
            using (var connection = _context.CreateConnection())
            {
                var values = await connection.QueryAsync<ResultBottomGridDTOs>(query);
                return values.ToList();
            }


        }

        public async Task<GetByIdBottomGridDTOs> GetBottomGridById(int id)
        {
            string query = "select * from BottomGrid where BottomGridID=@BottomGridID ";
            var parameters = new DynamicParameters();
            parameters.Add("BottomGridID", id);

            using (var connection = _context.CreateConnection())
            {
                var values = await connection.QueryFirstAsync<GetByIdBottomGridDTOs>(query,parameters);
                return values;
            }
        }

        public async void UpdateBottomGrid(UpdateBottomGridDTOs updateBottomGridDto)
        {
            string query = "Update BottomGrid Set Icon=@Icon,Title=@Title,Description=@Description,GoToLink=@GoToLink where BottomGridID=@BottomGridID";

            var parameters = new DynamicParameters();

            parameters.Add("@BottomGridID", updateBottomGridDto.BottomGridID);
            parameters.Add("@Title", updateBottomGridDto.Title);
            parameters.Add("@Icon", updateBottomGridDto.Icon);
            parameters.Add("@Description", updateBottomGridDto.Description);
            parameters.Add("@GoToLink", updateBottomGridDto.GoToLink);


            using (var connectiont = _context.CreateConnection())
            {
                await connectiont.ExecuteAsync(query, parameters);
            }
        }
    }
}

