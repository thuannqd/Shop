using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace Shop.Common
{
    public static class PBObjectExtension
    {

        public static T ToObject<T>(this DataRow row) where T : new()
        {
            List<PropertyInfo> properties = typeof(T).GetProperties().ToList();
            List<PropertyInfo> lstPropertiesAdd = new List<PropertyInfo>();
            T result = new T();

            #region Lấy các thuộc tính có trong Object và trong table
            List<string> lstColumnName = new List<string>();
            foreach (DataColumn col in row.Table.Columns)
            {
                lstColumnName.Add(col.ColumnName.ToUpper());
            }

            foreach (PropertyInfo objPI in properties)
            {
                if (lstColumnName.Contains(objPI.Name.ToUpper()))
                    lstPropertiesAdd.Add(objPI);
            }
            #endregion

            var item = CreateItemFromRow<T>((DataRow)row, lstPropertiesAdd);

            return item;
        }


        public static List<T> ToList<T>(this DataTable table) where T : new()
        {
            if (table == null)
                return null;
            List<PropertyInfo> properties = typeof(T).GetProperties().ToList();
            List<PropertyInfo> lstPropertiesAdd = new List<PropertyInfo>();
            List<T> result = new List<T>();

            #region Lấy các thuộc tính có trong Object và trong table
            List<string> lstColumnName = new List<string>();
            foreach (DataColumn col in table.Columns)
            {
                lstColumnName.Add(col.ColumnName.ToUpper());
            }

            foreach (PropertyInfo objPI in properties)
            {
                if (lstColumnName.Contains(objPI.Name.ToUpper()))
                    lstPropertiesAdd.Add(objPI);
            }
            #endregion

            foreach (var row in table.Rows)
            {
                var item = CreateItemFromRow<T>((DataRow)row, lstPropertiesAdd);
                result.Add(item);
            }

            return result;
        }

        public static T ToObject<T>(this DataTable table) where T : new()
        {
            IList<PropertyInfo> properties = typeof(T).GetProperties().ToList();
            IList<PropertyInfo> lstPropertiesAdd = new List<PropertyInfo>();
            T result = new T();

            #region Lấy các thuộc tính có trong Object và trong table
            List<string> lstColumnName = new List<string>();
            foreach (DataColumn col in table.Columns)
            {
                lstColumnName.Add(col.ColumnName.ToUpper());
            }

            foreach (PropertyInfo objPI in properties)
            {
                if (lstColumnName.Contains(objPI.Name.ToUpper()))
                    lstPropertiesAdd.Add(objPI);
            }
            #endregion

            foreach (var row in table.Rows)
            {
                result = CreateItemFromRow<T>((DataRow)row, lstPropertiesAdd);
                break;
            }

            return result;
        }

        private static T CreateItemFromRow<T>(DataRow row, IList<PropertyInfo> properties) where T : new()
        {
            T item = new T();
            try
            {
                foreach (var property in properties)
                {
                    if (row[property.Name] != DBNull.Value)
                    {
                        property.SetValue(item, System.Convert.ChangeType(row[property.Name], property.PropertyType), null);
                    }
                }

            }
            catch (Exception ex)
            {
                //Thieu field trong view
            }
            return item;
        }

        public static IEnumerable<TSource> DistinctBy<TSource, TKey>
    (this IEnumerable<TSource> source, Func<TSource, TKey> keySelector)
        {
            HashSet<TKey> seenKeys = new HashSet<TKey>();
            foreach (TSource element in source)
            {
                if (seenKeys.Add(keySelector(element)))
                {
                    yield return element;
                }
            }
        }

    }
}
