using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;
using Pomelo.EntityFrameworkCore.MySql.Scaffolding.Internal;

namespace hosxpapi.Models;

public partial class ApplicationDbContext : DbContext
{
    public ApplicationDbContext()
    {
    }

    public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
        : base(options)
    {
    }

    public virtual DbSet<Opduser> Opdusers { get; set; }

    public virtual DbSet<Ovst> Ovsts { get; set; }

    public virtual DbSet<Patient> Patients { get; set; }

    public virtual DbSet<Ward> Wards { get; set; }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
#warning To protect potentially sensitive information in your connection string, you should move it out of source code. You can avoid scaffolding the connection string by using the Name= syntax to read it from configuration - see https://go.microsoft.com/fwlink/?linkid=2131148. For more guidance on storing connection strings, see https://go.microsoft.com/fwlink/?LinkId=723263.
        => optionsBuilder.UseMySql("server=172.16.5.39;port=3306;database=hos;userid=coachnrm;password=his_api_slave", Microsoft.EntityFrameworkCore.ServerVersion.Parse("10.1.37-mariadb"));

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder
            .UseCollation("tis620_thai_ci")
            .HasCharSet("tis620");

        modelBuilder.Entity<Opduser>(entity =>
        {
            entity.HasKey(e => e.Loginname).HasName("PRIMARY");

            entity.ToTable("opduser");

            entity.HasIndex(e => e.Department, "department");

            entity.HasIndex(e => e.Groupname, "groupname");

            entity.HasIndex(e => e.Cid, "ix_cid");

            entity.HasIndex(e => e.Doctorcode, "ix_doctorcode");

            entity.HasIndex(e => e.HosGuid, "ix_hos_guid");

            entity.HasIndex(e => e.HosGuidExt, "ix_hos_guid_ext");

            entity.HasIndex(e => e.Name, "name");

            entity.HasIndex(e => e.Password, "password");

            entity.Property(e => e.Loginname)
                .HasMaxLength(250)
                .HasColumnName("loginname");
            entity.Property(e => e.Accessright)
                .HasColumnType("text")
                .HasColumnName("accessright");
            entity.Property(e => e.AccountDisable)
                .HasMaxLength(1)
                .IsFixedLength()
                .HasColumnName("account_disable");
            entity.Property(e => e.AnnounceReadCount)
                .HasColumnType("int(11)")
                .HasColumnName("announce_read_count");
            entity.Property(e => e.AutoLogoutMinute)
                .HasColumnType("int(11)")
                .HasColumnName("auto_logout_minute");
            entity.Property(e => e.CheckLabPassword)
                .HasMaxLength(1)
                .IsFixedLength()
                .HasColumnName("check_lab_password");
            entity.Property(e => e.Cid)
                .HasMaxLength(13)
                .HasColumnName("cid");
            entity.Property(e => e.Department)
                .HasMaxLength(250)
                .HasColumnName("department");
            entity.Property(e => e.Departmentposition)
                .HasMaxLength(250)
                .HasColumnName("departmentposition");
            entity.Property(e => e.Doctorcode)
                .HasMaxLength(7)
                .HasColumnName("doctorcode");
            entity.Property(e => e.DrugAccessLevel)
                .HasColumnType("tinyint(4)")
                .HasColumnName("drug_access_level");
            entity.Property(e => e.Entryposition)
                .HasMaxLength(250)
                .HasColumnName("entryposition");
            entity.Property(e => e.Groupname)
                .HasMaxLength(250)
                .HasColumnName("groupname");
            entity.Property(e => e.HosGuid)
                .HasMaxLength(38)
                .HasColumnName("hos_guid");
            entity.Property(e => e.HosGuidExt)
                .HasMaxLength(64)
                .HasColumnName("hos_guid_ext");
            entity.Property(e => e.HospitalDepartmentId)
                .HasColumnType("int(11)")
                .HasColumnName("hospital_department_id");
            entity.Property(e => e.IclaimJwt)
                .HasColumnType("text")
                .HasColumnName("iclaim_jwt");
            entity.Property(e => e.LabCheckPassword)
                .HasMaxLength(1)
                .IsFixedLength()
                .HasColumnName("lab_check_password");
            entity.Property(e => e.LabStaff)
                .HasMaxLength(1)
                .IsFixedLength()
                .HasColumnName("lab_staff");
            entity.Property(e => e.MaxStation)
                .HasColumnType("int(11)")
                .HasColumnName("max_station");
            entity.Property(e => e.MophAccPassword)
                .HasMaxLength(250)
                .HasColumnName("moph_acc_password");
            entity.Property(e => e.MophAccUser)
                .HasMaxLength(50)
                .HasColumnName("moph_acc_user");
            entity.Property(e => e.Name)
                .HasMaxLength(250)
                .HasColumnName("name");
            entity.Property(e => e.NewPasswordDate).HasColumnName("new_password_date");
            entity.Property(e => e.NhsoPassword)
                .HasMaxLength(250)
                .HasColumnName("nhso_password");
            entity.Property(e => e.NhsoUser)
                .HasMaxLength(250)
                .HasColumnName("nhso_user");
            entity.Property(e => e.NoAnnounceDisplay)
                .HasMaxLength(1)
                .IsFixedLength()
                .HasColumnName("no_announce_display");
            entity.Property(e => e.NoDoctorConsultDisplay)
                .HasMaxLength(1)
                .IsFixedLength()
                .HasColumnName("no_doctor_consult_display");
            entity.Property(e => e.NoLabResultDisplay)
                .HasMaxLength(1)
                .IsFixedLength()
                .HasColumnName("no_lab_result_display");
            entity.Property(e => e.Passweb)
                .HasMaxLength(250)
                .HasColumnName("passweb");
            entity.Property(e => e.Password)
                .HasMaxLength(250)
                .HasColumnName("password");
            entity.Property(e => e.PasswordExpireDate).HasColumnName("password_expire_date");
            entity.Property(e => e.PasswordRecheckDate)
                .HasColumnType("int(11)")
                .HasColumnName("password_recheck_date");
            entity.Property(e => e.PcuUser)
                .HasMaxLength(1)
                .IsFixedLength()
                .HasColumnName("pcu_user");
            entity.Property(e => e.Picture).HasColumnName("picture");
            entity.Property(e => e.RealStaff)
                .HasMaxLength(1)
                .IsFixedLength()
                .HasColumnName("real_staff");
            entity.Property(e => e.RestrictClinicAccess)
                .HasMaxLength(1)
                .IsFixedLength()
                .HasColumnName("restrict_clinic_access");
            entity.Property(e => e.RestrictWardAccess)
                .HasMaxLength(1)
                .IsFixedLength()
                .HasColumnName("restrict_ward_access");
            entity.Property(e => e.SendMophOtp)
                .HasMaxLength(1)
                .IsFixedLength()
                .HasColumnName("send_moph_otp");
            entity.Property(e => e.ShowTip)
                .HasMaxLength(1)
                .IsFixedLength()
                .HasColumnName("show_tip");
            entity.Property(e => e.Startfullscreen)
                .HasMaxLength(1)
                .IsFixedLength()
                .HasColumnName("startfullscreen");
            entity.Property(e => e.Turbohosxp)
                .HasMaxLength(1)
                .IsFixedLength()
                .HasColumnName("turbohosxp");
            entity.Property(e => e.Viewallmenu)
                .HasMaxLength(1)
                .IsFixedLength()
                .HasColumnName("viewallmenu");
            entity.Property(e => e.VisibleMenu)
                .HasColumnType("text")
                .HasColumnName("visible_menu");
            entity.Property(e => e.XrayStaff)
                .HasMaxLength(1)
                .IsFixedLength()
                .HasColumnName("xray_staff");
        });

