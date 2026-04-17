using UnityEngine;

public interface ICharacterInput
{
    Vector2 MoveInput { get; }
    Vector2 LookInput { get; }

    // Jump
    bool JumpPressed { get; }
    bool JumpHeld { get; }
    bool JumpReleased { get; }

    // Squat
    bool SquatPressed { get; }
    bool SquatHeld { get; }
    bool SquatReleased { get; }

    // Homing
    bool HomingPressed { get; }
    bool HomingHeld { get; }
    bool HomingReleased { get; }

    // Interact
    bool InteractPressed { get; }
    bool InteractHeld { get; }
    bool InteractReleased { get; }


    // Quick Step Left
    bool QuickStepLeftPressed { get; }
    bool QuickStepLeftHeld { get; }
    bool QuickStepLeftReleased { get; }

    // Quick Step Right
    bool QuickStepRightPressed { get; }
    bool QuickStepRightHeld { get; }
    bool QuickStepRightReleased { get; }

    // Drift
    bool DriftPressed { get; }
    bool DriftHeld { get; }
    bool DriftReleased { get; }

    // Boost
    bool BoostPressed { get; }
    bool BoostHeld { get; }
    bool BoostReleased { get; }

    // Target Lock
    bool TargetLockPressed { get; }
    bool TargetLockHeld { get; }
    bool TargetLockReleased { get; }

    // Light Speed Dash
    bool LightSpeedDashPressed { get; }
    bool LightSpeedDashHeld { get; }
    bool LightSpeedDashReleased { get; }

    // Pause
    bool PausePressed { get; }
    bool PauseHeld { get; }
    bool PauseReleased { get; }

    // Options
    bool OptionsPressed { get; }
    bool OptionsHeld { get; }
    bool OptionsReleased { get; }
}