namespace limingallery.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class SeedUserAndRoles : DbMigration
    {
        public override void Up()
        {
            Sql(@"
INSERT INTO [dbo].[AspNetRoles] ([Id], [Name]) VALUES (N'bc321ebd-196e-49bb-97ff-6b4488bc7dc4', N'Admin')
INSERT INTO [dbo].[AspNetRoles] ([Id], [Name]) VALUES (N'285d259a-da45-4f2c-a731-eeedf7ca7c16', N'Boss')

INSERT INTO [dbo].[AspNetUsers] ([Id], [NickName], [Email], [EmailConfirmed], [PasswordHash], [SecurityStamp], [PhoneNumber], [PhoneNumberConfirmed], [TwoFactorEnabled], [LockoutEndDateUtc], [LockoutEnabled], [AccessFailedCount], [UserName]) VALUES (N'112bd69f-c501-4d89-9c39-08e3aaaf87bf', N'phihai91', N'phihai91@gmail.com', 0, N'ABUcbGgV/UQLU2EMKLC48kdgPXCVbS8palQVY/OaudLz0Gl7NDFHXrcI1xU+ut8oig==', N'2697669a-89a5-417e-a332-e764973a98e5', NULL, 0, 0, NULL, 1, 0, N'phihai91@gmail.com')
INSERT INTO [dbo].[AspNetUsers] ([Id], [NickName], [Email], [EmailConfirmed], [PasswordHash], [SecurityStamp], [PhoneNumber], [PhoneNumberConfirmed], [TwoFactorEnabled], [LockoutEndDateUtc], [LockoutEnabled], [AccessFailedCount], [UserName]) VALUES (N'dfd86cbf-7b5e-450d-9895-64026b6500b6', N'Admin', N'phihai222@gmail.com', 0, N'AO5GVmIA3fPEbvg/4zV/UV+dVCRhnVwX+5WWOIs697grlj+YT+WPwmZUqqG2+VyUng==', N'e21cd4d9-3742-4f00-aa41-70ba1fdde8af', NULL, 0, 0, NULL, 1, 0, N'phihai222@gmail.com')

INSERT INTO [dbo].[AspNetUserRoles] ([UserId], [RoleId]) VALUES (N'112bd69f-c501-4d89-9c39-08e3aaaf87bf', N'285d259a-da45-4f2c-a731-eeedf7ca7c16')
INSERT INTO [dbo].[AspNetUserRoles] ([UserId], [RoleId]) VALUES (N'dfd86cbf-7b5e-450d-9895-64026b6500b6', N'bc321ebd-196e-49bb-97ff-6b4488bc7dc4')

");
        }
        
        public override void Down()
        {
        }
    }
}
