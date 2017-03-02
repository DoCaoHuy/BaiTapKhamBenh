package BenhVien;

import java.awt.*;
import java.awt.event.ActionEvent;
import java.awt.event.ActionListener;
import java.util.Properties;

import javax.jms.Connection;
import javax.jms.ConnectionFactory;
import javax.jms.Destination;
import javax.jms.JMSException;
import javax.jms.Message;
import javax.jms.MessageConsumer;
import javax.jms.MessageListener;
import javax.jms.Session;
import javax.jms.TextMessage;

import javax.naming.Context;
import javax.naming.InitialContext;
import javax.swing.*;
import javax.swing.border.TitledBorder;
import org.apache.log4j.BasicConfigurator;



//import java.sql.Connection;
import java.sql.DriverManager;
import java.sql.PreparedStatement;
import java.sql.ResultSet;
import java.sql.SQLException;
import java.sql.Statement;


public class RecieveInfo extends JFrame implements ActionListener {
	private DefaultListModel<String> lstmodel;
	private JList<String> lstDS;
	private Destination destination;
	private Session session;
	private JTextField txtRec;
	private JButton btnGoiKham;
	private JTextField txtMa;
	private JTextField txtCMND;
	private JTextField txtHo;
	private JTextArea txtAr;
	private JTextArea txtArND;
	private JButton btnCapNhat;

	public RecieveInfo() throws Exception{
		ketnoi();
		init();
		
		setSize(650,500);
		setTitle("BAC SY KHAM BENH");
		setDefaultCloseOperation(EXIT_ON_CLOSE);
		setResizable(false);
		setLocationRelativeTo(null);
		
		JPanel plist=new JPanel();
		JPanel pgoiKham=new JPanel(new GridLayout(0, 1));
		plist.setLayout(new BoxLayout(plist, BoxLayout.Y_AXIS));
//		plist.setLayout(new GridLayout(2, 1));
		plist.setBorder(new TitledBorder(BorderFactory.createLineBorder(Color.GREEN),"Danh sách benh nhan cho kham:"));;
		lstmodel=new DefaultListModel<String>();
		lstDS=new JList<String>(lstmodel);
		lstDS.setVisibleRowCount(30);
		plist.add(new JScrollPane(lstDS));
		pgoiKham.add(btnGoiKham=new JButton("goi kham"));
		plist.add(pgoiKham);
		add(plist,BorderLayout.WEST);
		btnGoiKham.addActionListener(this);
		
		lstmodel.addElement("20130918_035");
		lstmodel.addElement("20130918_036");
		lstmodel.addElement("20130918_037");
		
		JPanel pTTBenh=new JPanel();
		pTTBenh.setLayout(new BoxLayout(pTTBenh, BoxLayout.Y_AXIS));
		pTTBenh.setBorder(new TitledBorder(BorderFactory.createLineBorder(Color.GREEN),"Thong tin benh nhan duoc chon:"));
		
		JPanel pTT=new JPanel(new GridLayout(2, 1));
		JPanel pMSH=new JPanel();
		pMSH.setLayout(new BoxLayout(pMSH, BoxLayout.Y_AXIS));
		
		JPanel pMa=new JPanel();
		pMa.add(new JLabel("Ma so benh nhan:"));
		pMa.add(txtMa=new JTextField(20));
		txtMa.setEditable(false);
		JPanel pCMND=new JPanel();
		pCMND.add(new JLabel("              So CMND:"));
		pCMND.add(txtCMND=new JTextField(20));
		txtCMND.setEditable(false);
		JPanel pHo=new JPanel();
		pHo.add(new JLabel("                   Ho ten:"));
		pHo.add(txtHo=new JTextField(20));
		txtHo.setEditable(false);
		
		pMSH.add(pMa);
		pMSH.add(pCMND);
		pMSH.add(pHo);
		
		JPanel pDC=new JPanel();
		pDC.add(new JLabel("                 Dia chi:"));
		pDC.add(txtAr=new JTextArea(5,20));
		
		pTT.add(pMSH);
		pTT.add(pDC);
		pTTBenh.add(pTT);
		
		JPanel pND=new JPanel(new GridLayout(1, 1));
		pND.setBorder(new TitledBorder(BorderFactory.createLineBorder(Color.GREEN),"Noi dung kham:"));;
		pND.add(txtArND=new JTextArea());
		
		pTTBenh.add(pND);
		
		pTTBenh.add(btnCapNhat=new JButton("Cap nhat thong tin kham benh"));
		add(pTTBenh,BorderLayout.CENTER);
		
		
	}
	
	public void init() throws Exception {
		BasicConfigurator.configure();
		Properties setting = new Properties();
		setting.setProperty(javax.naming.Context.INITIAL_CONTEXT_FACTORY,
				"org.apache.activemq.jndi.ActiveMQInitialContextFactory");
		setting.setProperty(javax.naming.Context.PROVIDER_URL, "tcp://localhost:61616");
		Context context = new InitialContext(setting);
		ConnectionFactory factory =  (ConnectionFactory) context.lookup("TopicConnectionFactory");
		destination = (Destination) context.lookup("dynamicTopics/chat");
		Connection con = factory.createConnection("huy","123");
		con.start();
		session = con.createSession(false, Session.AUTO_ACKNOWLEDGE);
		//MessageProducer producer = session.createProducer(destination);
		MessageConsumer consumer = session.createConsumer(destination);
		consumer.setMessageListener(new MessageListener() {
			
			@Override
			public void onMessage(Message mess) {
				if(mess instanceof TextMessage){
					try {
						String text = ((TextMessage)mess).getText();
//						area.append(text + "\n");
						lstmodel.addElement(text);
					} catch (JMSException e) {
						// TODO Auto-generated catch block
						e.printStackTrace();
					}
				}
			}
		});	
	}
	
	
	
	void ketnoi(){
		String jdbcurl;
		java.sql.Connection con=null;
		try{
			Class.forName("com.microsoft.sqlserver.jdbc.SQLServerDriver");
			
		}catch (ClassNotFoundException e){
			e.printStackTrace();
		}
//		
//		jdbcurl="jdbc:sqlserver://"+Server+":"+port+";user="+user+";password="
//				+pass+";databasename="+database+"";
		
		jdbcurl="jdbc:sqlserver://DESKTOP-LP0F0PV:1433;user=sa;password=DoCaoHuy;databasename=QLBenhNhan";
		try{
			con= DriverManager.getConnection(jdbcurl);
			
		}catch(SQLException e){
			e.printStackTrace();
		}
		
		try{
			PreparedStatement pst=((java.sql.Connection) con).prepareStatement("select * from BenhNhan where hoten='Do Cao Huy'");
			ResultSet rs=pst.executeQuery();
			while(rs.next()){
//				System.out.println(rs.getString("hoten"));
				JOptionPane.showConfirmDialog(this, ""+rs.getString("hoten"));
				
			}
		} catch(SQLException ex){
			ex.printStackTrace();
		}
		
		
	}
	
	public static void main(String[] args) throws Exception {
		new RecieveInfo().setVisible(true);
	}

	@Override
	public void actionPerformed(ActionEvent e) {
		Object obj=e.getSource();
		if(obj.equals(btnGoiKham))
		{
//			JOptionPane.showConfirmDialog(this, ""+lstDS.getSelectedValue());
//			ketnoi();
		}
	}
	
}
