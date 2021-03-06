﻿using com.jiechengbao.entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace com.jiechengbao.Ibll
{
    public interface IGoodsBLL
    {
        IEnumerable<Goods> GetAllNoDeteledGoods();
        bool Add(Goods goods);
        Goods GetGoodsByCode(string code);
        Goods GetGoodsByName(string name);
        bool Update(Goods goods);
        Goods GetGoodsById(Guid Id);
        IEnumerable<Goods> GetGoodsByCondition(string condition);
    }
}
