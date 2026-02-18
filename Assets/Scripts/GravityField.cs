using StarterAssets;
using UnityEngine;

public class GravityField : MonoBehaviour
{
    [SerializeField] private bool _resetGravityOnExit;

    private CenterOfGravity _centerOfGravity;

    private void OnTriggerEnter(Collider other)
    {
        Debug.Log($"Trigger : {other.name}");
        if(other.TryGetComponent<CenterOfGravity>(out _centerOfGravity))
        {
            _centerOfGravity.GetPlayerController().SetNewLocalDown(transform.up * -1.0f, true);
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if(other.TryGetComponent<CenterOfGravity>(out _centerOfGravity) && _resetGravityOnExit)
        {
            _centerOfGravity.GetPlayerController().SetNewLocalDown(Vector3.down, false);
        }
    }

    private void OnTriggerStay(Collider other)
    {
        if (other.TryGetComponent<CenterOfGravity>(out _centerOfGravity))
        {
            if(_centerOfGravity.GetPlayerController().IsInGravityField) { return; }

            _centerOfGravity.GetPlayerController().SetNewLocalDown(transform.up * -1.0f, true);
        }
    }
}
