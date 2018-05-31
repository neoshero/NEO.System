using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace NEO.Core
{
    public class Member
    {
        [Key, DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; } 
        public string Uid { get; set; } 
        public string Password { get; set; } 
        public string Salt { get; set; } 
        public int? ProfileId { get; set; } 
        public int? RoleId { get; set; } 
        public int? OrganizationId { get; set; } 
        public string AccessToken { get; set; } 
        public DateTime? AccessTokenExpiry { get; set; } 
        public DateTime CreatedDate { get; set; } 
        public string CreatedBy { get; set; } 
        public int? CreatedById { get; set; } 
        public DateTime ModifyDate { get; set; } 
        public string ModifyBy { get; set; } 
        public int? ModifyById { get; set; } 
    }
}
