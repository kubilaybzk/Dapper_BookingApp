using System;
using Dapper_Web_Api.DTOs.BottomGrid;

namespace Dapper_Web_Api.Repositorys.BottomGrid
{
	public interface IBottomGridRepository
	{
        Task<List<ResultBottomGridDTOs>> GetAllBottomGridAsync();
        void CreateBottomGrid(CreateBottomGridDTOs createBottomGridDto);
        void DeleteBottomGrid(int id);
        void UpdateBottomGrid(UpdateBottomGridDTOs updateBottomGridDto);
        Task<GetByIdBottomGridDTOs> GetBottomGridById(int id);
    }
}

