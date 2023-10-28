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

    protected override void OnModelCreating(ModelBuilder modelBuilder) {
        modelBuilder.Entity<InsuranceAgent>(entity => {
            entity.HasOne(d => d.AgentTypeNavigation).WithMany(p => p.InsuranceAgents)
                .HasForeignKey(d => d.AgentType)
                .OnDelete(DeleteBehavior.ClientSetNull);

            entity.HasOne(d => d.ContractNavigation).WithMany(p => p.InsuranceAgents)
                .HasForeignKey(d => d.Contract)
                .OnDelete(DeleteBehavior.ClientSetNull);
        });

        OnModelCreatingPartial(modelBuilder);
    }

    partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
}
