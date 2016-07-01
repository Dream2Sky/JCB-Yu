﻿using com.jiechengbao.Ibll;
using com.jiechengbao.Idal;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using com.jiechengbao.entity;

namespace com.jiechengbao.bll
{
    public class RechargeBLL:IRechargeBLL
    {
        private IRechargeDAL _rechargeDAL;
        public RechargeBLL(IRechargeDAL rechargeDAL)
        {
            _rechargeDAL = rechargeDAL;
        }

        public IEnumerable<Recharge> GetRechargeListByMemberId(DateTime startTime, DateTime endTime, Guid memberId)
        {
            return _rechargeDAL.SelectRechargeListByMemberId(startTime, endTime, memberId);
        }
    }
}
