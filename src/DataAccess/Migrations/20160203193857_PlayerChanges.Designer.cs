using System;
using Microsoft.Data.Entity;
using Microsoft.Data.Entity.Infrastructure;
using Microsoft.Data.Entity.Metadata;
using Microsoft.Data.Entity.Migrations;
using DataAccess;

namespace dataaccess.Migrations
{
    [DbContext(typeof(JuveDbContext))]
    [Migration("20160203193857_PlayerChanges")]
    partial class PlayerChanges
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
            modelBuilder
                .HasAnnotation("ProductVersion", "7.0.0-rc1-16348")
                .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

            modelBuilder.Entity("DataAccess.Domain.Country", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<string>("Name");

                    b.HasKey("Id");
                });

            modelBuilder.Entity("DataAccess.Domain.Player", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<DateTime>("BirthDate");

                    b.Property<int>("CountryId");

                    b.Property<int>("CurrentTeamId");

                    b.Property<DateTime?>("EndDate");

                    b.Property<string>("FirstName");

                    b.Property<int?>("Height");

                    b.Property<string>("LastName");

                    b.Property<string>("Note");

                    b.Property<string>("Photo");

                    b.Property<int>("PlayerTypeId");

                    b.Property<DateTime>("StartDate");

                    b.Property<int>("TeamNumber");

                    b.Property<int?>("Weight");

                    b.HasKey("Id");
                });

            modelBuilder.Entity("DataAccess.Domain.PlayerType", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<string>("Type");

                    b.HasKey("Id");
                });

            modelBuilder.Entity("DataAccess.Domain.Team", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<int>("CountryId");

                    b.Property<string>("Name");

                    b.HasKey("Id");
                });

            modelBuilder.Entity("DataAccess.Domain.Video", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<string>("VideoExerpt");

                    b.HasKey("Id");
                });

            modelBuilder.Entity("DataAccess.Domain.Player", b =>
                {
                    b.HasOne("DataAccess.Domain.Country")
                        .WithMany()
                        .HasForeignKey("CountryId");

                    b.HasOne("DataAccess.Domain.Team")
                        .WithMany()
                        .HasForeignKey("CurrentTeamId");

                    b.HasOne("DataAccess.Domain.PlayerType")
                        .WithMany()
                        .HasForeignKey("PlayerTypeId");
                });

            modelBuilder.Entity("DataAccess.Domain.Team", b =>
                {
                    b.HasOne("DataAccess.Domain.Country")
                        .WithMany()
                        .HasForeignKey("CountryId");
                });
        }
    }
}
