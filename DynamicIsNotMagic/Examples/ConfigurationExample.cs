using System.Dynamic;
using DynamicIsNotMagic.Examples;

namespace DynamicIsNotMagic.Examples
{
    public abstract class ConfigurationSource : DynamicObject {/**/}
    public class JsonConfigurationSource : ConfigurationSource {/**/}
    public class XmlConfigurationSource : ConfigurationSource {/**/}
    public class DbConfigurationSource : ConfigurationSource {/**/}
    public class AggregatedConfigurationSource: ConfigurationSource {/**/}

    public class Application
    {
        public Application(ConfigurationSource configurationSource)
        {
            var configuration = configurationSource as dynamic;
            SetupDb(configuration.CommonSettings.DB);
            SetupPool(configuration.CommonSettings.Pool);
        }

        public void SetupDb(dynamic dbSettings) {/**/}
        public void SetupPool(dynamic poolSettings) {/**/}

        /**/
    }
}


public class a
{
    XmlConfigurationSource aa = new XmlConfigurationSource();
    DbConfigurationSource b = new DbConfigurationSource();
    AggregatedConfigurationSource c = new AggregatedConfigurationSource();
    JsonConfigurationSource d = new JsonConfigurationSource();
    Application aaa = new Application(new JsonConfigurationSource());
}
