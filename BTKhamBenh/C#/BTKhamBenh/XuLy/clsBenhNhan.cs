using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace XuLy
{
    public class clsBenhNhan:clsKetNoi
    {
        QuanLyKhamBenhDataContext dt = new QuanLyKhamBenhDataContext();
        public clsBenhNhan()
        {
            dt = getKetNoi();
        }
        public benhnhan getBNBietMa(string strMaBN)
        {
            IEnumerable<benhnhan> s = from x in dt.benhnhans
                                      where x.msbn.Equals(strMaBN)
                                      select x;
            return s.FirstOrDefault();
        }

        public benhnhan getBNBietCMND(string strCMND)
        {
            IEnumerable<benhnhan> s = from x in dt.benhnhans
                                      where x.socmnd.Equals(strCMND)
                                      select x;
            return s.FirstOrDefault();
        }

         public void themBN(benhnhan bn)
        {
            System.Data.Common.DbTransaction my = dt.Connection.BeginTransaction();
            try
            {
                dt.Transaction = my;
                dt.benhnhans.InsertOnSubmit(bn);
                dt.SubmitChanges();
                dt.Transaction.Commit();
            }
            catch (Exception ex)
            {
                dt.Transaction.Rollback();
                throw new Exception("Loi them vao" + ex.Message);
            }
        }

         public benhnhan getBNTimTheoMa(string strMaBN)
         {
             IEnumerable<benhnhan> q = from x in dt.benhnhans
                                       where x.msbn.Equals(strMaBN)
                                       select x;
             return q.FirstOrDefault();
         }

         public benhnhan getBNTimTheoCMND(string strCMND)
         {
             IEnumerable<benhnhan> q = from x in dt.benhnhans
                                       where x.socmnd.Equals(strCMND)
                                       select x;
             return q.FirstOrDefault();
         }

    }
}
