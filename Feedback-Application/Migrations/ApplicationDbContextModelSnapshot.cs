﻿// <auto-generated />
using System;
using Feedback_Application;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

#nullable disable

namespace Feedback_Application.Migrations
{
    [DbContext(typeof(ApplicationDbContext))]
    partial class ApplicationDbContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "8.0.12")
                .HasAnnotation("Relational:MaxIdentifierLength", 64);

            MySqlModelBuilderExtensions.AutoIncrementColumns(modelBuilder);

            modelBuilder.Entity("Feedback_Application.Pages.Models.Abteilung", b =>
                {
                    b.Property<int>("AbteilungsID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    MySqlPropertyBuilderExtensions.UseMySqlIdentityColumn(b.Property<int>("AbteilungsID"));

                    b.Property<string>("AbteilungName")
                        .IsRequired()
                        .HasColumnType("longtext");

                    b.HasKey("AbteilungsID");

                    b.ToTable("Abteilung");
                });

            modelBuilder.Entity("Feedback_Application.Pages.Models.Aussagen", b =>
                {
                    b.Property<int>("AussageID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    MySqlPropertyBuilderExtensions.UseMySqlIdentityColumn(b.Property<int>("AussageID"));

                    b.Property<string>("Aussage")
                        .IsRequired()
                        .HasColumnType("longtext");

                    b.Property<int>("ThemaID")
                        .HasColumnType("int");

                    b.HasKey("AussageID");

                    b.ToTable("Aussagen");

                    b.HasData(
                        new
                        {
                            AussageID = 1,
                            Aussage = "Sie/Er ist ungeduldig",
                            ThemaID = 1
                        },
                        new
                        {
                            AussageID = 2,
                            Aussage = "Sie/Er ist sicher im Auftreten",
                            ThemaID = 1
                        },
                        new
                        {
                            AussageID = 3,
                            Aussage = "Sie/Er ist freundlich",
                            ThemaID = 1
                        },
                        new
                        {
                            AussageID = 4,
                            Aussage = "Sie/Er ist erregbar und aufbrausend",
                            ThemaID = 1
                        },
                        new
                        {
                            AussageID = 5,
                            Aussage = "Sie/Er ist tatkraeftig, aktiv",
                            ThemaID = 1
                        },
                        new
                        {
                            AussageID = 6,
                            Aussage = "Sie/Er ist aufgeschlossen",
                            ThemaID = 1
                        },
                        new
                        {
                            AussageID = 7,
                            Aussage = "Die Lehrerin, der Lehrer bevorzugt manche Schuelerinnen oder Schueler.",
                            ThemaID = 2
                        },
                        new
                        {
                            AussageID = 8,
                            Aussage = "Die Lehrerin, der Lehrer nimmt die Schuelerinnen und Schueler ernst.",
                            ThemaID = 2
                        },
                        new
                        {
                            AussageID = 9,
                            Aussage = "Die Lehrerin, der Lehrer ermutigt und lobt viel.",
                            ThemaID = 2
                        },
                        new
                        {
                            AussageID = 10,
                            Aussage = "Die Lehrerin, der Lehrer entscheidet immer allein.",
                            ThemaID = 2
                        },
                        new
                        {
                            AussageID = 11,
                            Aussage = "Die Lehrerin, der Lehrer gesteht eigene Fehler ein.",
                            ThemaID = 2
                        },
                        new
                        {
                            AussageID = 12,
                            Aussage = "Die Ziele des Unterrichts sind klar erkennbar",
                            ThemaID = 3
                        },
                        new
                        {
                            AussageID = 13,
                            Aussage = "Der Lehrer redet zu viel.",
                            ThemaID = 3
                        },
                        new
                        {
                            AussageID = 14,
                            Aussage = "Der Lehrer schweift oft vom Thema ab.",
                            ThemaID = 3
                        },
                        new
                        {
                            AussageID = 15,
                            Aussage = "Die Fragen und Beiträge der Schuelerinnen und Schueler werden ernst genommen.",
                            ThemaID = 3
                        },
                        new
                        {
                            AussageID = 16,
                            Aussage = "Die Sprache des Lehrers ist gut verstaendlich.",
                            ThemaID = 3
                        },
                        new
                        {
                            AussageID = 17,
                            Aussage = "Der Lehrer achtet auf Ruhe und Disziplin im Unterricht.",
                            ThemaID = 3
                        },
                        new
                        {
                            AussageID = 18,
                            Aussage = "Der Unterricht ist abwechslungsreich.",
                            ThemaID = 3
                        },
                        new
                        {
                            AussageID = 19,
                            Aussage = "Unterrichtsmaterialien sind ansprechend und gut verstaendlich gestaltet",
                            ThemaID = 3
                        },
                        new
                        {
                            AussageID = 20,
                            Aussage = "Der Stoff wird ausreichend wiederholt und geuebt.",
                            ThemaID = 3
                        },
                        new
                        {
                            AussageID = 21,
                            Aussage = "Die Themen der Schulaufgaben werden rechtzeitig vorher bekannt gegeben.",
                            ThemaID = 4
                        },
                        new
                        {
                            AussageID = 22,
                            Aussage = "Der Schwierigkeitsgrad der Leistungsnachweise entspricht dem der Unterrichtsinhalte.",
                            ThemaID = 4
                        },
                        new
                        {
                            AussageID = 23,
                            Aussage = "Die Bewertungen sind nachvollziehbar und verstaendlich.",
                            ThemaID = 4
                        },
                        new
                        {
                            AussageID = 24,
                            Aussage = "Die Lehrkraft hat ein großes Hintergrundwissen.",
                            ThemaID = 5
                        },
                        new
                        {
                            AussageID = 25,
                            Aussage = "Die Lehrkraft ist immer gut vorbereitet.",
                            ThemaID = 5
                        },
                        new
                        {
                            AussageID = 26,
                            Aussage = "Die Lehrkraft zeigt Interesse an ihren Schuelern.",
                            ThemaID = 5
                        },
                        new
                        {
                            AussageID = 27,
                            Aussage = "Die Lehrkraft sorgt fuer ein gutes Lernklima in der Klasse.",
                            ThemaID = 5
                        },
                        new
                        {
                            AussageID = 28,
                            Aussage = "Die Notengebung ist fair und nachvollziehbar.",
                            ThemaID = 5
                        },
                        new
                        {
                            AussageID = 29,
                            Aussage = "Ich konnte dem Unterricht immer gut folgen.",
                            ThemaID = 5
                        },
                        new
                        {
                            AussageID = 30,
                            Aussage = "Der Unterricht wird vielfaeltig gestaltet.",
                            ThemaID = 5
                        },
                        new
                        {
                            AussageID = 31,
                            Aussage = "Ich lerne im Unterricht viel.",
                            ThemaID = 5
                        });
                });

            modelBuilder.Entity("Feedback_Application.Pages.Models.Bewertungen", b =>
                {
                    b.Property<int>("BewertungsID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    MySqlPropertyBuilderExtensions.UseMySqlIdentityColumn(b.Property<int>("BewertungsID"));

                    b.Property<string>("BewertungsChar")
                        .IsRequired()
                        .HasColumnType("longtext");

                    b.Property<int>("BewertungsInt")
                        .HasColumnType("int");

                    b.Property<int>("BogenID")
                        .HasColumnType("int");

                    b.HasKey("BewertungsID");

                    b.ToTable("Bewertungen");

                    b.HasData(
                        new
                        {
                            BewertungsID = 1,
                            BewertungsChar = "trifft voellig zu",
                            BewertungsInt = 4,
                            BogenID = 1
                        },
                        new
                        {
                            BewertungsID = 2,
                            BewertungsChar = "trifft eher zu",
                            BewertungsInt = 3,
                            BogenID = 1
                        },
                        new
                        {
                            BewertungsID = 3,
                            BewertungsChar = "trifft eher nicht zu",
                            BewertungsInt = 2,
                            BogenID = 1
                        },
                        new
                        {
                            BewertungsID = 4,
                            BewertungsChar = "trifft ueberhaupt nicht zu",
                            BewertungsInt = 1,
                            BogenID = 1
                        },
                        new
                        {
                            BewertungsID = 5,
                            BewertungsChar = "",
                            BewertungsInt = 1,
                            BogenID = 2
                        },
                        new
                        {
                            BewertungsID = 6,
                            BewertungsChar = "",
                            BewertungsInt = 2,
                            BogenID = 2
                        },
                        new
                        {
                            BewertungsID = 7,
                            BewertungsChar = "",
                            BewertungsInt = 3,
                            BogenID = 2
                        },
                        new
                        {
                            BewertungsID = 8,
                            BewertungsChar = "",
                            BewertungsInt = 4,
                            BogenID = 2
                        },
                        new
                        {
                            BewertungsID = 9,
                            BewertungsChar = "",
                            BewertungsInt = 5,
                            BogenID = 2
                        });
                });

            modelBuilder.Entity("Feedback_Application.Pages.Models.Ergebnisse", b =>
                {
                    b.Property<int>("ErgebnisID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    MySqlPropertyBuilderExtensions.UseMySqlIdentityColumn(b.Property<int>("ErgebnisID"));

                    b.Property<int>("AussageID")
                        .HasColumnType("int");

                    b.Property<int>("BewertungsID")
                        .HasColumnType("int");

                    b.Property<int>("ErstellungsID")
                        .HasColumnType("int");

                    b.Property<int>("FeedbackID")
                        .HasColumnType("int");

                    b.Property<int?>("VarErgebnisID")
                        .HasColumnType("int");

                    b.HasKey("ErgebnisID");

                    b.ToTable("Ergebnisse");
                });

            modelBuilder.Entity("Feedback_Application.Pages.Models.Erstellung", b =>
                {
                    b.Property<int>("ErstellungsID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    MySqlPropertyBuilderExtensions.UseMySqlIdentityColumn(b.Property<int>("ErstellungsID"));

                    b.Property<int>("AbteilungsID")
                        .HasColumnType("int");

                    b.Property<string>("Code")
                        .IsRequired()
                        .HasColumnType("longtext");

                    b.Property<DateTime>("Erstellungsdatum")
                        .HasColumnType("datetime(6)");

                    b.Property<int>("FachID")
                        .HasColumnType("int");

                    b.Property<int>("FeedbackID")
                        .HasColumnType("int");

                    b.Property<int?>("Jahrgang")
                        .HasColumnType("int");

                    b.Property<int>("KlassenID")
                        .HasColumnType("int");

                    b.Property<int>("Schuljahr")
                        .HasColumnType("int");

                    b.Property<string>("UserID")
                        .IsRequired()
                        .HasColumnType("longtext");

                    b.HasKey("ErstellungsID");

                    b.ToTable("Erstellung");
                });

            modelBuilder.Entity("Feedback_Application.Pages.Models.ExtraFeedback", b =>
                {
                    b.Property<int>("FragenID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    MySqlPropertyBuilderExtensions.UseMySqlIdentityColumn(b.Property<int>("FragenID"));

                    b.Property<int>("BogenID")
                        .HasColumnType("int");

                    b.Property<string>("Frage")
                        .IsRequired()
                        .HasColumnType("longtext");

                    b.HasKey("FragenID");

                    b.ToTable("ExtraFeedback");

                    b.HasData(
                        new
                        {
                            FragenID = 1,
                            BogenID = 1,
                            Frage = "Das hat mir besonders gut gefallen:"
                        },
                        new
                        {
                            FragenID = 2,
                            BogenID = 1,
                            Frage = "Das hat mir nicht gefallen:"
                        },
                        new
                        {
                            FragenID = 3,
                            BogenID = 1,
                            Frage = "Verbesserungsvorschlaege:"
                        },
                        new
                        {
                            FragenID = 4,
                            BogenID = 2,
                            Frage = "Was ich sonst noch anmerken moechte: "
                        });
                });

            modelBuilder.Entity("Feedback_Application.Pages.Models.Fach", b =>
                {
                    b.Property<int>("FachID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    MySqlPropertyBuilderExtensions.UseMySqlIdentityColumn(b.Property<int>("FachID"));

                    b.Property<string>("FachName")
                        .IsRequired()
                        .HasColumnType("longtext");

                    b.HasKey("FachID");

                    b.ToTable("Fach");
                });

            modelBuilder.Entity("Feedback_Application.Pages.Models.Feedbackbogen", b =>
                {
                    b.Property<int>("BogenID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    MySqlPropertyBuilderExtensions.UseMySqlIdentityColumn(b.Property<int>("BogenID"));

                    b.Property<string>("Beschreibung")
                        .IsRequired()
                        .HasColumnType("longtext");

                    b.HasKey("BogenID");

                    b.ToTable("Feedbackbogen");

                    b.HasData(
                        new
                        {
                            BogenID = 1,
                            Beschreibung = "Unterrichtsbeurteilung durch Schuelerinnen und Schueler I"
                        },
                        new
                        {
                            BogenID = 2,
                            Beschreibung = "Zielscheibe"
                        });
                });

            modelBuilder.Entity("Feedback_Application.Pages.Models.Klassen", b =>
                {
                    b.Property<int>("KlassenID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    MySqlPropertyBuilderExtensions.UseMySqlIdentityColumn(b.Property<int>("KlassenID"));

                    b.Property<string>("KlassenName")
                        .IsRequired()
                        .HasColumnType("longtext");

                    b.HasKey("KlassenID");

                    b.ToTable("Klassen");
                });

            modelBuilder.Entity("Feedback_Application.Pages.Models.Oberthema", b =>
                {
                    b.Property<int>("ThemaID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    MySqlPropertyBuilderExtensions.UseMySqlIdentityColumn(b.Property<int>("ThemaID"));

                    b.Property<int>("BogenID")
                        .HasColumnType("int");

                    b.Property<string>("Thema")
                        .IsRequired()
                        .HasColumnType("longtext");

                    b.HasKey("ThemaID");

                    b.ToTable("Oberthema");

                    b.HasData(
                        new
                        {
                            ThemaID = 1,
                            BogenID = 1,
                            Thema = "Verhalten des Lehrers:"
                        },
                        new
                        {
                            ThemaID = 2,
                            BogenID = 1,
                            Thema = "Bewerten Sie folgende Aussagen:"
                        },
                        new
                        {
                            ThemaID = 3,
                            BogenID = 1,
                            Thema = "Wie ist der Unterricht?"
                        },
                        new
                        {
                            ThemaID = 4,
                            BogenID = 1,
                            Thema = "Bewerten Sie folgende Behauptungen:"
                        },
                        new
                        {
                            ThemaID = 5,
                            BogenID = 2,
                            Thema = "Bewertung"
                        });
                });

            modelBuilder.Entity("Feedback_Application.Pages.Models.Registrierung", b =>
                {
                    b.Property<int>("RegID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    MySqlPropertyBuilderExtensions.UseMySqlIdentityColumn(b.Property<int>("RegID"));

                    b.Property<string>("RegPasswort")
                        .IsRequired()
                        .HasColumnType("longtext");

                    b.HasKey("RegID");

                    b.ToTable("Registrierung");

                    b.HasData(
                        new
                        {
                            RegID = 1,
                            RegPasswort = "ABCDE"
                        });
                });

            modelBuilder.Entity("Feedback_Application.Pages.Models.Variable_Ergebnisse", b =>
                {
                    b.Property<int>("VarErgebnisID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    MySqlPropertyBuilderExtensions.UseMySqlIdentityColumn(b.Property<int>("VarErgebnisID"));

                    b.Property<string>("AntwortUser")
                        .IsRequired()
                        .HasColumnType("longtext");

                    b.Property<int>("ErstellungsID")
                        .HasColumnType("int");

                    b.Property<int>("FragenID")
                        .HasColumnType("int");

                    b.HasKey("VarErgebnisID");

                    b.ToTable("Variable_Ergebnisse");
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityRole", b =>
                {
                    b.Property<string>("Id")
                        .HasColumnType("varchar(255)");

                    b.Property<string>("ConcurrencyStamp")
                        .IsConcurrencyToken()
                        .HasColumnType("longtext");

                    b.Property<string>("Name")
                        .HasMaxLength(256)
                        .HasColumnType("varchar(256)");

                    b.Property<string>("NormalizedName")
                        .HasMaxLength(256)
                        .HasColumnType("varchar(256)");

                    b.HasKey("Id");

                    b.HasIndex("NormalizedName")
                        .IsUnique()
                        .HasDatabaseName("RoleNameIndex");

                    b.ToTable("AspNetRoles", (string)null);
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityRoleClaim<string>", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    MySqlPropertyBuilderExtensions.UseMySqlIdentityColumn(b.Property<int>("Id"));

                    b.Property<string>("ClaimType")
                        .HasColumnType("longtext");

                    b.Property<string>("ClaimValue")
                        .HasColumnType("longtext");

                    b.Property<string>("RoleId")
                        .IsRequired()
                        .HasColumnType("varchar(255)");

                    b.HasKey("Id");

                    b.HasIndex("RoleId");

                    b.ToTable("AspNetRoleClaims", (string)null);
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUser", b =>
                {
                    b.Property<string>("Id")
                        .HasColumnType("varchar(255)");

                    b.Property<int>("AccessFailedCount")
                        .HasColumnType("int");

                    b.Property<string>("ConcurrencyStamp")
                        .IsConcurrencyToken()
                        .HasColumnType("longtext");

                    b.Property<string>("Email")
                        .HasMaxLength(256)
                        .HasColumnType("varchar(256)");

                    b.Property<bool>("EmailConfirmed")
                        .HasColumnType("tinyint(1)");

                    b.Property<bool>("LockoutEnabled")
                        .HasColumnType("tinyint(1)");

                    b.Property<DateTimeOffset?>("LockoutEnd")
                        .HasColumnType("datetime(6)");

                    b.Property<string>("NormalizedEmail")
                        .HasMaxLength(256)
                        .HasColumnType("varchar(256)");

                    b.Property<string>("NormalizedUserName")
                        .HasMaxLength(256)
                        .HasColumnType("varchar(256)");

                    b.Property<string>("PasswordHash")
                        .HasColumnType("longtext");

                    b.Property<string>("PhoneNumber")
                        .HasColumnType("longtext");

                    b.Property<bool>("PhoneNumberConfirmed")
                        .HasColumnType("tinyint(1)");

                    b.Property<string>("SecurityStamp")
                        .HasColumnType("longtext");

                    b.Property<bool>("TwoFactorEnabled")
                        .HasColumnType("tinyint(1)");

                    b.Property<string>("UserName")
                        .HasMaxLength(256)
                        .HasColumnType("varchar(256)");

                    b.HasKey("Id");

                    b.HasIndex("NormalizedEmail")
                        .HasDatabaseName("EmailIndex");

                    b.HasIndex("NormalizedUserName")
                        .IsUnique()
                        .HasDatabaseName("UserNameIndex");

                    b.ToTable("AspNetUsers", (string)null);
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserClaim<string>", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    MySqlPropertyBuilderExtensions.UseMySqlIdentityColumn(b.Property<int>("Id"));

                    b.Property<string>("ClaimType")
                        .HasColumnType("longtext");

                    b.Property<string>("ClaimValue")
                        .HasColumnType("longtext");

                    b.Property<string>("UserId")
                        .IsRequired()
                        .HasColumnType("varchar(255)");

                    b.HasKey("Id");

                    b.HasIndex("UserId");

                    b.ToTable("AspNetUserClaims", (string)null);
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserLogin<string>", b =>
                {
                    b.Property<string>("LoginProvider")
                        .HasColumnType("varchar(255)");

                    b.Property<string>("ProviderKey")
                        .HasColumnType("varchar(255)");

                    b.Property<string>("ProviderDisplayName")
                        .HasColumnType("longtext");

                    b.Property<string>("UserId")
                        .IsRequired()
                        .HasColumnType("varchar(255)");

                    b.HasKey("LoginProvider", "ProviderKey");

                    b.HasIndex("UserId");

                    b.ToTable("AspNetUserLogins", (string)null);
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserRole<string>", b =>
                {
                    b.Property<string>("UserId")
                        .HasColumnType("varchar(255)");

                    b.Property<string>("RoleId")
                        .HasColumnType("varchar(255)");

                    b.HasKey("UserId", "RoleId");

                    b.HasIndex("RoleId");

                    b.ToTable("AspNetUserRoles", (string)null);
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserToken<string>", b =>
                {
                    b.Property<string>("UserId")
                        .HasColumnType("varchar(255)");

                    b.Property<string>("LoginProvider")
                        .HasColumnType("varchar(255)");

                    b.Property<string>("Name")
                        .HasColumnType("varchar(255)");

                    b.Property<string>("Value")
                        .HasColumnType("longtext");

                    b.HasKey("UserId", "LoginProvider", "Name");

                    b.ToTable("AspNetUserTokens", (string)null);
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityRoleClaim<string>", b =>
                {
                    b.HasOne("Microsoft.AspNetCore.Identity.IdentityRole", null)
                        .WithMany()
                        .HasForeignKey("RoleId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserClaim<string>", b =>
                {
                    b.HasOne("Microsoft.AspNetCore.Identity.IdentityUser", null)
                        .WithMany()
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserLogin<string>", b =>
                {
                    b.HasOne("Microsoft.AspNetCore.Identity.IdentityUser", null)
                        .WithMany()
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserRole<string>", b =>
                {
                    b.HasOne("Microsoft.AspNetCore.Identity.IdentityRole", null)
                        .WithMany()
                        .HasForeignKey("RoleId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("Microsoft.AspNetCore.Identity.IdentityUser", null)
                        .WithMany()
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserToken<string>", b =>
                {
                    b.HasOne("Microsoft.AspNetCore.Identity.IdentityUser", null)
                        .WithMany()
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });
#pragma warning restore 612, 618
        }
    }
}
