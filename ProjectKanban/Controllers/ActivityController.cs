using Microsoft.AspNetCore.Mvc;
using ProjectKanban.Dto;
using ProjectKanban.Services.Activity;

namespace ProjectKanban.Controllers
{
    public class ActivityController : Controller
    {
        private readonly IActivityInterface _activityInterface;
        public ActivityController(IActivityInterface activityInterface)
        {
            _activityInterface = activityInterface;  
        }


        public async Task<IActionResult> Index()
        {
            var activity = await _activityInterface.BuscarAtividades();
            return View(activity);
        }

        public async Task<IActionResult> Register()
        {
            var status = await _activityInterface.BuscarStatus();

            ViewBag.Status = status;
            
            return View();
        }



        public async Task<IActionResult> SwitchCard(int id)
        {

            var activity = await _activityInterface.SwitchCard(id);

            return RedirectToAction("Index");
        }


        public async Task<IActionResult> BackCard(int id)
        {

            var activity = await _activityInterface.BackCard(id);

            return RedirectToAction("Index");
        }

        public async Task<IActionResult> Deletar(int id)
        {

            var activity = await _activityInterface.Deletar(id);

            return RedirectToAction("Index");
        }






        [HttpPost]
        public async Task<IActionResult> Register(ActivityRegisterDTO activityRegisterDTO)
        {
            if(ModelState.IsValid)
            {
                var activity = await _activityInterface.CadastrarAtividade(activityRegisterDTO);
                return RedirectToAction("Index");
            }
            else
            {
                var status = await _activityInterface.BuscarStatus();

                ViewBag.Status = status;


                return View(activityRegisterDTO);
            }
        }

    }
}
