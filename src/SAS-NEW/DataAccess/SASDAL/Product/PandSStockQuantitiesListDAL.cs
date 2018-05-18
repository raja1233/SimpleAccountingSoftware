﻿using SASDAL;
using SDN.Products.DALInterface;
using SDN.UI.Entities;
using SDN.UI.Entities.Export;
using SDN.UI.Entities.ProductandServices;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SDN.Products.DAL
{
    public class PandSStockQuantitiesListDAL : IPandSStockQuantitiesListDAL
    {
        SASEntitiesEDM entities = new SASEntitiesEDM();

        public List<PandSStockQuantitiesListEntity> GetPandSList()
        {

            List<PandSStockQuantitiesListEntity> pandslist = entities.Database.SqlQuery<PandSStockQuantitiesListEntity>("PRC_PandSStockQuantitiesList").ToList();
            return pandslist;
        }
        public List<ProductandServiceStockQuantitiesListEntity> GetExportDataList(string FileName)
        {
            List<ProductandServiceStockQuantitiesListEntity> exportdata = new List<ProductandServiceStockQuantitiesListEntity>();
            try
            {
                exportdata = entities.Database.SqlQuery<ProductandServiceStockQuantitiesListEntity>("PRC_PandSStockQuantitiesList").ToList();
            }
            catch(Exception e)
            {
                throw e;
            }
            return exportdata;
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