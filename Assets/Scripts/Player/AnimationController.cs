using System.Collections;
using UnityEngine;

public class AnimationController : MonoBehaviour
{
    SpriteRenderer sprite;
    [SerializeField] private Color damageColor = Color.red;


    void Start()
    {
        sprite = GetComponent<SpriteRenderer>();
        Healthbehaviour healthbehaviour = GetComponent<Healthbehaviour>();
        healthbehaviour.onDamaged.AddListener(AnimateDamageTaken);
    }

    private void AnimateDamageTaken(int damage)
    {
        float intensity = Mathf.Clamp01(damage / 50f);
        Color color = Color.Lerp(Color.white, damageColor, intensity);
        StartCoroutine(DamageAnimation(color));
    }

    private IEnumerator DamageAnimation(Color color)
    {
        Color originalColor = sprite.color;
        sprite.color = color;
        yield return new WaitForSeconds(0.1f);
        sprite.color = originalColor;
    }


}
