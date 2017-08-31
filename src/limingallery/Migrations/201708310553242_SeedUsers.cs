namespace limingallery.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class SeedUsers : DbMigration
    {
        public override void Up()
        {
            Sql(@"
INSERT INTO [dbo].[AspNetUsers] ([Id], [Email], [EmailConfirmed], [PasswordHash], [SecurityStamp], [PhoneNumber], [PhoneNumberConfirmed], [TwoFactorEnabled], [LockoutEndDateUtc], [LockoutEnabled], [AccessFailedCount], [UserName]) VALUES (N'c349ba56-c15e-45b3-8f8b-480b238720f0', N'phihai222@gmail.com', 0, N'AIE/VsJ7voWi3aB5Lywfz6RBEoZUq9jja90q2N4MutJIX9Cn02NxN9mTkcg59hMWdw==', N'6980dc7b-353c-4586-9bff-39b4ec398155', NULL, 0, 0, NULL, 1, 0, N'phihai222@gmail.com')
INSERT INTO [dbo].[AspNetUsers] ([Id], [Email], [EmailConfirmed], [PasswordHash], [SecurityStamp], [PhoneNumber], [PhoneNumberConfirmed], [TwoFactorEnabled], [LockoutEndDateUtc], [LockoutEnabled], [AccessFailedCount], [UserName]) VALUES (N'c6b113d8-d9db-4988-b18f-eea7c0ae309b', N'phihai91@gmail.com', 0, N'AOn/3JAlI4ZEvHj8hQYZyV4xPpB9bBy8SXuh60dz2fpLjXvCpxWfoeFFm6lp03uPPQ==', N'139ae895-83f9-4f0b-baa1-2c3a5f059c8c', NULL, 0, 0, NULL, 1, 0, N'phihai91@gmail.com')

INSERT INTO [dbo].[AspNetRoles] ([Id], [Name]) VALUES (N'df9db8e1-f53b-43a7-b54a-bc08f6340d3b', N'Admin')
INSERT INTO [dbo].[AspNetRoles] ([Id], [Name]) VALUES (N'16e712ad-8c92-44a6-9162-5771a11daa94', N'Boss')

INSERT INTO [dbo].[AspNetUserRoles] ([UserId], [RoleId]) VALUES (N'c6b113d8-d9db-4988-b18f-eea7c0ae309b', N'16e712ad-8c92-44a6-9162-5771a11daa94')
INSERT INTO [dbo].[AspNetUserRoles] ([UserId], [RoleId]) VALUES (N'c349ba56-c15e-45b3-8f8b-480b238720f0', N'df9db8e1-f53b-43a7-b54a-bc08f6340d3b')

");
        }
        
        public override void Down()
        {
        }
    }
}
