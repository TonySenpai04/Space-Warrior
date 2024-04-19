using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MonsterProjectile : GenericProjectile
{
    private int _counter;
    private TrailRenderer _trailRenderer;
    private Material _trailMaterial;

    // 
    public float RicochetChance;

    public float TrailFadeTime;
    public Vector2 TrailLifeTime;
    public Vector2 TrailEndWidth;
    public int damage = 2;

    public override void Awake()
    {
        base.Awake();

        _trailRenderer = GetComponentInChildren<TrailRenderer>();
        if (_trailRenderer)
        {
            // Randomize Trail
            _trailMaterial = _trailRenderer.material;
            var texOffset = _trailMaterial.mainTextureOffset;
            texOffset.x -= Random.Range(-25f, 25f);
            _trailMaterial.mainTextureOffset = texOffset;
            _trailRenderer.time = Random.Range(TrailLifeTime.x, TrailLifeTime.y);
            _trailRenderer.endWidth = Random.Range(TrailEndWidth.x, TrailEndWidth.y);
            _trailColor = _trailMaterial.GetColor("_TintColor");
            _trailColor *= Random.Range(0.5f, 1f);
            TrailFadeTime = Random.Range(1f, 2f);
        }
    }

    // Use this for initialization
    private void Start() { }

    private void Update()
    {
        if (_trailRenderer)
        {
            // Fade Trail
            _trailColor = Color.Lerp(_trailColor, Color.clear, Time.deltaTime * TrailFadeTime);
            _trailMaterial.SetColor("_TintColor", _trailColor);
        }
    }

    private Color _trailColor;

    // Update is called once per frame
    private void FixedUpdate()
    {
    }
    public override void OnTriggerEnter2D(Collider2D collision)
    {
        PlayerController player = collision.gameObject.GetComponent<PlayerController>();
        if (player != null)
        {
            Destroy(gameObject);
            player.GetComponentInChildren<CharacterStats>().health.TakeDamage(damage * player.GetComponentInChildren<CharacterStats>().level.GetLevel());
           
        }
        if(collision.CompareTag("Shield"))
        {
            Destroy(gameObject);
        }
    }

}