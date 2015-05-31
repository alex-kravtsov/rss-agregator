using System;
using System.Diagnostics;
using System.Windows.Forms;
using System.Drawing;
using System.Collections;
using PRO6.Models;
using PRO6.System;

namespace PRO6 {

    namespace Views {

        class pro6ViewDefault : pro6View {
        
            private TableLayoutPanel _layout_table = null;
            private int _layout_table_rows = 0;
            
            public pro6ViewDefault(){
                pro6Configuration configuration = pro6Factory.getConfiguration();
                this.Text = configuration.getKey(sectionName: "application", keyName: "application-title");
                this.AutoScroll = true;
                pro6ChannelItems channel_items_model = new pro6ChannelItems();
                ArrayList channel_items = channel_items_model.getChannelItems();
                this._layout_table = new TableLayoutPanel();
                this._layout_table.AutoSize = true;
                this._layout_table.AutoSizeMode = AutoSizeMode.GrowOnly;
                this.Controls.Add(this._layout_table);
                this._layout_table.ColumnCount = 2;
                foreach(pro6ChannelItem item in channel_items){
                    this._layout_table_rows++;
                    this._layout_table.RowCount = this._layout_table_rows;
                    this._renderChannelItem(item);
                }
                this.Width = this._layout_table.Width;
            }

            private void _renderChannelItem(pro6ChannelItem channel_item){

                pro6Configuration configuration = pro6Factory.getConfiguration();
                int item_text_width = Int32.Parse(configuration.getKey(sectionName: "application", keyName: "channel-item-text-width") );

                TableLayoutPanel item_table = new TableLayoutPanel();
                item_table.AutoSize = true;
                item_table.AutoSizeMode = AutoSizeMode.GrowOnly;
                item_table.ColumnCount = 1;

                Label label = new Label();
                label.Font = new Font("Arial", 10, FontStyle.Regular);
                string pub_date = channel_item.getPubDateString();
                string source = channel_item.getSource();
                label.Text = pub_date + " Источник: " + source;
                label.AutoSize = true;
                item_table.Controls.Add(label);
                item_table.SetColumn(label, 0);
                item_table.SetRow(label, 0);

                label = new Label();
                label.Text = channel_item.Title;
                label.Font = new Font("Arial", 12, FontStyle.Bold);
                Graphics graphics = Graphics.FromHwnd(label.Handle);
                SizeF text_size = graphics.MeasureString(label.Text, label.Font, item_text_width);
                label.Width = item_text_width;
                label.Height = text_size.ToSize().Height;
                item_table.Controls.Add(label);
                item_table.SetColumn(label, 0);
                item_table.SetRow(label, 1);

                label = new Label();
                label.Text = channel_item.Description;
                label.Font = new Font("Arial", 10, FontStyle.Regular);
                graphics = Graphics.FromHwnd(label.Handle);
                text_size = graphics.MeasureString(label.Text, label.Font, item_text_width);
                label.Width = item_text_width;
                label.Height = text_size.ToSize().Height;
                item_table.Controls.Add(label);
                item_table.SetColumn(label, 0);
                item_table.SetRow(label, 2);

                LinkLabel link_label = new LinkLabel();
                link_label.Text = "Читать далее";
                link_label.Links.Add(7, 5, channel_item.Link);
                link_label.LinkClicked += new LinkLabelLinkClickedEventHandler(this._LinkLabel_LinkClicked);
                item_table.Controls.Add(link_label);
                item_table.SetColumn(link_label, 0);
                item_table.SetRow(link_label, 3);

                this._layout_table.Controls.Add(item_table);
                this._layout_table.SetColumn(item_table, 1);
                this._layout_table.SetRow(item_table, this._layout_table_rows);
                if(channel_item.Image != null){
                    Control image_control = new Control();
                    image_control.BackgroundImage = channel_item.Image;
                    image_control.BackgroundImageLayout = ImageLayout.Center;
                    image_control.Size = channel_item.Image.Size;
                    this._layout_table.Controls.Add(image_control);
                    this._layout_table.SetColumn(image_control, 0);
                    this._layout_table.SetRow(image_control, this._layout_table_rows);
                }

            }

            private void _LinkLabel_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e){
                string target = e.Link.LinkData as string;
                Process.Start(target);
            }

        }

    }

}
