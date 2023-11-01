using lab4.Models;
using Microsoft.EntityFrameworkCore;

namespace lab4.Data;

public partial class InsuranceCompanyContext : DbContext
{
    public InsuranceCompanyContext()
    {
    }

    public InsuranceCompanyContext(DbContextOptions<InsuranceCompanyContext> options)
        : base(options)
    {
    }

    public virtual DbSet<AgentType> AgentTypes { get; set; }

    public virtual DbSet<Contract> Contracts { get; set; }

    public virtual DbSet<InsuranceAgent> InsuranceAgents { get; set; }
}