using System.Configuration;

namespace PRO6 {
    namespace System {
        class _ConfigurationKey: ConfigurationElement {

            public _ConfigurationKey(){}

            [ConfigurationProperty("name", IsRequired=true)]
            public string keyName {
                get {return (string)this["name"];}
                set {this["name"]=value;}
            }

            [ConfigurationProperty("value", DefaultValue="", IsRequired=false)]
            public string keyValue {
                get {return (string)this["value"];}
                set {this["value"]=value;}
            }

        }
    }
}
