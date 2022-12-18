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
        public float swimSpeed = 10f;
        [SerializeField] private MouseLook m_MouseLook;

        void Start()
        {
            GetComponent<Rigidbody>().useGravity = false;
            m_MouseLook.Init(transform, target.transform);
            ResetVelocity();
        }

        private void Update()
        {
            RotateView();
            isSwimming();
            isFloating();
        }

        private void FixedUpdate()
        {
            m_MouseLook.UpdateCursorLock();
        }

        private void OnTriggerStay(Collider other)
        {
            if (other.name == "SwimmingArea")
            {
                transform.position -= target.up * swimSpeed * 0.5f * Time.deltaTime;
                Debug.Log("enter");
                ResetVelocity();
            }
        }

        private void OnTriggerExit(Collider other)
        {
            Debug.Log("exit");
        }

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