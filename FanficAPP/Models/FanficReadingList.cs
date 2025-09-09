namespace FanficAPP.Models;

public class FanficReadingList
{
    public int FanficID { get; set; }
    public int ReadingListID { get; set; }

    public Fanfic Fanfic { get; set; }
    public ReadingList ReadingList { get; set; }

}