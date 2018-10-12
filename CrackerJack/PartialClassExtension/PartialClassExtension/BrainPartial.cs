using System;
using System.Collections.Generic;
using System.Text;

namespace PartialClassExtension
{
    public partial class Brain
    { 
        private String cerebrum;

        public string Cerebrum { get => cerebrum; set => cerebrum = value; }
    }
}
