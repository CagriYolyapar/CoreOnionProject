using Project.BLL.ManagerServices.Abstracts;
using Project.DAL.Repositories.Abstracts;
using Project.ENTITIES.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace Project.BLL.ManagerServices.Concretes
{
    public class ProfileManager:BaseManager<AppUserProfile>,IProfileManager
    {
        public ProfileManager(IRepository<AppUserProfile> proRep):base(proRep)
        {

        }
    }
}
