namespace csharp_atlas_rest.jira
{
    namespace Comments
    {
        public class Author
        {
            public string self { get; set; }
            public string name { get; set; }
            public string displayName { get; set; }
            public bool active { get; set; }
        }

        public class Comment
        {
            public string self { get; set; }
            public string id { get; set; }
            public Author author { get; set; }
            public string body { get; set; }
            public UpdateAuthor updateAuthor { get; set; }
            public string created { get; set; }
            public string updated { get; set; }
            public Visibility visibility { get; set; }

            public override string ToString()
            {
                return $"Comment: {id} : {author} : {body} : {created}";
            }
        }

        public class IssueCommentsResult
        {
            public int startAt { get; set; }
            public int maxResults { get; set; }
            public int total { get; set; }
            public List<Comment> comments { get; set; }
        }

        public class UpdateAuthor
        {
            public string self { get; set; }
            public string name { get; set; }
            public string displayName { get; set; }
            public bool active { get; set; }
            
            public override string ToString()
            {
                return $"UpdateAuthor: {name} : {displayName} : {active} ";
            }
        }

        public class Visibility
        {
            public string type { get; set; }
            public string value { get; set; }
        }
    }
}

