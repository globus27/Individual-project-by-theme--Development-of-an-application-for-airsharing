using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using BusinessLogic.Interfaces;
using DataAccess.Models;
using WebApplication1.Contracts.User;
using Mapster;

namespace WebApplication1.Controllers
{
    [Route(template:"api/[controller]")]
    [ApiController]
    public class UserController : ControllerBase
    {
        private IUserService _userService;
        public UserController(IUserService userService)
        {
            _userService = userService;
        }

        [HttpGet]
        public async Task<IActionResult> GetAll()
        {
            return Ok(await _userService.GetAll());
        }
        /// <summary>
        /// Получение пользователя по его ID
        /// </summary>
        /// <remarks>
        /// Пример запроса:
        ///
        ///     Get /Todo
        ///     {
        ///        "idUser": 0
        ///     }
        ///
        /// </remarks>
        /// <param name="model">Пользователь</param>
        /// <returns></returns>

        // POST api/<UsersController>
        [HttpGet(template:"{id}")]
        public async Task<IActionResult> GetById(int id)
        {
            var result = await _userService.GetById(id);
            var response = result.Adapt<User>();
            return Ok(response);
        }
        /// <summary>
        /// Создание нового пользователя
        /// </summary>
        /// <remarks>
        /// Пример запроса:
        ///
        ///     POST /Todo
        ///     {
        ///        "login" : "AirMan20000",
        ///        "email": "mail@mail.ru",
        ///        "password" : "!Pa$$word123@",
        ///        "idPassport": "2"
        ///     }
        ///
        /// </remarks>
        /// <param name="model">Пользователь</param>
        /// <returns></returns>

        // POST api/<UsersController>
        [HttpPost]
        public async Task<IActionResult> Add(CreateUserRequest request)
        {
            var userDto = request.Adapt<User>();
            await _userService.Create(userDto); 
            return Ok();
        }

        //[HttpPost]
        //public async Task<IActionResult> Add(CreateUserRequest request)
        //{
        //    var userDto = new User()
        //    {
        //        Login = request.Login,
        //        Email = request.Email,
        //        Password = request.Password,
        //        IdPassport = request.IdPassport,

        //    };
        //    await _userService.Create(userDto);
        //    return Ok();
        //}

        [HttpPut]
        public async Task<IActionResult> Update(User user)
        {
            await _userService.Update(user);
            return Ok();
        }

        [HttpDelete]
        public async Task<IActionResult> Delete(int id)
        {
            await _userService.Delete(id);
            return Ok();
        }
    }
}
