using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public class Wave
{
        [SerializeField]
        public GameObject[] enemies;
        public float rate = 20f;
    
    public Wave(GameObject[] _enemies, float _rate)
    {
        enemies = _enemies;
        rate = _rate;
    }

    public static implicit operator GameObject(Wave v)
    {
        throw new NotImplementedException();
    }
}
