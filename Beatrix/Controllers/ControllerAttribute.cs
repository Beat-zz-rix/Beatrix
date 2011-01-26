using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Beatrix.Controllers
{
    public class ControllerAttribute : Attribute
    {
        public ControllerAttribute(Type controllerType)
        {
            ControllerType = controllerType;
        }

        public Type ControllerType { get; private set; }
    }
}
