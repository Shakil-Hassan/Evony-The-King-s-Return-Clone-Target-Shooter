using System.Collections.Generic;
using Assets.Script.Menu;
using Script.UI;
using UnityEngine;

namespace Script.Player
{
    public enum Tag
    {
        Wall,
        Obstacle
    }
    public class PlayerView : MonoBehaviour
    {
        private PlayerController _playerController;

        [SerializeField] private Tag[] collisionTags;
        [SerializeField] private GameObject projectilePrefab;
        [SerializeField] private int poolSize = 10;
        [SerializeField] private int currentBullets = 10;
        [SerializeField] private float projectileSpeed = 10f;
        [SerializeField] private float maxDottedLineDistance = 5f;
        [SerializeField] private int dottedLineSegments = 10;
        [SerializeField] private LayerMask collisionLayerMask;

        private Vector3 dottedLineEndpoint;
        private ObjectPool<ProjectileView> projectilePool;
        private LineRenderer dottedLineRenderer;

        public void SetPlayerController(PlayerController playerController)
        {
            _playerController = playerController;
        }

        private void Start()
        {
            projectilePool = new ObjectPool<ProjectileView>(projectilePrefab.GetComponent<ProjectileView>(), poolSize, transform);
            dottedLineRenderer = GetComponent<LineRenderer>();
            dottedLineRenderer.positionCount = 0;
        }

        private void Update()
        {
            if (Input.GetMouseButton(0))
            {
                Vector3 mousePos = Camera.main.ScreenToWorldPoint(Input.mousePosition);
                Vector2 direction = (mousePos - transform.position).normalized;
                RaycastHit2D hit = Physics2D.Raycast(transform.position, direction, maxDottedLineDistance, collisionLayerMask);

                if (hit)
                {
                    dottedLineEndpoint = hit.point;
                }
                else
                {
                    dottedLineEndpoint = transform.position + (Vector3)(direction * maxDottedLineDistance);
                }

                DrawDottedLine();
            }
            else if (Input.GetMouseButtonUp(0))
            {
                ShootProjectile();
                dottedLineRenderer.positionCount = 0;
            }
        }

        private void DrawDottedLine()
        {
            dottedLineRenderer.positionCount = dottedLineSegments;

            for (int i = 0; i < dottedLineSegments; i++)
            {
                Vector3 point = Vector3.Lerp(transform.position, dottedLineEndpoint, i / (float)(dottedLineSegments - 1));
                dottedLineRenderer.SetPosition(i, point);
            }
        }

        private void ShootProjectile()
        {
            if (currentBullets <= 0)
            {
                LossMenu.Instance.ShowGameOver();
            }

            currentBullets--;
            UIManager.Instance.UpdateCurrentBullets(currentBullets);
            Debug.Log("Current Bullet" + currentBullets);

            Vector2 direction = (dottedLineEndpoint - transform.position).normalized;

            ProjectileView projectile = projectilePool.GetObject();
            if (projectile != null)
            {
                projectile.transform.position = transform.position;
                projectile.gameObject.SetActive(true);

                Rigidbody2D rb = projectile.GetComponent<Rigidbody2D>();
                rb.velocity = direction * projectileSpeed;
                rb.collisionDetectionMode = CollisionDetectionMode2D.Continuous;
                rb.sharedMaterial = new PhysicsMaterial2D { bounciness = 1f, friction = 0f };

                float angle = Mathf.Atan2(direction.y, direction.x) * Mathf.Rad2Deg;
                projectile.transform.rotation = Quaternion.Euler(new Vector3(0, 0, angle));
            }
        }
    }
}
