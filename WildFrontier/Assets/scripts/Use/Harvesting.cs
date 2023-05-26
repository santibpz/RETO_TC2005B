using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class Harvesting : MonoBehaviour
{
    public Tool tool
    {
        get
        {
            return _tool;
        }
        set
        {
            if (_tool != value)
            {
                _tool = value;
                // update the sprite
                UpdateSprite();
            }
        }
    }

    private void UpdateSprite()
    {
        if (_tool != null)
        {
            spriteRenderer.sprite = _tool.Sprite;

        }
        else
        {
            spriteRenderer.sprite = null;
        }
    }

    [SerializeField] Tool _tool;
    private SpriteRenderer spriteRenderer;

    private void Start()
    {
        spriteRenderer = GetComponent<SpriteRenderer>();
        UpdateSprite();
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        Harvestable harvestable = collision.GetComponent<Harvestable>();
        if(harvestable != null && harvestable.toolType == tool.type)
        {
            harvestable.Harvest(Random.Range(1, 2));
        }
    }
}
