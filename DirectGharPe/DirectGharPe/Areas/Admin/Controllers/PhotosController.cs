using DirectGharPe.Models;
using DirectGharPe.ViewModels;
using System;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace DirectGharPe.Areas.Admin.Controllers
{
    [Authorize(Roles = RoleName.Admin)]
    public class PhotosController : Controller
    {
        private readonly ApplicationDbContext _context;

        public PhotosController()
        {
            _context = new ApplicationDbContext();
        }
        
        public ActionResult Index(string id, string name)
        {
            var productId = 0;
            var photos = from p in _context.Photos
                         select p;

            if (!string.IsNullOrWhiteSpace(id))
            {
                productId = int.Parse(id);
                photos = photos.Where(p => p.ProductId == productId);
                Session["ProductId"] = productId;
            }
            else
            {
                productId = (int)Session["ProductId"];
                photos = photos.Where(p => p.ProductId == productId);
            }

            ViewBag.Title = "Manage photos for " + name;

            return View(photos.ToList());
        }

        public ActionResult New()
        {
            var viewModel = new ProductPhotoFormViewModel()
            {
                Id = 0,
                ProductId = (int)Session["ProductId"]
            };

            return View("ProductPhotoForm", viewModel);
        }

        // POST: Admin/Photos/Create
        [HttpPost]
        public ActionResult Create(ProductPhotoFormViewModel viewModel, HttpPostedFileBase PhotoUrl)
        {
            if (PhotoUrl == null)
            {
                ModelState.AddModelError("PhotoUrl", "PhotoUrl can't be blank");
                return View("ProductPhotoForm", viewModel);
            }

            if (PhotoUrl.ContentLength > 2000000)
            {
                ModelState.AddModelError("PhotoUrl", "PhotoUrl can't be more than 2Mb Size.");
                return View("ProductPhotoForm", viewModel);
            }

            string basePath = Server.MapPath("~");
            string folderPath = "Upload\\";
            string folderFullPath = basePath + "" + folderPath;
            string fillName =
                string.Format(DateTime.Now.Day + "" + DateTime.Now.Month + "" + DateTime.Now.Year + "" + DateTime.Now.Hour + "" + DateTime.Now.Minute + "" + DateTime.Now.Second + "" + Path.GetExtension(PhotoUrl.FileName));

            if (!Directory.Exists(folderFullPath))
            {
                Directory.CreateDirectory(folderFullPath);
            }

            Bitmap bmpPostedImage = new System.Drawing.Bitmap(PhotoUrl.InputStream);
            var image = ScaleImage(bmpPostedImage, 320, null);

            //PhotoUrl.SaveAs(Path.Combine(folderFullPath, fillName));
            image.Save(Path.Combine(folderFullPath, fillName));
            viewModel.PhotoUrl = folderPath + "" + fillName;

            Bitmap bmpPostedThumbImage = new System.Drawing.Bitmap(PhotoUrl.InputStream);
            var thumbImage = ScaleImage(bmpPostedThumbImage, 80, 115);

            thumbImage.Save(Path.Combine(folderFullPath, "thumb_" + fillName));
            viewModel.PhotoThumbUrl = folderPath + "thumb_" + fillName;
                        
            var photo = new Photo()
            {
                PhotoUrl = viewModel.PhotoUrl,
                PhotoThumbUrl = viewModel.PhotoThumbUrl,
                ProductId = viewModel.ProductId,
                IsActive = true,
            };

            _context.Photos.Add(photo);
            _context.SaveChanges();

            return RedirectToAction("Index", "Photos");
        }

        private static Image ScaleImage(Image image, int maxHeight, int? maxWidth)
        {
            if (!maxWidth.HasValue)
            {
                var ratio = (double)maxHeight / image.Height;
                var newWidth = (int)(image.Width * ratio);
                var newHeight = (int)(image.Height * ratio);

                var newImage = new Bitmap(newWidth, newHeight);
                using (var g = Graphics.FromImage(newImage))
                {
                    g.DrawImage(image, 0, 0, newWidth, newHeight);
                }
                return newImage;
            }
            else
            {
                var newImage = new Bitmap((int)maxWidth, maxHeight);
                using (var g = Graphics.FromImage(newImage))
                {
                    g.DrawImage(image, 0, 0, (int)maxWidth, maxHeight);
                }
                return newImage;
            }
        }
                
        public ActionResult ToggleDefault(int id)
        {
            var productId = (int)Session["ProductId"];
            var photos = _context.Photos.Where(p => p.ProductId == productId).ToList();
            for (int i = 0; i < photos.Count; i++)
            {
                photos[i].IsDefault = false;
            }
            _context.SaveChanges();

            var photo = _context.Photos.Find(id);
            photo.IsDefault = true;
            _context.SaveChanges();

            var productInDb = _context.Products.Find(productId);
            productInDb.PhotoId = id;
            _context.SaveChanges();

            return RedirectToAction("Index", "photos");
        }

        public ActionResult ToggleStatus(int id)
        {
            var photoinDb = _context.Photos.Find(id);

            if (photoinDb.IsActive)
                photoinDb.IsActive = false;
            else
                photoinDb.IsActive = true;

            _context.SaveChanges();

            return RedirectToAction("Index", "Photos");
        }
    }
}