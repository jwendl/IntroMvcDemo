using IntroMvcDemo.DataAccess.Interfaces;
using IntroMvcDemo.DataAccess.Models;
using System.Threading.Tasks;
using System.Web.Mvc;

namespace IntroMvcDemo.Controllers
{
    public class ArtistController
        : Controller
    {
        private IDataRepository<Artist> artistRepository { get; set; }

        public ArtistController(IDataRepository<Artist> artistRepository)
        {
            this.artistRepository = artistRepository;
        }

        public async Task<ActionResult> Index()
        {
            var artists = await artistRepository.FetchAllAsync(a => a.Albums);

            return View(artists);
        }

        public async Task<ActionResult> Item(int id)
        {
            var artist = await artistRepository.FindOneAsync(a => a.Id == id, a => a.Albums);

            return View(artist);
        }
    }
}
