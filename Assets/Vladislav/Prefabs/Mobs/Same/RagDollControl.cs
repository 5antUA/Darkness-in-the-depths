using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace mobs
{
    public class RagDollControl : MonoBehaviour
    {
        public Animator animation;
        public Rigidbody[] ALLrigidbodys;

        private void Awake()
        {
            for (int i = 0; i < ALLrigidbodys.Length; i++)
            {
                ALLrigidbodys[i].isKinematic = true;
            }
        }

        // Update is called once per frame
        void Update()
        {
            if (Input.GetKeyDown(KeyCode.E))
            {
                makephicik();
            }
        }

        public void makephicik()
        {
            if (animation.enabled == false)
            {
                animation.enabled = true;
                for (int i = 0; i < ALLrigidbodys.Length; i++)
                {
                    ALLrigidbodys[i].isKinematic = true;
                }

            }
            else
            {
                animation.enabled = false;
                for (int i = 0; i < ALLrigidbodys.Length; i++)
                {
                    ALLrigidbodys[i].isKinematic = false;
                    ALLrigidbodys[i].mass = 1;
                }
            }

        }
    }
}