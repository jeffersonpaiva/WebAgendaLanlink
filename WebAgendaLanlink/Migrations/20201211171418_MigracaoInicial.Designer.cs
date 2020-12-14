﻿// <auto-generated />
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using WebAgendaLanlink.Context;

namespace WebAgendaLanlink.Migrations
{
    [DbContext(typeof(AppDbContext))]
    [Migration("20201211171418_MigracaoInicial")]
    partial class MigracaoInicial
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "2.1.14-servicing-32113")
                .HasAnnotation("Relational:MaxIdentifierLength", 128)
                .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

            modelBuilder.Entity("WebAgendaLanlink.Models.Contato", b =>
                {
                    b.Property<int>("ContatoId")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("Bairro")
                        .HasMaxLength(80);

                    b.Property<string>("Cidade")
                        .HasMaxLength(80);

                    b.Property<int>("CodigoAgp");

                    b.Property<int>("CodigoTipo");

                    b.Property<string>("Complemento")
                        .HasMaxLength(20);

                    b.Property<string>("NumeroEnd")
                        .HasMaxLength(10);

                    b.Property<int>("PessoaId");

                    b.Property<string>("TextoContato")
                        .HasMaxLength(120);

                    b.Property<string>("TipoAgp")
                        .HasMaxLength(20);

                    b.Property<string>("TipoContato")
                        .HasMaxLength(10);

                    b.Property<string>("TipoEnd")
                        .HasMaxLength(20);

                    b.Property<string>("UF")
                        .HasMaxLength(2);

                    b.HasKey("ContatoId");

                    b.HasIndex("PessoaId");

                    b.ToTable("Contatos");
                });

            modelBuilder.Entity("WebAgendaLanlink.Models.Pessoa", b =>
                {
                    b.Property<int>("PessoaId")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("Nome")
                        .HasMaxLength(120);

                    b.HasKey("PessoaId");

                    b.ToTable("Pessoas");
                });

            modelBuilder.Entity("WebAgendaLanlink.Models.Contato", b =>
                {
                    b.HasOne("WebAgendaLanlink.Models.Pessoa", "Pessoa")
                        .WithMany("Contatos")
                        .HasForeignKey("PessoaId")
                        .OnDelete(DeleteBehavior.Cascade);
                });
#pragma warning restore 612, 618
        }
    }
}
