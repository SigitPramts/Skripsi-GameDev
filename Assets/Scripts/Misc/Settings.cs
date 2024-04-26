using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public static class Settings 
{
    #region Units
    public const float pixelsPerUnit = 16f;
    public const float tileSizePixels = 16;
    #endregion

    #region Dungeon Build Settings
    public const int maxDungeonRebuildAttemptsForRoomGraph = 1000;
    public const int maxDungeonBuildAttempts = 10;
    #endregion

    #region Room Settings
    public const float fadeInTime = 0.5f; // time to fade in the room
    public const int maxChildCorridors = 3; // Max number of child corridors leading from a room. Maximum should be 3 although this is not recommended since it can cause the dungeon building to fail since the rooms are more likely to not fit together;

    #endregion

    #region Animator Parameters
    // ANimator parameters - player
    public static int aimUp = Animator.StringToHash("aimUp");
    public static int aimDown = Animator.StringToHash("aimDown");
    public static int aimUpRight = Animator.StringToHash("aimUpRight");
    public static int aimUpLeft = Animator.StringToHash("aimUpLeft");
    public static int aimRight = Animator.StringToHash("aimRight");
    public static int aimLeft = Animator.StringToHash("aimLeft");
    public static int isIdle = Animator.StringToHash("isIdle");
    public static int isMoving = Animator.StringToHash("isMoving");
    public static int rollUp = Animator.StringToHash("rollUp");
    public static int rollRight = Animator.StringToHash("rollRight");
    public static int rollLeft = Animator.StringToHash("rollLeft");
    public static int rollDown = Animator.StringToHash("rollDown");
    public static float baseSpeedForPlayerAnimations = 8f;

    // Animator parameters = Enemy
    public static float baseSpeedForEnemyAnimations = 3f;

    // Animator parameters - Door
    public static int open = Animator.StringToHash("open");

    #endregion

    #region Gameobject Tags
    public const string playerTag = "Player";
    public const string playerWeapon = "playerWeapon";
    #endregion

    #region Firing Control
    public const float useAimAngleDistance = 3.5f; // If the target distance is less than this then the aim angle will be used (calculated from player), else the wepon aim angle will be used (calculated from the weapon).
    #endregion

    #region AStar Pathfinding Parameters
    public const int defaultAStarMovementPenalty = 40;
    public const int preferredPathAStarMovementPenalty = 1;
    public const float playerMoveDistanceToRebuildPath = 3f;
    public const float enemyPathRebuildCooldown = 2f;
    #endregion

    #region UI Parameters
    public const float uiAmmoIconSpacing = 4f;
    #endregion
}
