
namespace Minotaur_Maze_Mashup
{
    partial class LoginForm
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
            this.pnlUsername = new System.Windows.Forms.Panel();
            this.pbUsername = new System.Windows.Forms.PictureBox();
            this.txtUsername = new System.Windows.Forms.TextBox();
            this.pnlPassword = new System.Windows.Forms.Panel();
            this.pbPassword = new System.Windows.Forms.PictureBox();
            this.txtPassword = new System.Windows.Forms.TextBox();
            this.btnLogin = new System.Windows.Forms.Button();
            this.btnSignUp = new System.Windows.Forms.Button();
            this.txtForename = new System.Windows.Forms.TextBox();
            this.txtSurname = new System.Windows.Forms.TextBox();
            this.txtEmail = new System.Windows.Forms.TextBox();
            this.txtPasswordRegister = new System.Windows.Forms.TextBox();
            this.txtUsernameRegister = new System.Windows.Forms.TextBox();
            this.pbUser = new System.Windows.Forms.PictureBox();
            this.btnRegister = new System.Windows.Forms.Button();
            this.pbLogo = new System.Windows.Forms.PictureBox();
            this.pbMicrophone = new System.Windows.Forms.PictureBox();
            this.ForenameError = new System.Windows.Forms.ErrorProvider(this.components);
            this.SurnameError = new System.Windows.Forms.ErrorProvider(this.components);
            this.EmailError = new System.Windows.Forms.ErrorProvider(this.components);
            this.UsernameRegisterError = new System.Windows.Forms.ErrorProvider(this.components);
            this.PasswordRegisterError = new System.Windows.Forms.ErrorProvider(this.components);
            this.pbArrow = new System.Windows.Forms.PictureBox();
            this.ttForename = new System.Windows.Forms.ToolTip(this.components);
            this.pnlUsername.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pbUsername)).BeginInit();
            this.pnlPassword.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pbPassword)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pbUser)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pbLogo)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pbMicrophone)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.ForenameError)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.SurnameError)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.EmailError)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.UsernameRegisterError)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.PasswordRegisterError)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pbArrow)).BeginInit();
            this.SuspendLayout();
            // 
            // pnlUsername
            // 
            this.pnlUsername.BackColor = System.Drawing.SystemColors.ScrollBar;
            this.pnlUsername.Controls.Add(this.pbUsername);
            this.pnlUsername.Controls.Add(this.txtUsername);
            this.pnlUsername.Location = new System.Drawing.Point(274, 229);
            this.pnlUsername.Name = "pnlUsername";
            this.pnlUsername.Size = new System.Drawing.Size(276, 53);
            this.pnlUsername.TabIndex = 0;
            // 
            // pbUsername
            // 
            this.pbUsername.Image = global::Minotaur_Maze_Mashup.Properties.Resources.usernameIcon;
            this.pbUsername.Location = new System.Drawing.Point(4, 4);
            this.pbUsername.Name = "pbUsername";
            this.pbUsername.Size = new System.Drawing.Size(44, 42);
            this.pbUsername.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.pbUsername.TabIndex = 1;
            this.pbUsername.TabStop = false;
            // 
            // txtUsername
            // 
            this.txtUsername.BackColor = System.Drawing.SystemColors.ScrollBar;
            this.txtUsername.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.txtUsername.Font = new System.Drawing.Font("Segoe UI", 18F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.txtUsername.Location = new System.Drawing.Point(53, 7);
            this.txtUsername.MaxLength = 999;
            this.txtUsername.Name = "txtUsername";
            this.txtUsername.PlaceholderText = "Username";
            this.txtUsername.Size = new System.Drawing.Size(220, 32);
            this.txtUsername.TabIndex = 0;
            // 
            // pnlPassword
            // 
            this.pnlPassword.BackColor = System.Drawing.SystemColors.ScrollBar;
            this.pnlPassword.Controls.Add(this.pbPassword);
            this.pnlPassword.Controls.Add(this.txtPassword);
            this.pnlPassword.Location = new System.Drawing.Point(274, 298);
            this.pnlPassword.Name = "pnlPassword";
            this.pnlPassword.Size = new System.Drawing.Size(276, 53);
            this.pnlPassword.TabIndex = 1;
            // 
            // pbPassword
            // 
            this.pbPassword.Image = global::Minotaur_Maze_Mashup.Properties.Resources.passwordIcon;
            this.pbPassword.Location = new System.Drawing.Point(4, 5);
            this.pbPassword.Name = "pbPassword";
            this.pbPassword.Size = new System.Drawing.Size(44, 42);
            this.pbPassword.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.pbPassword.TabIndex = 3;
            this.pbPassword.TabStop = false;
            // 
            // txtPassword
            // 
            this.txtPassword.BackColor = System.Drawing.SystemColors.ScrollBar;
            this.txtPassword.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.txtPassword.Font = new System.Drawing.Font("Segoe UI", 18F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.txtPassword.Location = new System.Drawing.Point(53, 8);
            this.txtPassword.MaxLength = 999;
            this.txtPassword.Name = "txtPassword";
            this.txtPassword.PlaceholderText = "Password";
            this.txtPassword.Size = new System.Drawing.Size(220, 32);
            this.txtPassword.TabIndex = 2;
            this.txtPassword.UseSystemPasswordChar = true;
            // 
            // btnLogin
            // 
            this.btnLogin.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(112)))), ((int)(((byte)(173)))), ((int)(((byte)(71)))));
            this.btnLogin.FlatAppearance.BorderSize = 0;
            this.btnLogin.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnLogin.Font = new System.Drawing.Font("Microsoft Sans Serif", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.btnLogin.Location = new System.Drawing.Point(318, 450);
            this.btnLogin.Name = "btnLogin";
            this.btnLogin.Size = new System.Drawing.Size(200, 47);
            this.btnLogin.TabIndex = 2;
            this.btnLogin.Text = "Login";
            this.btnLogin.UseVisualStyleBackColor = false;
            this.btnLogin.Click += new System.EventHandler(this.btnLogin_Click);
            // 
            // btnSignUp
            // 
            this.btnSignUp.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(68)))), ((int)(((byte)(114)))), ((int)(((byte)(196)))));
            this.btnSignUp.FlatAppearance.BorderSize = 0;
            this.btnSignUp.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnSignUp.Font = new System.Drawing.Font("Microsoft Sans Serif", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.btnSignUp.Location = new System.Drawing.Point(318, 513);
            this.btnSignUp.Name = "btnSignUp";
            this.btnSignUp.Size = new System.Drawing.Size(200, 47);
            this.btnSignUp.TabIndex = 3;
            this.btnSignUp.Text = "Sign Up";
            this.btnSignUp.UseVisualStyleBackColor = false;
            this.btnSignUp.Click += new System.EventHandler(this.btnSignUp_Click);
            // 
            // txtForename
            // 
            this.txtForename.BackColor = System.Drawing.SystemColors.ScrollBar;
            this.txtForename.Font = new System.Drawing.Font("Segoe UI", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.txtForename.Location = new System.Drawing.Point(632, 184);
            this.txtForename.MinimumSize = new System.Drawing.Size(200, 40);
            this.txtForename.Name = "txtForename";
            this.txtForename.PlaceholderText = "Forename";
            this.txtForename.Size = new System.Drawing.Size(200, 35);
            this.txtForename.TabIndex = 4;
            this.txtForename.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.txtForename.Visible = false;
            // 
            // txtSurname
            // 
            this.txtSurname.BackColor = System.Drawing.SystemColors.ScrollBar;
            this.txtSurname.Font = new System.Drawing.Font("Segoe UI", 15.755F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.txtSurname.Location = new System.Drawing.Point(631, 245);
            this.txtSurname.MinimumSize = new System.Drawing.Size(200, 40);
            this.txtSurname.Name = "txtSurname";
            this.txtSurname.PlaceholderText = "Surname";
            this.txtSurname.Size = new System.Drawing.Size(200, 35);
            this.txtSurname.TabIndex = 5;
            this.txtSurname.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.txtSurname.Visible = false;
            // 
            // txtEmail
            // 
            this.txtEmail.BackColor = System.Drawing.SystemColors.ScrollBar;
            this.txtEmail.Font = new System.Drawing.Font("Segoe UI", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.txtEmail.Location = new System.Drawing.Point(632, 318);
            this.txtEmail.MinimumSize = new System.Drawing.Size(200, 40);
            this.txtEmail.Name = "txtEmail";
            this.txtEmail.PlaceholderText = "Email";
            this.txtEmail.Size = new System.Drawing.Size(200, 35);
            this.txtEmail.TabIndex = 6;
            this.txtEmail.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.txtEmail.Visible = false;
            // 
            // txtPasswordRegister
            // 
            this.txtPasswordRegister.BackColor = System.Drawing.SystemColors.ScrollBar;
            this.txtPasswordRegister.Font = new System.Drawing.Font("Segoe UI", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.txtPasswordRegister.Location = new System.Drawing.Point(631, 451);
            this.txtPasswordRegister.MinimumSize = new System.Drawing.Size(200, 40);
            this.txtPasswordRegister.Name = "txtPasswordRegister";
            this.txtPasswordRegister.PlaceholderText = "Password";
            this.txtPasswordRegister.Size = new System.Drawing.Size(200, 35);
            this.txtPasswordRegister.TabIndex = 8;
            this.txtPasswordRegister.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.txtPasswordRegister.Visible = false;
            // 
            // txtUsernameRegister
            // 
            this.txtUsernameRegister.BackColor = System.Drawing.SystemColors.ScrollBar;
            this.txtUsernameRegister.Font = new System.Drawing.Font("Segoe UI", 15.85F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.txtUsernameRegister.Location = new System.Drawing.Point(632, 382);
            this.txtUsernameRegister.MinimumSize = new System.Drawing.Size(200, 40);
            this.txtUsernameRegister.Name = "txtUsernameRegister";
            this.txtUsernameRegister.PlaceholderText = "Username";
            this.txtUsernameRegister.Size = new System.Drawing.Size(200, 36);
            this.txtUsernameRegister.TabIndex = 7;
            this.txtUsernameRegister.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.txtUsernameRegister.Visible = false;
            // 
            // pbUser
            // 
            this.pbUser.BackColor = System.Drawing.Color.Transparent;
            this.pbUser.Image = global::Minotaur_Maze_Mashup.Properties.Resources.camera;
            this.pbUser.Location = new System.Drawing.Point(672, 46);
            this.pbUser.Name = "pbUser";
            this.pbUser.Size = new System.Drawing.Size(120, 120);
            this.pbUser.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.pbUser.TabIndex = 9;
            this.pbUser.TabStop = false;
            this.pbUser.Visible = false;
            this.pbUser.Click += new System.EventHandler(this.pbUser_Click);
            // 
            // btnRegister
            // 
            this.btnRegister.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(68)))), ((int)(((byte)(114)))), ((int)(((byte)(196)))));
            this.btnRegister.FlatAppearance.BorderSize = 0;
            this.btnRegister.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnRegister.Font = new System.Drawing.Font("Microsoft Sans Serif", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.btnRegister.Location = new System.Drawing.Point(632, 513);
            this.btnRegister.Name = "btnRegister";
            this.btnRegister.Size = new System.Drawing.Size(200, 47);
            this.btnRegister.TabIndex = 10;
            this.btnRegister.Text = "Register";
            this.btnRegister.UseVisualStyleBackColor = false;
            this.btnRegister.Visible = false;
            this.btnRegister.Click += new System.EventHandler(this.btnRegister_Click);
            // 
            // pbLogo
            // 
            this.pbLogo.BackColor = System.Drawing.Color.Transparent;
            this.pbLogo.Image = global::Minotaur_Maze_Mashup.Properties.Resources.logo;
            this.pbLogo.Location = new System.Drawing.Point(147, 35);
            this.pbLogo.Name = "pbLogo";
            this.pbLogo.Size = new System.Drawing.Size(557, 87);
            this.pbLogo.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.pbLogo.TabIndex = 11;
            this.pbLogo.TabStop = false;
            // 
            // pbMicrophone
            // 
            this.pbMicrophone.BackColor = System.Drawing.Color.Transparent;
            this.pbMicrophone.Image = global::Minotaur_Maze_Mashup.Properties.Resources.microphoneUnmute;
            this.pbMicrophone.Location = new System.Drawing.Point(782, 571);
            this.pbMicrophone.Name = "pbMicrophone";
            this.pbMicrophone.Size = new System.Drawing.Size(50, 50);
            this.pbMicrophone.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.pbMicrophone.TabIndex = 12;
            this.pbMicrophone.TabStop = false;
            this.pbMicrophone.Click += new System.EventHandler(this.pbMicrophone_Click);
            // 
            // ForenameError
            // 
            this.ForenameError.BlinkStyle = System.Windows.Forms.ErrorBlinkStyle.NeverBlink;
            this.ForenameError.ContainerControl = this;
            // 
            // SurnameError
            // 
            this.SurnameError.BlinkStyle = System.Windows.Forms.ErrorBlinkStyle.NeverBlink;
            this.SurnameError.ContainerControl = this;
            // 
            // EmailError
            // 
            this.EmailError.BlinkStyle = System.Windows.Forms.ErrorBlinkStyle.NeverBlink;
            this.EmailError.ContainerControl = this;
            // 
            // UsernameRegisterError
            // 
            this.UsernameRegisterError.BlinkStyle = System.Windows.Forms.ErrorBlinkStyle.NeverBlink;
            this.UsernameRegisterError.ContainerControl = this;
            // 
            // PasswordRegisterError
            // 
            this.PasswordRegisterError.BlinkStyle = System.Windows.Forms.ErrorBlinkStyle.NeverBlink;
            this.PasswordRegisterError.ContainerControl = this;
            // 
            // pbArrow
            // 
            this.pbArrow.BackColor = System.Drawing.Color.Transparent;
            this.pbArrow.Image = global::Minotaur_Maze_Mashup.Properties.Resources.backarrow;
            this.pbArrow.Location = new System.Drawing.Point(312, 581);
            this.pbArrow.Name = "pbArrow";
            this.pbArrow.Size = new System.Drawing.Size(40, 40);
            this.pbArrow.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.pbArrow.TabIndex = 13;
            this.pbArrow.TabStop = false;
            this.pbArrow.Visible = false;
            this.pbArrow.Click += new System.EventHandler(this.pbArrow_Click);
            // 
            // ttForename
            // 
            this.ttForename.ToolTipTitle = "it is good";
            // 
            // LoginForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(96F, 96F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Dpi;
            this.BackgroundImage = global::Minotaur_Maze_Mashup.Properties.Resources.loginBackground;
            this.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.ClientSize = new System.Drawing.Size(848, 633);
            this.Controls.Add(this.pbArrow);
            this.Controls.Add(this.pbMicrophone);
            this.Controls.Add(this.btnRegister);
            this.Controls.Add(this.pbUser);
            this.Controls.Add(this.txtPasswordRegister);
            this.Controls.Add(this.txtUsernameRegister);
            this.Controls.Add(this.txtEmail);
            this.Controls.Add(this.txtSurname);
            this.Controls.Add(this.txtForename);
            this.Controls.Add(this.btnSignUp);
            this.Controls.Add(this.btnLogin);
            this.Controls.Add(this.pnlPassword);
            this.Controls.Add(this.pnlUsername);
            this.Controls.Add(this.pbLogo);
            this.DoubleBuffered = true;
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.Name = "LoginForm";
            this.ShowIcon = false;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Minotaur Maze Mashup";
            this.Load += new System.EventHandler(this.LoginForm_Load);
            this.pnlUsername.ResumeLayout(false);
            this.pnlUsername.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pbUsername)).EndInit();
            this.pnlPassword.ResumeLayout(false);
            this.pnlPassword.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pbPassword)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pbUser)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pbLogo)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pbMicrophone)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.ForenameError)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.SurnameError)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.EmailError)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.UsernameRegisterError)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.PasswordRegisterError)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pbArrow)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Panel pnlUsername;
        private System.Windows.Forms.Panel pnlPassword;
        private System.Windows.Forms.PictureBox pbUsername;
        private System.Windows.Forms.TextBox txtUsername;
        private System.Windows.Forms.PictureBox pbPassword;
        private System.Windows.Forms.TextBox txtPassword;
        private System.Windows.Forms.Button btnLogin;
        private System.Windows.Forms.Button btnSignUp;
        private System.Windows.Forms.TextBox txtForename;
		private System.Windows.Forms.TextBox txtSurname;
		private System.Windows.Forms.TextBox txtEmail;
		private System.Windows.Forms.TextBox txtPasswordRegister;
		private System.Windows.Forms.TextBox txtUsernameRegister;
		private System.Windows.Forms.PictureBox pbUser;
		private System.Windows.Forms.Button btnRegister;
		private System.Windows.Forms.PictureBox pbLogo;
		private System.Windows.Forms.PictureBox pbMicrophone;
		private System.Windows.Forms.ErrorProvider ForenameError;
		private System.Windows.Forms.ErrorProvider SurnameError;
		private System.Windows.Forms.ErrorProvider EmailError;
		private System.Windows.Forms.ErrorProvider UsernameRegisterError;
		private System.Windows.Forms.ErrorProvider PasswordRegisterError;
		private System.Windows.Forms.PictureBox pbArrow;
        private System.Windows.Forms.ToolTip ttForename;
    }
}

