namespace PRO6 {

    namespace System {

        public static class pro6Factory {

            public static pro6Configuration getConfiguration(){
                return pro6Configuration.getInstance();
            }

            public static pro6Dbo getDbo(){
                pro6Configuration configuration = pro6Factory.getConfiguration();
                string connection_string = configuration.getKey(sectionName: "mysql", keyName: "connection-string");
                pro6Dbo dbo = pro6Dbo.getInstance();
                dbo.init(connectionString: connection_string);
                return dbo;
            }

        }

    }

}
