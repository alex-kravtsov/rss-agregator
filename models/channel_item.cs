using System;
using System.Text.RegularExpressions;
using System.Drawing;
using PRO6.System;

namespace PRO6 {

    namespace Models {

        public class pro6ChannelItem {

            private int? _id = null;
            private string _title = null;
            private string _description = null;
            private string _link = null;
            private DateTime? _pub_date = null;
            private Image _image = null;

            public int? Id {
                get { return this._id; }
                set { this._id = value; }
            }

            public string Title {
                get { return this._title; }
                set { this._title = value; }
            }

            public string Description {
                get { return this._description; }
                set { this._description = value; }
            }

            public string Link {
                get { return this._link; }
                set { this._link = value; }
            }

            public DateTime? PubDate {
                get { return this._pub_date; }
                set { this._pub_date = value; }
            }

            public Image Image {
                get { return this._image; }
                set { this._image = value; }
            }

            public string getPubDateString(){
                if(this._pub_date != null){
                    pro6Configuration configuration = pro6Factory.getConfiguration();
                    DateTime date = (DateTime)this._pub_date;
                    return date.ToString(configuration.getKey(sectionName: "application", keyName: "application-date-format") );
                }
                return null;
            }

            public string getSource(){
                string pattern = @"(https?://)?(\w+\.)?(\w+\.\w+)";
                Match match = Regex.Match(this._link, pattern);
                if(match.Success){
                    return match.Groups[3].Value;
                }
                return null;
            }

        }

    }

}
