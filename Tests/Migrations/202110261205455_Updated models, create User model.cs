namespace Tests.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class UpdatedmodelscreateUsermodel : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Users",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Name = c.String(),
                        Email = c.String(),
                        HashedPassword = c.String(),
                    })
                .PrimaryKey(t => t.Id);
            
            AddColumn("dbo.Asks", "isAskCorrect", c => c.Boolean(nullable: false));
            AddColumn("dbo.Tests", "PassingScore", c => c.Int(nullable: false));
            AddColumn("dbo.Tests", "isTestCorrect", c => c.Boolean(nullable: false));
            AddColumn("dbo.Tests", "User_Id", c => c.Int());
            AddColumn("dbo.Tests", "User_Id1", c => c.Int());
            AddColumn("dbo.Tests", "User_Id2", c => c.Int());
            AddColumn("dbo.Tests", "Author_Id", c => c.Int());
            CreateIndex("dbo.Tests", "User_Id");
            CreateIndex("dbo.Tests", "User_Id1");
            CreateIndex("dbo.Tests", "User_Id2");
            CreateIndex("dbo.Tests", "Author_Id");
            AddForeignKey("dbo.Tests", "User_Id", "dbo.Users", "Id");
            AddForeignKey("dbo.Tests", "User_Id1", "dbo.Users", "Id");
            AddForeignKey("dbo.Tests", "User_Id2", "dbo.Users", "Id");
            AddForeignKey("dbo.Tests", "Author_Id", "dbo.Users", "Id");
            DropColumn("dbo.Asks", "isAnswerCorrect");
            DropColumn("dbo.Quizs", "isQuizCorrect");
            DropColumn("dbo.Tests", "Author");
        }
        
        public override void Down()
        {
            AddColumn("dbo.Tests", "Author", c => c.String());
            AddColumn("dbo.Quizs", "isQuizCorrect", c => c.Boolean(nullable: false));
            AddColumn("dbo.Asks", "isAnswerCorrect", c => c.Boolean(nullable: false));
            DropForeignKey("dbo.Tests", "Author_Id", "dbo.Users");
            DropForeignKey("dbo.Tests", "User_Id2", "dbo.Users");
            DropForeignKey("dbo.Tests", "User_Id1", "dbo.Users");
            DropForeignKey("dbo.Tests", "User_Id", "dbo.Users");
            DropIndex("dbo.Tests", new[] { "Author_Id" });
            DropIndex("dbo.Tests", new[] { "User_Id2" });
            DropIndex("dbo.Tests", new[] { "User_Id1" });
            DropIndex("dbo.Tests", new[] { "User_Id" });
            DropColumn("dbo.Tests", "Author_Id");
            DropColumn("dbo.Tests", "User_Id2");
            DropColumn("dbo.Tests", "User_Id1");
            DropColumn("dbo.Tests", "User_Id");
            DropColumn("dbo.Tests", "isTestCorrect");
            DropColumn("dbo.Tests", "PassingScore");
            DropColumn("dbo.Asks", "isAskCorrect");
            DropTable("dbo.Users");
        }
    }
}
