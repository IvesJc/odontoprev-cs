using Microsoft.EntityFrameworkCore;
using WebApplication2.Models;

namespace WebApplication2.AppData;

public class ApplicationContext : DbContext
{
    public DbSet<BeneficiarioEntity> Beneficiario { get; set; }
    public DbSet<EmpresaContratanteEntity> EmpresaContratante { get; set; }
    public DbSet<EnderecoEntity> Endereco { get; set; }
    public DbSet<MissaoEntity> Missao { get; set; }
    public DbSet<PlanoEntity> Plano { get; set; }
    public DbSet<PrestadorServicoEntity> PrestadorServico { get; set; }
    public DbSet<ProgramaRelacionamentoStatusEntity> ProgramaRelacionamentoStatus { get; set; }
    public DbSet<RecompensaEntity> Recompensa { get; set; }
    public DbSet<RedeCredenciadaEntity> RedeCredenciada { get; set; }
    public DbSet<ServicoEntity> Servico { get; set; }
    public DbSet<SinistroEntity> Sinistro { get; set; }
    public DbSet<TipoMissaoEntity> TipoMissao { get; set; }
    public DbSet<TipoPlanoEntity> TipoPlano { get; set; }
    public DbSet<TipoRecompensaEntity> TipoRecompensa { get; set; }
    public DbSet<TipoServicoEntity> TipoServico { get; set; }

    public ApplicationContext(DbContextOptions options) : base(options)
    {
    }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<BeneficiarioEntity>()
            .HasOne(b => b.ProgramaRelacionamentoStatus)
            .WithOne(prs => prs.Beneficiario);

        modelBuilder.Entity<BeneficiarioEntity>()
            .HasOne(b => b.Endereco)
            .WithOne(e => e.Beneficiario);

        modelBuilder.Entity<BeneficiarioEntity>()
            .HasMany(b => b.Planos)
            .WithMany(p => p.Beneficiarios);

        modelBuilder.Entity<BeneficiarioEntity>()
            .HasMany(b => b.Sinistros)
            .WithOne(s => s.Beneficiario);

        modelBuilder.Entity<BeneficiarioEntity>()
            .HasMany(b => b.Missoes)
            .WithOne(m => m.Beneficiario);

        modelBuilder.Entity<BeneficiarioEntity>()
            .HasMany(b => b.Recompensas)
            .WithOne(r => r.Beneficiario);

        modelBuilder.Entity<BeneficiarioEntity>()
            .HasOne(b => b.EmpresaContratante)
            .WithMany(ec => ec.Beneficiarios);

        modelBuilder.Entity<EmpresaContratanteEntity>()
            .HasMany(ec => ec.Planos)
            .WithOne(p => p.EmpresaContratante);

        modelBuilder.Entity<EmpresaContratanteEntity>()
            .HasMany(ec => ec.Beneficiarios)
            .WithOne(b => b.EmpresaContratante);

        modelBuilder.Entity<EnderecoEntity>()
            .HasOne(e => e.Beneficiario)
            .WithOne(b => b.Endereco);

        modelBuilder.Entity<EnderecoEntity>()
            .HasOne(e => e.RedeCredenciada)
            .WithMany(rc => rc.Enderecos);

        modelBuilder.Entity<MissaoEntity>()
            .HasOne(m => m.TipoMissao)
            .WithMany(tm => tm.Missoes);

        modelBuilder.Entity<MissaoEntity>()
            .HasOne(m => m.Beneficiario)
            .WithMany(b => b.Missoes);

        modelBuilder.Entity<PlanoEntity>()
            .HasOne(p => p.EmpresaContratante)
            .WithMany(ec => ec.Planos);

        modelBuilder.Entity<PlanoEntity>()
            .HasOne(p => p.TipoPlano)
            .WithMany(tp => tp.Planos);

        modelBuilder.Entity<PlanoEntity>()
            .HasMany(p => p.Beneficiarios)
            .WithMany(b => b.Planos);

        modelBuilder.Entity<PrestadorServicoEntity>()
            .HasOne(ps => ps.RedeCredenciada)
            .WithMany(rc => rc.PrestadorServicos);

        modelBuilder.Entity<PrestadorServicoEntity>()
            .HasMany(ps => ps.TipoServicos)
            .WithMany(ts => ts.PrestadorServicos);

        modelBuilder.Entity<PrestadorServicoEntity>()
            .HasMany(ps => ps.Sinistros)
            .WithOne(s => s.PrestadorServico);

        modelBuilder.Entity<ProgramaRelacionamentoStatusEntity>()
            .HasOne(prs => prs.Beneficiario)
            .WithOne(b => b.ProgramaRelacionamentoStatus);

        modelBuilder.Entity<RecompensaEntity>()
            .HasOne(r => r.Beneficiario)
            .WithMany(b => b.Recompensas);

        modelBuilder.Entity<RecompensaEntity>()
            .HasOne(r => r.TipoRecompensa)
            .WithMany(tr => tr.Recompensas);

        modelBuilder.Entity<RedeCredenciadaEntity>()
            .HasMany(rc => rc.Enderecos)
            .WithOne(e => e.RedeCredenciada);

        modelBuilder.Entity<RedeCredenciadaEntity>()
            .HasMany(rc => rc.PrestadorServicos)
            .WithOne(ps => ps.RedeCredenciada);

        modelBuilder.Entity<ServicoEntity>()
            .HasOne(s => s.TipoServico)
            .WithMany(ts => ts.Servicos);

        modelBuilder.Entity<ServicoEntity>()
            .HasOne(s => s.Sinistro)
            .WithMany(s => s.Servicos);

        modelBuilder.Entity<SinistroEntity>()
            .HasOne(s => s.Beneficiario)
            .WithMany(b => b.Sinistros);

        modelBuilder.Entity<SinistroEntity>()
            .HasOne(s => s.PrestadorServico)
            .WithMany(ps => ps.Sinistros);

        modelBuilder.Entity<SinistroEntity>()
            .HasMany(s => s.Servicos)
            .WithOne(s => s.Sinistro);

        modelBuilder.Entity<TipoMissaoEntity>()
            .HasMany(tm => tm.Missoes)
            .WithOne(m => m.TipoMissao);

        modelBuilder.Entity<TipoPlanoEntity>()
            .HasMany(tp => tp.TipoServicos)
            .WithMany(ts => ts.TipoPlanos);

        modelBuilder.Entity<TipoPlanoEntity>()
            .HasMany(tp => tp.Planos)
            .WithOne(p => p.TipoPlano);

        modelBuilder.Entity<TipoRecompensaEntity>()
            .HasMany(tr => tr.Recompensas)
            .WithOne(r => r.TipoRecompensa);

        modelBuilder.Entity<TipoServicoEntity>()
            .HasMany(ts => ts.TipoPlanos)
            .WithMany(tp => tp.TipoServicos);

        modelBuilder.Entity<TipoServicoEntity>()
            .HasMany(ts => ts.Servicos)
            .WithOne(s => s.TipoServico);

        modelBuilder.Entity<TipoServicoEntity>()
            .HasMany(ts => ts.PrestadorServicos)
            .WithMany(ps => ps.TipoServicos);
    }
}