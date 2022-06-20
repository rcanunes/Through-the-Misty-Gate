using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpellsAssetContainer : MonoBehaviour {
    // Start is called before the first frame update
    public static SpellsAssetContainer Instance;

    public Sprite FireballSprite;
    public Sprite ShieldSprite;
    public Sprite BoostSprite;
    public Sprite LightSwordSprite;
    public Sprite DefaultImage;
    public Sprite HydropumpSprite;
    public Sprite SoundwaveSprite;

    private void Awake() {
        Instance = this;
    }
}
