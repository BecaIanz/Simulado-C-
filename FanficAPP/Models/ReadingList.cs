//título, uma data de última
// modificação e uma lista de fanfics que fazem parte da lista.

namespace FanficAPP.Models;

public class ReadingList
{
    public Guid ReadingListID { get; set; }
    public Guid UserId { get; set; }
    public string Title { get; set; }
    public DateTime LastModificationDate { get; set; }
    public ICollection<Fanfic> FanficList { get; set; }
    public ICollection<FanficReadingList> FanficReadingLists { get; set; }
    public User User { get; set; }
}