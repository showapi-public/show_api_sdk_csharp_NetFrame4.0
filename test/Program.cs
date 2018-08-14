using System;
using System.Collections.Generic;
using System.Text;
using com.show.api;

namespace test
{
    class Program
    {
        static void Main(string[] args)
        {
            //String res = new ShowApiRequest("http://route.showapi.com/20-1", "3", "006513e01bd344fca03610d1fd0145f0")
            //.addTextPara("ip", "8.8.4.4")
            //.addHeadPara("head1", "123123")
            //.addHeadPara("head2", "456哈哈")
            //.post();


            String res = new ShowApiRequest("http://route.showapi.com/1-1", "3", "006513e01bd344fca03610d1fd0145f0")
            .addFilePara("src_img", "c:/1.jpg")
            .addTextPara("type", "rate")
            .addTextPara("rate", "0.5")
            .addHeadPara("head1", "c# test 啊")
            .addHeadPara("head2", "c# test as")
            .post();

            Console.WriteLine("--------------------响应包 BEGIN--------------------");
            Console.WriteLine(res);
            Console.WriteLine("--------------------响应包 END  --------------------");
            Console.WriteLine("任意键结束");

            Console.Read();
        }
    }
}
