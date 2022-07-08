using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RingCentral.Reporting.Models.InterventionComment
{
    // Root myDeserializedClass = JsonConvert.DeserializeObject<Root>(myJsonResponse);
    public class Record
    {
        public string id { get; set; }
        public DateTime created_at { get; set; }
        public DateTime updated_at { get; set; }
        public string body { get; set; }
        public string identity_id { get; set; }
        public string intervention_id { get; set; }
        public string source_id { get; set; }
        public string thread_id { get; set; }
        public string user_id { get; set; }
    }

    public class InterventionCommentModel
    {
        public int count { get; set; }
        public int limit { get; set; }
        public int offset { get; set; }
        public List<Record> records { get; set; }
    }


}
