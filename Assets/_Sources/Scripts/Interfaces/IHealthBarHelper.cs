using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Assets._Sources.Scripts.Interfaces
{
    public interface IHealthBarHelper
    {
        public float GetMaxHealth();
        public float GetCurrentHealth();
    }
}
