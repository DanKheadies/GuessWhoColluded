// CC 4.0 International License: Attribution--HolisticGaming.com--NonCommercial--ShareALike
// Authors: David W. Corso
// Start: 03/18/2019
// Last:  03/19/2019

using UnityEngine;

// Contains logic for single player mode
public class SinglePlayerLogic : MonoBehaviour
{
    public GWC001 gwc;
    public DialogueManager dMan;
    public MoveOptionsMenuArrow moveOptsArw;
    public OptionsManager oMan;

    public bool bOppQ1;
    public bool bOppQ2;
    public bool bOppQ3;
    public bool bOppQ4;
    public bool bOppQ5;
    public bool bOppQ6;
    public bool bPauseQuestion;
    public bool bPlayerGuessing;
    public bool bPlayQ1;
    public bool bPlayQ2;
    public bool bPlayQ3;
    public bool bPlayQ4;
    public bool bPlayQ5;
    public bool bPlayQ6;
    //public bool bStartSingle;

    public int playerGuessNumber;

    private float pauseTime;

    public string pAnswer;

    void Start()
    {
        // Initializers
        dMan = FindObjectOfType<DialogueManager>();
        gwc = FindObjectOfType<GWC001>();
        moveOptsArw = FindObjectOfType<MoveOptionsMenuArrow>();
        oMan = FindObjectOfType<OptionsManager>();

        pauseTime = 3.0f;
    }
    
