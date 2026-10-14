using System.Text.RegularExpressions;

namespace _46._Custom_Route_Constraint_Class.CustomConstraints;

public class MonthsCustomConstraints : IRouteConstraint
{
    // Match method will be called automatically as a part of ASP.Net core internal code.
    public bool Match(HttpContext? httpContext, IRouter? route,
        string routeKey, RouteValueDictionary values, RouteDirection routeDirection)
    {
        // httpContext is the context which we are receiving in every middleware.
        // So this context provides the request and response objects mainly.

        // IRouter type of parameter represents an object that represents the route in which this constraint
        // is applied.
        // Assume that we have applied that constraint in particular route.
        // So this particular route is represented as IRouter.

        // Then after that the route key.
        // So this route key will be the name of the parameter for example month in this case.

        // values: will represent one or more values that are received from the incoming request.

        // routeDirection : is of either incoming request or URL generation.
        // Incoming request means we are going to check whether this constraint matches with the incoming request
        // while executing the routes.

        // URL generation is about generating a URL based on the values that you supply.
        // It generally happens with model view controllers and creating hyperlinks in the views.
        // It's a later topic, so ignore it for the time being.

        // Lets verify whether the value for the month parameter exists or not.
        if (!values.ContainsKey(routeKey))
        {
            // The Boolean value false indicates that it's not a match means the constraint doesn't match.
            // So in case of false overall it would be treated as this particular road doesn't match with that URL.
            // And it will go and check the upcoming next route which is in the same order.
            return false;
        }

        Regex regex = new Regex("^(apr|jul|oct|jan)$");

        string? monthValue = Convert.ToString(values[routeKey]);

        if (regex.IsMatch(monthValue!))
        {
            // True indicates that the incoming value matches with this constraint.

            return true;
        }

        return false; // Not a match
    }
}