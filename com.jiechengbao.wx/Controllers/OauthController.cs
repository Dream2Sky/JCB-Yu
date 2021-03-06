﻿using com.jiechengbao.common;
using com.jiechengbao.entity;
using com.jiechengbao.Ibll;
using com.jiechengbao.wx.Models;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace com.jiechengbao.wx.Controllers
{
    public class OauthController:Controller
    {
        private IMemberBLL _memberBLL;
        public OauthController(IMemberBLL memberBLL)
        {
            _memberBLL = memberBLL;
        }

        public ActionResult GetCode(string code)
        {
            LogHelper.Log.Write("传递的code:" + code);
            if (string.IsNullOrEmpty(code))
            {
                string url = "https://open.weixin.qq.com/connect/oauth2/authorize?appid=wx3fab45769c82a189&redirect_uri=http://jcb.ybtx88.com/Oauth/GetCode&response_type=code&scope=snsapi_userinfo&state=STATE#wechat_redirect";

                System.Web.HttpContext.Current.Response.Redirect(url);

                return RedirectToAction("GetCode");
            }
            else
            {
                CacheManager.SetCache("code", code);
            }
            UserInfo_JsonModel user = GetWxUserInfo();

            LogHelper.Log.Write("openid:" + user.openid + ", nickname:" + user.nickname + ", sex:" + user.sex + ", headerimage:" + user.headimgurl);

            if (!_memberBLL.IsExist(user.openid))
            {
                Member member = new Member();
                member.Id = Guid.NewGuid();
                member.IsDeleted = false;
                member.NickeName = user.nickname;
                member.OpenId = user.openid;
                member.Vip = 0;
                member.HeadImage = user.headimgurl;
                member.Assets = 0;
                member.CreatedTime = DateTime.Now;
                member.Credit = 0;
                member.DeletedTime = DateTime.MinValue.AddHours(8);

                if (!_memberBLL.Add(member))
                {
                    LogHelper.Log.Write("添加新用户失败");
                }
                 
            }
            LogHelper.Log.Write("user's openid = " + user.openid);

            System.Web.HttpContext.Current.Session["member"] = user.openid;

            if (Request.UrlReferrer == null || Request.UrlReferrer.Host != Request.Url.Host)
            {
                return RedirectToAction("Index", "UserInfo");
            }
            else
            {
                return Redirect(Request.UrlReferrer.ToString());
            }
        }

        public ActionResult GetHelpCode(string code)
        {
            LogHelper.Log.Write("传递的code:" + code);
            if (string.IsNullOrEmpty(code))
            {
                string url = "https://open.weixin.qq.com/connect/oauth2/authorize?appid=wx3fab45769c82a189&redirect_uri=http://jcb.ybtx88.com/Oauth/GetHelpCode&response_type=code&scope=snsapi_userinfo&state=STATE#wechat_redirect";

                System.Web.HttpContext.Current.Response.Redirect(url);

                return RedirectToAction("GetHelpCode");
            }
            else
            {
                CacheManager.SetCache("code", code);
            }
            UserInfo_JsonModel user = GetWxUserInfo();

            LogHelper.Log.Write("openid:" + user.openid + ", nickname:" + user.nickname + ", sex:" + user.sex + ", headerimage:" + user.headimgurl);

            if (!_memberBLL.IsExist(user.openid))
            {
                Member member = new Member();
                member.Id = Guid.NewGuid();
                member.IsDeleted = false;
                member.NickeName = user.nickname;
                member.OpenId = user.openid;
                member.Vip = 0;
                member.HeadImage = user.headimgurl;
                member.Assets = 0;
                member.CreatedTime = DateTime.Now;
                member.Credit = 0;
                member.DeletedTime = DateTime.MinValue.AddHours(8);

                if (!_memberBLL.Add(member))
                {
                    LogHelper.Log.Write("添加新用户失败");
                }

            }
            LogHelper.Log.Write("user's openid = " + user.openid);

            System.Web.HttpContext.Current.Session["member"] = user.openid;

            if (Request.UrlReferrer == null || Request.UrlReferrer.Host != Request.Url.Host)
            {
                return RedirectToAction("Help", "UserInfo");
            }
            else
            {
                return Redirect(Request.UrlReferrer.ToString());
            }
        }

        public ActionResult GetRechargeCode(string code)
        {
            LogHelper.Log.Write("传递的code:" + code);
            if (string.IsNullOrEmpty(code))
            {
                string url = "https://open.weixin.qq.com/connect/oauth2/authorize?appid=wx3fab45769c82a189&redirect_uri=http://jcb.ybtx88.com/Oauth/GetRechargeCode&response_type=code&scope=snsapi_userinfo&state=STATE#wechat_redirect";

                System.Web.HttpContext.Current.Response.Redirect(url);

                return RedirectToAction("GetRechargeCode");
            }
            else
            {
                CacheManager.SetCache("code", code);
            }
            UserInfo_JsonModel user = GetWxUserInfo();

            LogHelper.Log.Write("openid:" + user.openid + ", nickname:" + user.nickname + ", sex:" + user.sex + ", headerimage:" + user.headimgurl);

            if (!_memberBLL.IsExist(user.openid))
            {
                Member member = new Member();
                member.Id = Guid.NewGuid();
                member.IsDeleted = false;
                member.NickeName = user.nickname;
                member.OpenId = user.openid;
                member.Vip = 0;
                member.HeadImage = user.headimgurl;
                member.Assets = 0;
                member.CreatedTime = DateTime.Now;
                member.Credit = 0;
                member.DeletedTime = DateTime.MinValue.AddHours(8);

                if (!_memberBLL.Add(member))
                {
                    LogHelper.Log.Write("添加新用户失败");
                }

            }
            LogHelper.Log.Write("user's openid = " + user.openid);

            System.Web.HttpContext.Current.Session["member"] = user.openid;

            if (Request.UrlReferrer == null || Request.UrlReferrer.Host != Request.Url.Host)
            {
                return RedirectToAction("RechargeOptionsList", "UserInfo");
            }
            else
            {
                return Redirect(Request.UrlReferrer.ToString());
            }
        }

        public ActionResult GetUserInfoCode(string code)
        {
            if (string.IsNullOrEmpty(code))
            {
                string url = "https://open.weixin.qq.com/connect/oauth2/authorize?appid=wx3fab45769c82a189&redirect_uri=http://jcb.ybtx88.com/Oauth/GetUserInfoCode&response_type=code&scope=snsapi_userinfo&state=STATE#wechat_redirect";

                System.Web.HttpContext.Current.Response.Redirect(url);

                return RedirectToAction("GetRechargeCode");
            }
            else
            {
                CacheManager.SetCache("code", code);
            }
            UserInfo_JsonModel user = GetWxUserInfo();

            if (!_memberBLL.IsExist(user.openid))
            {
                Member member = new Member();
                member.Id = Guid.NewGuid();
                member.IsDeleted = false;
                member.NickeName = user.nickname;
                member.OpenId = user.openid;
                member.Vip = 0;
                member.HeadImage = user.headimgurl;
                member.Assets = 0;
                member.CreatedTime = DateTime.Now;
                member.Credit = 0;
                member.DeletedTime = DateTime.MinValue.AddHours(8);

                if (!_memberBLL.Add(member))
                {
                    LogHelper.Log.Write("添加新用户失败");
                }

            }
            System.Web.HttpContext.Current.Session["member"] = user.openid;

            if (Request.UrlReferrer == null || Request.UrlReferrer.Host != Request.Url.Host)
            {
                return RedirectToAction("Info", "UserInfo");
            }
            else
            {
                return Redirect(Request.UrlReferrer.ToString());
            }
        }


        private UserInfo_JsonModel GetWxUserInfo()
        {
            string code = CacheManager.GetCache("code").ToString();
            string responseString = string.Empty;

            string url = string.Format(@"https://api.weixin.qq.com/sns/oauth2/access_token?appid=wx3fab45769c82a189&secret=1b4feb651f6bbae81776068c241f8603&code={0}&grant_type=authorization_code", code);

            responseString = HttpManager.AccessURL_GET(url);
            Access_Token_JsonModel model = new Access_Token_JsonModel();
            UserInfo_JsonModel user = new UserInfo_JsonModel();

            try
            {
                model = JsonConvert.DeserializeObject<Access_Token_JsonModel>(responseString);

                LogHelper.Log.Write("access_token:" + model.access_token);

                user = GetUserInfo(model);
            }
            catch (Exception ex)
            {
                LogHelper.Log.Write(ex.Message);
                LogHelper.Log.Write(ex.StackTrace);
                throw;
            }

            return user;
        }


        /// <summary>
        /// 通过access_token获取用户信息
        /// </summary>
        /// <param name="model"></param>
        /// <returns></returns>
        private UserInfo_JsonModel GetUserInfo(Access_Token_JsonModel model)
        {
            string responseString = string.Empty;
            string url = string.Format(@"https://api.weixin.qq.com/sns/userinfo?access_token={0}&openid={1}", model.access_token, model.openid);

            responseString = HttpManager.AccessURL_GET(url);
            LogHelper.Log.Write("打印微信返回的xml");
            LogHelper.Log.Write(responseString);
            UserInfo_JsonModel user = new UserInfo_JsonModel();
            try
            {
                user = JsonConvert.DeserializeObject<UserInfo_JsonModel>(responseString);
            }
            catch (Exception ex)
            {
                LogHelper.Log.Write(ex.Message);
                LogHelper.Log.Write(ex.StackTrace);
                throw;
            }

            return user;
        }
    }
}