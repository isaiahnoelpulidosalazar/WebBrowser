namespace WebBrowser
{
    public class VerticalFlowLayoutPanel : FlowLayoutPanel
    {
        protected override CreateParams CreateParams
        {
            get
            {
                CreateParams cp = base.CreateParams;
                cp.Style &= ~0x00100000;
                return cp;
            }
        }
    }
}
