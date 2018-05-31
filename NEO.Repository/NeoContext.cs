using System.Data.Entity;
using System.Data.Entity.ModelConfiguration.Conventions;
using NEO.Core;

namespace NEO.Repository
{
    public class NeoContext:DbContext
    {
        public NeoContext():base("name=NeoConnection")
        {
            
        }

      

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            //删除表名称的复数形式
            modelBuilder.Conventions.Remove<PluralizingTableNameConvention>();
            //禁用一对多级联删除
            modelBuilder.Conventions.Remove<OneToManyCascadeDeleteConvention>();
            //禁用多对多级联删除
            modelBuilder.Conventions.Remove<ManyToManyCascadeDeleteConvention>();

            base.OnModelCreating(modelBuilder);
        }
    }
}
