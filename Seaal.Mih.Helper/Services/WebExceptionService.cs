using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;

namespace Seaal.Mih.Helper
{
    public class WebExceptionService
    {
        public string Handle(WebException wex)
        {
            if (wex.Status == WebExceptionStatus.ProtocolError)
            {
                switch (((HttpWebResponse)wex.Response).StatusCode)
                {
                    case HttpStatusCode.NotFound:
                        return "Player not found.";
                    case HttpStatusCode.Unauthorized:
                        return "Unauthorized, check your API key.";
                    case HttpStatusCode.BadRequest:
                        return "Bad Request, try again later.";
                    case HttpStatusCode.ServiceUnavailable:
                    case HttpStatusCode.InternalServerError:
                        return "API unavailable, try again later.";
                    case (HttpStatusCode)429:
                        return "API limit reached, try again.";
                    default:
                        return "An error has occurred.";
                }
            }
            else if (wex.Status == WebExceptionStatus.NameResolutionFailure)
            {
                return "Cannot resolve API name.";
            }
            else
            {
                return "An error has occurred.";
            }     
        }
        
    }
}
