﻿// <auto-generated />
using Emp.Data;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage;
using Microsoft.EntityFrameworkCore.Storage.Internal;
using System;

namespace Emp.Migrations
{
    [DbContext(typeof(EmpDBContext))]
    [Migration("20180309172512_Initial")]
    partial class Initial
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "2.0.1-rtm-125")
                .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

            modelBuilder.Entity("Emp.Data.Entity.EvidenciaZamestnanca", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<DateTime>("DatumNastupu");

                    b.Property<DateTime?>("DatumUkoncenia");

                    b.Property<float>("Plat");

                    b.Property<int>("PoziciaId");

                    b.Property<int>("ZamestnanecId");

                    b.HasKey("Id");

                    b.HasIndex("PoziciaId");

                    b.HasIndex("ZamestnanecId");

                    b.ToTable("EvidenciaZamestnancov");
                });

            modelBuilder.Entity("Emp.Data.Entity.Pozicia", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<string>("Nazov")
                        .IsRequired();

                    b.Property<bool>("Vymazana");

                    b.HasKey("Id");

                    b.ToTable("Pozicie");
                });

            modelBuilder.Entity("Emp.Data.Entity.Zamestnanec", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<string>("Adresa");

                    b.Property<DateTime>("DatumNarodenia");

                    b.Property<string>("Meno")
                        .IsRequired();

                    b.Property<string>("Priezvisko")
                        .IsRequired();

                    b.HasKey("Id");

                    b.ToTable("Zamestnanci");
                });

            modelBuilder.Entity("Emp.Data.Entity.EvidenciaZamestnanca", b =>
                {
                    b.HasOne("Emp.Data.Entity.Pozicia", "Pozicia")
                        .WithMany("EvidenciaZamestnanca")
                        .HasForeignKey("PoziciaId")
                        .OnDelete(DeleteBehavior.Cascade);

                    b.HasOne("Emp.Data.Entity.Zamestnanec", "Zamestnanec")
                        .WithMany("EvidenciaZamestnanca")
                        .HasForeignKey("ZamestnanecId")
                        .OnDelete(DeleteBehavior.Cascade);
                });
#pragma warning restore 612, 618
        }
    }
}
