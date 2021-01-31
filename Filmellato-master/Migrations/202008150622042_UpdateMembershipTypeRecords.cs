namespace Filmellato.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class UpdateMembershipTypeRecords : DbMigration
    {
        public override void Up()
        {
            Sql("UPDATE MembershipTypes SET MembershipName = 'Azonnali fizetés' WHERE Id = 1");
            Sql("UPDATE MembershipTypes SET MembershipName = 'Havi' WHERE Id = 2");
            Sql("UPDATE MembershipTypes SET MembershipName = 'Negyedéves' WHERE Id = 3");
            Sql("UPDATE MembershipTypes SET MembershipName = 'Éves' WHERE Id = 4");
        }
        
        public override void Down()
        {
        }
    }
}
