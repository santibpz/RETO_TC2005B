using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "DirectionalAnimationSet", menuName = "WildFrontier/DirectionalAnimationSet")]
public class DirectionalAnimationSet : ScriptableObject
{
    [SerializeField] AnimationClip Up;
    [SerializeField] AnimationClip Down;
    [SerializeField] AnimationClip Left;
    [SerializeField] AnimationClip Right;

    /// <summary>
    /// Based on the input movement direction, the function tries to calculate the correct animation to play based on calculation the distance between the input direction and the vector up, left, down, right.
    /// </summary>
    /// <param name="movementInput"></param>
    /// <returns></returns>
    public AnimationClip GetCorrectAnimationClip(Vector2 movementInput)
    {

        Vector2 closestDirection = GetClosestDirection(movementInput);

        if (closestDirection == Vector2.up)
        {
            return Up;
        }
        else if (closestDirection == Vector2.down)
        {
            return Down;
        }
        else if (closestDirection == Vector2.left)
        {
            return Left;
        }
        else if (closestDirection == Vector2.right)
        {
            return Right;
        }
        else
        {
            throw new Exception($"Direction not expected {closestDirection}");

        }

        Vector2 GetClosestDirection(Vector2 inputDirection)
        {
            Vector2 normalizedDirection = inputDirection.normalized;

            Vector2 closestDirection = Vector2.zero;
            float closestDistance = 0;
            bool isFirstSet = false;

            Vector2[] directionsToCheck = new Vector2[4] { Vector2.up, Vector2.down, Vector2.left, Vector2.right };

            for (int i = 0; i < directionsToCheck.Length; i++)
            {
                if (!isFirstSet)
                {
                    closestDirection = directionsToCheck[i];
                    closestDistance = Vector2.Distance(inputDirection, directionsToCheck[i]);
                    isFirstSet = true;
                }
                else
                {
                    if (Vector2.Distance(inputDirection, directionsToCheck[i]) < closestDistance)
                    {
                        closestDistance = Vector2.Distance(inputDirection, directionsToCheck[i]);
                        closestDirection = directionsToCheck[i];
                    }
                }
            }
            return closestDirection;
        }
    }
}
