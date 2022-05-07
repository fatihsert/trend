namespace Deeplink.Core
{
    public interface IDeeplinkService : IDeeplinkServiceValidations,
                                        IDeeplinkServiceQueryParameters,
                                        IDeeplinkServiceParameterFormat,
                                        IDeeplinkServiceDefaultParameters
    {

    }
}
