using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using DevExpress.XtraWaitForm;

namespace MessagePublisher.Client.BaseViews
{

    public partial class TrWaitForm : WaitForm
    {
        public TrWaitForm()
        {
            InitializeComponent();
            this.progressPanel1.AutoHeight = true;
        }
    }

}
