using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using System.Threading.Tasks;
using System.Data.Entity;
using System.Net;
using MGCTrainingPortalAPI.OktaConnector.Constants;
using System.IO;
using System.Configuration;

namespace MGCTrainingPortalAPI.OktaConnector
{
    public class OktaUsers
    {
        public async Task<dynamic> GetUserFromOkta(string sOktaId)
        {
            try
            {
                string sOktaAPIKey = ConfigurationManager.AppSettings["OktaAPIToken"];

                HttpWebRequest request = (HttpWebRequest)HttpWebRequest.Create(OktaEndPointConstants.sUsersEndPoint + "/" + sOktaId);
                request.Method = "GET";
                request.ContentType = "application/json";
                request.Headers.Add(HttpRequestHeader.Authorization, "SSWS " + sOktaAPIKey);

                var response = (HttpWebResponse)request.GetResponse();

                var jarrResponse = await new StreamReader(response.GetResponseStream()).ReadToEndAsync();
                var jsResponse = JsonConvert.DeserializeObject<dynamic>(jarrResponse);

                return jsResponse;
            }
            catch(Exception ex)
            {
                throw new Exception(ex.Message);
            }

        }
    }
}