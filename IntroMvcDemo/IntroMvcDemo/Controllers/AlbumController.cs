using IntroMvcDemo.DataAccess.Interfaces;
using IntroMvcDemo.DataAccess.Models;
using System.Threading.Tasks;
using System.Web.Mvc;

namespace IntroMvcDemo.Controllers
{
    public class AlbumController
        : Controller
    {
        private IDataRepository<Album> albumRepository { get; set; }

        public AlbumController(IDataRepository<Album> albumRepository)
        {
            this.albumRepository = albumRepository;
        }

        public async Task<ActionResult> Item(int id)
        {
            var album = await albumRepository.FindOneAsync(a => a.Id == id, a => a.Songs);

            return View(album);
        }
    }
}
