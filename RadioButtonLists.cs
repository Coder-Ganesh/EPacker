using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Diagnostics;
using System.Linq;
using System.Text;

namespace ePacker1
{
    public partial class RadioButtonLists : Component
    {
        public RadioButtonLists()
        {
            InitializeComponent();
        }

        public RadioButtonLists(IContainer container)
        {
            container.Add(this);

            InitializeComponent();
        }
    }
}
