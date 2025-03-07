using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace KszUtil
{
    public class Smoothtransform : MonoBehaviour
    {
        public Vector3 TargetPosition;
        public Vector3 TargetScale;
        public Quaternion TargetRotation;
        public float TimeFact { set; get; } = 0.5f;

        public void Start()
        {
            TargetPosition = transform.localPosition;
            TargetScale = transform.localScale;
            TargetRotation = transform.localRotation;
        }

        public void Update()
        {
            var t = 1 - Mathf.Pow(0.1f, Time.deltaTime / TimeFact);  //TimeFact秒で今いる場所から1/10まで間を詰めるための値
            transform.localPosition = Vector3.Lerp(transform.localPosition, TargetPosition, t);
            transform.localScale = Vector3.Lerp(transform.localScale, TargetScale, t);
            transform.localRotation = Quaternion.Lerp(transform.localRotation, TargetRotation, t);
        }
    }
}


