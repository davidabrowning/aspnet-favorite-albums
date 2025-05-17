using ASPNETFavoriteAlbums.Data;
using ASPNETFavoriteAlbums.Models;
using ASPNETFavoriteAlbums.ViewModels;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace ASPNETFavoriteAlbums.Controllers
{
    public class AlbumController : Controller
    {
        private readonly IAlbum _albumRepository;
        private readonly ITag _tagRepository;
        public AlbumController(IAlbum albumRepository, ITag tagRepository)
        {
            _albumRepository = albumRepository;
            _tagRepository = tagRepository;
        }
        // GET: AlbumController
        public ActionResult Index()
        {
            AlbumIndexViewModel albumIndexViewModel = new()
            {
                Albums = _albumRepository.GetAll(),
                Tags = _tagRepository.GetAll()
            };
            return View(albumIndexViewModel);
        }

        // GET: AlbumController/Details/5
        public ActionResult Details(int id)
        {
            return View(_albumRepository.GetById(id));
        }

        // GET: AlbumController/Create
        public ActionResult Create()
        {
            AlbumCreateViewModel albumCreateViewModel = new()
            {
                AllTags = _tagRepository.GetAll()
            };
            return View(albumCreateViewModel);
        }

        // POST: AlbumController/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(AlbumCreateViewModel albumCreateViewModel)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    Album album = albumCreateViewModel.Album;
                    IEnumerable<int> selectedTagIds = albumCreateViewModel.SelectedTagIds;
                    List<Tag> selectedTags = _tagRepository.GetAll().Where(t => selectedTagIds.Contains(t.Id)).ToList();
                    album.Tags = selectedTags;
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
            AlbumEditViewModel albumEditViewModel = new()
            {
                Album = _albumRepository.GetById(id),
                AllTags = _tagRepository.GetAll()
            };
            return View(albumEditViewModel);
        }

        // POST: AlbumController/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(AlbumEditViewModel albumEditViewModel)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    Album formAlbum = albumEditViewModel.Album;
                    Album album = _albumRepository.GetById(formAlbum.Id);
                    album.Name = formAlbum.Name;
                    album.Artist = formAlbum.Artist;
                    album.AlbumImageURL = formAlbum.AlbumImageURL;
                    IEnumerable<Tag> allTags = _tagRepository.GetAll().ToList();
                    IEnumerable<int> selectedTagIds = albumEditViewModel.SelectedTagIds.ToList();
                    IEnumerable<Tag> selectedTags = allTags.Where(t => selectedTagIds.Contains(t.Id)).ToList();
                    IEnumerable<Tag> oldTags = album.Tags.ToList();
                    IEnumerable<Tag> tagsToAdd = selectedTags.Except(oldTags).ToList();
                    IEnumerable<Tag> tagsToRemove = oldTags.Except(selectedTags).ToList();
                    foreach (Tag tag in tagsToAdd)
                    {
                        album.Tags.Add(tag);
                    }
                    foreach (Tag tag in tagsToRemove)
                    {
                        album.Tags.Remove(tag);
                    }
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
