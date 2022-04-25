using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;
using DRApplication.Shared.Models;

namespace DRApplication.Shared.Models
{
    public partial class FSTSSDatabaseContext : DbContext
    {
        public FSTSSDatabaseContext()
        {
        }

        public FSTSSDatabaseContext(DbContextOptions<FSTSSDatabaseContext> options)
            : base(options)
        {
        }

        public virtual DbSet<Baseline> Baselines { get; set; } = null!;
        public virtual DbSet<Comment> Comments { get; set; } = null!;
        public virtual DbSet<CorrectiveAction> CorrectiveActions { get; set; } = null!;
        public virtual DbSet<Device> Devices { get; set; } = null!;
        public virtual DbSet<DeviceDiscovered> DeviceDiscovereds { get; set; } = null!;
        public virtual DbSet<DeviceType> DeviceTypes { get; set; } = null!;
        public virtual DbSet<DocumentLink> DocumentLinks { get; set; } = null!;
        public virtual DbSet<Dr> Drs { get; set; } = null!;
        public virtual DbSet<DrDissent> DrDissents { get; set; } = null!;
        public virtual DbSet<DrDuplicate> DrDuplicates { get; set; } = null!;
        public virtual DbSet<DrType> DrTypes { get; set; } = null!;
        public virtual DbSet<Drrb> Drrbs { get; set; } = null!;
        public virtual DbSet<DrrbIssue> DrrbIssues { get; set; } = null!;
        public virtual DbSet<GetConfigByLoadId> GetConfigByLoadIds { get; set; } = null!;
        public virtual DbSet<GrfrHistory> GrfrHistories { get; set; } = null!;
        public virtual DbSet<GrfrPlan> GrfrPlans { get; set; } = null!;
        public virtual DbSet<HardwareConfig> HardwareConfigs { get; set; } = null!;
        public virtual DbSet<HardwareSystem> HardwareSystems { get; set; } = null!;
        public virtual DbSet<HardwareVersion> HardwareVersions { get; set; } = null!;
        public virtual DbSet<HardwareVersionsConfig> HardwareVersionsConfigs { get; set; } = null!;
        public virtual DbSet<Issue> Issues { get; set; } = null!;
        public virtual DbSet<IssueConfiguration> IssueConfigurations { get; set; } = null!;
        public virtual DbSet<IssueObserved> IssueObserveds { get; set; } = null!;
        public virtual DbSet<IssueSsrdTask> IssueSsrdTasks { get; set; } = null!;
        public virtual DbSet<IssuesDevice> IssuesDevices { get; set; } = null!;
        public virtual DbSet<IssuesKeyword> IssuesKeywords { get; set; } = null!;
        public virtual DbSet<Keyword> Keywords { get; set; } = null!;
        public virtual DbSet<Load> Loads { get; set; } = null!;
        public virtual DbSet<LoadsDevice> LoadsDevices { get; set; } = null!;
        public virtual DbSet<LoadsTestEvent> LoadsTestEvents { get; set; } = null!;
        public virtual DbSet<MaintIssue> MaintIssues { get; set; } = null!;
        public virtual DbSet<Maintainer> Maintainers { get; set; } = null!;
        public virtual DbSet<ManModule> ManModules { get; set; } = null!;
        public virtual DbSet<RctdConfiguration> RctdConfigurations { get; set; } = null!;
        public virtual DbSet<RctdLot> RctdLots { get; set; } = null!;
        public virtual DbSet<ResearchInfo> ResearchInfos { get; set; } = null!;
        public virtual DbSet<SimStatus> SimStatuses { get; set; } = null!;
        public virtual DbSet<SimStatusType> SimStatusTypes { get; set; } = null!;
        public virtual DbSet<SoftwareSystem> SoftwareSystems { get; set; } = null!;
        public virtual DbSet<SoftwareVersion> SoftwareVersions { get; set; } = null!;
        public virtual DbSet<SsrdTask> SsrdTasks { get; set; } = null!;
        public virtual DbSet<StatusChange> StatusChanges { get; set; } = null!;
        public virtual DbSet<TestEvent> TestEvents { get; set; } = null!;
        public virtual DbSet<TestEventDr> TestEventDrs { get; set; } = null!;
        public virtual DbSet<TestEventIssue> TestEventIssues { get; set; } = null!;
        public virtual DbSet<UserLog> UserLogs { get; set; } = null!;
        public virtual DbSet<VersionsLoad> VersionsLoads { get; set; } = null!;

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
                optionsBuilder.UseSqlServer("Server=F5010-9Y7HZH3-L;Database=FSTSSDatabase;Trusted_Connection=True;");
            }
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Baseline>(entity =>
            {
                entity.Property(e => e.BaseLineDate).HasColumnType("datetime");

                entity.Property(e => e.EnteredBy).HasMaxLength(255);

                entity.Property(e => e.EnteredDate).HasColumnType("datetime");

                entity.HasOne(d => d.Dr)
                    .WithMany(p => p.Baselines)
                    .HasForeignKey(d => d.DrId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_Baselines_Drs");
            });

            modelBuilder.Entity<Comment>(entity =>
            {
                entity.Property(e => e.CommentDate).HasColumnType("datetime");

                entity.Property(e => e.EnteredBy).HasMaxLength(255);

                entity.HasOne(d => d.Issue)
                    .WithMany(p => p.Comments)
                    .HasForeignKey(d => d.IssueId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_Comments_Issues");
            });

            modelBuilder.Entity<CorrectiveAction>(entity =>
            {
                entity.Property(e => e.Name).HasMaxLength(255);
            });

            modelBuilder.Entity<Device>(entity =>
            {
                entity.Property(e => e.Name)
                    .HasMaxLength(20)
                    .IsUnicode(false);

                entity.HasOne(d => d.DeviceType)
                    .WithMany(p => p.Devices)
                    .HasForeignKey(d => d.DeviceTypeId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_Devices_DeviceTypes");
            });

            modelBuilder.Entity<DeviceDiscovered>(entity =>
            {
                entity.ToTable("DeviceDiscovered");

                entity.HasOne(d => d.Device)
                    .WithMany(p => p.DeviceDiscovereds)
                    .HasForeignKey(d => d.DeviceId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_DeviceDiscovered_Devices");

                entity.HasOne(d => d.Issue)
                    .WithMany(p => p.DeviceDiscovereds)
                    .HasForeignKey(d => d.IssueId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_DeviceDiscovered_Issues");
            });

            modelBuilder.Entity<DeviceType>(entity =>
            {
                entity.Property(e => e.Name).HasMaxLength(255);

                entity.HasOne(d => d.Maintainer)
                    .WithMany(p => p.DeviceTypes)
                    .HasForeignKey(d => d.MaintainerId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_DeviceTypes_Maintainers");
            });

            modelBuilder.Entity<DocumentLink>(entity =>
            {
                entity.Property(e => e.Title).HasMaxLength(255);

                entity.Property(e => e.Url).HasMaxLength(255);

                entity.HasOne(d => d.Issue)
                    .WithMany(p => p.DocumentLinks)
                    .HasForeignKey(d => d.IssueId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_DocumentLinks_Issues");
            });

            modelBuilder.Entity<Dr>(entity =>
            {
                entity.HasOne(d => d.Issue)
                    .WithMany(p => p.Drs)
                    .HasForeignKey(d => d.IssueId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_Drs_Issues");
            });

            modelBuilder.Entity<DrDissent>(entity =>
            {
                entity.HasOne(d => d.Dr)
                    .WithMany(p => p.DrDissents)
                    .HasForeignKey(d => d.DrId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_DrDissents_Drs");
            });

            modelBuilder.Entity<DrDuplicate>(entity =>
            {
                entity.HasOne(d => d.Dr)
                    .WithMany(p => p.DrDuplicates)
                    .HasForeignKey(d => d.Drid)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_DrDuplicates_Drs");
            });

            modelBuilder.Entity<DrType>(entity =>
            {
                entity.Property(e => e.Name)
                    .HasMaxLength(5)
                    .IsUnicode(false);
            });

            modelBuilder.Entity<Drrb>(entity =>
            {
                entity.Property(e => e.DrrbDate).HasColumnType("datetime");

                entity.HasOne(d => d.DeviceType)
                    .WithMany(p => p.Drrbs)
                    .HasForeignKey(d => d.DeviceTypeId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_Drrbs_DeviceTypes");
            });

            modelBuilder.Entity<DrrbIssue>(entity =>
            {
                entity.HasOne(d => d.Drrb)
                    .WithMany(p => p.DrrbIssues)
                    .HasForeignKey(d => d.DrrbId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_DrrbIssues_Drrbs");

                entity.HasOne(d => d.Issue)
                    .WithMany(p => p.DrrbIssues)
                    .HasForeignKey(d => d.IssueId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_DrrbIssues_Issues");
            });

            modelBuilder.Entity<GetConfigByLoadId>(entity =>
            {
                entity.HasNoKey();

                entity.ToView("GetConfigByLoadId");

                entity.Property(e => e.Name)
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.Version)
                    .HasMaxLength(50)
                    .IsUnicode(false);
            });

            modelBuilder.Entity<GrfrHistory>(entity =>
            {
                entity.Property(e => e.EnteredBy).HasMaxLength(255);

                entity.Property(e => e.EnteredDate).HasColumnType("datetime");

                entity.Property(e => e.GrfrDate).HasColumnType("datetime");

                entity.HasOne(d => d.Dr)
                    .WithMany(p => p.GrfrHistories)
                    .HasForeignKey(d => d.DrId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_GrfrHistories_Drs");
            });

            modelBuilder.Entity<GrfrPlan>(entity =>
            {
                entity.Property(e => e.EnteredBy).HasMaxLength(255);

                entity.Property(e => e.EnteredDate).HasColumnType("datetime");

                entity.Property(e => e.GrfrDate).HasColumnType("datetime");

                entity.HasOne(d => d.Dr)
                    .WithMany(p => p.GrfrPlans)
                    .HasForeignKey(d => d.DrId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_GrfrPlans_Drs");
            });

            modelBuilder.Entity<HardwareConfig>(entity =>
            {
                entity.Property(e => e.Name)
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.HasOne(d => d.DeviceType)
                    .WithMany(p => p.HardwareConfigs)
                    .HasForeignKey(d => d.DeviceTypeId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_HardwareConfigs_DeviceTypes");
            });

            modelBuilder.Entity<HardwareSystem>(entity =>
            {
                entity.Property(e => e.Name)
                    .HasMaxLength(50)
                    .IsUnicode(false);
            });

            modelBuilder.Entity<HardwareVersion>(entity =>
            {
                entity.Property(e => e.Name)
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.VersionDate).HasColumnType("datetime");

                entity.HasOne(d => d.HardwareSystem)
                    .WithMany(p => p.HardwareVersions)
                    .HasForeignKey(d => d.HardwareSystemId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_HardwareVersions_HardwareSystems");
            });

            modelBuilder.Entity<HardwareVersionsConfig>(entity =>
            {
                entity.HasOne(d => d.HardwareConfig)
                    .WithMany(p => p.HardwareVersionsConfigs)
                    .HasForeignKey(d => d.HardwareConfigId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_HardwareVersionsConfigs_HardwareConfigs");

                entity.HasOne(d => d.HardwareVersion)
                    .WithMany(p => p.HardwareVersionsConfigs)
                    .HasForeignKey(d => d.HardwareVersionId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_HardwareVersionsConfigs_HardwareVersions");
            });

            modelBuilder.Entity<Issue>(entity =>
            {
                entity.Property(e => e.EnteredBy).HasMaxLength(255);

                entity.Property(e => e.IssueDate).HasColumnType("datetime");

                entity.HasOne(d => d.DrType)
                    .WithMany(p => p.Issues)
                    .HasForeignKey(d => d.DrTypeId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_Issues_DrTypes");

                entity.HasOne(d => d.SimStatus)
                    .WithMany(p => p.Issues)
                    .HasForeignKey(d => d.SimStatusId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_Issues_SimStatuses");
            });

            modelBuilder.Entity<IssueConfiguration>(entity =>
            {
                entity.HasOne(d => d.Config)
                    .WithMany(p => p.IssueConfigurations)
                    .HasForeignKey(d => d.ConfigId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_IssueConfigurations_RctdConfigurations");

                entity.HasOne(d => d.Issue)
                    .WithMany(p => p.IssueConfigurations)
                    .HasForeignKey(d => d.IssueId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_IssueConfigurations_Issues");
            });

            modelBuilder.Entity<IssueObserved>(entity =>
            {
                entity.ToTable("IssueObserved");

                entity.Property(e => e.DateObserved).HasColumnType("datetime");

                entity.HasOne(d => d.Device)
                    .WithMany(p => p.IssueObserveds)
                    .HasForeignKey(d => d.DeviceId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_IssueObserved_Devices");

                entity.HasOne(d => d.Issue)
                    .WithMany(p => p.IssueObserveds)
                    .HasForeignKey(d => d.IssueId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_IssueObserved_Issues");
            });

            modelBuilder.Entity<IssueSsrdTask>(entity =>
            {
                entity.HasOne(d => d.Issue)
                    .WithMany(p => p.IssueSsrdTasks)
                    .HasForeignKey(d => d.IssueId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_IssueSsrdTasks_Issues");

                entity.HasOne(d => d.SsrdTask)
                    .WithMany(p => p.IssueSsrdTasks)
                    .HasForeignKey(d => d.SsrdTaskId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_IssueSsrdTasks_SsrdTasks");
            });

            modelBuilder.Entity<IssuesDevice>(entity =>
            {
                entity.HasOne(d => d.Device)
                    .WithMany(p => p.IssuesDevices)
                    .HasForeignKey(d => d.DeviceId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_IssueDevices_Devices");

                entity.HasOne(d => d.Issue)
                    .WithMany(p => p.IssuesDevices)
                    .HasForeignKey(d => d.IssueId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_IssueDevices_Issues");
            });

            modelBuilder.Entity<IssuesKeyword>(entity =>
            {
                entity.HasOne(d => d.Issue)
                    .WithMany(p => p.IssuesKeywords)
                    .HasForeignKey(d => d.IssueId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_IssuesKeywords_Issues");

                entity.HasOne(d => d.Keyword)
                    .WithMany(p => p.IssuesKeywords)
                    .HasForeignKey(d => d.KeywordId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_IssuesKeywords_Keywords");
            });

            modelBuilder.Entity<Keyword>(entity =>
            {
                entity.Property(e => e.Name).HasMaxLength(255);
            });

            modelBuilder.Entity<Load>(entity =>
            {
                entity.Property(e => e.Name)
                    .HasMaxLength(50)
                    .IsUnicode(false);
            });

            modelBuilder.Entity<LoadsDevice>(entity =>
            {
                entity.HasOne(d => d.Device)
                    .WithMany(p => p.LoadsDevices)
                    .HasForeignKey(d => d.DeviceId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_LoadsDevices_Devices");

                entity.HasOne(d => d.Load)
                    .WithMany(p => p.LoadsDevices)
                    .HasForeignKey(d => d.LoadId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_LoadsDevices_Loads");
            });

            modelBuilder.Entity<LoadsTestEvent>(entity =>
            {
                entity.HasOne(d => d.Load)
                    .WithMany(p => p.LoadsTestEvents)
                    .HasForeignKey(d => d.LoadId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_LoadEvents_Loads");

                entity.HasOne(d => d.TestEvent)
                    .WithMany(p => p.LoadsTestEvents)
                    .HasForeignKey(d => d.TestEventId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_LoadTable_TestEvents");
            });

            modelBuilder.Entity<MaintIssue>(entity =>
            {
                entity.Property(e => e.Pid).HasMaxLength(10);

                entity.HasOne(d => d.CorrectiveAction)
                    .WithMany(p => p.MaintIssues)
                    .HasForeignKey(d => d.CorrectiveActionId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_MaintIssues_CorrectiveActions");

                entity.HasOne(d => d.Issue)
                    .WithMany(p => p.MaintIssues)
                    .HasForeignKey(d => d.IssueId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_MaintIssues_Issues");
            });

            modelBuilder.Entity<Maintainer>(entity =>
            {
                entity.Property(e => e.Name).HasMaxLength(255);
            });

            modelBuilder.Entity<ManModule>(entity =>
            {
                entity.Property(e => e.Name)
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.HasOne(d => d.RctdLot)
                    .WithMany(p => p.ManModules)
                    .HasForeignKey(d => d.RctdLotId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_ManModules_RctdLots");
            });

            modelBuilder.Entity<RctdConfiguration>(entity =>
            {
                entity.Property(e => e.Name).HasMaxLength(20);
            });

            modelBuilder.Entity<RctdLot>(entity =>
            {
                entity.Property(e => e.Name)
                    .HasMaxLength(10)
                    .IsUnicode(false);

                entity.HasOne(d => d.DeviceType)
                    .WithMany(p => p.RctdLots)
                    .HasForeignKey(d => d.DeviceTypeId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_RctdLots_DeviceTypes");
            });

            modelBuilder.Entity<ResearchInfo>(entity =>
            {
                entity.Property(e => e.DeadlineDate).HasColumnType("datetime");

                entity.Property(e => e.ResearchDate).HasColumnType("datetime");

                entity.Property(e => e.ResearchLead).HasMaxLength(20);

                entity.HasOne(d => d.Issue)
                    .WithMany(p => p.ResearchInfos)
                    .HasForeignKey(d => d.IssueId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_ResearchInfos_Issues");
            });

            modelBuilder.Entity<SimStatus>(entity =>
            {
                entity.Property(e => e.IssueDisplayName).HasMaxLength(25);

                entity.Property(e => e.Name).HasMaxLength(25);

                entity.HasOne(d => d.SimStatusType)
                    .WithMany(p => p.SimStatuses)
                    .HasForeignKey(d => d.SimStatusTypeId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_SimStatuses_SimStatusTypes");
            });

            modelBuilder.Entity<SimStatusType>(entity =>
            {
                entity.Property(e => e.Name).HasMaxLength(25);
            });

            modelBuilder.Entity<SoftwareSystem>(entity =>
            {
                entity.Property(e => e.Name)
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.HasOne(d => d.HardwareConfig)
                    .WithMany(p => p.SoftwareSystems)
                    .HasForeignKey(d => d.HardwareConfigId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_SoftwareSystems_HardwareConfigs");
            });

            modelBuilder.Entity<SoftwareVersion>(entity =>
            {
                entity.Property(e => e.Name)
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.VersionDate).HasColumnType("datetime");

                entity.HasOne(d => d.SoftwareSystem)
                    .WithMany(p => p.SoftwareVersions)
                    .HasForeignKey(d => d.SoftwareSystemId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_SofwareVersions_SoftwareSystems");
            });

            modelBuilder.Entity<SsrdTask>(entity =>
            {
                entity.Property(e => e.Name).HasMaxLength(50);

                entity.HasOne(d => d.DeviceType)
                    .WithMany(p => p.SsrdTasks)
                    .HasForeignKey(d => d.DeviceTypeId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_SsrdTasks_DeviceTypes");
            });

            modelBuilder.Entity<StatusChange>(entity =>
            {
                entity.Property(e => e.EnteredBy).HasMaxLength(50);

                entity.Property(e => e.EnteredDate).HasColumnType("datetime");

                entity.HasOne(d => d.Issue)
                    .WithMany(p => p.StatusChanges)
                    .HasForeignKey(d => d.IssueId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_StatusChanges_Issues");

                entity.HasOne(d => d.SimStatus)
                    .WithMany(p => p.StatusChanges)
                    .HasForeignKey(d => d.SimStatusId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_StatusChanges_SimStatuses");
            });

            modelBuilder.Entity<TestEvent>(entity =>
            {
                entity.Property(e => e.Name).HasMaxLength(255);

                entity.Property(e => e.TestEventDate).HasColumnType("datetime");

                entity.HasOne(d => d.Device)
                    .WithMany(p => p.TestEvents)
                    .HasForeignKey(d => d.DeviceId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_TestEvents_Devices");
            });

            modelBuilder.Entity<TestEventDr>(entity =>
            {
                entity.HasOne(d => d.Dr)
                    .WithMany(p => p.TestEventDrs)
                    .HasForeignKey(d => d.DrId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_TestEventDrs_Drs");

                entity.HasOne(d => d.TestEvent)
                    .WithMany(p => p.TestEventDrs)
                    .HasForeignKey(d => d.TestEventId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_TestEventDrs_TestEvents");
            });

            modelBuilder.Entity<TestEventIssue>(entity =>
            {
                entity.HasOne(d => d.Issue)
                    .WithMany(p => p.TestEventIssues)
                    .HasForeignKey(d => d.IssueId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_TestEventIssues_Issues");

                entity.HasOne(d => d.TestEvent)
                    .WithMany(p => p.TestEventIssues)
                    .HasForeignKey(d => d.TestEventId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_TestEventIssues_TestEvents");
            });

            modelBuilder.Entity<UserLog>(entity =>
            {
                entity.Property(e => e.IpAddress).HasMaxLength(25);

                entity.Property(e => e.LoginDateTime).HasColumnType("datetime");

                entity.Property(e => e.UserName).HasMaxLength(50);
            });

            modelBuilder.Entity<VersionsLoad>(entity =>
            {
                entity.HasOne(d => d.Load)
                    .WithMany(p => p.VersionsLoads)
                    .HasForeignKey(d => d.LoadId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_VersionsLoads_Loads");

                entity.HasOne(d => d.SoftwareVersion)
                    .WithMany(p => p.VersionsLoads)
                    .HasForeignKey(d => d.SoftwareVersionId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_VersionsLoads_SofwareVersions");
            });

            OnModelCreatingPartial(modelBuilder);
        }

        partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
    }
}
