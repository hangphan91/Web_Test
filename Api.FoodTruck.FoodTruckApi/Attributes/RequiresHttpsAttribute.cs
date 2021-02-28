using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using System.Web;
using System.Web.Http.Controllers;
using System.Web.Http.Filters;

namespace Api.FoodTruck.FoodTruckApi.Attributes
{
    [AttributeUsage(AttributeTargets.Method)]
    public class RequiresHttpsAttribute: AuthorizationFilterAttribute
    {
        public override Task OnAuthorizationAsync(HttpActionContext actionContext, CancellationToken cancellationToken)
        {
            if (actionContext.Request.RequestUri.Scheme != Uri.UriSchemeHttps)
            {
                actionContext.Response =  new System.Net.Http.HttpResponseMessage(System.Net.HttpStatusCode.Forbidden) { ReasonPhrase= "Https Required."};
            }
            return base.OnAuthorizationAsync(actionContext, cancellationToken);
        }
    }
}