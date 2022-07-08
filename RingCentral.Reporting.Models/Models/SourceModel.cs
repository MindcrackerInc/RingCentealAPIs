using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RingCentral.Reporting.Models.Sources
{

    public class SourceModel
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
        public bool active { get; set; }
        public string community_id { get; set; }
        public string channel_id { get; set; }
        public string name { get; set; }
        public string status { get; set; }
        public int color { get; set; }
        public int sla_response { get; set; }
        public string sla_expired_strategy { get; set; }
        public int intervention_messages_boost { get; set; }
        public string transferred_tasks_boost { get; set; }
        public bool hidden_from_stats { get; set; }
        public List<string> default_category_ids { get; set; }
        public List<string> user_thread_default_category_ids { get; set; }
        public string default_content_language { get; set; }
        public bool auto_detect_content_language { get; set; }
        public List<string> time_sheet_ids { get; set; }
        public int? content_archiving_period { get; set; }
        public List<string> content_languages { get; set; }
        public string type { get; set; }
        public object error_message { get; set; }
        public bool live_chat { get; set; }
        public bool enable_android { get; set; }
        public bool enable_ios { get; set; }
        public bool enable_web { get; set; }
    }

}
