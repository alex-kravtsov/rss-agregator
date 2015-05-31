using System;
using System.Windows.Forms;
using PRO6.Views;

namespace PRO6 {

    class RSSAgregator {

        public static void Main(){
            try {
                Application.Run(new pro6ViewDefault() );
            }
            catch(Exception e){
                Console.WriteLine("{0}", e.Message);
            }
        }

    }

}
