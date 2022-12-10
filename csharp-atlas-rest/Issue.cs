namespace csharp_atlas_rest;


public class Issue
{
    public string Id { get; set; }
    public string Self { get; set; }
    public string Key { get; set; }
    public Field[] Fields { get; set; }

    public class Field
    {
        public string timespent { get; set; }
    }
}