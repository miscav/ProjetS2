using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Cam : MonoBehaviour
{
    [SerializeField] Player player;
    [SerializeField] Ray ray;
    [SerializeField] GameObject Interaction;
    [SerializeField] GameObject Text;
    [SerializeField] int QuetesAcheve;
    [SerializeField] private QueteManagement QueteVise;

    void Start()
    {
        ray = new Ray(transform.position, transform.forward*10);
        QuetesAcheve = 0;
        Text.SetActive(false);
        Interaction.SetActive(false);
    }

    // Update is called once per frame
    void Update()
    {
        RaycastHit hit;
        if (Physics.Raycast(transform.position, transform.TransformDirection(Vector3.forward), out hit, 3))
        {
            if(hit.collider.gameObject.CompareTag("Quete"))
            {
                QueteVise = hit.collider.gameObject.GetComponent<QueteManagement>();

                Interaction.SetActive(true);

                if (Input.GetKeyDown(KeyCode.E))
                {
                    if(QueteVise.quete.Count > 0)
                    {
                        if(QueteManagement.QuetesActuelle != null)
                        {
                            if(QueteManagement.QuetesActuelle == QueteVise.quete.Peek())
                            {
                                Text.GetComponentInChildren<Text>().text = "As tu fini la quete ?";
                                Text.SetActive(true);
                            }
                            else
                            {
                                Debug.Log("Quete déjà en cours !");
                            }
                        }
                        else
                        {
                            Text.GetComponentInChildren<Text>().text = QueteVise.quete.Peek().text;
                            Text.SetActive(true);
                        }
                    }
                    else
                    {
                        Debug.Log("Plus de quetes disponibles");
                    }
                }
            }
            else
            {
                Interaction.SetActive(false);
            }
        }
        else
        {
            Interaction.SetActive(false);
        }
    }

    public void Accept()
    {
        if(QueteManagement.QuetesActuelle == null)
        {
            if(QueteVise.quete.Peek() is Principale)
            {
                if (((Principale)QueteVise.quete.Peek()).Requis == 0)
                {
                    QuetesAcheve++;
                    QueteVise.Reussi();
                }
                else if(((Principale)QueteVise.quete.Peek()).Requis == QuetesAcheve)
                {
                    QueteManagement.QuetesActuelle = QueteVise.quete.Peek();
                }
                else
                {
                    Debug.Log("Vous devez effectuez les quetes principales précédantes avant celle ci !");
                }
            }

            Close();
        }
        else
        {
            // tester les requis de la quetes

            // si c'est bon 
            // -> QueteVise.Reussi();

            // sinon 
            // -> afficher que c'est pas bon
            
            Close();
        }
    }

    public void Close()
    {
        Text.SetActive(false);
    }

    public void Kill()
    {
        Text.SetActive(false);
        player.ReceiveDamages(player.GetHealth());
    }
}
