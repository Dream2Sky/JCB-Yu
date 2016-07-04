﻿using com.jiechengbao.common;
using com.jiechengbao.entity;
using com.jiechengbao.Ibll;
using com.jiechengbao.wx.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace com.jiechengbao.wx.Controllers
{
    public class UserInfoController : Controller
    {
        private IMemberBLL _memberBLL;
        private IGoodsBLL _goodsBLL;
        private IGoodsImagesBLL _goodsImageBLL;
        private IReCommendBLL _recommendBLL;
        private IRechargeBLL _rechargeBLL;
        private ICarBLL _carBLL;
        private IServiceBLL _serviceBLL;
        public UserInfoController(IMemberBLL memberBLL, IGoodsBLL goodsBLL,
            IGoodsImagesBLL goodsImagesBLL, IReCommendBLL recommendBLL, 
            IRechargeBLL rechargeBLL,ICarBLL carBLL, IServiceBLL serviceBLL)
        {
            _memberBLL = memberBLL;
            _goodsBLL = goodsBLL;
            _goodsImageBLL = goodsImagesBLL;
            _recommendBLL = recommendBLL;
            _rechargeBLL = rechargeBLL;
            _carBLL = carBLL;
        }

        public ActionResult Index()
        {
            System.Web.HttpContext.Current.Session["member"] = "okzkZv6LHCo-vIyZHynDoXjeUbKs";

            // 先获得推荐商品的索引 即商品的guid list
            IEnumerable<ReCommend> recommendList = _recommendBLL.GetAllReCommendListwithSortByTime();

            List<GoodsModel> goodsModelList = new List<GoodsModel>();
            foreach (var item in recommendList)
            {
                Goods goods = _goodsBLL.GetGoodsById(item.GoodsId);
                GoodsImage gi = _goodsImageBLL.GetPictureByGoodsId(goods.Id);

                GoodsModel gm = new GoodsModel(goods);
                gm.PicturePath = gi.ImagePath;

                goodsModelList.Add(gm);
            }

            // 要显示的推荐商品
            ViewData["GoodsModelList"] = goodsModelList;
            return View();
        }

        public ActionResult Help()
        {
            return View();
        }

        public ActionResult Check()
        {
            Member member = _memberBLL.GetMemberByOpenId(System.Web.HttpContext.Current.Session["member"].ToString());
            List<Car> carList = _carBLL.GetCarListByMemberId(member.Id).ToList();

            ViewData["carList"] = carList;

            return View();
        }

        public ActionResult Info()
        {
            Member member = _memberBLL.GetMemberByOpenId(System.Web.HttpContext.Current.Session["member"].ToString());
            return View(member);
        }

        public ActionResult Phone()
        {
            Member member = _memberBLL.GetMemberByOpenId(System.Web.HttpContext.Current.Session["member"].ToString());
            ViewBag.Phone = member.Phone;
            return View();
        }

        public ActionResult MyServices()
        {
            List<MyService> msList = new List<MyService>();
            List<ServiceDetailModel> sdmList = new List<ServiceDetailModel>();
            Member member = _memberBLL.GetMemberByOpenId(System.Web.HttpContext.Current.Session["member"].ToString());
            msList = _serviceBLL.GetMyServiceByMemberId(member.Id).ToList();

            foreach (var item in msList)
            {
                ServiceDetailModel sdm = new ServiceDetailModel();
                sdm.CurrentCount = item.CurrentCount;
                sdm.ServcieId = item.Id;
                sdm.ServiceImagePath = _goodsImageBLL.GetPictureByGoodsId(item.GoodsId).ImagePath;
                sdm.ServiceName = item.GoodsName;
                sdm.TotalCount = item.TotalCount;

                sdmList.Add(sdm);
            }
            ViewData["SDMList"] = sdmList;
            return View();
        }

        [HttpPost]
        public ActionResult Phone(string phone)
        {
            if (string.IsNullOrEmpty(phone))
            {
                return Json("False", JsonRequestBehavior.AllowGet);
            }

            Member member = _memberBLL.GetMemberByOpenId(System.Web.HttpContext.Current.Session["member"].ToString());
            member.Phone = phone;

            if (_memberBLL.Update(member))
            {
                return Json("True", JsonRequestBehavior.AllowGet);
            }
            else
            {
                return Json("False", JsonRequestBehavior.AllowGet);
            }
        }

        public ActionResult Recharge()
        {
            return View();
        }

        [HttpPost]
        public ActionResult CheckRecharge(DateTime startTime, DateTime endTime)
        {
            // 上来先获取 当前用户 的对象
            Member member = _memberBLL.GetMemberByOpenId(System.Web.HttpContext.Current.Session["member"].ToString());
            if (startTime == null || endTime == null)
            {
                var res = new
                {
                    startTime = startTime,
                    endTime = endTime
                };
                return Json(res, JsonRequestBehavior.AllowGet);
            }

            List<Recharge> rechargeList = _rechargeBLL.GetRechargeListByMemberId(startTime,endTime,member.Id).ToList();
            System.Web.HttpContext.Current.Session["RechargeList"] = rechargeList;

            return Json("True", JsonRequestBehavior.AllowGet);
        }

        public ActionResult RechargeList()
        {
            if (null == (System.Web.HttpContext.Current.Session["RechargeList"] as List<Recharge>))
            {
                return View();
            }
            else
            {
                ViewData["RechargeList"] = System.Web.HttpContext.Current.Session["RechargeList"] as List<Recharge>;
                return View();
            }
        }

        public ActionResult RechargeOptionsList()
        {
            return View();
        }
    }
}