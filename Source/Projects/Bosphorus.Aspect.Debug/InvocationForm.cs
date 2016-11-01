using System;
using System.Collections;
using System.Linq;
using System.Windows.Forms;
using Bosphorus.Aspect.Debug.ControlBuilder;
using Bosphorus.Aspect.Debug.PropertyWrapper;
using Castle.DynamicProxy;

namespace Bosphorus.Aspect.Debug
{
    public partial class InvocationForm : Form
    {
        private readonly IInvocation invocation;
        private readonly GenericControlBuilder genericControlBuilder;

        public InvocationForm(GenericControlBuilder genericControlBuilder, IInvocation invocation)
        {
            InitializeComponent();
            this.invocation = invocation;
            this.genericControlBuilder = genericControlBuilder;
            this.Text = invocation.InvocationTarget.ToString();
            pgInvocationOwner.SelectedObject = new CustomTypeDescriptorWrapper(invocation.InvocationTarget);
            tcArguments.TabPages.AddRange(invocation.Arguments.Select((arg, index) => BuildArgumentPage(arg, "Argument " + index)).ToArray());
        }

        private TabPage BuildArgumentPage(dynamic arg, string caption)
        {
            if (arg is IEnumerable)
            {
                arg = Enumerable.ToList(arg);
            }

            Control control = genericControlBuilder.Build(arg);
            control.Dock = DockStyle.Fill;

            TabPage tabPage = new TabPage(caption);
            tabPage.Controls.Add(control);
            return tabPage;
        }

        private void btnProceed_Click(object sender, EventArgs e)
        {
            invocation.Proceed();
            var resultPage = BuildArgumentPage(invocation.ReturnValue, "Return");
            tcArguments.TabPages.Add(resultPage);
            tcArguments.SelectedIndex = tcArguments.TabPages.Count - 1;
            btnProceed.Enabled = false;
            btnRevert.Enabled = true;
            btnContinue.Enabled = true;
            btnContinue.Focus();
        }

        private void btnRevert_Click(object sender, EventArgs e)
        {
            tcArguments.TabPages.RemoveAt(tcArguments.TabPages.Count - 1);
            tcArguments.SelectedIndex = tcArguments.TabPages.Count - 1;
            btnProceed.Enabled = true;
            btnRevert.Enabled = false;
            btnContinue.Enabled = false;
            btnProceed.Focus();
        }
    }
}
