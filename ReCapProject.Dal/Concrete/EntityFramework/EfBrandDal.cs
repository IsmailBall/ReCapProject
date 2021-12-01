using Microsoft.EntityFrameworkCore;
using ReCapProject.Core.DataAccess.EntityFramework;
using ReCapProject.DataAccess.Abstarct;
using ReCapProject.Entities.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;

namespace ReCapProject.DataAccess.Concrete.EntityFramework
{
    public class EfBrandDal : EfEntityRepostoryBase<Brand,CarRentContext>,IBrandDal
    {
        
    }
}
