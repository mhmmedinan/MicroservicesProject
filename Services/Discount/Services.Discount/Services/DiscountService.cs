using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Threading.Tasks;
using Course.Core.Utilities.Results;
using Dapper;
using Microsoft.Extensions.Configuration;
using Npgsql;

namespace Services.Discount.Services
{
    public class DiscountService:IDiscountService
    {
        private readonly IConfiguration _configuration;
        private readonly IDbConnection _dbConnection;

        public DiscountService(IConfiguration configuration)
        {
            _configuration = configuration;

            _dbConnection = new NpgsqlConnection(_configuration.GetConnectionString("PostgreSql"));
        }
        public IDataResult<List<Models.Discount>> GetAll()
        {
            var discounts = _dbConnection.Query<Models.Discount>("Select * from discount");
            return new SuccessDataResult<List<Models.Discount>>(discounts.ToList(),"Success");
        }

        public IDataResult<Models.Discount> GetById(int id)
        {
            var discount = _dbConnection.Query<Models.Discount>("Select * from discount where id=@Id",new{Id=id}).SingleOrDefault();
            if (discount==null)
            {
                return new ErrorDataResult<Models.Discount>("Discount not fount");
            }

            return new SuccessDataResult<Models.Discount>(discount,"Success");
        }

        public IResult Save(Models.Discount discount)
        {
            var saveStatus = _dbConnection.Execute("INSERT INTO discount(userid,rate,code)VALUES(@UserId,@Rate,@Code)",
                discount);
            return new SuccessResult("Success");
        }

        public IResult Update(Models.Discount discount)
        {
            var updateStatus = _dbConnection.Execute(
                "Update discount set userid=@UserId,code=@Code,rate=@Rate where id=@Id", new
                {
                    Id = discount.Id,
                    UserId = discount.UserId,
                    Code = discount.Code,
                    Rate = discount.Rate
                });
            return new SuccessResult("Updated");
        }

        public IResult Delete(int id)
        {
            var deleteStatus = _dbConnection.Execute("delete from discount where id=@Id", new {Id = id});
            return new SuccessResult("Deleted");
        }

        public IDataResult<Models.Discount> GetByCodeAndUserId(string code, string userId)
        {
            var discounts = _dbConnection.Query<Models.Discount>(
                "Select * from discount where userid=@UserId and code=@Code", new
                {
                    UserId = userId, Code = code
                });
            var hasDiscount = discounts.FirstOrDefault();
            if (hasDiscount==null)
            {
                return new ErrorDataResult<Models.Discount>("Discount not fount");
            }

            return new SuccessDataResult<Models.Discount>(hasDiscount, "Success");
        }
    }
}
