using System;
using Dapper_Web_Api.DTOs.WhoWeAreServices;

namespace Dapper_Web_Api.Repositorys.WhoWeAre
{
	public interface IWhoWeAreServicesRepository
	{

        Task<List<ResultWhoWeAreServicesDTOs>> GetAllWhoWeAreServicesAsync();
        void CreateWhoWeAreServices(CreateWhoWeAreServicesDTOs createWhoWeAreServicesDTOs);
        void DeleteWhoWeAreServices(int id);
        void UpdateWhoWeAreServices(UpdateWhoWeAreServicesDTOs updateWhoWeAreServicesDTOs);
        Task<GetByIDWhoWeAreServicesDTOs> GetByIDWhoWeAreServices(int id);
    }
}

