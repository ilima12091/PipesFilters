using System;
using TwitterUCU;

namespace CompAndDel.Filters
{
    public class FilterPostTwitter : IFilter
    {
        public IPicture Filter(IPicture image)
        {
            this.PostToTwitter(image);
            return image;
        }

        private void PostToTwitter(IPicture image)
        {
            this.Persist(image, "imageForPost.jpg");
            string consumerKey = "CkovShLMNVCY0STsZlcRUFu99";
            string consumerKeySecret = "6rc35cHCyqFQSy4vIIjKiCYu31qqkBBkSS5BRlqeYCt5r7zO5B";
            string accessTokenSecret = "gNytQjJgLvurJekVU0wmBBkrR1Th40sJmTO8JDhiyUkuy";
            string accessToken = "1396065818-MeBf8ybIXA3FpmldORfBMdmrVJLVgijAXJv3B18";
            var twitter = new TwitterImage(consumerKey, consumerKeySecret, accessToken, accessTokenSecret);
            Console.WriteLine(twitter.PublishToTwitter("", "imageForPost.jpg"));
        }

        private void Persist(IPicture image, string pathToPersist) 
        {
            PictureProvider provider = new PictureProvider();
            provider.SavePicture(image, pathToPersist);
        }
    }
}