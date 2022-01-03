﻿// <auto-generated />
using System;
using CNPJ.Data.Context;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

namespace CNPJ.Data.Migrations
{
    [DbContext(typeof(ConsultCnpjDbContext))]
    partial class ConsultCnpjDbContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("Relational:MaxIdentifierLength", 128)
                .HasAnnotation("ProductVersion", "5.0.9")
                .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

            modelBuilder.Entity("CNPJ.Domain.DTO.ResponseApApiWsDTO", b =>
                {
                    b.Property<int>("ApId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<int>("EmpresaId")
                        .HasColumnType("int");

                    b.Property<int?>("ResponseApiWsDTOEmpresaId")
                        .HasColumnType("int");

                    b.Property<string>("code")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("text")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("ApId");

                    b.HasIndex("ResponseApiWsDTOEmpresaId");

                    b.ToTable("AtividadePrincipal");
                });

            modelBuilder.Entity("CNPJ.Domain.DTO.ResponseApiWsDTO", b =>
                {
                    b.Property<int>("EmpresaId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("Abertura")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Bairro")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Cep")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Cnpj")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Complemento")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("DataSituacao")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("DataSituacaoEspecial")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Efr")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Email")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Fantasia")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Logradouro")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("MotivoSituacao")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("MsgErro")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Municipio")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Nome")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Numero")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Porte")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Situacao")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("SituacaoEspecial")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Status")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Telefone")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Tipo")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Uf")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("capital_social")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("natureza_juridica")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("ultima_atualizacao")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("EmpresaId");

                    b.ToTable("Empresa");
                });

            modelBuilder.Entity("CNPJ.Domain.DTO.ResponseAsApiWsDTO", b =>
                {
                    b.Property<int>("AsId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<int>("EmpresaId")
                        .HasColumnType("int");

                    b.Property<int?>("ResponseApiWsDTOEmpresaId")
                        .HasColumnType("int");

                    b.Property<string>("code")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("text")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("AsId");

                    b.HasIndex("ResponseApiWsDTOEmpresaId");

                    b.ToTable("AtividadeSecundaria");
                });

            modelBuilder.Entity("CNPJ.Domain.DTO.ResponseQsaApiWsDTO", b =>
                {
                    b.Property<int>("DiretorId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<int>("EmpresaId")
                        .HasColumnType("int");

                    b.Property<string>("Nome")
                        .HasColumnType("nvarchar(max)");

                    b.Property<int?>("ResponseApiWsDTOEmpresaId")
                        .HasColumnType("int");

                    b.Property<string>("qual")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("DiretorId");

                    b.HasIndex("ResponseApiWsDTOEmpresaId");

                    b.ToTable("Diretor");
                });

            modelBuilder.Entity("CNPJ.Domain.DTO.ResponseApApiWsDTO", b =>
                {
                    b.HasOne("CNPJ.Domain.DTO.ResponseApiWsDTO", null)
                        .WithMany("atividade_principal")
                        .HasForeignKey("ResponseApiWsDTOEmpresaId");
                });

            modelBuilder.Entity("CNPJ.Domain.DTO.ResponseAsApiWsDTO", b =>
                {
                    b.HasOne("CNPJ.Domain.DTO.ResponseApiWsDTO", null)
                        .WithMany("atividades_secundarias")
                        .HasForeignKey("ResponseApiWsDTOEmpresaId");
                });

            modelBuilder.Entity("CNPJ.Domain.DTO.ResponseQsaApiWsDTO", b =>
                {
                    b.HasOne("CNPJ.Domain.DTO.ResponseApiWsDTO", null)
                        .WithMany("qsa")
                        .HasForeignKey("ResponseApiWsDTOEmpresaId");
                });

            modelBuilder.Entity("CNPJ.Domain.DTO.ResponseApiWsDTO", b =>
                {
                    b.Navigation("atividade_principal");

                    b.Navigation("atividades_secundarias");

                    b.Navigation("qsa");
                });
#pragma warning restore 612, 618
        }
    }
}
