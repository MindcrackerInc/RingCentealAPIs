using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RingCentral.Reporting.Models.IdentityGroup
{

    // Root myDeserializedClass = JsonConvert.DeserializeObject<Root>(myJsonResponse);
    public class IdentityGroupModel
    {
        public int count { get; set; }
        public int limit { get; set; }
        public int offset { get; set; }
        public List<Record> records { get; set; }
    }

   
    public class CustomFieldValues
    {
        public List<string> source { get; set; }
        public List<string> state { get; set; }
        public object phone_number { get; set; }
        public string question_key01 { get; set; }
        public string zip_code { get; set; }
        public string campus { get; set; }
        public string poi { get; set; }
        public object order_no { get; set; }
        public string opt_msg_response { get; set; }
        public object url { get; set; }
        public object country { get; set; }
    }

    public class Record
    {
        public string id { get; set; }
        public DateTime created_at { get; set; }
        public DateTime updated_at { get; set; }
        public CustomFieldValues custom_field_values { get; set; }
        public string company { get; set; }
        public List<string> emails { get; set; }
        public string firstname { get; set; }
        public object gender { get; set; }
        public List<object> home_phones { get; set; }
        public List<string> identity_ids { get; set; }
        public string lastname { get; set; }
        public List<string> mobile_phones { get; set; }
        public string notes { get; set; }
        public bool read_only { get; set; }
        public List<object> tag_ids { get; set; }
        public string avatar_url { get; set; }
    }

   


}
