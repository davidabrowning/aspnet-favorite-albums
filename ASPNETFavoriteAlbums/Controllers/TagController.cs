using ASPNETFavoriteAlbums.Data;
using ASPNETFavoriteAlbums.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace ASPNETFavoriteAlbums.Controllers
{
    public class TagController : Controller
    {
        ITag _tagRepository;
        public TagController(ITag tagRepository)
        {
            _tagRepository = tagRepository;
        }
        // GET: TagController
        public ActionResult Index()
        {
            return View(_tagRepository.GetAll());
        }

        // GET: TagController/Details/5
        public ActionResult Details(int id)
        {
            return View(_tagRepository.GetById(id));
        }

        // GET: TagController/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: TagController/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(Tag tag)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    _tagRepository.Add(tag);
                }
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }

        // GET: TagController/Edit/5
        public ActionResult Edit(int id)
        {
            return View(_tagRepository.GetById(id));
        }

        // POST: TagController/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(Tag tag)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    _tagRepository.Update(tag);
                }
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }

        // GET: TagController/Delete/5
        public ActionResult Delete(int id)
        {
            return View(_tagRepository.GetById(id));
        }

        // POST: TagController/Delete/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Delete(Tag tag)
        {
            try
            {
                _tagRepository.Delete(tag.Id);
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }
    }
}
