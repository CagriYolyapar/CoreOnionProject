using Microsoft.AspNetCore.Identity;
using Project.ENTITIES.CoreInterfaces;
using Project.ENTITIES.Enums;
using System;
using System.Collections.Generic;
using System.Text;

namespace Project.ENTITIES.Models
{
    //Asagıdaki yapıda IdentityUser sınıfına generic int vermemizin sebebi sudur; normal şartlarda Identity yapısı bütün primary key'leri Sql'e nvarchar olarak gönderir...Ancak siz IdentityUser'a generic olarak bir int tipi verdiginizde Identity yapısının olusturacagı tablolar int tipinde bir primary key'e sahip olacaklardır...

    public class AppUser:IdentityUser<int>,IEntity
    {
        public int ID { get; set; }
        public DateTime CreatedDate { get; set; }
        public DateTime? DeletedDate { get; set; }
        public DateTime? ModifiedDate { get; set; }
        public DataStatus? Status { get; set; }

        public AppUser()
        {
            CreatedDate = DateTime.Now;
            Status = DataStatus.Inserted;
        }

        //Relational Properties
        public virtual AppUserProfile Profile { get; set; }
        public virtual List<Order> Orders { get; set; }

    }
}
