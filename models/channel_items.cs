using System;
using System.Collections;
using System.Drawing;
using PRO6.System;
using MySql.Data;
using MySql.Data.MySqlClient;

namespace PRO6 {

    namespace Models {

        public class pro6ChannelItems {

            public ArrayList getChannelItems(){
                pro6Dbo dbo = pro6Factory.getDbo();
                string query = "SELECT `t1`.`id`, `t1`.`title`, `t1`.`description`, `t1`.`link`, `t1`.`pubDate`, `t2`.`image` FROM `pro6_channel_items` AS `t1` LEFT JOIN `pro6_channel_items_images` AS `t2` ON `t1`.`id` = `t2`.`item_id`";
                MySqlDataReader reader = dbo.doSelect(query);
                ArrayList channel_items = new ArrayList();
                while(reader.Read() ){
                    pro6ChannelItem channel_item = new pro6ChannelItem();
                    channel_item.Id = reader.GetInt32(0);
                    channel_item.Title = reader.GetString(1);
                    channel_item.Description = reader.GetString(2);
                    channel_item.Link = reader.GetString(3);
                    channel_item.PubDate = DateTime.Parse(reader.GetString(4) );
                    if(!reader.IsDBNull(5) ) channel_item.Image = pro6Utilites.ImageCreateFromBase64(reader.GetString(5) );
                    channel_items.Add(channel_item);
                }
                reader.Close();
                return channel_items;
            }

        }

    }

}
