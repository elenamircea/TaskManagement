using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DomainClasses.Enums
{
    public enum TaskStatus
    {
        open,
        close,
        [Description("In progress")]
        inProgress,
        [Description("In testing")]
        inTesting
    };
}
