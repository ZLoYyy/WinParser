namespace WinParser
{
    partial class Frm_CreateOrderList
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
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
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            this.btn_Cancel = new System.Windows.Forms.Button();
            this.btn_Apply = new System.Windows.Forms.Button();
            this.bs_Orders = new System.Windows.Forms.BindingSource(this.components);
            this.dgv_Orders = new System.Windows.Forms.DataGridView();
            this.dgvc_Checked = new System.Windows.Forms.DataGridViewCheckBoxColumn();
            this.dgvcCadastralNumber = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dgvc_FullAdderess = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dgvc_TypeObject = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dgvc_Square = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dgvc_CategoryZU = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dgvc_TypeZU = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dgvc_Purpose = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.cbx_SelectAll = new System.Windows.Forms.CheckBox();
            ((System.ComponentModel.ISupportInitialize)(this.bs_Orders)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dgv_Orders)).BeginInit();
            this.SuspendLayout();
            // 
            // btn_Cancel
            // 
            this.btn_Cancel.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.btn_Cancel.Location = new System.Drawing.Point(713, 415);
            this.btn_Cancel.Name = "btn_Cancel";
            this.btn_Cancel.Size = new System.Drawing.Size(75, 23);
            this.btn_Cancel.TabIndex = 0;
            this.btn_Cancel.Text = "Отмена";
            this.btn_Cancel.UseVisualStyleBackColor = true;
            this.btn_Cancel.Click += new System.EventHandler(this.btn_Cancel_Click);
            // 
            // btn_Apply
            // 
            this.btn_Apply.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.btn_Apply.Location = new System.Drawing.Point(619, 415);
            this.btn_Apply.Name = "btn_Apply";
            this.btn_Apply.Size = new System.Drawing.Size(88, 23);
            this.btn_Apply.TabIndex = 0;
            this.btn_Apply.Text = "Применить";
            this.btn_Apply.UseVisualStyleBackColor = true;
            this.btn_Apply.Click += new System.EventHandler(this.btn_Apply_Click);
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
            this.dgvc_Checked,
            this.dgvcCadastralNumber,
            this.dgvc_FullAdderess,
            this.dgvc_TypeObject,
            this.dgvc_Square,
            this.dgvc_CategoryZU,
            this.dgvc_TypeZU,
            this.dgvc_Purpose});
            this.dgv_Orders.Location = new System.Drawing.Point(8, 42);
            this.dgv_Orders.Name = "dgv_Orders";
            this.dgv_Orders.RowHeadersVisible = false;
            this.dgv_Orders.RowHeadersWidthSizeMode = System.Windows.Forms.DataGridViewRowHeadersWidthSizeMode.AutoSizeToAllHeaders;
            this.dgv_Orders.RowTemplate.Height = 25;
            this.dgv_Orders.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dgv_Orders.Size = new System.Drawing.Size(784, 367);
            this.dgv_Orders.TabIndex = 1;
            // 
            // dgvc_Checked
            // 
            this.dgvc_Checked.HeaderText = "Выбрать";
            this.dgvc_Checked.Name = "dgvc_Checked";
            // 
            // dgvcCadastralNumber
            // 
            this.dgvcCadastralNumber.DataPropertyName = "CadastralNumber";
            this.dgvcCadastralNumber.HeaderText = "Кадастровый номер";
            this.dgvcCadastralNumber.Name = "dgvcCadastralNumber";
            // 
            // dgvc_FullAdderess
            // 
            this.dgvc_FullAdderess.DataPropertyName = "FullAdderess";
            this.dgvc_FullAdderess.HeaderText = "Полный адрес";
            this.dgvc_FullAdderess.Name = "dgvc_FullAdderess";
            // 
            // dgvc_TypeObject
            // 
            this.dgvc_TypeObject.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
            this.dgvc_TypeObject.DataPropertyName = "TypeObject";
            this.dgvc_TypeObject.HeaderText = "Тип обьекта";
            this.dgvc_TypeObject.Name = "dgvc_TypeObject";
            // 
            // dgvc_Square
            // 
            this.dgvc_Square.DataPropertyName = "Square";
            this.dgvc_Square.HeaderText = "Площадь";
            this.dgvc_Square.Name = "dgvc_Square";
            // 
            // dgvc_CategoryZU
            // 
            this.dgvc_CategoryZU.DataPropertyName = "CategoryZU";
            this.dgvc_CategoryZU.HeaderText = "Категория ЗУ";
            this.dgvc_CategoryZU.Name = "dgvc_CategoryZU";
            // 
            // dgvc_TypeZU
            // 
            this.dgvc_TypeZU.DataPropertyName = "TypeZU";
            this.dgvc_TypeZU.HeaderText = "Вид разрешенного использования ЗУ";
            this.dgvc_TypeZU.Name = "dgvc_TypeZU";
            // 
            // dgvc_Purpose
            // 
            this.dgvc_Purpose.DataPropertyName = "Purpose";
            this.dgvc_Purpose.HeaderText = "Назначение здания или помещения";
            this.dgvc_Purpose.Name = "dgvc_Purpose";
            // 
            // cbx_SelectAll
            // 
            this.cbx_SelectAll.AutoSize = true;
            this.cbx_SelectAll.Location = new System.Drawing.Point(8, 17);
            this.cbx_SelectAll.Name = "cbx_SelectAll";
            this.cbx_SelectAll.Size = new System.Drawing.Size(94, 19);
            this.cbx_SelectAll.TabIndex = 2;
            this.cbx_SelectAll.Text = "Выбрать всё";
            this.cbx_SelectAll.UseVisualStyleBackColor = true;
            this.cbx_SelectAll.CheckedChanged += new System.EventHandler(this.cbx_SelectAll_CheckedChanged);
            // 
            // Frm_CreateOrderList
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this.cbx_SelectAll);
            this.Controls.Add(this.dgv_Orders);
            this.Controls.Add(this.btn_Apply);
            this.Controls.Add(this.btn_Cancel);
            this.Name = "Frm_CreateOrderList";
            this.Text = "Frm_CreateOrderList";
            this.Load += new System.EventHandler(this.Frm_CreateOrderList_Load);
            ((System.ComponentModel.ISupportInitialize)(this.bs_Orders)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dgv_Orders)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button btn_Cancel;
        private System.Windows.Forms.Button btn_Apply;
        private System.Windows.Forms.BindingSource bs_Orders;
        private System.Windows.Forms.DataGridView dgv_Orders;
        private System.Windows.Forms.DataGridViewCheckBoxColumn dgvc_Checked;
        private System.Windows.Forms.DataGridViewTextBoxColumn dgvcCadastralNumber;
        private System.Windows.Forms.DataGridViewTextBoxColumn dgvc_FullAdderess;
        private System.Windows.Forms.DataGridViewTextBoxColumn dgvc_TypeObject;
        private System.Windows.Forms.DataGridViewTextBoxColumn dgvc_Square;
        private System.Windows.Forms.DataGridViewTextBoxColumn dgvc_CategoryZU;
        private System.Windows.Forms.DataGridViewTextBoxColumn dgvc_TypeZU;
        private System.Windows.Forms.DataGridViewTextBoxColumn dgvc_Purpose;
        private System.Windows.Forms.CheckBox cbx_SelectAll;
    }
}