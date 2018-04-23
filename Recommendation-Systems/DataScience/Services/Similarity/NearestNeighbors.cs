using System;
using System.Collections.Generic;
using DataScience.Models.UserItem;

namespace DataScience.Services.Similarity
{
    public class NearestNeighbors
    {
        private readonly SortedDictionary<int, Article> Articles;
        private readonly List<User> Users;
        private readonly User User;

        public NearestNeighbors(List<User> users, User user, SortedDictionary<int, Article> articles)
        {
            Users = users;
            
            // Remove current user from users list
            Users.Remove(user);
            
            User = user;
            Articles = articles;
        }

        /// <summary>
        /// Calculate similarity and return a list of tuples with the user and how similar it is.
        /// </summary>
        public IEnumerable<Tuple<User, float>> ListSimilarities(Similarity similarity, float threshold = 1)
        {
            var users = new List<Tuple<User, float>>();

            foreach (var user in Users)
            {
                var data = new SimilarityList(user.Ratings, User.Ratings, Articles);
                var result = (float) similarity.Calculate(data);

                if (result < threshold)
                {
                    continue;
                }

                users.Add(new Tuple<User, float>(user, result));
            }

            // Sort
            users.Sort((x, y) => y.Item2.CompareTo(x.Item2));

            return users;
        }
    }
}