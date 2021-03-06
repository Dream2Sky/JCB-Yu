﻿using com.jiechengbao.entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace com.jiechengbao.Ibll
{
    public interface ITransactionBLL
    {
        bool Add(Transaction transaction);
        bool Remove(Transaction transaction);
        IEnumerable<Transaction> GetTransactionByMemberIdwithCount(Guid memberId, int count);
    }
}
