
namespace API_Demo.Handlers.RoutingConstraints
{
    public class EvenRouteConstraint : IRouteConstraint
    {
        public bool Match(
            HttpContext? httpContext,
            IRouter? route, 
            string routeKey, 
            RouteValueDictionary values, 
            RouteDirection routeDirection)
        {
            object? routeValue = values[routeKey];
            if (routeValue is null) return false;
            try
            {
                int value = int.Parse(routeValue.ToString());
                return value % 2 == 0;
            }
            catch (Exception)
            {
                return false;
            }
        }
    }
}
