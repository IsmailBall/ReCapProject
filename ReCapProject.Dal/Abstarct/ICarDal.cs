using ReCapProject.Core.DataAccess;
using ReCapProject.Entities.Concrete;
using ReCapProject.Entities.DTOs;
using System;
using System.Collections.Generic;
using System.Text;

namespace ReCapProject.DataAccess.Abstarct
{
    public interface ICarDal:IEntityRepostory<Car>
    {
        List<CarDetail> GetAllCarDetails();
    }
}
