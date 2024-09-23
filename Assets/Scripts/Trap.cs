using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class Trap : MonoBehaviour
{
    // public bool isDangerous = true;
    // public bool isControllable = false;

    public bool moveHorizontally = false;
    public float leftBoundary = -5f;
    public float rightBoundary = 5f;
    public bool moveVertically = false;
    public float downBoundary = -5f;
    public float upBoundary = 5f;
    public float moveSpeed = 10.0f;
    protected Vector3 originalScale;
    protected bool hasTransformed = false;
    public abstract void ActivateSkill();
    public abstract void DeactivateSkill();
    public void Move(Vector2 direction)
    {
        Vector2 actualDir = direction;
        if (!moveHorizontally)
        {
            actualDir.x = 0;
        }
        if (!moveVertically)
        {
            actualDir.y = 0;
        }

        if (actualDir != Vector2.zero)
        {
            Debug.Log($"Trap {name} moving: {actualDir}");
            transform.Translate(actualDir * Time.deltaTime * moveSpeed);
            // limit to within the boundaries
            Vector3 clampedPosition = transform.localPosition;
            clampedPosition.x = Mathf.Clamp(clampedPosition.x, leftBoundary, rightBoundary);
            clampedPosition.y = Mathf.Clamp(clampedPosition.y, downBoundary, upBoundary);
            transform.localPosition = clampedPosition;
        }
    }
    protected void ExpandHorizontally(float n = 2)
    {
        if (!hasTransformed)
        {
            // Double the width of the trap
            transform.localScale = new Vector3(originalScale.x * n, originalScale.y, originalScale.z);
            hasTransformed = true;
            Debug.Log($"{name} expanded to double width.");
        }
    }

    protected void Collapse()
    {
        if (hasTransformed)
        {
            transform.localScale = originalScale;
            hasTransformed = false;
            Debug.Log($"{name} collapsed back to original size.");
        }
    }


}
