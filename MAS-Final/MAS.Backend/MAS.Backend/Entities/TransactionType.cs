namespace MAS.Backend.Entities;

public partial class TransactionType
{
    public int IdTransactionType { get; set; }
    public string Type { get; set; }

    public virtual ICollection<Transaction> Transactions { get; set; } = new List<Transaction>();
}