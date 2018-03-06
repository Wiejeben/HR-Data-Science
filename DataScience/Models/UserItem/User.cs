using System.Collections.Generic;
using System.Text;

namespace DataScience.Models.UserItem
{
    public class User
    {
        public readonly int Id;
        public readonly Dictionary<int, float> Ratings;

        public User(int id)
        {
            Id = id;
            Ratings = new Dictionary<int, float>();
        }

        public void AddRating(int articleId, float rating)
        {
            Ratings.Add(articleId, rating);
        }

        /// <summary>
        /// Create user models from the provided list with array of strings.
        /// </summary>
        public static SortedDictionary<int, User> Populate(IEnumerable<string[]> ratings)
        {
            var models = new SortedDictionary<int, User>();
            foreach (var rating in ratings)
            {
                var userId = int.Parse(rating[0]);
                var articleId = int.Parse(rating[1]);
                var grade = float.Parse(rating[2]);

                if (!models.TryGetValue(userId, out var model))
                {
                    model = new User(userId);
                    models.Add(userId, model);
                }
                
                model.AddRating(articleId, grade);
            }

            return models;
        }
    }
}