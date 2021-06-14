using UnityEngine;

public class SetAnimationSpeed : MonoBehaviour
{

    Animation _animation;

    public float animSpeed = 1;

    void Start()
    {
        _animation = GetComponent<Animation>();

        _animation[_animation.clip.name].speed = animSpeed;
    }
}
