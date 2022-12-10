namespace csharp_atlas_rest;

public class CreateIssue
{
    public Fields fields { get; set; }
}

public class Fields
{
    public string Summary { get; set; }
    public string Description { get; set; }
    public Project Project { get; set; }
    public IssueType issueType { get; set; }
    
}

public class Project
{
    public string Id { get; set; }
}

public class IssueType
{
    public string Id { get; set; }
}