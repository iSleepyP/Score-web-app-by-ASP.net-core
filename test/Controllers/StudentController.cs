using Microsoft.AspNetCore.Mvc;
using System.Security.Cryptography;
using test.Data;
using test.Models;

namespace test.Controllers
{
    public class StudentController : Controller
    {
        private readonly ApplicationDBContext _db;

        public StudentController(ApplicationDBContext db)
        {
            _db = db;
        }
        public IActionResult Index()
        {
            /*Student s1= new Student();
            s1.Id = 1;
            s1.Name = "Pon";
            s1.Score = 100;

            var s2 = new Student();
            s2.Id = 2;
            s2.Name = "Ploy";
            s2.Score = 100;

            Student s3 = new();
            s3.Id = 3;
            s3.Name = "NamPeung";
            s3.Score = 100;

            Student s4 = new();
            s4.Id = 4;
            s4.Name = "Somebody";
            s4.Score = 47;

            List<Student> alls = new List<Student>();
            alls.Add(s1);
            alls.Add(s2);
            alls.Add(s3);
            alls.Add(s4);*/

            IEnumerable< Student > allStudent = _db.Students;

            return View(allStudent);
        }
        public IActionResult Create() 
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Create(Student obj)
        {
            if(ModelState.IsValid) //check range of score
            { 
            _db.Students.Add(obj);
            _db.SaveChanges();
            return RedirectToAction("Index");
            }
            return View(obj);
        }

        public IActionResult About()
        {
            return View();
        }

        public IActionResult Edit(int? id)
        {
            if(id==null || id == 0)
            {
                return NotFound();
            }
            
           var obj = _db.Students.Find(id);
           
            if(obj==null)
            {
                return NotFound();
            }
            return View(obj);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Edit(Student obj)
        {
            if (ModelState.IsValid) //check range of score
            {
                _db.Students.Update(obj);
                _db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(obj);
        }

        public IActionResult Del(int? id)
        {
            if (id == null || id == 0)
            {
                return NotFound();
            }

            var obj = _db.Students.Find(id);

            if (obj == null)
            {
                return NotFound();
            }

            _db.Students.Remove(obj);
            _db.SaveChanges();
            return RedirectToAction("Index");
        }

        /*public IActionResult ShowScore(int id)
        {
            return Content($"Score of student id {id} = ");
        }*/
    }
}
