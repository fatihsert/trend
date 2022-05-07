using Deeplink.Core;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Deeplink.Api.Configuration
{
    public class DeeplinkConfiguraiton : IDeeplinkConfiguration
    {
        public string Root { get; set; }
        public IList<DeeplinkDefinition> DeeplinkDefinitions { get; set; }

        public DeeplinkConfiguraiton()
        {
            Root = "ty://?";

            DeeplinkDefinitions = new List<DeeplinkDefinition>();

            DeeplinkDefinition product = new DeeplinkDefinition();
            DeeplinkDefinitions.Add(product);
            product.Name = "Product";
            product.RootPattern = @"^(http|https):\/\/(www\.)?trendyol\.com\/[a-zA-Z0-9-]{1,}\/[a-zA-Z0-9-]{1,}-p-[0-9]{1,}";

            product.DefaultParameters = new Dictionary<string, string>();
            product.DefaultParameters.Add("Page", product.Name);

            product.ParameterKeyMap = new Dictionary<string, string>();
            product.ParameterKeyMap.Add("boutiqueId", "campaingId");

            product.ParameterFormatMap = new Dictionary<string, IDeeplinkParameterFormater>();
            product.ParameterFormatMap.Add("ContentId", new DeeplinkContentIdFormater(@"(http|https):\/\/(www\.)?trendyol\.com\/[a-zA-Z0-9-]{1,}\/[a-zA-Z0-9-]{1,}-p-",
                                                                                      "^[0-9]{1,}"));

            product.Validations = new List<IDeeplinkValidation>
                    {
                        new EmptyUrlValidation(),
                        new RegexUrlValidation(@"^(http|https):\/\/(www\.)?trendyol\.com\/[a-zA-Z0-9]{1,}\/[a-zA-Z0-9-]{1,}-p-[0-9]{1,}\??([a-zA-Z0-9-=&]*)?$")
                    };

            DeeplinkDefinition search = new DeeplinkDefinition();
            DeeplinkDefinitions.Add(search);

            search.Name = "Search";
            search.RootPattern = @"^(http|https):\/\/(www\.)?trendyol\.com\/tum--urunler*";

            search.DefaultParameters = new Dictionary<string, string>();
            search.DefaultParameters.Add("Page", search.Name);

            search.ParameterKeyMap = new Dictionary<string, string>();
            search.ParameterKeyMap.Add("q", "Query");

            search.Validations = new List<IDeeplinkValidation>
                    {
                        new EmptyUrlValidation(),
                        new RegexUrlValidation(search.RootPattern)
                    };


            DeeplinkDefinition other = new DeeplinkDefinition();
            DeeplinkDefinitions.Add(other);

            other.Name = "Home";
            other.RootPattern = @"^(http|https):\/\/(www\.)?trendyol\.com.*";

            other.DefaultParameters = new Dictionary<string, string>();
            other.DefaultParameters.Add("Page", other.Name);

            other.Validations = new List<IDeeplinkValidation>
                    {
                        new EmptyUrlValidation(),
                        new RegexUrlValidation(other.RootPattern)
                    };
        }
    }

}
