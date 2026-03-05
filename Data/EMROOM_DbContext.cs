using Microsoft.EntityFrameworkCore;
using EMROOM_emproj.Models;

namespace EMROOM_emproj.Data;

public class EMROOM_DbContext : DbContext
{
    public EMROOM_DbContext(DbContextOptions<EMROOM_DbContext> options) : base(options)
    {
    }
    
    public DbSet<EMROOM_User> EMROOM_Users { get; set; }
    public DbSet<EMROOM_Patient> EMROOM_Patients { get; set; }
    public DbSet<EMROOM_Symptom> EMROOM_Symptoms { get; set; }
    public DbSet<EMROOM_Triage_Level> EMROOM_Triage_Levels { get; set; }
    public DbSet<EMROOM_Emergency_Case> EMROOM_Emergency_Cases { get; set; }
    public DbSet<EMROOM_Treatment> EMROOM_Treatments { get; set; }
    public DbSet<EMROOM_Case_Symptom> EMROOM_Case_Symptoms { get; set; }
    
    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        base.OnModelCreating(modelBuilder);
        
        modelBuilder.Entity<EMROOM_Emergency_Case>()
            .HasOne(ec => ec.EMROOM_Patient)
            .WithMany(p => p.EMROOM_Emergency_Cases)
            .HasForeignKey(ec => ec.EMROOM_Patient_Id)
            .OnDelete(DeleteBehavior.Restrict);
        
        modelBuilder.Entity<EMROOM_Emergency_Case>()
            .HasOne(ec => ec.EMROOM_Triage_Level)
            .WithMany(tl => tl.EMROOM_Emergency_Cases)
            .HasForeignKey(ec => ec.EMROOM_Triage_Id)
            .OnDelete(DeleteBehavior.Restrict);
        
        modelBuilder.Entity<EMROOM_Emergency_Case>()
            .HasOne(ec => ec.EMROOM_Nurse)
            .WithMany()
            .HasForeignKey(ec => ec.EMROOM_Triaged_By_Nurse_Id)
            .OnDelete(DeleteBehavior.Restrict);
        
        modelBuilder.Entity<EMROOM_Treatment>()
            .HasOne(t => t.EMROOM_Emergency_Case)
            .WithOne(ec => ec.EMROOM_Treatment)
            .HasForeignKey<EMROOM_Treatment>(t => t.EMROOM_Case_Id)
            .OnDelete(DeleteBehavior.Restrict);
        
        modelBuilder.Entity<EMROOM_Treatment>()
            .HasOne(t => t.EMROOM_User)
            .WithMany(u => u.EMROOM_Treatments)
            .HasForeignKey(t => t.EMROOM_Physician_Id)
            .OnDelete(DeleteBehavior.Restrict);
        
        // Many-to-Many relationship between Emergency Cases and Symptoms
        modelBuilder.Entity<EMROOM_Case_Symptom>()
            .HasOne(cs => cs.EMROOM_Emergency_Case)
            .WithMany(ec => ec.EMROOM_Case_Symptoms)
            .HasForeignKey(cs => cs.EMROOM_Case_Id)
            .OnDelete(DeleteBehavior.Cascade);
        
        modelBuilder.Entity<EMROOM_Case_Symptom>()
            .HasOne(cs => cs.EMROOM_Symptom)
            .WithMany(s => s.EMROOM_Case_Symptoms)
            .HasForeignKey(cs => cs.EMROOM_Symptom_Id)
            .OnDelete(DeleteBehavior.Restrict);
    }
}
