using Microsoft.EntityFrameworkCore;
using ReCapProject.DataAccess.Abstarct;
using ReCapProject.Entities.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;

namespace ReCapProject.DataAccess.Concrete.EntityFramework
{
    public class EfColorDal : IColorDal
    {
        public void Add(Color entity)
        {
            using (CarRentContext context = new CarRentContext())
            {
                var addedBrand = context.Entry(entity);
                addedBrand.State = EntityState.Added;
                context.SaveChanges();
            }
        }

        public void Delete(Color entity)
        {
            using (CarRentContext context = new CarRentContext())
            {
                var deletedBrand = context.Entry(entity);
                deletedBrand.State = EntityState.Deleted;
                context.SaveChanges();
            }
        }

        public Color Get(Expression<Func<Color, bool>> filter)
        {
            using (CarRentContext context = new CarRentContext())
            {
                return context.Set<Color>().SingleOrDefault(filter);
            }
        }

        public List<Color> GetAll(Expression<Func<Color, bool>> filter = null)
        {
            using (CarRentContext context = new CarRentContext())
            {
                return filter == null ?
                    context.Set<Color>().ToList() :
                    context.Set<Color>().Where(filter).ToList();
            }
        }

        public void Update(Color entity)
        {
            using (CarRentContext context = new CarRentContext())
            {
                var updatedBrand = context.Entry(entity);
                updatedBrand.State = EntityState.Modified;
                context.SaveChanges();
            }
        }
    }
}
