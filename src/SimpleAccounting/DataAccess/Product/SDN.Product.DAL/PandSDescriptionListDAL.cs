﻿using SDN.ProductEDM;
using SDN.Products.DALInterface;
using SDN.UI.Entities;
using SDN.UI.Entities.ProductandServices;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SDN.Products.DAL
{
    public class PandSDescriptionListDAL : IPandSDescriptionListDAL
    {
        SDNProductDBEntities entities = new SDNProductDBEntities();

        public List<PandSDescriptionListEntity> GetPandSList()
        {

            List<PandSDescriptionListEntity> pandslist = entities.Database.SqlQuery<PandSDescriptionListEntity>("PRC_PandSDescriptionList").ToList();
            return pandslist;
        }

        //public List<ContentModel> GetAllSalesman(string catType)
        //{
        //    List<ContentModel> lstsalesman = new List<ContentModel>();

        //    try
        //    {
        //        lstsalesman = (from content in objProdEntities.Categories
        //                       join catContent in objProdEntities.CategoriesContents
        //                       on content.ID equals catContent.Cat_Id
        //                       where content.Cat_Code == catType && catContent.IsDeleted == false
        //                       select new ContentModel
        //                       {
        //                           ContentName = catContent.Cat_Contents,
        //                           ContentID = catContent.ID
        //                       }).ToList<ContentModel>();

        //        return lstsalesman;
        //    }
        //    catch (Exception ex)
        //    {
        //        throw ex;
        //    }
        //}
    }
}