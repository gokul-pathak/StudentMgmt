using Infomax.Models;
using Infomax.Services;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace StudentMgmt.Pages.Students
{
    public class EditModel : PageModel
    {
        private readonly IStudentRepository _studentRepository;
        private readonly IWebHostEnvironment webHostEnvironment;
        [BindProperty]
        public Student Student { get; set; }

        [BindProperty]
        public IFormFile? Photo { get; set; }

        [BindProperty]
        public bool Notify { get; set; }

        [TempData]
        public string Message { get; set; }

        public EditModel(IStudentRepository studentRepository, IWebHostEnvironment webHostEnvironment)
        {
            _studentRepository = studentRepository;
            this.webHostEnvironment = webHostEnvironment;
        }
        public IActionResult OnGet(int? id)
        {
            if(id.HasValue)
            {
                Student = _studentRepository.GetStudent(id.Value);
            }
            else
            {
                Student = new Student();
                Student.PhotoPath = "none";
            }
            if(Student == null)
            {
                return RedirectToPage("/404");
            }
            return Page();
            Student = _studentRepository.GetStudent(id.Value);
        }
        public IActionResult OnPost(Student Student)
        {
            if (ModelState.IsValid)
            {

                if (Photo != null)
                {
                    // If a new photo is uploaded, the existing photo must be
                    // deleted. So check if there is an existing photo and delete
                    if (Student.PhotoPath != null)
                    {
                        string filePath = Path.Combine(webHostEnvironment.WebRootPath,
                            "images", Student.PhotoPath);
                        System.IO.File.Delete(filePath);
                    }
                    // Save the new photo in wwwroot/images folder and update
                    // PhotoPath property of the Student object
                    Student.PhotoPath = ProcessUploadedFile();
                }
                if (Student.Id > 0)
                {
                    Student = _studentRepository.Update(Student);

                }
                else
                {
                    if (Student.PhotoPath == "none")
                    {
                        ModelState.AddModelError(string.Empty, "Please select your thopda");
                        return Page();
                    }
                    Student = _studentRepository.Add(Student);
                }
                Student = _studentRepository.Update(Student);
                return RedirectToPage("Index");
            }
            return Page();
        }
        private string ProcessUploadedFile()
        {
            string uniqueFileName = null;

            if (Photo != null)
            {
                string uploadsFolder = Path.Combine(webHostEnvironment.WebRootPath, "images");
                // uniqueFileName = Guid.NewGuid().ToString() + "_" + Photo.FileName;
                uniqueFileName = Photo.FileName;
                string filePath = Path.Combine(uploadsFolder, uniqueFileName);
                using (var fileStream = new FileStream(filePath, FileMode.Create))
                {
                    Photo.CopyTo(fileStream);
                }
            }

            return uniqueFileName;
        }
    }
}

