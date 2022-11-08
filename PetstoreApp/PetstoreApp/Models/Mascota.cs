using PetstoreApp.Utils;

namespace PetstoreApp.Models
{

    public class Mascota
    {
        public long id { get; set; }
        public Category category { get; set; }
        public string name { get; set; }
        public string[] photoUrls { get; set; }
        public Tag[] tags { get; set; }
        public string status { get; set; }
        public string Status
        {
            get
            {
                Enum.TryParse<Utilities.Status>(status, out Utilities.Status statusValue);
                return statusValue.ToString();
            }
        }
    }

    public class Category
    {
        public int id { get; set; }
        public string name { get; set; }
    }

    public class Tag
    {
        public int id { get; set; }
        public string name { get; set; }
    }


}
