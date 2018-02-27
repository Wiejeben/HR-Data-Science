namespace DataScience.Models.UserItem
{
    public class UserPreference
    {
        public int UserId;
        public int ArticleId;
        public float Rating;
        
        public UserPreference(int userId, int articleId, float rating)
        {
            UserId = userId;
            ArticleId = articleId;
            Rating = rating;
        }
    }
}