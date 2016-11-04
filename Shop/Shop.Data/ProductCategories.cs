using Shop.Common;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WebLibs;

namespace Shop.Data
{
    public class ProductCategories
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
        public DateTime? UpdateDate { set; get; }
        public string UpdateBy { set; get; }
        public bool Status { set; get; }
        public bool HomeFlag { set; get; }
        #endregion

        #region contructor
        public ProductCategories()
        {
            this.Name = string.Empty;
            this.Alias = string.Empty;
            this.Description = string.Empty;
            this.ParentID = 0;
            this.DisplayOrder = 0;
            this.Image = string.Empty;
            this.MetaKeyword = string.Empty;
            this.MetaDesription = string.Empty;
            this.CreateDate = DateTime.Today;
            this.CreateBy = string.Empty;
            this.UpdateDate = DateTime.Today;
            this.UpdateBy = string.Empty;
            this.Status = false;
            this.HomeFlag = false;
        }
        #endregion

        #region function general
        public void Insert(ProductCategories obj)
        {
            IData objData = new IData();
            try
            {
                objData.Connect();
                objData.CreateNewStoredProcedure("ProductCategories_Insert");
                objData.AddParameter("@Name", obj.Name);
                objData.AddParameter("@Alias", obj.Alias);
                objData.AddParameter("@Description", obj.Description);
                objData.AddParameter("@ParentID", obj.ParentID);
                objData.AddParameter("@DisplayOrder", obj.DisplayOrder);
                objData.AddParameter("@Image", obj.Image);
                objData.AddParameter("@MetaKeyword", obj.MetaKeyword);
                objData.AddParameter("@MetaDesription", obj.MetaDesription);
                objData.AddParameter("@CreateDate", obj.CreateDate);
                objData.AddParameter("@CreateBy", obj.CreateBy);
                objData.AddParameter("@UpdateDate", obj.UpdateDate);
                objData.AddParameter("@UpdateBy", obj.UpdateBy);
                objData.AddParameter("@Status", obj.Status);
                objData.AddParameter("@HomeFlag", obj.HomeFlag);
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

        public void Update(ProductCategories obj)
        {
            IData objData = new IData();
            try
            {
                objData.Connect();
                objData.CreateNewStoredProcedure("ProductCategories_Update");
                objData.AddParameter("@ID", obj.ID);
                objData.AddParameter("@Name", obj.Name);
                objData.AddParameter("@Alias", obj.Alias);
                objData.AddParameter("@Description", obj.Description);
                objData.AddParameter("@ParentID", obj.ParentID);
                objData.AddParameter("@DisplayOrder", obj.DisplayOrder);
                objData.AddParameter("@Image", obj.Image);
                objData.AddParameter("@MetaKeyword", obj.MetaKeyword);
                objData.AddParameter("@MetaDesription", obj.MetaDesription);
                objData.AddParameter("@UpdateDate", obj.UpdateDate);
                objData.AddParameter("@UpdateBy", obj.UpdateBy);
                objData.AddParameter("@Status", obj.Status);
                objData.AddParameter("@HomeFlag", obj.HomeFlag);
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
                objData.CreateNewStoredProcedure("ProductCategories_Delete");
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

        public ProductCategories GetByID(int ID)
        {
            DataTable table = new DataTable();
            ProductCategories result = null;
            IData objData = new IData();
            try
            {
                objData.Connect();
                objData.CreateNewStoredProcedure("ProductCategories_GetByID");
                objData.AddParameter("@ID", this.ID);
                table = objData.ExecStoreToDataTable();
                if (table != null && table.Rows.Count > 0)
                {
                    result = PBObjectExtension.ToList<ProductCategories>(table)[0];
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

        public List<ProductCategories> GetAll()
        {
            DataTable table = new DataTable();
            List<ProductCategories> lst = null;
            IData objData = new IData();
            try
            {
                objData.Connect();
                objData.CreateNewStoredProcedure("ProductCategories_GetAll");
                table = objData.ExecStoreToDataTable();
                if (table != null && table.Rows.Count > 0)
                {
                    lst = PBObjectExtension.ToList<ProductCategories>(table);
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