        modelBuilder.Entity<Ovst>(entity =>
        {
            entity.HasKey(e => e.HosGuid).HasName("PRIMARY");

            entity.ToTable("ovst");

            entity.HasIndex(e => e.An, "ix_an");

            entity.HasIndex(e => e.AnonymousVn, "ix_anonymous_vn");

            entity.HasIndex(e => e.Doctor, "ix_doctor");

            entity.HasIndex(e => e.Hcode, "ix_hcode");

            entity.HasIndex(e => e.Hn, "ix_hn");

            entity.HasIndex(e => new { e.Hn, e.Vstdate }, "ix_hn_vstdate");

            entity.HasIndex(e => e.IReferNumber, "ix_i_refer_number");

            entity.HasIndex(e => e.OReferNumber, "ix_o_refer_number");

            entity.HasIndex(e => e.Pttype, "ix_pttype");

            entity.HasIndex(e => e.Spclty, "ix_spclty");

            entity.HasIndex(e => e.Staff, "ix_staff");

            entity.HasIndex(e => new { e.Vn, e.AnonymousVisit, e.AnonymousVn }, "ix_vn_anonymous_vs_vn");

            entity.HasIndex(e => new { e.Vn, e.Vstdate }, "ix_vn_date");

            entity.HasIndex(e => e.Vn, "ix_vn_unique").IsUnique();

            entity.HasIndex(e => e.Vstdate, "ix_vstdate");

            entity.HasIndex(e => new { e.Vstdate, e.CurDep }, "ix_vstdate_curdep");

            entity.Property(e => e.HosGuid)
                .HasMaxLength(38)
                .HasColumnName("hos_guid");
            entity.Property(e => e.An)
                .HasMaxLength(9)
                .HasColumnName("an");
            entity.Property(e => e.AnonymousVisit)
                .HasMaxLength(1)
                .IsFixedLength()
                .HasColumnName("anonymous_visit");
            entity.Property(e => e.AnonymousVn)
                .HasMaxLength(12)
                .HasColumnName("anonymous_vn");
            entity.Property(e => e.AtHospital)
                .HasMaxLength(1)
                .IsFixedLength()
                .HasColumnName("at_hospital");
            entity.Property(e => e.CommandDoctor)
                .HasMaxLength(6)
                .HasColumnName("command_doctor");
            entity.Property(e => e.ContractId)
                .HasColumnType("int(11)")
                .HasColumnName("contract_id");
            entity.Property(e => e.CurDep)
                .HasMaxLength(3)
                .IsFixedLength()
                .HasColumnName("cur_dep");
            entity.Property(e => e.CurDepBusy)
                .HasMaxLength(1)
                .IsFixedLength()
                .HasColumnName("cur_dep_busy");
            entity.Property(e => e.CurDepTime)
                .HasColumnType("time")
                .HasColumnName("cur_dep_time");
            entity.Property(e => e.DiagText)
                .HasMaxLength(250)
                .HasColumnName("diag_text");
            entity.Property(e => e.Doctor)
                .HasMaxLength(7)
                .HasColumnName("doctor");
            entity.Property(e => e.FinanceAlient)
                .HasMaxLength(50)
                .HasColumnName("finance_alient");
            entity.Property(e => e.FinanceLock)
                .HasMaxLength(1)
                .IsFixedLength()
                .HasColumnName("finance_lock");
            entity.Property(e => e.FinanceSummaryDate).HasColumnName("finance_summary_date");
            entity.Property(e => e.HasInsurance)
                .HasMaxLength(1)
                .IsFixedLength()
                .HasColumnName("has_insurance");
            entity.Property(e => e.Hcode)
                .HasMaxLength(5)
                .HasColumnName("hcode");
            entity.Property(e => e.Hn)
                .HasMaxLength(9)
                .HasColumnName("hn");
            entity.Property(e => e.Hospmain)
                .HasMaxLength(5)
                .HasColumnName("hospmain");
            entity.Property(e => e.Hospsub)
                .HasMaxLength(5)
                .HasColumnName("hospsub");
            entity.Property(e => e.IReferNumber)
                .HasMaxLength(25)
                .HasColumnName("i_refer_number");
            entity.Property(e => e.LastDep)
                .HasMaxLength(3)
                .IsFixedLength()
                .HasColumnName("last_dep");
            entity.Property(e => e.MainDep)
                .HasMaxLength(3)
                .IsFixedLength()
                .HasColumnName("main_dep");
            entity.Property(e => e.MainDepQueue)
                .HasColumnType("int(11)")
                .HasColumnName("main_dep_queue");
            entity.Property(e => e.NodeId)
                .HasMaxLength(1)
                .IsFixedLength()
                .HasColumnName("node_id");
            entity.Property(e => e.OReferDep)
                .HasMaxLength(5)
                .HasColumnName("o_refer_dep");
            entity.Property(e => e.OReferNumber)
                .HasColumnType("int(11)")
                .HasColumnName("o_refer_number");
            entity.Property(e => e.Oldcode)
                .HasMaxLength(20)
                .HasColumnName("oldcode");
            entity.Property(e => e.Oqueue)
                .HasColumnType("int(11)")
                .HasColumnName("oqueue");
            entity.Property(e => e.OvstKey)
                .HasMaxLength(40)
                .HasColumnName("ovst_key");
            entity.Property(e => e.Ovstist)
                .HasMaxLength(2)
                .IsFixedLength()
                .HasColumnName("ovstist");
            entity.Property(e => e.Ovstost)
                .HasMaxLength(4)
                .HasColumnName("ovstost");
            entity.Property(e => e.PtCapabilityTypeId)
                .HasColumnType("int(11)")
                .HasColumnName("pt_capability_type_id");
            entity.Property(e => e.PtPriority)
                .HasColumnType("int(11)")
                .HasColumnName("pt_priority");
            entity.Property(e => e.PtSubtype)
                .HasColumnType("tinyint(4)")
                .HasColumnName("pt_subtype");
            entity.Property(e => e.Pttype)
                .HasMaxLength(2)
                .IsFixedLength()
                .HasColumnName("pttype");
            entity.Property(e => e.Pttypeno)
                .HasMaxLength(50)
                .HasColumnName("pttypeno");
            entity.Property(e => e.RcptDisease)
                .HasMaxLength(100)
                .HasColumnName("rcpt_disease");
            entity.Property(e => e.ReferType)
                .HasMaxLength(1)
                .IsFixedLength()
                .HasColumnName("refer_type");
            entity.Property(e => e.RfriIcd10)
                .HasMaxLength(6)
                .HasColumnName("rfri_icd10");
            entity.Property(e => e.Rfrics)
                .HasMaxLength(1)
                .IsFixedLength()
                .HasColumnName("rfrics");
            entity.Property(e => e.Rfrilct)
                .HasMaxLength(5)
                .HasColumnName("rfrilct");
            entity.Property(e => e.Rfrocs)
                .HasMaxLength(1)
                .IsFixedLength()
                .HasColumnName("rfrocs");
            entity.Property(e => e.Rfrolct)
                .HasMaxLength(5)
                .HasColumnName("rfrolct");
            entity.Property(e => e.RxQueue)
                .HasColumnType("int(11)")
                .HasColumnName("rx_queue");
            entity.Property(e => e.SendPerson)
                .HasMaxLength(150)
                .HasColumnName("send_person");
            entity.Property(e => e.SignDoctor)
                .HasMaxLength(10)
                .HasColumnName("sign_doctor");
            entity.Property(e => e.Spclty)
                .HasMaxLength(2)
                .IsFixedLength()
                .HasColumnName("spclty");
            entity.Property(e => e.Staff)
                .HasMaxLength(25)
                .HasColumnName("staff");
            entity.Property(e => e.VisitType)
                .HasMaxLength(1)
                .IsFixedLength()
                .HasColumnName("visit_type");
            entity.Property(e => e.Vn)
                .HasMaxLength(13)
                .HasColumnName("vn");
            entity.Property(e => e.Vstdate).HasColumnName("vstdate");
            entity.Property(e => e.Vsttime)
                .HasColumnType("time")
                .HasColumnName("vsttime");
            entity.Property(e => e.Waiting)
                .HasMaxLength(1)
                .IsFixedLength()
                .HasColumnName("waiting");
        });

