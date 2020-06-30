using DirectGharPe.Models;
using System.Collections.Generic;
using System.Linq;
using System.Web.Http;

namespace DirectGharPe.Areas.Admin.Controllers.Api
{
    public class PhotosController : ApiController
    {
        private readonly ApplicationDbContext _context;

        public PhotosController()
        {
            _context = new ApplicationDbContext();
        }

        [HttpGet]
        public IEnumerable<Photo> Photos()
        {
            var photos = _context.Photos.ToList();

            return photos;
        }

        [HttpGet]
        public Photo photo(int id)
        {
            var photo = _context.Photos.FirstOrDefault(p => p.Id == id);

            return photo;
        }

        [Route("Api/Photos/PhotosByProductId/{id}")]        
        [HttpGet]
        public IEnumerable<Photo> PhotosByProductId(int id)
        {
            var photos = _context.Photos
                .Where(p => p.ProductId == id)
                .ToList();

            return photos;
        }

        [HttpDelete]
        public void Deletephoto(int id)
        {
            var photo = _context.Photos.Find(id);

            _context.Photos.Remove(photo);
            _context.SaveChanges();
        }

    }
}
