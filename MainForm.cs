using Microsoft.Web.WebView2.Core;
using Microsoft.Web.WebView2.WinForms;

namespace WebBrowser
{
    public partial class MainForm : Form
    {
        private const string DefaultUrl = "https://www.google.com/";
        private Panel activeTabItem = null;
        private bool isAdjustingWidths = false;

        public MainForm()
        {
            InitializeComponent();
        }

        private void WebBrowser_Load(object sender, EventArgs e)
        {
            AddNewTab(DefaultUrl);
        }

        private void AdjustTabWidths()
        {
            if (isAdjustingWidths) return;
            isAdjustingWidths = true;

            tabPanel.SuspendLayout();
            try
            {
                int clientWidth = tabPanel.ClientSize.Width;
                int targetWidth = clientWidth - 6;

                if (targetWidth < 50)
                {
                    targetWidth = 50;
                }

                foreach (Control ctrl in tabPanel.Controls)
                {
                    if (ctrl is Panel tabItem)
                    {
                        if (tabItem.Width != targetWidth)
                        {
                            tabItem.Width = targetWidth;
                            AdjustInternalTabControls(tabItem, targetWidth);
                        }
                    }
                }
            }
            finally
            {
                tabPanel.ResumeLayout(true);
                isAdjustingWidths = false;
            }
        }

        private void AdjustInternalTabControls(Panel tabItem, int targetWidth)
        {
            Label lbl = null;
            Button btn = null;

            foreach (Control c in tabItem.Controls)
            {
                if (c is Label label) lbl = label;
                else if (c is Button button) btn = button;
            }

            if (btn != null)
            {
                btn.Left = targetWidth - btn.Width - 6;
            }

            if (lbl != null && btn != null)
            {
                lbl.Width = btn.Left - lbl.Left - 4;
            }
        }

        private void TabPanel_Layout(object sender, LayoutEventArgs e)
        {
            AdjustTabWidths();
        }

        private void TabPanel_Resize(object sender, EventArgs e)
        {
            AdjustTabWidths();
        }

