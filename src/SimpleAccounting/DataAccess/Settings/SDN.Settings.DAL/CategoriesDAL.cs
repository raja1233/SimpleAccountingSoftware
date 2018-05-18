
namespace SDN.Settings.DAL
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using SDN.Settings.DALInterface;
    using SDN.SettingsEDM;
    using SDN.UI.Entities;

    public class CategoriesDAL : ICategoriesDAL
    {
        public List<CategoryModel> GetCategory(string CategoryCode)
        {
            using (SDNSettingEntities objCategoryEntities = new SDNSettingEntities())
            {
                var result = objCategoryEntities.Categories.Where(e => e.Cat_Code == CategoryCode).ToList();
                List<UI.Entities.CategoryModel> catModel = (from r in result
                                                            select new UI.Entities.CategoryModel
                                                            {
                                                                ID = r.ID,
                                                                CategoryName = r.Cat_Name,
                                                                CategoryCode = r.Cat_Code

                                                            }).ToList<UI.Entities.CategoryModel>();
                return catModel;
            }
        }


        /// <summary>
        /// This is used to get all categories
        /// </summary>
        public List<UI.Entities.CategoryModel> GetCategoryList()
        {
            using (SDNSettingEntities objCategoryEntities = new SDNSettingEntities())
            {
                var result = objCategoryEntities.Categories.ToList();
                List<UI.Entities.CategoryModel> catModel = (from r in result
                                                            select new UI.Entities.CategoryModel
                                                            {
                                                                ID=r.ID,
                                                                CategoryName=r.Cat_Name

                                                            }).ToList<UI.Entities.CategoryModel>();
                return catModel;
            }
        }

        public List<ContentModel> GetPSCategoryList()
        {
            using (SDNSettingEntities objCategoryEntities = new SDNSettingEntities())
            {
                var result = objCategoryEntities.TermsAndConditions.ToList();
                List<ContentModel> catModel = (from r in result
                                                            select new ContentModel
                                                            {
                                                                CategoryID = r.ID,
                                                                CategoryName = r.Cat_Name,
                                                                CategoryCode=r.Cat_Code,
                                                                ContentName=r.Cat_Content
                                                                
                                                            }).ToList<ContentModel>();
                return catModel;
            }
        }
    }

    public class CategoryContentsDAL : ICategoryContentDAL
    {
        /// <summary>
        /// This method is used to get category contents of selected category
        /// </summary>
        /// <param name="catID"></param>
        /// <returns></returns>
       public  List<ContentModel> GetCategoryContentList(int catID)
        {
            using (SDNSettingEntities objCategoryEntities = new SDNSettingEntities())
            {
                var result = (from catContent in objCategoryEntities.CategoriesContents
                              join cat in objCategoryEntities.Categories
                              on catContent.Cat_Id equals cat.ID
                              where catContent.Cat_Id == catID && catContent.IsDeleted==false
                              select new ContentModel
                              {
                                  ContentID = catContent.ID,
                                  ContentName=catContent.Cat_Contents,
                                  CategoryID= cat.ID,
                                  ContentType = cat.Content_Type,
                                  CategoryName=cat.Cat_Name,
                                  CategoryCode=cat.Cat_Code,
                                  IsSelected=catContent.Set_Default,
                                  Predefined = catContent.Predefined
                                 
                              }).ToList();
                
                return result;
            }
        }
        public string GetNumberFormat()
        {
            string numberFormat = string.Empty;
            using (SDNSettingEntities objCategoryEntities = new SDNSettingEntities())
            {
              var format = objCategoryEntities.Options.FirstOrDefault();
                if (format != null)
                {
                    numberFormat = format.Number_Format;
                }
                

                if(numberFormat!=string.Empty)
                {
                    return numberFormat;
                }
                else
                {
                    return string.Empty;
                }
              
            }
        }

        public string GetPSCategoryContentList(string tcCode)
        {
            string content = string.Empty;
            using (SDNSettingEntities objCategoryEntities = new SDNSettingEntities())
            {
                var result = (from tandc in objCategoryEntities.TermsAndConditions
                              where tandc.Cat_Code == tcCode
                              select tandc.Cat_Content).SingleOrDefault();

                if (result != null)
                {
                    content = result;
                }
                return content;
            }
        }
    }

    public class ContentOperationDAL : IContentOperationDAL
    {
        /// <summary>
        /// This method is used to delete Category Content
        /// </summary>
        /// <param name="catId"></param>
        public void DeleteCategoryContent(int contentID)
        {
            using (SDNSettingEntities objCategoryEntities = new SDNSettingEntities())
            {
                try
                {
                    CategoriesContent catContent = objCategoryEntities.CategoriesContents.SingleOrDefault(i => i.ID ==  contentID);
                    if (catContent != null)
                    {
                        catContent.IsDeleted = true;
                        
                        objCategoryEntities.SaveChanges();
                    }
                }
                catch (Exception ex)
                {
                    throw ex;
                }

            }
        }

        /// <summary>
        /// This method is used get category details from Category
        /// </summary>
        /// <param name="ID"></param>
        /// <returns></returns>
        public List<ContentModel> GetCategoryDetails(int ID)
        {
            using (SDNSettingEntities objCategoryEntities = new SDNSettingEntities())
            {
                try
                {
                    var result = (from cat in objCategoryEntities.Categories
                               
                                  where cat.ID == ID
                                  select new ContentModel
                                  {
                                      CategoryID = cat.ID,
                                      CategoryCode = cat.Cat_Code,
                                      CategoryName = cat.Cat_Name,
                                      ContentType=cat.Content_Type,
                                     
                                     
                                  }).ToList();
                    return result;
                }
                catch (Exception ex)
                {
                    throw ex;
                }

            }
        }

        public bool IsContentExists(ContentModel content)
        {
            bool IsExists = false;
            using (SDNSettingEntities objCategoryEntities = new SDNSettingEntities())
            {
                try
                {
                    var catContent = objCategoryEntities.CategoriesContents.Where(e => e.Cat_Id == content.CategoryID
                    && e.Cat_Contents==content.ContentName.Trim() && e.IsDeleted==false && e.ID!=content.ContentID).ToList();
                    if(catContent.Count>0)
                    {
                        IsExists = true;
                    }
                    else
                    {
                        IsExists = false;
                    }

                }
                catch (Exception ex)
                {
                    throw ex;
                }
                return IsExists;
            }
        }

        /// <summary>
        /// This method is used to delete Purchase and sales Category Content
        /// </summary>
        /// <param name="content"></param>
        public void DeletePSCategoryContent(ContentModel content)
        {
            using (SDNSettingEntities objCategoryEntities = new SDNSettingEntities())
            {
                try
                {
                    var tandc = objCategoryEntities.TermsAndConditions.Where(e => e.Cat_Code == content.CategoryCode).SingleOrDefault();
                    if (tandc != null)
                    {
                        tandc.Cat_Content = string.Empty;
                        objCategoryEntities.SaveChanges();
                    }
                }
                catch (Exception ex)
                {
                    throw ex;
                }
            }

        }

        /// <summary>
        /// This method is used to save Purchase and sales Category Content
        /// </summary>
        /// <param name="content"></param>
       public void SavePSCategoryContent(ContentModel content)
        {
            using (SDNSettingEntities objCategoryEntities = new SDNSettingEntities())
            {
                try
                {
                    var tandc = objCategoryEntities.TermsAndConditions.Where(e => e.Cat_Code == content.CategoryCode).SingleOrDefault();
                    if (tandc != null)
                    {
                        tandc.Cat_Content = content.ContentName;
                        objCategoryEntities.SaveChanges();
                    }

                }
                catch (Exception ex)
                {
                    throw ex;
                }
            }
        }

        /// <summary>
        /// This method is used to save category contents with associated category
        /// </summary>
        /// <param name="content"></param>
        public void SaveCategoryContent(ContentModel content)
        {
            using (SDNSettingEntities objCategoryEntities = new SDNSettingEntities())
            {
                var obj = objCategoryEntities.CategoriesContents.Where(x =>x.Cat_Id == content.CategoryID && x.IsDeleted!=true && x.Set_Default==true && content.IsSelected == true).FirstOrDefault();
                if (obj!=null)
                {
                                        
                    obj.Set_Default = false;
                    objCategoryEntities.SaveChanges();
                }
                
                try
                {
                    CategoriesContent catContent = new CategoriesContent();
                    catContent.Cat_Contents = content.ContentName.Trim() ;
                    catContent.Content_Limit = content.Limit;
                    catContent.Cat_Id = content.CategoryID;
                    catContent.IsDeleted = false;
                    catContent.Set_Default = content.IsSelected;
                    catContent.CreatedDate = DateTime.Now;
                    objCategoryEntities.CategoriesContents.Add(catContent);
                    objCategoryEntities.SaveChanges();

                }
                catch (Exception ex)
                {
                    throw ex;
                }
            }
        }

        /// <summary>
        /// This method is used to save Tax Name
        /// </summary>
        /// <param name="taxName"></param>
        public void SaveTaxName(string taxName)
        {
            using (SDNSettingEntities objCategoryEntities = new SDNSettingEntities())
            {
                try
                {
                    var taxes = objCategoryEntities.TaxCodesAndRates.ToList();
                    if(taxes.Count>0)
                    {
                      foreach(var tax in taxes)
                        {
                            tax.Tax_Name = taxName;
                            objCategoryEntities.SaveChanges();
                        }
                    }
                }
                catch (Exception ex)
                {
                    throw ex;
                }
            }
        }



        /// <summary>
        /// This method is used to update category contents with associated category
        /// </summary>
        /// <param name="content"></param>
        public void UpdateCategoryContent(ContentModel content)
        {
            using (SDNSettingEntities objCategoryEntities = new SDNSettingEntities())
            {
                try
                {
                    var obj = objCategoryEntities.CategoriesContents.Where(x => x.Cat_Id == content.CategoryID && x.IsDeleted != true && x.Set_Default == true && content.IsSelected == true).FirstOrDefault();
                    if (obj != null)
                    {
                        obj.Set_Default = false;
                        objCategoryEntities.SaveChanges();
                    }

                    CategoriesContent catContent = objCategoryEntities.CategoriesContents.SingleOrDefault(i => i.ID == content.ContentID);
                    if (catContent != null)
                    {
                        catContent.Cat_Contents = content.ContentName;
                        catContent.Content_Limit = content.Limit;
                        catContent.Set_Default = content.IsSelected;
                        catContent.ModifiedDate = DateTime.Now;
                        objCategoryEntities.SaveChanges();
                    }

                    //var categoryContent = objCategoryEntities.CategoriesContents.Where(e => e.Cat_Id == content.CategoryID && e.ID!=content.ContentID).ToList();
                    //if (categoryContent != null)
                    //{
                    //    foreach (var c in categoryContent)
                    //    {
                    //        if (content.IsSelected == true)
                    //        {
                    //            if (c.Set_Default == true)
                    //            {
                    //                c.Set_Default = false;
                    //            }
                    //        }
                    //        else
                    //        {
                    //            if(c.Set_Default==true)
                    //            {
                    //                c.Set_Default = true;
                    //            }   
                    //        }
                    //        objCategoryEntities.SaveChanges();
                    //    }
                    //}

                }
                catch (Exception ex)
                {
                    throw ex;
                }

            }
        }
    }
}
