using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TwoOfUs.Domain.CustomModels;
using TwoOfUs.Domain.Infrastructure;
using TwoOfUs.Domain.Models;
using TwoOfUs.Domain.Models.Enums;

namespace TwoOfUs.Domain.BLL
{
    public static class CategoryBLL
    {
        private static DataAccess db = new DataAccess();

        public static List<Category> GetAll()
        {
            return db.Categories.ToList();
        }

        public static Page<CustomCategory> Search(long pageSize = 3, long pageIndex = 1, SortOrder sortOrder = SortOrder.Ascending, string keyword = "", Guid? parentId = null)
        {
            Page<CustomCategory> result = new Page<CustomCategory>();
             
            if (pageSize < 1)
            {
                pageSize = 1;
            }

            IQueryable<Category> catQuery = (IQueryable<Category>)db.Categories;

            if (parentId != null)
            {
                catQuery = catQuery.Where(c => c.ParentId == parentId.Value);
            }
            else
            {
                catQuery = catQuery.Where(c => c.ParentId == null);
            }

            if (string.IsNullOrEmpty(keyword) == false)
            {
                catQuery = catQuery.Where(c => c.Name.Contains(keyword));
            }

            long queryCount = catQuery.Count();

            int pageCount = (int)Math.Ceiling((decimal)(queryCount / pageSize));
            long mod = (queryCount % pageSize);

            if (mod > 0)
            {
                pageCount = pageCount + 1;
            }

            int skip = (int)(pageSize * (pageIndex - 1));
            List<Category> categories = new List<Category>();

            if (sortOrder == SortOrder.Ascending)
            {
                categories = catQuery.OrderBy(c => c.Name).ToList();
            }
            else
            {
                categories = catQuery.OrderByDescending(u => u.Name).ToList();
            }


            result.Items = categories
                            .Skip(skip)
                            .Take((int)pageSize)
                            .Select(c => new CustomCategory()
                            {
                                Id = c.Id,
                                Name = c.Name,
                                Timestamp = c.Timestamp,
                                ParentId = c.ParentId
                            })               
                            .ToList();
            result.PageCount = pageCount;
            result.PageSize = pageSize;
            result.QueryCount = queryCount;

            foreach(CustomCategory category in result.Items)
            {
                var children = db.Categories.Where(c => c.ParentId == category.Id);
                if(children != null)
                {
                    category.ChildCount = children.Count();
                };

                var products = db.Products.Where(p => p.CategoryId == category.Id);
                if (products != null)
                {
                    category.ProductCount = products.Count();
                };
            }
            
            return result;
        }
    }
}
