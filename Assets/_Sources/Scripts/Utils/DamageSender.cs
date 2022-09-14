using Assets._Sources.Scripts.Interfaces;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public class DamageSender : MonoBehaviour
{

    [Header("Collision")]
    public Dictionary<int, Collider2D> _collitions = new Dictionary<int, Collider2D>();
    [SerializeField] public List<Collider2D> Colliders;

    private void OnTriggerStay2D(Collider2D collider)
    {
        int objId = collider.gameObject.GetInstanceID();
        if (!_collitions.ContainsKey(objId))
        {
            _collitions.Add(objId, collider);
        }
    }

    private void OnTriggerExit2D(Collider2D collider)
    {
        int objId = collider.gameObject.GetInstanceID();
        if (_collitions.ContainsKey(objId))
        {
            _collitions.Remove(objId);
        }
    }

}
