namespace MAS.Backend.Entities;

public partial class Transaction
{
    public int IdTransaction { get; set; }
    public DateTime Date { get; set; }
    public float Amount { get; set; }
    public int IdAccount { get; set; }
    public int IdTransactionType { get; set; }
    public virtual TransactionType TransactionType { get; set; }
    public virtual Account Account { get; set; }
}