
namespace CarDealer_PracticeExam
{
    partial class NewCarForm
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
            this.cbManufacturer = new System.Windows.Forms.ComboBox();
            this.tbModel = new System.Windows.Forms.TextBox();
            this.tbPrice = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.btnAddCar = new System.Windows.Forms.Button();
            this.errorProvider = new System.Windows.Forms.ErrorProvider(this.components);
            this.dtpManufacturingDate = new System.Windows.Forms.DateTimePicker();
            ((System.ComponentModel.ISupportInitialize)(this.errorProvider)).BeginInit();
            this.SuspendLayout();
            // 
            // cbManufacturer
            // 
            this.cbManufacturer.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cbManufacturer.FormattingEnabled = true;
            this.cbManufacturer.Location = new System.Drawing.Point(700, 159);
            this.cbManufacturer.Name = "cbManufacturer";
            this.cbManufacturer.Size = new System.Drawing.Size(248, 39);
            this.cbManufacturer.TabIndex = 0;
            this.cbManufacturer.Validating += new System.ComponentModel.CancelEventHandler(this.cbManufacturer_Validating);
            this.cbManufacturer.Validated += new System.EventHandler(this.cbManufacturer_Validated);
            // 
            // tbModel
            // 
            this.tbModel.Location = new System.Drawing.Point(700, 270);
            this.tbModel.Name = "tbModel";
            this.tbModel.Size = new System.Drawing.Size(321, 38);
            this.tbModel.TabIndex = 1;
            this.tbModel.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.tbModel_KeyPress);
            this.tbModel.Validating += new System.ComponentModel.CancelEventHandler(this.tbModel_Validating);
            this.tbModel.Validated += new System.EventHandler(this.tbModel_Validated);
            // 
            // tbPrice
            // 
            this.tbPrice.Location = new System.Drawing.Point(700, 483);
            this.tbPrice.Name = "tbPrice";
            this.tbPrice.Size = new System.Drawing.Size(171, 38);
            this.tbPrice.TabIndex = 3;
            this.tbPrice.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.tbPrice_KeyPress);
            this.tbPrice.Validating += new System.ComponentModel.CancelEventHandler(this.tbPrice_Validating);
            this.tbPrice.Validated += new System.EventHandler(this.tbPrice_Validated);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(370, 159);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(182, 32);
            this.label1.TabIndex = 4;
            this.label1.Text = "Manufacturer";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(370, 270);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(93, 32);
            this.label2.TabIndex = 5;
            this.label2.Text = "Model";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(370, 367);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(160, 32);
            this.label3.TabIndex = 6;
            this.label3.Text = "Model Year";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(370, 483);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(80, 32);
            this.label4.TabIndex = 7;
            this.label4.Text = "Price";
            // 
            // btnAddCar
            // 
            this.btnAddCar.DialogResult = System.Windows.Forms.DialogResult.OK;
            this.btnAddCar.Location = new System.Drawing.Point(700, 674);
            this.btnAddCar.Name = "btnAddCar";
            this.btnAddCar.Size = new System.Drawing.Size(200, 91);
            this.btnAddCar.TabIndex = 8;
            this.btnAddCar.Text = "OK";
            this.btnAddCar.UseVisualStyleBackColor = true;
            this.btnAddCar.Click += new System.EventHandler(this.btnAddCar_Click);
            // 
            // errorProvider
            // 
            this.errorProvider.ContainerControl = this;
            // 
            // dtpManufacturingDate
            // 
            this.dtpManufacturingDate.Location = new System.Drawing.Point(700, 367);
            this.dtpManufacturingDate.Name = "dtpManufacturingDate";
            this.dtpManufacturingDate.Size = new System.Drawing.Size(473, 38);
            this.dtpManufacturingDate.TabIndex = 2;
            this.dtpManufacturingDate.Validating += new System.ComponentModel.CancelEventHandler(this.dtpManufacturingDate_Validating);
            this.dtpManufacturingDate.Validated += new System.EventHandler(this.dtpManufacturingDate_Validated);
            // 
            // NewCarForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(16F, 31F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.AutoValidate = System.Windows.Forms.AutoValidate.EnableAllowFocusChange;
            this.ClientSize = new System.Drawing.Size(1297, 916);
            this.Controls.Add(this.btnAddCar);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.tbPrice);
            this.Controls.Add(this.dtpManufacturingDate);
            this.Controls.Add(this.tbModel);
            this.Controls.Add(this.cbManufacturer);
            this.Name = "NewCarForm";
            this.Text = "NewCarForm";
            this.Load += new System.EventHandler(this.NewCarForm_Load);
            ((System.ComponentModel.ISupportInitialize)(this.errorProvider)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.ComboBox cbManufacturer;
        private System.Windows.Forms.TextBox tbModel;
        private System.Windows.Forms.TextBox tbPrice;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Button btnAddCar;
        private System.Windows.Forms.ErrorProvider errorProvider;
        private System.Windows.Forms.DateTimePicker dtpManufacturingDate;
    }
}