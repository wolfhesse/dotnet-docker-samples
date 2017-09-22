namespace AddDescription
{
    using System;
    using System.ComponentModel.Design;

    using DescriptionUseCase;

    using NUnit.Framework;

    [TestFixture]
    public class UnitTestOne
    {
        private string desc;

        private FindDescription findDescription;

        private AddDescription addDescription;

        [SetUp]
        public void AddDescriptionRecord()
        {
            this.desc = $"{DateTimeOffset.Now} + {this}";
            this.addDescription = new AddDescription(this.desc);
            var saved = this.addDescription;
            Console.Out.WriteLine("saved = {0}", saved);
            Console.Out.WriteLine("this.desc = {0}", this.desc);
//            Console.Out.WriteLine("addDescription = {0}", this.addDescription.DescriptionRecord.Id);
        }

        [Test]
        public void FindDescriptionRecord()
        {
//            var description = this.findDescription = new FindDescription(this.addDescription.DescriptionRecord.Id);
//            Console.Out.WriteLine($"description = {description.LastDescription.Id}");
        }

        [Test]
        public void ChangeDescription()
        {

            this.desc = $"something else @ {DateTimeOffset.Now}";
            new UpdateDescription(1, desc);
        }
    }

    public class UpdateDescription
    {
        public UpdateDescription(int i, string desc)
        {
//            var dbRogeraEntities = new DbRogeraEntities();
//            var description = dbRogeraEntities.Description.Find(1);
//            description.Desc = desc;
            
//            dbRogeraEntities.SaveChanges();
        }
    }
}
