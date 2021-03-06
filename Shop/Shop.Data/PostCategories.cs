﻿using Shop.Common;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WebLibs;

namespace Shop.Data
{
    public class PostCategories
    {
        #region init
        public int ID { set; get; }
        public string Name { set; get; }
        public string Alias { set; get; }
        public string Description { set; get; }
        public int ParentID { set; get; }
        public int DisplayOrder { set; get; }
        public string Image { set; get; }
        public string MetaKeyword { set; get; }
        public string MetaDesription { set; get; }
        public DateTime CreateDate { set; get; }
        public string CreateBy { set; get; }
        public DateTime UpdateDate { set; get; }
        public string UpdateBy { set; get; }
        public bool Status { set; get; }
        public bool HomeFlag { set; get; }
        #endregion

        #region contructor
        public PostCategories()
        {
            this.Name = string.Empty;
            this.Alias = string.Empty;
            this.Description = string.Empty;
            this.ParentID = 0;
            this.DisplayOrder= 0;
            this.Image = string.Empty;
            this.MetaKeyword = string.Empty;
            this.MetaDesription = string.Empty;
            this.CreateDate = DateTime.Now;
            this.CreateBy = string.Empty;
            this.UpdateDate = DateTime.Now;
            this.UpdateBy = string.Empty;
            this.Status = false;
            this.HomeFlag = false;
        }
        #endregion

        #region function general
        public void Insert()
        {
            IData objData = new IData();
            try
            {
                objData.Connect();
                objData.CreateNewStoredProcedure("PostCategories_Insert");
                objData.AddParameter("@Name", this.Name);
                objData.AddParameter("@Alias", this.Alias);
                objData.AddParameter("@Description", this.Description);
                objData.AddParameter("@ParentID", this.ParentID);
                objData.AddParameter("@DisplayOrder", this.DisplayOrder);
                objData.AddParameter("@Image", this.Image);
                objData.AddParameter("@MetaKeyword", this.MetaKeyword);
                objData.AddParameter("@MetaDesription", this.MetaDesription);
                objData.AddParameter("@CreateDate", this.CreateDate);
                objData.AddParameter("@CreateBy", this.CreateBy);
                objData.AddParameter("@UpdateDate", this.UpdateDate);
                objData.AddParameter("@UpdateBy", this.UpdateBy);
                objData.AddParameter("@Status", this.Status);
                objData.AddParameter("@HomeFlag", this.HomeFlag);
                objData.ExecNonQuery();
            }
            catch
            {
                throw;
            }
            finally
            {
                objData.DeConnect();
            }
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="obj"></param>
        public void Update()
        {
            IData objData = new IData();
            try
            {
                objData.Connect();
                objData.CreateNewStoredProcedure("PostCategories_Update");
                objData.AddParameter("@ID", this.ID);
                objData.AddParameter("@Name", this.Name);
                objData.AddParameter("@Alias", this.Alias);
                objData.AddParameter("@Description", this.Description);
                objData.AddParameter("@ParentID", this.ParentID);
                objData.AddParameter("@DisplayOrder", this.DisplayOrder);
                objData.AddParameter("@Image", this.Image);
                objData.AddParameter("@MetaKeyword", this.MetaKeyword);
                objData.AddParameter("@MetaDesription", this.MetaDesription);
                objData.AddParameter("@UpdateDate", this.UpdateDate);
                objData.AddParameter("@UpdateBy", this.UpdateBy);
                objData.AddParameter("@Status", this.Status);
                objData.AddParameter("@HomeFlag", this.HomeFlag);
                objData.ExecNonQuery();
            }
            catch
            {
                throw;
            }
            finally
            {
                objData.DeConnect();
            }
        }

        public void Delete(int ID)
        {
            IData objData = new IData();
            try
            {
                objData.Connect();
                objData.CreateNewStoredProcedure("PostCategories_Delete");
                objData.AddParameter("@ID", ID);
                objData.ExecNonQuery();
            }
            catch
            {
                throw;
            }
            finally
            {
                objData.DeConnect();
            }
        }

        public PostCategories GetByID(int ID)
        {
            DataTable table = new DataTable();
            PostCategories result = null;
            IData objData = new IData();
            try
            {
                objData.Connect();
                objData.CreateNewStoredProcedure("PostCategories_GetByID");
                objData.AddParameter("@ID", this.ID);
                table = objData.ExecStoreToDataTable();
                if (table != null && table.Rows.Count > 0)
                {
                    result = PBObjectExtension.ToList<PostCategories>(table)[0];
                    return result;
                }
                else
                    return null;
            }
            catch
            {
                throw;
            }
            finally
            {
                objData.DeConnect();
            }
        }

        public List<PostCategories> GetAll()
        {
            DataTable table = new DataTable();
            List<PostCategories> lst = null;
            IData objData = new IData();
            try
            {
                objData.Connect();
                objData.CreateNewStoredProcedure("PostCategories_GetAll");
                table = objData.ExecStoreToDataTable();
                if (table != null && table.Rows.Count > 0)
                {
                    lst = PBObjectExtension.ToList<PostCategories>(table);
                    return lst;
                }
                else
                    return null;
            }
            catch
            {
                throw;
            }
            finally
            {
                objData.DeConnect();
            }
        }
        #endregion
    }
}
