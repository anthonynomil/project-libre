﻿// <auto-generated />
using System;
using Infrastructure.Database;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

#nullable disable

namespace Database.Migrations
{
    [DbContext(typeof(ProjetLibreContext))]
    [Migration("20240315104001_UserRole")]
    partial class UserRole
    {
        /// <inheritdoc />
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "8.0.2")
                .HasAnnotation("Relational:MaxIdentifierLength", 64);

            modelBuilder.Entity("Entities.Address", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    b.Property<int>("CityId")
                        .HasColumnType("int");

                    b.Property<int>("Number")
                        .HasColumnType("int");

                    b.Property<string>("NumberComplement")
                        .HasColumnType("longtext");

                    b.Property<string>("Road")
                        .IsRequired()
                        .HasColumnType("longtext");

                    b.HasKey("Id");

                    b.HasIndex("CityId");

                    b.ToTable("Address");
                });

            modelBuilder.Entity("Entities.BankDetails", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    b.Property<string>("Bic")
                        .HasColumnType("longtext");

                    b.Property<string>("Iban")
                        .HasColumnType("longtext");

                    b.HasKey("Id");

                    b.ToTable("BankDetails");
                });

            modelBuilder.Entity("Entities.City", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("longtext");

                    b.Property<string>("PostalCode")
                        .IsRequired()
                        .HasColumnType("longtext");

                    b.HasKey("Id");

                    b.ToTable("City");
                });

            modelBuilder.Entity("Entities.ClientContact", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    b.Property<int?>("AddressId")
                        .HasColumnType("int");

                    b.Property<DateTime?>("Birthdate")
                        .HasColumnType("datetime(6)");

                    b.Property<int?>("CompanyId")
                        .HasColumnType("int");

                    b.Property<int?>("ContactInformationId")
                        .HasColumnType("int");

                    b.Property<int?>("CountryId")
                        .HasColumnType("int");

                    b.Property<string>("Firstname")
                        .IsRequired()
                        .HasColumnType("longtext");

                    b.Property<string>("Lastname")
                        .IsRequired()
                        .HasColumnType("longtext");

                    b.HasKey("Id");

                    b.HasIndex("AddressId");

                    b.HasIndex("CompanyId");

                    b.HasIndex("ContactInformationId");

                    b.HasIndex("CountryId");

                    b.ToTable("ClientContact");
                });

            modelBuilder.Entity("Entities.ClientFinancialInformation", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    b.Property<int>("Budget")
                        .HasColumnType("int");

                    b.Property<int>("PaymentMethod")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.ToTable("ClientFinancialInformation");
                });

            modelBuilder.Entity("Entities.ClientMission", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    b.Property<int?>("CompanyId")
                        .HasColumnType("int");

                    b.Property<int?>("ProjectId")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.HasIndex("CompanyId");

                    b.HasIndex("ProjectId");

                    b.ToTable("ClientMission");
                });

            modelBuilder.Entity("Entities.ClientMissionCommunication", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    b.Property<int?>("ClientMissionId")
                        .HasColumnType("int");

                    b.Property<DateTime>("Date")
                        .HasColumnType("datetime(6)");

                    b.Property<string>("Note")
                        .HasColumnType("longtext");

                    b.Property<int>("Type")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.HasIndex("ClientMissionId");

                    b.ToTable("ClientMissionCommunication");
                });

            modelBuilder.Entity("Entities.ClientMissionContract", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    b.Property<int?>("ClientMissionId")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.HasIndex("ClientMissionId");

                    b.ToTable("ClientMissionContract");
                });

            modelBuilder.Entity("Entities.ClientMissionProject", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    b.Property<DateTime?>("Deadline")
                        .HasColumnType("datetime(6)");

                    b.Property<string>("Description")
                        .HasColumnType("longtext");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("longtext");

                    b.Property<int>("Status")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.ToTable("ClientMissionProject");
                });

            modelBuilder.Entity("Entities.ClientMissionProjectMilestone", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    b.Property<int?>("ClientMissionProjectId")
                        .HasColumnType("int");

                    b.Property<DateTime>("End")
                        .HasColumnType("datetime(6)");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("longtext");

                    b.Property<DateTime>("Start")
                        .HasColumnType("datetime(6)");

                    b.HasKey("Id");

                    b.HasIndex("ClientMissionProjectId");

                    b.ToTable("ClientMissionProjectMilestone");
                });

            modelBuilder.Entity("Entities.ClientMissionSpecialRequest", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    b.Property<int?>("ClientMissionId")
                        .HasColumnType("int");

                    b.Property<DateTime>("Date")
                        .HasColumnType("datetime(6)");

                    b.Property<string>("Description")
                        .IsRequired()
                        .HasColumnType("longtext");

                    b.HasKey("Id");

                    b.HasIndex("ClientMissionId");

                    b.ToTable("ClientMissionSpecialRequest");
                });

            modelBuilder.Entity("Entities.Company", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    b.Property<int?>("AddressId")
                        .HasColumnType("int");

                    b.Property<int?>("BankDetailsId")
                        .HasColumnType("int");

                    b.Property<string>("BusinessName")
                        .IsRequired()
                        .HasColumnType("longtext");

                    b.Property<int?>("CountryId")
                        .HasColumnType("int");

                    b.Property<int?>("FinancialInformationId")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.HasIndex("AddressId");

                    b.HasIndex("BankDetailsId");

                    b.HasIndex("CountryId");

                    b.HasIndex("FinancialInformationId");

                    b.ToTable("Company");
                });

            modelBuilder.Entity("Entities.CompanyFranceSpecifics", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    b.Property<string>("CodeSiret")
                        .HasColumnType("longtext");

                    b.Property<int>("CompanyId")
                        .HasColumnType("int");

                    b.Property<string>("NomenclatureActiviteFrancaise")
                        .HasColumnType("longtext");

                    b.Property<string>("NumeroTea")
                        .HasColumnType("longtext");

                    b.Property<string>("Rib")
                        .HasColumnType("longtext");

                    b.Property<string>("Siren")
                        .HasColumnType("longtext");

                    b.HasKey("Id");

                    b.HasIndex("CompanyId");

                    b.ToTable("CompanyFranceSpecifics");
                });

            modelBuilder.Entity("Entities.CompanyUsaSpecifics", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    b.Property<string>("CentralIndexKey")
                        .HasColumnType("longtext");

                    b.Property<int>("CompanyId")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.HasIndex("CompanyId");

                    b.ToTable("CompanyUsaSpecifics");
                });

            modelBuilder.Entity("Entities.ContactInformation", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    b.Property<string>("MailAddress")
                        .HasColumnType("longtext");

                    b.Property<string>("PhoneNumber")
                        .HasColumnType("longtext");

                    b.HasKey("Id");

                    b.ToTable("ContactInformation");
                });

            modelBuilder.Entity("Entities.Country", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("longtext");

                    b.HasKey("Id");

                    b.ToTable("Country");
                });

            modelBuilder.Entity("Entities.Invoice", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    b.Property<int?>("ClientMissionId")
                        .HasColumnType("int");

                    b.Property<DateTimeOffset>("CreatedAt")
                        .HasColumnType("datetime");

                    b.Property<string>("Designation")
                        .IsRequired()
                        .HasColumnType("longtext");

                    b.Property<DateTimeOffset>("UpdatedAt")
                        .HasColumnType("datetime");

                    b.HasKey("Id");

                    b.HasIndex("ClientMissionId");

                    b.ToTable("Invoice");
                });

            modelBuilder.Entity("Entities.Quotation", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    b.Property<int?>("ClientMissionId")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.HasIndex("ClientMissionId");

                    b.ToTable("Quotation");
                });

            modelBuilder.Entity("Entities.User", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    b.Property<int?>("AddressId")
                        .HasColumnType("int");

                    b.Property<DateTime?>("Birthdate")
                        .HasColumnType("datetime(6)");

                    b.Property<int?>("ContactInformationId")
                        .HasColumnType("int");

                    b.Property<int?>("CountryId")
                        .HasColumnType("int");

                    b.Property<string>("Email")
                        .IsRequired()
                        .HasColumnType("longtext");

                    b.Property<string>("Firstname")
                        .IsRequired()
                        .HasColumnType("longtext");

                    b.Property<string>("Lastname")
                        .IsRequired()
                        .HasColumnType("longtext");

                    b.Property<string>("Password")
                        .IsRequired()
                        .HasColumnType("longtext");

                    b.HasKey("Id");

                    b.HasIndex("AddressId");

                    b.HasIndex("ContactInformationId");

                    b.HasIndex("CountryId");

                    b.ToTable("User");
                });

            modelBuilder.Entity("Entities.UserRole", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    b.Property<int?>("UserId")
                        .HasColumnType("int");

                    b.Property<int>("Value")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.HasIndex("UserId");

                    b.ToTable("UserRole");
                });

            modelBuilder.Entity("Entities.Address", b =>
                {
                    b.HasOne("Entities.City", "City")
                        .WithMany()
                        .HasForeignKey("CityId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("City");
                });

            modelBuilder.Entity("Entities.ClientContact", b =>
                {
                    b.HasOne("Entities.Address", "Address")
                        .WithMany()
                        .HasForeignKey("AddressId");

                    b.HasOne("Entities.Company", null)
                        .WithMany("Contacts")
                        .HasForeignKey("CompanyId");

                    b.HasOne("Entities.ContactInformation", "ContactInformation")
                        .WithMany()
                        .HasForeignKey("ContactInformationId");

                    b.HasOne("Entities.Country", "Country")
                        .WithMany()
                        .HasForeignKey("CountryId");

                    b.Navigation("Address");

                    b.Navigation("ContactInformation");

                    b.Navigation("Country");
                });

            modelBuilder.Entity("Entities.ClientMission", b =>
                {
                    b.HasOne("Entities.Company", null)
                        .WithMany("ClientMissions")
                        .HasForeignKey("CompanyId");

                    b.HasOne("Entities.ClientMissionProject", "Project")
                        .WithMany()
                        .HasForeignKey("ProjectId");

                    b.Navigation("Project");
                });

            modelBuilder.Entity("Entities.ClientMissionCommunication", b =>
                {
                    b.HasOne("Entities.ClientMission", null)
                        .WithMany("CommunicationsHistory")
                        .HasForeignKey("ClientMissionId");
                });

            modelBuilder.Entity("Entities.ClientMissionContract", b =>
                {
                    b.HasOne("Entities.ClientMission", null)
                        .WithMany("Contracts")
                        .HasForeignKey("ClientMissionId");
                });

            modelBuilder.Entity("Entities.ClientMissionProjectMilestone", b =>
                {
                    b.HasOne("Entities.ClientMissionProject", null)
                        .WithMany("Milestones")
                        .HasForeignKey("ClientMissionProjectId");
                });

            modelBuilder.Entity("Entities.ClientMissionSpecialRequest", b =>
                {
                    b.HasOne("Entities.ClientMission", null)
                        .WithMany("SpecialRequests")
                        .HasForeignKey("ClientMissionId");
                });

            modelBuilder.Entity("Entities.Company", b =>
                {
                    b.HasOne("Entities.Address", "Address")
                        .WithMany()
                        .HasForeignKey("AddressId");

                    b.HasOne("Entities.BankDetails", "BankDetails")
                        .WithMany()
                        .HasForeignKey("BankDetailsId");

                    b.HasOne("Entities.Country", "Country")
                        .WithMany()
                        .HasForeignKey("CountryId");

                    b.HasOne("Entities.ClientFinancialInformation", "FinancialInformation")
                        .WithMany()
                        .HasForeignKey("FinancialInformationId");

                    b.Navigation("Address");

                    b.Navigation("BankDetails");

                    b.Navigation("Country");

                    b.Navigation("FinancialInformation");
                });

            modelBuilder.Entity("Entities.CompanyFranceSpecifics", b =>
                {
                    b.HasOne("Entities.Company", "Company")
                        .WithMany()
                        .HasForeignKey("CompanyId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Company");
                });

            modelBuilder.Entity("Entities.CompanyUsaSpecifics", b =>
                {
                    b.HasOne("Entities.Company", "Company")
                        .WithMany()
                        .HasForeignKey("CompanyId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Company");
                });

            modelBuilder.Entity("Entities.Invoice", b =>
                {
                    b.HasOne("Entities.ClientMission", null)
                        .WithMany("Invoices")
                        .HasForeignKey("ClientMissionId");
                });

            modelBuilder.Entity("Entities.Quotation", b =>
                {
                    b.HasOne("Entities.ClientMission", null)
                        .WithMany("Quotations")
                        .HasForeignKey("ClientMissionId");
                });

            modelBuilder.Entity("Entities.User", b =>
                {
                    b.HasOne("Entities.Address", "Address")
                        .WithMany()
                        .HasForeignKey("AddressId");

                    b.HasOne("Entities.ContactInformation", "ContactInformation")
                        .WithMany()
                        .HasForeignKey("ContactInformationId");

                    b.HasOne("Entities.Country", "Country")
                        .WithMany()
                        .HasForeignKey("CountryId");

                    b.Navigation("Address");

                    b.Navigation("ContactInformation");

                    b.Navigation("Country");
                });

            modelBuilder.Entity("Entities.UserRole", b =>
                {
                    b.HasOne("Entities.User", null)
                        .WithMany("UserRoles")
                        .HasForeignKey("UserId");
                });

            modelBuilder.Entity("Entities.ClientMission", b =>
                {
                    b.Navigation("CommunicationsHistory");

                    b.Navigation("Contracts");

                    b.Navigation("Invoices");

                    b.Navigation("Quotations");

                    b.Navigation("SpecialRequests");
                });

            modelBuilder.Entity("Entities.ClientMissionProject", b =>
                {
                    b.Navigation("Milestones");
                });

            modelBuilder.Entity("Entities.Company", b =>
                {
                    b.Navigation("ClientMissions");

                    b.Navigation("Contacts");
                });

            modelBuilder.Entity("Entities.User", b =>
                {
                    b.Navigation("UserRoles");
                });
#pragma warning restore 612, 618
        }
    }
}
