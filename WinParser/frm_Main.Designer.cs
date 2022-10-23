namespace WinParser
{
    partial class frm_Main
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
            this.components = new System.ComponentModel.Container();
            this.tabControl1 = new System.Windows.Forms.TabControl();
            this.tp_Order = new System.Windows.Forms.TabPage();
            this.pb_Load = new System.Windows.Forms.ProgressBar();
            this.btn_RossLogin = new System.Windows.Forms.Button();
            this.btn_ClearSession = new System.Windows.Forms.Button();
            this.btn_OrderClearValues = new System.Windows.Forms.Button();
            this.lbl_key = new System.Windows.Forms.Label();
            this.lbl_Load = new System.Windows.Forms.Label();
            this.btn_OrderSend = new System.Windows.Forms.Button();
            this.label5 = new System.Windows.Forms.Label();
            this.label6 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.tb_OrderStreet = new System.Windows.Forms.TextBox();
            this.tb_OrderFlat = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.tb_OrderHome = new System.Windows.Forms.TextBox();
            this.tb_OrderLocation = new System.Windows.Forms.TextBox();
            this.tb_OrderDistrict = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.tb_OrderRegion = new System.Windows.Forms.TextBox();
            this.tp_OrderList = new System.Windows.Forms.TabPage();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.dtp_Begin = new System.Windows.Forms.DateTimePicker();
            this.tb_OrderNumber = new System.Windows.Forms.TextBox();
            this.label7 = new System.Windows.Forms.Label();
            this.label9 = new System.Windows.Forms.Label();
            this.btn_OrdersRefresh = new System.Windows.Forms.Button();
            this.dgv_Orders = new System.Windows.Forms.DataGridView();
            this.dgvc_Number = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dgvc_DateCreate = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dgvc_State = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dgvc_Download = new System.Windows.Forms.DataGridViewButtonColumn();
            this.btn_Close = new System.Windows.Forms.Button();
            this.bs_Orders = new System.Windows.Forms.BindingSource(this.components);
            this.lbl_Login = new System.Windows.Forms.Label();
            this.lbl_SheetCount = new System.Windows.Forms.Label();
            this.label10 = new System.Windows.Forms.Label();
            this.rb_BrowserOn = new System.Windows.Forms.RadioButton();
            this.rb_BrowserOff = new System.Windows.Forms.RadioButton();
            this.tabControl1.SuspendLayout();
            this.tp_Order.SuspendLayout();
            this.tp_OrderList.SuspendLayout();
            this.groupBox1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgv_Orders)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.bs_Orders)).BeginInit();
            this.SuspendLayout();
            // 
            // tabControl1
            // 
            this.tabControl1.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.tabControl1.Controls.Add(this.tp_Order);
            this.tabControl1.Controls.Add(this.tp_OrderList);
            this.tabControl1.Location = new System.Drawing.Point(1, 38);
            this.tabControl1.Name = "tabControl1";
            this.tabControl1.SelectedIndex = 0;
            this.tabControl1.Size = new System.Drawing.Size(812, 371);
            this.tabControl1.TabIndex = 0;
            // 
            // tp_Order
            // 
            this.tp_Order.Controls.Add(this.pb_Load);
            this.tp_Order.Controls.Add(this.btn_RossLogin);
            this.tp_Order.Controls.Add(this.btn_ClearSession);
            this.tp_Order.Controls.Add(this.btn_OrderClearValues);
            this.tp_Order.Controls.Add(this.lbl_key);
            this.tp_Order.Controls.Add(this.lbl_Load);
            this.tp_Order.Controls.Add(this.btn_OrderSend);
            this.tp_Order.Controls.Add(this.label5);
            this.tp_Order.Controls.Add(this.label6);
            this.tp_Order.Controls.Add(this.label4);
            this.tp_Order.Controls.Add(this.label3);
            this.tp_Order.Controls.Add(this.tb_OrderStreet);
            this.tp_Order.Controls.Add(this.tb_OrderFlat);
            this.tp_Order.Controls.Add(this.label2);
            this.tp_Order.Controls.Add(this.tb_OrderHome);
            this.tp_Order.Controls.Add(this.tb_OrderLocation);
            this.tp_Order.Controls.Add(this.tb_OrderDistrict);
            this.tp_Order.Controls.Add(this.label1);
            this.tp_Order.Controls.Add(this.tb_OrderRegion);
            this.tp_Order.Location = new System.Drawing.Point(4, 24);
            this.tp_Order.Name = "tp_Order";
            this.tp_Order.Padding = new System.Windows.Forms.Padding(3);
            this.tp_Order.Size = new System.Drawing.Size(804, 343);
            this.tp_Order.TabIndex = 0;
            this.tp_Order.Text = "Подать заявку";
            this.tp_Order.UseVisualStyleBackColor = true;
            // 
            // pb_Load
            // 
            this.pb_Load.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.pb_Load.Location = new System.Drawing.Point(7, 314);
            this.pb_Load.Name = "pb_Load";
            this.pb_Load.Size = new System.Drawing.Size(790, 23);
            this.pb_Load.Step = 1;
            this.pb_Load.TabIndex = 9;
            this.pb_Load.Visible = false;
            // 
            // btn_RossLogin
            // 
            this.btn_RossLogin.Location = new System.Drawing.Point(470, 251);
            this.btn_RossLogin.Name = "btn_RossLogin";
            this.btn_RossLogin.Size = new System.Drawing.Size(106, 23);
            this.btn_RossLogin.TabIndex = 7;
            this.btn_RossLogin.Text = "Подкключение";
            this.btn_RossLogin.UseVisualStyleBackColor = true;
            this.btn_RossLogin.Click += new System.EventHandler(this.btn_RossLogin_Click);
            // 
            // btn_ClearSession
            // 
            this.btn_ClearSession.Location = new System.Drawing.Point(582, 251);
            this.btn_ClearSession.Name = "btn_ClearSession";
            this.btn_ClearSession.Size = new System.Drawing.Size(106, 23);
            this.btn_ClearSession.TabIndex = 7;
            this.btn_ClearSession.Text = "Очистить кеш";
            this.btn_ClearSession.UseVisualStyleBackColor = true;
            this.btn_ClearSession.Click += new System.EventHandler(this.btn_ClearSession_Click);
            // 
            // btn_OrderClearValues
            // 
            this.btn_OrderClearValues.Location = new System.Drawing.Point(119, 120);
            this.btn_OrderClearValues.Name = "btn_OrderClearValues";
            this.btn_OrderClearValues.Size = new System.Drawing.Size(106, 23);
            this.btn_OrderClearValues.TabIndex = 7;
            this.btn_OrderClearValues.Text = "Очистить поля";
            this.btn_OrderClearValues.UseVisualStyleBackColor = true;
            // 
            // lbl_key
            // 
            this.lbl_key.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.lbl_key.AutoSize = true;
            this.lbl_key.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.lbl_key.Location = new System.Drawing.Point(7, 237);
            this.lbl_key.Name = "lbl_key";
            this.lbl_key.Size = new System.Drawing.Size(28, 15);
            this.lbl_key.TabIndex = 1;
            this.lbl_key.Text = "Key";
            this.lbl_key.Visible = false;
            // 
            // lbl_Load
            // 
            this.lbl_Load.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.lbl_Load.AutoSize = true;
            this.lbl_Load.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.lbl_Load.Location = new System.Drawing.Point(7, 296);
            this.lbl_Load.Name = "lbl_Load";
            this.lbl_Load.Size = new System.Drawing.Size(239, 15);
            this.lbl_Load.TabIndex = 1;
            this.lbl_Load.Text = "Запрос сведений об объекте(~500мин.)";
            this.lbl_Load.Visible = false;
            // 
            // btn_OrderSend
            // 
            this.btn_OrderSend.Location = new System.Drawing.Point(7, 120);
            this.btn_OrderSend.Name = "btn_OrderSend";
            this.btn_OrderSend.Size = new System.Drawing.Size(106, 23);
            this.btn_OrderSend.TabIndex = 6;
            this.btn_OrderSend.Text = "Подать заявку";
            this.btn_OrderSend.UseVisualStyleBackColor = true;
            this.btn_OrderSend.Click += new System.EventHandler(this.btn_OrderSend_Click);
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(358, 21);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(44, 15);
            this.label5.TabIndex = 1;
            this.label5.Text = "Улица:";
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(368, 79);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(61, 15);
            this.label6.TabIndex = 1;
            this.label6.Text = "Квартира:";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(368, 50);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(34, 15);
            this.label4.TabIndex = 1;
            this.label4.Text = "Дом:";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(7, 79);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(114, 15);
            this.label3.TabIndex = 1;
            this.label3.Text = "Населенный пункт:";
            // 
            // tb_OrderStreet
            // 
            this.tb_OrderStreet.Location = new System.Drawing.Point(405, 18);
            this.tb_OrderStreet.Name = "tb_OrderStreet";
            this.tb_OrderStreet.Size = new System.Drawing.Size(220, 23);
            this.tb_OrderStreet.TabIndex = 3;
            // 
            // tb_OrderFlat
            // 
            this.tb_OrderFlat.Location = new System.Drawing.Point(432, 76);
            this.tb_OrderFlat.Name = "tb_OrderFlat";
            this.tb_OrderFlat.Size = new System.Drawing.Size(73, 23);
            this.tb_OrderFlat.TabIndex = 5;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(7, 50);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(44, 15);
            this.label2.TabIndex = 1;
            this.label2.Text = "Район:";
            // 
            // tb_OrderHome
            // 
            this.tb_OrderHome.Location = new System.Drawing.Point(405, 47);
            this.tb_OrderHome.Name = "tb_OrderHome";
            this.tb_OrderHome.Size = new System.Drawing.Size(100, 23);
            this.tb_OrderHome.TabIndex = 4;
            // 
            // tb_OrderLocation
            // 
            this.tb_OrderLocation.Location = new System.Drawing.Point(127, 76);
            this.tb_OrderLocation.Name = "tb_OrderLocation";
            this.tb_OrderLocation.Size = new System.Drawing.Size(202, 23);
            this.tb_OrderLocation.TabIndex = 2;
            // 
            // tb_OrderDistrict
            // 
            this.tb_OrderDistrict.Location = new System.Drawing.Point(59, 47);
            this.tb_OrderDistrict.Name = "tb_OrderDistrict";
            this.tb_OrderDistrict.Size = new System.Drawing.Size(270, 23);
            this.tb_OrderDistrict.TabIndex = 1;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(7, 21);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(49, 15);
            this.label1.TabIndex = 1;
            this.label1.Text = "Регион:";
            // 
            // tb_OrderRegion
            // 
            this.tb_OrderRegion.Location = new System.Drawing.Point(59, 18);
            this.tb_OrderRegion.Name = "tb_OrderRegion";
            this.tb_OrderRegion.Size = new System.Drawing.Size(270, 23);
            this.tb_OrderRegion.TabIndex = 0;
            // 
            // tp_OrderList
            // 
            this.tp_OrderList.Controls.Add(this.groupBox1);
            this.tp_OrderList.Controls.Add(this.btn_OrdersRefresh);
            this.tp_OrderList.Controls.Add(this.dgv_Orders);
            this.tp_OrderList.Location = new System.Drawing.Point(4, 24);
            this.tp_OrderList.Name = "tp_OrderList";
            this.tp_OrderList.Padding = new System.Windows.Forms.Padding(3);
            this.tp_OrderList.Size = new System.Drawing.Size(804, 343);
            this.tp_OrderList.TabIndex = 1;
            this.tp_OrderList.Text = "Список заявок";
            this.tp_OrderList.UseVisualStyleBackColor = true;
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.dtp_Begin);
            this.groupBox1.Controls.Add(this.tb_OrderNumber);
            this.groupBox1.Controls.Add(this.label7);
            this.groupBox1.Controls.Add(this.label9);
            this.groupBox1.Location = new System.Drawing.Point(7, 6);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(444, 56);
            this.groupBox1.TabIndex = 5;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Фильтры";
            // 
            // dtp_Begin
            // 
            this.dtp_Begin.Format = System.Windows.Forms.DateTimePickerFormat.Short;
            this.dtp_Begin.Location = new System.Drawing.Point(338, 22);
            this.dtp_Begin.Name = "dtp_Begin";
            this.dtp_Begin.Size = new System.Drawing.Size(94, 23);
            this.dtp_Begin.TabIndex = 2;
            // 
            // tb_OrderNumber
            // 
            this.tb_OrderNumber.Location = new System.Drawing.Point(96, 22);
            this.tb_OrderNumber.Name = "tb_OrderNumber";
            this.tb_OrderNumber.Size = new System.Drawing.Size(191, 23);
            this.tb_OrderNumber.TabIndex = 4;
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Location = new System.Drawing.Point(293, 25);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(39, 15);
            this.label7.TabIndex = 3;
            this.label7.Text = "дата с";
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.Location = new System.Drawing.Point(6, 25);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(84, 15);
            this.label9.TabIndex = 3;
            this.label9.Text = "Номер заявки";
            // 
            // btn_OrdersRefresh
            // 
            this.btn_OrdersRefresh.Location = new System.Drawing.Point(457, 13);
            this.btn_OrdersRefresh.Name = "btn_OrdersRefresh";
            this.btn_OrdersRefresh.Size = new System.Drawing.Size(125, 33);
            this.btn_OrdersRefresh.TabIndex = 1;
            this.btn_OrdersRefresh.Text = "Обновить заявки";
            this.btn_OrdersRefresh.UseVisualStyleBackColor = true;
            this.btn_OrdersRefresh.Click += new System.EventHandler(this.btn_OrdersRefresh_Click);
            // 
            // dgv_Orders
            // 
            this.dgv_Orders.AllowUserToAddRows = false;
            this.dgv_Orders.AllowUserToDeleteRows = false;
            this.dgv_Orders.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.dgv_Orders.BackgroundColor = System.Drawing.SystemColors.ButtonHighlight;
            this.dgv_Orders.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.DisableResizing;
            this.dgv_Orders.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.dgvc_Number,
            this.dgvc_DateCreate,
            this.dgvc_State,
            this.dgvc_Download});
            this.dgv_Orders.Location = new System.Drawing.Point(3, 68);
            this.dgv_Orders.Name = "dgv_Orders";
            this.dgv_Orders.RowHeadersVisible = false;
            this.dgv_Orders.RowTemplate.Height = 25;
            this.dgv_Orders.Size = new System.Drawing.Size(801, 272);
            this.dgv_Orders.TabIndex = 0;
            // 
            // dgvc_Number
            // 
            this.dgvc_Number.DataPropertyName = "Number";
            this.dgvc_Number.HeaderText = "Номер";
            this.dgvc_Number.Name = "dgvc_Number";
            // 
            // dgvc_DateCreate
            // 
            this.dgvc_DateCreate.DataPropertyName = "DateCreate";
            this.dgvc_DateCreate.HeaderText = "Дата создания";
            this.dgvc_DateCreate.Name = "dgvc_DateCreate";
            // 
            // dgvc_State
            // 
            this.dgvc_State.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
            this.dgvc_State.DataPropertyName = "State";
            this.dgvc_State.HeaderText = "Статус";
            this.dgvc_State.Name = "dgvc_State";
            // 
            // dgvc_Download
            // 
            this.dgvc_Download.DataPropertyName = "DownloadLink";
            this.dgvc_Download.HeaderText = "Скачать";
            this.dgvc_Download.Name = "dgvc_Download";
            // 
            // btn_Close
            // 
            this.btn_Close.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.btn_Close.Location = new System.Drawing.Point(727, 415);
            this.btn_Close.Name = "btn_Close";
            this.btn_Close.Size = new System.Drawing.Size(75, 23);
            this.btn_Close.TabIndex = 8;
            this.btn_Close.Text = "Закрыть";
            this.btn_Close.UseVisualStyleBackColor = true;
            this.btn_Close.Click += new System.EventHandler(this.btn_Close_Click);
            // 
            // lbl_Login
            // 
            this.lbl_Login.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.lbl_Login.AutoSize = true;
            this.lbl_Login.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.lbl_Login.Location = new System.Drawing.Point(742, 9);
            this.lbl_Login.Name = "lbl_Login";
            this.lbl_Login.Size = new System.Drawing.Size(37, 15);
            this.lbl_Login.TabIndex = 1;
            this.lbl_Login.Text = "Login";
            // 
            // lbl_SheetCount
            // 
            this.lbl_SheetCount.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.lbl_SheetCount.AutoSize = true;
            this.lbl_SheetCount.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.lbl_SheetCount.Location = new System.Drawing.Point(679, 9);
            this.lbl_SheetCount.Name = "lbl_SheetCount";
            this.lbl_SheetCount.Size = new System.Drawing.Size(14, 15);
            this.lbl_SheetCount.TabIndex = 1;
            this.lbl_SheetCount.Text = "0";
            // 
            // label10
            // 
            this.label10.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.label10.AutoSize = true;
            this.label10.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.label10.Location = new System.Drawing.Point(566, 9);
            this.label10.Name = "label10";
            this.label10.Size = new System.Drawing.Size(107, 15);
            this.label10.TabIndex = 1;
            this.label10.Text = "Доступно листов:";
            // 
            // rb_BrowserOn
            // 
            this.rb_BrowserOn.AutoSize = true;
            this.rb_BrowserOn.Location = new System.Drawing.Point(12, 12);
            this.rb_BrowserOn.Name = "rb_BrowserOn";
            this.rb_BrowserOn.Size = new System.Drawing.Size(91, 19);
            this.rb_BrowserOn.TabIndex = 10;
            this.rb_BrowserOn.TabStop = true;
            this.rb_BrowserOn.Text = "браузер вкл";
            this.rb_BrowserOn.UseVisualStyleBackColor = true;
            this.rb_BrowserOn.Visible = false;
            this.rb_BrowserOn.CheckedChanged += new System.EventHandler(this.rb_BrowserOn_CheckedChanged);
            // 
            // rb_BrowserOff
            // 
            this.rb_BrowserOff.AutoSize = true;
            this.rb_BrowserOff.Location = new System.Drawing.Point(109, 12);
            this.rb_BrowserOff.Name = "rb_BrowserOff";
            this.rb_BrowserOff.Size = new System.Drawing.Size(100, 19);
            this.rb_BrowserOff.TabIndex = 10;
            this.rb_BrowserOff.TabStop = true;
            this.rb_BrowserOff.Text = "браузер выкл";
            this.rb_BrowserOff.UseVisualStyleBackColor = true;
            this.rb_BrowserOff.Visible = false;
            this.rb_BrowserOff.CheckedChanged += new System.EventHandler(this.rb_BrowserOff_CheckedChanged);
            // 
            // frm_Main
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(814, 450);
            this.Controls.Add(this.rb_BrowserOff);
            this.Controls.Add(this.rb_BrowserOn);
            this.Controls.Add(this.btn_Close);
            this.Controls.Add(this.tabControl1);
            this.Controls.Add(this.label10);
            this.Controls.Add(this.lbl_SheetCount);
            this.Controls.Add(this.lbl_Login);
            this.Name = "frm_Main";
            this.Text = "Form1";
            this.FormClosed += new System.Windows.Forms.FormClosedEventHandler(this.frm_Main_FormClosed);
            this.Load += new System.EventHandler(this.frm_Main_Load);
            this.Shown += new System.EventHandler(this.frm_Main_Shown);
            this.tabControl1.ResumeLayout(false);
            this.tp_Order.ResumeLayout(false);
            this.tp_Order.PerformLayout();
            this.tp_OrderList.ResumeLayout(false);
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgv_Orders)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.bs_Orders)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.TabControl tabControl1;
        private System.Windows.Forms.TabPage tp_Order;
        private System.Windows.Forms.TabPage tp_OrderList;
        private System.Windows.Forms.Button btn_Close;
        private System.Windows.Forms.DataGridView dgv_Orders;
        private System.Windows.Forms.BindingSource bs_Orders;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.TextBox tb_OrderStreet;
        private System.Windows.Forms.TextBox tb_OrderFlat;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox tb_OrderHome;
        private System.Windows.Forms.TextBox tb_OrderLocation;
        private System.Windows.Forms.TextBox tb_OrderDistrict;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox tb_OrderRegion;
        private System.Windows.Forms.Button btn_OrderClearValues;
        private System.Windows.Forms.Button btn_OrderSend;
        private System.Windows.Forms.Button btn_OrdersRefresh;
        private System.Windows.Forms.DataGridViewTextBoxColumn dgvc_Number;
        private System.Windows.Forms.DataGridViewTextBoxColumn dgvc_DateCreate;
        private System.Windows.Forms.DataGridViewTextBoxColumn dgvc_State;
        private System.Windows.Forms.DataGridViewButtonColumn dgvc_Download;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.DateTimePicker dtp_Begin;
        private System.Windows.Forms.Label lbl_Login;
        private System.Windows.Forms.Label lbl_SheetCount;
        private System.Windows.Forms.Label label10;
        private System.Windows.Forms.ProgressBar pb_Load;
        private System.Windows.Forms.Label lbl_Load;
        private System.Windows.Forms.RadioButton rb_BrowserOn;
        private System.Windows.Forms.RadioButton rb_BrowserOff;
        private System.Windows.Forms.Button btn_RossLogin;
        private System.Windows.Forms.Button btn_ClearSession;
        private System.Windows.Forms.Label lbl_key;
        private System.Windows.Forms.TextBox tb_OrderNumber;
        private System.Windows.Forms.Label label9;
        private System.Windows.Forms.GroupBox groupBox1;
    }
}
