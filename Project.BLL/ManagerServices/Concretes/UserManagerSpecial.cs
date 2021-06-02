using Project.BLL.ManagerServices.Abstracts;
using Project.DAL.Repositories.Abstracts;
using Project.ENTITIES.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace Project.BLL.ManagerServices.Concretes
{
    public class UserManagerSpecial:BaseManager<AppUser>,IAppUserManager
    {
        public UserManagerSpecial(IRepository<AppUser> appRep):base(appRep)
        {

        }

        public override string Add(AppUser item)
        {
            if (item.PasswordHash!=null && item.UserName!=null)
            {
                _iRep.Add(item);
                return "Ekleme basarılı";
            }
            return "Kullanıcı ismi veya sifre girilmemiş";
        }
    }
}
