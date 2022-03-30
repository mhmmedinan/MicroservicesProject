using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Course.Core.Utilities.Results;
using Services.Discount.Models;

namespace Services.Discount.Services
{
    public interface IDiscountService
    {
        IDataResult<List<Models.Discount>> GetAll();

        IDataResult<Models.Discount> GetById(int id);
        IResult Save(Models.Discount discount);
        IResult Update(Models.Discount discount);
        IResult Delete(int id);
        IDataResult<Models.Discount> GetByCodeAndUserId(string code,string userId);


    }
}
