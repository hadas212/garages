using GarageApi.Models;          // ייבוא המודלים, במקרה זה Garage
using GarageApi.Services;        // ייבוא שירותי הביזנס לוגיק: GaragesDbService ו-GovernmentApiService
using Microsoft.AspNetCore.Mvc;  // ייבוא תכונות של ASP.NET Core MVC/API

namespace GarageApi.Controllers
{
    [ApiController]                   // מסמן שמדובר בקונטרולר API
    [Route("api/[controller]")]       // קביעת הנתיב: api/garages
    public class GaragesController : ControllerBase
    {
        private readonly GaragesDbService _dbService;      // שירות גישה למסד הנתונים של מוסכים
        private readonly GovernmentApiService _govService; // שירות לשליפת מוסכים מה-API הממשלתי

        // קונסטרקטור - מוזרק תלות של השירותים דרך DI (Dependency Injection)
        public GaragesController(GaragesDbService dbService, GovernmentApiService govService)
        {
            _dbService = dbService;   // שמירת השירות המקומי
            _govService = govService; // שמירת השירות המקומי
        }

        // GET api/garages
        [HttpGet]
        public async Task<List<Garage>> Get() =>
            await _dbService.GetAsync();  // מחזיר את כל המוסכים מהמסד בצורה אסינכרונית

        // POST api/garages/import
        [HttpPost("import")]
        public async Task<IActionResult> ImportFromGov()
        {
            try
            {
                // שליפת רשימת מוסכים מה-API הממשלתי
                var garages = await _govService.GetGaragesFromGovAsync();
                // שמירה של כל מוסך שהתקבל למסד הנתונים
                foreach (var g in garages)
                    await _dbService.CreateAsync(g);

                return Ok(garages); // מחזיר ללקוח את הרשימה שהתקבלה ונשמרה
            }
            catch (Exception ex)
            {
                // במקרה של שגיאה מחזיר 500 עם הודעת השגיאה
                return StatusCode(500, ex.Message);
            }
        }

        // POST api/garages
        [HttpPost]
        public async Task<IActionResult> Create(Garage garage)
        {
            // שמירה של מוסך חדש למסד הנתונים
            await _dbService.CreateAsync(garage);

            // מחזיר תשובה 201 Created עם הנתונים שנוספו
            // CreatedAtAction מאפשר לקבוע URL שמוביל לפונקציית Get שמחזירה את המידע
            return CreatedAtAction(nameof(Get), new { id = garage.Id }, garage);
        }
    }
}
