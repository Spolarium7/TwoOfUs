using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TwoOfUs.Domain.Infrastructure;
using TwoOfUs.Domain.Models;
using TwoOfUs.Domain.Models.Enums;

namespace TwoOfUs.Domain.BLL
{
    public class ProductBLL : BaseModel
    {
        private static DataAccess db = new DataAccess();

        public static List<Product> GetAll()
        {
            return db.Products.ToList();
        }

        public static Page<Product> Search(long pageSize = 3, long pageIndex = 1, SortOrder sortOrder = SortOrder.Ascending, string keyword = "", Guid? categoryId = null)
        {
            Page<Product> result = new Page<Product>();

            if (pageSize < 1)
            {
                pageSize = 1;
            }

            IQueryable<Product> prodQuery = (IQueryable<Product>)db.Products;

            if (categoryId != null)
            {
                prodQuery = prodQuery.Where(c => c.CategoryId == categoryId.Value);
            }
            else
            {
                return result;
            }

            if (string.IsNullOrEmpty(keyword) == false)
            {
                prodQuery = prodQuery.Where(c => c.Name.Contains(keyword));
            }

            long queryCount = prodQuery.Count();

            int pageCount = (int)Math.Ceiling((decimal)(queryCount / pageSize));
            long mod = (queryCount % pageSize);

            if (mod > 0)
            {
                pageCount = pageCount + 1;
            }

            int skip = (int)(pageSize * (pageIndex - 1));
            List<Product> products = new List<Product>();

            if (sortOrder == SortOrder.Ascending)
            {
                products = prodQuery.OrderBy(c => c.Name).ToList();
            }
            else
            {
                products = prodQuery.OrderByDescending(u => u.Name).ToList();
            }


            result.Items = products.Skip(skip).Take((int)pageSize).ToList();
            result.PageCount = pageCount;
            result.PageSize = pageSize;
            result.QueryCount = queryCount;

            return result;
        }
    }
}
