using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LineController : MonoBehaviour
{
    [SerializeField] private LineRenderer lineRenderer;
    [SerializeField] private Texture[] textures;
    [SerializeField] private float fps=60;
    [SerializeField] private float fpsCouter;
    [SerializeField] private int animationStep;
    [SerializeField] private Vector3 target;
    private float damage;
    EdgeCollider2D edgeCollider;
    private float damageTimer = 0f;
    private float damageInterval = 0.5f;
    void Awake()
    {
        edgeCollider = this.GetComponent<EdgeCollider2D>();
        lineRenderer = GetComponent<LineRenderer>();
    }
    void Update()
    {
        SetEdgeCollider(lineRenderer);
        lineRenderer.SetPosition(1, target);
        fpsCouter += Time.deltaTime;
        if (fpsCouter >= 1 / fps)
        {
            animationStep++;
            if (animationStep == textures.Length)
                animationStep = 0;
            lineRenderer.material.SetTexture("_MainTex", textures[animationStep]);
            fpsCouter = 0;
        }
    }

    void SetEdgeCollider(LineRenderer lineRenderer)
    {
        List<Vector2> edges = new List<Vector2>();

        for (int point = 0; point < lineRenderer.positionCount; point++)
        {
            Vector3 lineRendererPoint = lineRenderer.GetPosition(point);
            edges.Add(new Vector2(lineRendererPoint.x, lineRendererPoint.y-1));
        }

        edgeCollider.SetPoints(edges);
    }

    public void SetDamage(float dam)
    {
        damage = dam;
    } 

    public void AssignTarget(Vector3 startPos, Vector3 newTarget)
    {
        lineRenderer.positionCount = 2;
        lineRenderer.SetPosition(0, startPos);
        target=newTarget;
    }
    private void OnTriggerStay2D(Collider2D collision)
    {

        if (collision.GetComponent<Enemy>() != null)
        {
            if (damageTimer >= damageInterval)
            {
                collision.GetComponent<Enemy>().TakeDamage(damage,Color.green);
                damageTimer = 0f;
            }
            
            else
            {
                damageTimer += Time.deltaTime;
            }
        }
    }
}
