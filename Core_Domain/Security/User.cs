using PetaPoco;
using System;

namespace Core_Domain
{
    [TableName("\"ProjectKona\".\"User\"")]
    [PrimaryKey("UserId", AutoIncrement = true)]
    public class User
    {

        [PetaPoco.Column(Name = "UserId")]

        public int UserId { get; set; }
        [PetaPoco.Column(Name = "FirstName")]
        public string FirstName { get; set; }
        [PetaPoco.Column(Name = "LastName")]
        public string LastName { get; set; }
        [PetaPoco.Column(Name = "UserName")]
        public string UserName { get; set; }
    }

}
