using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class Harvesting : MonoBehaviour
{
    [SerializeField] Tool _tool;
    private SpriteRenderer spriteRenderer;
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


    private void Start()
    {
        spriteRenderer = GetComponent<SpriteRenderer>(); // get the spriterenderer component
        UpdateSprite(); // update the sprite if the tool selection changes
    }
    private void OnTriggerEnter2D(Collider2D collision) // check when the tool collides with either a rock or a tree
    {
        Harvestable harvestable = collision.GetComponent<Harvestable>();
        if(harvestable != null && harvestable.toolType == tool.type)
        {
            harvestable.Harvest(Random.Range(1, 2));
        }
    }
}