    void Update()
    {
        // Wait to ask question
        if (bPauseQuestion)
        {
            pauseTime -= Time.deltaTime;

            if (pauseTime < 0)
            {
                UnpauseQuestion();
            }
        }

        // Single Player - Opponent's First Guess
        if (bOppQ1 &&
            !bPauseQuestion &&
            !dMan.bDialogueActive)
        {
            gwc.GWC_PromptRestrictions();

            gwc.dialogueLines = new string[] {
                "Are you a man?"
            };
            gwc.GWC_DialogueRestter();
            gwc.dPic.sprite = gwc.portPic[48];

            gwc.optionsLines = new string[] {
                "Yes",
                "No"
            };
            gwc.GWC_OptionsResetter_2Q();
        }
        // Single Player - Opponent's Second Guess
        else if (bOppQ2 &&
            !bPauseQuestion &&
            !dMan.bDialogueActive)
        {
            gwc.GWC_PromptRestrictions();

            gwc.dialogueLines = new string[] {
                "Are you looking to the right?"
            };
            gwc.GWC_DialogueRestter();
            gwc.dPic.sprite = gwc.portPic[48];

            gwc.optionsLines = new string[] {
                "Yes",
                "No"
            };
            gwc.GWC_OptionsResetter_2Q();
        }
        // Single Player - Opponent's Third Guess
        else if (bOppQ3 &&
            !bPauseQuestion &&
            !dMan.bDialogueActive)
        {
            gwc.GWC_PromptRestrictions();

            gwc.dialogueLines = new string[] {
                "Are you wearing red?"
            };
            gwc.GWC_DialogueRestter();
            gwc.dPic.sprite = gwc.portPic[48];

            gwc.optionsLines = new string[] {
                "Yes",
                "No"
            };
            gwc.GWC_OptionsResetter_2Q();
        }
        // Single Player - Opponent's Fourth Guess
        else if (bOppQ4 &&
            !bPauseQuestion &&
            !dMan.bDialogueActive)
        {
            gwc.GWC_PromptRestrictions();

            if (gwc.oppName == "Trump")
            {
                gwc.dialogueLines = new string[] {
                    "Are or were you working in the White House?"
                };
            }
            else if (gwc.oppName == "Mueller")
            {
                gwc.dialogueLines = new string[] {
                    "Are or were you working on Mueller's investigation team?"
                };
            }

            gwc.GWC_DialogueRestter();
            gwc.dPic.sprite = gwc.portPic[48];

            gwc.optionsLines = new string[] {
                "Yes",
                "No"
            };
            gwc.GWC_OptionsResetter_2Q();
        }
        // Single Player - Opponent's Fifth Guess
        else if (bOppQ5 &&
            !bPauseQuestion &&
            !dMan.bDialogueActive)
        {
            gwc.GWC_PromptRestrictions();

            gwc.dialogueLines = new string[] {
                "Are you a media member?"
            };
            gwc.GWC_DialogueRestter();
            gwc.dPic.sprite = gwc.portPic[48];

            gwc.optionsLines = new string[] {
                "Yes",
                "No"
            };
            gwc.GWC_OptionsResetter_2Q();
        }
        // Single Player - Opponent's Sixth Guess
        else if (bOppQ6 &&
            !bPauseQuestion &&
            !dMan.bDialogueActive)
        {
            gwc.GWC_PromptRestrictions();

            if (gwc.oppName == "Trump")
            {
                gwc.dialogueLines = new string[] {
                    "Got it! Are you Donald Trump?"
                };
            }
            else if (gwc.oppName == "Mueller")
            {
                gwc.dialogueLines = new string[] {
                    "Ah ha! Are you Robert Mueller?"
                };
            }

            gwc.GWC_DialogueRestter();
            gwc.dPic.sprite = gwc.portPic[48];

            gwc.optionsLines = new string[] {
                "Yes",
                "No"
            };
            gwc.GWC_OptionsResetter_2Q();
        }

        // Single Player - Player's First Guess
        if (bPlayerGuessing &&
            playerGuessNumber == 1 &&
            !dMan.bDialogueActive)
        {
            bPlayerGuessing = false;
            bPlayQ1 = true;

            gwc.GWC_PromptRestrictions();

            gwc.dialogueLines = new string[] {
                "Hmmm..."
            };
            gwc.GWC_DialogueRestter();
            gwc.dPic.sprite = gwc.portPic[gwc.randomCharacter];

            // The meat of the logic tree
            // Will want to know what team player is on & against (worked in WH vs on MIT)
            // Keep track of what has been asked
            // Allow user to select a character (or hold down again cancel)
            gwc.optionsLines = new string[] {
                "Are you wearing red?",
                "Are you a female?",
                "You work in the white house?",
                "I know who it is!"
            };
            gwc.GWC_OptionsResetter_4Q();
        }
        // Single Player - Player's Second Guess
        else if (bPlayerGuessing &&
                 playerGuessNumber == 2 &&
                 !dMan.bDialogueActive)
        {
            bPlayerGuessing = false;
            bPlayQ2 = true;

            gwc.GWC_PromptRestrictions();

            gwc.dialogueLines = new string[] {
                "Hmmm..."
            };
            gwc.GWC_DialogueRestter();
            gwc.dPic.sprite = gwc.portPic[gwc.randomCharacter];

            gwc.optionsLines = new string[] {
                "Are you wearing blue?",
                "Are you a male?",
                "Are you blonde?",
                "I know who it is!"
            };
            gwc.GWC_OptionsResetter_4Q();
        }
        // Single Player - Player's Third Guess
        else if (bPlayerGuessing &&
                 playerGuessNumber == 3 &&
                 !dMan.bDialogueActive)
        {
            bPlayerGuessing = false;
            bPlayQ3 = true;

            gwc.GWC_PromptRestrictions();

            gwc.dialogueLines = new string[] {
                "Hmmm..."
            };
            gwc.GWC_DialogueRestter();
            gwc.dPic.sprite = gwc.portPic[gwc.randomCharacter];

            if (gwc.oppName == "Trump")
            {
                gwc.optionsLines = new string[] {
                    "On Trump's campaign team?",
                    "You w/ a 2016 US party?",
                    "You looking to the left?",
                    "I know who it is!"
                };
            }
            else if (gwc.oppName == "Mueller")
            {
                gwc.optionsLines = new string[] {
                    "On Mueller's investigation?",
                    "Are you a female?",
                    "Are you wearing glasses?",
                    "I know who it is!"
                };
            }
            
            gwc.GWC_OptionsResetter_4Q();
        }
        // Single Player - Player's Fourth Guess
        else if (bPlayerGuessing &&
                 playerGuessNumber == 4 &&
                 !dMan.bDialogueActive)
        {
            bPlayerGuessing = false;
            bPlayQ4 = true;

            gwc.GWC_PromptRestrictions();

            gwc.dialogueLines = new string[] {
                "Hmmm..."
            };
            gwc.GWC_DialogueRestter();
            gwc.dPic.sprite = gwc.portPic[gwc.randomCharacter];

            gwc.optionsLines = new string[] {
                "Are you wearing purple?",
                "You Republican in 2016?",
                "You fired by Trump?",
                "I know who it is!"
            };
            gwc.GWC_OptionsResetter_4Q();
        }
        // Single Player - Player's Fifth Guess
        else if (bPlayerGuessing &&
                 playerGuessNumber == 5 &&
                 !dMan.bDialogueActive)
        {
            bPlayerGuessing = false;
            bPlayQ5 = true;

            gwc.GWC_PromptRestrictions();

            gwc.dialogueLines = new string[] {
                "Hmmm..."
            };
            gwc.GWC_DialogueRestter();
            gwc.dPic.sprite = gwc.portPic[gwc.randomCharacter];

            gwc.optionsLines = new string[] {
                "Are you bald-ish?",
                "You wearing a tie?",
                "You in a DJT tweet?",
                "I know who it is!"
            };
            gwc.GWC_OptionsResetter_4Q();
        }
        // Single Player - Player's Sixth Guess
        else if (bPlayerGuessing &&
                 playerGuessNumber == 6 &&
                 !dMan.bDialogueActive)
        {
            bPlayerGuessing = false;
            bPlayQ6 = true;

            gwc.GWC_PromptRestrictions();

            if (gwc.oppName == "Trump" &&
                gwc.teamName == "Trump")
            {
                gwc.dialogueLines = new string[] {
                    "I think I know who's been leaking information..."
                };
            }
            else if (gwc.oppName == "Trump" &&
                     gwc.teamName == "Mueller")
            {
                gwc.dialogueLines = new string[] {
                    "I think I know who's been colluding..."
                };
            }
            else if (gwc.oppName == "Mueller")
            {
                gwc.dialogueLines = new string[] {
                    "I think I know who's been leading this witch hunt..."
                };
            }
            
            gwc.GWC_DialogueRestter();
            gwc.dPic.sprite = gwc.portPic[gwc.randomCharacter];

            // Prompt Sam to say, "Select a person..."
            // Sam will say are you sure it's X person
            // Yup or no...
        }
    }

