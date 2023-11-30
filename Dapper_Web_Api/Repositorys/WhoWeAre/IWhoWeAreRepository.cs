using System;
using Dapper_Web_Api.DTOs.WhoWeAre;


namespace Dapper_Web_Api.Repositorys
{
	public interface IWhoWeAreRepository
	{


        Task<List<ResultWhoWeAreDTO>> GetAllWhoWeAreAsync();
        void CreateWhoWeAre(CreateWhoWeAreDTO createWhoWeAreDetailDto);
        void DeleteWhoWeAre(int id);
        void UpdateWhoWeAre(UpdateWhoWeAre updateWhoWeAreDetailDto);
        Task<ResultWhoWeAreDTO> GetWhoWeAre(int id);
    }
}

