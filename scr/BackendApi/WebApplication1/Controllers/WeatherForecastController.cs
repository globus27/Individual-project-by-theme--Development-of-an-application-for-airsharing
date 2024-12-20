using Microsoft.AspNetCore.Mvc;

namespace WebApplication1.Controllers
{
    [ApiController]
    [Route("[controller]/[action]")]
    public class WeatherForecastController : ControllerBase
    {
        private static List<string> Summaries = new()
        {
        "Freezing", "Bracing", "Chilly", "Cool", "Mild", "Warm", "Balmy", "Hot", "Sweltering", "Scorching"
        };

        private readonly ILogger<WeatherForecastController> _logger;

        public WeatherForecastController(ILogger<WeatherForecastController> logger)
        {
            _logger = logger;
        }

        [HttpGet]
        public List<string> Get()
        {
            return Summaries;
        }
       
        [HttpPost]
        public IActionResult Add(string name)
        {
            Summaries.Add(name);
            return Ok();
        }
        [HttpPut]
        public IActionResult Update(int index, string name)
        {
            if(index >= Summaries.Count || index < 0)
            {
                return BadRequest("Индекс неправильный! Попробуй еще раз");
            }
            
            Summaries[index] = name;
            return Ok();
             
        }
        [HttpDelete]
        public IActionResult Delete(int index)
        {
            if (index >= Summaries.Count || index < 0)
            {
                return BadRequest("Индекс неправильный! Попробуй еще раз");
            }
            Summaries.RemoveAt(index);
            return Ok();
        }

        [HttpGet("{index}")]
        public IActionResult GetName(int index) 
        {
            
            if (index >= Summaries.Count || index < 0)
            {
                return BadRequest("Индекс неправильный! Попробуй еще раз");
            }
            return Content(Summaries[index]);
        }
        [HttpGet("{name}")]
        public IActionResult GetByName(string name)
        {
            int count = 0;
            for (int i =0; i< Summaries.Count; i++)
            {
                if(name == Summaries[i])
                    count++;
            }
            return Content($"{count}");

        }
        [HttpGet]
        public IActionResult GetAll(int? sortStrategy)
        {
            switch (sortStrategy)
            {
                case null:
                    { 
                        return Ok(Summaries);
                    
                    }
                case 1:
                    {
                        Summaries.Sort();
                        return Ok(Summaries);
                    }
                case -1: 
                    {
                        Summaries.Reverse();
                        return Ok(Summaries);
                    }
                default:
                    {
                        return BadRequest("Некорректное значение параметра sortStrategy");
                    }

            }
        }
    }
}