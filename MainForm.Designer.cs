namespace WebBrowser
{
    partial class MainForm
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
            panelTop = new Panel();
            btnBack = new Button();
            btnForward = new Button();
            btnRefresh = new Button();
            txtUrl = new TextBox();
            btnGo = new Button();
            btnHistory = new Button();
            btnDownloads = new Button();
            panelLeftSidebar = new Panel();
            tabPanel = new VerticalFlowLayoutPanel();
            btnSidebarNewTab = new Button();
            containerPanel = new Panel();
            panelTop.SuspendLayout();
            panelLeftSidebar.SuspendLayout();
            SuspendLayout();
            // 
            // panelTop
            // 
            panelTop.Controls.Add(btnBack);
            panelTop.Controls.Add(btnForward);
            panelTop.Controls.Add(btnRefresh);
            panelTop.Controls.Add(txtUrl);
            panelTop.Controls.Add(btnGo);
            panelTop.Controls.Add(btnHistory);
            panelTop.Controls.Add(btnDownloads);
            panelTop.Dock = DockStyle.Top;
            panelTop.Location = new Point(0, 0);
            panelTop.Margin = new Padding(4, 3, 4, 3);
            panelTop.Name = "panelTop";
            panelTop.Size = new Size(1176, 52);
            panelTop.TabIndex = 0;
            // 
            // btnBack
            // 
            btnBack.Location = new Point(14, 12);
            btnBack.Margin = new Padding(4, 3, 4, 3);
            btnBack.Name = "btnBack";
            btnBack.Size = new Size(41, 29);
            btnBack.TabIndex = 0;
            btnBack.Text = "<";
            btnBack.UseVisualStyleBackColor = true;
            btnBack.Click += btnBack_Click;
            // 
            // btnForward
            // 
            btnForward.Location = new Point(62, 12);
            btnForward.Margin = new Padding(4, 3, 4, 3);
            btnForward.Name = "btnForward";
            btnForward.Size = new Size(41, 29);
            btnForward.TabIndex = 1;
            btnForward.Text = ">";
            btnForward.UseVisualStyleBackColor = true;
            btnForward.Click += btnForward_Click;
            // 
            // btnRefresh
            // 
            btnRefresh.Location = new Point(110, 12);
            btnRefresh.Margin = new Padding(4, 3, 4, 3);
            btnRefresh.Name = "btnRefresh";
            btnRefresh.Size = new Size(41, 29);
            btnRefresh.TabIndex = 2;
            btnRefresh.Text = "↻";
            btnRefresh.UseVisualStyleBackColor = true;
            btnRefresh.Click += btnRefresh_Click;
            // 
            // txtUrl
            // 
            txtUrl.Anchor = AnchorStyles.Top | AnchorStyles.Left | AnchorStyles.Right;
            txtUrl.Location = new Point(158, 14);
            txtUrl.Margin = new Padding(4, 3, 4, 3);
            txtUrl.Name = "txtUrl";
            txtUrl.Size = new Size(750, 23);
            txtUrl.TabIndex = 3;
            txtUrl.KeyDown += txtUrl_KeyDown;
            // 
            // btnGo
            // 
            btnGo.Anchor = AnchorStyles.Top | AnchorStyles.Right;
            btnGo.Location = new Point(913, 12);
            btnGo.Margin = new Padding(4, 3, 4, 3);
            btnGo.Name = "btnGo";
            btnGo.Size = new Size(58, 29);
            btnGo.TabIndex = 4;
            btnGo.Text = "Go";
            btnGo.UseVisualStyleBackColor = true;
            btnGo.Click += btnGo_Click;
            // 
            // btnHistory
            // 
            btnHistory.Anchor = AnchorStyles.Top | AnchorStyles.Right;
            btnHistory.Location = new Point(978, 12);
            btnHistory.Margin = new Padding(4, 3, 4, 3);
            btnHistory.Name = "btnHistory";
            btnHistory.Size = new Size(88, 29);
            btnHistory.TabIndex = 5;
            btnHistory.Text = "History";
            btnHistory.UseVisualStyleBackColor = true;
            btnHistory.Click += btnHistory_Click;
            // 
            // btnDownloads
            // 
            btnDownloads.Anchor = AnchorStyles.Top | AnchorStyles.Right;
            btnDownloads.Location = new Point(1071, 12);
            btnDownloads.Margin = new Padding(4, 3, 4, 3);
            btnDownloads.Name = "btnDownloads";
            btnDownloads.Size = new Size(91, 29);
            btnDownloads.TabIndex = 6;
            btnDownloads.Text = "Downloads";
            btnDownloads.UseVisualStyleBackColor = true;
            btnDownloads.Click += btnDownloads_Click;
            // 
            // panelLeftSidebar
            // 
            panelLeftSidebar.Controls.Add(tabPanel);
            panelLeftSidebar.Controls.Add(btnSidebarNewTab);
            panelLeftSidebar.Dock = DockStyle.Left;
            panelLeftSidebar.Location = new Point(0, 52);
            panelLeftSidebar.Margin = new Padding(4, 3, 4, 3);
            panelLeftSidebar.Name = "panelLeftSidebar";
            panelLeftSidebar.Size = new Size(233, 789);
            panelLeftSidebar.TabIndex = 1;
            // 
            // tabPanel
            // 
            tabPanel.AutoScroll = true;
            tabPanel.BackColor = SystemColors.ControlLight;
            tabPanel.Dock = DockStyle.Fill;
            tabPanel.FlowDirection = FlowDirection.TopDown;
            tabPanel.Location = new Point(0, 40);
            tabPanel.Margin = new Padding(4, 3, 4, 3);
            tabPanel.Name = "tabPanel";
            tabPanel.Size = new Size(233, 749);
            tabPanel.TabIndex = 1;
            tabPanel.WrapContents = false;
            tabPanel.Layout += TabPanel_Layout;
            tabPanel.Resize += TabPanel_Resize;
            // 
            // btnSidebarNewTab
            // 
            btnSidebarNewTab.Dock = DockStyle.Top;
            btnSidebarNewTab.Location = new Point(0, 0);
            btnSidebarNewTab.Margin = new Padding(4, 3, 4, 3);
            btnSidebarNewTab.Name = "btnSidebarNewTab";
            btnSidebarNewTab.Size = new Size(233, 40);
            btnSidebarNewTab.TabIndex = 0;
            btnSidebarNewTab.Text = "+ New Tab";
            btnSidebarNewTab.UseVisualStyleBackColor = true;
            btnSidebarNewTab.Click += btnSidebarNewTab_Click;
            // 
            // containerPanel
            // 
            containerPanel.Dock = DockStyle.Fill;
            containerPanel.Location = new Point(233, 52);
            containerPanel.Margin = new Padding(4, 3, 4, 3);
            containerPanel.Name = "containerPanel";
            containerPanel.Size = new Size(943, 789);
            containerPanel.TabIndex = 2;
            // 
            // MainForm
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(1176, 841);
            Controls.Add(containerPanel);
            Controls.Add(panelLeftSidebar);
            Controls.Add(panelTop);
            DoubleBuffered = true;
            Margin = new Padding(4, 3, 4, 3);
            Name = "MainForm";
            StartPosition = FormStartPosition.CenterScreen;
            Text = "Web Browser";
            WindowState = FormWindowState.Maximized;
            Load += WebBrowser_Load;
            panelTop.ResumeLayout(false);
            panelTop.PerformLayout();
            panelLeftSidebar.ResumeLayout(false);
            ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel panelTop;
        private System.Windows.Forms.Button btnBack;
        private System.Windows.Forms.Button btnForward;
        private System.Windows.Forms.Button btnRefresh;
        private System.Windows.Forms.TextBox txtUrl;
        private System.Windows.Forms.Button btnGo;
        private System.Windows.Forms.Button btnHistory;
        private System.Windows.Forms.Button btnDownloads;
        private System.Windows.Forms.Panel panelLeftSidebar;
        private VerticalFlowLayoutPanel tabPanel;
        private System.Windows.Forms.Button btnSidebarNewTab;
        private System.Windows.Forms.Panel containerPanel;
    }
}
