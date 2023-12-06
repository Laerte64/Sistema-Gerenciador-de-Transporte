using Microsoft.EntityFrameworkCore;
using SistemaGerenciadorDeTransportes.Model;

namespace SistemaGerenciadorDeTransportes.Data
{
    class SistemaTransporteContexto : DbContext
    {
        private static SistemaTransporteContexto? _instancia;

        public DbSet<Usuario> Usuarios { get; set; }
        public DbSet<Passageiro> Passageiros { get; set; }
        public DbSet<Empresa> Empresas { get; set; }

        public DbSet<Modalidade> Modalidades { get; set; }
        public DbSet<Veiculo> Veiculos { get; set; }

        public DbSet<Pais> Paises { get; set; }
        public DbSet<Estado> Estados { get; set; }
        public DbSet<Cidade> Cidades { get; set; }

        public DbSet<Viagem> Viagens { get; set; }

        public SistemaTransporteContexto() { }

        public static SistemaTransporteContexto AdquirirContexto()
        {
            if (_instancia == null)
                _instancia = new SistemaTransporteContexto();
            return _instancia;
        }
        public static void EncerrarContexto()
        {
            _instancia = null;
        }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseMySql("Server=localhost;Database=db_sistematransporte;User=admin;Password=admin1234;", new MySqlServerVersion(new Version(8, 0, 23)));
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Usuario>()
                .HasKey(u => u.UsuarioId);
            modelBuilder.Entity<Usuario>()
                .HasIndex(u => u.Nome)
                .IsUnique();
            modelBuilder.Entity<Usuario>()
                .Property(u => u.Senha)
                .IsRequired();

            modelBuilder.Entity<Passageiro>()
                .Property(p => p.CPF)
                .IsRequired();

            modelBuilder.Entity<Empresa>()
                .Property(e => e.CNPJ)
                .IsRequired();

            modelBuilder.Entity<Modalidade>()
                .HasKey(m => m.ModalidadeId);
            modelBuilder.Entity<Modalidade>()
                .HasIndex(m => m.Nome)
                .IsUnique();

            modelBuilder.Entity<Veiculo>()
                .HasKey(v => v.VeiculoId);
            modelBuilder.Entity<Veiculo>()
                .Property(v =>v.Identificacao).IsRequired();
            modelBuilder.Entity<Veiculo>()
                .HasOne(v => v.Empresa)
                .WithMany(e => e.Veiculos)
                .HasForeignKey(v => v.EmpresaId)
                .OnDelete(DeleteBehavior.Cascade);
            modelBuilder.Entity<Veiculo>()
                .HasOne(v => v.Modalidade)
                .WithMany(m => m.Veiculos)
                .HasForeignKey(v => v.ModalidadeId)
                .OnDelete(DeleteBehavior.Cascade);
            modelBuilder.Entity<Veiculo>()
                .Property(v => v.Capacidade)
                .IsRequired();

            modelBuilder.Entity<Pais>()
                .HasKey(p => p.PaisId);
            modelBuilder.Entity<Pais>()
                .HasIndex(p => p.Nome)
                .IsUnique();
            
            modelBuilder.Entity<Estado>()
                .HasKey(e => e.EstadoId);
            modelBuilder.Entity<Estado>()
                .Property(e => e.Nome)
                .IsRequired();
            modelBuilder.Entity<Estado>()
                .HasOne(e => e.Pais)
                .WithMany(p => p.Estados)
                .HasForeignKey(e => e.PaisId)
                .OnDelete(DeleteBehavior.Cascade);

            modelBuilder.Entity<Cidade>()
                .HasKey(c => c.CidadeId);
            modelBuilder.Entity<Cidade>()
                .Property(c => c.Nome)
                .IsRequired();
            modelBuilder.Entity<Cidade>()
                .HasOne(c => c.Estado)
                .WithMany(e => e.Cidades)
                .HasForeignKey(c => c.EstadoId)
                .OnDelete(DeleteBehavior.Cascade);


            modelBuilder.Entity<Viagem>()
                .HasKey(v => v.ViagemId);
            modelBuilder.Entity<Viagem>()
                .HasOne(v => v.Veiculo)
                .WithMany(v => v.Viagens)
                .HasForeignKey(v => v.VeiculoId)
                .OnDelete(DeleteBehavior.Cascade);
            modelBuilder.Entity<Viagem>()
                .HasOne(v => v.CidadePartida)
                .WithMany()
                .HasForeignKey(v => v.CidadePartidaId)
                .OnDelete(DeleteBehavior.Cascade);
            modelBuilder.Entity<Viagem>()
                .HasOne(v => v.CidadeChegada)
                .WithMany()
                .HasForeignKey(v => v.CidadeChegadaId)
                .OnDelete(DeleteBehavior.Cascade);
            modelBuilder.Entity<Viagem>()
                .Property(v => v.Data)
                .IsRequired();
            modelBuilder.Entity<Viagem>()
                .HasMany(v => v.Passageiros)
                .WithMany(p => p.Viagens)
                .UsingEntity(j => j.ToTable("tb_passageiro_viagem"));
        }

    }
}