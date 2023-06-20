using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class SetTracker : MonoBehaviour
{
     GameObject player;
     GameObject wolf;
     [SerializeField] GameObject pointer;
     Image arrow;

    public void Start()
    {
        player = GameObject.FindGameObjectWithTag("Player");
        wolf = GameObject.FindGameObjectWithTag("Wolf");
        arrow = GetComponent<Image>();
    }
    public void Update()
    {
        float x = 0f;
        float y = 0f;

        Vector2 A = Camera.main.WorldToScreenPoint(player.transform.position);
        Vector2 B = Camera.main.WorldToScreenPoint(wolf.transform.position);

        // slope
        var m = (B.y - A.y) / (B.x - A.x);
        // y-intercept
        var b = A.y + (-m * A.x);

        // x and y formulas reference
        y = (m * x) + b;
        x = (y - b) / m;

        Vector2 offset = arrow.rectTransform.sizeDelta;
        Rect scrRect = new Rect(offset, new Vector2(Screen.width - offset.x, Screen.height - offset.y));

        // clamp target x pos to screen to help find y
        x = Mathf.Clamp(B.x, scrRect.xMin, scrRect.xMax);
        y = (m * x) + b;

        // if y is off screen clamp it, then find a better x
        if (y < scrRect.yMin || y > scrRect.yMax)
        {
            y = Mathf.Clamp(y, scrRect.yMin, scrRect.yMax);
            x = (y - b) / m;
        }

        // arrow position
        Vector2 C = new Vector2(x, y);

        // this checks if target is on screen or not
        if (Vector2.Distance(B, C) > offset.x)
        {
            // target is far from arrow, so it is off screen
            // show arrow and position it
           
            arrow.enabled = true;
            pointer.SetActive(true);
            arrow.transform.position = C;

            // rotate arrow to point from player to target
            float angle = Mathf.Atan2(B.y - A.y, B.x - A.x) * Mathf.Rad2Deg;
            arrow.transform.rotation = Quaternion.AngleAxis(angle + 1f, Vector3.forward);

        }
        else
        {
            // target is close to arrow, so it is on screen
            // hide arrow
            arrow.enabled = false;
            pointer.SetActive(false);
        }
    }

    private void OnDrawGizmos()
    {
        // Draw line between player and target for debugging
        Vector2 A = player.transform.position;
        Vector2 B = wolf.transform.position;
        Gizmos.DrawLine(A, B);
    }
}
