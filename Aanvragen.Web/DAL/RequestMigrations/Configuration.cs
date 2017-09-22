namespace Aanvragen.Web.DAL.RequestMigrations {
    using Entities;
    using System;
    using System.Data.Entity;
    using System.Data.Entity.Migrations;
    using System.Linq;

    internal sealed class Configuration : DbMigrationsConfiguration<Aanvragen.Web.DAL.RequestDb> {
        public Configuration() {
            AutomaticMigrationsEnabled = false;
            MigrationsDirectory = @"DAL\RequestMigrations";
        }

        protected override void Seed(Aanvragen.Web.DAL.RequestDb context) {
            //  This method will be called after migrating to the latest version.

            context.Companies.AddOrUpdate(
                c => c.ID,
                new Company { ID = 1, Name = "SIRA Professionals B.V.", Address = "Noordzijde 113", ZipCode = "2411 RE", City = " Bodegraven", Active = true },
                new Company { ID = 2, Name = "McDonald's Nederland B.V.", Address = "Paasheuvelweg 14", ZipCode = "1105 BH", City = "Amsterdam", Active = true },
                new Company { ID = 3, Name = "Thales TTS", Address = "Bestevaer 46", ZipCode = "1271 ZA", City = "Huizen", Active = true });

            context.Attachments.AddOrUpdate(
                a => a.ID,
                new Attachment { ID = 1, Name = "Attachment 1", Description = "Attachment 1 Mc. Donalds", FileName = "attachment1_20170830001.txt", Extention = "txt", Type = AttachmentType.Overig, Url = "http://server.nl/attachment1_20170830001.txt", Active = true },
                new Attachment { ID = 2, Name = "Attachment 2", Description = " Attachment 2 SIRA", FileName = "attachment2_20170830002.xls", Extention = "xls", Type = AttachmentType.CV, Active = true },
                new Attachment { ID = 3, Name = "Attachment 3", Description = " Attachment 3 TTS", FileName = "attachment3_20170830003.docx", Extention = "docx", Type = AttachmentType.Personal, Active = true });

            context.Requests.AddOrUpdate(
                r => r.ID,
                new Request {
                    ID = 1,
                    RequestNumber = "201708300001",
                    Name = "3 mndn Systeembeheer McDonalds",
                    Description = "3 mndn Systeembeheer McDonalds met kans op verlenging",
                    CompanyID = 2,
                    Created = DateTime.Parse("2017-08-30"),
                    Start = DateTime.Parse("2017-10-01"),
                    End = DateTime.Parse("2017-12-31"),
                    Type = RequestType.Verkoop,
                    Status = RequestStatus.Nieuw,
                    Active = true
                },
                new Request {
                    ID = 2,
                    RequestNumber = "201708300002",
                    Name = "3 wkn ServiceNow Applicatiebeheer",
                    Description = "3 wkn ServiceNow Applicatiebeheer en development",
                    CompanyID = 3,
                    Created = DateTime.Parse("2017-08-30"),
                    Start = DateTime.Parse("2017-09-04"),
                    End = DateTime.Parse("2017-09-22"),
                    Type = RequestType.Verkoop,
                    Status = RequestStatus.Aanbieding,
                    Active = true
                });

            context.People.AddOrUpdate(
                c => c.ID,
                new Person {
                    ID = 1,
                    FirstName = "Piet",
                    Preposition = "van",
                    LastName = "Heerdt",
                    CompanyID = 2,
                    Email = "pietvh@md.nl",
                    Phone = "0612345578",
                    Role = Role.Operationmanager,
                    Active = true,
                    Address = null,
                    AddressAddition = null,
                    City = null,
                    ZipCode = null,
                    HireType = HireType.Inhuur,

                },
                new Person {
                    ID = 2,
                    FirstName = "Henk",
                    Preposition = null,
                    LastName = "Meijer",
                    CompanyID = 2,
                    Email = "hm@sira.nl",
                    Phone = "0612345579",
                    Role = Role.Overig,
                    Active = true

                },
                new Person {
                    ID = 3,
                    FirstName = "Mac",
                    Preposition = null,
                    LastName = "Donalds",
                    CompanyID = 1,
                    Email = "md@macdonalds.com",
                    Phone = "0622223333",
                    Role = Role.Directeur,
                    Active = true
                },
                new Person {
                    ID = 4,
                    FirstName = "René",
                    Preposition = "de",
                    LastName = "Leeuw",
                    Address = "Kromme Horn 17",
                    ZipCode = "1484EG",
                    City = "Graft",
                    CompanyID = 1,
                    Email = "renedeleeuw66@gmail.com",
                    Phone = "0627024950",
                    HireType = HireType.Verhuur,
                    Active = true
                },
                new Person {
                    ID = 5,
                    FirstName = "Piet",
                    Preposition = "",
                    LastName = "Patat",
                    Address = "Patatstraat 3127",
                    ZipCode = "1111AA",
                    City = "Amsterdam",
                    CompanyID = 2,
                    Email = "pp@hotmail.com",
                    Phone = "0612345678",
                    HireType = HireType.Inhuur,
                    Active = true
                });

            context.PersonAttachments.AddOrUpdate(
                x => x.ID,
                new PersonAttachment { ID = 1, AttachmentID = 1, PersonID = 2, Action = AttachmentAction.Verzonden },
                new PersonAttachment { ID = 2, AttachmentID = 2, PersonID = 1, Action = AttachmentAction.Verbeterd },
                new PersonAttachment { ID = 3, AttachmentID = 1, PersonID = 2, Action = AttachmentAction.Verzonden },
                new PersonAttachment { ID = 4, AttachmentID = 3, PersonID = 3, Action = AttachmentAction.Beoordeling });

            context.RequestAttachments.AddOrUpdate(
                x => x.ID,
                new RequestAttachment { ID = 1, AttachmentID = 3, RequestID = 2, Action = AttachmentAction.Verzonden },
                new RequestAttachment { ID = 2, AttachmentID = 2, RequestID = 1, Action = AttachmentAction.Verzonden });


        }
    }
}
