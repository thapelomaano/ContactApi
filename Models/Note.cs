using System.ComponentModel.DataAnnotations;

public class Note
{
    public int Id { get; set; }
    public string Content { get; set; }
    public int ContactId { get; set; }

}
