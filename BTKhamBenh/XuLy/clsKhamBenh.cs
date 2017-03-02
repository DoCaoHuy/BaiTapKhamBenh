using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace XuLy
{
    public class clsKhamBenh:clsKetNoi
    {
         QuanLyKhamBenhDataContext dt = new QuanLyKhamBenhDataContext();
        public clsKhamBenh()
        {
            dt = getKetNoi();
        }


        public void themKB(khambenh kb)
        {
            System.Data.Common.DbTransaction my = dt.Connection.BeginTransaction();
            try
            {
                dt.Transaction = my;
                dt.khambenhs.InsertOnSubmit(kb);
                dt.SubmitChanges();
                dt.Transaction.Commit();
            }
            catch (Exception ex)
            {
                dt.Transaction.Rollback();
                throw new Exception("Loi them vao" + ex.Message);
            }
        }
    }
}
