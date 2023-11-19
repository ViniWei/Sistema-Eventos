﻿// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using Sistema_Eventos.Data;

#nullable disable

namespace Sistema_Eventos.Migrations
{
    [DbContext(typeof(SistemaEventosDbContext))]
    [Migration("20231119005423_IngressosDiponiveisEvento")]
    partial class IngressosDiponiveisEvento
    {
        /// <inheritdoc />
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder.HasAnnotation("ProductVersion", "7.0.11");

            modelBuilder.Entity("KitProduto", b =>
                {
                    b.Property<int>("KitsId")
                        .HasColumnType("INTEGER");

                    b.Property<int>("ProdutosId")
                        .HasColumnType("INTEGER");

                    b.HasKey("KitsId", "ProdutosId");

                    b.HasIndex("ProdutosId");

                    b.ToTable("KitProduto");
                });

            modelBuilder.Entity("PlanoUsuario", b =>
                {
                    b.Property<int>("PlanosId")
                        .HasColumnType("INTEGER");

                    b.Property<int>("UsuariosId")
                        .HasColumnType("INTEGER");

                    b.HasKey("PlanosId", "UsuariosId");

                    b.HasIndex("UsuariosId");

                    b.ToTable("PlanoUsuario");
                });

            modelBuilder.Entity("Sistema_Eventos.Models.Atuante", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("INTEGER");

                    b.Property<int?>("EventoId")
                        .HasColumnType("INTEGER");

                    b.Property<string>("Nome")
                        .HasColumnType("TEXT");

                    b.HasKey("Id");

                    b.HasIndex("EventoId");

                    b.ToTable("Atuante");
                });

