using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace UnityStandardAssets.Characters.FirstPerson
{
    [RequireComponent(typeof(CharacterController))]
    [RequireComponent(typeof(AudioSource))]

    public class Swimming : MonoBehaviour
    {
        public Transform target;
        public float swimSpeed = 5f;
        [SerializeField] private MouseLook m_MouseLook;
        //AudioSource sound;

        public float surface;

        void Start()
        {
            GetComponent<Rigidbody>().useGravity = false;    // false;
            //sound = GetComponent<AudioSource>(); 
            m_MouseLook.Init(transform, target.transform);
            ResetVelocity();
        }

        private void Update()
        {
            surface = Terrain.activeTerrain.SampleHeight(transform.position) +0.05f;
            if (transform.position.y > surface)
            {
                transform.position -= target.up * swimSpeed * 0.5f * Time.deltaTime;
            }

            RotateView();
            isSwimming();
            isFloating();
            ResetVelocity();
        }
        
        private void FixedUpdate()
        {
            m_MouseLook.UpdateCursorLock();
        }

        //private void OnTriggerStay(Collider other)
        //{
        //    if (other.name == "SwimmingArea")
        //    {
        //        transform.position -= target.up * swimSpeed * 0.5f * Time.deltaTime;
        //        ResetVelocity();
        //        Debug.Log("enter");
        //    }
        //}

        //private void OnTriggerExit(Collider other)
        //{
        //    Debug.Log("exit");
        //}

        void isSwimming()
        {
            if (Input.GetAxisRaw("Vertical") > 0)
            {
                transform.position += target.forward * swimSpeed * Time.deltaTime;
            }
            if (Input.GetAxisRaw("Vertical") < 0)
            {
                transform.position -= target.forward * swimSpeed * Time.deltaTime;
            }
            if (Input.GetAxisRaw("Horizontal") > 0)
            {
                transform.position += target.right * swimSpeed * Time.deltaTime;
            }
            if (Input.GetAxisRaw("Horizontal") < 0)
            {
                transform.position -= target.right * swimSpeed * Time.deltaTime;
            }

        }

        void isFloating()
        {
            if (Input.GetKey(KeyCode.Space))
            {
                transform.position += target.up * swimSpeed * Time.deltaTime;
            }
        }
        void ResetVelocity()
        {
            GetComponent<Rigidbody>().velocity = Vector3.zero;
            GetComponent<Rigidbody>().angularVelocity = Vector3.zero;
        }
        private void RotateView()
        {
            m_MouseLook.LookRotation(transform, target.transform);
        }
    }
}