using UnityEngine;

public class Throw : MonoBehaviour
{
	[Header("References")]
	public GameObject[] gameObjects;
	public Transform spawnPoint;
	public float throwForce = 10f;

	void Update()
	{
		if (Input.GetKeyDown(KeyCode.Space))
		{
			ThrowObject();
		}
	}

	public void ThrowObject()
	{
		GameObject randomObject = gameObjects[Random.Range(0, gameObjects.Length)];

		GameObject thrownObject = Instantiate(randomObject, spawnPoint.position, Quaternion.identity);

		Rigidbody2D rb = thrownObject.GetComponent<Rigidbody2D>();
		if (rb != null)
		{
			Vector2 throwDirection = transform.right;
			rb.AddForce(throwDirection * throwForce, ForceMode2D.Impulse);
		}
	}

	private void OnCollisionEnter2D(Collision2D collision)
	{
		if (collision.gameObject.CompareTag("Food"))
		{
			Invoke("DestoryObject", 2f);
		}
	}

	private void DestoryObject()
	{
		Destroy(gameObject);
	}
}
