using Cinemachine;
using UnityEngine;
/// <summary>
/// Extension for Cinimacine to be able to use new Input System instead of the classic one.
/// </summary>
public class CinemachinePovExtension : CinemachineExtension
{
    [SerializeField] private float _horizontalSpeed = 35f;
    [SerializeField] private float _verticalSpeed = 25f;
    [SerializeField] private float _clampAngle = 80f;

    private InputManager _inputManager;
    private Vector3 _startingRot;
    protected override void Awake()
    {
        _inputManager = InputManager.Instance;
        base.Awake();
    }
    protected override void PostPipelineStageCallback(CinemachineVirtualCameraBase vcam, CinemachineCore.Stage stage, ref CameraState state, float deltaTime)
    {
        if (vcam.Follow)
        {
            if(stage == CinemachineCore.Stage.Aim)
            {
                if(_startingRot == null) _startingRot = transform.localRotation.eulerAngles;
                Vector2 deltaInput = _inputManager.PlayerGetLook();
                _startingRot.x += deltaInput.x * _horizontalSpeed * Time.deltaTime;
                _startingRot.y += deltaInput.y * _verticalSpeed* Time.deltaTime;
                _startingRot.y = Mathf.Clamp( _startingRot.y, -_clampAngle, _clampAngle );
                state.RawOrientation = Quaternion.Euler(-_startingRot.y, _startingRot.x,0f);
            }
        }
    }
}
