namespace thepos
{
    partial class frmReportList1
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
            this.btnNext = new System.Windows.Forms.Button();
            this.btnPrev = new System.Windows.Forms.Button();
            this.btnView = new System.Windows.Forms.Button();
            this.lblYYYYMM = new System.Windows.Forms.Label();
            this.lblReportTitle = new System.Windows.Forms.Label();
            this.lvwList = new System.Windows.Forms.ListView();
            this.biz_dt = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.c1 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.c2 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.c3 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.c4 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.tvwList = new System.Windows.Forms.TreeView();
            this.lblListPath = new System.Windows.Forms.Label();
            this.c5 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.SuspendLayout();
            // 
            // btnNext
            // 
            this.btnNext.BackColor = System.Drawing.Color.White;
            this.btnNext.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnNext.Font = new System.Drawing.Font("굴림", 8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.btnNext.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(68)))), ((int)(((byte)(87)))), ((int)(((byte)(96)))));
            this.btnNext.Location = new System.Drawing.Point(395, 27);
            this.btnNext.Name = "btnNext";
            this.btnNext.Size = new System.Drawing.Size(40, 27);
            this.btnNext.TabIndex = 82;
            this.btnNext.TabStop = false;
            this.btnNext.Text = "▶";
            this.btnNext.UseVisualStyleBackColor = false;
            this.btnNext.Click += new System.EventHandler(this.btnNext_Click);
            // 
            // btnPrev
            // 
            this.btnPrev.BackColor = System.Drawing.Color.White;
            this.btnPrev.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnPrev.Font = new System.Drawing.Font("굴림", 8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.btnPrev.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(68)))), ((int)(((byte)(87)))), ((int)(((byte)(96)))));
            this.btnPrev.Location = new System.Drawing.Point(222, 27);
            this.btnPrev.Name = "btnPrev";
            this.btnPrev.Size = new System.Drawing.Size(40, 27);
            this.btnPrev.TabIndex = 81;
            this.btnPrev.TabStop = false;
            this.btnPrev.Text = "◀";
            this.btnPrev.UseVisualStyleBackColor = false;
            this.btnPrev.Click += new System.EventHandler(this.btnPrev_Click);
            // 
            // btnView
            // 
            this.btnView.BackColor = System.Drawing.Color.White;
            this.btnView.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnView.Font = new System.Drawing.Font("굴림", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.btnView.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(68)))), ((int)(((byte)(87)))), ((int)(((byte)(96)))));
            this.btnView.Location = new System.Drawing.Point(460, 26);
            this.btnView.Name = "btnView";
            this.btnView.Size = new System.Drawing.Size(100, 29);
            this.btnView.TabIndex = 80;
            this.btnView.Text = "조회";
            this.btnView.UseVisualStyleBackColor = false;
            this.btnView.Click += new System.EventHandler(this.btnView_Click);
            // 
            // lblYYYYMM
            // 
            this.lblYYYYMM.BackColor = System.Drawing.Color.White;
            this.lblYYYYMM.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.lblYYYYMM.Font = new System.Drawing.Font("굴림", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.lblYYYYMM.Location = new System.Drawing.Point(269, 27);
            this.lblYYYYMM.Name = "lblYYYYMM";
            this.lblYYYYMM.Size = new System.Drawing.Size(120, 27);
            this.lblYYYYMM.TabIndex = 79;
            this.lblYYYYMM.Text = "2023-10";
            this.lblYYYYMM.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // lblReportTitle
            // 
            this.lblReportTitle.AutoSize = true;
            this.lblReportTitle.Font = new System.Drawing.Font("굴림", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.lblReportTitle.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(68)))), ((int)(((byte)(87)))), ((int)(((byte)(96)))));
            this.lblReportTitle.Location = new System.Drawing.Point(25, 33);
            this.lblReportTitle.Name = "lblReportTitle";
            this.lblReportTitle.Size = new System.Drawing.Size(91, 14);
            this.lblReportTitle.TabIndex = 78;
            this.lblReportTitle.Text = "월별매출목록";
            this.lblReportTitle.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // lvwList
            // 
            this.lvwList.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this.biz_dt,
            this.c1,
            this.c2,
            this.c3,
            this.c4,
            this.c5});
            this.lvwList.Font = new System.Drawing.Font("굴림", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.lvwList.FullRowSelect = true;
            this.lvwList.GridLines = true;
            this.lvwList.HeaderStyle = System.Windows.Forms.ColumnHeaderStyle.Nonclickable;
            this.lvwList.HideSelection = false;
            this.lvwList.Location = new System.Drawing.Point(222, 102);
            this.lvwList.MultiSelect = false;
            this.lvwList.Name = "lvwList";
            this.lvwList.Size = new System.Drawing.Size(558, 578);
            this.lvwList.TabIndex = 87;
            this.lvwList.UseCompatibleStateImageBehavior = false;
            this.lvwList.View = System.Windows.Forms.View.Details;
            // 
            // biz_dt
            // 
            this.biz_dt.Text = "영업일자";
            this.biz_dt.Width = 90;
            // 
            // c1
            // 
            this.c1.Text = "수량";
            this.c1.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            this.c1.Width = 90;
            // 
            // c2
            // 
            this.c2.Text = "상품금액";
            this.c2.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            this.c2.Width = 90;
            // 
            // c3
            // 
            this.c3.Text = "할인금액";
            this.c3.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            this.c3.Width = 90;
            // 
            // c4
            // 
            this.c4.Text = "매출금액";
            this.c4.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            this.c4.Width = 90;
            // 
            // tvwList
            // 
            this.tvwList.Location = new System.Drawing.Point(20, 102);
            this.tvwList.Name = "tvwList";
            this.tvwList.Size = new System.Drawing.Size(196, 578);
            this.tvwList.TabIndex = 90;
            this.tvwList.AfterSelect += new System.Windows.Forms.TreeViewEventHandler(this.tvwList_AfterSelect);
            // 
            // lblListPath
            // 
            this.lblListPath.AutoSize = true;
            this.lblListPath.Location = new System.Drawing.Point(225, 73);
            this.lblListPath.Name = "lblListPath";
            this.lblListPath.Size = new System.Drawing.Size(13, 12);
            this.lblListPath.TabIndex = 91;
            this.lblListPath.Text = ">";
            // 
            // c5
            // 
            this.c5.Text = "";
            this.c5.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            this.c5.Width = 90;
            // 
            // frmReportList1
            // 
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.None;
            this.ClientSize = new System.Drawing.Size(800, 700);
            this.Controls.Add(this.lblListPath);
            this.Controls.Add(this.tvwList);
            this.Controls.Add(this.lvwList);
            this.Controls.Add(this.btnNext);
            this.Controls.Add(this.btnPrev);
            this.Controls.Add(this.btnView);
            this.Controls.Add(this.lblYYYYMM);
            this.Controls.Add(this.lblReportTitle);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Name = "frmReportList1";
            this.Text = "frmReportList1";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.Button btnNext;
        private System.Windows.Forms.Button btnPrev;
        private System.Windows.Forms.Button btnView;
        private System.Windows.Forms.Label lblYYYYMM;
        private System.Windows.Forms.Label lblReportTitle;
        private System.Windows.Forms.ListView lvwList;
        private System.Windows.Forms.TreeView tvwList;
        private System.Windows.Forms.ColumnHeader biz_dt;
        private System.Windows.Forms.ColumnHeader c1;
        private System.Windows.Forms.ColumnHeader c2;
        private System.Windows.Forms.ColumnHeader c3;
        private System.Windows.Forms.ColumnHeader c4;
        private System.Windows.Forms.Label lblListPath;
        private System.Windows.Forms.ColumnHeader c5;
    }
}