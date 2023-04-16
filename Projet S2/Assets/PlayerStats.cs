
using UnityEngine;
using UnityEngine.UI;

public class PlayerStats : MonoBehaviour
{
     public AudioClip sonmort;
     public AudioClip sondegat;
    public bool IsAlive;
     float prochaine;
    [Header("HP")]
    [SerializeField]
    private float maxHealth = 100f;
    private float currentHealth;

    [SerializeField]
    private Image HealthFill;

    [SerializeField]
    private float HealthDecreaseRateForWaterAndHunger;

    [Header("Hunger")]
    [SerializeField]
    private float maxHunger = 100f;
    private float currentHunger;

    [SerializeField]
    private Image HungerFill;

    [SerializeField]
    private float hungerDecreaseRate;

    [Header("Water")]
    [SerializeField]
    private float maxWater = 100f;
    private float currentWater;

    [SerializeField]
    private Image WaterFill;

    [SerializeField]
    private float WaterDecreaseRate;
    void Awake()
    {
        currentHealth = maxHealth;
        currentHunger = maxHunger;
        currentWater = maxWater;
        prochaine = Time.time;
        IsAlive = true;
    }

    void Update()
    {
        UpdateHungerAndWaterBar();
    }

    void TakeDamage(float damage, bool overTime = false)
    {
        if(Time.time > prochaine)
        {
            GetComponent<AudioSource>().PlayOneShot(sondegat);
            prochaine = Time.time + 3;
        }
        if (overTime)
        {
            currentHealth -= damage * Time.deltaTime;
        }
        else
        {
            currentHealth -= damage;
        }

        if(currentHealth <= 0 && IsAlive)
        {
            IsAlive = false;
            GetComponent<AudioSource>().PlayOneShot(sonmort);
            Debug.Log("Player died");
        }
        UpdateHPbar();
    }

    void UpdateHPbar()
    {
        HealthFill.fillAmount = currentHealth / maxHealth;
    }

    void UpdateHungerAndWaterBar()
    {
        // Diminue la faim au fil du temps et le visuel
        currentHunger -= hungerDecreaseRate * Time.deltaTime;
        HungerFill.fillAmount = currentHunger / maxHunger;

        // empêche de passer le négatif
        currentHunger = currentHunger < 0 ? 0 : currentHunger;
        currentWater = currentWater < 0 ? 0 : currentWater;
        // Diminue la soif au fil du temps et le visuel 
        currentWater -= WaterDecreaseRate * Time.deltaTime;
        WaterFill.fillAmount = currentWater / maxWater;

        // si barre faim / soif à zéro, retire des hp ( *2 pour les deux à 0)
        if (currentHunger <= 0 || currentWater <= 0)
        {
            TakeDamage((currentHunger <= 0 & currentWater <= 0 ? HealthDecreaseRateForWaterAndHunger * 2 : HealthDecreaseRateForWaterAndHunger),true);
        }
    }


}
