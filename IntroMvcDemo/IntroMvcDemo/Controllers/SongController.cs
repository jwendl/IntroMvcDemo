using IntroMvcDemo.DataAccess.Interfaces;
using IntroMvcDemo.DataAccess.Models;
using System.Threading.Tasks;
using System.Web.Mvc;

namespace IntroMvcDemo.Controllers
{
    public class SongController
        : Controller
    {
        private IDataRepository<Song> songRepository { get; set; }

        public SongController(IDataRepository<Song> songRepository)
        {
            this.songRepository = songRepository;
        }

        public async Task<ActionResult> Item(int id)
        {
            var song = await songRepository.FindOneAsync(s => s.Id == id, s => s.Album, s => s.Album.Artist);

            return View(song);
        }

        [HttpGet]
        public async Task<ActionResult> Edit(int id)
        {
            var song = await songRepository.FindOneAsync(s => s.Id == id, s => s.Album, s => s.Album.Artist);

            return View(song);
        }

        [HttpPost]
        public async Task<ActionResult> Edit(int id, Song song)
        {
            var songFromDatabase = await songRepository.FindOneAsync(s => s.Id == id);
            var updateSuccess = TryUpdateModel(songFromDatabase);
            await songRepository.UpdateAsync(songFromDatabase, id);

            if (updateSuccess)
            {
                return RedirectToAction("Item", new { id = id });
            }

            return View(song);
        }
    }
}
