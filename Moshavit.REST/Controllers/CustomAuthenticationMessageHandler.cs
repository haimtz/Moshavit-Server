using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Security.Principal;
using System.Threading;
using System.Threading.Tasks;
using System.Web;

namespace Moshavit.REST.Controllers
{
    public class CustomAuthenticationMessageHandler : DelegatingHandler
    {
        public CustomAuthenticationMessageHandler()
        {

        }

        protected override Task<HttpResponseMessage> SendAsync(HttpRequestMessage request,
                                                               CancellationToken cancellationToken)
        {
            if (!Authenticate(request))
            {
                var response = new HttpResponseMessage(HttpStatusCode.Forbidden);
                var tsc = new TaskCompletionSource<HttpResponseMessage>();
                tsc.SetResult(response);
                return tsc.Task;
            }


            return base.SendAsync(request, cancellationToken);
        }

        protected bool Authenticate(HttpRequestMessage request)
        {
            return true;
        }
    }
}