﻿using com.jiechengbao.entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace com.jiechengbao.Idal
{
    public interface IOrderDetailDAL:IDataBaseDAL<OrderDetail>
    {
        IEnumerable<OrderDetail> SelectByOrderNo(string orderNO);
        bool Delete(List<OrderDetail> odList);
    }
}
