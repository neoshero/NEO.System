using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Dynamic;
using System.Text;

namespace NEO.Core
{
    public class BaseModule
    {
        [Key,DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; } 
        public int? ParentId { get; set; } 
        public string Code { get; set; } 
        public string Name { get; set; } 
        public bool IsPublic { get; set; } 
        public bool Expand { get; set; } 
        public bool IsLeaf { get; set; } 
        public string NavigateUrl { get; set; } 
        public int Priority { get; set; } 
        public bool Deleted { get; set; } 
        public string Remark { get; set; } 
        public DateTime CreatedDate { get; set; } 
        public string CreatedBy { get; set; } 
        public int? CreatedById { get; set; } 
        public DateTime ModifyDate { get; set; } 
        public string ModifyBy { get; set; } 
        public int? ModifyById { get; set; }

        public static BaseModule CreateInstance(int? parentId,string code,string name,bool ispublic,bool expand,bool isleaf,string navigateUrl,int priority,bool deleted,string remark,Member member)
        {
            DateTime now = DateTime.UtcNow;
            return new BaseModule()
            {
                ParentId = parentId,
                Code = code,
                Name = name,
                IsPublic = ispublic,
                Expand = expand,
                IsLeaf = isleaf,
                NavigateUrl = navigateUrl,
                Priority = priority,
                Deleted = deleted,
                Remark = remark,
                CreatedDate = now,
                CreatedBy = "1",
                ModifyDate = now,
                ModifyBy = "1"
            };
        }
    }
}
