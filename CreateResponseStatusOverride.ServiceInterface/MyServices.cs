using ServiceStack;
using CreateResponseStatusOverride.ServiceModel;
using System;

namespace CreateResponseStatusOverride.ServiceInterface;

public class MyServices : Service
{
    public object Any(Hello request)
    {
        if (request != null)
            throw new ArgumentException("Dummy exception");
        return new HelloResponse { Result = $"Hello, {request.Name}!" };
    }
}