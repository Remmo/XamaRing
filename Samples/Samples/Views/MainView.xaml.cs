using Samples.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Samples.Views
{
    public partial class MainView
    {
        public MainView()
        {
            InitializeComponent();
            this.BindingContext = new vmMain();
        }
    }
}
