namespace FanficAPP.Models;

// FAÇA RELACAO N-N DIRETO SEM TABELA INTERMEDIARIA
// USANDO ICOLLECTION NAS DUAS TABELAS
public class FanficReadingList
{
    public Guid FanficID { get; set; }
    public Guid ReadingListID { get; set; }

    public Fanfic Fanfic { get; set; }
    public ReadingList ReadingList { get; set; }

}