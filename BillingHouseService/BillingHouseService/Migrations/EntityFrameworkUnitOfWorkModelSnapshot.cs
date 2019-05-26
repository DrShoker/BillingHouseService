﻿// <auto-generated />
using System;
using BH.DAL.Repositories;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

namespace BH.WebApi.Migrations
{
    [DbContext(typeof(EntityFrameworkUnitOfWork))]
    partial class EntityFrameworkUnitOfWorkModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "2.1.11-servicing-32099")
                .HasAnnotation("Relational:MaxIdentifierLength", 128)
                .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

            modelBuilder.Entity("BH.DTOL.Entities.Company", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<string>("Description");

                    b.Property<string>("HomePageLink");

                    b.Property<string>("Name");

                    b.HasKey("Id");

                    b.ToTable("Company");
                });

            modelBuilder.Entity("BH.DTOL.Entities.CompanyConstructionMaterial", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<Guid>("CompanyId");

                    b.Property<Guid>("ConstructionMaterialId");

                    b.Property<decimal>("Price")
                        .HasColumnType("decimal");

                    b.HasKey("Id");

                    b.HasIndex("CompanyId");

                    b.HasIndex("ConstructionMaterialId");

                    b.ToTable("CompanyConstructionMaterial");
                });

            modelBuilder.Entity("BH.DTOL.Entities.CompanyConstructionWorks", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<Guid>("CompanyId");

                    b.Property<Guid>("ConstructionWorksId");

                    b.Property<decimal>("PricePerSquareMeter")
                        .HasColumnType("decimal");

                    b.HasKey("Id");

                    b.HasIndex("CompanyId");

                    b.HasIndex("ConstructionWorksId");

                    b.ToTable("CompanyConstructionWorks");
                });

            modelBuilder.Entity("BH.DTOL.Entities.CompanyConstructionWorksConstructionMaterial", b =>
                {
                    b.Property<Guid>("ConstructionMaterialId");

                    b.Property<Guid>("CompanyConstructionWorksId");

                    b.HasKey("ConstructionMaterialId", "CompanyConstructionWorksId");

                    b.HasIndex("CompanyConstructionWorksId");

                    b.ToTable("CompanyConstructionWorksConstructionMaterial");
                });

            modelBuilder.Entity("BH.DTOL.Entities.CompanyContactPhones", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<Guid>("CompanyId");

                    b.Property<string>("PhoneNumber");

                    b.HasKey("Id");

                    b.HasIndex("CompanyId");

                    b.ToTable("CompanyContactPhones");
                });

            modelBuilder.Entity("BH.DTOL.Entities.ConstructionMaterial", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<string>("Description");

                    b.Property<string>("Name");

                    b.Property<int>("TypeOfMaterial");

                    b.HasKey("Id");

                    b.ToTable("ConstructionMaterial");
                });

            modelBuilder.Entity("BH.DTOL.Entities.ConstructionWorks", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<string>("Description");

                    b.Property<string>("Name");

                    b.Property<int>("TypeOfWorks");

                    b.HasKey("Id");

                    b.ToTable("ConstructionWorks");
                });

            modelBuilder.Entity("BH.DTOL.Entities.ProjectScheme", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<decimal?>("CeilingArea")
                        .HasColumnType("decimal");

                    b.Property<decimal?>("CeilingPerimeter")
                        .HasColumnType("decimal");

                    b.Property<decimal?>("FloorArea")
                        .HasColumnType("decimal");

                    b.Property<decimal?>("FloorPerimeter")
                        .HasColumnType("decimal");

                    b.Property<string>("Name");

                    b.Property<Guid>("UserProjectId");

                    b.Property<decimal?>("WallsArea")
                        .HasColumnType("decimal");

                    b.HasKey("Id");

                    b.HasIndex("UserProjectId");

                    b.ToTable("ProjectScheme");
                });

            modelBuilder.Entity("BH.DTOL.Entities.SchemeConstructionWorks", b =>
                {
                    b.Property<Guid>("ConstructionWorksId");

                    b.Property<Guid>("SchemeId");

                    b.HasKey("ConstructionWorksId", "SchemeId");

                    b.HasIndex("SchemeId");

                    b.ToTable("SchemeConstructionWorks");
                });

            modelBuilder.Entity("BH.DTOL.Entities.SchemeWall", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<decimal>("Area")
                        .HasColumnType("decimal");

                    b.Property<Guid>("ProjectSchemeId");

                    b.Property<int>("Type");

                    b.HasKey("Id");

                    b.HasIndex("ProjectSchemeId");

                    b.ToTable("SchemeWall");
                });

            modelBuilder.Entity("BH.DTOL.Entities.User", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<string>("Email");

                    b.Property<string>("FirstName");

                    b.Property<string>("LastName");

                    b.Property<string>("Password");

                    b.HasKey("Id");

                    b.HasIndex("Email")
                        .IsUnique()
                        .HasFilter("[Email] IS NOT NULL");

                    b.ToTable("User");
                });

            modelBuilder.Entity("BH.DTOL.Entities.UserFeedbackAboutCompany", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<Guid>("CompanyId");

                    b.Property<DateTime>("DateOfCreation");

                    b.Property<string>("Message");

                    b.Property<Guid>("UserId");

                    b.HasKey("Id");

                    b.HasIndex("CompanyId");

                    b.HasIndex("UserId");

                    b.ToTable("UserFeedbackAboutCompany");
                });

            modelBuilder.Entity("BH.DTOL.Entities.UserProject", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<string>("Name");

                    b.Property<Guid>("UserId");

                    b.HasKey("Id");

                    b.HasIndex("UserId");

                    b.ToTable("UserProject");
                });

            modelBuilder.Entity("BH.DTOL.Entities.CompanyConstructionMaterial", b =>
                {
                    b.HasOne("BH.DTOL.Entities.Company", "Company")
                        .WithMany("ConstructionMaterials")
                        .HasForeignKey("CompanyId")
                        .OnDelete(DeleteBehavior.Cascade);

                    b.HasOne("BH.DTOL.Entities.ConstructionMaterial", "ConstructionMaterial")
                        .WithMany()
                        .HasForeignKey("ConstructionMaterialId")
                        .OnDelete(DeleteBehavior.Restrict);
                });

            modelBuilder.Entity("BH.DTOL.Entities.CompanyConstructionWorks", b =>
                {
                    b.HasOne("BH.DTOL.Entities.Company", "Company")
                        .WithMany("ConstructionWorks")
                        .HasForeignKey("CompanyId")
                        .OnDelete(DeleteBehavior.Cascade);

                    b.HasOne("BH.DTOL.Entities.ConstructionWorks", "ConstructionWorks")
                        .WithMany()
                        .HasForeignKey("ConstructionWorksId")
                        .OnDelete(DeleteBehavior.Restrict);
                });

            modelBuilder.Entity("BH.DTOL.Entities.CompanyConstructionWorksConstructionMaterial", b =>
                {
                    b.HasOne("BH.DTOL.Entities.CompanyConstructionWorks", "CompanyConstructionWorks")
                        .WithMany("CompanyConstructionWorksConstructionMaterials")
                        .HasForeignKey("CompanyConstructionWorksId")
                        .OnDelete(DeleteBehavior.Cascade);

                    b.HasOne("BH.DTOL.Entities.ConstructionMaterial", "ConstructionMaterial")
                        .WithMany("CompanyConstructionWorksConstructionMaterials")
                        .HasForeignKey("ConstructionMaterialId")
                        .OnDelete(DeleteBehavior.Cascade);
                });

            modelBuilder.Entity("BH.DTOL.Entities.CompanyContactPhones", b =>
                {
                    b.HasOne("BH.DTOL.Entities.Company", "Company")
                        .WithMany("ContactPhones")
                        .HasForeignKey("CompanyId")
                        .OnDelete(DeleteBehavior.Cascade);
                });

            modelBuilder.Entity("BH.DTOL.Entities.ProjectScheme", b =>
                {
                    b.HasOne("BH.DTOL.Entities.UserProject", "UserProject")
                        .WithMany("ProjectShemes")
                        .HasForeignKey("UserProjectId")
                        .OnDelete(DeleteBehavior.Cascade);
                });

            modelBuilder.Entity("BH.DTOL.Entities.SchemeConstructionWorks", b =>
                {
                    b.HasOne("BH.DTOL.Entities.ConstructionWorks", "ConstructionWorks")
                        .WithMany("SchemeConstructionWorks")
                        .HasForeignKey("ConstructionWorksId")
                        .OnDelete(DeleteBehavior.Cascade);

                    b.HasOne("BH.DTOL.Entities.ProjectScheme", "ProjectScheme")
                        .WithMany("SchemeConstructionWorks")
                        .HasForeignKey("SchemeId")
                        .OnDelete(DeleteBehavior.Cascade);
                });

            modelBuilder.Entity("BH.DTOL.Entities.SchemeWall", b =>
                {
                    b.HasOne("BH.DTOL.Entities.ProjectScheme", "ProjectScheme")
                        .WithMany("Walls")
                        .HasForeignKey("ProjectSchemeId")
                        .OnDelete(DeleteBehavior.Cascade);
                });

            modelBuilder.Entity("BH.DTOL.Entities.UserFeedbackAboutCompany", b =>
                {
                    b.HasOne("BH.DTOL.Entities.Company", "Company")
                        .WithMany("Feedbacks")
                        .HasForeignKey("CompanyId")
                        .OnDelete(DeleteBehavior.Cascade);

                    b.HasOne("BH.DTOL.Entities.User", "User")
                        .WithMany()
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Restrict);
                });

            modelBuilder.Entity("BH.DTOL.Entities.UserProject", b =>
                {
                    b.HasOne("BH.DTOL.Entities.User", "User")
                        .WithMany("UserProjects")
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade);
                });
#pragma warning restore 612, 618
        }
    }
}
