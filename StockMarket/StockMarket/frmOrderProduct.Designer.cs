namespace StockMarket
{
    partial class frmOrderProduct
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
            this.btnCheck = new System.Windows.Forms.Button();
            this.DGV1 = new System.Windows.Forms.DataGridView();
            this.DGV2 = new System.Windows.Forms.DataGridView();
            this.btnAdd = new System.Windows.Forms.Button();
            this.btnCancel = new System.Windows.Forms.Button();
            this.label1 = new System.Windows.Forms.Label();
            this.dtpOrderDate = new System.Windows.Forms.DateTimePicker();
            this.label2 = new System.Windows.Forms.Label();
            this.lbOrderTime = new System.Windows.Forms.Label();
            this.txtOrderBillNo = new System.Windows.Forms.TextBox();
            this.label4 = new System.Windows.Forms.Label();
            this.button4 = new System.Windows.Forms.Button();
            this.button5 = new System.Windows.Forms.Button();
            this.label5 = new System.Windows.Forms.Label();
            this.lbCount = new System.Windows.Forms.Label();
            this.label7 = new System.Windows.Forms.Label();
            this.timer1 = new System.Windows.Forms.Timer(this.components);
            ((System.ComponentModel.ISupportInitialize)(this.DGV1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.DGV2)).BeginInit();
            this.SuspendLayout();
            // 
            // btnCheck
            // 
            this.btnCheck.Location = new System.Drawing.Point(52, 25);
            this.btnCheck.Name = "btnCheck";
            this.btnCheck.Size = new System.Drawing.Size(193, 31);
            this.btnCheck.TabIndex = 0;
            this.btnCheck.Text = "ກວດສອບສິນຄ້າ";
            this.btnCheck.UseVisualStyleBackColor = true;
            this.btnCheck.Click += new System.EventHandler(this.btnCheck_Click);
            // 
            // DGV1
            // 
            this.DGV1.BackgroundColor = System.Drawing.Color.White;
            this.DGV1.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.DGV1.GridColor = System.Drawing.Color.Red;
            this.DGV1.Location = new System.Drawing.Point(34, 75);
            this.DGV1.Name = "DGV1";
            this.DGV1.Size = new System.Drawing.Size(760, 150);
            this.DGV1.TabIndex = 1;
            this.DGV1.Click += new System.EventHandler(this.DGV1_Click);
            // 
            // DGV2
            // 
            this.DGV2.BackgroundColor = System.Drawing.Color.White;
            this.DGV2.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.DGV2.GridColor = System.Drawing.Color.Red;
            this.DGV2.Location = new System.Drawing.Point(24, 302);
            this.DGV2.Name = "DGV2";
            this.DGV2.Size = new System.Drawing.Size(760, 150);
            this.DGV2.TabIndex = 2;
            this.DGV2.Click += new System.EventHandler(this.DGV2_Click);
            this.DGV2.DoubleClick += new System.EventHandler(this.DGV2_DoubleClick);
            // 
            // btnAdd
            // 
            this.btnAdd.Location = new System.Drawing.Point(34, 246);
            this.btnAdd.Name = "btnAdd";
            this.btnAdd.Size = new System.Drawing.Size(193, 31);
            this.btnAdd.TabIndex = 3;
            this.btnAdd.Text = "ສັ່ງຊື້ສິນຄ້າ";
            this.btnAdd.UseVisualStyleBackColor = true;
            this.btnAdd.Click += new System.EventHandler(this.btnAdd_Click);
            // 
            // btnCancel
            // 
            this.btnCancel.Location = new System.Drawing.Point(233, 246);
            this.btnCancel.Name = "btnCancel";
            this.btnCancel.Size = new System.Drawing.Size(193, 31);
            this.btnCancel.TabIndex = 4;
            this.btnCancel.Text = "ຍົກເລີກສັ່ງຊື້ສິນຄ້າ";
            this.btnCancel.UseVisualStyleBackColor = true;
            this.btnCancel.Click += new System.EventHandler(this.btnCancel_Click);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(355, 21);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(41, 24);
            this.label1.TabIndex = 5;
            this.label1.Text = "ວັນທີ";
            // 
            // dtpOrderDate
            // 
            this.dtpOrderDate.Format = System.Windows.Forms.DateTimePickerFormat.Short;
            this.dtpOrderDate.Location = new System.Drawing.Point(415, 18);
            this.dtpOrderDate.Name = "dtpOrderDate";
            this.dtpOrderDate.Size = new System.Drawing.Size(126, 35);
            this.dtpOrderDate.TabIndex = 6;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(584, 25);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(44, 24);
            this.label2.TabIndex = 7;
            this.label2.Text = "ເວລາ";
            // 
            // lbOrderTime
            // 
            this.lbOrderTime.AutoSize = true;
            this.lbOrderTime.Location = new System.Drawing.Point(655, 25);
            this.lbOrderTime.Name = "lbOrderTime";
            this.lbOrderTime.Size = new System.Drawing.Size(54, 24);
            this.lbOrderTime.TabIndex = 8;
            this.lbOrderTime.Text = "label3";
            // 
            // txtOrderBillNo
            // 
            this.txtOrderBillNo.Location = new System.Drawing.Point(580, 242);
            this.txtOrderBillNo.Name = "txtOrderBillNo";
            this.txtOrderBillNo.Size = new System.Drawing.Size(100, 35);
            this.txtOrderBillNo.TabIndex = 9;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(461, 249);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(113, 24);
            this.label4.TabIndex = 10;
            this.label4.Text = "ເລກທີໃນບິນສັງຊື";
            // 
            // button4
            // 
            this.button4.Location = new System.Drawing.Point(34, 523);
            this.button4.Name = "button4";
            this.button4.Size = new System.Drawing.Size(193, 31);
            this.button4.TabIndex = 11;
            this.button4.Text = "ບັນທຶກ";
            this.button4.UseVisualStyleBackColor = true;
            this.button4.Click += new System.EventHandler(this.button4_Click);
            // 
            // button5
            // 
            this.button5.Location = new System.Drawing.Point(233, 523);
            this.button5.Name = "button5";
            this.button5.Size = new System.Drawing.Size(193, 31);
            this.button5.TabIndex = 12;
            this.button5.Text = "ອອກ";
            this.button5.UseVisualStyleBackColor = true;
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(30, 475);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(186, 24);
            this.label5.TabIndex = 13;
            this.label5.Text = "ຈຳນວນລາຍການສັ່ງຊື້ທັງໝົດ";
            // 
            // lbCount
            // 
            this.lbCount.AutoSize = true;
            this.lbCount.Location = new System.Drawing.Point(222, 475);
            this.lbCount.Name = "lbCount";
            this.lbCount.Size = new System.Drawing.Size(19, 24);
            this.lbCount.TabIndex = 14;
            this.lbCount.Text = "0";
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Location = new System.Drawing.Point(291, 475);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(66, 24);
            this.label7.TabIndex = 15;
            this.label7.Text = "ລາຍການ";
            // 
            // timer1
            // 
            this.timer1.Tick += new System.EventHandler(this.timer1_Tick);
            // 
            // frmOrderProduct
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(9F, 24F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(848, 566);
            this.Controls.Add(this.label7);
            this.Controls.Add(this.lbCount);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.button5);
            this.Controls.Add(this.button4);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.txtOrderBillNo);
            this.Controls.Add(this.lbOrderTime);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.dtpOrderDate);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.btnCancel);
            this.Controls.Add(this.btnAdd);
            this.Controls.Add(this.DGV2);
            this.Controls.Add(this.DGV1);
            this.Controls.Add(this.btnCheck);
            this.Font = new System.Drawing.Font("Saysettha OT", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(222)));
            this.Margin = new System.Windows.Forms.Padding(4, 6, 4, 6);
            this.Name = "frmOrderProduct";
            this.Text = "ຟອມາສັ່ງຊື້ສິນຄ້າ";
            this.Load += new System.EventHandler(this.frmOrderProduct_Load);
            ((System.ComponentModel.ISupportInitialize)(this.DGV1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.DGV2)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button btnCheck;
        private System.Windows.Forms.DataGridView DGV1;
        private System.Windows.Forms.DataGridView DGV2;
        private System.Windows.Forms.Button btnAdd;
        private System.Windows.Forms.Button btnCancel;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.DateTimePicker dtpOrderDate;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label lbOrderTime;
        private System.Windows.Forms.TextBox txtOrderBillNo;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Button button4;
        private System.Windows.Forms.Button button5;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label lbCount;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.Timer timer1;
    }
}