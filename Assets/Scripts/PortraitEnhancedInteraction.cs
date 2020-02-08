using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Windows.Speech;
using System.Linq;

public class PortraitEnhancedInteraction : MonoBehaviour
{
    private KeywordRecognizer keywordRecogniser; //sets up speech rec
    private Dictionary<string, System.Action> actions = new Dictionary<string, System.Action>();


    public Material DefaultMaterial;
    public Material SelectedMaterial;
    public Material[] sharedMaterialsCopy;

    public GameObject PlayerController;
    public AudioSource PlayerAudioSource;

    public AudioClip[] Information;

    public bool _PortraitSelected = false;

    public string KeywordOne;
    // Start is called before the first frame update
    void Start()
    {

        DefaultMaterial = gameObject.GetComponent<Renderer>().sharedMaterials[1]; //finds the default assigned portrait material 
        sharedMaterialsCopy = gameObject.GetComponent<Renderer>().sharedMaterials; //creates a copy of the array of shared materials

        //creates keywords for portrait based speech rec
        
        

        PlayerAudioSource = PlayerController.GetComponent<AudioSource>();

        
    }


    /*
    private void RecognisedSpeech(PhraseRecognizedEventArgs speech)
    {
        Debug.Log(speech.text);
        actions[speech.text].Invoke();



    }
    */
    // Update is called once per frame
    void Update()
    {
        
    }

    public void PortraitSelected() //triggers if the raycast from the point gesture hits the object
    {
        if (_PortraitSelected == false)
        {
            sharedMaterialsCopy[1] = SelectedMaterial; //when selected, changes the material to the alternate glowing version
            gameObject.GetComponent<Renderer>().sharedMaterials = sharedMaterialsCopy; //replaces the sharedmaterials array with the new copy
            //Debug.Log(gameObject + " material changed");

            /*
            actions.Add(KeywordOne, PointOfInterestOne);
            keywordRecogniser = new KeywordRecognizer(actions.Keys.ToArray());
            keywordRecogniser.OnPhraseRecognized += RecognisedSpeech;
            keywordRecogniser.Start();
            */
            _PortraitSelected = true;

        }
        

    }

    public void PortraitUnselected() //same as above but changes back to it's default portrait material
    {

        if (_PortraitSelected == true)
        {
            sharedMaterialsCopy[1] = DefaultMaterial;
            gameObject.GetComponent<Renderer>().sharedMaterials = sharedMaterialsCopy;
            Debug.Log(gameObject + " material changed");

            actions.Clear();
            keywordRecogniser.Stop();

            _PortraitSelected = false;


        }
        
    }

    public void PointOfInterestOne()
    {
        Debug.Log("Point of Interest Works");
        PlayerAudioSource.PlayOneShot(Information[0]);

    }
}
