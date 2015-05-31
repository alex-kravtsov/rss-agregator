using System;
using System.Configuration;

namespace PRO6 {
    namespace System {
        class _ConfigurationKeysCollection: ConfigurationElementCollection {

            public override ConfigurationElementCollectionType CollectionType {
                get {return ConfigurationElementCollectionType.AddRemoveClearMap;}
            }

            protected override ConfigurationElement CreateNewElement(string elementName){
                _ConfigurationKey element = new _ConfigurationKey();
                element.keyName = elementName;
                return element;
            }

            protected override ConfigurationElement CreateNewElement(){
                return new _ConfigurationKey();
            }

            protected override Object GetElementKey(ConfigurationElement element){
                return ( (_ConfigurationKey)element).keyName;
            }

            public _ConfigurationKey this[int index]{
                get {return (_ConfigurationKey)BaseGet(index);}
                set {
                    if(BaseGet(index) != null) BaseRemoveAt(index);
                    BaseAdd(index, value);
                }
            }

            new public _ConfigurationKey this[string Name]{
                get {return (_ConfigurationKey)BaseGet(Name);}
            }

            public int IndexOf(_ConfigurationKey element){
                return BaseIndexOf(element);
            }

            public void Add(_ConfigurationKey element){
                BaseAdd(element);
            }

            protected override void BaseAdd(ConfigurationElement element){
                BaseAdd(element, false);
            }

            public void Remove(_ConfigurationKey element){
                if(BaseIndexOf(element) >= 0) BaseRemove(element.keyName);
            }

            public void Remove(string Name){
                BaseRemove(Name);
            }

            public void Clear(){
                BaseClear();
            }

        }
    }
}
