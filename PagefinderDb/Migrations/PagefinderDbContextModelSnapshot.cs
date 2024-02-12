﻿// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using PagefinderDb.Data;

#nullable disable

namespace PagefinderDb.Migrations
{
    [DbContext(typeof(PagefinderDbContext))]
    partial class PagefinderDbContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "8.0.1")
                .HasAnnotation("Relational:MaxIdentifierLength", 128);

            SqlServerModelBuilderExtensions.UseIdentityColumns(modelBuilder);

            modelBuilder.Entity("PagefinderDb.Data.Models.Character", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<string>("Description")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("ImageUrl")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Tags")
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("UserId")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.HasIndex("UserId");

                    b.ToTable("Characters");
                });

            modelBuilder.Entity("PagefinderDb.Data.Models.Choice", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<string>("Description")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("FailurePageId")
                        .HasColumnType("int");

                    b.Property<int?>("PageId")
                        .HasColumnType("int");

                    b.Property<int>("SuccessPageId")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.HasIndex("FailurePageId");

                    b.HasIndex("PageId");

                    b.HasIndex("SuccessPageId");

                    b.ToTable("Choices");
                });

            modelBuilder.Entity("PagefinderDb.Data.Models.Collection", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<string>("Description")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("ImageUrl")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("UserId")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.HasIndex("UserId");

                    b.ToTable("Collections");
                });

            modelBuilder.Entity("PagefinderDb.Data.Models.InventoryItem", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<int>("Amount")
                        .HasColumnType("int");

                    b.Property<int>("ItemId")
                        .HasColumnType("int");

                    b.Property<int>("PlayTestId")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.HasIndex("PlayTestId");

                    b.ToTable("InventoryItems");
                });

            modelBuilder.Entity("PagefinderDb.Data.Models.Item", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<string>("Description")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("ImageUrl")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Tags")
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("UserId")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.HasIndex("UserId");

                    b.ToTable("Items");
                });

            modelBuilder.Entity("PagefinderDb.Data.Models.Page", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<string>("ImageURL")
                        .HasColumnType("nvarchar(max)");

                    b.Property<bool>("IsEnd")
                        .HasColumnType("bit");

                    b.Property<string>("PageText")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("PageTitle")
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("StoryId")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.HasIndex("StoryId");

                    b.ToTable("Pages");
                });

            modelBuilder.Entity("PagefinderDb.Data.Models.PlayTest", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<int>("Progress")
                        .HasColumnType("int");

                    b.Property<int>("StoryId")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.HasIndex("StoryId")
                        .IsUnique();

                    b.ToTable("PlayTests");
                });

            modelBuilder.Entity("PagefinderDb.Data.Models.Requirement", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<int>("Amount")
                        .HasColumnType("int");

                    b.Property<int>("ChoiceId")
                        .HasColumnType("int");

                    b.Property<bool>("IsHidden")
                        .HasColumnType("bit");

                    b.Property<int>("ItemId")
                        .HasColumnType("int");

                    b.Property<int>("StoryId")
                        .HasColumnType("int");

                    b.Property<bool>("SubtractOnPass")
                        .HasColumnType("bit");

                    b.HasKey("Id");

                    b.HasIndex("ChoiceId");

                    b.HasIndex("ItemId");

                    b.HasIndex("StoryId");

                    b.ToTable("Requirements");
                });

            modelBuilder.Entity("PagefinderDb.Data.Models.Restriction", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<int>("Amount")
                        .HasColumnType("int");

                    b.Property<int>("ChoiceId")
                        .HasColumnType("int");

                    b.Property<bool>("IsHidden")
                        .HasColumnType("bit");

                    b.Property<int>("ItemId")
                        .HasColumnType("int");

                    b.Property<int>("StoryId")
                        .HasColumnType("int");

                    b.Property<bool>("SubtractOnPass")
                        .HasColumnType("bit");

                    b.HasKey("Id");

                    b.HasIndex("ChoiceId");

                    b.HasIndex("ItemId");

                    b.HasIndex("StoryId");

                    b.ToTable("Restrictions");
                });

            modelBuilder.Entity("PagefinderDb.Data.Models.Reward", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<int>("Amount")
                        .HasColumnType("int");

                    b.Property<int>("ChoiceId")
                        .HasColumnType("int");

                    b.Property<bool>("IsHidden")
                        .HasColumnType("bit");

                    b.Property<int>("ItemId")
                        .HasColumnType("int");

                    b.Property<int>("StoryId")
                        .HasColumnType("int");

                    b.Property<bool>("SubtractOnPass")
                        .HasColumnType("bit");

                    b.HasKey("Id");

                    b.HasIndex("ChoiceId");

                    b.HasIndex("ItemId");

                    b.HasIndex("StoryId");

                    b.ToTable("Rewards");
                });

            modelBuilder.Entity("PagefinderDb.Data.Models.Story", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<int>("CollectionId")
                        .HasColumnType("int");

                    b.Property<string>("Description")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("ImageUrl")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Title")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.HasIndex("CollectionId");

                    b.ToTable("Stories");
                });

            modelBuilder.Entity("PagefinderDb.Data.Models.User", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<string>("Email")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Password")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Username")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.ToTable("Users");
                });

            modelBuilder.Entity("PagefinderDb.Data.Models.Character", b =>
                {
                    b.HasOne("PagefinderDb.Data.Models.User", "User")
                        .WithMany("Characters")
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("User");
                });

            modelBuilder.Entity("PagefinderDb.Data.Models.Choice", b =>
                {
                    b.HasOne("PagefinderDb.Data.Models.Page", "FailurePage")
                        .WithMany()
                        .HasForeignKey("FailurePageId")
                        .OnDelete(DeleteBehavior.Restrict)
                        .IsRequired();

                    b.HasOne("PagefinderDb.Data.Models.Page", null)
                        .WithMany("Choices")
                        .HasForeignKey("PageId");

                    b.HasOne("PagefinderDb.Data.Models.Page", "SuccessPage")
                        .WithMany()
                        .HasForeignKey("SuccessPageId")
                        .OnDelete(DeleteBehavior.Restrict)
                        .IsRequired();

                    b.Navigation("FailurePage");

                    b.Navigation("SuccessPage");
                });

            modelBuilder.Entity("PagefinderDb.Data.Models.Collection", b =>
                {
                    b.HasOne("PagefinderDb.Data.Models.User", "User")
                        .WithMany("Collections")
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("User");
                });

            modelBuilder.Entity("PagefinderDb.Data.Models.InventoryItem", b =>
                {
                    b.HasOne("PagefinderDb.Data.Models.PlayTest", "PlayTest")
                        .WithMany("InventoryItems")
                        .HasForeignKey("PlayTestId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("PlayTest");
                });

            modelBuilder.Entity("PagefinderDb.Data.Models.Item", b =>
                {
                    b.HasOne("PagefinderDb.Data.Models.User", "User")
                        .WithMany("Items")
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("User");
                });

            modelBuilder.Entity("PagefinderDb.Data.Models.Page", b =>
                {
                    b.HasOne("PagefinderDb.Data.Models.Story", "Story")
                        .WithMany("Pages")
                        .HasForeignKey("StoryId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Story");
                });

            modelBuilder.Entity("PagefinderDb.Data.Models.PlayTest", b =>
                {
                    b.HasOne("PagefinderDb.Data.Models.Story", "Story")
                        .WithOne("PlayTest")
                        .HasForeignKey("PagefinderDb.Data.Models.PlayTest", "StoryId")
                        .OnDelete(DeleteBehavior.Restrict)
                        .IsRequired();

                    b.Navigation("Story");
                });

            modelBuilder.Entity("PagefinderDb.Data.Models.Requirement", b =>
                {
                    b.HasOne("PagefinderDb.Data.Models.Choice", null)
                        .WithMany("Requirements")
                        .HasForeignKey("ChoiceId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("PagefinderDb.Data.Models.Item", "Item")
                        .WithMany()
                        .HasForeignKey("ItemId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("PagefinderDb.Data.Models.Story", "Story")
                        .WithMany()
                        .HasForeignKey("StoryId")
                        .OnDelete(DeleteBehavior.Restrict)
                        .IsRequired();

                    b.Navigation("Item");

                    b.Navigation("Story");
                });

            modelBuilder.Entity("PagefinderDb.Data.Models.Restriction", b =>
                {
                    b.HasOne("PagefinderDb.Data.Models.Choice", null)
                        .WithMany("Restrictions")
                        .HasForeignKey("ChoiceId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("PagefinderDb.Data.Models.Item", "Item")
                        .WithMany()
                        .HasForeignKey("ItemId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("PagefinderDb.Data.Models.Story", "Story")
                        .WithMany()
                        .HasForeignKey("StoryId")
                        .OnDelete(DeleteBehavior.Restrict)
                        .IsRequired();

                    b.Navigation("Item");

                    b.Navigation("Story");
                });

            modelBuilder.Entity("PagefinderDb.Data.Models.Reward", b =>
                {
                    b.HasOne("PagefinderDb.Data.Models.Choice", null)
                        .WithMany("Rewards")
                        .HasForeignKey("ChoiceId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("PagefinderDb.Data.Models.Item", "Item")
                        .WithMany()
                        .HasForeignKey("ItemId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("PagefinderDb.Data.Models.Story", "Story")
                        .WithMany()
                        .HasForeignKey("StoryId")
                        .OnDelete(DeleteBehavior.Restrict)
                        .IsRequired();

                    b.Navigation("Item");

                    b.Navigation("Story");
                });

            modelBuilder.Entity("PagefinderDb.Data.Models.Story", b =>
                {
                    b.HasOne("PagefinderDb.Data.Models.Collection", "Collection")
                        .WithMany("Stories")
                        .HasForeignKey("CollectionId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Collection");
                });

            modelBuilder.Entity("PagefinderDb.Data.Models.Choice", b =>
                {
                    b.Navigation("Requirements");

                    b.Navigation("Restrictions");

                    b.Navigation("Rewards");
                });

            modelBuilder.Entity("PagefinderDb.Data.Models.Collection", b =>
                {
                    b.Navigation("Stories");
                });

            modelBuilder.Entity("PagefinderDb.Data.Models.Page", b =>
                {
                    b.Navigation("Choices");
                });

            modelBuilder.Entity("PagefinderDb.Data.Models.PlayTest", b =>
                {
                    b.Navigation("InventoryItems");
                });

            modelBuilder.Entity("PagefinderDb.Data.Models.Story", b =>
                {
                    b.Navigation("Pages");

                    b.Navigation("PlayTest");
                });

            modelBuilder.Entity("PagefinderDb.Data.Models.User", b =>
                {
                    b.Navigation("Characters");

                    b.Navigation("Collections");

                    b.Navigation("Items");
                });
#pragma warning restore 612, 618
        }
    }
}
