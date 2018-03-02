﻿using System.Collections.Generic;

namespace DataScience.Models.UserItem
{
    public class User
    {
        public int Id;
        public Dictionary<int, float> Ratings;

        public User(int id)
        {
            Id = id;
            Ratings = new Dictionary<int, float>();
        }

        public void AddRating(int articleId, float rating)
        {
            Ratings.Add(articleId, rating);
        }

        public static Dictionary<int, User> Populate(IEnumerable<string[]> ratings)
        {
            var models = new Dictionary<int, User>();
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