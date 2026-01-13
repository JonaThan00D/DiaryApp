using DiaryApp.Data;
using DiaryApp.Models;
using DiaryApp.Services;
using Microsoft.AspNetCore.Mvc;
namespace DiaryApp.Controllers
{
    public class DiaryEntriesController : Controller
    {
        private readonly ApplicationDbContext _db;
        private readonly DiaryEntryService _diaryService;

        //constructor
        public DiaryEntriesController(ApplicationDbContext db, DiaryEntryService diaryService)
        {
            _db = db;
            _diaryService = diaryService;
        }

        public IActionResult Index()
        {
            List<DiaryEntry> objDiaryEntryList = _diaryService.GetAll();
            return View(objDiaryEntryList);
        }

        public IActionResult Create()
        {
            return View();
        }

        [HttpPost]
        public IActionResult Create(DiaryEntry obj)
        {
            //Server side validations
            if (obj != null && obj.Title.Length < 3) {
                ModelState.AddModelError("Title", "The title lengh is too short!");
            }

            if (ModelState.IsValid)
            {
                _diaryService.Create(obj);
                return RedirectToAction("Index");
            }

            return View(obj);
        }

        [HttpGet]
        public IActionResult Edit(Guid id) {

            if(id == null || id == Guid.Empty)
            {
                return NotFound();
            }
            DiaryEntry? diaryEntry = _diaryService.GetById(id);

            if (diaryEntry == null)
            {
                return NotFound();
            }
            return View(diaryEntry);
        }

        [HttpPost]
        public IActionResult Edit(DiaryEntry obj)
        {
            //Server side validations
            if (obj != null && obj.Title.Length < 3)
            {
                ModelState.AddModelError("Title", "The title lengh is too short!");
            }

            if (ModelState.IsValid)
            {
                _diaryService.Update(obj);
                return RedirectToAction("Index");
            }

            return View(obj);
        }

        [HttpGet]
        public IActionResult Delete(Guid id)
        {

            if (id == null || id == Guid.Empty)
            {
                return NotFound();
            }
            DiaryEntry? diaryEntry = _diaryService.GetById(id);

            if (diaryEntry == null)
            {
                return NotFound();
            }
            return View(diaryEntry);
        }

        [HttpPost]
        public IActionResult Delete(DiaryEntry obj)
        {


                _diaryService.Delete(obj);
                return RedirectToAction("Index");
        }
     }
 }
