namespace Tests.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AddedMoreModels : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Asks",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        AskText = c.String(),
                        isAnswerCorrect = c.Boolean(nullable: false),
                        Quiz_Id = c.Int(),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Quizs", t => t.Quiz_Id)
                .Index(t => t.Quiz_Id);
            
            CreateTable(
                "dbo.Quizs",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        isQuizCorrect = c.Boolean(nullable: false),
                        isQuizComplited = c.Boolean(nullable: false),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.Tests",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Title = c.String(),
                        Description = c.String(),
                        Author = c.String(),
                        Quiz_Id = c.Int(),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Quizs", t => t.Quiz_Id)
                .Index(t => t.Quiz_Id);
            
            AddColumn("dbo.Answers", "Ask_Id", c => c.Int());
            CreateIndex("dbo.Answers", "Ask_Id");
            AddForeignKey("dbo.Answers", "Ask_Id", "dbo.Asks", "Id");
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Tests", "Quiz_Id", "dbo.Quizs");
            DropForeignKey("dbo.Asks", "Quiz_Id", "dbo.Quizs");
            DropForeignKey("dbo.Answers", "Ask_Id", "dbo.Asks");
            DropIndex("dbo.Tests", new[] { "Quiz_Id" });
            DropIndex("dbo.Asks", new[] { "Quiz_Id" });
            DropIndex("dbo.Answers", new[] { "Ask_Id" });
            DropColumn("dbo.Answers", "Ask_Id");
            DropTable("dbo.Tests");
            DropTable("dbo.Quizs");
            DropTable("dbo.Asks");
        }
    }
}
