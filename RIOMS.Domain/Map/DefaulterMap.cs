using RIOMS.Domain.Models;
using System;
using System.Collections.Generic;
using System.Data.Entity.ModelConfiguration;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RIOMS.Domain.Map
{
   public class DefaulterMap :  EntityTypeConfiguration<Defaulter>
    {
        public DefaulterMap()
        {
            this.ToTable("Defaulters");
            this.HasKey(t => new { t.VillageId, t.KhataNo, t.Year });
            this.Property(t => t.Cess.Current).HasColumnName("DFC_Current");
            this.Property(t => t.Cess.Previous).HasColumnName("DFC_Previous");
            this.Property(t => t.Cess.Second).HasColumnName("DFC_Second");
            this.Property(t => t.Cess.Third).HasColumnName("DFC_Third");
            this.Property(t => t.Cess.MoreThanThree).HasColumnName("DFC_MoreThanThree");

            this.Property(t => t.CBWR.Current).HasColumnName("DFW_Current");
            this.Property(t => t.CBWR.Previous).HasColumnName("DFW_Previous");
            this.Property(t => t.CBWR.Second).HasColumnName("DFW_Second");
            this.Property(t => t.CBWR.Third).HasColumnName("DFW_Third");
            this.Property(t => t.CBWR.MoreThanThree).HasColumnName("DFW_MoreThanThree");

            this.Property(t => t.LR.Current).HasColumnName("DFLR_Current");
            this.Property(t => t.LR.Previous).HasColumnName("DFLR_Previous");
            this.Property(t => t.LR.Second).HasColumnName("DFLR_Second");
            this.Property(t => t.LR.Third).HasColumnName("DFLR_Third");
            this.Property(t => t.LR.MoreThanThree).HasColumnName("DFLR_MoreThanThree");

            
        }
    }
}
