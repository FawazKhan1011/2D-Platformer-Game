using UnityEngine;

public class Coin : MonoBehaviour
{
    public Animator animator;
    public int value;

    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.CompareTag("Player"))
        {
            Character character = other.gameObject.GetComponent<Character>();
            if (character != null)
            {
                character.HandleCoinCollision(animator);
            }

            Destroy(gameObject);
            SoundManager.instance.coinsource.PlayOneShot(SoundManager.instance.coinSound);
            CoinCounter.instance.IncreaseCoins(value);
        }
    }
}
