using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// 物體分裂效果元件類。
/// </summary>
public class Crasher : MonoBehaviour
{
    #region 可視變數
    [SerializeField]
    [Tooltip("Sprite物件。")]
    private Sprite sprite = null;

    [SerializeField]
    [Tooltip("碎片的層次名稱，用於避碰。")]
    private string layerName = "Fragment";

    [SerializeField]
    [Tooltip("分割點的數量。")]
    private int splitPoint = 3;

    [SerializeField]
    [Tooltip("爆破力乘數。")]
    private float forceMultiply = 50F;

    [SerializeField]
    [Tooltip("碎片消失時延。")]
    private float delaySecond = 5F;
    #endregion

    #region 成員變數
    private int seed = 0;               // 亂數種子
    private float spriteWidth = 0;      // 貼圖實際寬度
    private float spriteHeight = 0;     // 貼圖實際高度
    private List<GameObject> fragments = new List<GameObject>();    // 碎片物件列表
    #endregion

    #region 功能方法
    /// <summary>
    /// 對物件執行粉碎特效。
    /// </summary>
    public void Crash()
    {
        // 屬性初始化
        //spriteWidth = sprite.texture.width;
        //spriteHeight = sprite.texture.height;
        spriteWidth = (int)sprite.rect.width;
        spriteHeight = (int)sprite.rect.height;
        // 獲取所有碎片物件
        GetFragments(CropTexture(sprite), RandomSplits());
        // 彈射碎片物件
        for (int i = 0; i < fragments.Count; i++)
            Ejection(fragments[i]);
    }

    Texture2D CropTexture(Sprite sprite)
    {
        // assume "sprite" is your Sprite object
        Texture2D croppedTexture = new Texture2D((int)sprite.rect.width, (int)sprite.rect.height);
        var pixels = sprite.texture.GetPixels((int)sprite.textureRect.x,
                                                (int)sprite.textureRect.y,
                                                (int)sprite.textureRect.width,
                                                (int)sprite.textureRect.height);
        croppedTexture.SetPixels(pixels);
        croppedTexture.Apply();
        return croppedTexture;
    }

    /// <summary>
    /// 根據割點獲取所有碎片物件。
    /// </summary>
    /// <param name="texture2D">原始物件的紋理。</param>
    /// <param name="splits">割點列表。</param>
    private void GetFragments(Texture2D texture2D, Vector2[] splits)
    {
        // 分別獲取x，y兩個陣列
        float[] splitXs = new float[splits.Length + 2];
        float[] splitYs = new float[splits.Length + 2];
        splitXs[0] = 0;
        splitXs[splitXs.Length - 1] = spriteWidth;
        splitYs[0] = 0;
        splitYs[splitYs.Length - 1] = spriteHeight;
        for (int i = 0; i < splits.Length; i++)
        {
            splitXs[i + 1] = splits[i].x;
            splitYs[i + 1] = spriteHeight - splits[i].y;    // y軸座標系倒轉
        }
        // 對陣列進行升序排序
        Sort<float> sort = new Sort<float>();
        sort.QuickSort(splitXs, 0, splits.Length);
        sort.QuickSort(splitYs, 0, splits.Length);
        // 分割物體
        for (int i = 0; i < splitXs.Length - 1; i++)
        {
            for (int j = 0; j < splitYs.Length - 1; j++)
            {
                float x1 = splitXs[i];
                float y1 = splitYs[j];
                float x2 = splitXs[i + 1];
                float y2 = splitYs[j + 1];
                float centerX = gameObject.transform.position.x - gameObject.transform.localScale.x / 2 + (x1 + x2) / (2 * spriteWidth);
                float centerY = gameObject.transform.position.y - gameObject.transform.localScale.y / 2 + (y1 + y2) / (2 * spriteHeight);
                Rect rect = new Rect(x1, y1, x2 - x1, y2 - y1);
                Sprite sprite = Sprite.Create(texture2D, rect, Vector2.zero);
                Vector2 position = new Vector2(centerX, centerY);
                fragments.Add(CreateFragment(sprite, position));
            }
        }
    }

    /// <summary>
    /// 在spriteRenderer區域內獲取隨機分割點。
    /// </summary>
    /// <returns>分割點陣列。</returns>
    private Vector2[] RandomSplits()
    {
        System.Random random;
        Vector2[] splits = new Vector2[splitPoint];
        // 為了避免割點聚集，先分割區域，再於對應區域隨機取點
        float spanX = spriteWidth / (2 * splitPoint + 1);
        float spanY = spriteHeight / (2 * splitPoint + 1);
        for (int i = 0; i < splitPoint; i++)
        {
            random = new System.Random(unchecked((int)System.DateTime.Now.Ticks) + seed);
            seed++;
            double x = random.NextDouble() * spanX + 2 * (i + 1) * spanX;
            random = new System.Random(unchecked((int)System.DateTime.Now.Ticks) + seed);
            seed++;
            double y = random.NextDouble() * spanY + 2 * (i + 1) * spanY;
            splits[i] = new Vector2((float)x, (float)y);
        }
        return splits;
    }

    /// <summary>
    /// 彈射一個碎片物件。
    /// </summary>
    /// <param name="fragment">碎片物件。</param>
    private void Ejection(GameObject fragment)
    {
        Vector2 start = fragment.transform.position;
        Vector2 end = gameObject.transform.position;
        Vector2 direction = end - start;
        fragment.GetComponent<Rigidbody2D>().AddForce(direction * forceMultiply, ForceMode2D.Impulse);
    }

    /// <summary>
    /// 創造一個碎片物件。
    /// </summary>
    /// <param name="sprite">碎片貼圖。</param>
    /// <param name="position">碎片貼圖位置。</param>
    /// <returns>碎片物件。</returns>
    private GameObject CreateFragment(Sprite sprite, Vector2 position)
    {
        GameObject fragment = new GameObject("Fragment");
        fragment.layer = LayerMask.NameToLayer(layerName);
        fragment.transform.position = position;
        fragment.AddComponent<SpriteRenderer>().sprite = sprite;
        // 可以將碎片視作剛體，這樣會有與地形的碰撞效果
        fragment.AddComponent<Rigidbody2D>();
        fragment.AddComponent<BoxCollider2D>();
        fragment.AddComponent<FadeOut>().delaySecond = delaySecond;     // 新增淡出效果
        return fragment;
    }
    #endregion
}
