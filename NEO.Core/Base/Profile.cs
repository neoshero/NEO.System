using System;

namespace NEO.Core
{
    public class Profile
    {
        public int Id { get; set; } 
        public string NickName { get; set; } 
        public string Name { get; set; } 
        public int Gender { get; set; } 
        public DateTime? Birthday { get; set; } 
        public string Tel { get; set; } 
        public string Email { get; set; } 
        public string Remark { get; set; } 
        public DateTime CreatedDate { get; set; } 
        public string CreatedBy { get; set; } 
        public DateTime ModifyDate { get; set; } 
        public string ModifyBy { get; set; } 
    }
}
