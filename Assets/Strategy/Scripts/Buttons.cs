using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Strategy
{
    public class Buttons : MonoBehaviour
    {
        public static event Action LoadSimpleAmmo_e;
        public static event Action LoadMetalAmmo_e;
        public static event Action EnableSingleFireing_e;
        public static event Action EnableTripleFireing_e;

        void Start()
        {

        }

        public void EnableSingleFireing()
        {
            EnableSingleFireing_e?.Invoke();
        }

        public void EnableTripleFireing()
        {
            EnableTripleFireing_e?.Invoke();
        }


        public void LoadSimpleAmmo()
        {
            LoadSimpleAmmo_e?.Invoke();
        }

        public void LoadMetalAmmo()
        {
            LoadMetalAmmo_e?.Invoke();

        }
    }
}