        modelBuilder.Entity<Patient>(entity =>
        {
            entity.HasKey(e => e.HosGuid).HasName("PRIMARY");

            entity.ToTable("patient");

            entity.HasIndex(e => new { e.Chwpart, e.Amppart, e.Tmbpart }, "ix_address");

            entity.HasIndex(e => e.Chwpart, "ix_chwpart");

            entity.HasIndex(e => e.Cid, "ix_cid");

            entity.HasIndex(e => e.Clinic, "ix_clinic");

            entity.HasIndex(e => e.Deathday, "ix_deathday");

            entity.HasIndex(e => e.Firstday, "ix_firstday");

            entity.HasIndex(e => e.Fname, "ix_fname");

            entity.HasIndex(e => new { e.Fname, e.Lname }, "ix_fname_lname");

            entity.HasIndex(e => e.FnameSoundex, "ix_fname_soundex");

            entity.HasIndex(e => e.Hcode, "ix_hcode");

            entity.HasIndex(e => e.Hn, "ix_hn_unique").IsUnique();

            entity.HasIndex(e => e.LastUpdate, "ix_last_update");

            entity.HasIndex(e => e.LastVisit, "ix_lastvisit");

            entity.HasIndex(e => e.Lname, "ix_lname");

            entity.HasIndex(e => e.LnameSoundex, "ix_lname_soundex");

            entity.HasIndex(e => e.MembercardNo, "ix_membercard_no");

            entity.HasIndex(e => e.Oldcode, "ix_oldcode");

            entity.HasIndex(e => e.PassportNo, "ix_passport_no");

            entity.HasIndex(e => e.Pname, "ix_pname");

            entity.HasIndex(e => e.Pttype, "ix_pttype");

            entity.Property(e => e.HosGuid)
                .HasMaxLength(38)
                .HasColumnName("hos_guid");
            entity.Property(e => e.AddrSoi)
                .HasMaxLength(100)
                .HasColumnName("addr_soi");
            entity.Property(e => e.Addressid)
                .HasMaxLength(6)
                .HasColumnName("addressid");
            entity.Property(e => e.Addrpart)
                .HasMaxLength(50)
                .HasColumnName("addrpart");
            entity.Property(e => e.Admit)
                .HasMaxLength(1)
                .IsFixedLength()
                .HasColumnName("admit");
            entity.Property(e => e.AliasName)
                .HasMaxLength(100)
                .HasColumnName("alias_name");
            entity.Property(e => e.Amppart)
                .HasMaxLength(2)
                .IsFixedLength()
                .HasColumnName("amppart");
            entity.Property(e => e.AnonymousPerson)
                .HasMaxLength(1)
                .IsFixedLength()
                .HasColumnName("anonymous_person");
            entity.Property(e => e.BirthOrder)
                .HasColumnType("int(11)")
                .HasColumnName("birth_order");
            entity.Property(e => e.Birthday).HasColumnName("birthday");
            entity.Property(e => e.Birthtime)
                .HasColumnType("time")
                .HasColumnName("birthtime");
            entity.Property(e => e.BloodgroupRh)
                .HasMaxLength(5)
                .HasColumnName("bloodgroup_rh");
            entity.Property(e => e.Bloodgrp)
                .HasMaxLength(20)
                .HasColumnName("bloodgrp");
            entity.Property(e => e.CardDestroyDate).HasColumnName("card_destroy_date");
            entity.Property(e => e.Chwpart)
                .HasMaxLength(2)
                .IsFixedLength()
                .HasColumnName("chwpart");
            entity.Property(e => e.Cid)
                .HasMaxLength(13)
                .HasColumnName("cid");
            entity.Property(e => e.Citizenship)
                .HasMaxLength(3)
                .IsFixedLength()
                .HasColumnName("citizenship");
            entity.Property(e => e.Clinic)
                .HasMaxLength(100)
                .HasColumnName("clinic");
            entity.Property(e => e.Country)
                .HasMaxLength(2)
                .IsFixedLength()
                .HasColumnName("country");
            entity.Property(e => e.CoupleCid)
                .HasMaxLength(13)
                .HasColumnName("couple_cid");
            entity.Property(e => e.Death)
                .HasMaxLength(1)
                .IsFixedLength()
                .HasColumnName("death");
            entity.Property(e => e.DeathCode504)
                .HasMaxLength(2)
                .IsFixedLength()
                .HasColumnName("death_code504");
            entity.Property(e => e.DeathDiag)
                .HasMaxLength(6)
                .HasColumnName("death_diag");
            entity.Property(e => e.Deathday).HasColumnName("deathday");
            entity.Property(e => e.Destroyed)
                .HasMaxLength(1)
                .IsFixedLength()
                .HasColumnName("destroyed");
            entity.Property(e => e.Drugallergy)
                .HasMaxLength(250)
                .HasColumnName("drugallergy");
            entity.Property(e => e.EcFname)
                .HasMaxLength(50)
                .HasColumnName("ec_fname");
            entity.Property(e => e.EcLname)
                .HasMaxLength(50)
                .HasColumnName("ec_lname");
            entity.Property(e => e.EcRelationTypeId)
                .HasColumnType("int(11)")
                .HasColumnName("ec_relation_type_id");
            entity.Property(e => e.Educate)
                .HasMaxLength(1)
                .IsFixedLength()
                .HasColumnName("educate");
            entity.Property(e => e.Email)
                .HasMaxLength(50)
                .HasColumnName("email");
            entity.Property(e => e.FamilyStatus)
                .HasMaxLength(1)
                .IsFixedLength()
                .HasColumnName("family_status");
            entity.Property(e => e.Familyno)
                .HasColumnType("int(11)")
                .HasColumnName("familyno");
            entity.Property(e => e.FatherCid)
                .HasMaxLength(13)
                .HasColumnName("father_cid");
            entity.Property(e => e.FatherHn)
                .HasMaxLength(9)
                .HasColumnName("father_hn");
            entity.Property(e => e.Fatherlname)
                .HasMaxLength(30)
                .HasColumnName("fatherlname");
            entity.Property(e => e.Fathername)
                .HasMaxLength(50)
                .HasColumnName("fathername");
            entity.Property(e => e.Firstday).HasColumnName("firstday");
            entity.Property(e => e.Fname)
                .HasMaxLength(30)
                .HasColumnName("fname");
            entity.Property(e => e.FnameSoundex)
                .HasMaxLength(50)
                .HasColumnName("fname_soundex");
            entity.Property(e => e.G6pd)
                .HasMaxLength(1)
                .IsFixedLength()
                .HasColumnName("g6pd");
            entity.Property(e => e.GovChronicId)
                .HasMaxLength(10)
                .HasColumnName("gov_chronic_id");
            entity.Property(e => e.Hcode)
                .HasMaxLength(5)
                .HasColumnName("hcode");
            entity.Property(e => e.Height)
                .HasColumnType("int(11)")
                .HasColumnName("height");
            entity.Property(e => e.Hid)
                .HasColumnType("int(11)")
                .HasColumnName("hid");
            entity.Property(e => e.Hn)
                .HasMaxLength(9)
                .HasColumnName("hn");
            entity.Property(e => e.HnInt)
                .HasColumnType("int(11)")
                .HasColumnName("hn_int");
            entity.Property(e => e.Hometel)
                .HasMaxLength(20)
                .HasColumnName("hometel");
            entity.Property(e => e.HospitalDepartmentId)
                .HasColumnType("int(11)")
                .HasColumnName("hospital_department_id");
            entity.Property(e => e.InCups)
                .HasMaxLength(1)
                .IsFixedLength()
                .HasColumnName("in_cups");
            entity.Property(e => e.Informaddr)
                .HasMaxLength(200)
                .HasColumnName("informaddr");
            entity.Property(e => e.Informname)
                .HasMaxLength(50)
                .HasColumnName("informname");
            entity.Property(e => e.Informrelation)
                .HasMaxLength(50)
                .HasColumnName("informrelation");
            entity.Property(e => e.Informtel)
                .HasMaxLength(20)
                .HasColumnName("informtel");
            entity.Property(e => e.Inregion)
                .HasMaxLength(1)
                .IsFixedLength()
                .HasColumnName("inregion");
            entity.Property(e => e.IsCardDestroy)
                .HasMaxLength(1)
                .IsFixedLength()
                .HasColumnName("is_card_destroy");
            entity.Property(e => e.LaborType)
                .HasMaxLength(1)
                .IsFixedLength()
                .HasColumnName("labor_type");
            entity.Property(e => e.Lang)
                .HasMaxLength(2)
                .IsFixedLength()
                .HasColumnName("lang");
            entity.Property(e => e.LastUpdate)
                .HasColumnType("datetime")
                .HasColumnName("last_update");
            entity.Property(e => e.LastVisit).HasColumnName("last_visit");
            entity.Property(e => e.LegalAction)
                .HasMaxLength(1)
                .IsFixedLength()
                .HasColumnName("legal_action");
            entity.Property(e => e.Lname)
                .HasMaxLength(30)
                .HasColumnName("lname");
            entity.Property(e => e.LnameSoundex)
                .HasMaxLength(50)
                .HasColumnName("lname_soundex");
            entity.Property(e => e.Marrystatus)
                .HasMaxLength(1)
                .IsFixedLength()
                .HasColumnName("marrystatus");
            entity.Property(e => e.Mathername)
                .HasMaxLength(50)
                .HasColumnName("mathername");
            entity.Property(e => e.MembercardNo)
                .HasMaxLength(15)
                .HasColumnName("membercard_no");
            entity.Property(e => e.Midname)
                .HasMaxLength(25)
                .HasColumnName("midname");
            entity.Property(e => e.MobilePhoneNumber)
                .HasMaxLength(20)
                .HasColumnName("mobile_phone_number");
            entity.Property(e => e.Moopart)
                .HasMaxLength(3)
                .IsFixedLength()
                .HasColumnName("moopart");
            entity.Property(e => e.MotherCid)
                .HasMaxLength(13)
                .HasColumnName("mother_cid");
            entity.Property(e => e.MotherHn)
                .HasMaxLength(9)
                .HasColumnName("mother_hn");
            entity.Property(e => e.Motherlname)
                .HasMaxLength(30)
                .HasColumnName("motherlname");
            entity.Property(e => e.Nationality)
                .HasMaxLength(3)
                .IsFixedLength()
                .HasColumnName("nationality");
            entity.Property(e => e.NodeId)
                .HasMaxLength(1)
                .IsFixedLength()
                .HasColumnName("node_id");
            entity.Property(e => e.NumberOfRelatives)
                .HasColumnType("int(11)")
                .HasColumnName("number_of_relatives");
            entity.Property(e => e.Occupation)
                .HasMaxLength(4)
                .HasColumnName("occupation");
            entity.Property(e => e.OldAddr)
                .HasMaxLength(250)
                .HasColumnName("old_addr");
            entity.Property(e => e.Oldcode)
                .HasMaxLength(50)
                .HasColumnName("oldcode");
            entity.Property(e => e.Opdlocation)
                .HasMaxLength(50)
                .HasColumnName("opdlocation");
            entity.Property(e => e.PassportNo)
                .HasMaxLength(25)
                .HasColumnName("passport_no");
            entity.Property(e => e.PatientColorId)
                .HasColumnType("int(11)")
                .HasColumnName("patient_color_id");
            entity.Property(e => e.PatientTypeId)
                .HasColumnType("tinyint(4)")
                .HasColumnName("patient_type_id");
            entity.Property(e => e.PersonLaborTypeId)
                .HasColumnType("int(11)")
                .HasColumnName("person_labor_type_id");
            entity.Property(e => e.PersonType)
                .HasMaxLength(2)
                .IsFixedLength()
                .HasColumnName("person_type");
            entity.Property(e => e.Pname)
                .HasMaxLength(25)
                .HasColumnName("pname");
            entity.Property(e => e.PoCode)
                .HasMaxLength(5)
                .HasColumnName("po_code");
            entity.Property(e => e.PrivateDoctorName)
                .HasMaxLength(75)
                .HasColumnName("private_doctor_name");
            entity.Property(e => e.Pttype)
                .HasMaxLength(2)
                .IsFixedLength()
                .HasColumnName("pttype");
            entity.Property(e => e.RegTime)
                .HasColumnType("time")
                .HasColumnName("reg_time");
            entity.Property(e => e.Religion)
                .HasMaxLength(2)
                .IsFixedLength()
                .HasColumnName("religion");
            entity.Property(e => e.Road)
                .HasMaxLength(50)
                .HasColumnName("road");
            entity.Property(e => e.Sex)
                .HasMaxLength(1)
                .IsFixedLength()
                .HasColumnName("sex");
            entity.Property(e => e.Spslname)
                .HasMaxLength(30)
                .HasColumnName("spslname");
            entity.Property(e => e.Spsname)
                .HasMaxLength(50)
                .HasColumnName("spsname");
            entity.Property(e => e.Tmbpart)
                .HasMaxLength(2)
                .IsFixedLength()
                .HasColumnName("tmbpart");
            entity.Property(e => e.TranStatus)
                .HasMaxLength(1)
                .HasColumnName("tran_status");
            entity.Property(e => e.Truebirthday)
                .HasMaxLength(1)
                .IsFixedLength()
                .HasColumnName("truebirthday");
            entity.Property(e => e.TypeArea)
                .HasMaxLength(1)
                .IsFixedLength()
                .HasColumnName("type_area");
            entity.Property(e => e.WorkAddr1)
                .HasMaxLength(230)
                .HasColumnName("work_addr");
            entity.Property(e => e.Workaddr)
                .HasMaxLength(50)
                .HasColumnName("workaddr");
            entity.Property(e => e.Worktel)
                .HasMaxLength(20)
                .HasColumnName("worktel");
        });

