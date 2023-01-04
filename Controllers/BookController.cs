using Microsoft.AspNetCore.Mvc;
using MSSA_Assignment_12._2.Services;
using MSSA_Assignment_12._2.Models;

namespace MSSA_Assignment_12._2.Controllers
{
    public class BookController : Controller
    {
        private ICRUD cRUD;
        private IFileUpload fileUpload;
        public BookController(ICRUD cRUD, IFileUpload fileUpload)
        {
            this.cRUD = cRUD;
            this.fileUpload = fileUpload;
        }
        public IActionResult Create()
        {
            var booknew = new Book();
            booknew.Id = cRUD.GetMaxID();
            return View(booknew);
        }
        [HttpPost]
        public async Task<ActionResult> Create(Book obj, IFormFile file)
        {
            if (ModelState.IsValid)
            {
                if (await fileUpload.UploadFile(file))
                {
                    obj.ImageName = fileUpload.FileName;
                    cRUD.AddBook(obj);
                    return RedirectToRoute(new { Action = "Index", Controller = "Book" });
                }
                else
                {
                    ViewBag.ErrorMessage = "File Upload failed";
                    return View(obj);
                }
            }
            ViewBag.Message = "Error adding employee";
            return View(obj);
        }
        public IActionResult About()
        {
            return View();
        }
        public IActionResult Index()
        {
            AllBooksView model = new AllBooksView();
            model.Books = cRUD.GetBooks();

            return View(model);
        }
        public IActionResult Details(int? id)
        {
            var book = cRUD.GetBook(id);
            if (book == null)
            {
                return NotFound();
            }
            return View(book);
        }
        public IActionResult Edit(int id)
        {
            var book = cRUD.GetBook(id);
            return View(book);
        }
        [HttpPost]
        public IActionResult Edit(Book obj)
        {
            if (ModelState.IsValid)
            {
                cRUD.UpdateBook(obj);
                return RedirectToAction("Index");
            }
            ViewBag.Message = "Error editing employee";
            return View(obj);
        }
        public IActionResult Delete(int id)
        {
            cRUD.DeleteBook(id);
            return RedirectToAction("Index");

        }
        public IActionResult TestBookBootstrap()
        {
            return View();
        }

    }
}
