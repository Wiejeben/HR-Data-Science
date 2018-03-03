using System.Collections.Generic;

namespace DataScience.Models.UserItem
{
    public class Article
    {
        public int Id;

        public Article(int id)
        {
            Id = id;
        }

        public static SortedDictionary<int, Article> Populate(IEnumerable<string[]> ratings)
        {
            var models = new SortedDictionary<int, Article>();
            foreach (var rating in ratings)
            {
                var articleId = int.Parse(rating[1]);

                if (models.ContainsKey(articleId))
                {
                    continue;
                }

                models.Add(articleId, new Article(articleId));
            }
            
            return models;
        }
    }
}