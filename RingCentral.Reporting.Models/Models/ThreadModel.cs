namespace RingCentral.Reporting.Models
{
    public class ThreadModel
    {
        public long count { get; set; }
        public int limit { get; set; }
        public int offset { get; set; }
        public List<Record> records { get; set; }
    }


    // Root myDeserializedClass = JsonConvert.DeserializeObject<Root>(myJsonResponse);
    public class ExtraData
    {
        public string initial_page_title { get; set; }
        public string initial_page_url { get; set; }
        public int initial_page_visit_count { get; set; }
        public int initial_page_visit_started_at { get; set; }
        public int initial_visit_count { get; set; }
        public int initial_visit_started_at { get; set; }
        public object initial_custom_mcn_msg_test { get; set; }
        public string page_title { get; set; }
        public string page_url { get; set; }
        public int page_visit_count { get; set; }
        public int page_visit_started_at { get; set; }
        public int visit_count { get; set; }
        public int visit_started_at { get; set; }
        public object custom_mcn_msg_test { get; set; }
        public string trigger_id { get; set; }
        public string trigger_name { get; set; }
        public string close_cause { get; set; }
        public DateTime? closed_at { get; set; }
    }

    public class Record
    {
        public string id { get; set; }
        public DateTime? created_at { get; set; }
        public DateTime? updated_at { get; set; }
        public List<string> category_ids { get; set; }
        public bool closed { get; set; }
        public int contents_count { get; set; }
        public ExtraData extra_data { get; set; }
        public string foreign_id { get; set; }
        public int interventions_count { get; set; }
        public string source_id { get; set; }
        public List<string> thread_category_ids { get; set; }
        public string title { get; set; }
        public DateTime? last_content_at { get; set; }
        public DateTime? first_categorization_at { get; set; }
        public string first_content_id { get; set; }
        public string first_content_author_id { get; set; }
        public string last_content_id { get; set; }
        public List<string> intervention_user_ids { get; set; }
        public List<string> opened_intervention_user_ids { get; set; }
    }
}
