namespace DAL.Migrations
{
    using System;
    using System.Data.Entity;
    using System.Data.Entity.Migrations;
    using System.Linq;

    internal sealed class Configuration : DbMigrationsConfiguration<DAL.EF.UMSContext>
    {
        public Configuration()
        {
            AutomaticMigrationsEnabled = false;
        }

        protected override void Seed(DAL.EF.UMSContext context)
        {
            //for (int i = 1; i < 11; i++) {
            //    context.Students.Add(new EF.Tables.Student() { 
            //        Name ="Student "+i,
            //        Address = "Address " +i
            //    });
            //}
            //context.SaveChanges();
        }
    }
}
