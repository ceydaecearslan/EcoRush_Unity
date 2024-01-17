
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using System.Runtime.CompilerServices;
using DG.Tweening;
using UnityEngine.UI;

public class SpawnManager : MonoBehaviour
{
    public static SpawnManager Instance;

    private void Awake()
    {
        if (Instance)
        {
            Destroy(gameObject);
            return;
        }
        Instance = this;
    }

    RoadSpawner roadSpawner;
    public int PlasticCount = 0;
    public int PaperCount = 0;
    public int GlassCount = 0;

    public TMP_Text PaperText;
    public TMP_Text PlasticText;
    public TMP_Text GlassText;

    public GameObject PaperTrash;
    public GameObject PlasticTrash;
    public GameObject GlassTrash;
    public TMP_Text scoreText;
    public int score = 0;
    public List<GameObject> PaperList = new List<GameObject>();
    public List<GameObject> PlasticList = new List<GameObject>();
    public List<GameObject> GlassList = new List<GameObject>();

    public Slider slider;
    public AudioSource audioSource;
    public AudioClip paperSound;
    public AudioClip plasticSound;
    public AudioClip glassSound;
    void Start()
    {
        roadSpawner = GetComponent<RoadSpawner>();

        for (int i = 0; i < 20; i++)
        {
            PaperList.Add(Instantiate(PaperTrash, Vector3.zero, Quaternion.identity));
            PlasticList.Add(Instantiate(PlasticTrash, Vector3.zero, Quaternion.identity));
            GlassList.Add(Instantiate(GlassTrash, Vector3.zero, Quaternion.identity));
        }
    }

    public void SpawnTriggerEntered()
    {
        roadSpawner.SpawnRoad();
        Debug.Log("SpawntriggerEntered çalıştı");
    }

    public void TrashCountUpdate(TrashType trashType)
    {
        if(trashType == TrashType.Paper)
        {
            PaperCount++;
            PaperText.SetText(PaperCount.ToString());
            score += 5;
            scoreText.SetText(score.ToString());
            audioSource.PlayOneShot(paperSound, 0.5f);
        }
        if(trashType == TrashType.Plastic)
        {
            PlasticCount++;
            PlasticText.SetText(PlasticCount.ToString());
            score += 5;
            scoreText.SetText(score.ToString());
            audioSource.PlayOneShot(plasticSound, 0.5f);
        }
        if(trashType == TrashType.Glass)
        {
            GlassCount++;
            GlassText.SetText(GlassCount.ToString());
            score += 5;
            scoreText.SetText(score.ToString());
            audioSource.PlayOneShot(glassSound, 0.5f);
        }
    }

    public void EmptyTrash(TrashType trashType, Transform TrashCanTrans)
    {
        Transform playerTrans = CharController.Instance.gameObject.transform;
        StartCoroutine(WaitTrashEmpty());
        IEnumerator WaitTrashEmpty()
        {
            Debug.Log("EmptyTrash");
            if(trashType == TrashType.Paper)
            {
                for(int i = PaperCount; i>0; i--)
                {
                    PaperCount--;
                    PaperText.SetText(PaperCount.ToString());
                    score += 100;
                    scoreText.SetText(score.ToString());
                    if(slider.value < 59)
                    {
                        slider.GetComponent<SliderTimer>().TimeAdd(1.5f);
                    }
                    PaperList[i].transform.localScale = Vector3.one * 0.5f;
                    PaperList[i].transform.DOMove(playerTrans.position, 0.0001f);
                    PaperList[i].transform.DOJump(TrashCanTrans.position, 2f, 1, 1f);
                    PaperList[i].transform.DOScale(0f, 1.2f);
                
                    yield return new WaitForSeconds(0.2f);
                }
            
            }

            if(trashType == TrashType.Plastic)
            {
                for(int i= PlasticCount; i>0; i--)
                {
                    PlasticCount--;
                    PlasticText.SetText(PlasticCount.ToString());
                    score += 100;
                    scoreText.SetText(score.ToString());
                    if(slider.value < 59)
                    {
                        slider.GetComponent<SliderTimer>().TimeAdd(1.5f);
                    }
                    PlasticList[i].transform.localScale = Vector3.one * 0.3f;
                    PlasticList[i].transform.DOMove(playerTrans.position, 0.0001f);
                    PlasticList[i].transform.DOJump(TrashCanTrans.position, 2f, 1, 1f);
                    PlasticList[i].transform.DOScale(0f, 1.2f);

                    yield return new WaitForSeconds(0.2f);
                }
            }
            if(trashType == TrashType.Glass)
            {
                for(int i= GlassCount; i>0; i--)
                {
                    GlassCount--;
                    GlassText.SetText(GlassCount.ToString());
                    score += 100;
                    scoreText.SetText(score.ToString());
                    if(slider.value < 59)
                    {
                        slider.GetComponent<SliderTimer>().TimeAdd(1.5f);
                    }
                    GlassList[i].transform.localScale = Vector3.one * 0.5f;
                    GlassList[i].transform.DOMove(playerTrans.position, 0.0001f);
                    GlassList[i].transform.DOJump(TrashCanTrans.position, 2f, 1, 1f);
                    GlassList[i].transform.DOScale(0f, 1.2f);

                    yield return new WaitForSeconds(0.2f);
                }
            }
        }
        
        /*for(int i= count; i>0; i--)
        {

            text.SetText(count.ToString());
        }*/
            
    }
}

public enum TrashType
{
Paper,
Plastic,
Glass
}