    public void LogicTree()
    {
        // Single Player - Opponent Question 1 
        if (bOppQ1)
        {
            if (moveOptsArw.currentPosition == MoveOptionsMenuArrow.ArrowPos.Opt1)
            {
                pAnswer = "yes";
            }
            else if (moveOptsArw.currentPosition == MoveOptionsMenuArrow.ArrowPos.Opt2)
            {
                pAnswer = "no";
            }

            bOppQ1 = false;
            gwc.bSingleReminder = true;

            oMan.ResetOptions();
        }
        // Single Player - Opponent Question 2 
        else if (bOppQ2)
        {
            if (moveOptsArw.currentPosition == MoveOptionsMenuArrow.ArrowPos.Opt1)
            {
                pAnswer = "yes";
            }
            else if (moveOptsArw.currentPosition == MoveOptionsMenuArrow.ArrowPos.Opt2)
            {
                pAnswer = "no";
            }

            bOppQ2 = false;
            gwc.bAllowPlayerToGuess = true;

            oMan.ResetOptions();
        }
        // Single Player - Opponent Question 3 
        else if (bOppQ3)
        {
            if (moveOptsArw.currentPosition == MoveOptionsMenuArrow.ArrowPos.Opt1)
            {
                pAnswer = "yes";
            }
            else if (moveOptsArw.currentPosition == MoveOptionsMenuArrow.ArrowPos.Opt2)
            {
                pAnswer = "no";
            }

            bOppQ3 = false;
            gwc.bAllowPlayerToGuess = true;

            oMan.ResetOptions();
        }
        // Single Player - Opponent Question 4 
        else if (bOppQ4)
        {
            if (moveOptsArw.currentPosition == MoveOptionsMenuArrow.ArrowPos.Opt1)
            {
                pAnswer = "yes";
            }
            else if (moveOptsArw.currentPosition == MoveOptionsMenuArrow.ArrowPos.Opt2)
            {
                pAnswer = "no";
            }

            bOppQ4 = false;
            gwc.bAllowPlayerToGuess = true;

            oMan.ResetOptions();
        }
        // Single Player - Opponent Question 5 
        else if (bOppQ5)
        {
            if (moveOptsArw.currentPosition == MoveOptionsMenuArrow.ArrowPos.Opt1)
            {
                pAnswer = "yes";
            }
            else if (moveOptsArw.currentPosition == MoveOptionsMenuArrow.ArrowPos.Opt2)
            {
                pAnswer = "no";
            }

            bOppQ5 = false;
            gwc.bAllowPlayerToGuess = true;

            oMan.ResetOptions();
        }
        // Single Player - Opponent Question 6 
        else if (bOppQ6)
        {
            if (moveOptsArw.currentPosition == MoveOptionsMenuArrow.ArrowPos.Opt1)
            {
                pAnswer = "yes";
            }
            else if (moveOptsArw.currentPosition == MoveOptionsMenuArrow.ArrowPos.Opt2)
            {
                pAnswer = "no";
            }

            bOppQ6 = false;
            gwc.bAllowPlayerToGuess = true;

            oMan.ResetOptions();
        }

        // Single Player - Player Question 1 
        else if (bPlayQ1)
        {
            if (moveOptsArw.currentPosition == MoveOptionsMenuArrow.ArrowPos.Opt1)
            {
                // "Are you wearing red?";
            }
            else if (moveOptsArw.currentPosition == MoveOptionsMenuArrow.ArrowPos.Opt2)
            {
                // "Are you a female?"
            }
            else if (moveOptsArw.currentPosition == MoveOptionsMenuArrow.ArrowPos.Opt3)
            {
                // "Do or did you work in the white house?"
            }
            else if (moveOptsArw.currentPosition == MoveOptionsMenuArrow.ArrowPos.Opt4)
            {
                // "I know who it is!"
            }

            bPlayQ1 = false;
            bOppQ2 = true;
            PauseQuestion();
            
            oMan.ResetOptions();
        }
        // Single Player - Player Question 2 
        else if (bPlayQ2)
        {
            if (moveOptsArw.currentPosition == MoveOptionsMenuArrow.ArrowPos.Opt1)
            {
                // "Are you wearing red?";
            }
            else if (moveOptsArw.currentPosition == MoveOptionsMenuArrow.ArrowPos.Opt2)
            {
                // "Are you a female?"
            }
            else if (moveOptsArw.currentPosition == MoveOptionsMenuArrow.ArrowPos.Opt3)
            {
                // "Do or did you work in the white house?"
            }
            else if (moveOptsArw.currentPosition == MoveOptionsMenuArrow.ArrowPos.Opt4)
            {
                // "I know who it is!"
            }

            bPlayQ2 = false;
            bOppQ3 = true;
            PauseQuestion();

            oMan.ResetOptions();
        }
        // Single Player - Player Question 3 
        else if (bPlayQ3)
        {
            if (moveOptsArw.currentPosition == MoveOptionsMenuArrow.ArrowPos.Opt1)
            {
                // "Are you wearing red?";
            }
            else if (moveOptsArw.currentPosition == MoveOptionsMenuArrow.ArrowPos.Opt2)
            {
                // "Are you a female?"
            }
            else if (moveOptsArw.currentPosition == MoveOptionsMenuArrow.ArrowPos.Opt3)
            {
                // "Do or did you work in the white house?"
            }
            else if (moveOptsArw.currentPosition == MoveOptionsMenuArrow.ArrowPos.Opt4)
            {
                // "I know who it is!"
            }

            bPlayQ3 = false;
            bOppQ4 = true;
            PauseQuestion();

            oMan.ResetOptions();
        }
        // Single Player - Player Question 4 
        else if (bPlayQ4)
        {
            if (moveOptsArw.currentPosition == MoveOptionsMenuArrow.ArrowPos.Opt1)
            {
                // "Are you wearing red?";
            }
            else if (moveOptsArw.currentPosition == MoveOptionsMenuArrow.ArrowPos.Opt2)
            {
                // "Are you a female?"
            }
            else if (moveOptsArw.currentPosition == MoveOptionsMenuArrow.ArrowPos.Opt3)
            {
                // "Do or did you work in the white house?"
            }
            else if (moveOptsArw.currentPosition == MoveOptionsMenuArrow.ArrowPos.Opt4)
            {
                // "I know who it is!"
            }

            bPlayQ4 = false;
            bOppQ5 = true;
            PauseQuestion();

            oMan.ResetOptions();
        }
        // Single Player - Player Question 5 
        else if (bPlayQ5)
        {
            if (moveOptsArw.currentPosition == MoveOptionsMenuArrow.ArrowPos.Opt1)
            {
                // "Are you wearing red?";
            }
            else if (moveOptsArw.currentPosition == MoveOptionsMenuArrow.ArrowPos.Opt2)
            {
                // "Are you a female?"
            }
            else if (moveOptsArw.currentPosition == MoveOptionsMenuArrow.ArrowPos.Opt3)
            {
                // "Do or did you work in the white house?"
            }
            else if (moveOptsArw.currentPosition == MoveOptionsMenuArrow.ArrowPos.Opt4)
            {
                // "I know who it is!"
            }

            bPlayQ5 = false;
            bOppQ6 = true;
            PauseQuestion();

            oMan.ResetOptions();
        }
    }

    public void PauseQuestion()
    {
        bPauseQuestion = true;
    }

    public void UnpauseQuestion()
    {
        bPauseQuestion = false;
        pauseTime = 3.0f;
    }
}
