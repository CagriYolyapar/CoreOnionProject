using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Project.ENTITIES.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace Project.MAP.Configurations
{
    public class AppUserConfiguration : BaseConfiguration<AppUser>
    {
        public override void Configure(EntityTypeBuilder<AppUser> builder)
        {
            base.Configure(builder);
            builder.HasOne(x => x.Profile).WithOne(x => x.AppUser).HasForeignKey<AppUserProfile>(x => x.ID); //birebir ilişki ayarımız icin talimatı burada verdik...

            //Bizim AppUser class'ımızın bizim yazdığımız property'lerin yanı sıra Microsoft'un Identity kütüphanesinden gelen property'leri de icerecektir... Identity'den gelen bu property'lerin icerisinde primary key olan ve Id ismine sahip olan bir property daha olacaktır. Dolayısıyla bu class tabloya cevrilirken hem bizim ID property'imiz hem de Identity'nin gönderdigi Id property'si Sql'daki Incasesensitive durum yüzünden aynı sütun sayılarak size migration durumunda bir tabloda aynı isimde iki sütun olamaz diye hata cıkaracaktır...Dolayısıyla bizim burada ID'imiz C#'ta kalsa da onu (kendi ID'imizi) Sql'e göndermememiz gerecektir...
            builder.Ignore(x => x.ID);
        }
    }
}
