using UnityEngine;

[RequireComponent(typeof(Rigidbody2D))]
[RequireComponent(typeof(BoxCollider2D))]
public class Player : MonoBehaviour
{
    public float speed = 5f;
    public Projectile laserPrefab;
    private Projectile laser;
    private Vector2 movementDirection;
    
    private void Update()
    {
        Vector3 position = transform.position;
        movementDirection = Vector2.zero;

        // Update the position and direction of the player based on the input for both horizontal and vertical movement
        if (Input.GetKey(KeyCode.A) || Input.GetKey(KeyCode.LeftArrow))
        {
            position.x -= speed * Time.deltaTime;
            movementDirection = Vector2.left;
        }
        else if (Input.GetKey(KeyCode.D) || Input.GetKey(KeyCode.RightArrow))
        {
            position.x += speed * Time.deltaTime;
            movementDirection = Vector2.right;
        }

        if (Input.GetKey(KeyCode.W) || Input.GetKey(KeyCode.UpArrow))
        {
            position.y += speed * Time.deltaTime;
            movementDirection = Vector2.up;
        }
        else if (Input.GetKey(KeyCode.S) || Input.GetKey(KeyCode.DownArrow))
        {
            position.y -= speed * Time.deltaTime;
            movementDirection = Vector2.down;
        }

        // If there is movement, rotate the player to face the movement direction
        if (movementDirection != Vector2.zero)
        {
            float angle = Mathf.Atan2(movementDirection.y, movementDirection.x) * Mathf.Rad2Deg;
            transform.rotation = Quaternion.Euler(new Vector3(0, 0, angle - 90f));  // Adjust the angle offset for correct orientation
        }

        // Clamp the position of the character so they do not go out of bounds
        Vector3 bottomLeft = Camera.main.ViewportToWorldPoint(new Vector3(0, 0, 0));
        Vector3 topRight = Camera.main.ViewportToWorldPoint(new Vector3(1, 1, 0));
        position.x = Mathf.Clamp(position.x, bottomLeft.x, topRight.x);
        position.y = Mathf.Clamp(position.y, bottomLeft.y, topRight.y);

        // Set the new position
        transform.position = position;

        // Only one laser can be active at a given time so first check that
        // there is not already an active laser
        if (laser == null && (Input.GetKeyDown(KeyCode.Space) || Input.GetMouseButtonDown(0)))
        {
<<<<<<< Updated upstream
            // Create the laser at the player's position and make it move in the player's facing direction
            laser = Instantiate(laserPrefab, transform.position, );

            // Get the player's current facing direction from its rotation
            /*Vector2 shootDirection =*/ ;  // The player's forward (facing) direction is "up" in local space

/*            laser.GetComponent<Rigidbody2D>().velocity = movementDirection * 10f; // Adjust the speed of the laser
*/        }
=======
            // Create the laser and make it move in the player's current movement direction
            //laser = Instantiate(laserPrefab, transform.position, Quaternion.identity);
            //laser.GetComponent<Rigidbody2D>().velocity = movementDirection.normalized * 10f; // Adjust the speed of the laser
            Shoot();
        }
>>>>>>> Stashed changes
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.layer == LayerMask.NameToLayer("Missile") ||
            other.gameObject.layer == LayerMask.NameToLayer("Invader"))
        {
            GameManager.Instance.OnPlayerKilled(this);
        }
    }
<<<<<<< Updated upstream
}
=======

    private void Shoot()
    {
        laserPrefab = Instantiate(this.laserPrefab, this.transform.position, this.transform.rotation);
        laserPrefab.Project(this.transform.up);
        
    }
}
>>>>>>> Stashed changes
