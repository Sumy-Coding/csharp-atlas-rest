using System.Text.Json.Serialization;

namespace csharp_atlas_rest.jira
{
    public class Issue
    {
        public string expand { get; set; }
        public string id { get; set; }
        public string self { get; set; }
        public string key { get; set; }
        public Fields fields { get; set; }

        public override string ToString()
        {
            return $"Issue: {id} {self} {key} {fields}";
        }
    }
    public class Aggregateprogress
    {
        public int progress { get; set; }
        public int total { get; set; }
    }

    public class AvatarUrls
    {
        [JsonPropertyName("48x48")]
        public string _48x48 { get; set; }

        [JsonPropertyName("24x24")]
        public string _24x24 { get; set; }

        [JsonPropertyName("16x16")]
        public string _16x16 { get; set; }

        [JsonPropertyName("32x32")]
        public string _32x32 { get; set; }
    }

    public class Comment
    {
        public List<object> comments { get; set; }
        public int maxResults { get; set; }
        public int total { get; set; }
        public int startAt { get; set; }
    }

    public class Creator
    {
        public string self { get; set; }
        public string name { get; set; }
        public string key { get; set; }
        public string emailAddress { get; set; }
        public AvatarUrls avatarUrls { get; set; }
        public string displayName { get; set; }
        public bool active { get; set; }
        public string timeZone { get; set; }
    }

    public class Fields
    {
        public Issuetype issuetype { get; set; }
        public object timespent { get; set; }
        public Project project { get; set; }
        public List<object> fixVersions { get; set; }
        public object customfield_10111 { get; set; }
        public object aggregatetimespent { get; set; }
        public object resolution { get; set; }
        public object customfield_10107 { get; set; }
        public object customfield_10108 { get; set; }
        public string customfield_10109 { get; set; }
        public object resolutiondate { get; set; }
        public int workratio { get; set; }
        public string lastViewed { get; set; }
        public Watches watches { get; set; }
        public string created { get; set; }
        public Priority priority { get; set; }
        public object customfield_10100 { get; set; }
        public object customfield_10101 { get; set; }
        public object customfield_10102 { get; set; }
        public List<object> labels { get; set; }
        public object customfield_10103 { get; set; }
        public object timeestimate { get; set; }
        public object aggregatetimeoriginalestimate { get; set; }
        public List<object> versions { get; set; }
        public List<object> issuelinks { get; set; }
        public object assignee { get; set; }
        public string updated { get; set; }
        public Status status { get; set; }
        public List<object> components { get; set; }
        public object timeoriginalestimate { get; set; }
        public string description { get; set; }
        public Timetracking timetracking { get; set; }
        public object archiveddate { get; set; }
        public List<object> attachment { get; set; }
        public object aggregatetimeestimate { get; set; }
        public string summary { get; set; }
        public Creator creator { get; set; }
        public List<Subtask> subtasks { get; set; }
        public Reporter reporter { get; set; }
        public string customfield_10000 { get; set; }
        public Aggregateprogress aggregateprogress { get; set; }
        public object environment { get; set; }
        public object duedate { get; set; }
        public Progress progress { get; set; }
        public Comment comment { get; set; }
        public Votes votes { get; set; }
        public Worklog worklog { get; set; }
        public object archivedby { get; set; }
    }

    public class Issuetype
    {
        public string self { get; set; }
        public string id { get; set; }
        public string description { get; set; }
        public string iconUrl { get; set; }
        public string name { get; set; }
        public bool subtask { get; set; }
        public int avatarId { get; set; }
    }

    public class Priority
    {
        public string self { get; set; }
        public string iconUrl { get; set; }
        public string name { get; set; }
        public string id { get; set; }
    }

    public class Progress
    {
        public int progress { get; set; }
        public int total { get; set; }
    }

    public class Project
    {
        public string self { get; set; }
        public string id { get; set; }
        public string key { get; set; }
        public string name { get; set; }
        public string projectTypeKey { get; set; }
        public AvatarUrls avatarUrls { get; set; }
    }

    public class Reporter
    {
        public string self { get; set; }
        public string name { get; set; }
        public string key { get; set; }
        public string emailAddress { get; set; }
        public AvatarUrls avatarUrls { get; set; }
        public string displayName { get; set; }
        public bool active { get; set; }
        public string timeZone { get; set; }
    }

    

    public class Status
    {
        public string self { get; set; }
        public string description { get; set; }
        public string iconUrl { get; set; }
        public string name { get; set; }
        public string id { get; set; }
        public StatusCategory statusCategory { get; set; }
    }

    public class StatusCategory
    {
        public string self { get; set; }
        public int id { get; set; }
        public string key { get; set; }
        public string colorName { get; set; }
        public string name { get; set; }
    }

    public class Subtask
    {
        public string id { get; set; }
        public string key { get; set; }
        public string self { get; set; }
        public Fields fields { get; set; }
    }

    public class Timetracking
    {
    }

    public class Votes
    {
        public string self { get; set; }
        public int votes { get; set; }
        public bool hasVoted { get; set; }
    }

    public class Watches
    {
        public string self { get; set; }
        public int watchCount { get; set; }
        public bool isWatching { get; set; }
    }

    public class Worklog
    {
        public int startAt { get; set; }
        public int maxResults { get; set; }
        public int total { get; set; }
        public List<object> worklogs { get; set; }
    }


    namespace Create
    {
        public class CreateIssue
        {
            public string Id { get; set; }
            public string Self { get; set; }
            public string Key { get; set; }
            public Fields Fields { get; set; }
        }  
    
        public class Fields
        {
            public string Summary { get; set; }
            public string Description { get; set; }
            public Project Project { get; set; }
            public Issuetype Issuetype { get; set; }
        }

        public class Issuetype
        {
            public string Name { get; set; }
        }

        public class Project
        {
            public string Name { get; set; }
        }
    }
    
}

