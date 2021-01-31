namespace Filmellato.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class SeedUsers : DbMigration
    {
        public override void Up()
        {
            AlterColumn("dbo.Movies", "Name", c => c.String(nullable: false, maxLength: 255));

            Sql(@"
            INSERT INTO[dbo].[AspNetUsers] ([Id], [Email], [EmailConfirmed], [PasswordHash], [SecurityStamp], [PhoneNumber], [PhoneNumberConfirmed], [TwoFactorEnabled], [LockoutEndDateUtc], [LockoutEnabled], [AccessFailedCount], [UserName]) VALUES(N'05da5ef6-012d-4045-961e-68bebe258df8', N'guest@filmellato.com', 0, N'ABOUuEjpjLV0UCwQ7575h9EG+yD18RX1KRicoKyKA4OxQm5vJ0hlhLi915uX2Kk8Xg==', N'1d31ad02-c3d1-4488-9fec-9ef684801973', NULL, 0, 0, NULL, 1, 0, N'guest@filmellato.com')
            INSERT INTO[dbo].[AspNetUsers] ([Id], [Email], [EmailConfirmed], [PasswordHash], [SecurityStamp], [PhoneNumber], [PhoneNumberConfirmed], [TwoFactorEnabled], [LockoutEndDateUtc], [LockoutEnabled], [AccessFailedCount], [UserName]) VALUES(N'909bc7be-6119-4cff-8442-26ce86df6a43', N'admin@filmellato.com', 0, N'APfykzOC/4M+uL49wD9jOZ2CDT72P2+kurMcL3BE1sWkC+DTS7XkGtCEIJZm9vvn5Q==', N'e901aa67-2e3d-49af-bea5-09e6ae05f9da', NULL, 0, 0, NULL, 1, 0, N'admin@filmellato.com')
            
            INSERT INTO [dbo].[AspNetRoles] ([Id], [Name]) VALUES (N'3443bf83-025c-4228-9012-33654faedf00', N'CanManageMovies')
            
            INSERT INTO [dbo].[AspNetUserRoles] ([UserId], [RoleId]) VALUES (N'909bc7be-6119-4cff-8442-26ce86df6a43', N'3443bf83-025c-4228-9012-33654faedf00')
            ");
        }

        public override void Down()
        {
            AlterColumn("dbo.Movies", "Name", c => c.String());
        }
    }
}
