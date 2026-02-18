using StarterAssets;
using UnityEngine;

public class CenterOfGravity : MonoBehaviour
{
    [SerializeField] private ThirdPersonController _playerController;

    public ThirdPersonController GetPlayerController()
    {
        return _playerController; 
    }
}
