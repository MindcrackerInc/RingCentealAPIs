using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RingCentral.Reporting.Models.Categories
{

    public class CategoriesModel
    {
        public int count { get; set; }
        public int limit { get; set; }
        public int offset { get; set; }
        public List<Record> records { get; set; }
    }

    public class Record
    {
        public string id { get; set; }
        public DateTime? created_at { get; set; }
        public DateTime? updated_at { get; set; }
        public string name { get; set; }
        public string parent_id { get; set; }
        public bool unselectable { get; set; }
        public bool mandatory { get; set; }
        public bool post_qualification { get; set; }
        public bool multiple { get; set; }
        public int color { get; set; }
        public List<string> source_ids { get; set; }
        public bool non_routable { get; set; }
        public bool bot { get; set; }
    }

}
