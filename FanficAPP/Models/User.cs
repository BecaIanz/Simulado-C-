//Email, Nome de Usuário, Senha, Descrição do Autor e Data de criação da conta
namespace FanficAPP.Models;

public class User
{
    public Guid UserID { get; set; }
    public string Username { get; set; }
    public string Password { get; set; }
    public string Email { get; set; }
    public string AuthorBio { get; set; }
    public string CriationDate { get; set; }
    
    
    public ICollection<Fanfic> Fanfics { get; set; }
    public ICollection<ReadingList> ReadingLists { get; set; }
}