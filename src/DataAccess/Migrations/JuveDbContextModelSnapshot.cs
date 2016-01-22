using System;
using Microsoft.Data.Entity;
using Microsoft.Data.Entity.Infrastructure;
using Microsoft.Data.Entity.Metadata;
using Microsoft.Data.Entity.Migrations;
using DataAccess;

namespace DataAccess.Migrations
{
    [DbContext(typeof(JuveDbContext))]
    partial class JuveDbContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
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
                    b.Property<int>("VideoId")
                        .ValueGeneratedOnAdd();

                    b.Property<string>("VideoExerpt");

                    b.HasKey("VideoId");
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
