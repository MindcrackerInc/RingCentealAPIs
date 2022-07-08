using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RingCentral.Reporting.Models.Intervention
{
    // Root myDeserializedClass = JsonConvert.DeserializeObject<Root>(myJsonResponse);
    public class InterventionModel
    {
        public int count { get; set; }
        public int limit { get; set; }
        public int offset { get; set; }
        public List<Record> records { get; set; }
    }

    public class CustomFieldValues
    {
    }

    public class Record
    {
        public string id { get; set; }
        public DateTime created_at { get; set; }
        public DateTime updated_at { get; set; }
        public CustomFieldValues custom_field_values { get; set; }
        public List<string> category_ids { get; set; }
        public bool closed { get; set; }
        public DateTime? closed_at { get; set; }
        public int comments_count { get; set; }
        public string content_id { get; set; }
        public object deferred_at { get; set; }
        public int first_user_reply_in { get; set; }
        public int first_user_reply_in_bh { get; set; }
        public string identity_id { get; set; }
        public int last_user_reply_in { get; set; }
        public int last_user_reply_in_bh { get; set; }
        public string source_id { get; set; }
        public string thread_id { get; set; }
        public string user_id { get; set; }
        public int user_replies_count { get; set; }
        public int user_reply_in_average { get; set; }
        public int user_reply_in_average_bh { get; set; }
        public int user_reply_in_average_count { get; set; }
        public string first_user_reply_id { get; set; }
        public string status { get; set; }
        public object satisfaction_grade { get; set; }
        public DateTime? satisfaction_answered_at { get; set; }
        public DateTime? satisfaction_sent_at { get; set; }
        public string survey_response_id { get; set; }
        public string survey_id { get; set; }
    }
}
