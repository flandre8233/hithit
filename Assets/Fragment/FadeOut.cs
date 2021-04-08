using System.Collections;
using UnityEngine;

/// <summary>
/// 淡出效果元件類。
/// </summary>
public class FadeOut : MonoBehaviour
{
    #region 可視變數
    [HideInInspector] [Tooltip("消失時延。")] public float delaySecond = 5F;
    #endregion

    #region 成員變數
    private SpriteRenderer spriteRenderer = null;
    private float fadeSpeed = 0;    // 消逝速度
    #endregion

    #region 功能方法
    /// <summary>
    /// 第一幀呼叫之前觸發。
    /// </summary>
    private void Start()
    {
        if (TryGetComponent(out SpriteRenderer spriteRenderer))
            this.spriteRenderer = spriteRenderer;
        fadeSpeed = this.spriteRenderer.color.a * Time.fixedDeltaTime / delaySecond;
        //StartCoroutine(DestroyNow());
    }

    /*
    /// <summary>
    /// 定時自殺。
    /// </summary>
    /// <returns></returns>
    private IEnumerator DestroyNow()
    {
        yield return new WaitForSeconds(delaySecond);
        Destroy(gameObject);
    }
    */

    /// <summary>
    /// 降低物件透明度，為0後摧毀物件。
    /// 在固定物理幀重新整理時觸發。
    /// </summary>
    private void FixedUpdate()
    {
        float alpha = spriteRenderer.color.a - fadeSpeed;
        spriteRenderer.color = new Color(spriteRenderer.color.r, spriteRenderer.color.r, spriteRenderer.color.r, alpha);
        if (alpha <= 0)
            Destroy(gameObject);
    }
    #endregion
}