using System;
using Android.App;
using Android.Content;
using Android.OS;
using Com.Tencent.MM.Opensdk.Modelbase;
using Com.Tencent.MM.Opensdk.Openapi;
using Android.Util;
using Android.Widget;
using Com.Tencent.MM.Opensdk.Constants;

namespace XamarinWeiXinDemo
{
    /// <summary>
    /// ΢��֧���ص�Activity
    /// </summary>
    public class WXPayEntryActivity : Activity, IWXAPIEventHandler
    {

        private IWXAPI api;

        public void onCreate(Bundle savedInstanceState)
        {
            base.OnCreate(savedInstanceState);
            //SetContentView(R.layout.pay_result);
            //�����ǿ����Զ���
            api = WXAPIFactory.CreateWXAPI(this, "App_ID");
            api.HandleIntent(Intent, this);
        }

        protected override void OnNewIntent(Intent intent)
        {
            base.OnNewIntent(intent);
            Intent = intent;
            api.HandleIntent(intent, this);
        }

        public void OnReq(BaseReq p0)
        {

        }

        public void OnResp(BaseResp p0)
        {
            Log.Debug("΢��֧���ص�", "onPayFinish, errCode = " + p0.errCode);
            
            if (p0.Type == ConstantsAPI.CommandPayByWx)
            {
                //0   �ɹ� չʾ�ɹ�ҳ��
                //-1  ���� ���ܵ�ԭ��ǩ������δע��APPID����Ŀ����APPID����ȷ��ע���APPID�����õĲ�ƥ�䡢�����쳣�ȡ�
                //-2  �û�ȡ�� ���账�������������û���֧���ˣ����ȡ��������APP��
                if (p0.errCode == 0)
                {
                    //֧���ɹ��߼�
                    Toast.MakeText(this, "֧���ɹ�", ToastLength.Long).Show();
                }
                else
                {
                    //֧��ʧ��
                    Toast.MakeText(this, "֧��ʧ��", ToastLength.Long).Show();
                }
                Finish();
            }

        }


    }



}