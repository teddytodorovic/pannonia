using System;
using System.Collections.Generic;
using System.Text;

namespace PartialClassExtension
{
    public partial class Brain
    {
        public Brain()
        {
            Console.WriteLine("In the constructor.");
        }

        private String limbicSystem;
        private String neurons;

        public String LimbicSystem { get => limbicSystem; set => limbicSystem = value; }
        public String Neurons { get => neurons; set => neurons = value; }
    }
}
