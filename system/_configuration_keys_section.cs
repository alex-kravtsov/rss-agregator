using System.Configuration;

namespace PRO6 {
    namespace System {
        class _ConfigurationKeysSection: ConfigurationSection {

            [ConfigurationProperty("name", DefaultValue="default", IsRequired=true, IsKey=false)]
            [RegexStringValidator(@"[A-Za-z_-]{1,60}")]
            public string Name {
                get {return (string)this["name"];}
                set {this["name"]=value;}
            }

            [ConfigurationProperty("configuration_keys", IsDefaultCollection=false)]
            public _ConfigurationKeysCollection configurationKeys {
                get {return (_ConfigurationKeysCollection)base["configuration_keys"];}
                set {base["configuration_keys"]=value;}
            }

        }
    }
}
