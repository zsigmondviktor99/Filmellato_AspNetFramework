namespace Filmellato.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class PopulateMembershipTypes : DbMigration
    {
        public override void Up()
        {
            Sql("INSERT INTO MembershipTypes (Id, SignUpFee, Duration, DiscountRate) VALUES (1, 0, 0, 0)");
            Sql("INSERT INTO MembershipTypes (Id, SignUpFee, Duration, DiscountRate) VALUES (2, 2000, 1, 10)");
            Sql("INSERT INTO MembershipTypes (Id, SignUpFee, Duration, DiscountRate) VALUES (3, 4000, 3, 15)");
            Sql("INSERT INTO MembershipTypes (Id, SignUpFee, Duration, DiscountRate) VALUES (4, 10000, 12, 20)");
        }
        
        public override void Down()
        {
        }
    }
}
