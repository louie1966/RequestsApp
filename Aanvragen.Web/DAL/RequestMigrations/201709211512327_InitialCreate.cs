namespace Aanvragen.Web.DAL.RequestMigrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class InitialCreate : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "request.Attachment",
                c => new
                    {
                        ID = c.Int(nullable: false, identity: true),
                        Name = c.String(),
                        Description = c.String(),
                        FileName = c.String(),
                        Extention = c.String(),
                        Url = c.String(),
                        Active = c.Boolean(nullable: false),
                        Type = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.ID);
            
            CreateTable(
                "request.PersonAttachment",
                c => new
                    {
                        ID = c.Int(nullable: false, identity: true),
                        PersonID = c.Int(nullable: false),
                        AttachmentID = c.Int(nullable: false),
                        Action = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.ID)
                .ForeignKey("request.Attachment", t => t.AttachmentID, cascadeDelete: true)
                .ForeignKey("request.Person", t => t.PersonID, cascadeDelete: true)
                .Index(t => t.PersonID)
                .Index(t => t.AttachmentID);
            
            CreateTable(
                "request.Person",
                c => new
                    {
                        ID = c.Int(nullable: false, identity: true),
                        FirstName = c.String(),
                        Preposition = c.String(),
                        LastName = c.String(),
                        Email = c.String(),
                        Phone = c.String(),
                        Active = c.Boolean(nullable: false),
                        CompanyID = c.Int(nullable: false),
                        Address = c.String(),
                        AddressAddition = c.String(),
                        ZipCode = c.String(),
                        City = c.String(),
                        Role = c.Int(nullable: false),
                        HireType = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.ID)
                .ForeignKey("request.Company", t => t.CompanyID, cascadeDelete: true)
                .Index(t => t.CompanyID);
            
            CreateTable(
                "request.Company",
                c => new
                    {
                        ID = c.Int(nullable: false, identity: true),
                        Name = c.String(),
                        Address = c.String(),
                        AddressAddition = c.String(),
                        ZipCode = c.String(),
                        City = c.String(),
                        Active = c.Boolean(nullable: false),
                    })
                .PrimaryKey(t => t.ID);
            
            CreateTable(
                "request.RequestAttachment",
                c => new
                    {
                        ID = c.Int(nullable: false, identity: true),
                        RequestID = c.Int(nullable: false),
                        AttachmentID = c.Int(nullable: false),
                        Action = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.ID)
                .ForeignKey("request.Attachment", t => t.AttachmentID, cascadeDelete: true)
                .ForeignKey("request.Request", t => t.RequestID, cascadeDelete: true)
                .Index(t => t.RequestID)
                .Index(t => t.AttachmentID);
            
            CreateTable(
                "request.Request",
                c => new
                    {
                        ID = c.Int(nullable: false, identity: true),
                        RequestNumber = c.String(),
                        Name = c.String(),
                        Description = c.String(),
                        Type = c.Int(nullable: false),
                        Status = c.Int(nullable: false),
                        Created = c.DateTime(nullable: false),
                        Start = c.DateTime(nullable: false),
                        End = c.DateTime(nullable: false),
                        CompanyID = c.Int(nullable: false),
                        Active = c.Boolean(nullable: false),
                    })
                .PrimaryKey(t => t.ID)
                .ForeignKey("request.Company", t => t.CompanyID, cascadeDelete: true)
                .Index(t => t.CompanyID);
            
        }
        
        public override void Down()
        {
            DropForeignKey("request.RequestAttachment", "RequestID", "request.Request");
            DropForeignKey("request.Request", "CompanyID", "request.Company");
            DropForeignKey("request.RequestAttachment", "AttachmentID", "request.Attachment");
            DropForeignKey("request.PersonAttachment", "PersonID", "request.Person");
            DropForeignKey("request.Person", "CompanyID", "request.Company");
            DropForeignKey("request.PersonAttachment", "AttachmentID", "request.Attachment");
            DropIndex("request.Request", new[] { "CompanyID" });
            DropIndex("request.RequestAttachment", new[] { "AttachmentID" });
            DropIndex("request.RequestAttachment", new[] { "RequestID" });
            DropIndex("request.Person", new[] { "CompanyID" });
            DropIndex("request.PersonAttachment", new[] { "AttachmentID" });
            DropIndex("request.PersonAttachment", new[] { "PersonID" });
            DropTable("request.Request");
            DropTable("request.RequestAttachment");
            DropTable("request.Company");
            DropTable("request.Person");
            DropTable("request.PersonAttachment");
            DropTable("request.Attachment");
        }
    }
}
