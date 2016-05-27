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
            var artist = await artistRepository.FetchAsync(1);

            return View(artist);
        }
    }
}
