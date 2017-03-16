using Android.Content;
using Com.Tencent.MM.Opensdk.Openapi;
using Com.Tencent.MM.Opensdk.Modelpay;
namespace XamarinWeiXinDemo
{
    public class PayUtil
    {
        /// <summary>
        /// ����֧��
        /// </summary>
        /// <param name="context"></param>
        /// <param name="AppId">΢�ſ���ƽ̨���ͨ����Ӧ��APPID</param>
        /// <param name="partnerId">΢��֧��������̻���</param>
        /// <param name="prepayId">���ýӿ��ύ���ն��豸��</param>
        /// <param name="nonceStr">����ַ�����������32λ</param>
        /// <param name="timeStamp">ʱ���</param>
        /// <param name="sign">ǩ��</param>
        /// <returns></returns>
        public bool Pay(Context context,string AppId,string partnerId,string prepayId,string nonceStr,string timeStamp,string sign)
        {
            var api = WXAPIFactory.CreateWXAPI(context, AppId);
            api.RegisterApp("APP_ID");

            PayReq payRequest = new PayReq();

            payRequest.AppId = AppId;

            payRequest.PartnerId = partnerId;

            payRequest.PrepayId = prepayId;

            payRequest.PackageValue = "Sign=WXPay";

            payRequest.NonceStr = nonceStr;

            payRequest.TimeStamp = timeStamp;

            payRequest.Sign = sign;

            return api.SendReq(payRequest);

        }
    }
}