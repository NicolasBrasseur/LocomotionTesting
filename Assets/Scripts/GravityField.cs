using StarterAssets;
using UnityEngine;

public class GravityField : MonoBehaviour
{
    [SerializeField] private bool _resetGravityOnExit;

    private ThirdPersonController _controller;

    private void OnTriggerEnter(Collider other)
    {
        if(other.TryGetComponent<ThirdPersonController>(out _controller))
        {
            _controller.SetNewLocalDown(transform.up * -1.0f, true);
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if(other.TryGetComponent<ThirdPersonController>(out _controller) && _resetGravityOnExit)
        {
            _controller.SetNewLocalDown(Vector3.down, false);
        }
    }

    private void OnTriggerStay(Collider other)
    {
        if (other.TryGetComponent<ThirdPersonController>(out _controller))
        {
            if(_controller.IsInGravityField) { return; }

            _controller.SetNewLocalDown(transform.up * -1.0f, true);
        }
    }
}
