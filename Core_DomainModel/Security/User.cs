using PetaPoco;

namespace Core_DomainModel
{
    [TableName("\"ProjectKona\".\"User\"")]
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