        private async void AddNewTab(string url)
        {
            WebView2 webView = new WebView2
            {
                Dock = DockStyle.Fill,
                Visible = false
            };
            containerPanel.Controls.Add(webView);

            Panel tabItem = new Panel
            {
                Height = 38,
                BorderStyle = BorderStyle.FixedSingle,
                Margin = new Padding(3, 3, 3, 0),
                BackColor = SystemColors.Control,
                Cursor = Cursors.Hand
            };
            
            int initialWidth = Math.Max(50, tabPanel.ClientSize.Width - 6);
            tabItem.Width = initialWidth;

            Label lblTitle = new Label
            {
                Text = "Loading...",
                Location = new Point(5, 11),
                Size = new Size(130, 18),
                AutoEllipsis = true,
                Cursor = Cursors.Hand
            };

            Button btnClose = new Button
            {
                Text = "×",
                Font = new Font("Arial", 9.5F, FontStyle.Bold),
                Size = new Size(20, 20),
                Location = new Point(148, 8),
                FlatStyle = FlatStyle.Flat,
                Cursor = Cursors.Hand
            };
            btnClose.FlatAppearance.BorderSize = 0;

            tabItem.Tag = webView;
            lblTitle.Tag = tabItem;
            btnClose.Tag = tabItem;

            tabItem.Click += TabItem_Click;
            lblTitle.Click += TabItem_Click;
            btnClose.Click += BtnClose_Click;

            tabItem.Controls.Add(lblTitle);
            tabItem.Controls.Add(btnClose);

            AdjustInternalTabControls(tabItem, initialWidth);

            tabPanel.Controls.Add(tabItem);

            AdjustTabWidths();
            tabPanel.PerformLayout();

            tabPanel.ScrollControlIntoView(tabItem);

            SelectTab(tabItem);

            try
            {
                await webView.EnsureCoreWebView2Async(null);

                webView.CoreWebView2.NewWindowRequested += CoreWebView2_NewWindowRequested;

                webView.Source = new Uri(NormalizeUrl(url));
                webView.SourceChanged += WebView_SourceChanged;
                webView.NavigationCompleted += WebView_NavigationCompleted;
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Failed to initialize WebView2: {ex.Message}", "Initialization Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void SelectTab(Panel selectedTab)
        {
            activeTabItem = selectedTab;

            foreach (Control ctrl in tabPanel.Controls)
            {
                if (ctrl is Panel tabItem)
                {
                    WebView2 webView = tabItem.Tag as WebView2;
                    Label lbl = GetLabelFromTabItem(tabItem);

                    if (tabItem == selectedTab)
                    {
                        tabItem.BackColor = SystemColors.GradientActiveCaption;
                        if (lbl != null)
                        {
                            lbl.BackColor = SystemColors.GradientActiveCaption;
                        }

                        if (webView != null)
                        {
                            webView.Visible = true;
                            txtUrl.Text = webView.Source?.ToString() ?? string.Empty;
                        }
                    }
                    else
                    {
                        tabItem.BackColor = SystemColors.Control;
                        if (lbl != null)
                        {
                            lbl.BackColor = SystemColors.Control;
                        }

                        if (webView != null)
                        {
                            webView.Visible = false;
                        }
                    }
                }
            }
        }

        private void CloseTab(Panel tabItem)
        {
            if (tabPanel.Controls.Count <= 1)
            {
                Close();
            }

            WebView2 webView = tabItem.Tag as WebView2;
            bool wasActive = (activeTabItem == tabItem);
            int index = tabPanel.Controls.IndexOf(tabItem);

            tabPanel.Controls.Remove(tabItem);
            if (webView != null)
            {
                containerPanel.Controls.Remove(webView);
                webView.Dispose();
            }
            tabItem.Dispose();

            if (wasActive)
            {
                int nextIndex = Math.Max(0, index - 1);
                if (tabPanel.Controls.Count > 0)
                {
                    Panel nextTab = tabPanel.Controls[nextIndex] as Panel;
                    SelectTab(nextTab);
                }
            }
        }

        private Label GetLabelFromTabItem(Panel tabItem)
        {
            foreach (Control c in tabItem.Controls)
            {
                if (c is Label lbl)
                {
                    return lbl;
                }
            }
            return null;
        }

        private WebView2 GetCurrentWebView()
        {
            if (activeTabItem != null)
            {
                return activeTabItem.Tag as WebView2;
            }
            return null;
        }

        private string NormalizeUrl(string url)
        {
            if (string.IsNullOrWhiteSpace(url))
            {
                return DefaultUrl;
            }

            if (!url.StartsWith("http://") && !url.StartsWith("https://"))
            {
                if (url.Contains(".") && !url.Contains(" "))
                {
                    url = "https://" + url;
                }
                else
                {
                    url = "https://www.bing.com/search?q=" + Uri.EscapeDataString(url);
                }
            }
            return url;
        }

        private void CoreWebView2_NewWindowRequested(object sender, CoreWebView2NewWindowRequestedEventArgs e)
        {
            e.Handled = true;
            AddNewTab(e.Uri);
        }

        private void WebView_SourceChanged(object sender, CoreWebView2SourceChangedEventArgs e)
        {
            var webView = sender as WebView2;
            if (webView != null && activeTabItem != null && activeTabItem.Tag == webView)
            {
                txtUrl.Text = webView.Source.ToString();
            }
        }

        private void WebView_NavigationCompleted(object sender, CoreWebView2NavigationCompletedEventArgs e)
        {
            var webView = sender as WebView2;
            if (webView != null)
            {
                foreach (Control ctrl in tabPanel.Controls)
                {
                    if (ctrl is Panel tabItem && tabItem.Tag == webView)
                    {
                        Label lbl = GetLabelFromTabItem(tabItem);
                        if (lbl != null)
                        {
                            lbl.Text = webView.CoreWebView2.DocumentTitle;
                        }
                        break;
                    }
                }
            }
        }

        private void TabItem_Click(object sender, EventArgs e)
        {
            Panel tabItem = sender as Panel;
            if (tabItem == null)
            {
                tabItem = (sender as Control)?.Tag as Panel;
            }
            if (tabItem != null)
            {
                SelectTab(tabItem);
            }
        }

        private void BtnClose_Click(object sender, EventArgs e)
        {
            Button btn = sender as Button;
            Panel tabItem = btn?.Tag as Panel;

            if (tabItem != null)
            {
                CloseTab(tabItem);
            }
        }

        private void btnGo_Click(object sender, EventArgs e)
        {
            var webView = GetCurrentWebView();
            if (webView != null)
            {
                webView.Source = new Uri(NormalizeUrl(txtUrl.Text));
            }
        }

        private void txtUrl_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                var webView = GetCurrentWebView();
                if (webView != null)
                {
                    webView.Source = new Uri(NormalizeUrl(txtUrl.Text));
                }
                e.SuppressKeyPress = true;
            }
        }

        private void btnBack_Click(object sender, EventArgs e)
        {
            var webView = GetCurrentWebView();
            if (webView != null && webView.CanGoBack)
            {
                webView.GoBack();
            }
        }

        private void btnForward_Click(object sender, EventArgs e)
        {
            var webView = GetCurrentWebView();
            if (webView != null && webView.CanGoForward)
            {
                webView.GoForward();
            }
        }

        private void btnSidebarNewTab_Click(object sender, EventArgs e)
        {
            AddNewTab(DefaultUrl);
        }
    }
}