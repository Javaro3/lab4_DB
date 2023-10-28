using System;
using System.Collections.Generic;

namespace lab4.Models;

public partial class AgentType
{
    public int Id { get; set; }

    public string Type { get; set; } = null!;

    public virtual ICollection<InsuranceAgent> InsuranceAgents { get; set; } = new List<InsuranceAgent>();
}
