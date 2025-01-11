namespace WOW.RealmList.Manager.Domain;

public class Entity
{
    public int Id { get; set; }
    
    public DateTime CreatedAt { get; set; }
    
    public DateTime UpdatedAt { get; set; }
}

public class Server : Entity
{
    public required string Name { get; set; }

    public required List<RealmList> Realmlists { get; set; }
}

public class RealmList : Entity
{
    public required string Name { get; set; }
    public required string Address { get; set; }

    public string? Description { get; set; }
    
    public required List<Account> Accounts { get; set; }
    
    public int ServerId { get; set; }
}

public class Account : Entity
{
    public required string Login { get; set; }
    
    public string? Password { get; set; }
    
    public string? Description { get; set; }
    public int RealmListId { get; set; }
}
