using System;
using System.Collections.Generic;

namespace DataScience.Models.UserItem
{
    public class UserItems : Dictionary<int, List<UserPreference>>
    {
        public UserItems(List<string[]> users)
        {
            foreach (string[] user in users)
            {
                var userId = int.Parse(user[0]);
                var articleId = int.Parse(user[1]);
                var rating = float.Parse(user[2]);

                var preference = new UserPreference(userId, articleId, rating);
                if (TryGetValue(userId, out var userPreference))
                {
                    // Add to existing user
                    userPreference.Add(preference);
                }
                else
                {
                    // Create new user
                    Add(userId, new List<UserPreference> {preference});
                }
            }
        }
    }
}