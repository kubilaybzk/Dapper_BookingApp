using System;
using Dapper_Web_Api.DTOs;
using Dapper_Web_Api.Models.DapperContext;
using Dapper_Web_Api.Repositorys;
using Dapper;

namespace Dapper_Web_Api.Concrete
{
    public class CategoryRepository : ICategoryRepository
    {

        public readonly DapperContext _context;

        public CategoryRepository(DapperContext context)
        {
            _context = context;
        }



        public async Task<List<ResultCategoryDTO>> GetAllCategoryAsync()
        {
            //Genel olarak SQL üzerinden çalışmalar gerçekleştiriliyor.
            //SQL sorgusu QueryAsync üzerinden  sorgulanarak gelen veriler kullanıcıya dönülür.

            var query = "Select * from Category";

            var conncection = _context.CreateConnection();

            var categorys = await conncection.QueryAsync<ResultCategoryDTO>(query);

            return categorys.ToList();


        }

        //Tek bir ürün alma ve listeleme.
        public async Task<ResultCategoryDTO> GetByIdCategory(int id)
        {
            var query = "Select * from Category Where CategoryID=@CategoryID";
            var parameter = new DynamicParameters();
            parameter.Add("CategoryID", id);

            try
            {
                using (var connection = _context.CreateConnection())
                {
                    var category = await connection.QueryFirstOrDefaultAsync<ResultCategoryDTO>(query, parameter);

                    return category;

                }
            }
            catch (Exception ex)
            {
                throw new Exception("Ürün Bulunamadı");
            }



        }


        public async Task<bool> CreateOneCategory(CreateCategoryDTO createCategoryDTO)
        {
            var query = "INSERT INTO Category(CategoryName, CategoryStatus) VALUES (@CategoryName, @CategoryStatus)";

            // Query içine parametreleri yollamak için,
            var parameters = new DynamicParameters();
            parameters.Add("@CategoryName", createCategoryDTO.CategoryName);
            parameters.Add("@CategoryStatus", createCategoryDTO.CategoryStatus);

            try
            {
                // Gerekli olan ekleme işlemini execute etmek için kullanılan yöntem.
                using (var connection = _context.CreateConnection())
                {
                    var result = await connection.ExecuteAsync(query, parameters);
                    return result == 1;
                }
            }
            catch (Exception ex)
            {
                throw new Exception("Ekleme işlemi başarısız", ex);
            }
        }

        //Burada başka bir yöntem ile parametre yollamayı görelim.

        public async Task<bool> DeleteCategory(int id)
        {
            var query = "delete from Category where CategoryID = @id";
           

            try
            {
               // Gerekli olan ekleme işlemini execute etmek için kullanılan yöntem.
               using (var connection = _context.CreateConnection())
               {
                   //Parametre için ekstra bir DynamicParameters objesi oluşturmaya gerek yok.
                    var result = await connection.ExecuteAsync(query, new {id});
                    return result == 1;
               }

            }
            catch (Exception ex)
            {
                throw new Exception("Silme işlemi başarısız", ex);
            }


        }


        public async Task<bool> UpdateCategory(UpdateCategoryDTO updateCategoryDTO)
        {
            var query = "update Category Set CategoryName=@CategoryName ,CategoryStatus=@CategoryStatus where CategoryID=@CategoryID";

            var paramaters = new DynamicParameters();

            paramaters.Add("CategoryName", updateCategoryDTO.CategoryName);

            paramaters.Add("CategoryStatus", updateCategoryDTO.CategoryStatus);

            paramaters.Add("CategoryID", updateCategoryDTO.CategoryID);

            using (var connection = _context.CreateConnection())
            {
                //Parametre için ekstra bir DynamicParameters objesi oluşturmaya gerek yok.
                var result = await connection.ExecuteAsync(query, paramaters);
                return result == 1;
            }

        }
    }
}