            modelBuilder.Entity("Sistema_Eventos.Models.Evento", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("INTEGER");

                    b.Property<DateTime?>("Date")
                        .HasColumnType("TEXT");

                    b.Property<string>("Descricao")
                        .HasColumnType("TEXT");

                    b.Property<string>("Endereco")
                        .HasColumnType("TEXT");

                    b.Property<int?>("IngressosDisponiveis")
                        .HasColumnType("INTEGER");

                    b.Property<string>("Nome")
                        .HasColumnType("TEXT");

                    b.Property<int?>("OrganizadorId")
                        .HasColumnType("INTEGER");

                    b.HasKey("Id");

                    b.HasIndex("OrganizadorId");

                    b.ToTable("Evento");
                });

            modelBuilder.Entity("Sistema_Eventos.Models.Ingresso", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("INTEGER");

                    b.Property<int?>("EventoId")
                        .HasColumnType("INTEGER");

                    b.Property<float?>("Preco")
                        .HasColumnType("REAL");

                    b.Property<int?>("UsuarioId")
                        .HasColumnType("INTEGER");

                    b.HasKey("Id");

                    b.HasIndex("EventoId");

                    b.HasIndex("UsuarioId");

                    b.ToTable("Ingresso");
                });

            modelBuilder.Entity("Sistema_Eventos.Models.Kit", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("INTEGER");

                    b.Property<string>("Descricao")
                        .HasColumnType("TEXT");

                    b.Property<string>("Nome")
                        .HasColumnType("TEXT");

                    b.Property<int?>("OrganizadorId")
                        .HasColumnType("INTEGER");

                    b.Property<float?>("Preco")
                        .HasColumnType("REAL");

                    b.HasKey("Id");

                    b.HasIndex("OrganizadorId");

                    b.ToTable("Kit");
                });

            modelBuilder.Entity("Sistema_Eventos.Models.Organizador", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("INTEGER");

                    b.Property<string>("Email")
                        .HasColumnType("TEXT");

                    b.Property<string>("Nome")
                        .HasColumnType("TEXT");

                    b.Property<string>("Senha")
                        .HasColumnType("TEXT");

                    b.HasKey("Id");

                    b.ToTable("Organizador");
                });

            modelBuilder.Entity("Sistema_Eventos.Models.Plano", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("INTEGER");

                    b.Property<string>("Descricao")
                        .HasColumnType("TEXT");

                    b.Property<string>("Nome")
                        .HasColumnType("TEXT");

                    b.Property<int?>("OrganizadorId")
                        .HasColumnType("INTEGER");

                    b.Property<float?>("Preco")
                        .HasColumnType("REAL");

                    b.HasKey("Id");

                    b.HasIndex("OrganizadorId");

                    b.ToTable("Plano");
                });

            modelBuilder.Entity("Sistema_Eventos.Models.Produto", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("INTEGER");

                    b.Property<string>("Descricao")
                        .HasColumnType("TEXT");

                    b.Property<string>("Nome")
                        .HasColumnType("TEXT");

                    b.Property<int?>("OrganizadorId")
                        .HasColumnType("INTEGER");

                    b.Property<float?>("Preco")
                        .HasColumnType("REAL");

                    b.HasKey("Id");

                    b.HasIndex("OrganizadorId");

                    b.ToTable("Produto");
                });

            modelBuilder.Entity("Sistema_Eventos.Models.Usuario", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("INTEGER");

                    b.Property<string>("Cpf")
                        .HasColumnType("TEXT");

                    b.Property<DateOnly?>("DataNascimento")
                        .HasColumnType("TEXT");

                    b.Property<string>("Email")
                        .HasColumnType("TEXT");

                    b.Property<string>("Nome")
                        .HasColumnType("TEXT");

                    b.Property<string>("Senha")
                        .HasColumnType("TEXT");

                    b.HasKey("Id");

                    b.ToTable("Usuario");
                });

            modelBuilder.Entity("KitProduto", b =>
                {
                    b.HasOne("Sistema_Eventos.Models.Kit", null)
                        .WithMany()
                        .HasForeignKey("KitsId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("Sistema_Eventos.Models.Produto", null)
                        .WithMany()
                        .HasForeignKey("ProdutosId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("PlanoUsuario", b =>
                {
                    b.HasOne("Sistema_Eventos.Models.Plano", null)
                        .WithMany()
                        .HasForeignKey("PlanosId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("Sistema_Eventos.Models.Usuario", null)
                        .WithMany()
                        .HasForeignKey("UsuariosId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("Sistema_Eventos.Models.Atuante", b =>
                {
                    b.HasOne("Sistema_Eventos.Models.Evento", "Evento")
                        .WithMany()
                        .HasForeignKey("EventoId");

                    b.Navigation("Evento");
                });

            modelBuilder.Entity("Sistema_Eventos.Models.Evento", b =>
                {
                    b.HasOne("Sistema_Eventos.Models.Organizador", "Organizador")
                        .WithMany()
                        .HasForeignKey("OrganizadorId");

                    b.Navigation("Organizador");
                });

            modelBuilder.Entity("Sistema_Eventos.Models.Ingresso", b =>
                {
                    b.HasOne("Sistema_Eventos.Models.Evento", "Evento")
                        .WithMany()
                        .HasForeignKey("EventoId");

                    b.HasOne("Sistema_Eventos.Models.Usuario", "Usuario")
                        .WithMany()
                        .HasForeignKey("UsuarioId");

                    b.Navigation("Evento");

                    b.Navigation("Usuario");
                });

            modelBuilder.Entity("Sistema_Eventos.Models.Kit", b =>
                {
                    b.HasOne("Sistema_Eventos.Models.Organizador", "Organizador")
                        .WithMany()
                        .HasForeignKey("OrganizadorId");

                    b.Navigation("Organizador");
                });

            modelBuilder.Entity("Sistema_Eventos.Models.Plano", b =>
                {
                    b.HasOne("Sistema_Eventos.Models.Organizador", "Organizador")
                        .WithMany()
                        .HasForeignKey("OrganizadorId");

                    b.Navigation("Organizador");
                });

            modelBuilder.Entity("Sistema_Eventos.Models.Produto", b =>
                {
                    b.HasOne("Sistema_Eventos.Models.Organizador", "Organizador")
                        .WithMany()
                        .HasForeignKey("OrganizadorId");

                    b.Navigation("Organizador");
                });
#pragma warning restore 612, 618
        }
    }
}
