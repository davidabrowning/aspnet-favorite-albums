using ASPNETFavoriteAlbums.Data;
using ASPNETFavoriteAlbums.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace ASPNETFavoriteAlbums.Controllers
{
    public class AlbumController : Controller
    {
        private readonly IAlbum _albumRepository;
        public AlbumController(IAlbum albumRepository)
        {
            _albumRepository = albumRepository;
        }
        // GET: AlbumController
        public ActionResult Index()
        {
            return View(_albumRepository.GetAll());
        }

        // GET: AlbumController/Details/5
        public ActionResult Details(int id)
        {
            return View(_albumRepository.GetById(id));
        }

        // GET: AlbumController/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: AlbumController/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(Album album)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    _albumRepository.Add(album);
                }
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }

        // GET: AlbumController/Edit/5
        public ActionResult Edit(int id)
        {
            return View(_albumRepository.GetById(id));
        }

        // POST: AlbumController/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(Album album)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    _albumRepository.Update(album);
                }
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }

        // GET: AlbumController/Delete/5
        public ActionResult Delete(int id)
        {
            return View(_albumRepository.GetById(id));
        }

        // POST: AlbumController/Delete/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Delete(Album album)
        {
            try
            {
                _albumRepository.Delete(album.Id);
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }
    }
}
