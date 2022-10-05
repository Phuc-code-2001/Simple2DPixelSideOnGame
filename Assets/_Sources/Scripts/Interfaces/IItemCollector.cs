using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Assets._Sources.Scripts.Interfaces
{
    public interface IItemCollector
    {
        public void Collect<T>(T item);
    }
}
