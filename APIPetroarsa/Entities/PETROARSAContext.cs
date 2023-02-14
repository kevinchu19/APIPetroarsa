using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;

#nullable disable

namespace ApiPetroarsa.Entities
{
    public partial class PETROARSAContext : DbContext
    {
        public PETROARSAContext()
        {
        }

        public PETROARSAContext(DbContextOptions<PETROARSAContext> options)
            : base(options)
        {
        }

        public virtual DbSet<Fcrmvh> Fcrmvh { get; set; }
        public virtual DbSet<Fcrmvi> Fcrmvi { get; set; }
        public virtual DbSet<Vtmclc> Vtmclc { get; set; }

        public virtual DbSet<Vtmclh> Vtmclh { get; set; }
        public virtual DbSet<Grtpac> Grtpac { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.HasAnnotation("Relational:Collation", "SQL_Latin1_General_CP1_CI_AS");

            modelBuilder.Entity<Fcrmvh>(entity =>
            {
                entity.HasKey(e => new { e.Fcrmvh_Modfor, e.Fcrmvh_Codfor, e.Fcrmvh_Nrofor });

                entity.ToTable("FCRMVH");
                
                entity.HasMany(e => e.Items)
                    .WithOne(c => c.Header);

                entity.HasIndex(e => new { e.Fcrmvh_Modfor, e.Fcrmvh_Codfor, e.Fcrmvh_Nrofor, e.Fcrmvh_Nrosub, e.Fcrmvh_Circom, e.Fcrmvh_Cirapl }, "GR_LIMITECREDITO");

                entity.HasIndex(e => e.Fcrmvh_Nrofor, "GR_NUMERATION");

                entity.HasIndex(e => new { e.Fcrmvh_Modfor, e.Fcrmvh_Codfor, e.Fcrmvh_Nrofor, e.Fcrmvh_Accfst }, "P_ST_STTEVHWIZ");

                entity.HasIndex(e => new { e.Fcrmvh_Codfor, e.Fcrmvh_Nrofor, e.Fcrmvh_Nrocta, e.Fcrmvh_Circom, e.Fcrmvh_Deposi, e.Fcrmvh_Modfor, e.Fcrmvh_Sector }, "T_FC_FCRMVH");

                entity.HasIndex(e => new { e.Fcrmvh_Modfor, e.Fcrmvh_Codfor, e.Fcrmvh_Nrofor, e.Fcrmvh_Fchmov }, "W_FC_FCRMVH");

                entity.HasIndex(e => new { e.Fcrmvh_Nrosub, e.Fcrmvh_Modfor, e.Fcrmvh_Codfor, e.Fcrmvh_Nrofor, e.Fcrmvh_Circom, e.Fcrmvh_Cirapl, e.Fcrmvh_Cndpag, e.Fcrmvh_Coflis, e.Fcrmvh_Cndiva }, "W_GR_FCRMVH");

                entity.HasIndex(e => new { e.Fcrmvh_Circom, e.Fcrmvh_Nrocta, e.Fcrmvh_Deposi, e.Fcrmvh_Sector, e.Fcrmvh_Codlis, e.Fcrmvh_Modfor, e.Fcrmvh_Codfor, e.Fcrmvh_Nrofor, e.Fcrmvh_Cirapl, e.Fcrmvh_Cndpag }, "W_GR_FCRMVH1");

                entity.HasIndex(e => new { e.Fcrmvh_Nroost, e.Fcrmvh_Modfor, e.Fcrmvh_Codfor, e.Fcrmvh_Nrofor, e.Fcrmvh_Cndpag, e.Fcrmvh_Tracod, e.Fcrmvh_Trcuit, e.Fcrmvh_Trandr, e.Fcrmvh_Modost, e.Fcrmvh_Codost }, "W_GR_FCRMVH2");

                entity.HasIndex(e => new { e.Fcrmvh_Modfor, e.Fcrmvh_Codfor, e.Fcrmvh_Nrofor, e.Fcrmvh_Circom, e.Fcrmvh_Nrosub, e.Fcrmvh_Cndpag, e.Fcrmvh_Cndiva, e.Fcrmvh_Cirapl, e.Fcrmvh_Coflis }, "W_GR_FCRMVH3");

                entity.HasIndex(e => new { e.Fcrmvh_Estaut, e.Fcrmvh_Modfor, e.Fcrmvh_Codfor, e.Fcrmvh_Nrofor, e.Fcrmvh_Fchmov }, "W_GR_FCRMVH4");

                entity.HasIndex(e => new { e.Fcrmvh_Modost, e.Fcrmvh_Codost, e.Fcrmvh_Nroost }, "W_ST_STRMVZ");

                entity.Property(e => e.Fcrmvh_Modfor)
                    .HasMaxLength(2)
                    .IsUnicode(false)
                    .HasColumnName("FCRMVH_MODFOR");

                entity.Property(e => e.Fcrmvh_Codfor)
                    .HasMaxLength(6)
                    .IsUnicode(false)
                    .HasColumnName("FCRMVH_CODFOR");

                entity.Property(e => e.Fcrmvh_Nrofor).HasColumnName("FCRMVH_NROFOR");

                entity.Property(e => e.Fcrmvh_Accfst)
                    .HasMaxLength(1)
                    .IsUnicode(false)
                    .HasColumnName("FCRMVH_ACCFST");

                entity.Property(e => e.Fcrmvh_Aerpue)
                    .HasMaxLength(6)
                    .IsUnicode(false)
                    .HasColumnName("FCRMVH_AERPUE");

                entity.Property(e => e.Fcrmvh_Auxdev)
                    .HasMaxLength(3)
                    .IsUnicode(false)
                    .HasColumnName("FCRMVH_AUXDEV");

                entity.Property(e => e.Fcrmvh_Bmpbmp)
                    .HasMaxLength(255)
                    .IsUnicode(false)
                    .HasColumnName("FCRMVH_BMPBMP");

                entity.Property(e => e.Fcrmvh_Cambio)
                    .HasColumnType("numeric(20, 8)")
                    .HasColumnName("FCRMVH_CAMBIO");

                entity.Property(e => e.Fcrmvh_Camion)
                    .HasMaxLength(6)
                    .IsUnicode(false)
                    .HasColumnName("FCRMVH_CAMION");

                entity.Property(e => e.Fcrmvh_Camsec)
                    .HasColumnType("numeric(20, 8)")
                    .HasColumnName("FCRMVH_CAMSEC");

                entity.Property(e => e.Fcrmvh_Camuss)
                    .HasColumnType("numeric(20, 8)")
                    .HasColumnName("FCRMVH_CAMUSS");

                entity.Property(e => e.Fcrmvh_Canant)
                    .HasMaxLength(1)
                    .IsUnicode(false)
                    .HasColumnName("FCRMVH_CANANT")
                    .IsFixedLength(true);

                entity.Property(e => e.Fcrmvh_Cdent1)
                    .HasMaxLength(6)
                    .IsUnicode(false)
                    .HasColumnName("FCRMVH_CDENT1");

                entity.Property(e => e.Fcrmvh_Cdent2)
                    .HasMaxLength(6)
                    .IsUnicode(false)
                    .HasColumnName("FCRMVH_CDENT2");

                entity.Property(e => e.Fcrmvh_Cirapl)
                    .IsRequired()
                    .HasMaxLength(6)
                    .IsUnicode(false)
                    .HasColumnName("FCRMVH_CIRAPL");

                entity.Property(e => e.Fcrmvh_Circom)
                    .IsRequired()
                    .HasMaxLength(6)
                    .IsUnicode(false)
                    .HasColumnName("FCRMVH_CIRCOM");

                entity.Property(e => e.Fcrmvh_Cirgen)
                    .IsRequired()
                    .HasMaxLength(6)
                    .IsUnicode(false)
                    .HasColumnName("FCRMVH_CIRGEN");

                entity.Property(e => e.Fcrmvh_Claaut).HasColumnName("FCRMVH_CLAAUT");

                entity.Property(e => e.Fcrmvh_Clasif)
                    .HasMaxLength(1)
                    .IsUnicode(false)
                    .HasColumnName("FCRMVH_CLASIF");

                entity.Property(e => e.Fcrmvh_Clprfa)
                    .HasMaxLength(1)
                    .IsUnicode(false)
                    .HasColumnName("FCRMVH_CLPRFA")
                    .IsFixedLength(true);

                entity.Property(e => e.Fcrmvh_Cmpver)
                    .HasMaxLength(10)
                    .IsUnicode(false)
                    .HasColumnName("FCRMVH_CMPVER");

                entity.Property(e => e.Fcrmvh_Cndcom)
                    .HasMaxLength(6)
                    .IsUnicode(false)
                    .HasColumnName("FCRMVH_CNDCOM")
                    .IsFixedLength(true);

                entity.Property(e => e.Fcrmvh_Cndiva)
                    .HasMaxLength(6)
                    .IsUnicode(false)
                    .HasColumnName("FCRMVH_CNDIVA");

                entity.Property(e => e.Fcrmvh_Cndpag)
                    .IsRequired()
                    .HasMaxLength(6)
                    .IsUnicode(false)
                    .HasColumnName("FCRMVH_CNDPAG");

                entity.Property(e => e.Fcrmvh_Cntpdc)
                    .HasMaxLength(4)
                    .IsUnicode(false)
                    .HasColumnName("FCRMVH_CNTPDC");

                entity.Property(e => e.Fcrmvh_Codemp)
                    .HasMaxLength(10)
                    .IsUnicode(false)
                    .HasColumnName("FCRMVH_CODEMP");

                entity.Property(e => e.Fcrmvh_Codent)
                    .HasMaxLength(10)
                    .IsUnicode(false)
                    .HasColumnName("FCRMVH_CODENT");

                entity.Property(e => e.Fcrmvh_Codfcr)
                    .HasMaxLength(6)
                    .IsUnicode(false)
                    .HasColumnName("FCRMVH_CODFCR");

                entity.Property(e => e.Fcrmvh_Codfst)
                    .HasMaxLength(6)
                    .IsUnicode(false)
                    .HasColumnName("FCRMVH_CODFST");

                entity.Property(e => e.Fcrmvh_Codgen)
                    .IsRequired()
                    .HasMaxLength(6)
                    .IsUnicode(false)
                    .HasColumnName("FCRMVH_CODGEN");

                entity.Property(e => e.Fcrmvh_Codlis)
                    .IsRequired()
                    .HasMaxLength(10)
                    .IsUnicode(false)
                    .HasColumnName("FCRMVH_CODLIS")
                    .IsFixedLength(true);

                entity.Property(e => e.Fcrmvh_Codocj)
                    .HasMaxLength(6)
                    .IsUnicode(false)
                    .HasColumnName("FCRMVH_CODOCJ");

                entity.Property(e => e.Fcrmvh_Codopr)
                    .HasMaxLength(30)
                    .IsUnicode(false)
                    .HasColumnName("FCRMVH_CODOPR");

                entity.Property(e => e.Fcrmvh_Codori)
                    .HasMaxLength(20)
                    .IsUnicode(false)
                    .HasColumnName("FCRMVH_CODORI");

                entity.Property(e => e.Fcrmvh_Codost)
                    .HasMaxLength(6)
                    .IsUnicode(false)
                    .HasColumnName("FCRMVH_CODOST");

                entity.Property(e => e.Fcrmvh_Codpai)
                    .HasMaxLength(3)
                    .IsUnicode(false)
                    .HasColumnName("FCRMVH_CODPAI");

                entity.Property(e => e.Fcrmvh_Codpos)
                    .HasMaxLength(10)
                    .IsUnicode(false)
                    .HasColumnName("FCRMVH_CODPOS");

                entity.Property(e => e.Fcrmvh_Codzon)
                    .HasMaxLength(6)
                    .IsUnicode(false)
                    .HasColumnName("FCRMVH_CODZON");

                entity.Property(e => e.Fcrmvh_Cofdeu)
                    .HasMaxLength(6)
                    .IsUnicode(false)
                    .HasColumnName("FCRMVH_COFDEU");

                entity.Property(e => e.Fcrmvh_Coffac)
                    .HasMaxLength(6)
                    .IsUnicode(false)
                    .HasColumnName("FCRMVH_COFFAC");

                entity.Property(e => e.Fcrmvh_Coflis)
                    .HasMaxLength(6)
                    .IsUnicode(false)
                    .HasColumnName("FCRMVH_COFLIS");

                entity.Property(e => e.Fcrmvh_Comori)
                    .HasMaxLength(4)
                    .IsUnicode(false)
                    .HasColumnName("FCRMVH_COMORI");

                entity.Property(e => e.Fcrmvh_Conbon)
                    .HasMaxLength(1)
                    .IsUnicode(false)
                    .HasColumnName("FCRMVH_CONBON")
                    .IsFixedLength(true);

                entity.Property(e => e.Fcrmvh_Congel)
                    .HasMaxLength(1)
                    .IsUnicode(false)
                    .HasColumnName("FCRMVH_CONGEL")
                    .IsFixedLength(true);

                entity.Property(e => e.Fcrmvh_Coniva)
                    .HasMaxLength(6)
                    .IsUnicode(false)
                    .HasColumnName("FCRMVH_CONIVA");

                entity.Property(e => e.Fcrmvh_Contac)
                    .HasMaxLength(60)
                    .IsUnicode(false)
                    .HasColumnName("FCRMVH_CONTAC");

                entity.Property(e => e.Fcrmvh_Ctaen1)
                    .HasMaxLength(20)
                    .IsUnicode(false)
                    .HasColumnName("FCRMVH_CTAEN1");

                entity.Property(e => e.Fcrmvh_Ctaen2)
                    .HasMaxLength(20)
                    .IsUnicode(false)
                    .HasColumnName("FCRMVH_CTAEN2");

                entity.Property(e => e.Fcrmvh_Debaja)
                    .HasMaxLength(1)
                    .IsUnicode(false)
                    .HasColumnName("FCRMVH_DEBAJA")
                    .IsFixedLength(true);

                entity.Property(e => e.Fcrmvh_Deposi)
                    .HasMaxLength(15)
                    .IsUnicode(false)
                    .HasColumnName("FCRMVH_DEPOSI");

                entity.Property(e => e.Fcrmvh_Deptra)
                    .HasMaxLength(15)
                    .IsUnicode(false)
                    .HasColumnName("FCRMVH_DEPTRA");

                entity.Property(e => e.Fcrmvh_Diadi1).HasColumnName("FCRMVH_DIADI1");

                entity.Property(e => e.Fcrmvh_Diadi2).HasColumnName("FCRMVH_DIADI2");

                entity.Property(e => e.Fcrmvh_Diadi3).HasColumnName("FCRMVH_DIADI3");

                entity.Property(e => e.Fcrmvh_Diaent).HasColumnName("FCRMVH_DIAENT");

                entity.Property(e => e.Fcrmvh_Dialib)
                    .HasColumnType("numeric(5, 2)")
                    .HasColumnName("FCRMVH_DIALIB");

                entity.Property(e => e.Fcrmvh_Dimobl)
                    .HasMaxLength(6)
                    .IsUnicode(false)
                    .HasColumnName("FCRMVH_DIMOBL");

                entity.Property(e => e.Fcrmvh_Dimori)
                    .HasMaxLength(6)
                    .IsUnicode(false)
                    .HasColumnName("FCRMVH_DIMORI");

                entity.Property(e => e.Fcrmvh_Direcc)
                    .HasMaxLength(255)
                    .IsUnicode(false)
                    .HasColumnName("FCRMVH_DIRECC");

                entity.Property(e => e.Fcrmvh_Dirent)
                    .HasMaxLength(255)
                    .IsUnicode(false)
                    .HasColumnName("FCRMVH_DIRENT");

                entity.Property(e => e.Fcrmvh_Docfis)
                    .HasMaxLength(6)
                    .IsUnicode(false)
                    .HasColumnName("FCRMVH_DOCFIS");

                entity.Property(e => e.Fcrmvh_Edvacp)
                    .HasMaxLength(1)
                    .IsUnicode(false)
                    .HasColumnName("FCRMVH_EDVACP")
                    .IsFixedLength(true);

                entity.Property(e => e.Fcrmvh_Embarq)
                    .HasMaxLength(6)
                    .IsUnicode(false)
                    .HasColumnName("FCRMVH_EMBARQ");

                entity.Property(e => e.Fcrmvh_Empfcr)
                    .HasMaxLength(10)
                    .IsUnicode(false)
                    .HasColumnName("FCRMVH_EMPFCR");

                entity.Property(e => e.Fcrmvh_Empfst)
                    .HasMaxLength(10)
                    .IsUnicode(false)
                    .HasColumnName("FCRMVH_EMPFST");

                entity.Property(e => e.Fcrmvh_Empgen)
                    .HasMaxLength(10)
                    .IsUnicode(false)
                    .HasColumnName("FCRMVH_EMPGEN");

                entity.Property(e => e.Fcrmvh_Empocj)
                    .HasMaxLength(10)
                    .IsUnicode(false)
                    .HasColumnName("FCRMVH_EMPOCJ");

                entity.Property(e => e.Fcrmvh_Empost)
                    .HasMaxLength(10)
                    .IsUnicode(false)
                    .HasColumnName("FCRMVH_EMPOST");

                entity.Property(e => e.Fcrmvh_Estaut).HasColumnName("FCRMVH_ESTAUT");

                entity.Property(e => e.Fcrmvh_Fchaut)
                    .HasColumnType("datetime")
                    .HasColumnName("FCRMVH_FCHAUT");

                entity.Property(e => e.Fcrmvh_Fchdes)
                    .HasColumnType("datetime")
                    .HasColumnName("FCRMVH_FCHDES");

                entity.Property(e => e.Fcrmvh_Fchhas)
                    .HasColumnType("datetime")
                    .HasColumnName("FCRMVH_FCHHAS");

                entity.Property(e => e.Fcrmvh_Fchmov)
                    .HasColumnType("datetime")
                    .HasColumnName("FCRMVH_FCHMOV");

                entity.Property(e => e.Fcrmvh_Fchven)
                    .HasColumnType("datetime")
                    .HasColumnName("FCRMVH_FCHVEN");

                entity.Property(e => e.Fcrmvh_Fecalt)
                    .HasColumnType("datetime")
                    .HasColumnName("FCRMVH_FECALT");

                entity.Property(e => e.Fcrmvh_Fecfcr)
                    .HasColumnType("datetime")
                    .HasColumnName("FCRMVH_FECFCR");

                entity.Property(e => e.Fcrmvh_Feclis)
                    .HasColumnType("datetime")
                    .HasColumnName("FCRMVH_FECLIS");

                entity.Property(e => e.Fcrmvh_Fecmod)
                    .HasColumnType("datetime")
                    .HasColumnName("FCRMVH_FECMOD");

                entity.Property(e => e.Fcrmvh_Grubon)
                    .HasMaxLength(6)
                    .IsUnicode(false)
                    .HasColumnName("FCRMVH_GRUBON");

                entity.Property(e => e.Fcrmvh_Horent)
                    .HasMaxLength(60)
                    .IsUnicode(false)
                    .HasColumnName("FCRMVH_HORENT");

                entity.Property(e => e.Fcrmvh_Hormov)
                    .HasMaxLength(10)
                    .IsUnicode(false)
                    .HasColumnName("FCRMVH_HORMOV");

                entity.Property(e => e.Fcrmvh_Impres).HasColumnName("FCRMVH_IMPRES");

                entity.Property(e => e.Fcrmvh_Imptcn)
                    .HasMaxLength(6)
                    .IsUnicode(false)
                    .HasColumnName("FCRMVH_IMPTCN");

                entity.Property(e => e.Fcrmvh_Isprct)
                    .HasMaxLength(1)
                    .IsUnicode(false)
                    .HasColumnName("FCRMVH_ISPRCT")
                    .IsFixedLength(true);

                entity.Property(e => e.Fcrmvh_Jurctd)
                    .HasMaxLength(6)
                    .IsUnicode(false)
                    .HasColumnName("FCRMVH_JURCTD");

                entity.Property(e => e.Fcrmvh_Jurisd)
                    .IsRequired()
                    .HasMaxLength(6)
                    .IsUnicode(false)
                    .HasColumnName("FCRMVH_JURISD");

                entity.Property(e => e.Fcrmvh_Letfis)
                    .HasMaxLength(6)
                    .IsUnicode(false)
                    .HasColumnName("FCRMVH_LETFIS");

                entity.Property(e => e.Fcrmvh_Lotori)
                    .HasMaxLength(6)
                    .IsUnicode(false)
                    .HasColumnName("FCRMVH_LOTORI");

                entity.Property(e => e.Fcrmvh_Lotrec)
                    .HasMaxLength(6)
                    .IsUnicode(false)
                    .HasColumnName("FCRMVH_LOTREC");

                entity.Property(e => e.Fcrmvh_Lottra)
                    .HasMaxLength(6)
                    .IsUnicode(false)
                    .HasColumnName("FCRMVH_LOTTRA");

                entity.Property(e => e.Fcrmvh_Mascar)
                    .HasMaxLength(6)
                    .IsUnicode(false)
                    .HasColumnName("FCRMVH_MASCAR")
                    .IsFixedLength(true);

                entity.Property(e => e.Fcrmvh_Modfcr)
                    .HasMaxLength(2)
                    .IsUnicode(false)
                    .HasColumnName("FCRMVH_MODFCR");

                entity.Property(e => e.Fcrmvh_Modfst)
                    .HasMaxLength(2)
                    .IsUnicode(false)
                    .HasColumnName("FCRMVH_MODFST");

                entity.Property(e => e.Fcrmvh_Modgen)
                    .HasMaxLength(2)
                    .IsUnicode(false)
                    .HasColumnName("FCRMVH_MODGEN");

                entity.Property(e => e.Fcrmvh_Modocj)
                    .HasMaxLength(2)
                    .IsUnicode(false)
                    .HasColumnName("FCRMVH_MODOCJ");

                entity.Property(e => e.Fcrmvh_Modost)
                    .HasMaxLength(2)
                    .IsUnicode(false)
                    .HasColumnName("FCRMVH_MODOST");

                entity.Property(e => e.Fcrmvh_Module)
                    .HasMaxLength(10)
                    .IsUnicode(false)
                    .HasColumnName("FCRMVH_MODULE");

                entity.Property(e => e.Fcrmvh_Modulo)
                    .HasMaxLength(2)
                    .IsUnicode(false)
                    .HasColumnName("FCRMVH_MODULO")
                    .IsFixedLength(true);

                entity.Property(e => e.Fcrmvh_Motdev)
                    .HasMaxLength(6)
                    .IsUnicode(false)
                    .HasColumnName("FCRMVH_MOTDEV");

                entity.Property(e => e.Fcrmvh_Municp)
                    .HasMaxLength(6)
                    .IsUnicode(false)
                    .HasColumnName("FCRMVH_MUNICP");

                entity.Property(e => e.Fcrmvh_Nombre)
                    .HasMaxLength(150)
                    .IsUnicode(false)
                    .HasColumnName("FCRMVH_NOMBRE");

                entity.Property(e => e.Fcrmvh_Nrocae)
                    .HasMaxLength(20)
                    .IsUnicode(false)
                    .HasColumnName("FCRMVH_NROCAE");

                entity.Property(e => e.Fcrmvh_Nrocta)
                    .IsRequired()
                    .HasMaxLength(20)
                    .IsUnicode(false)
                    .HasColumnName("FCRMVH_NROCTA");

                entity.Property(e => e.Fcrmvh_Nrodoc)
                    .HasMaxLength(50)
                    .IsUnicode(false)
                    .HasColumnName("FCRMVH_NRODOC");

                entity.Property(e => e.Fcrmvh_Nrofcr).HasColumnName("FCRMVH_NROFCR");

                entity.Property(e => e.Fcrmvh_Nrofis).HasColumnName("FCRMVH_NROFIS");

                entity.Property(e => e.Fcrmvh_Nrofst).HasColumnName("FCRMVH_NROFST");

                entity.Property(e => e.Fcrmvh_Nrogen).HasColumnName("FCRMVH_NROGEN");

                entity.Property(e => e.Fcrmvh_Nroocj).HasColumnName("FCRMVH_NROOCJ");

                entity.Property(e => e.Fcrmvh_Nroost).HasColumnName("FCRMVH_NROOST");

                entity.Property(e => e.Fcrmvh_Nrosub)
                    .HasMaxLength(20)
                    .IsUnicode(false)
                    .HasColumnName("FCRMVH_NROSUB");

                entity.Property(e => e.Fcrmvh_Oalias)
                    .HasMaxLength(10)
                    .IsUnicode(false)
                    .HasColumnName("FCRMVH_OALIAS");

                entity.Property(e => e.Fcrmvh_Oleole)
                    .HasColumnType("text")
                    .HasColumnName("FCRMVH_OLEOLE");

                entity.Property(e => e.Fcrmvh_Paient)
                    .HasMaxLength(3)
                    .IsUnicode(false)
                    .HasColumnName("FCRMVH_PAIENT");

                entity.Property(e => e.Fcrmvh_Pctbf1)
                    .HasColumnType("numeric(15, 7)")
                    .HasColumnName("FCRMVH_PCTBF1");

                entity.Property(e => e.Fcrmvh_Pctbf2)
                    .HasColumnType("numeric(15, 7)")
                    .HasColumnName("FCRMVH_PCTBF2");

                entity.Property(e => e.Fcrmvh_Pctbf3)
                    .HasColumnType("numeric(15, 7)")
                    .HasColumnName("FCRMVH_PCTBF3");

                entity.Property(e => e.Fcrmvh_Pctbf4)
                    .HasColumnType("numeric(15, 7)")
                    .HasColumnName("FCRMVH_PCTBF4");

                entity.Property(e => e.Fcrmvh_Pctbf5)
                    .HasColumnType("numeric(15, 7)")
                    .HasColumnName("FCRMVH_PCTBF5");

                entity.Property(e => e.Fcrmvh_Pctbl1)
                    .HasColumnType("numeric(15, 7)")
                    .HasColumnName("FCRMVH_PCTBL1");

                entity.Property(e => e.Fcrmvh_Pctbl2)
                    .HasColumnType("numeric(15, 7)")
                    .HasColumnName("FCRMVH_PCTBL2");

                entity.Property(e => e.Fcrmvh_Pctbl3)
                    .HasColumnType("numeric(15, 7)")
                    .HasColumnName("FCRMVH_PCTBL3");

                entity.Property(e => e.Fcrmvh_Pctdes)
                    .HasColumnType("numeric(15, 7)")
                    .HasColumnName("FCRMVH_PCTDES");

                entity.Property(e => e.Fcrmvh_Pctdi1)
                    .HasColumnType("numeric(15, 7)")
                    .HasColumnName("FCRMVH_PCTDI1");

                entity.Property(e => e.Fcrmvh_Pctdi2)
                    .HasColumnType("numeric(15, 7)")
                    .HasColumnName("FCRMVH_PCTDI2");

                entity.Property(e => e.Fcrmvh_Pctdi3)
                    .HasColumnType("numeric(15, 7)")
                    .HasColumnName("FCRMVH_PCTDI3");

                entity.Property(e => e.Fcrmvh_Pctdm1)
                    .HasColumnType("numeric(15, 7)")
                    .HasColumnName("FCRMVH_PCTDM1");

                entity.Property(e => e.Fcrmvh_Pctdm2)
                    .HasColumnType("numeric(15, 7)")
                    .HasColumnName("FCRMVH_PCTDM2");

                entity.Property(e => e.Fcrmvh_Pctdm3)
                    .HasColumnType("numeric(15, 7)")
                    .HasColumnName("FCRMVH_PCTDM3");

                entity.Property(e => e.Fcrmvh_Pctfin)
                    .HasColumnType("numeric(15, 7)")
                    .HasColumnName("FCRMVH_PCTFIN");

                entity.Property(e => e.Fcrmvh_Sector)
                    .HasMaxLength(15)
                    .IsUnicode(false)
                    .HasColumnName("FCRMVH_SECTOR");

                entity.Property(e => e.Fcrmvh_Sectra)
                    .HasMaxLength(15)
                    .IsUnicode(false)
                    .HasColumnName("FCRMVH_SECTRA");

                entity.Property(e => e.Fcrmvh_Subcue)
                    .HasMaxLength(40)
                    .IsUnicode(false)
                    .HasColumnName("FCRMVH_SUBCUE");

                entity.Property(e => e.Fcrmvh_Subori)
                    .HasMaxLength(40)
                    .IsUnicode(false)
                    .HasColumnName("FCRMVH_SUBORI");

                entity.Property(e => e.Fcrmvh_Sucfis)
                    .HasMaxLength(6)
                    .IsUnicode(false)
                    .HasColumnName("FCRMVH_SUCFIS");

                entity.Property(e => e.Fcrmvh_Sucurs)
                    .HasMaxLength(6)
                    .IsUnicode(false)
                    .HasColumnName("FCRMVH_SUCURS");

                entity.Property(e => e.Fcrmvh_Sysver)
                    .HasMaxLength(10)
                    .IsUnicode(false)
                    .HasColumnName("FCRMVH_SYSVER");

                entity.Property(e => e.Fcrmvh_Tasain)
                    .HasColumnType("numeric(15, 7)")
                    .HasColumnName("FCRMVH_TASAIN");

                entity.Property(e => e.Fcrmvh_Telefn)
                    .HasMaxLength(30)
                    .IsUnicode(false)
                    .HasColumnName("FCRMVH_TELEFN");

                entity.Property(e => e.Fcrmvh_Textos)
                    .HasColumnType("text")
                    .HasColumnName("FCRMVH_TEXTOS");

                entity.Property(e => e.Fcrmvh_Tipdoc)
                    .HasMaxLength(4)
                    .IsUnicode(false)
                    .HasColumnName("FCRMVH_TIPDOC");

                entity.Property(e => e.Fcrmvh_Tipexp)
                    .HasMaxLength(6)
                    .IsUnicode(false)
                    .HasColumnName("FCRMVH_TIPEXP");

                entity.Property(e => e.Fcrmvh_Tipopr)
                    .HasMaxLength(6)
                    .IsUnicode(false)
                    .HasColumnName("FCRMVH_TIPOPR");

                entity.Property(e => e.Fcrmvh_Tracod)
                    .HasMaxLength(6)
                    .IsUnicode(false)
                    .HasColumnName("FCRMVH_TRACOD");

                entity.Property(e => e.Fcrmvh_Trandr)
                    .HasMaxLength(60)
                    .IsUnicode(false)
                    .HasColumnName("FCRMVH_TRANDR");

                entity.Property(e => e.Fcrmvh_Transp)
                    .HasMaxLength(60)
                    .IsUnicode(false)
                    .HasColumnName("FCRMVH_TRANSP");

                entity.Property(e => e.Fcrmvh_Trcuit)
                    .HasMaxLength(50)
                    .IsUnicode(false)
                    .HasColumnName("FCRMVH_TRCUIT");


                entity.Property(e => e.Fcrmvh_Ultopr)
                    .HasMaxLength(1)
                    .IsUnicode(false)
                    .HasColumnName("FCRMVH_ULTOPR")
                    .IsFixedLength(true);

                entity.Property(e => e.Fcrmvh_Userid)
                    .HasMaxLength(64)
                    .IsUnicode(false)
                    .HasColumnName("FCRMVH_USERID");

                entity.Property(e => e.Fcrmvh_Usraut)
                    .HasMaxLength(36)
                    .IsUnicode(false)
                    .HasColumnName("FCRMVH_USRAUT");

                entity.Property(e => e.Fcrmvh_Vnddor)
                    .IsRequired()
                    .HasMaxLength(6)
                    .IsUnicode(false)
                    .HasColumnName("FCRMVH_VNDDOR");

                entity.Property(e => e.Usr_Fcrmvh_Aproba)
                    .HasMaxLength(1)
                    .IsUnicode(false)
                    .HasColumnName("USR_FCRMVH_APROBA");

                entity.Property(e => e.Usr_Fcrmvh_Armaca)
                    .HasMaxLength(1)
                    .IsUnicode(false)
                    .HasColumnName("USR_FCRMVH_ARMACA")
                    .IsFixedLength(true);

                entity.Property(e => e.Usr_Fcrmvh_Batnst)
                    .HasMaxLength(1)
                    .IsUnicode(false)
                    .HasColumnName("USR_FCRMVH_BATNST")
                    .IsFixedLength(true);

                entity.Property(e => e.Usr_Fcrmvh_Causbt)
                    .HasMaxLength(2)
                    .IsUnicode(false)
                    .HasColumnName("USR_FCRMVH_CAUSBT");

                entity.Property(e => e.Usr_Fcrmvh_Chofer).HasColumnName("USR_FCRMVH_CHOFER");

                entity.Property(e => e.Usr_Fcrmvh_Cirapl)
                    .HasMaxLength(6)
                    .IsUnicode(false)
                    .HasColumnName("USR_FCRMVH_CIRAPL");

                entity.Property(e => e.Usr_Fcrmvh_Circom)
                    .HasMaxLength(6)
                    .IsUnicode(false)
                    .HasColumnName("USR_FCRMVH_CIRCOM");

                entity.Property(e => e.Usr_Fcrmvh_Climin)
                    .HasMaxLength(7)
                    .IsUnicode(false)
                    .HasColumnName("USR_FCRMVH_CLIMIN");

                entity.Property(e => e.Usr_Fcrmvh_Codfac)
                    .HasMaxLength(6)
                    .IsUnicode(false)
                    .HasColumnName("USR_FCRMVH_CODFAC");

                entity.Property(e => e.Usr_Fcrmvh_Codfnc)
                    .HasMaxLength(6)
                    .IsUnicode(false)
                    .HasColumnName("USR_FCRMVH_CODFNC");

                entity.Property(e => e.Usr_Fcrmvh_Corrgt)
                    .HasMaxLength(1)
                    .IsUnicode(false)
                    .HasColumnName("USR_FCRMVH_CORRGT")
                    .IsFixedLength(true);

                entity.Property(e => e.Usr_Fcrmvh_Cupdes).HasColumnName("USR_FCRMVH_CUPDES");

                entity.Property(e => e.Usr_Fcrmvh_Descup).HasColumnName("USR_FCRMVH_DESCUP");

                entity.Property(e => e.Usr_Fcrmvh_Entmin)
                    .HasMaxLength(1)
                    .IsUnicode(false)
                    .HasColumnName("USR_FCRMVH_ENTMIN");

                entity.Property(e => e.Usr_Fcrmvh_Entrega)
                    .HasMaxLength(1)
                    .IsUnicode(false)
                    .HasColumnName("USR_FCRMVH_ENTREGA");

                entity.Property(e => e.Usr_Fcrmvh_Estpre)
                    .HasMaxLength(6)
                    .IsUnicode(false)
                    .HasColumnName("USR_FCRMVH_ESTPRE");

                entity.Property(e => e.Usr_Fcrmvh_Facmin)
                    .HasMaxLength(64)
                    .IsUnicode(false)
                    .HasColumnName("USR_FCRMVH_FACMIN");

                entity.Property(e => e.Usr_Fcrmvh_Fcenco)
                    .HasColumnType("datetime")
                    .HasColumnName("USR_FCRMVH_FCENCO");

                entity.Property(e => e.Usr_Fcrmvh_Fchcom)
                    .HasColumnType("datetime")
                    .HasColumnName("USR_FCRMVH_FCHCOM");

                entity.Property(e => e.Usr_Fcrmvh_Fchvta)
                    .HasColumnType("datetime")
                    .HasColumnName("USR_FCRMVH_FCHVTA");

                entity.Property(e => e.Usr_Fcrmvh_Lugdes)
                    .HasMaxLength(60)
                    .IsUnicode(false)
                    .HasColumnName("USR_FCRMVH_LUGDES");

                entity.Property(e => e.Usr_Fcrmvh_Modfnc)
                    .HasMaxLength(6)
                    .IsUnicode(false)
                    .HasColumnName("USR_FCRMVH_MODFNC");

                entity.Property(e => e.Usr_Fcrmvh_Moncup)
                    .HasMaxLength(1)
                    .IsUnicode(false)
                    .HasColumnName("USR_FCRMVH_MONCUP");

                entity.Property(e => e.Usr_Fcrmvh_Motapr)
                    .HasMaxLength(1)
                    .IsUnicode(false)
                    .HasColumnName("USR_FCRMVH_MOTAPR")
                    .IsFixedLength(true);

                entity.Property(e => e.Usr_Fcrmvh_Motauc)
                    .HasMaxLength(40)
                    .IsUnicode(false)
                    .HasColumnName("USR_FCRMVH_MOTAUC");

                entity.Property(e => e.Usr_Fcrmvh_Motaut)
                    .HasMaxLength(150)
                    .IsUnicode(false)
                    .HasColumnName("USR_FCRMVH_MOTAUT");

                entity.Property(e => e.Usr_Fcrmvh_Motbri)
                    .HasMaxLength(60)
                    .IsUnicode(false)
                    .HasColumnName("USR_FCRMVH_MOTBRI");

                entity.Property(e => e.Usr_Fcrmvh_Motcor)
                    .HasMaxLength(1)
                    .IsUnicode(false)
                    .HasColumnName("USR_FCRMVH_MOTCOR")
                    .IsFixedLength(true);

                entity.Property(e => e.Usr_Fcrmvh_Motcta)
                    .HasMaxLength(1)
                    .IsUnicode(false)
                    .HasColumnName("USR_FCRMVH_MOTCTA")
                    .IsFixedLength(true);

                entity.Property(e => e.Usr_Fcrmvh_Motdes)
                    .HasMaxLength(1)
                    .IsUnicode(false)
                    .HasColumnName("USR_FCRMVH_MOTDES")
                    .IsFixedLength(true);

                entity.Property(e => e.Usr_Fcrmvh_Motdev)
                    .HasMaxLength(6)
                    .IsUnicode(false)
                    .HasColumnName("USR_FCRMVH_MOTDEV");

                entity.Property(e => e.Usr_Fcrmvh_Motdve)
                    .HasMaxLength(1)
                    .IsUnicode(false)
                    .HasColumnName("USR_FCRMVH_MOTDVE")
                    .IsFixedLength(true);

                entity.Property(e => e.Usr_Fcrmvh_Motlcr)
                    .HasMaxLength(1)
                    .IsUnicode(false)
                    .HasColumnName("USR_FCRMVH_MOTLCR")
                    .IsFixedLength(true);

                entity.Property(e => e.Usr_Fcrmvh_Nroext)
                    .HasMaxLength(250)
                    .IsUnicode(false)
                    .HasColumnName("USR_FCRMVH_NROEXT");
                
                entity.Property(e => e.Usr_Fcrmvh_Clicob)
                    .HasMaxLength(30)
                    .IsUnicode(false)
                    .HasColumnName("USR_FCRMVH_CLICOB");

                entity.Property(e => e.Usr_Fcrmvh_Nrofnc).HasColumnName("USR_FCRMVH_NROFNC");

                entity.Property(e => e.Usr_Fcrmvh_Nrogar)
                    .HasMaxLength(8)
                    .IsUnicode(false)
                    .HasColumnName("USR_FCRMVH_NROGAR");

                entity.Property(e => e.Usr_Fcrmvh_Nroope)
                    .HasMaxLength(60)
                    .IsUnicode(false)
                    .HasColumnName("USR_FCRMVH_NROOPE");

                entity.Property(e => e.Usr_Fcrmvh_Nrosgt).HasColumnName("USR_FCRMVH_NROSGT");

                entity.Property(e => e.Usr_Fcrmvh_Obspre)
                    .HasMaxLength(120)
                    .IsUnicode(false)
                    .HasColumnName("USR_FCRMVH_OBSPRE");

                entity.Property(e => e.Usr_Fcrmvh_Patent)
                    .HasMaxLength(8)
                    .IsUnicode(false)
                    .HasColumnName("USR_FCRMVH_PATENT");

                entity.Property(e => e.Usr_Fcrmvh_Perare)
                    .HasMaxLength(6)
                    .IsUnicode(false)
                    .HasColumnName("USR_FCRMVH_PERARE");

                entity.Property(e => e.Usr_Fcrmvh_Plazoe)
                    .HasMaxLength(1)
                    .IsUnicode(false)
                    .HasColumnName("USR_FCRMVH_PLAZOE");

                entity.Property(e => e.Usr_Fcrmvh_Poracp)
                    .HasColumnType("numeric(15, 7)")
                    .HasColumnName("USR_FCRMVH_PORACP");

                entity.Property(e => e.Usr_Fcrmvh_Porrem)
                    .HasMaxLength(3)
                    .IsUnicode(false)
                    .HasColumnName("USR_FCRMVH_PORREM");

                entity.Property(e => e.Usr_Fcrmvh_Proces)
                    .HasMaxLength(1)
                    .IsUnicode(false)
                    .HasColumnName("USR_FCRMVH_PROCES")
                    .IsFixedLength(true);

                entity.Property(e => e.Usr_Fcrmvh_Prodie)
                    .HasMaxLength(2)
                    .IsUnicode(false)
                    .HasColumnName("USR_FCRMVH_PRODIE");

                entity.Property(e => e.Usr_Fcrmvh_Resaut)
                    .HasMaxLength(60)
                    .IsUnicode(false)
                    .HasColumnName("USR_FCRMVH_RESAUT");

                entity.Property(e => e.Usr_Fcrmvh_Revcod)
                    .HasMaxLength(6)
                    .IsUnicode(false)
                    .HasColumnName("USR_FCRMVH_REVCOD");

                entity.Property(e => e.Usr_Fcrmvh_Revnro).HasColumnName("USR_FCRMVH_REVNRO");

                entity.Property(e => e.Usr_Fcrmvh_Soleva).HasColumnName("USR_FCRMVH_SOLEVA");

                entity.Property(e => e.Usr_Fcrmvh_Texto2)
                    .HasColumnType("text")
                    .HasColumnName("USR_FCRMVH_TEXTO2");

                entity.Property(e => e.Usr_Fcrmvh_Tipfac)
                    .HasMaxLength(6)
                    .IsUnicode(false)
                    .HasColumnName("USR_FCRMVH_TIPFAC");

                entity.Property(e => e.Usr_Fcrmvh_Tipgar)
                    .HasMaxLength(1)
                    .IsUnicode(false)
                    .HasColumnName("USR_FCRMVH_TIPGAR");

                entity.Property(e => e.Usr_Fcrmvh_Tipneu)
                    .HasMaxLength(2)
                    .IsUnicode(false)
                    .HasColumnName("USR_FCRMVH_TIPNEU");

                entity.Property(e => e.Usr_Fcrmvh_Tipope)
                    .HasMaxLength(1)
                    .IsUnicode(false)
                    .HasColumnName("USR_FCRMVH_TIPOPE");

                entity.Property(e => e.Usr_Fcrmvh_Turno)
                    .HasMaxLength(1)
                    .IsUnicode(false)
                    .HasColumnName("USR_FCRMVH_TURNO");

                entity.Property(e => e.Usr_Fcrmvh_Usrslf)
                    .HasMaxLength(250)
                    .IsUnicode(false)
                    .HasColumnName("USR_FCRMVH_USRSLF");
            });

            modelBuilder.Entity<Fcrmvi>(entity =>
            {
                entity.HasKey(e => new { e.Fcrmvi_Modfor, e.Fcrmvi_Codfor, e.Fcrmvi_Nrofor, e.Fcrmvi_Nroitm, e.Fcrmvi_Nivexp, e.Fcrmvi_Modapl, e.Fcrmvi_Codapl, e.Fcrmvi_Nroapl, e.Fcrmvi_Itmapl, e.Fcrmvi_Expapl });

                entity.ToTable("FCRMVI");

                entity.HasIndex(e => new { e.Fcrmvi_Modfor, e.Fcrmvi_Codfor, e.Fcrmvi_Nrofor, e.Fcrmvi_Codemp, e.Fcrmvi_Nroitm, e.Fcrmvi_Nivexp, e.Fcrmvi_Empapl, e.Fcrmvi_Modapl, e.Fcrmvi_Codapl, e.Fcrmvi_Nroapl, e.Fcrmvi_Itmapl, e.Fcrmvi_Expapl }, "P_VT_MovPendCAE");

                entity.HasIndex(e => new { e.Fcrmvi_Modapl, e.Fcrmvi_Codapl, e.Fcrmvi_Nroapl, e.Fcrmvi_Itmapl, e.Fcrmvi_Expapl }, "S_FC_FCRMVH");

                entity.HasIndex(e => new { e.Fcrmvi_Modapl, e.Fcrmvi_Codapl, e.Fcrmvi_Nroapl }, "T_FC_FCRMVH");

                entity.HasIndex(e => new { e.Fcrmvi_Modapl, e.Fcrmvi_Codapl, e.Fcrmvi_Tippro, e.Fcrmvi_Artcod, e.Fcrmvi_Deposi, e.Fcrmvi_Sector, e.Fcrmvi_Fchent, e.Fcrmvi_Cantst }, "T_GR_FCRMVH");

                entity.HasIndex(e => new { e.Fcrmvi_Nroapl, e.Fcrmvi_Modapl, e.Fcrmvi_Codapl, e.Fcrmvi_Itmapl, e.Fcrmvi_Expapl, e.Fcrmvi_Tippro, e.Fcrmvi_Artcod, e.Fcrmvi_Cantid }, "W_FC_FCRMVH");

                entity.HasIndex(e => new { e.Fcrmvi_Modapl, e.Fcrmvi_Codapl, e.Fcrmvi_Nroapl, e.Fcrmvi_Modfor, e.Fcrmvi_Codfor, e.Fcrmvi_Nrofor }, "W_FC_FCRMVH1UPD");

                entity.HasIndex(e => new { e.Fcrmvi_Modapl, e.Fcrmvi_Codapl, e.Fcrmvi_Nroapl, e.Fcrmvi_Nivexp, e.Fcrmvi_Tippro, e.Fcrmvi_Artcod, e.Fcrmvi_Precio, e.Fcrmvi_Cantid, e.Fcrmvi_Pctbfn }, "W_GR_FCRMVH");

                entity.HasIndex(e => new { e.Fcrmvi_Modapl, e.Fcrmvi_Codapl, e.Fcrmvi_Nroapl, e.Fcrmvi_Tippro, e.Fcrmvi_Artcod }, "W_ST_STRMVH");

                entity.Property(e => e.Fcrmvi_Modfor)
                    .HasMaxLength(2)
                    .IsUnicode(false)
                    .HasColumnName("FCRMVI_MODFOR");

                entity.Property(e => e.Fcrmvi_Codfor)
                    .HasMaxLength(6)
                    .IsUnicode(false)
                    .HasColumnName("FCRMVI_CODFOR");

                entity.Property(e => e.Fcrmvi_Nrofor).HasColumnName("FCRMVI_NROFOR");

                entity.Property(e => e.Fcrmvi_Nroitm).HasColumnName("FCRMVI_NROITM");

                entity.Property(e => e.Fcrmvi_Nivexp)
                    .HasMaxLength(3)
                    .IsUnicode(false)
                    .HasColumnName("FCRMVI_NIVEXP");

                entity.Property(e => e.Fcrmvi_Modapl)
                    .HasMaxLength(2)
                    .IsUnicode(false)
                    .HasColumnName("FCRMVI_MODAPL");

                entity.Property(e => e.Fcrmvi_Codapl)
                    .HasMaxLength(6)
                    .IsUnicode(false)
                    .HasColumnName("FCRMVI_CODAPL")
                    .IsFixedLength(true);

                entity.Property(e => e.Fcrmvi_Nroapl).HasColumnName("FCRMVI_NROAPL");

                entity.Property(e => e.Fcrmvi_Itmapl).HasColumnName("FCRMVI_ITMAPL");

                entity.Property(e => e.Fcrmvi_Expapl)
                    .HasMaxLength(3)
                    .IsUnicode(false)
                    .HasColumnName("FCRMVI_EXPAPL");

                entity.Property(e => e.Fcrmvi_Aerpue)
                    .HasMaxLength(6)
                    .IsUnicode(false)
                    .HasColumnName("FCRMVI_AERPUE");

                entity.Property(e => e.Fcrmvi_Artcod)
                    .IsRequired()
                    .HasMaxLength(30)
                    .IsUnicode(false)
                    .HasColumnName("FCRMVI_ARTCOD");

                entity.Property(e => e.Fcrmvi_Artequ)
                    .HasMaxLength(60)
                    .IsUnicode(false)
                    .HasColumnName("FCRMVI_ARTEQU");

                entity.Property(e => e.Fcrmvi_Artori)
                    .HasMaxLength(30)
                    .IsUnicode(false)
                    .HasColumnName("FCRMVI_ARTORI");

                entity.Property(e => e.Fcrmvi_Cambio)
                    .HasColumnType("numeric(20, 8)")
                    .HasColumnName("FCRMVI_CAMBIO");

                entity.Property(e => e.Fcrmvi_Cancel)
                    .HasMaxLength(1)
                    .IsUnicode(false)
                    .HasColumnName("FCRMVI_CANCEL");

                entity.Property(e => e.Fcrmvi_Cantid)
                    .HasColumnType("numeric(18, 4)")
                    .HasColumnName("FCRMVI_CANTID");

                entity.Property(e => e.Fcrmvi_Cantst)
                    .HasColumnType("numeric(18, 4)")
                    .HasColumnName("FCRMVI_CANTST");

                entity.Property(e => e.Fcrmvi_Ccdapl)
                    .HasMaxLength(6)
                    .IsUnicode(false)
                    .HasColumnName("FCRMVI_CCDAPL");

                entity.Property(e => e.Fcrmvi_Cmpver)
                    .HasMaxLength(10)
                    .IsUnicode(false)
                    .HasColumnName("FCRMVI_CMPVER");

                entity.Property(e => e.Fcrmvi_Cntalt)
                    .HasColumnType("numeric(18, 4)")
                    .HasColumnName("FCRMVI_CNTALT");

                entity.Property(e => e.Fcrmvi_Cntant)
                    .HasColumnType("numeric(18, 4)")
                    .HasColumnName("FCRMVI_CNTANT");

                entity.Property(e => e.Fcrmvi_Cntbon)
                    .HasColumnType("numeric(18, 4)")
                    .HasColumnName("FCRMVI_CNTBON");

                entity.Property(e => e.Fcrmvi_Cntcon)
                    .HasColumnType("numeric(18, 4)")
                    .HasColumnName("FCRMVI_CNTCON");

                entity.Property(e => e.Fcrmvi_Cntfac)
                    .HasColumnType("numeric(18, 4)")
                    .HasColumnName("FCRMVI_CNTFAC");

                entity.Property(e => e.Fcrmvi_Cntori)
                    .HasColumnType("numeric(18, 4)")
                    .HasColumnName("FCRMVI_CNTORI");

                entity.Property(e => e.Fcrmvi_Cntpen)
                    .HasColumnType("numeric(18, 4)")
                    .HasColumnName("FCRMVI_CNTPEN");

                entity.Property(e => e.Fcrmvi_Cntsec)
                    .HasColumnType("numeric(18, 4)")
                    .HasColumnName("FCRMVI_CNTSEC");

                entity.Property(e => e.Fcrmvi_Cntuni)
                    .HasColumnType("numeric(18, 4)")
                    .HasColumnName("FCRMVI_CNTUNI");

                entity.Property(e => e.Fcrmvi_Cntvar)
                    .HasColumnType("numeric(18, 4)")
                    .HasColumnName("FCRMVI_CNTVAR");

                entity.Property(e => e.Fcrmvi_Codcpt)
                    .HasMaxLength(6)
                    .IsUnicode(false)
                    .HasColumnName("FCRMVI_CODCPT");

                entity.Property(e => e.Fcrmvi_Codemp)
                    .HasMaxLength(10)
                    .IsUnicode(false)
                    .HasColumnName("FCRMVI_CODEMP");

                entity.Property(e => e.Fcrmvi_Codgan)
                    .HasMaxLength(6)
                    .IsUnicode(false)
                    .HasColumnName("FCRMVI_CODGAN");

                entity.Property(e => e.Fcrmvi_Codini)
                    .HasMaxLength(6)
                    .IsUnicode(false)
                    .HasColumnName("FCRMVI_CODINI");

                entity.Property(e => e.Fcrmvi_Codopr)
                    .HasMaxLength(30)
                    .IsUnicode(false)
                    .HasColumnName("FCRMVI_CODOPR");

                entity.Property(e => e.Fcrmvi_Codori)
                    .HasMaxLength(6)
                    .IsUnicode(false)
                    .HasColumnName("FCRMVI_CODORI")
                    .IsFixedLength(true);

                entity.Property(e => e.Fcrmvi_Codost)
                    .HasMaxLength(6)
                    .IsUnicode(false)
                    .HasColumnName("FCRMVI_CODOST");

                entity.Property(e => e.Fcrmvi_Codpro)
                    .HasMaxLength(40)
                    .IsUnicode(false)
                    .HasColumnName("FCRMVI_CODPRO");

                entity.Property(e => e.Fcrmvi_Codtar)
                    .HasMaxLength(20)
                    .IsUnicode(false)
                    .HasColumnName("FCRMVI_CODTAR");

                entity.Property(e => e.Fcrmvi_Coflis)
                    .HasMaxLength(6)
                    .IsUnicode(false)
                    .HasColumnName("FCRMVI_COFLIS");

                entity.Property(e => e.Fcrmvi_Cuenta)
                    .HasMaxLength(40)
                    .IsUnicode(false)
                    .HasColumnName("FCRMVI_CUENTA");

                entity.Property(e => e.Fcrmvi_Debaja)
                    .HasMaxLength(1)
                    .IsUnicode(false)
                    .HasColumnName("FCRMVI_DEBAJA")
                    .IsFixedLength(true);

                entity.Property(e => e.Fcrmvi_Deposi)
                    .HasMaxLength(15)
                    .IsUnicode(false)
                    .HasColumnName("FCRMVI_DEPOSI");

                entity.Property(e => e.Fcrmvi_Deptra)
                    .HasMaxLength(15)
                    .IsUnicode(false)
                    .HasColumnName("FCRMVI_DEPTRA");

                entity.Property(e => e.Fcrmvi_Empapl)
                    .HasMaxLength(10)
                    .IsUnicode(false)
                    .HasColumnName("FCRMVI_EMPAPL");

                entity.Property(e => e.Fcrmvi_Empgan)
                    .HasMaxLength(10)
                    .IsUnicode(false)
                    .HasColumnName("FCRMVI_EMPGAN");

                entity.Property(e => e.Fcrmvi_Empini)
                    .HasMaxLength(10)
                    .IsUnicode(false)
                    .HasColumnName("FCRMVI_EMPINI");

                entity.Property(e => e.Fcrmvi_Empori)
                    .HasMaxLength(10)
                    .IsUnicode(false)
                    .HasColumnName("FCRMVI_EMPORI");

                entity.Property(e => e.Fcrmvi_Empost)
                    .HasMaxLength(10)
                    .IsUnicode(false)
                    .HasColumnName("FCRMVI_EMPOST");

                entity.Property(e => e.Fcrmvi_Envase)
                    .HasMaxLength(30)
                    .IsUnicode(false)
                    .HasColumnName("FCRMVI_ENVASE");

                entity.Property(e => e.Fcrmvi_Expori)
                    .HasMaxLength(3)
                    .IsUnicode(false)
                    .HasColumnName("FCRMVI_EXPORI");

                entity.Property(e => e.Fcrmvi_Expost)
                    .HasMaxLength(3)
                    .IsUnicode(false)
                    .HasColumnName("FCRMVI_EXPOST");

                entity.Property(e => e.Fcrmvi_Facalt)
                    .HasColumnType("numeric(12, 6)")
                    .HasColumnName("FCRMVI_FACALT");

                entity.Property(e => e.Fcrmvi_Faccon)
                    .HasColumnType("numeric(12, 6)")
                    .HasColumnName("FCRMVI_FACCON");

                entity.Property(e => e.Fcrmvi_Facfac)
                    .HasColumnType("numeric(12, 6)")
                    .HasColumnName("FCRMVI_FACFAC");

                entity.Property(e => e.Fcrmvi_Facsec)
                    .HasColumnType("numeric(12, 6)")
                    .HasColumnName("FCRMVI_FACSEC");

                entity.Property(e => e.Fcrmvi_Factor)
                    .HasColumnType("numeric(12, 6)")
                    .HasColumnName("FCRMVI_FACTOR");

                entity.Property(e => e.Fcrmvi_Fchent)
                    .HasColumnType("datetime")
                    .HasColumnName("FCRMVI_FCHENT");

                entity.Property(e => e.Fcrmvi_Fchhas)
                    .HasColumnType("datetime")
                    .HasColumnName("FCRMVI_FCHHAS");

                entity.Property(e => e.Fcrmvi_Fecalt)
                    .HasColumnType("datetime")
                    .HasColumnName("FCRMVI_FECALT");

                entity.Property(e => e.Fcrmvi_Fecmod)
                    .HasColumnType("datetime")
                    .HasColumnName("FCRMVI_FECMOD");

                entity.Property(e => e.Fcrmvi_Hormov)
                    .HasMaxLength(10)
                    .IsUnicode(false)
                    .HasColumnName("FCRMVI_HORMOV");

                entity.Property(e => e.Fcrmvi_Itmini).HasColumnName("FCRMVI_ITMINI");

                entity.Property(e => e.Fcrmvi_Itmori).HasColumnName("FCRMVI_ITMORI");

                entity.Property(e => e.Fcrmvi_Itmost).HasColumnName("FCRMVI_ITMOST");

                entity.Property(e => e.Fcrmvi_Lotori)
                    .HasMaxLength(6)
                    .IsUnicode(false)
                    .HasColumnName("FCRMVI_LOTORI");

                entity.Property(e => e.Fcrmvi_Lotrec)
                    .HasMaxLength(6)
                    .IsUnicode(false)
                    .HasColumnName("FCRMVI_LOTREC");

                entity.Property(e => e.Fcrmvi_Lottra)
                    .HasMaxLength(6)
                    .IsUnicode(false)
                    .HasColumnName("FCRMVI_LOTTRA");

                entity.Property(e => e.Fcrmvi_Mcdapl)
                    .HasMaxLength(2)
                    .IsUnicode(false)
                    .HasColumnName("FCRMVI_MCDAPL");

                entity.Property(e => e.Fcrmvi_Modcpt)
                    .HasMaxLength(2)
                    .IsUnicode(false)
                    .HasColumnName("FCRMVI_MODCPT");

                entity.Property(e => e.Fcrmvi_Modgan)
                    .HasMaxLength(2)
                    .IsUnicode(false)
                    .HasColumnName("FCRMVI_MODGAN");

                entity.Property(e => e.Fcrmvi_Modini)
                    .HasMaxLength(2)
                    .IsUnicode(false)
                    .HasColumnName("FCRMVI_MODINI");

                entity.Property(e => e.Fcrmvi_Modori)
                    .HasMaxLength(2)
                    .IsUnicode(false)
                    .HasColumnName("FCRMVI_MODORI");

                entity.Property(e => e.Fcrmvi_Modost)
                    .HasMaxLength(2)
                    .IsUnicode(false)
                    .HasColumnName("FCRMVI_MODOST");

                entity.Property(e => e.Fcrmvi_Module)
                    .HasMaxLength(10)
                    .IsUnicode(false)
                    .HasColumnName("FCRMVI_MODULE");

                entity.Property(e => e.Fcrmvi_Natrib)
                    .HasMaxLength(30)
                    .IsUnicode(false)
                    .HasColumnName("FCRMVI_NATRIB");

                entity.Property(e => e.Fcrmvi_Ncanpn)
                    .HasMaxLength(1)
                    .IsUnicode(false)
                    .HasColumnName("FCRMVI_NCANPN")
                    .IsFixedLength(true);

                entity.Property(e => e.Fcrmvi_Ncnpna)
                    .HasMaxLength(1)
                    .IsUnicode(false)
                    .HasColumnName("FCRMVI_NCNPNA")
                    .IsFixedLength(true);

                entity.Property(e => e.Fcrmvi_Ndespa)
                    .HasMaxLength(30)
                    .IsUnicode(false)
                    .HasColumnName("FCRMVI_NDESPA");

                entity.Property(e => e.Fcrmvi_Nestan)
                    .HasMaxLength(30)
                    .IsUnicode(false)
                    .HasColumnName("FCRMVI_NESTAN");

                entity.Property(e => e.Fcrmvi_Newpre)
                    .HasColumnType("numeric(20, 6)")
                    .HasColumnName("FCRMVI_NEWPRE");

                entity.Property(e => e.Fcrmvi_Nfecha)
                    .HasMaxLength(30)
                    .IsUnicode(false)
                    .HasColumnName("FCRMVI_NFECHA");

                entity.Property(e => e.Fcrmvi_Ngenpn)
                    .HasMaxLength(1)
                    .IsUnicode(false)
                    .HasColumnName("FCRMVI_NGENPN")
                    .IsFixedLength(true);

                entity.Property(e => e.Fcrmvi_Ngenst)
                    .HasMaxLength(1)
                    .IsUnicode(false)
                    .HasColumnName("FCRMVI_NGENST")
                    .IsFixedLength(true);

                entity.Property(e => e.Fcrmvi_Nivini)
                    .HasMaxLength(3)
                    .IsUnicode(false)
                    .HasColumnName("FCRMVI_NIVINI");

                entity.Property(e => e.Fcrmvi_Notros)
                    .HasMaxLength(30)
                    .IsUnicode(false)
                    .HasColumnName("FCRMVI_NOTROS");

                entity.Property(e => e.Fcrmvi_Nrocta)
                    .HasMaxLength(20)
                    .IsUnicode(false)
                    .HasColumnName("FCRMVI_NROCTA");

                entity.Property(e => e.Fcrmvi_Nrogan).HasColumnName("FCRMVI_NROGAN");

                entity.Property(e => e.Fcrmvi_Nroini).HasColumnName("FCRMVI_NROINI");

                entity.Property(e => e.Fcrmvi_Nroori).HasColumnName("FCRMVI_NROORI");

                entity.Property(e => e.Fcrmvi_Nroost).HasColumnName("FCRMVI_NROOST");

                entity.Property(e => e.Fcrmvi_Nrosub)
                    .HasMaxLength(20)
                    .IsUnicode(false)
                    .HasColumnName("FCRMVI_NROSUB");

                entity.Property(e => e.Fcrmvi_Nserie)
                    .HasMaxLength(30)
                    .IsUnicode(false)
                    .HasColumnName("FCRMVI_NSERIE");

                entity.Property(e => e.Fcrmvi_Nubica)
                    .HasMaxLength(30)
                    .IsUnicode(false)
                    .HasColumnName("FCRMVI_NUBICA");

                entity.Property(e => e.Fcrmvi_Oalias)
                    .HasMaxLength(10)
                    .IsUnicode(false)
                    .HasColumnName("FCRMVI_OALIAS");

                entity.Property(e => e.Fcrmvi_Oldpre)
                    .HasColumnType("numeric(20, 6)")
                    .HasColumnName("FCRMVI_OLDPRE");

                entity.Property(e => e.Fcrmvi_Pctbf1)
                    .HasColumnType("numeric(15, 7)")
                    .HasColumnName("FCRMVI_PCTBF1");

                entity.Property(e => e.Fcrmvi_Pctbf2)
                    .HasColumnType("numeric(15, 7)")
                    .HasColumnName("FCRMVI_PCTBF2");

                entity.Property(e => e.Fcrmvi_Pctbf3)
                    .HasColumnType("numeric(15, 7)")
                    .HasColumnName("FCRMVI_PCTBF3");

                entity.Property(e => e.Fcrmvi_Pctbf4)
                    .HasColumnType("numeric(15, 7)")
                    .HasColumnName("FCRMVI_PCTBF4");

                entity.Property(e => e.Fcrmvi_Pctbf5)
                    .HasColumnType("numeric(15, 7)")
                    .HasColumnName("FCRMVI_PCTBF5");

                entity.Property(e => e.Fcrmvi_Pctbf6)
                    .HasColumnType("numeric(15, 7)")
                    .HasColumnName("FCRMVI_PCTBF6");

                entity.Property(e => e.Fcrmvi_Pctbf7)
                    .HasColumnType("numeric(15, 7)")
                    .HasColumnName("FCRMVI_PCTBF7");

                entity.Property(e => e.Fcrmvi_Pctbf8)
                    .HasColumnType("numeric(15, 7)")
                    .HasColumnName("FCRMVI_PCTBF8");

                entity.Property(e => e.Fcrmvi_Pctbf9)
                    .HasColumnType("numeric(15, 7)")
                    .HasColumnName("FCRMVI_PCTBF9");

                entity.Property(e => e.Fcrmvi_Pctbfn)
                    .HasColumnType("numeric(15, 7)")
                    .HasColumnName("FCRMVI_PCTBFN");

                entity.Property(e => e.Fcrmvi_Pctcom)
                    .HasColumnType("numeric(15, 7)")
                    .HasColumnName("FCRMVI_PCTCOM");

                entity.Property(e => e.Fcrmvi_Porant)
                    .HasColumnType("numeric(15, 7)")
                    .HasColumnName("FCRMVI_PORANT");

                entity.Property(e => e.Fcrmvi_Precio)
                    .HasColumnType("numeric(20, 6)")
                    .HasColumnName("FCRMVI_PRECIO");

                entity.Property(e => e.Fcrmvi_Preext)
                    .HasColumnType("numeric(20, 6)")
                    .HasColumnName("FCRMVI_PREEXT");

                entity.Property(e => e.Fcrmvi_Prenac)
                    .HasColumnType("numeric(20, 6)")
                    .HasColumnName("FCRMVI_PRENAC");

                entity.Property(e => e.Fcrmvi_Presec)
                    .HasColumnType("numeric(20, 6)")
                    .HasColumnName("FCRMVI_PRESEC");

                entity.Property(e => e.Fcrmvi_Preuss)
                    .HasColumnType("numeric(20, 6)")
                    .HasColumnName("FCRMVI_PREUSS");

                entity.Property(e => e.Fcrmvi_Sector)
                    .HasMaxLength(15)
                    .IsUnicode(false)
                    .HasColumnName("FCRMVI_SECTOR");

                entity.Property(e => e.Fcrmvi_Sectra)
                    .HasMaxLength(15)
                    .IsUnicode(false)
                    .HasColumnName("FCRMVI_SECTRA");

                entity.Property(e => e.Fcrmvi_Sucurs)
                    .HasMaxLength(6)
                    .IsUnicode(false)
                    .HasColumnName("FCRMVI_SUCURS");

                entity.Property(e => e.Fcrmvi_Sysver)
                    .HasMaxLength(10)
                    .IsUnicode(false)
                    .HasColumnName("FCRMVI_SYSVER");

                entity.Property(e => e.Fcrmvi_Tatrib)
                    .HasMaxLength(30)
                    .IsUnicode(false)
                    .HasColumnName("FCRMVI_TATRIB");

                entity.Property(e => e.Fcrmvi_Tdespa)
                    .HasMaxLength(30)
                    .IsUnicode(false)
                    .HasColumnName("FCRMVI_TDESPA");

                entity.Property(e => e.Fcrmvi_Tenvas)
                    .HasMaxLength(30)
                    .IsUnicode(false)
                    .HasColumnName("FCRMVI_TENVAS");

                entity.Property(e => e.Fcrmvi_Testan)
                    .HasMaxLength(30)
                    .IsUnicode(false)
                    .HasColumnName("FCRMVI_TESTAN");

                entity.Property(e => e.Fcrmvi_Textos)
                    .HasColumnType("text")
                    .HasColumnName("FCRMVI_TEXTOS");

                entity.Property(e => e.Fcrmvi_Tfecha)
                    .HasMaxLength(30)
                    .IsUnicode(false)
                    .HasColumnName("FCRMVI_TFECHA");

                entity.Property(e => e.Fcrmvi_Tipcpt)
                    .HasMaxLength(1)
                    .IsUnicode(false)
                    .HasColumnName("FCRMVI_TIPCPT")
                    .IsFixedLength(true);

                entity.Property(e => e.Fcrmvi_Tipopr)
                    .HasMaxLength(6)
                    .IsUnicode(false)
                    .HasColumnName("FCRMVI_TIPOPR");

                entity.Property(e => e.Fcrmvi_Tipori)
                    .HasMaxLength(6)
                    .IsUnicode(false)
                    .HasColumnName("FCRMVI_TIPORI")
                    .IsFixedLength(true);

                entity.Property(e => e.Fcrmvi_Tippro)
                    .IsRequired()
                    .HasMaxLength(6)
                    .IsUnicode(false)
                    .HasColumnName("FCRMVI_TIPPRO")
                    .IsFixedLength(true);

                entity.Property(e => e.Fcrmvi_Tipuni)
                    .HasMaxLength(1)
                    .IsUnicode(false)
                    .HasColumnName("FCRMVI_TIPUNI");

                entity.Property(e => e.Fcrmvi_Totlin)
                    .HasColumnType("numeric(15, 4)")
                    .HasColumnName("FCRMVI_TOTLIN");

                entity.Property(e => e.Fcrmvi_Totros)
                    .HasMaxLength(30)
                    .IsUnicode(false)
                    .HasColumnName("FCRMVI_TOTROS");

                entity.Property(e => e.Fcrmvi_Tserie)
                    .HasMaxLength(30)
                    .IsUnicode(false)
                    .HasColumnName("FCRMVI_TSERIE");

                entity.Property(e => e.Fcrmvi_Tubica)
                    .HasMaxLength(30)
                    .IsUnicode(false)
                    .HasColumnName("FCRMVI_TUBICA");

                entity.Property(e => e.Fcrmvi_Ultopr)
                    .HasMaxLength(1)
                    .IsUnicode(false)
                    .HasColumnName("FCRMVI_ULTOPR")
                    .IsFixedLength(true);

                entity.Property(e => e.Fcrmvi_Unialt)
                    .HasMaxLength(6)
                    .IsUnicode(false)
                    .HasColumnName("FCRMVI_UNIALT");

                entity.Property(e => e.Fcrmvi_Unicon)
                    .HasMaxLength(6)
                    .IsUnicode(false)
                    .HasColumnName("FCRMVI_UNICON");

                entity.Property(e => e.Fcrmvi_Unifac)
                    .HasMaxLength(6)
                    .IsUnicode(false)
                    .HasColumnName("FCRMVI_UNIFAC");

                entity.Property(e => e.Fcrmvi_Unimed)
                    .HasMaxLength(6)
                    .IsUnicode(false)
                    .HasColumnName("FCRMVI_UNIMED");

                entity.Property(e => e.Fcrmvi_Unisec)
                    .HasMaxLength(6)
                    .IsUnicode(false)
                    .HasColumnName("FCRMVI_UNISEC");

                entity.Property(e => e.Fcrmvi_Userid)
                    .HasMaxLength(64)
                    .IsUnicode(false)
                    .HasColumnName("FCRMVI_USERID");

                entity.Property(e => e.Usr_Fcrmvi_Cndpag)
                    .HasMaxLength(6)
                    .IsUnicode(false)
                    .HasColumnName("USR_FCRMVI_CNDPAG");

                entity.Property(e => e.Usr_Fcrmvi_Codfor)
                    .HasMaxLength(6)
                    .IsUnicode(false)
                    .HasColumnName("USR_FCRMVI_CODFOR");

                entity.Property(e => e.Usr_Fcrmvi_Costos)
                    .HasColumnType("numeric(20, 6)")
                    .HasColumnName("USR_FCRMVI_COSTOS");

                entity.Property(e => e.Usr_Fcrmvi_Ctacte)
                    .HasMaxLength(6)
                    .IsUnicode(false)
                    .HasColumnName("USR_FCRMVI_CTACTE");

                entity.Property(e => e.Usr_Fcrmvi_Item).HasColumnName("USR_FCRMVI_ITEM");

                entity.Property(e => e.Usr_Fcrmvi_Modfor)
                    .HasMaxLength(2)
                    .IsUnicode(false)
                    .HasColumnName("USR_FCRMVI_MODFOR");

                entity.Property(e => e.Usr_Fcrmvi_Nrodot).HasColumnName("USR_FCRMVI_NRODOT");

                entity.Property(e => e.Usr_Fcrmvi_Nrofor).HasColumnName("USR_FCRMVI_NROFOR");

                entity.Property(e => e.Usr_Fcrmvi_Nroint).HasColumnName("USR_FCRMVI_NROINT");

                entity.Property(e => e.Usr_Fcrmvi_Nserie)
                    .HasMaxLength(11)
                    .IsUnicode(false)
                    .HasColumnName("USR_FCRMVI_NSERIE");

                entity.Property(e => e.Usr_Fcrmvi_Vnddor)
                    .HasMaxLength(6)
                    .IsUnicode(false)
                    .HasColumnName("USR_FCRMVI_VNDDOR");
            });

            modelBuilder.Entity<Vtmclc>(entity =>
            {
                entity.HasKey(e => new { e.Vtmclc_Nrocta, e.Vtmclc_Codcon });

                entity.ToTable("VTMCLC");

                entity.Property(e => e.Vtmclc_Nrocta)
                    .HasMaxLength(20)
                    .IsUnicode(false)
                    .HasColumnName("VTMCLC_NROCTA");

                entity.Property(e => e.Vtmclc_Codcon)
                    .HasMaxLength(40)
                    .IsUnicode(false)
                    .HasColumnName("VTMCLC_CODCON");

                entity.Property(e => e.Usr_Vtmclc_Envisf)
                    .HasMaxLength(1)
                    .IsUnicode(false)
                    .HasColumnName("USR_VTMCLC_ENVISF")
                    .IsFixedLength(true);

                entity.Property(e => e.Vtmclc_Celula)
                    .HasMaxLength(30)
                    .IsUnicode(false)
                    .HasColumnName("VTMCLC_CELULA");


                entity.Property(e => e.Vtmclc_Debaja)
                    .HasMaxLength(1)
                    .IsUnicode(false)
                    .HasColumnName("VTMCLC_DEBAJA")
                    .IsFixedLength(true);

                entity.Property(e => e.Vtmclc_Direml)
                    .HasMaxLength(60)
                    .IsUnicode(false)
                    .HasColumnName("VTMCLC_DIREML");

                entity.Property(e => e.Vtmclc_Fecalt)
                    .HasColumnType("datetime")
                    .HasColumnName("VTMCLC_FECALT");

                entity.Property(e => e.Vtmclc_Fecmod)
                    .HasColumnType("datetime")
                    .HasColumnName("VTMCLC_FECMOD");

                
                entity.Property(e => e.Vtmclc_Oalias)
                    .HasMaxLength(10)
                    .IsUnicode(false)
                    .HasColumnName("VTMCLC_OALIAS");

                entity.Property(e => e.Vtmclc_Observ)
                    .HasColumnType("text")
                    .HasColumnName("VTMCLC_OBSERV");

                entity.Property(e => e.Vtmclc_Puesto)
                    .HasMaxLength(6)
                    .IsUnicode(false)
                    .HasColumnName("VTMCLC_PUESTO");

                entity.Property(e => e.Vtmclc_Recfac)
                    .HasMaxLength(1)
                    .IsUnicode(false)
                    .HasColumnName("VTMCLC_RECFAC")
                    .IsFixedLength(true);


                entity.Property(e => e.Vtmclc_Refcma)
                    .HasMaxLength(1)
                    .IsUnicode(false)
                    .HasColumnName("VTMCLC_REFCMA")
                    .IsFixedLength(true);

                entity.Property(e => e.Vtmclc_Telint)
                    .HasMaxLength(30)
                    .IsUnicode(false)
                    .HasColumnName("VTMCLC_TELINT");

                entity.Property(e => e.Vtmclc_Tipsex)
                    .IsRequired()
                    .HasMaxLength(1)
                    .IsUnicode(false)
                    .HasColumnName("VTMCLC_TIPSEX");


                entity.Property(e => e.Vtmclc_Ultopr)
                    .HasMaxLength(1)
                    .IsUnicode(false)
                    .HasColumnName("VTMCLC_ULTOPR")
                    .IsFixedLength(true);

                entity.Property(e => e.Vtmclc_Userid)
                    .HasMaxLength(64)
                    .IsUnicode(false)
                    .HasColumnName("VTMCLC_USERID");
            });

            modelBuilder.Entity<Vtmclh>(entity =>
            {
                entity.HasKey(e => e.Vtmclh_Nrocta);

                entity.ToTable("VTMCLH");

                entity.HasIndex(e => new { e.Vtmclh_Nrocta, e.Vtmclh_Nombre }, "VTMCLH_SuperFind");

                entity.HasIndex(e => e.Vtmclh_Cobrad, "W_CV_CVRMVHWIZ");

                entity.Property(e => e.Vtmclh_Nrocta)
                    .HasMaxLength(20)
                    .IsUnicode(false)
                    .HasColumnName("VTMCLH_NROCTA");

                entity.Property(e => e.Usr_Dircob)
                    .HasMaxLength(60)
                    .IsUnicode(false)
                    .HasColumnName("USR_DIRCOB");

                entity.Property(e => e.Usr_Dyhcob)
                    .HasMaxLength(60)
                    .IsUnicode(false)
                    .HasColumnName("USR_DYHCOB");

                entity.Property(e => e.Usr_Dyhrec)
                    .HasMaxLength(60)
                    .IsUnicode(false)
                    .HasColumnName("USR_DYHREC");

                entity.Property(e => e.Usr_Resppr)
                    .HasMaxLength(20)
                    .IsUnicode(false)
                    .HasColumnName("USR_RESPPR");

                entity.Property(e => e.Usr_Telppr)
                    .HasMaxLength(30)
                    .IsUnicode(false)
                    .HasColumnName("USR_TELPPR");

                entity.Property(e => e.Usr_Vtmclh_Altapr)
                    .HasMaxLength(1)
                    .IsUnicode(false)
                    .HasColumnName("USR_VTMCLH_ALTAPR")
                    .IsFixedLength(true);

                entity.Property(e => e.Usr_Vtmclh_Asesor)
                    .HasMaxLength(6)
                    .IsUnicode(false)
                    .HasColumnName("USR_VTMCLH_ASESOR");

                entity.Property(e => e.Usr_Vtmclh_Clicob)
                    .HasMaxLength(20)
                    .IsUnicode(false)
                    .HasColumnName("USR_VTMCLH_CLICOB");

                entity.Property(e => e.Usr_Vtmclh_Cluatc)
                    .HasMaxLength(1)
                    .IsUnicode(false)
                    .HasColumnName("USR_VTMCLH_CLUATC")
                    .IsFixedLength(true);

                entity.Property(e => e.Usr_Vtmclh_Codact)
                    .HasMaxLength(6)
                    .IsUnicode(false)
                    .HasColumnName("USR_VTMCLH_CODACT");

                entity.Property(e => e.Usr_Vtmclh_Coment)
                    .HasColumnType("text")
                    .HasColumnName("USR_VTMCLH_COMENT");

                entity.Property(e => e.Usr_Vtmclh_Comnac)
                    .HasMaxLength(6)
                    .IsUnicode(false)
                    .HasColumnName("USR_VTMCLH_COMNAC");

                entity.Property(e => e.Usr_Vtmclh_Conces)
                    .HasMaxLength(1)
                    .IsUnicode(false)
                    .HasColumnName("USR_VTMCLH_CONCES")
                    .IsFixedLength(true);

                entity.Property(e => e.Usr_Vtmclh_Deuven)
                    .HasMaxLength(1)
                    .IsUnicode(false)
                    .HasColumnName("USR_VTMCLH_DEUVEN")
                    .IsFixedLength(true);

                entity.Property(e => e.Usr_Vtmclh_Envisf)
                    .HasMaxLength(1)
                    .IsUnicode(false)
                    .HasColumnName("USR_VTMCLH_ENVISF")
                    .IsFixedLength(true);

                entity.Property(e => e.Usr_Vtmclh_Fiagro)
                    .HasMaxLength(1)
                    .IsUnicode(false)
                    .HasColumnName("USR_VTMCLH_FIAGRO")
                    .IsFixedLength(true);

                entity.Property(e => e.Usr_Vtmclh_Floplu)
                    .HasMaxLength(1)
                    .IsUnicode(false)
                    .HasColumnName("USR_VTMCLH_FLOPLU")
                    .IsFixedLength(true);

                entity.Property(e => e.Usr_Vtmclh_Gescob)
                    .HasMaxLength(1)
                    .IsUnicode(false)
                    .HasColumnName("USR_VTMCLH_GESCOB")
                    .IsFixedLength(true);

                entity.Property(e => e.Usr_Vtmclh_Nooper)
                    .HasMaxLength(1)
                    .IsUnicode(false)
                    .HasColumnName("USR_VTMCLH_NOOPER")
                    .IsFixedLength(true);

                entity.Property(e => e.Usr_Vtmclh_Precom)
                    .HasMaxLength(1)
                    .IsUnicode(false)
                    .HasColumnName("USR_VTMCLH_PRECOM")
                    .IsFixedLength(true);

                entity.Property(e => e.Usr_Vtmclh_Prendar)
                    .HasMaxLength(1)
                    .IsUnicode(false)
                    .HasColumnName("USR_VTMCLH_PRENDAR")
                    .IsFixedLength(true);

                entity.Property(e => e.Usr_Vtmclh_Rapel)
                    .HasMaxLength(1)
                    .IsUnicode(false)
                    .HasColumnName("USR_VTMCLH_RAPEL")
                    .IsFixedLength(true);

                entity.Property(e => e.Usr_Vtmclh_Segmto)
                    .HasMaxLength(6)
                    .IsUnicode(false)
                    .HasColumnName("USR_VTMCLH_SEGMTO");

                entity.Property(e => e.Usr_Vtmclh_Userid)
                    .HasMaxLength(64)
                    .IsUnicode(false)
                    .HasColumnName("USR_VTMCLH_USERID");

                entity.Property(e => e.Vtmclh_Activd)
                    .HasMaxLength(6)
                    .IsUnicode(false)
                    .HasColumnName("VTMCLH_ACTIVD");

                entity.Property(e => e.Vtmclh_Apell1)
                    .HasMaxLength(60)
                    .IsUnicode(false)
                    .HasColumnName("VTMCLH_APELL1");

                entity.Property(e => e.Vtmclh_Apell2)
                    .HasMaxLength(60)
                    .IsUnicode(false)
                    .HasColumnName("VTMCLH_APELL2");

                entity.Property(e => e.Vtmclh_Bmpbmp)
                    .HasMaxLength(255)
                    .IsUnicode(false)
                    .HasColumnName("VTMCLH_BMPBMP");

                entity.Property(e => e.Vtmclh_Camalt)
                    .HasMaxLength(6)
                    .IsUnicode(false)
                    .HasColumnName("VTMCLH_CAMALT");

                entity.Property(e => e.Vtmclh_Camion)
                    .HasMaxLength(6)
                    .IsUnicode(false)
                    .HasColumnName("VTMCLH_CAMION");

                entity.Property(e => e.Vtmclh_Catego)
                    .HasMaxLength(6)
                    .IsUnicode(false)
                    .HasColumnName("VTMCLH_CATEGO");

                entity.Property(e => e.Vtmclh_Cmpver)
                    .HasMaxLength(10)
                    .IsUnicode(false)
                    .HasColumnName("VTMCLH_CMPVER");

                entity.Property(e => e.Vtmclh_Cndint)
                    .HasMaxLength(6)
                    .IsUnicode(false)
                    .HasColumnName("VTMCLH_CNDINT");

                entity.Property(e => e.Vtmclh_Cndiva)
                    .IsRequired()
                    .HasMaxLength(6)
                    .IsUnicode(false)
                    .HasColumnName("VTMCLH_CNDIVA");

                entity.Property(e => e.Vtmclh_Cndpag)
                    .IsRequired()
                    .HasMaxLength(6)
                    .IsUnicode(false)
                    .HasColumnName("VTMCLH_CNDPAG");

                entity.Property(e => e.Vtmclh_Cndpre)
                    .HasMaxLength(10)
                    .IsUnicode(false)
                    .HasColumnName("VTMCLH_CNDPRE")
                    .IsFixedLength(true);

                entity.Property(e => e.Vtmclh_Cobrad)
                    .IsRequired()
                    .HasMaxLength(6)
                    .IsUnicode(false)
                    .HasColumnName("VTMCLH_COBRAD");

                entity.Property(e => e.Vtmclh_Codcof)
                    .HasMaxLength(6)
                    .IsUnicode(false)
                    .HasColumnName("VTMCLH_CODCOF");

                entity.Property(e => e.Vtmclh_Codcpt)
                    .HasMaxLength(6)
                    .IsUnicode(false)
                    .HasColumnName("VTMCLH_CODCPT");

                entity.Property(e => e.Vtmclh_Codcrd)
                    .HasMaxLength(6)
                    .IsUnicode(false)
                    .HasColumnName("VTMCLH_CODCRD");

                entity.Property(e => e.Vtmclh_Codent)
                    .HasMaxLength(10)
                    .IsUnicode(false)
                    .HasColumnName("VTMCLH_CODENT");

                entity.Property(e => e.Vtmclh_Codexp)
                    .HasMaxLength(6)
                    .IsUnicode(false)
                    .HasColumnName("VTMCLH_CODEXP");

                entity.Property(e => e.Vtmclh_Codfil)
                    .HasMaxLength(6)
                    .IsUnicode(false)
                    .HasColumnName("VTMCLH_CODFIL");

                entity.Property(e => e.Vtmclh_Codopr)
                    .HasMaxLength(30)
                    .IsUnicode(false)
                    .HasColumnName("VTMCLH_CODOPR");

                entity.Property(e => e.Vtmclh_Codpai)
                    .IsRequired()
                    .HasMaxLength(3)
                    .IsUnicode(false)
                    .HasColumnName("VTMCLH_CODPAI");

                entity.Property(e => e.Vtmclh_Codpos)
                    .IsRequired()
                    .HasMaxLength(10)
                    .IsUnicode(false)
                    .HasColumnName("VTMCLH_CODPOS");

                entity.Property(e => e.Vtmclh_Codzon)
                    .IsRequired()
                    .HasMaxLength(6)
                    .IsUnicode(false)
                    .HasColumnName("VTMCLH_CODZON");

                entity.Property(e => e.Vtmclh_Contad)
                    .HasMaxLength(1)
                    .IsUnicode(false)
                    .HasColumnName("VTMCLH_CONTAD")
                    .IsFixedLength(true);

                entity.Property(e => e.Vtmclh_Copifc).HasColumnName("VTMCLH_COPIFC");

                entity.Property(e => e.Vtmclh_Copist).HasColumnName("VTMCLH_COPIST");

                entity.Property(e => e.Vtmclh_Copivt).HasColumnName("VTMCLH_COPIVT");

                entity.Property(e => e.Vtmclh_Cuenta)
                    .HasMaxLength(40)
                    .IsUnicode(false)
                    .HasColumnName("VTMCLH_CUENTA");

                entity.Property(e => e.Vtmclh_Debaja)
                    .HasMaxLength(1)
                    .IsUnicode(false)
                    .HasColumnName("VTMCLH_DEBAJA")
                    .IsFixedLength(true);

                entity.Property(e => e.Vtmclh_Deposi)
                    .HasMaxLength(15)
                    .IsUnicode(false)
                    .HasColumnName("VTMCLH_DEPOSI");

                entity.Property(e => e.Vtmclh_Deptos)
                    .HasMaxLength(6)
                    .IsUnicode(false)
                    .HasColumnName("VTMCLH_DEPTOS");

                entity.Property(e => e.Vtmclh_Deptra)
                    .HasMaxLength(15)
                    .IsUnicode(false)
                    .HasColumnName("VTMCLH_DEPTRA");

                entity.Property(e => e.Vtmclh_Difdes)
                    .HasColumnType("datetime")
                    .HasColumnName("VTMCLH_DIFDES");

                entity.Property(e => e.Vtmclh_Difdia).HasColumnName("VTMCLH_DIFDIA");

                entity.Property(e => e.Vtmclh_Difhas)
                    .HasColumnType("datetime")
                    .HasColumnName("VTMCLH_DIFHAS");

                entity.Property(e => e.Vtmclh_Direcc)
                    .HasMaxLength(255)
                    .IsUnicode(false)
                    .HasColumnName("VTMCLH_DIRECC");

                entity.Property(e => e.Vtmclh_Direml)
                    .HasMaxLength(60)
                    .IsUnicode(false)
                    .HasColumnName("VTMCLH_DIREML");

                entity.Property(e => e.Vtmclh_Dirent)
                    .HasMaxLength(255)
                    .IsUnicode(false)
                    .HasColumnName("VTMCLH_DIRENT");

                entity.Property(e => e.Vtmclh_Direp1)
                    .HasMaxLength(2)
                    .IsUnicode(false)
                    .HasColumnName("VTMCLH_DIREP1");

                entity.Property(e => e.Vtmclh_Direp2)
                    .HasMaxLength(2)
                    .IsUnicode(false)
                    .HasColumnName("VTMCLH_DIREP2");

                entity.Property(e => e.Vtmclh_Direp3)
                    .HasMaxLength(2)
                    .IsUnicode(false)
                    .HasColumnName("VTMCLH_DIREP3");

                entity.Property(e => e.Vtmclh_Direp4)
                    .HasMaxLength(2)
                    .IsUnicode(false)
                    .HasColumnName("VTMCLH_DIREP4");

                entity.Property(e => e.Vtmclh_Direp5)
                    .HasMaxLength(2)
                    .IsUnicode(false)
                    .HasColumnName("VTMCLH_DIREP5");

                entity.Property(e => e.Vtmclh_Distri)
                    .HasMaxLength(1)
                    .IsUnicode(false)
                    .HasColumnName("VTMCLH_DISTRI")
                    .IsFixedLength(true);

                entity.Property(e => e.Vtmclh_Dppiso)
                    .HasMaxLength(6)
                    .IsUnicode(false)
                    .HasColumnName("VTMCLH_DPPISO");

                entity.Property(e => e.Vtmclh_Edisub)
                    .HasMaxLength(1)
                    .IsUnicode(false)
                    .HasColumnName("VTMCLH_EDISUB")
                    .IsFixedLength(true);

                entity.Property(e => e.Vtmclh_Email)
                    .HasMaxLength(60)
                    .IsUnicode(false)
                    .HasColumnName("VTMCLH_EMAIL");

                entity.Property(e => e.Vtmclh_Fecalt)
                    .HasColumnType("datetime")
                    .HasColumnName("VTMCLH_FECALT");

                entity.Property(e => e.Vtmclh_Fecmod)
                    .HasColumnType("datetime")
                    .HasColumnName("VTMCLH_FECMOD");

                entity.Property(e => e.Vtmclh_Fisjur)
                    .IsRequired()
                    .HasMaxLength(1)
                    .IsUnicode(false)
                    .HasColumnName("VTMCLH_FISJUR");

                entity.Property(e => e.Vtmclh_Fletes)
                    .HasMaxLength(1)
                    .IsUnicode(false)
                    .HasColumnName("VTMCLH_FLETES")
                    .IsFixedLength(true);

                entity.Property(e => e.Vtmclh_Genxml)
                    .HasMaxLength(1)
                    .IsUnicode(false)
                    .HasColumnName("VTMCLH_GENXML")
                    .IsFixedLength(true);

                entity.Property(e => e.Vtmclh_Glndes)
                    .HasMaxLength(15)
                    .IsUnicode(false)
                    .HasColumnName("VTMCLH_GLNDES");

                entity.Property(e => e.Vtmclh_Grubon)
                    .HasMaxLength(6)
                    .IsUnicode(false)
                    .HasColumnName("VTMCLH_GRUBON");

                entity.Property(e => e.Vtmclh_Hormov)
                    .HasMaxLength(10)
                    .IsUnicode(false)
                    .HasColumnName("VTMCLH_HORMOV");

                entity.Property(e => e.Vtmclh_Horrec)
                    .HasMaxLength(20)
                    .IsUnicode(false)
                    .HasColumnName("VTMCLH_HORREC");

                entity.Property(e => e.Vtmclh_Impdif)
                    .HasColumnType("numeric(18, 2)")
                    .HasColumnName("VTMCLH_IMPDIF");

                entity.Property(e => e.Vtmclh_Inhibe)
                    .HasMaxLength(1)
                    .IsUnicode(false)
                    .HasColumnName("VTMCLH_INHIBE")
                    .IsFixedLength(true);

                entity.Property(e => e.Vtmclh_Jurent)
                    .HasMaxLength(6)
                    .IsUnicode(false)
                    .HasColumnName("VTMCLH_JURENT");

                entity.Property(e => e.Vtmclh_Jurisd)
                    .IsRequired()
                    .HasMaxLength(6)
                    .IsUnicode(false)
                    .HasColumnName("VTMCLH_JURISD");

                entity.Property(e => e.Vtmclh_Lanexp)
                    .HasMaxLength(1)
                    .IsUnicode(false)
                    .HasColumnName("VTMCLH_LANEXP");

                entity.Property(e => e.Vtmclh_Liscli)
                    .HasMaxLength(1)
                    .IsUnicode(false)
                    .HasColumnName("VTMCLH_LISCLI")
                    .IsFixedLength(true);

                entity.Property(e => e.Vtmclh_Lotori)
                    .HasMaxLength(6)
                    .IsUnicode(false)
                    .HasColumnName("VTMCLH_LOTORI");

                entity.Property(e => e.Vtmclh_Lotrec)
                    .HasMaxLength(6)
                    .IsUnicode(false)
                    .HasColumnName("VTMCLH_LOTREC");

                entity.Property(e => e.Vtmclh_Lottra)
                    .HasMaxLength(6)
                    .IsUnicode(false)
                    .HasColumnName("VTMCLH_LOTTRA");

                entity.Property(e => e.Vtmclh_Maxitm).HasColumnName("VTMCLH_MAXITM");

                entity.Property(e => e.Vtmclh_Medpag)
                    .HasMaxLength(6)
                    .IsUnicode(false)
                    .HasColumnName("VTMCLH_MEDPAG");

                entity.Property(e => e.Vtmclh_Modcpt)
                    .HasMaxLength(2)
                    .IsUnicode(false)
                    .HasColumnName("VTMCLH_MODCPT");

                entity.Property(e => e.Vtmclh_Modpag)
                    .HasMaxLength(2)
                    .IsUnicode(false)
                    .HasColumnName("VTMCLH_MODPAG");

                entity.Property(e => e.Vtmclh_Module)
                    .HasMaxLength(10)
                    .IsUnicode(false)
                    .HasColumnName("VTMCLH_MODULE");

                entity.Property(e => e.Vtmclh_Municp)
                    .HasMaxLength(6)
                    .IsUnicode(false)
                    .HasColumnName("VTMCLH_MUNICP");

                entity.Property(e => e.Vtmclh_Nomb01)
                    .HasMaxLength(60)
                    .IsUnicode(false)
                    .HasColumnName("VTMCLH_NOMB01");

                entity.Property(e => e.Vtmclh_Nomb02)
                    .HasMaxLength(60)
                    .IsUnicode(false)
                    .HasColumnName("VTMCLH_NOMB02");

                entity.Property(e => e.Vtmclh_Nombre)
                    .IsRequired()
                    .HasMaxLength(150)
                    .IsUnicode(false)
                    .HasColumnName("VTMCLH_NOMBRE");

                entity.Property(e => e.Vtmclh_Nrodis)
                    .HasMaxLength(20)
                    .IsUnicode(false)
                    .HasColumnName("VTMCLH_NRODIS");

                entity.Property(e => e.Vtmclh_Nrodo1)
                    .HasMaxLength(50)
                    .IsUnicode(false)
                    .HasColumnName("VTMCLH_NRODO1");

                entity.Property(e => e.Vtmclh_Nrodo2)
                    .HasMaxLength(50)
                    .IsUnicode(false)
                    .HasColumnName("VTMCLH_NRODO2");

                entity.Property(e => e.Vtmclh_Nrodo3)
                    .HasMaxLength(50)
                    .IsUnicode(false)
                    .HasColumnName("VTMCLH_NRODO3");

                entity.Property(e => e.Vtmclh_Nrodo4)
                    .HasMaxLength(50)
                    .IsUnicode(false)
                    .HasColumnName("VTMCLH_NRODO4");

                entity.Property(e => e.Vtmclh_Nrodo5)
                    .HasMaxLength(50)
                    .IsUnicode(false)
                    .HasColumnName("VTMCLH_NRODO5");

                entity.Property(e => e.Vtmclh_Nrodoc)
                    .HasMaxLength(50)
                    .IsUnicode(false)
                    .HasColumnName("VTMCLH_NRODOC");

                entity.Property(e => e.Vtmclh_Nrofax)
                    .HasMaxLength(20)
                    .IsUnicode(false)
                    .HasColumnName("VTMCLH_NROFAX");

                entity.Property(e => e.Vtmclh_Nrosub)
                    .HasMaxLength(20)
                    .IsUnicode(false)
                    .HasColumnName("VTMCLH_NROSUB");

                entity.Property(e => e.Vtmclh_Ntelex)
                    .HasMaxLength(15)
                    .IsUnicode(false)
                    .HasColumnName("VTMCLH_NTELEX");

                entity.Property(e => e.Vtmclh_Numero)
                    .HasMaxLength(6)
                    .IsUnicode(false)
                    .HasColumnName("VTMCLH_NUMERO");

                entity.Property(e => e.Vtmclh_Oalias)
                    .HasMaxLength(10)
                    .IsUnicode(false)
                    .HasColumnName("VTMCLH_OALIAS");

                entity.Property(e => e.Vtmclh_Oblcon)
                    .HasMaxLength(1)
                    .IsUnicode(false)
                    .HasColumnName("VTMCLH_OBLCON")
                    .IsFixedLength(true);

                entity.Property(e => e.Vtmclh_Oleole)
                    .HasColumnType("text")
                    .HasColumnName("VTMCLH_OLEOLE");

                entity.Property(e => e.Vtmclh_Paient)
                    .HasMaxLength(3)
                    .IsUnicode(false)
                    .HasColumnName("VTMCLH_PAIENT");

                entity.Property(e => e.Vtmclh_Perina)
                    .HasColumnType("numeric(6, 0)")
                    .HasColumnName("VTMCLH_PERINA");

                entity.Property(e => e.Vtmclh_Prmipr)
                    .HasColumnType("numeric(15, 7)")
                    .HasColumnName("VTMCLH_PRMIPR");

                entity.Property(e => e.Vtmclh_Prmxpr)
                    .HasColumnType("numeric(15, 7)")
                    .HasColumnName("VTMCLH_PRMXPR");

                entity.Property(e => e.Vtmclh_Respon)
                    .HasMaxLength(60)
                    .IsUnicode(false)
                    .HasColumnName("VTMCLH_RESPON");

                entity.Property(e => e.Vtmclh_Rubr01)
                    .HasMaxLength(20)
                    .IsUnicode(false)
                    .HasColumnName("VTMCLH_RUBR01");

                entity.Property(e => e.Vtmclh_Rubr02)
                    .HasMaxLength(20)
                    .IsUnicode(false)
                    .HasColumnName("VTMCLH_RUBR02");

                entity.Property(e => e.Vtmclh_Rubr03)
                    .HasMaxLength(20)
                    .IsUnicode(false)
                    .HasColumnName("VTMCLH_RUBR03");

                entity.Property(e => e.Vtmclh_Rubr04)
                    .HasMaxLength(20)
                    .IsUnicode(false)
                    .HasColumnName("VTMCLH_RUBR04");

                entity.Property(e => e.Vtmclh_Rubr05)
                    .HasMaxLength(20)
                    .IsUnicode(false)
                    .HasColumnName("VTMCLH_RUBR05");

                entity.Property(e => e.Vtmclh_Rubr06)
                    .HasMaxLength(20)
                    .IsUnicode(false)
                    .HasColumnName("VTMCLH_RUBR06");

                entity.Property(e => e.Vtmclh_Rubr07)
                    .HasMaxLength(20)
                    .IsUnicode(false)
                    .HasColumnName("VTMCLH_RUBR07");

                entity.Property(e => e.Vtmclh_Rubr08)
                    .HasMaxLength(20)
                    .IsUnicode(false)
                    .HasColumnName("VTMCLH_RUBR08");

                entity.Property(e => e.Vtmclh_Rubr09)
                    .HasMaxLength(20)
                    .IsUnicode(false)
                    .HasColumnName("VTMCLH_RUBR09");

                entity.Property(e => e.Vtmclh_Rubr10)
                    .HasMaxLength(20)
                    .IsUnicode(false)
                    .HasColumnName("VTMCLH_RUBR10");

                entity.Property(e => e.Vtmclh_Sector)
                    .HasMaxLength(15)
                    .IsUnicode(false)
                    .HasColumnName("VTMCLH_SECTOR");

                entity.Property(e => e.Vtmclh_Sectra)
                    .HasMaxLength(15)
                    .IsUnicode(false)
                    .HasColumnName("VTMCLH_SECTRA");

                entity.Property(e => e.Vtmclh_Segpro)
                    .HasMaxLength(1)
                    .IsUnicode(false)
                    .HasColumnName("VTMCLH_SEGPRO")
                    .IsFixedLength(true);

                entity.Property(e => e.Vtmclh_Sysver)
                    .HasMaxLength(10)
                    .IsUnicode(false)
                    .HasColumnName("VTMCLH_SYSVER");

                entity.Property(e => e.Vtmclh_Telefn)
                    .HasMaxLength(30)
                    .IsUnicode(false)
                    .HasColumnName("VTMCLH_TELEFN");

                entity.Property(e => e.Vtmclh_Textos)
                    .HasColumnType("text")
                    .HasColumnName("VTMCLH_TEXTOS");

                entity.Property(e => e.Vtmclh_Tipcpt)
                    .HasMaxLength(1)
                    .IsUnicode(false)
                    .HasColumnName("VTMCLH_TIPCPT")
                    .IsFixedLength(true);

                entity.Property(e => e.Vtmclh_Tipdo1)
                    .HasMaxLength(4)
                    .IsUnicode(false)
                    .HasColumnName("VTMCLH_TIPDO1");

                entity.Property(e => e.Vtmclh_Tipdo2)
                    .HasMaxLength(4)
                    .IsUnicode(false)
                    .HasColumnName("VTMCLH_TIPDO2");

                entity.Property(e => e.Vtmclh_Tipdo3)
                    .HasMaxLength(4)
                    .IsUnicode(false)
                    .HasColumnName("VTMCLH_TIPDO3");

                entity.Property(e => e.Vtmclh_Tipdo4)
                    .HasMaxLength(4)
                    .IsUnicode(false)
                    .HasColumnName("VTMCLH_TIPDO4");

                entity.Property(e => e.Vtmclh_Tipdo5)
                    .HasMaxLength(4)
                    .IsUnicode(false)
                    .HasColumnName("VTMCLH_TIPDO5");

                entity.Property(e => e.Vtmclh_Tipdoc)
                    .HasMaxLength(4)
                    .IsUnicode(false)
                    .HasColumnName("VTMCLH_TIPDOC");

                entity.Property(e => e.Vtmclh_Tipopr)
                    .HasMaxLength(6)
                    .IsUnicode(false)
                    .HasColumnName("VTMCLH_TIPOPR");

                entity.Property(e => e.Vtmclh_Tippag)
                    .HasMaxLength(1)
                    .IsUnicode(false)
                    .HasColumnName("VTMCLH_TIPPAG")
                    .IsFixedLength(true);

                entity.Property(e => e.Vtmclh_Tracod)
                    .HasMaxLength(6)
                    .IsUnicode(false)
                    .HasColumnName("VTMCLH_TRACOD");

                entity.Property(e => e.Vtmclh_Trafcr)
                    .HasMaxLength(1)
                    .IsUnicode(false)
                    .HasColumnName("VTMCLH_TRAFCR")
                    .IsFixedLength(true);

                entity.Property(e => e.Vtmclh_Ultopr)
                    .HasMaxLength(1)
                    .IsUnicode(false)
                    .HasColumnName("VTMCLH_ULTOPR")
                    .IsFixedLength(true);

                entity.Property(e => e.Vtmclh_Userid)
                    .HasMaxLength(64)
                    .IsUnicode(false)
                    .HasColumnName("VTMCLH_USERID");

                entity.Property(e => e.Vtmclh_Vnddor)
                    .IsRequired()
                    .HasMaxLength(6)
                    .IsUnicode(false)
                    .HasColumnName("VTMCLH_VNDDOR");

                entity.Property(e => e.Vtmclh_Zonent)
                    .HasMaxLength(6)
                    .IsUnicode(false)
                    .HasColumnName("VTMCLH_ZONENT");
            });

            modelBuilder.Entity<Grtpac>(entity =>
            {
                entity.HasKey(e => new { e.GrtpacCodpai, e.GrtpacCodpos });

                entity.ToTable("GRTPAC");

                entity.Property(e => e.GrtpacCodpai)
                    .HasMaxLength(3)
                    .IsUnicode(false)
                    .HasColumnName("GRTPAC_CODPAI");

                entity.Property(e => e.GrtpacCodpos)
                    .HasMaxLength(10)
                    .IsUnicode(false)
                    .HasColumnName("GRTPAC_CODPOS");

                entity.Property(e => e.GrtpacCmpver)
                    .HasMaxLength(10)
                    .IsUnicode(false)
                    .HasColumnName("GRTPAC_CMPVER");

                entity.Property(e => e.GrtpacCodpro)
                    .HasMaxLength(3)
                    .IsUnicode(false)
                    .HasColumnName("GRTPAC_CODPRO");

                entity.Property(e => e.GrtpacDebaja)
                    .HasMaxLength(1)
                    .IsUnicode(false)
                    .HasColumnName("GRTPAC_DEBAJA")
                    .IsFixedLength(true);

                entity.Property(e => e.GrtpacDescrp)
                    .IsRequired()
                    .HasMaxLength(60)
                    .IsUnicode(false)
                    .HasColumnName("GRTPAC_DESCRP");

                entity.Property(e => e.GrtpacFecalt)
                    .HasColumnType("datetime")
                    .HasColumnName("GRTPAC_FECALT");

                entity.Property(e => e.GrtpacFecmod)
                    .HasColumnType("datetime")
                    .HasColumnName("GRTPAC_FECMOD");

                entity.Property(e => e.GrtpacHormov)
                    .HasMaxLength(10)
                    .IsUnicode(false)
                    .HasColumnName("GRTPAC_HORMOV");

                entity.Property(e => e.GrtpacJurisd)
                    .HasMaxLength(6)
                    .IsUnicode(false)
                    .HasColumnName("GRTPAC_JURISD");

                entity.Property(e => e.GrtpacLotori)
                    .HasMaxLength(6)
                    .IsUnicode(false)
                    .HasColumnName("GRTPAC_LOTORI");

                entity.Property(e => e.GrtpacLotrec)
                    .HasMaxLength(6)
                    .IsUnicode(false)
                    .HasColumnName("GRTPAC_LOTREC");

                entity.Property(e => e.GrtpacLottra)
                    .HasMaxLength(6)
                    .IsUnicode(false)
                    .HasColumnName("GRTPAC_LOTTRA");

                entity.Property(e => e.GrtpacModule)
                    .HasMaxLength(10)
                    .IsUnicode(false)
                    .HasColumnName("GRTPAC_MODULE");

                entity.Property(e => e.GrtpacOalias)
                    .HasMaxLength(10)
                    .IsUnicode(false)
                    .HasColumnName("GRTPAC_OALIAS");

                entity.Property(e => e.GrtpacPaipro)
                    .HasMaxLength(3)
                    .IsUnicode(false)
                    .HasColumnName("GRTPAC_PAIPRO");

                entity.Property(e => e.GrtpacSysver)
                    .HasMaxLength(10)
                    .IsUnicode(false)
                    .HasColumnName("GRTPAC_SYSVER");

                entity.Property(e => e.GrtpacTstamp)
                    .IsRowVersion()
                    .IsConcurrencyToken()
                    .HasColumnName("GRTPAC_TSTAMP");

                entity.Property(e => e.GrtpacUltopr)
                    .HasMaxLength(1)
                    .IsUnicode(false)
                    .HasColumnName("GRTPAC_ULTOPR")
                    .IsFixedLength(true);

                entity.Property(e => e.GrtpacUserid)
                    .HasMaxLength(64)
                    .IsUnicode(false)
                    .HasColumnName("GRTPAC_USERID");
            });



            OnModelCreatingPartial(modelBuilder);
        }

        partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
    }
}
