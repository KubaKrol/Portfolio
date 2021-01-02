using System.Collections.Generic;

namespace API.Entities
{
    public class AppUser
    {
        //Entity framework finds this Id - this variable name should stay as "Id"
        public int Id { get; set; }
        public string UserName { get; set; }
        public List<AppUserRole> MyRole { get; set; }
        public List<BlogPost> MyBlogPosts { get; set; }
    }
}