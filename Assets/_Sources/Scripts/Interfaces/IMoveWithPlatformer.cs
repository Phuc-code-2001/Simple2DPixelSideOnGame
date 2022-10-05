using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UnityEngine;

namespace Assets._Sources.Scripts.Interfaces
{
    public interface IMoveWithPlatformer
    {
        public void InvokeMovingPlatformer(MovingPlatform platformer);
        public void LeaveMovingPlatformer(MovingPlatform platformer);
        public void MoveByVelocity(Vector2 director);
    }
}
