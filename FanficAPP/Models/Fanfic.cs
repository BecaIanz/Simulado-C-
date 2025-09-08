//título e texto
namespace FanficAPP.Models;

public class Fanfic
{
    public Guid FanficID { get; set; }
    public Guid UserId { get; set; }
    public string Title { get; set; }
    public string Text { get; set; }

    public User User { get; set; }
}