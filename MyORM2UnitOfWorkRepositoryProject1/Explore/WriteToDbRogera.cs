using NUnit.Framework;

namespace MyORM2UnitOfWorkRepositoryProject1.Explore
{
    using System;

    [TestFixture]
    public class WriteToDbRogera
    {
        [Test]
        public void WriteDescription()
        {
            var model1 = new Model1();
            var description = model1.Description.Create();
            description.Desc = $"desc {DateTimeOffset.Now}";
            Console.Out.WriteLine("description = {0}", description);
            model1.Description.Add(description);
            var saveChanges = model1.SaveChanges();
            Console.Out.WriteLine("saveChanges = {0}", saveChanges);
        }
    }
}