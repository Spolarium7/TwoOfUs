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
    public static class UsersBLL
    {
        private static DataAccess db = new DataAccess();

        public static List<User> GetAll()
        {
            return db.Users.ToList();
        }
        
        public static User Find(Guid? id)
        {
            return db.Users.FirstOrDefault(u => u.Id == id);
        }
        
        public static User GetUserByUserName(string userName)
        {
            return db.Users.FirstOrDefault(u => u.UserName.ToLower() == userName.ToLower());
        }

        public static User GetDuplicateUserName(string userName, Guid? id)
        {
            return db.Users.FirstOrDefault(u => u.UserName.ToLower() == userName.ToLower()
                                            && u.Id != id
            );
        }
        
        public static User Create(User user)
        {
            db.Users.Add(user);
            db.SaveChanges();
            return user;
        }

        public static Guid? Delete(User user)
        {
            db.Users.Remove(user);
            db.SaveChanges();
            return user.Id;
        }

        public static User Update(User user)
        {
            User userRecord = db.Users.FirstOrDefault(u => u.Id == user.Id);
            if (userRecord != null)
            {
                userRecord.FirstName = user.FirstName;
                userRecord.LastName = user.LastName;
                userRecord.UserName = user.UserName;
                userRecord.Role = user.Role;
                db.SaveChanges();
            }

            return userRecord;
        }

        public static Page<User> Search(long pageSize = 3, long pageIndex = 1, UserSortOrder orderBy = UserSortOrder.UserName, SortOrder sortOrder = SortOrder.Ascending, Role? role = null, string keyword ="")
        {
            Page<User> result = new Page<User>();


            if (pageSize < 1)
            {
                pageSize = 1;
            }

            IQueryable<User> userQuery = (IQueryable<User>)db.Users;

            if(role != null)
            {
                userQuery = userQuery.Where(u => u.Role == role.Value);
            }

            if(string.IsNullOrEmpty(keyword) == false)
            {
                userQuery = userQuery.Where(u => u.FirstName.Contains(keyword) 
                                            ||   u.LastName.Contains(keyword)
                                            ||   u.UserName.Contains(keyword));
            }

            long queryCount = userQuery.Count();

            int pageCount = (int)Math.Ceiling((decimal)(queryCount / pageSize));
            long mod =(queryCount % pageSize);

            if(mod > 0)
            {
                pageCount = pageCount + 1;
            }

            int skip = (int)(pageSize * (pageIndex - 1));
            List<User> users = new List<User>();

            if (sortOrder == SortOrder.Ascending && orderBy == UserSortOrder.UserName)
            {
                users = userQuery.OrderBy(u => u.UserName).ToList();
            }
            else if (sortOrder == SortOrder.Descending && orderBy == UserSortOrder.UserName)
            {
                users = userQuery.OrderByDescending(u => u.UserName).ToList();
            }
            else if (sortOrder == SortOrder.Ascending && orderBy == UserSortOrder.FirstName)
            {
                users = userQuery.OrderBy(u => u.FirstName).ToList();
            }
            else if (sortOrder == SortOrder.Descending && orderBy == UserSortOrder.FirstName)
            {
                users = userQuery.OrderByDescending(u => u.FirstName).ToList();
            }
            else if (sortOrder == SortOrder.Ascending && orderBy == UserSortOrder.LastName)
            {
                users = userQuery.OrderBy(u => u.LastName).ToList();
            }
            else if (sortOrder == SortOrder.Descending && orderBy == UserSortOrder.LastName)
            {
                users = userQuery.OrderByDescending(u => u.LastName).ToList();
            }

            result.Items = users.Skip(skip).Take((int)pageSize).ToList();
            result.PageCount = pageCount;
            result.PageSize = pageSize;
            result.QueryCount = queryCount;

            return result;
        }
    }
}
