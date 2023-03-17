using System.Collections.Generic;

namespace CA.Domain.Entities
{
    public class mtUsers
    {
        public int account_id { get; set; }
        public string first_name { get; set; }
        public string last_name { get; set; }
        public string username { get; set; }
        public string passwordhash { get; set; }
        public DateTime createdate { get; set; }
        public DateTime updatedate { get; set; }
    }
}
