using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerInputHandler : MonoBehaviour, ICharacterInput
{
    private PlayerInputActions input;
    private Transform cameraTransform;


    private void Awake()
    {
        input = new PlayerInputActions();
        cameraTransform = Camera.main.transform;
    }

    private void OnEnable()
    {
        input.Enable();
    }

    private void OnDisable()
    {
        input.Disable();
    }

    // MOVEMENT
    public Vector2 MoveInput => input.Player.Move.ReadValue<Vector2>();
    public Vector3 MoveInputDirection => VectorExtension.InputDirection(MoveInput.x, MoveInput.y, cameraTransform, transform);

    public Vector2 LookInput => input.Player.Look.ReadValue<Vector2>();

    // JUMP
    public bool JumpPressed => input.Player.Jump.WasPressedThisFrame();
    public bool JumpHeld => input.Player.Jump.IsPressed();
    public bool JumpReleased => input.Player.Jump.WasReleasedThisFrame();

    // SQUAT
    public bool SquatPressed => input.Player.Squat.WasPressedThisFrame();
    public bool SquatHeld => input.Player.Squat.IsPressed();
    public bool SquatReleased => input.Player.Squat.WasReleasedThisFrame();

    // HOMING
    public bool HomingPressed => input.Player.Homing.WasPressedThisFrame();
    public bool HomingHeld => input.Player.Homing.IsPressed();
    public bool HomingReleased => input.Player.Homing.WasReleasedThisFrame();

    // INTERACT
    public bool InteractPressed => input.Player.Homing.WasPressedThisFrame();
    public bool InteractHeld => input.Player.Homing.IsPressed();
    public bool InteractReleased => input.Player.Homing.WasReleasedThisFrame();

    // QUICK STEP LEFT
    public bool QuickStepLeftPressed => input.Player.QuickStepLeft.WasPressedThisFrame();
    public bool QuickStepLeftHeld => input.Player.QuickStepLeft.IsPressed();
    public bool QuickStepLeftReleased => input.Player.QuickStepLeft.WasReleasedThisFrame();

    // QUICK STEP RIGHT
    public bool QuickStepRightPressed => input.Player.QuickStepRight.WasPressedThisFrame();
    public bool QuickStepRightHeld => input.Player.QuickStepRight.IsPressed();
    public bool QuickStepRightReleased => input.Player.QuickStepRight.WasReleasedThisFrame();

    // DRIFT
    public bool DriftPressed => input.Player.Drift.WasPressedThisFrame();
    public bool DriftHeld => input.Player.Drift.IsPressed();
    public bool DriftReleased => input.Player.Drift.WasReleasedThisFrame();

    // BOOST
    public bool BoostPressed => input.Player.Boost.WasPressedThisFrame();
    public bool BoostHeld => input.Player.Boost.IsPressed();
    public bool BoostReleased => input.Player.Boost.WasReleasedThisFrame();

    // TARGET LOCK
    public bool TargetLockPressed => input.Player.TargetLock.WasPressedThisFrame();
    public bool TargetLockHeld => input.Player.TargetLock.IsPressed();
    public bool TargetLockReleased => input.Player.TargetLock.WasReleasedThisFrame();

    // LIGHT SPEED DASH
    public bool LightSpeedDashPressed => input.Player.LightSpeedDash.WasPressedThisFrame();
    public bool LightSpeedDashHeld => input.Player.LightSpeedDash.IsPressed();
    public bool LightSpeedDashReleased => input.Player.LightSpeedDash.WasReleasedThisFrame();

    // PAUSE
    public bool PausePressed => input.Player.Pause.WasPressedThisFrame();
    public bool PauseHeld => input.Player.Pause.IsPressed();
    public bool PauseReleased => input.Player.Pause.WasReleasedThisFrame();

    // OPTIONS
    public bool OptionsPressed => input.Player.Options.WasPressedThisFrame();
    public bool OptionsHeld => input.Player.Options.IsPressed();
    public bool OptionsReleased => input.Player.Options.WasReleasedThisFrame();
}