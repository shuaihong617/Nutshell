using Nutshell.Components;
using Nutshell.Components.Models;
using Nutshell.Data;

namespace Nutshell.Distributing
{
        public abstract class Site<TC, TP> : ConsumeProducter<TC, TP>, ISite
                where TC : class
                where TP : class
        {
                protected Site(IdentityObject parent, string id)
                        : base(parent,id)
                {
                }
        }
}
