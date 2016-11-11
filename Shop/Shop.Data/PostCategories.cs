using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

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
    }
}
