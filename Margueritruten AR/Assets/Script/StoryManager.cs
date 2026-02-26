using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class StoryManager : MonoBehaviour
{
    public Text storyText;
    public Text titleText;
    public GameObject exploreBtn;
    public int rewardStoryUnlocked;     //1 = true, 0 = false

    // Start is called before the first frame update
    void Start()
    {
        rewardStoryUnlocked = PlayerPrefs.GetInt("rewardStoryUnlocked");
    }

    // Update is called once per frame
    void Update()
    {
        if(rewardStoryUnlocked == 1)
        {
            exploreBtn.SetActive(false);

            titleText.text = "En Røverhistorie Fra Vissenbjerg";

            storyText.text = "Området omkring Vissenbjergbakkerne var engang berømt og berygtet for røvere, der gemte sig i skoven og overfaldt folk. \n \n" +
                "Et af sagnene beretter om en mand og hans datter, Frida, som boede inde i skoven tæt på en røverbande. En dag fik de besøg af en ung, fremmed mand, ved navn Valdemar, som friede til bondens eneste datter og fik et ja. \n \n" +
                "En dag tæt på det forestående bryllup gik datteren en tur i skoven og kom til en hule, hvor røverne holdt til. Der fandt hun til sin store forbløffelse alverdens rigdomme i guld og sølv. \n" +
                "I et andet rum var hun nær ved at besvime, for her lå afhuggede arme og ben. Hun ville skynde sig væk, men i samme øjeblik hørte hun stemmer og besluttede at gemme sig under sengen. \n" +
                "Lidt efter kom en af røverne slæbende på en jomfru, han havde dræbt med en kniv. Han prøvede at vriste en ring af hendes finger, men endte med at hugge hele fingeren af, da ringen sad fast. " +
                "Da opdagede Frida til sin forfærdelse, at morderen var hendes kommende husbond, Valdemar. Fingeren landede under sengen, og da røveren drog videre på togt, stak pigen af. \n \n" +
                "Da bryllupsdagen oprandt og brudeparret sad til bords, hev bruden fingeren frem og spurgte sin nye mand, om han kendte noget til fingeren. Manden blegnede, og kort efter blev hele banden fanget og dræbt. " +
                "Brudens far døde kort efter af chok, og pigen endte sine dage i kloster.";
        }
        else if(rewardStoryUnlocked == 0)
        {
            exploreBtn.SetActive(true);

            titleText.text = "Vissenbjerg";

            storyText.text = "Vissenbjergbakkerne er fredede og byder på et dramatisk landskab formet af istiden, og det tætteste vi i Danmark kommer på Grand Canyon. \n \n" +
                "Opstigningen til Vissenbjerg begynder ved Vissenbjerg Kirke, Fyns højest beliggende kirke. “Udsigten” står der på et skilt. " +
                "Her kan skues mod syd ud over Brænde Å helt til Brændholt Bjerg og Frøbjerg Bavnehøj. Sidstnævnte er Fyns højeste punkt med sine 131 m, knapt 2 m højere end Vissenbjerg. Mod vest er der udsigt helt til Lillebælt. \n \n" +
                "Selve det højeste punkt på Vissenbjerg ligger dog inde i skoven og er mere beskedent, hvad angår udsigten, pga. de mange træer. Det bakkede landskab strækker sig fra Rugård i nord til Glamsbjerg i syd. \n \n" +
                "Der er mange gode vandremuligheder i området, og lægmusklerne syrer til op og ned ad de mange højdedrag. Ved stien bag Terrariet, inde i en lysning til venstre, gemmer sig en talerstol udskåret i træ, " +
                "hvor der kan fortælles røverhistorier. Der er bænke og bålpladser langs de mange ruter og gode steder at spise medbragte madpakker. Og så kan der kigges ned i afgrunden efter svaret på alt.";
        }
    }

    public void exploreArea()
    {
        SceneManager.LoadScene("Main");
    }
}
