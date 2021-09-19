
namespace DS1
{
    partial class CedulaForm
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
            this.dtgCedulas = new System.Windows.Forms.DataGridView();
            this.addButtom = new System.Windows.Forms.Button();
            this.editButton = new System.Windows.Forms.Button();
            this.buscarButton = new System.Windows.Forms.Button();
            this.tbBuscar = new System.Windows.Forms.TextBox();
            ((System.ComponentModel.ISupportInitialize)(this.dtgCedulas)).BeginInit();
            this.SuspendLayout();
            // 
            // dtgCedulas
            // 
            this.dtgCedulas.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dtgCedulas.Location = new System.Drawing.Point(12, 96);
            this.dtgCedulas.Name = "dtgCedulas";
            this.dtgCedulas.Size = new System.Drawing.Size(776, 342);
            this.dtgCedulas.TabIndex = 0;
            // 
            // addButtom
            // 
            this.addButtom.Location = new System.Drawing.Point(556, 12);
            this.addButtom.Name = "addButtom";
            this.addButtom.Size = new System.Drawing.Size(149, 30);
            this.addButtom.TabIndex = 1;
            this.addButtom.Text = "Agregar";
            this.addButtom.UseVisualStyleBackColor = true;
            this.addButtom.Click += new System.EventHandler(this.addButtom_Click);
            // 
            // editButton
            // 
            this.editButton.Location = new System.Drawing.Point(556, 48);
            this.editButton.Name = "editButton";
            this.editButton.Size = new System.Drawing.Size(149, 30);
            this.editButton.TabIndex = 2;
            this.editButton.Text = "Editar";
            this.editButton.UseVisualStyleBackColor = true;
            // 
            // buscarButton
            // 
            this.buscarButton.Location = new System.Drawing.Point(248, 45);
            this.buscarButton.Name = "buscarButton";
            this.buscarButton.RightToLeft = System.Windows.Forms.RightToLeft.No;
            this.buscarButton.Size = new System.Drawing.Size(127, 23);
            this.buscarButton.TabIndex = 4;
            this.buscarButton.Text = "Buscar";
            this.buscarButton.UseVisualStyleBackColor = true;
            this.buscarButton.Click += new System.EventHandler(this.buscarButton_Click);
            // 
            // tbBuscar
            // 
            this.tbBuscar.Location = new System.Drawing.Point(33, 19);
            this.tbBuscar.Name = "tbBuscar";
            this.tbBuscar.Size = new System.Drawing.Size(342, 20);
            this.tbBuscar.TabIndex = 5;
            // 
            // CedulaForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this.tbBuscar);
            this.Controls.Add(this.buscarButton);
            this.Controls.Add(this.editButton);
            this.Controls.Add(this.addButtom);
            this.Controls.Add(this.dtgCedulas);
            this.Name = "CedulaForm";
            this.Text = "CedulaForm";
            ((System.ComponentModel.ISupportInitialize)(this.dtgCedulas)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.DataGridView dtgCedulas;
        private System.Windows.Forms.Button addButtom;
        private System.Windows.Forms.Button editButton;
        private System.Windows.Forms.Button buscarButton;
        private System.Windows.Forms.TextBox tbBuscar;
    }
}