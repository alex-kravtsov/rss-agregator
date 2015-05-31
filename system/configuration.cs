using System;
using System.Configuration;

namespace PRO6 {

    namespace System {

        public class pro6Configuration {

            private static pro6Configuration _instance = null;

            public void addKey(string sectionName, string keyName, string keyValue){
                Configuration config = ConfigurationManager.OpenExeConfiguration(ConfigurationUserLevel.None);
                _ConfigurationKeysSection section;
                if(config.Sections[sectionName] == null){
                    section = new _ConfigurationKeysSection();
                    section.Name = sectionName;
                    config.Sections.Add(sectionName, section);
                }
                else section = (_ConfigurationKeysSection)config.Sections[sectionName];
                if(section.configurationKeys == null) section.configurationKeys = new _ConfigurationKeysCollection();
                if(section.configurationKeys[keyName] == null){
                    _ConfigurationKey key = new _ConfigurationKey();
                    key.keyName = keyName;
                    key.keyValue = keyValue;
                    section.configurationKeys.Add(key);
                }
                else (section.configurationKeys[keyName]).keyValue = keyValue;
                config.Save(ConfigurationSaveMode.Full);
            }

            public static pro6Configuration getInstance(){
                if(pro6Configuration._instance == null) pro6Configuration._instance = new pro6Configuration();
                return pro6Configuration._instance;
            }

            public string getKey(string sectionName, string keyName){
                Configuration config = ConfigurationManager.OpenExeConfiguration(ConfigurationUserLevel.None);
                if(config.Sections[sectionName] == null){
                    throw new Exception("Invalid configuration section name");
                }
                _ConfigurationKeysSection section = (_ConfigurationKeysSection)config.Sections[sectionName];
                if(section.configurationKeys[keyName] == null){
                    throw new Exception("Invalid configuration key name");
                }
                _ConfigurationKey key = section.configurationKeys[keyName];
                return key.keyValue;
            }

            private pro6Configuration(){
            }

        }

    }

}
