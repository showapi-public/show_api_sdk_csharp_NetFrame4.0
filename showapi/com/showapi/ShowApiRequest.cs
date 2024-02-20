using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Collections;
using com.showapi.uti;
using System.IO;
 
namespace com.showapi
{
    public class ShowApiRequest
    {
        private int connectTimeout = 60000;//60秒
        private int readTimeout = 60000;//60秒
        private String url;



        private Hashtable textMap = new Hashtable();
        private Hashtable uploadMap = new Hashtable();
        private Hashtable headMap = new Hashtable();


        public ShowApiRequest(String url, String appid, String appSecret)
        {
            this.url = url;
            this.textMap.Add("showapi_appid", appid);
            this.textMap.Add("showapi_sign", appSecret);
        }


        public Hashtable getTextMap()
        {
            return textMap;
        }

        public void setTextMap(Hashtable textMap)
        {
            this.textMap = textMap;
        }
        public String getUrl()
        {
            return url;
        }

        public Hashtable getUploadMap()
        {
            return uploadMap;
        }
        public void setUploadMap(Hashtable uploadMap)
        {
            this.uploadMap = uploadMap;
        }
        public Hashtable getHeadMap()
        {
            return headMap;
        }
        public void setHeadMap(Hashtable headMap)
        {
            this.headMap = headMap;
        }
        public int getConnectTimeout()
        {
            return connectTimeout;
        }
        public int getReadTimeout()
        {
            return readTimeout;
        }
        public ShowApiRequest setConnectTimeout(int connectTimeout)
        {
            this.connectTimeout = connectTimeout;
            return this;
        }
        public ShowApiRequest setReadTimeout(int readTimeout)
        {
            this.readTimeout = readTimeout;
            return this;
        }

        /**
         * 设置客户端与showapi网关的最大长连接数量。
         */
        public ShowApiRequest setUrl(String url)
        {
            this.url = url;
            return this;
        }


        /**
         * 添加post体的字符串参数
         */
        public ShowApiRequest addTextPara(String key, String value)
        {
            this.textMap.Add(key, value);
            return this;
        }
        
         /**
         * 添加base64字符串参数
         */
        public ShowApiRequest addBase64Para(String key,String original)
        {
        	byte[] b =System.Text.Encoding.UTF8.GetBytes(original);
        	String newstr= Convert.ToBase64String(b);  
            this.textMap.Add(key, newstr);
            return this;
        }
         /**
         * 添加base64的文件参数
         */
        public ShowApiRequest addBase64Para(String key,FileStream fs)
        {
        	var array = new byte[fs.Length];//初始化字节数组
			fs.Read(array, 0, array.Length);//读取流中数据到字节数组中
			fs.Close();//关闭流
			String base64string=Convert.ToBase64String(array);
			Console.Write("\r\n"+base64string);
            this.textMap.Add(key, base64string);
            return this;
        }
        
        
          /**
         * 添加base64的byte array 参数
         */
        public ShowApiRequest addBase64Para(String key,byte[] array)
        {
			String base64string=Convert.ToBase64String(array);
			Console.Write("\r\n"+base64string);
            this.textMap.Add(key, base64string);
            return this;
        }

        /**
         * 添加post体的上传文件参数
         */
        public ShowApiRequest addFilePara(String key, String item)
        {
            this.uploadMap.Add(key, item);
            return this;
        }
        /**
         * 添加head头的字符串参数
         */
        public ShowApiRequest addHeadPara(String key, String value)
        {
            this.headMap.Add(key, value);
            return this;
        }

        public String post()
        {
            String res = "";
            try
            {
                res = ShowHttpHelper.post(this);
            }
            catch (Exception e)
            {
                res = ShowApiUtils.errorMsg(e.ToString());
            }
            return res;
        }

        public String get()
        {
            String res = "";
            try
            {
                res = ShowHttpHelper.get(this);
            }
            catch (Exception e)
            {
                res = ShowApiUtils.errorMsg(e.ToString());                
            }
            return res;
        }
    }
}
