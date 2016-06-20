﻿using com.jiechengbao.Ibll;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using com.jiechengbao.entity;
using com.jiechengbao.Idal;

namespace com.jiechengbao.bll
{
    public class MemberBLL : IMemberBLL
    {
        private IMemberDAL _memberDAL;
        public MemberBLL(IMemberDAL memberDAL)
        {
            _memberDAL = memberDAL;
        }

        /// <summary>
        /// 获取未标记为删除的用户的集合
        /// </summary>
        /// <returns></returns>
        public IEnumerable<Member> GetAllNoDeletedMembers()
        {
            try
            {
                return _memberDAL.SelectAll().Where(n => n.IsDeleted == false);
            }
            catch (Exception ex)
            {
                LogHelper.Log.Write(ex.Message);
                LogHelper.Log.Write(ex.StackTrace);

                return null;
            }
            
        }

        /// <summary>
        /// 获得所有未标记为删除的用户的数量
        /// </summary>
        /// <returns></returns>
        public int GetAllNoDeletedMembersCount()
        {
            return _memberDAL.SelectNoDeletedMembersCount();
        }

        /// <summary>
        /// 根据MemberID 获取一个Member
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public Member GetMemberById(Guid id)
        {
            return _memberDAL.SelectById(id);
        }

        /// <summary>
        /// 获得昨天的新用户列表
        /// </summary>
        /// <returns></returns>
        public IEnumerable<Member> GetNewMembersAtYesterDay()
        {
            return _memberDAL.SelectNoDeletedMembersByDate(DateTime.Now.AddDays(-1).Date);
        }
    }
}