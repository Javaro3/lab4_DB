namespace lab4.Models;

public partial class InsuranceAgent
{
    public int Id { get; set; }

    public string Name { get; set; } = null!;

    public string Surname { get; set; } = null!;

    public string MiddleName { get; set; } = null!;

    public int AgentType { get; set; }

    public decimal Salary { get; set; }

    public int Contract { get; set; }

    public double TransactionPercent { get; set; }

    public virtual AgentType AgentTypeNavigation { get; set; } = null!;

    public virtual Contract ContractNavigation { get; set; } = null!;
}
