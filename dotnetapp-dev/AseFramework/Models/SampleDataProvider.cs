// --------------------------------------------------------------------------------------------------------------------
// <copyright file="SampleDataProvider.cs" company="">
//   
// </copyright>
// <summary>
//   The sample data provider.
// </summary>
// --------------------------------------------------------------------------------------------------------------------

namespace DotnetApp.AseFramework.Models
{
    #region

    using System;

    #endregion

    /// <summary>
    /// The sample data provider.
    /// </summary>
    public class SampleDataProvider
    {
        /// <summary>
        /// The onetab json empty state.
        /// </summary>
        public static string OnetabJsonEmptyState = @"{""tabGroups"":[]}";

        /// <summary>
        /// The get sample tweet.
        /// </summary>
        /// <returns>
        /// The <see cref="TweetModel"/>.
        /// </returns>
        public static InteropTypes.V1.TweetModel GetSampleTweet()
        {
            var pTweet = new InteropTypes.V1.TweetModel
                             {
                                 Id =
                                     null, // typeof(InteropTypes.V1.TweetModel) + ".GetSampleTweet",
                                 // Id = 1,
                                 User = "rogeraaut",
                                 PostDateTime = DateTime.Now,
                                 Value = "Trying out NEST, so far so good?"
                             };
            return pTweet;
        }
    }
}