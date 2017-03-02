using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Apache.NMS;
using Apache.NMS.ActiveMQ;
using Apache.NMS.ActiveMQ.Commands;
using XuLy;

namespace BTKhamBenh
{
    public partial class frmThongTin : Form
    {
        private ActiveMQTopic destination;
        private ISession session;

        clsBenhNhan objBenhNhan = new clsBenhNhan();
        clsKhamBenh objKhamBenh = new clsKhamBenh();
        public frmThongTin()
        {
            InitializeComponent();
            init();
        }

        private void init()
        {
            IConnectionFactory factory = new ConnectionFactory("tcp://localhost:61616");
            destination = new ActiveMQTopic("chat");
            IConnection con = factory.CreateConnection("admin", "admin");
            con.Start();
            session = con.CreateSession(AcknowledgementMode.AutoAcknowledge);
            IMessageConsumer consumer = session.CreateConsumer(destination);
        }


        void KTInput()
        {
            if (txtMa.Text == "" || txtMa.Text == null)
            {
                MessageBox.Show("Ma benh nhan khong duoc de trong!");
                txtMa.Focus();
                txtMa.SelectAll();
            }
            else
                if (txtCMND.Text == "" || txtCMND.Text == null)
                {
                    MessageBox.Show("so CMND khong duoc de trong!");
                    txtCMND.Focus();
                    txtCMND.SelectAll();
                }
                else
                    if (txtHoTen.Text == "" || txtHoTen.Text == null)
                    {
                        MessageBox.Show("ho ten khong duoc de trong!");
                        txtHoTen.Focus();
                        txtHoTen.SelectAll();
                    }
                    else
                        if (txtDiaChi.Text == "" || txtDiaChi.Text == null)
                        {
                            MessageBox.Show("Dia chi khong duoc de trong!");
                            txtDiaChi.Focus();
                            txtDiaChi.SelectAll();
                        }
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            
            //kiem tra gia tri nhap vao truoc khi add vao database
            KTInput();
            //add thong tin benh nhan vao database
            IEnumerable<benhnhan> lstSV;
            if (objBenhNhan.getBNBietMa(txtMa.Text) != null)
            {
                MessageBox.Show("Da gui thong tin benh nhan tai kham cho bac si");
                //send message
                IMessageProducer producer = session.CreateProducer(destination);
                ITextMessage mess = new ActiveMQTextMessage(txtMa.Text);
                producer.Send(mess);
            }
            else
                if (objBenhNhan.getBNBietCMND(txtCMND.Text) != null)
                {
                    MessageBox.Show("Da gui thong tin benh nhan tai kham cho bac si");
                    IMessageProducer producer = session.CreateProducer(destination);
                    ITextMessage mess = new ActiveMQTextMessage(txtMa.Text);
                    producer.Send(mess);
                }
                else
                {
                    benhnhan bn = new benhnhan();
                    bn.msbn = txtMa.Text;
                    bn.socmnd = txtCMND.Text;
                    bn.hoten = txtHoTen.Text;
                    bn.diachi = txtDiaChi.Text;
                    objBenhNhan.themBN(bn);

                    //
                    khambenh kb = new khambenh();
                    kb.msbn = txtMa.Text;

                    kb.msbacsy = "002";
                    objKhamBenh.themKB(kb);

                    //send message
                    IMessageProducer producer = session.CreateProducer(destination);
                    ITextMessage mess = new ActiveMQTextMessage(txtMa.Text);
                    producer.Send(mess);

                    MessageBox.Show("Da luu thong tin!");
                }

        }

        private void btnfindMa_Click(object sender, EventArgs e)
        {
            if(txtMa.Text=="" || txtMa.Text==null)
            {
                MessageBox.Show("Vui long nhap ma benh nhan can tim!");
                txtMa.Focus();
                txtMa.SelectAll();
            }
            else
            {
                string strMa = txtMa.Text.Trim();
                benhnhan bn = objBenhNhan.getBNTimTheoMa(txtMa.Text);
                if (bn != null)
                {
                    txtCMND.Text = bn.socmnd;
                    txtDiaChi.Text = bn.diachi;
                    txtHoTen.Text = bn.hoten;
                }
                else
                    MessageBox.Show("Tim khong thay!");
                

            }
        }

        private void btnfindCMND_Click(object sender, EventArgs e)
        {
            if (txtCMND.Text == "" || txtCMND.Text == null)
            {
                MessageBox.Show("Vui long nhap CMND benh nhan can tim!");
                txtCMND.Focus();
                txtCMND.SelectAll();
            }
            else
            {
                string strCMND = txtCMND.Text.Trim();
                benhnhan bn = objBenhNhan.getBNTimTheoCMND(txtCMND.Text);
                if (bn != null)
                {
                    txtMa.Text = bn.socmnd;
                    txtDiaChi.Text = bn.diachi;
                    txtHoTen.Text = bn.hoten;
                }
                else
                    MessageBox.Show("Tim khong thay!");
            }
        }



    }
}
