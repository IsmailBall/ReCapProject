using ReCapProject.Core.DataAccess.EntityFramework;
using ReCapProject.DataAccess.Abstarct;
using ReCapProject.Entities.Concrete;
using System;
using System.Collections.Generic;
using System.Text;

namespace ReCapProject.DataAccess.Concrete.EntityFramework
{
    public class EfCustomerDal: EfEntityRepostoryBase<Customer, CarRentContext> , ICustomerDal
    {
    }
}
