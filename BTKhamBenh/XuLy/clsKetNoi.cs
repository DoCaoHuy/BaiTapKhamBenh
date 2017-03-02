using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace XuLy
{
    public class clsKetNoi
    {
        QuanLyKhamBenhDataContext dt;
        protected QuanLyKhamBenhDataContext getKetNoi()
        {
            string strconnection = @"Data Source=DESKTOP-LP0F0PV;Initial Catalog=QLBenhNhan;User ID=sa;Password=DoCaoHuy";
            dt = new QuanLyKhamBenhDataContext(strconnection);
            dt.Connection.Open();
            return dt;
        }
    }
}
