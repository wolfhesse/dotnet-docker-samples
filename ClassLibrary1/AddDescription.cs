// --------------------------------------------------------------------------------------------------------------------
// <copyright file="AddDescription.cs" company="">
//   
// </copyright>
// <summary>
//   The AddDescription interface.
// </summary>
// --------------------------------------------------------------------------------------------------------------------

namespace DescriptionUseCase
{
    using System;

    /// <summary>The AddDescription interface.</summary>
    public interface IAddDescription
    {
//        Description DescriptionRecord { get; }

        /// <summary>Gets the save changes.</summary>
        int SaveChanges { get; }
    }

    /// <summary>The add description.</summary>
    public class AddDescription : IAddDescription
    {
//        public Description DescriptionRecord { get; }

        /// <inheritdoc />
        public AddDescription(string Desc)
        {
//            var dbRogeraEntities = new DbRogeraEntities();
//            this.DescriptionRecord = dbRogeraEntities.Description.Add(new Description { Desc = Desc });
//            Console.Out.WriteLine("description = {0}", this.DescriptionRecord);
//            this.SaveChanges = dbRogeraEntities.SaveChanges();
//            Console.Out.WriteLine("description.Desc = {0}", description.Desc);
//            Console.Out.WriteLine("description.Id = {0}", description.Id);
        }

        /// <summary>Gets the save changes.</summary>
        public int SaveChanges { get; }
    }
}