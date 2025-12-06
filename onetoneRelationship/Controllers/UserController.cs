using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using onetoneRelationship.Models;
using onetoneRelationship.PaginationConfig;

namespace onetoneRelationship.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UsersController : ControllerBase
    {
        private readonly AppDbContext _context;
        public UsersController(AppDbContext context)
        {
            _context = context;
        }

        [HttpGet]
        public async Task<IEnumerable<User>> GetUsersAsync([FromQuery] PaginationParams @params)
        {
            if (HttpContext.Request.Query.TryGetValue("pageSize", out var sizeValue) && int.TryParse(sizeValue, out int parsedSize))
            {
                @params.SetPageSize(parsedSize);
            }
            var studentsQuery = _context.Users.AsQueryable();
            // Use _pageSize property instead of PageSize
            var students = await studentsQuery   //1,2,3,4,5,6,7,8,9,10 Skip(0).Take(5) -->5,6
                .Skip((@params.PageNumber - 1) * @params._pageSize)
                .Take(@params._pageSize)
                .ToListAsync();

            return students;
        }
    }
}