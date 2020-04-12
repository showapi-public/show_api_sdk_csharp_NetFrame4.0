using System;
using System.Collections.Generic;
using System.Text;
using com.showapi;
using System.IO;

namespace showapi
{
     class Demo
    {
     	public static void get_demo(){
     		
     	}
     	
     	public static String post_base64_demo(){
     		 String res = new ShowApiRequest("http://route.showapi.com/20-1", "3", "006513e01bd344fca03610d1fd0145f0")
            .addTextPara("ip", "8.8.4.4")
     		.addBase64Para("base64str", System.Text.Encoding.UTF8.GetBytes("aij adsfljsda f"))
            .post();
     		 
     		 return res;
     	}
     	public static String post_file_demo(){
     		 String res = new ShowApiRequest("http://route.showapi.com/1-1", "3", "006513e01bd344fca03610d1fd0145f0")
     		.addFilePara("src_img", "c:/1.txt")
            .addTextPara("type", "rate")
            .addTextPara("rate", "0.5")
            .post();
     		 
     		 return res;
     	}
        static void   Main(string[] args)
        {
        	String res=Demo.post_file_demo();
        	

			


            Console.WriteLine("--------------------响应包 BEGIN--------------------");
            Console.WriteLine(res);
            Console.WriteLine("--------------------响应包 END  --------------------");
            Console.WriteLine("任意键结束");

            Console.Read();
        }
    }
}
