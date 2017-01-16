using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Nutshell.Components;

namespace Nutshell.Speech
{
        public abstract class Synthesizer: DispatchableComponent,ISynthesizer
        {
                protected Synthesizer(IIdentityObject parent, string id) 
                        : base(parent, id)
                {
                }
        }
}
