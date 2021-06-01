using Project.DAL.Context;
using Project.DAL.Repositories.Abstracts;
using Project.ENTITIES.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace Project.DAL.Repositories.Concretes
{
    public class OrderDetailRepository:BaseRepository<OrderDetail>,IOrderDetailRepository
    {
        public OrderDetailRepository(MyContext db):base(db)
        {

        }
    }
}