        modelBuilder.Entity<Ward>(entity =>
        {
            entity.HasKey(e => e.Ward1).HasName("PRIMARY");

            entity.ToTable("ward");

            entity.HasIndex(e => e.HosGuid, "ix_hos_guid");

            entity.HasIndex(e => e.OldCode, "ix_old_code");

            entity.HasIndex(e => e.Name, "name");

            entity.Property(e => e.Ward1)
                .HasMaxLength(4)
                .HasColumnName("ward");
            entity.Property(e => e.Bedcount)
                .HasColumnType("int(11)")
                .HasColumnName("bedcount");
            entity.Property(e => e.HosGuid)
                .HasMaxLength(38)
                .HasColumnName("hos_guid");
            entity.Property(e => e.IpKey)
                .HasMaxLength(50)
                .HasColumnName("ip_key");
            entity.Property(e => e.IpdRxShiftTypeId)
                .HasColumnType("int(11)")
                .HasColumnName("ipd_rx_shift_type_id");
            entity.Property(e => e.Name)
                .HasMaxLength(250)
                .HasColumnName("name");
            entity.Property(e => e.NameOldSk)
                .HasMaxLength(250)
                .HasColumnName("name_old_sk");
            entity.Property(e => e.OldCode)
                .HasMaxLength(15)
                .HasColumnName("old_code");
            entity.Property(e => e.SelectBednoFromLayout)
                .HasMaxLength(1)
                .IsFixedLength()
                .HasColumnName("select_bedno_from_layout");
            entity.Property(e => e.ShortName1)
                .HasMaxLength(100)
                .HasColumnName("short_name");
            entity.Property(e => e.ShortNameBarcode)
                .HasMaxLength(100)
                .HasColumnName("short_name_barcode");
            entity.Property(e => e.Shortname)
                .HasMaxLength(20)
                .HasColumnName("shortname");
            entity.Property(e => e.Spclty)
                .HasMaxLength(2)
                .IsFixedLength()
                .HasColumnName("spclty");
            entity.Property(e => e.SssCode)
                .HasMaxLength(10)
                .HasColumnName("sss_code");
            entity.Property(e => e.StrictAccess)
                .HasMaxLength(1)
                .IsFixedLength()
                .HasColumnName("strict_access");
            entity.Property(e => e.WardActive)
                .HasMaxLength(1)
                .IsFixedLength()
                .HasColumnName("ward_active");
            entity.Property(e => e.WardExportCode)
                .HasMaxLength(50)
                .HasColumnName("ward_export_code");
        });

        OnModelCreatingPartial(modelBuilder);
    }

    partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
}
