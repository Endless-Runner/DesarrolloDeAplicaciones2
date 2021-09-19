
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
            this.DelButtom = new System.Windows.Forms.Button();
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
            this.addButtom.Location = new System.Drawing.Point(111, 42);
            this.addButtom.Name = "addButtom";
            this.addButtom.Size = new System.Drawing.Size(75, 23);
            this.addButtom.TabIndex = 1;
            this.addButtom.Text = "Agregar";
            this.addButtom.UseVisualStyleBackColor = true;
            this.addButtom.Click += new System.EventHandler(this.addButtom_Click);
            // 
            // editButton
            // 
            this.editButton.Location = new System.Drawing.Point(386, 41);
            this.editButton.Name = "editButton";
            this.editButton.Size = new System.Drawing.Size(75, 23);
            this.editButton.TabIndex = 2;
            this.editButton.Text = "Editar";
            this.editButton.UseVisualStyleBackColor = true;
            // 
            // DelButtom
            // 
            this.DelButtom.Location = new System.Drawing.Point(638, 42);
            this.DelButtom.Name = "DelButtom";
            this.DelButtom.Size = new System.Drawing.Size(75, 23);
            this.DelButtom.TabIndex = 3;
            this.DelButtom.Text = "Eliminar";
            this.DelButtom.UseVisualStyleBackColor = true;
            // 
            // CedulaForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this.DelButtom);
            this.Controls.Add(this.editButton);
            this.Controls.Add(this.addButtom);
            this.Controls.Add(this.dtgCedulas);
            this.Name = "CedulaForm";
            this.Text = "CedulaForm";
            ((System.ComponentModel.ISupportInitialize)(this.dtgCedulas)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.DataGridView dtgCedulas;
        private System.Windows.Forms.Button addButtom;
        private System.Windows.Forms.Button editButton;
        private System.Windows.Forms.Button DelButtom;
    }
}