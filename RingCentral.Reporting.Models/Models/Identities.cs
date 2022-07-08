using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RingCentral.Reporting.Models.Identities
{
    public class IdentitiesModel
    {
        public int count { get; set; }
        public int limit { get; set; }
        public int offset { get; set; }
        public List<Record> records { get; set; }
    }

    // Root myDeserializedClass = JsonConvert.DeserializeObject<Root>(myJsonResponse);
    public class ExtraValues
    {
        public string question_key01 { get; set; }
        public string phone_no { get; set; }
        public string zip_code { get; set; }
        public string opt_msg_response { get; set; }
    }

    public class Record
    {
        public string id { get; set; }
        public DateTime created_at { get; set; }
        public DateTime updated_at { get; set; }
        public string community_id { get; set; }
        public object community_url { get; set; }
        public object company { get; set; }
        public string email { get; set; }
        public string firstname { get; set; }
        public string foreign_id { get; set; }
        public object gender { get; set; }
        public object home_phone { get; set; }
        public string identity_group_id { get; set; }
        public string lastname { get; set; }
        public object mobile_phone { get; set; }
        public string screenname { get; set; }
        public List<object> user_ids { get; set; }
        public string uuid { get; set; }
        public ExtraValues extra_values { get; set; }
        public string display_name { get; set; }
        public string avatar_url { get; set; }
        public string type { get; set; }
    }

   


}
