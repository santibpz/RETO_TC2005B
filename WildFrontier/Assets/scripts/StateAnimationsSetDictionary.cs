using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public class StateAnimationsSetDictionary : SerializableDictionary<CharacterState, DirectionalAnimationSet>
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }


    public AnimationClip GetAnimationClipFromState(Vector2 movementInput, CharacterState state)
    {
        if (TryGetValue(state, out DirectionalAnimationSet animationSet))
        {
            return animationSet.GetCorrectAnimationClip(movementInput);
        }
        else
        {
            Debug.LogError($"State {state.name} could not be found in the state animations dictionary");
        }
        // failed to return animation clip
        return null;
    }


}
