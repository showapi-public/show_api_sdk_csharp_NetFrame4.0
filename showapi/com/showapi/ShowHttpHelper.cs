using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Collections;
using com.showapi.uti;

namespace com.showapi
{
    class ShowHttpHelper
    {
    
	
	public static String  post(ShowApiRequest req){
		return _send(req,"post");
	}
	
	public static String  get(ShowApiRequest req){
		return _send(req,"get");
	}
	public static String  _send(ShowApiRequest req,String type){
		
        String rsp = "";
        Hashtable textMap = req.getTextMap();

        if(textMap[Constants.SHOWAPI_APPID]==null)
			return ShowApiUtils.errorMsg(Constants.SHOWAPI_APPID+"不得为空!");

        if(textMap[Constants.SHOWAPI_SIGN]==null)
			return ShowApiUtils.errorMsg(Constants.SHOWAPI_SIGN+"不能为空!");

        String timestamp = DateTime.Now.ToString(Constants.DATE_TIME_FORMAT);
		textMap.Add(Constants.SHOWAPI_TIMESTAMP,timestamp);
		
		String signMethod=textMap[Constants.SHOWAPI_SIGN_METHOD].ToString();
		try {
			
            if (req.getUrl().Substring(0,5).Equals("https"))
                return ShowApiUtils.errorMsg("暂未实现https");            
			
			if(type.ToLower().Equals("post")){
                rsp = WebUtils.doPost(req.getUrl(), req.getTextMap(), req.getUploadMap(),
                        req.getHeadMap(), req.getConnectTimeout(), req.getReadTimeout());
			}else{
				rsp= WebUtils.doGet(req.getUrl(), req.getTextMap() , req.getConnectTimeout(), req.getReadTimeout()  );
			}
		} catch (Exception e) {
            throw e;
		}
		
		return rsp;
	}

	
	
    }
}
