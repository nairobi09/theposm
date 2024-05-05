using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Xml;
using static thepos.thePos;

namespace thepos
{
    internal class couponPM
    {
        String PLACEM_URL = "https://gateway.sparo.cc/extra/kiosk/v1/";
        String PLACEM_CH = "3590";

        String rcode = "";
        String rmsg = "";



        public int requestPmCertAuth(String tCouponNo)
        {
            String sUrl = PLACEM_URL + "req.php?pc=US&pval=" + tCouponNo + "&ch=" + PLACEM_CH + "&fcno=POS_" + mPosNo;

            try
            {
                var response = mHttpClient.GetAsync(sUrl).Result;

                var responseContent = response.Content;
                string responseString = responseContent.ReadAsStringAsync().Result;

                XmlDocument xdoc = new XmlDocument();
                xdoc.LoadXml(responseString);


                XmlNodeList nodes = xdoc.SelectNodes("/RESULT");
                foreach (XmlNode res in nodes)
                {
                    rcode = res.SelectSingleNode("RCODE").InnerText;
                    rmsg = res.SelectSingleNode("RMSG").InnerText;
                }


                if (rcode == "S")  // 성공
                {
                    return 0;
                }
                else
                {
                    MessageBox.Show("쿠폰사용요청 실패응답. \r\n\r\n" + rmsg, "thepos");
                    return -1;

                }

            }
            catch (Exception ex)
            {
                MessageBox.Show("아래 메시지를 관리자에게 전달바랍니다. \r\n\r\n" + ex.Message, "시스템오류");
                return -1;
            }

        }

        public int requestPmCertCancel(String tCouponNo)
        {
            String sUrl = PLACEM_URL + "req.php?pc=RC&pval=" + tCouponNo + "&ch=" + PLACEM_CH + "&fcno=POS_" + mPosNo;

            try
            {
                var response = mHttpClient.GetAsync(sUrl).Result;

                var responseContent = response.Content;
                string responseString = responseContent.ReadAsStringAsync().Result;

                XmlDocument xdoc = new XmlDocument();
                xdoc.LoadXml(responseString);


                XmlNodeList nodes = xdoc.SelectNodes("/RESULT");
                foreach (XmlNode res in nodes)
                {
                    rcode = res.SelectSingleNode("RCODE").InnerText;
                    rmsg = res.SelectSingleNode("RMSG").InnerText;
                }


                if (rcode == "S")  // 성공
                {
                    return 0;
                }
                else
                {
                    MessageBox.Show("쿠폰사용요청 실패응답. \r\n\r\n" + rmsg, "thepos");
                    return -1;

                }

            }
            catch (Exception ex)
            {
                MessageBox.Show("아래 메시지를 관리자에게 전달바랍니다. \r\n\r\n" + ex.Message, "시스템오류");
                return -1;
            }

        }
    }
}
