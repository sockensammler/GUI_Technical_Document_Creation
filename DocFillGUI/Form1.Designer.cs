namespace DocFillGUI
{
    partial class Form1
    {
        /// <summary>
        ///  Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        ///  Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        ///  Required method for Designer support - do not modify
        ///  the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            search_box = new TextBox();
            available_articles_list = new ListBox();
            added_connected_articles_list = new ListBox();
            available_connected_articles_list = new ListBox();
            label1 = new Label();
            add_art_button = new Button();
            added_articles_list = new ListBox();
            button3 = new Button();
            button4 = new Button();
            remove_art_button = new Button();
            remove_conn_art_button = new Button();
            add_conn_art_button = new Button();
            SuspendLayout();
            // 
            // search_box
            // 
            search_box.Location = new Point(12, 12);
            search_box.Name = "search_box";
            search_box.Size = new Size(100, 23);
            search_box.TabIndex = 0;
            search_box.Text = "Search...";
            // 
            // available_articles_list
            // 
            available_articles_list.FormattingEnabled = true;
            available_articles_list.ItemHeight = 15;
            available_articles_list.Location = new Point(12, 41);
            available_articles_list.Name = "available_articles_list";
            available_articles_list.Size = new Size(337, 184);
            available_articles_list.TabIndex = 1;
            available_articles_list.SelectedIndexChanged += available_articles_list_SelectedIndexChanged;
            // 
            // added_connected_articles_list
            // 
            added_connected_articles_list.FormattingEnabled = true;
            added_connected_articles_list.ItemHeight = 15;
            added_connected_articles_list.Location = new Point(451, 248);
            added_connected_articles_list.Name = "added_connected_articles_list";
            added_connected_articles_list.Size = new Size(337, 109);
            added_connected_articles_list.TabIndex = 4;
            // 
            // available_connected_articles_list
            // 
            available_connected_articles_list.FormattingEnabled = true;
            available_connected_articles_list.ItemHeight = 15;
            available_connected_articles_list.Location = new Point(12, 248);
            available_connected_articles_list.Name = "available_connected_articles_list";
            available_connected_articles_list.Size = new Size(337, 109);
            available_connected_articles_list.TabIndex = 3;
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Location = new Point(12, 230);
            label1.Name = "label1";
            label1.Size = new Size(105, 15);
            label1.TabIndex = 6;
            label1.Text = "Connected articles";
            label1.Click += label1_Click;
            // 
            // add_art_button
            // 
            add_art_button.Location = new Point(355, 71);
            add_art_button.Name = "add_art_button";
            add_art_button.Size = new Size(90, 63);
            add_art_button.TabIndex = 7;
            add_art_button.Text = "Add article >>";
            add_art_button.UseVisualStyleBackColor = true;
            add_art_button.Click += add_art_button_Click;
            // 
            // added_articles_list
            // 
            added_articles_list.FormattingEnabled = true;
            added_articles_list.ItemHeight = 15;
            added_articles_list.Location = new Point(451, 41);
            added_articles_list.Name = "added_articles_list";
            added_articles_list.Size = new Size(337, 184);
            added_articles_list.TabIndex = 5;
            // 
            // button3
            // 
            button3.Location = new Point(665, 413);
            button3.Name = "button3";
            button3.Size = new Size(123, 33);
            button3.TabIndex = 9;
            button3.Text = "Generate Docs >>>";
            button3.UseVisualStyleBackColor = true;
            // 
            // button4
            // 
            button4.Location = new Point(536, 413);
            button4.Name = "button4";
            button4.Size = new Size(123, 33);
            button4.TabIndex = 10;
            button4.Text = "Remove all articles";
            button4.UseVisualStyleBackColor = true;
            button4.Click += button4_Click;
            // 
            // remove_art_button
            // 
            remove_art_button.Location = new Point(355, 140);
            remove_art_button.Name = "remove_art_button";
            remove_art_button.Size = new Size(90, 41);
            remove_art_button.TabIndex = 11;
            remove_art_button.Text = "Remove article <<";
            remove_art_button.UseVisualStyleBackColor = true;
            remove_art_button.Click += remove_art_button_Click;
            // 
            // remove_conn_art_button
            // 
            remove_conn_art_button.Location = new Point(355, 317);
            remove_conn_art_button.Name = "remove_conn_art_button";
            remove_conn_art_button.Size = new Size(90, 41);
            remove_conn_art_button.TabIndex = 13;
            remove_conn_art_button.Text = "Remove conn. article <<";
            remove_conn_art_button.UseVisualStyleBackColor = true;
            remove_conn_art_button.Click += button2_Click;
            // 
            // add_conn_art_button
            // 
            add_conn_art_button.Location = new Point(355, 248);
            add_conn_art_button.Name = "add_conn_art_button";
            add_conn_art_button.Size = new Size(90, 63);
            add_conn_art_button.TabIndex = 12;
            add_conn_art_button.Text = "Add conn. article >>";
            add_conn_art_button.UseVisualStyleBackColor = true;
            add_conn_art_button.Click += button6_Click;
            // 
            // Form1
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(800, 450);
            Controls.Add(remove_conn_art_button);
            Controls.Add(add_conn_art_button);
            Controls.Add(remove_art_button);
            Controls.Add(button4);
            Controls.Add(button3);
            Controls.Add(add_art_button);
            Controls.Add(label1);
            Controls.Add(added_articles_list);
            Controls.Add(added_connected_articles_list);
            Controls.Add(available_connected_articles_list);
            Controls.Add(available_articles_list);
            Controls.Add(search_box);
            Name = "Form1";
            Text = "Form1";
            Load += Form1_Load;
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private TextBox search_box;
        private ListBox available_articles_list;
        private ListBox added_connected_articles_list;
        private ListBox available_connected_articles_list;
        private Label label1;
        private Button add_art_button;
        private ListBox added_articles_list;
        private Button button3;
        private Button button4;
        private Button remove_art_button;
        private Button remove_conn_art_button;
        private Button add_conn_art_button;
        private DataGridView dataGridView1;

    }
}
