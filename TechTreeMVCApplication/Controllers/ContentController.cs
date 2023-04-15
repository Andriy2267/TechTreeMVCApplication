using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;
using TechTreeMVCApplication.Data;
using TechTreeMVCApplication.Entities;
using System.Linq;
using Microsoft.EntityFrameworkCore;

namespace TechTreeMVCApplication.Controllers
{
    public class ContentController : Controller
    {
        private readonly ApplicationDbContext _context;
        public ContentController(ApplicationDbContext context)
        {
            _context = context;
        }
        public async Task<IActionResult> Index(int categoryItemId)
        {
            Content content = await (from item in _context.Content
                                     where item.CategoryItem.Id == categoryItemId
                                     select new Content
                                     {
                                         Title = item.Title,
                                         VideoLink = item.VideoLink,
                                         HTMLContent = item.HTMLContent
                                     }).FirstOrDefaultAsync();
            return View(content);
        }
    }
}
