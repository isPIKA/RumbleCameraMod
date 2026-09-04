using Il2Cpp;
using Il2CppCinemachine;
using MelonLoader;
using UnityEngine;

[assembly: MelonInfo(
    typeof(CameraMod.CameraModMain),
    "Top-Down Camera Distance Mod",
    "1.3.0",
    "Aramon"
)]
[assembly: MelonGame("Lightfox Games, Inc.", "Rumble Club")]

namespace CameraMod;

public sealed class CameraModMain : MelonMod
{
    private const float MinimumMultiplier = 0.5f;
    private const float MaximumMultiplier = 3.0f;

    private float _distanceMultiplier = 1.0f;
    private bool _initialized;
    private bool _componentReported;
    private float _originalFramingDistance;
    private Vector3 _originalFollowOffset;

    public override void OnInitializeMelon()
    {
        MelonLogger.Msg("Top-Down Camera Mod v1.3 loaded.");
        MelonLogger.Msg("Left Alt + Mouse Wheel: distance");
        MelonLogger.Msg("Left Alt + R: reset distance");
    }

    public override void OnUpdate()
    {
        if (Input.GetKey(KeyCode.LeftAlt))
        {
            float scroll = Input.GetAxis("Mouse ScrollWheel");

            if (scroll != 0.0f)
            {
                _distanceMultiplier = Mathf.Clamp(
                    _distanceMultiplier + scroll,
                    MinimumMultiplier,
                    MaximumMultiplier);

                MelonLogger.Msg($"Camera distance: {_distanceMultiplier:F1}x");
            }

            if (Input.GetKeyDown(KeyCode.R))
            {
                _distanceMultiplier = 1.0f;
                MelonLogger.Msg("Camera distance reset.");
            }
        }

        ApplyCameraDistance();
    }

    private void ApplyCameraDistance()
    {
        try
        {
            CameraPlayerFollow cameraFollow = CameraPlayerFollow.Inst;

            if (cameraFollow == null)
                return;

            CinemachineVirtualCamera virtualCamera = cameraFollow.GroundedVirtualCam;

            if (virtualCamera == null)
                return;

            CinemachineFramingTransposer framing =
                virtualCamera.GetCinemachineComponent<CinemachineFramingTransposer>();

            if (framing != null)
            {
                if (!_initialized)
                {
                    _originalFramingDistance = framing.m_CameraDistance;
                    _initialized = true;
                }

                framing.m_CameraDistance =
                    _originalFramingDistance * _distanceMultiplier;

                ReportComponent("CinemachineFramingTransposer");
                return;
            }

            CinemachineTransposer transposer =
                virtualCamera.GetCinemachineComponent<CinemachineTransposer>();

            if (transposer != null)
            {
                if (!_initialized)
                {
                    _originalFollowOffset = transposer.m_FollowOffset;
                    _initialized = true;
                }

                transposer.m_FollowOffset =
                    _originalFollowOffset * _distanceMultiplier;

                ReportComponent("CinemachineTransposer");
            }
        }
        catch (System.Exception exception)
        {
            if (_componentReported)
                return;

            MelonLogger.Error($"Camera error: {exception.Message}");
            _componentReported = true;
        }
    }

    private void ReportComponent(string componentName)
    {
        if (_componentReported)
            return;

        MelonLogger.Msg("Top-down angle preserved.");
        MelonLogger.Msg($"Using {componentName}.");
        _componentReported = true;
    }
}
