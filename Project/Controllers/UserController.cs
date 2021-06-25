using Data.Context;
using Data.Dto;
using Data.Models;
using DataAccess.UnitOfWork;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Project.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class UserController : ControllerBase
    {
        MasterContext masterContext = new MasterContext();
        [HttpPost("AddUser")]
        public string AddUser(SaveUserDto userDto)
        {
            using (UnitOfWork unitOf = new UnitOfWork(masterContext))
            {
                User user = new User()
                {
                    ID = userDto.Id,
                    NAME = userDto.Name,
                    LASTNAME = userDto.Lastname,
                    PASSWORD = userDto.Password
                };
                unitOf.GetRepository<User>().Add(user);
                int save = unitOf.SaveChanges();
                if (save == 1)
                    return "Kayıt Başarılı.";
                else
                    return "Kayıt Başarısız";
            }
        }
        [HttpGet("GetUser")]
        public UserDto GetUser(int Id)
        {
            using (UnitOfWork unitOf = new UnitOfWork(masterContext))
            {
                User user = unitOf.GetRepository<User>().Get(Id);
                UserDto userDto = new UserDto()
                {
                    Name = user.NAME,
                    Lastname = user.LASTNAME
                };
                return userDto;
            }
        }
        [HttpDelete("DeleteUser")]
        public string DeleteUser(int id)
        {
            using (UnitOfWork unitOf = new UnitOfWork(masterContext))
            {
                User user = unitOf.GetRepository<User>().Get(id);
                unitOf.GetRepository<User>().Delete(user);
                int save = unitOf.SaveChanges();
                if (save == 1)
                    return " Kayıt Silindi.";
                else
                    return "Kayıt Bulunamadı";
            }
        }
        [HttpPut("UpdateUser")]
        public string UpdateUser(SaveUserDto saveUserDto)
        {
            using (UnitOfWork unitOf = new UnitOfWork(masterContext))
            {
                User user = unitOf.GetRepository<User>().Get(saveUserDto.Id);
                user.NAME = saveUserDto.Name;
                user.LASTNAME = saveUserDto.Lastname;
                user.PASSWORD = saveUserDto.Password;
                unitOf.GetRepository<User>().Update(user);
                int save = unitOf.SaveChanges();
                if (save == 1)
                    return " Kayıt Güncellendi.";
                else
                    return "Hata Oluştu";
            }
        }

    }

}
