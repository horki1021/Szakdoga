namespace SzamitogepNyilvantarto.UI.MenuControls
{
    public partial class BaseControl : UserControl
    {
        protected BindingSource adapter = new BindingSource();
        public BaseControl()
        {
            InitializeComponent();
            dataGridView.BringToFront();
        }

        protected virtual void OnAddClick(object sender, EventArgs e)
        { }

        protected virtual void OnUpdateClick(object sender, EventArgs e)
        { }

        protected virtual void OnDeleteClick(object sender, EventArgs e)
        { }

        protected virtual void OnCloseClick(object sender, EventArgs e)
        {
            MainForm form = (MainForm)this.Parent!;
            form.CloseControl(this);
        }
    }
}
