using System;
using System.Collections.Generic;
using System.Text;

namespace Data.Dto
{
   public class SaveUserDto
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Lastname { get; set; }
        public string Password { get; set; }
    }
}
