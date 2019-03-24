// CC 4.0 International License: Attribution--HolisticGaming.com--NonCommercial--ShareALike
// Authors: David W. Corso
// Start: 03/20/2019
// Last:  03/24/2019

using UnityEngine;

// Contains logic for single player mode
public class SinglePlayerLogic : MonoBehaviour
{
    public Characters chars;
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

    public int playerGuessNumber;
    public int randomInt;

    private float pauseTime;

    public string pAnswer1;
    public string pAnswer2;
    public string pAnswer3;
    public string pAnswer4;
    public string pAnswer5;
    public string pAnswer6;

    void Start()
    {
        // Initializers
        chars = FindObjectOfType<Characters>();
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

            OpponentTreeOne(1);

            gwc.GWC_DialogueRestter();
            gwc.dPic.sprite = gwc.portPic[48];

            gwc.optionsLines = new string[] {
                "Yes",
                "No"//,
                //"I do not recall"
            };
            gwc.GWC_OptionsResetter_2Q();
            //gwc.GWC_OptionsResetter_3Q();
        }
        // Single Player - Opponent's Second Guess
        else if (bOppQ2 &&
            !bPauseQuestion &&
            !dMan.bDialogueActive)
        {
            gwc.GWC_PromptRestrictions();
            
            OpponentTreeOne(2);

            gwc.GWC_DialogueRestter();
            gwc.dPic.sprite = gwc.portPic[48];

            gwc.optionsLines = new string[] {
                "Yes",
                "No"//,
                //"I do not recall"
            };
            gwc.GWC_OptionsResetter_2Q();
            //gwc.GWC_OptionsResetter_3Q();
        }
        // Single Player - Opponent's Third Guess
        else if (bOppQ3 &&
            !bPauseQuestion &&
            !dMan.bDialogueActive)
        {
            gwc.GWC_PromptRestrictions();

            OpponentTreeOne(3);

            gwc.GWC_DialogueRestter();
            gwc.dPic.sprite = gwc.portPic[48];

            gwc.optionsLines = new string[] {
                "Yes",
                "No"//,
                //"I do not recall"
            };
            gwc.GWC_OptionsResetter_2Q();
            //gwc.GWC_OptionsResetter_3Q();
        }
        // Single Player - Opponent's Fourth Guess
        else if (bOppQ4 &&
            !bPauseQuestion &&
            !dMan.bDialogueActive)
        {
            gwc.GWC_PromptRestrictions();

            OpponentTreeOne(4);

            gwc.GWC_DialogueRestter();
            gwc.dPic.sprite = gwc.portPic[48];

            gwc.optionsLines = new string[] {
                "Yes",
                "No"//,
                //"I do not recall"
            };
            gwc.GWC_OptionsResetter_2Q();
            //gwc.GWC_OptionsResetter_3Q();
        }
        // Single Player - Opponent's Fifth Guess
        else if (bOppQ5 &&
            !bPauseQuestion &&
            !dMan.bDialogueActive)
        {
            gwc.GWC_PromptRestrictions();

            OpponentTreeOne(5);

            gwc.GWC_DialogueRestter();
            gwc.dPic.sprite = gwc.portPic[48];

            gwc.optionsLines = new string[] {
                "Yes",
                "No"//,
                //"I do not recall"
            };
            gwc.GWC_OptionsResetter_2Q();
            //gwc.GWC_OptionsResetter_3Q();
        }
        // Single Player - Opponent's Sixth Guess
        else if (bOppQ6 &&
            !bPauseQuestion &&
            !dMan.bDialogueActive)
        {
            gwc.GWC_PromptRestrictions();

            OpponentTreeOne(6);

            //if (gwc.oppName == "Trump")
            //{
            //    gwc.dialogueLines = new string[] {
            //        "Got it! Are you Donald Trump?"
            //    };
            //}
            //else if (gwc.oppName == "Mueller")
            //{
            //    gwc.dialogueLines = new string[] {
            //        "Ah ha! Are you Robert Mueller?"
            //    };
            //}

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
            gwc.dPic.sprite = gwc.portPic[gwc.playerCharacter];

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
            gwc.dPic.sprite = gwc.portPic[gwc.playerCharacter];

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
            gwc.dPic.sprite = gwc.portPic[gwc.playerCharacter];

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
            gwc.dPic.sprite = gwc.portPic[gwc.playerCharacter];

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
            gwc.dPic.sprite = gwc.portPic[gwc.playerCharacter];

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
            gwc.dPic.sprite = gwc.portPic[gwc.playerCharacter];

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
                pAnswer1 = "yes";
            }
            else if (moveOptsArw.currentPosition == MoveOptionsMenuArrow.ArrowPos.Opt2)
            {
                pAnswer1 = "no";
            }

            bOppQ1 = false;
            gwc.bSingleReminder = true;

            oMan.ResetOptions();

            // NPC Response
        }
        // Single Player - Opponent Question 2 
        else if (bOppQ2)
        {
            if (moveOptsArw.currentPosition == MoveOptionsMenuArrow.ArrowPos.Opt1)
            {
                pAnswer2 = "yes";
            }
            else if (moveOptsArw.currentPosition == MoveOptionsMenuArrow.ArrowPos.Opt2)
            {
                pAnswer2 = "no";
            }

            bOppQ2 = false;
            gwc.bAllowPlayerToGuess = true;

            oMan.ResetOptions();

            // NPC Response
        }
        // Single Player - Opponent Question 3 
        else if (bOppQ3)
        {
            if (moveOptsArw.currentPosition == MoveOptionsMenuArrow.ArrowPos.Opt1)
            {
                pAnswer3 = "yes";
            }
            else if (moveOptsArw.currentPosition == MoveOptionsMenuArrow.ArrowPos.Opt2)
            {
                pAnswer3 = "no";
            }

            bOppQ3 = false;
            gwc.bAllowPlayerToGuess = true;

            oMan.ResetOptions();

            // NPC Response
        }
        // Single Player - Opponent Question 4 
        else if (bOppQ4)
        {
            if (moveOptsArw.currentPosition == MoveOptionsMenuArrow.ArrowPos.Opt1)
            {
                pAnswer4 = "yes";
            }
            else if (moveOptsArw.currentPosition == MoveOptionsMenuArrow.ArrowPos.Opt2)
            {
                pAnswer4 = "no";
            }

            bOppQ4 = false;
            gwc.bAllowPlayerToGuess = true;

            oMan.ResetOptions();

            // NPC Response
        }
        // Single Player - Opponent Question 5 
        else if (bOppQ5)
        {
            if (moveOptsArw.currentPosition == MoveOptionsMenuArrow.ArrowPos.Opt1)
            {
                pAnswer5 = "yes";
            }
            else if (moveOptsArw.currentPosition == MoveOptionsMenuArrow.ArrowPos.Opt2)
            {
                pAnswer5 = "no";
            }

            bOppQ5 = false;
            gwc.bAllowPlayerToGuess = true;

            oMan.ResetOptions();

            // NPC Response
        }
        // Single Player - Opponent Question 6 
        else if (bOppQ6)
        {
            if (moveOptsArw.currentPosition == MoveOptionsMenuArrow.ArrowPos.Opt1)
            {
                pAnswer6 = "yes";
            }
            else if (moveOptsArw.currentPosition == MoveOptionsMenuArrow.ArrowPos.Opt2)
            {
                pAnswer6 = "no";
            }

            bOppQ6 = false;
            gwc.bAllowPlayerToGuess = true;

            oMan.ResetOptions();

            // NPC Response
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

    public void OpponentTreeOne(int guessNum)
    {
        if (guessNum == 1)
        {
            if (gwc.teamName == "Trump")
            {
                gwc.dialogueLines = new string[] {
                    "Are you wearing anything blue?"
                };
            }
            else if (gwc.teamName == "Mueller")
            {
                gwc.dialogueLines = new string[] {
                    "Do or have you worked in the Department of Justice?"
                };
            }
            else
            {
                if (gwc.teamName == "Trump")
                {
                    randomInt = Random.Range(23, 47);
                }
                else if (gwc.teamName == "Mueller")
                {
                    randomInt = Random.Range(0, 23);
                }

                gwc.dialogueLines = new string[] {
                    "Umm.. Did you.... Nvm. Are you " + chars.characters[randomInt].charName + "?"
                };
            }
        }
        else if (guessNum == 2)
        {
            if (gwc.teamName == "Trump")
            {
                if (pAnswer1 == "yes") // Wearing Blue
                {
                    gwc.dialogueLines = new string[] {
                        "Do or have you worked in the White House?"
                    };
                }
                else if (pAnswer1 == "no") // Wearing Blue
                {
                    gwc.dialogueLines = new string[] {
                        "Were you a registered Republican in 2016?"
                    };
                }
            }
            else if (gwc.teamName == "Mueller")
            {
                if (pAnswer1 == "yes") // DOJ
                {
                    gwc.dialogueLines = new string[] {
                        "Were you a registered Democrat in 2016?"
                    };
                }
                else if (pAnswer1 == "no") // DOJ
                {
                    gwc.dialogueLines = new string[] {
                        "Do or have you worked in Congress?"
                    };
                }
            }
            else
            {
                if (gwc.teamName == "Trump")
                {
                    randomInt = Random.Range(23, 47);
                }
                else if (gwc.teamName == "Mueller")
                {
                    randomInt = Random.Range(0, 23);
                }

                gwc.dialogueLines = new string[] {
                    "Umm.. Did you.... Nvm. Are you " + chars.characters[randomInt].charName + "?"
                };
            }
        }

        else if (guessNum == 3)
        {
            if (gwc.teamName == "Trump")
            {
                if (pAnswer1 == "yes" && // Wearing Blue
                    pAnswer2 == "yes")   // White House
                {
                    gwc.dialogueLines = new string[] {
                        "Are you blonde?"
                    };
                }
                else if (pAnswer1 == "yes" && // Wearing Blue
                         pAnswer2 == "no")    // White House
                {
                    gwc.dialogueLines = new string[] {
                        "Were you without any US party affiliation in 2016?"
                    };
                }
                else if (pAnswer1 == "no" &&  // Wearing Blue
                         pAnswer2 == "yes")   // Republican
                {
                    gwc.dialogueLines = new string[] {
                        "Are you looking to the left?"
                    };
                }
                else if (pAnswer1 == "no" && // Wearing Blue
                         pAnswer2 == "no")   // Republican
                {
                    gwc.dialogueLines = new string[] {
                        "Were you without any US party affiliation in 2016?"
                    };
                }
            }
            else if (gwc.teamName == "Mueller")
            {
                if (pAnswer1 == "yes" && // DOJ
                    pAnswer2 == "yes")   // Democrat
                {
                    gwc.dialogueLines = new string[] {
                        "Are you a woman?"
                    };
                }
                else if (pAnswer1 == "yes" && // DOJ
                         pAnswer2 == "no")    // Democrat
                {
                    gwc.dialogueLines = new string[] {
                        "Were you a registered Republican in 2016?"
                    };
                }
                else if (pAnswer1 == "no" &&  // DOJ
                         pAnswer2 == "yes")   // Congress
                {
                    gwc.dialogueLines = new string[] {
                        "Are you a woman?"
                    };
                }
                else if (pAnswer1 == "no" &&  // DOJ
                         pAnswer2 == "no")    // Congress
                {
                    gwc.dialogueLines = new string[] {
                        "Are you wearing something red?"
                    };
                }
            }
            else
            {
                if (gwc.teamName == "Trump")
                {
                    randomInt = Random.Range(23, 47);
                }
                else if (gwc.teamName == "Mueller")
                {
                    randomInt = Random.Range(0, 23);
                }

                gwc.dialogueLines = new string[] {
                    "Umm.. Did you.... Nvm. Are you " + chars.characters[randomInt].charName + "?"
                };
            }
        }

        else if (guessNum == 4)
        {
            if (gwc.teamName == "Trump")
            {
                if (pAnswer1 == "yes" && // Wearing Blue
                    pAnswer2 == "yes" && // White House
                    pAnswer3 == "yes")   // Blonde
                {
                    // If Hard, at 33% and should just guess
                    gwc.dialogueLines = new string[] {
                        "Have you been mentioned in a Donald Trump tweet?"
                    };
                }
                else if (pAnswer1 == "yes" && // Wearing Blue
                         pAnswer2 == "yes" && // White House
                         pAnswer3 == "no")    // Blonde
                {
                    // If Hard, at 33% and should just guess
                    gwc.dialogueLines = new string[] {
                        "Are you a woman?"
                    };
                }
                else if (pAnswer1 == "yes" && // Wearing Blue
                         pAnswer2 == "yes" && // White House
                         pAnswer3 == "yes")   // No-US Party
                {
                    // If Hard, at 33% and should just guess
                    gwc.dialogueLines = new string[] {
                        "Are you an American?"
                    };
                }
                else if (pAnswer1 == "yes" && // Wearing Blue
                         pAnswer2 == "yes" && // White House
                         pAnswer3 == "no")    // No-US Party
                {
                    // If Hard, at 50% and should just guess
                    gwc.dialogueLines = new string[] {
                        "Are you wearing a red tie?"
                    };
                }
                else if (pAnswer1 == "no" &&  // Wearing Blue
                         pAnswer2 == "yes" && // Republican
                         pAnswer3 == "yes")   // Looking Left
                {
                    // If Hard, at 33% and should just guess
                    gwc.dialogueLines = new string[] {
                        "Are you a woman?"
                    };
                }
                else if (pAnswer1 == "no" &&  // Wearing Blue
                         pAnswer2 == "yes" && // Republican
                         pAnswer3 == "no")    // Looking Left
                {
                    gwc.dialogueLines = new string[] {
                        "Were you fired by Trump?"
                    };
                }
                else if (pAnswer1 == "no" &&  // Wearing Blue
                         pAnswer2 == "no" &&  // Republican
                         pAnswer3 == "yes")   // No-US Party
                {
                    // If Hard, at 33% and should just guess
                    gwc.dialogueLines = new string[] {
                        "Are you an American?"
                    };
                }
                else if (pAnswer1 == "no" &&  // Wearing Blue
                         pAnswer2 == "no" &&  // Republican
                         pAnswer3 == "no")    // No-US Party
                {
                    // If Hard, at 33% and should just guess
                    gwc.dialogueLines = new string[] {
                        "Were you registered as in Independent in 2016?"
                    };
                }
            }
            else if (gwc.teamName == "Mueller")
            {
                if (pAnswer1 == "yes" && // DOJ
                    pAnswer2 == "yes" && // Democrat
                    pAnswer3 == "yes")   // Woman
                {
                    // If Hard, at 50% and should just guess
                    gwc.dialogueLines = new string[] {
                        "Are you on Mueller's investigation team?"
                    };
                }
                else if (pAnswer1 == "yes" && // DOJ
                         pAnswer2 == "yes" && // Democrat
                         pAnswer3 == "no")    // Woman
                {
                    // If Hard, at 50% and should just guess
                    gwc.dialogueLines = new string[] {
                        "Do you have brown hair?"
                    };
                }
                else if (pAnswer1 == "yes" && // DOJ
                         pAnswer2 == "yes" && // Democrat
                         pAnswer3 == "yes")   // Republican
                {
                    // If Hard, at 50% and should just guess
                    gwc.dialogueLines = new string[] {
                        "Are you wearing glasses?"
                    };
                }
                else if (pAnswer1 == "yes" && // DOJ
                         pAnswer2 == "yes" && // Democrat
                         pAnswer3 == "no")    // Republican
                {
                    // If Hard, at 33% and should just guess
                    gwc.dialogueLines = new string[] {
                        "Were you fired by Trump?"
                    };
                }
                else if (pAnswer1 == "no" &&  // DOJ
                         pAnswer2 == "yes" && // Congress
                         pAnswer3 == "yes")   // Woman
                {
                    // If Hard, at 33% and should just guess
                    gwc.dialogueLines = new string[] {
                        "Do you have blonde hair?"
                    };
                }
                else if (pAnswer1 == "no" &&  // DOJ
                         pAnswer2 == "yes" && // Congress
                         pAnswer3 == "no")    // Woman
                {
                    // If Hard, at 33% and should just guess
                    gwc.dialogueLines = new string[] {
                        "Are you looking to the right?"
                    };
                }
                else if (pAnswer1 == "no" &&  // DOJ
                         pAnswer2 == "no" &&  // Congress
                         pAnswer3 == "yes")   // Red
                {
                    gwc.dialogueLines = new string[] {
                        "Do or have you worked in the White House?"
                    };
                }
                else if (pAnswer1 == "no" &&  // DOJ
                         pAnswer2 == "no" &&  // Congress
                         pAnswer3 == "no")    // Red
                {
                    gwc.dialogueLines = new string[] {
                        "Were you without any US party affiliation in 2016?"
                    };
                }
            }
            else
            {
                if (gwc.teamName == "Trump")
                {
                    randomInt = Random.Range(23, 47);
                }
                else if (gwc.teamName == "Mueller")
                {
                    randomInt = Random.Range(0, 23);
                }

                gwc.dialogueLines = new string[] {
                    "Umm.. Did you.... Nvm. Are you " + chars.characters[randomInt].charName + "?"
                };
            }
        }

        else if (guessNum == 5)
        {
            if (gwc.teamName == "Trump")
            {
                if (pAnswer1 == "yes" && // Wearing Blue
                    pAnswer2 == "yes" && // White House
                    pAnswer3 == "yes" && // Blonde
                    pAnswer4 == "yes")   // Tweet
                {
                    // If Hard, from 33% -> 50% and should just guess
                    gwc.dialogueLines = new string[] {
                        "Were you fired by Trump?"
                    };
                }
                else if (pAnswer1 == "yes" && // Wearing Blue
                         pAnswer2 == "yes" && // White House
                         pAnswer3 == "yes" && // Blonde
                         pAnswer4 == "no")    // Tweet
                {
                    // If Hard, from 33% -> 100%
                    gwc.dialogueLines = new string[] {
                        "Ah HA! You're Erik Prince aren't ya?!"
                    };
                }
                else if (pAnswer1 == "yes" && // Wearing Blue
                         pAnswer2 == "yes" && // White House
                         pAnswer3 == "no" &&  // Blonde
                         pAnswer4 == "yes")   // Woman
                {
                    // If Hard, from 33% -> 50% and should just guess
                    gwc.dialogueLines = new string[] {
                        "Do you have black hair?"
                    };
                }
                else if (pAnswer1 == "yes" && // Wearing Blue
                         pAnswer2 == "yes" && // White House
                         pAnswer3 == "no" &&  // Blonde
                         pAnswer4 == "no")    // Woman
                {
                    // If Hard, from 33% -> 100%
                    gwc.dialogueLines = new string[] {
                        "Ah HA! You're Mike Pence aren't ya?!"
                    };
                }
                else if (pAnswer1 == "yes" && // Wearing Blue
                         pAnswer2 == "yes" && // White House
                         pAnswer3 == "yes" && // No-US Party
                         pAnswer4 == "yes")   // American
                {
                    // If Hard, from 33% -> 50% and should just guess
                    gwc.dialogueLines = new string[] {
                        "Are you a media member?"
                    };
                }
                else if (pAnswer1 == "yes" && // Wearing Blue
                         pAnswer2 == "yes" && // White House
                         pAnswer3 == "yes" && // No-US Party
                         pAnswer4 == "no")    // American
                {
                    // If Hard, from 33% -> 100%
                    gwc.dialogueLines = new string[] {
                        "Ah HA! You're Vladimir Putin aren't ya?!"
                    };
                }
                else if (pAnswer1 == "yes" && // Wearing Blue
                         pAnswer2 == "yes" && // White House
                         pAnswer3 == "no"  && // No-US Party
                         pAnswer4 == "yes")   // Red Tie
                {
                    // If Hard, from 50% -> 100% (unless the consider Mooch to wear blue)
                    gwc.dialogueLines = new string[] {
                        "Ah HA! You're Michael Cohen aren't ya?!"
                    };
                }
                else if (pAnswer1 == "yes" && // Wearing Blue
                         pAnswer2 == "yes" && // White House
                         pAnswer3 == "no" &&  // No-US Party
                         pAnswer4 == "no")    // Red Tie
                {
                    // If Hard, from 50% -> 100%
                    gwc.dialogueLines = new string[] {
                        "Ah HA! You're Donald Trump Jr. aren't ya?!"
                    };
                }
                else if (pAnswer1 == "no" &&  // Wearing Blue
                         pAnswer2 == "yes" && // Republican
                         pAnswer3 == "yes" && // Looking Left
                         pAnswer4 == "yes")   // Woman
                {
                    // If Hard, from 33% -> 50% and should just guess
                    gwc.dialogueLines = new string[] {
                        "Do you have brown hair?"
                    };
                }
                else if (pAnswer1 == "no" &&  // Wearing Blue
                         pAnswer2 == "yes" && // Republican
                         pAnswer3 == "yes" && // Looking Left
                         pAnswer4 == "no")    // Woman
                {
                    // If Hard, from 33% -> 100%
                    gwc.dialogueLines = new string[] {
                        "Ah HA! You're Rudy Giuliani aren't ya?!"
                    };
                }
                else if (pAnswer1 == "no" &&  // Wearing Blue
                         pAnswer2 == "yes" && // Republican
                         pAnswer3 == "no" &&  // Looking Left
                         pAnswer4 == "yes")   // Fired
                {
                    // If Hard, at 50% and should just guess
                    gwc.dialogueLines = new string[] {
                        "Are you wearing shades?"
                    };
                }
                else if (pAnswer1 == "no" &&  // Wearing Blue
                         pAnswer2 == "yes" && // Republican
                         pAnswer3 == "no" &&  // Looking Left
                         pAnswer4 == "no")    // Fired
                {
                    // If Hard, at 50% and should just guess
                    gwc.dialogueLines = new string[] {
                        "Are you a giant piece of shit? (And look like one?)"
                    };
                }
                else if (pAnswer1 == "no" &&  // Wearing Blue
                         pAnswer2 == "no" &&  // Republican
                         pAnswer3 == "yes" && // No-US Party
                         pAnswer4 == "yes")   // American
                {
                    // If Hard, from 33% -> 100%
                    gwc.dialogueLines = new string[] {
                        "Ah HA! You're Jared Kushner aren't ya?!"
                    };
                }
                else if (pAnswer1 == "no" &&  // Wearing Blue
                         pAnswer2 == "no" &&  // Republican
                         pAnswer3 == "yes" && // No-US Party
                         pAnswer4 == "no")    // American
                {
                    // If Hard, from 33% -> 50% and should just guess
                    gwc.dialogueLines = new string[] {
                        "Do you have facial hair?"
                    };
                }
                else if (pAnswer1 == "no" &&  // Wearing Blue
                         pAnswer2 == "no" &&  // Republican
                         pAnswer3 == "no" &&  // No-US Party
                         pAnswer4 == "yes")   // Independent
                {
                    // If Hard, from 33% -> 50% and should just guess
                    gwc.dialogueLines = new string[] {
                        "Are you wearing a purple tie?"
                    };
                }
                else if (pAnswer1 == "no" &&  // Wearing Blue
                         pAnswer2 == "no" &&  // Republican
                         pAnswer3 == "no" &&  // No-US Party
                         pAnswer4 == "no")    // Independent
                {
                    // If Hard, from 33% -> 100%
                    gwc.dialogueLines = new string[] {
                        "Ah HA! You're Michael Flynn aren't ya?!"
                    };
                }
            }
            else if (gwc.teamName == "Mueller")
            {
                if (pAnswer1 == "yes" && // DOJ
                    pAnswer2 == "yes" && // Democrat
                    pAnswer3 == "yes" && // Woman
                    pAnswer4 == "yes")   // Mueller
                {
                    // If Hard, from 50% -> 100%
                    gwc.dialogueLines = new string[] {
                        "Ah HA! You're Jeannie Rhee aren't ya?!"
                    };
                }
                else if (pAnswer1 == "yes" && // DOJ
                         pAnswer2 == "yes" && // Democrat
                         pAnswer3 == "yes" && // Woman
                         pAnswer4 == "no")    // Mueller
                {
                    // If Hard, from 50% -> 100%
                    gwc.dialogueLines = new string[] {
                        "Ah HA! You're Sally Yates aren't ya?!"
                    };
                }
                else if (pAnswer1 == "yes" && // DOJ
                         pAnswer2 == "yes" && // Democrat
                         pAnswer3 == "yes" && // Woman
                         pAnswer4 == "yes")   // Brown Hair
                {
                    // If Hard, from 50% -> 100%
                    gwc.dialogueLines = new string[] {
                        "Ah HA! You're Andrew Weissmann aren't ya?!"
                    };
                }
                else if (pAnswer1 == "yes" && // DOJ
                         pAnswer2 == "yes" && // Democrat
                         pAnswer3 == "yes" && // Woman
                         pAnswer4 == "no")    // Brown Hair
                {
                    // If Hard, from 50% -> 100%
                    gwc.dialogueLines = new string[] {
                        "Ah HA! You're Michael Dreeban aren't ya?!"
                    };
                }
                else if (pAnswer1 == "yes" && // DOJ
                         pAnswer2 == "yes" && // Democrat
                         pAnswer3 == "yes" && // Republican
                         pAnswer4 == "yes")   // Glasses
                {
                    // If Hard, from 50% -> 100%
                    gwc.dialogueLines = new string[] {
                        "Ah HA! You're Rod Rosenstein aren't ya?!"
                    };
                }
                else if (pAnswer1 == "yes" && // DOJ
                         pAnswer2 == "yes" && // Democrat
                         pAnswer3 == "yes" && // Republican
                         pAnswer4 == "no")    // Glasses
                {
                    // If Hard, from 50% -> 100%
                    gwc.dialogueLines = new string[] {
                        "Ah HA! You're Robert Mueller aren't ya?!"
                    };
                }
                else if (pAnswer1 == "yes" && // DOJ
                         pAnswer2 == "yes" && // Democrat
                         pAnswer3 == "no" &&  // Republican
                         pAnswer4 == "yes")   // Fired
                {
                    // If Hard, from 33% -> 100%
                    gwc.dialogueLines = new string[] {
                        "Ah HA! You're James Comey aren't ya?!"
                    };
                }
                else if (pAnswer1 == "yes" && // DOJ
                         pAnswer2 == "yes" && // Democrat
                         pAnswer3 == "no" &&  // Republican
                         pAnswer4 == "no")    // Fired
                {
                    // If Hard, from 33% -> 50% and should guess
                    gwc.dialogueLines = new string[] {
                        "Do you have glasses?"
                    };
                }
                else if (pAnswer1 == "no" &&  // DOJ
                         pAnswer2 == "yes" && // Congress
                         pAnswer3 == "yes" && // Woman
                         pAnswer4 == "yes")   // Blonde
                {
                    // If Hard, from 33% -> 50% and should guess
                    gwc.dialogueLines = new string[] {
                        "Do or have you worked in the White House?"
                    };
                }
                else if (pAnswer1 == "no" &&  // DOJ
                         pAnswer2 == "yes" && // Congress
                         pAnswer3 == "yes" && // Woman
                         pAnswer4 == "no")    // Blonde
                {
                    // If Hard, from 33% -> 100%
                    gwc.dialogueLines = new string[] {
                        "Ah HA! You're Nancy Pelosi aren't ya?!"
                    };
                }
                else if (pAnswer1 == "no" &&  // DOJ
                         pAnswer2 == "yes" && // Congress
                         pAnswer3 == "no" &&  // Woman
                         pAnswer4 == "yes")   // Right
                {
                    // If Hard, at 50% and should guess
                    gwc.dialogueLines = new string[] {
                        "Are you bald?"
                    };
                }
                else if (pAnswer1 == "no" &&  // DOJ
                         pAnswer2 == "yes" && // Congress
                         pAnswer3 == "no" &&  // Woman
                         pAnswer4 == "no")    // Right
                {
                    // If Hard, at 50% and should guess
                    gwc.dialogueLines = new string[] {
                        "Are you black?"
                    };
                }
                else if (pAnswer1 == "no" &&  // DOJ
                         pAnswer2 == "no" &&  // Congress
                         pAnswer3 == "yes" && // Glasses
                         pAnswer4 == "yes")   // Red
                {
                    // If Hard, at 33% and should guess
                    gwc.dialogueLines = new string[] {
                        "Do or have you worked in the white house?"
                    };
                }
                else if (pAnswer1 == "no" &&  // DOJ
                         pAnswer2 == "no" &&  // Congress
                         pAnswer3 == "yes" && // Red
                         pAnswer4 == "yes")   // White House
                {
                    // If Hard, at 50% and should guess
                    gwc.dialogueLines = new string[] {
                        "Do you have grey hair?"
                    };
                }
                else if (pAnswer1 == "no" &&  // DOJ
                         pAnswer2 == "no" &&  // Congress
                         pAnswer3 == "yes" && // Red
                         pAnswer4 == "no")    // White House
                {
                    // If Hard, at 50% and should guess
                    gwc.dialogueLines = new string[] {
                        "Are you British?"
                    };
                }
                else if (pAnswer1 == "no" &&  // DOJ
                         pAnswer2 == "no" &&  // Congress
                         pAnswer3 == "no" &&  // Red
                         pAnswer4 == "yes")   // No-US Party
                {
                    // If Hard, at 50% and should guess
                    gwc.dialogueLines = new string[] {
                        "Do or did you work for the FBI?"
                    };
                }
                else if (pAnswer1 == "no" &&  // DOJ
                         pAnswer2 == "no" &&  // Congress
                         pAnswer3 == "no" &&  // Red
                         pAnswer4 == "no")    // No-US Party
                {
                    // If Hard, at 50% and should guess
                    gwc.dialogueLines = new string[] {
                        "Do you have facial hair?"
                    };
                }
            }
            else
            {
                if (gwc.teamName == "Trump")
                {
                    randomInt = Random.Range(23, 47);
                }
                else if (gwc.teamName == "Mueller")
                {
                    randomInt = Random.Range(0, 23);
                }

                gwc.dialogueLines = new string[] {
                    "Umm.. Did you.... Nvm. Are you " + chars.characters[randomInt].charName + "?"
                };
            }
        }

        else if (guessNum == 6)
        {
            if (gwc.teamName == "Trump")
            {
                if (pAnswer1 == "yes" && // Wearing Blue
                    pAnswer2 == "yes" && // White House
                    pAnswer3 == "yes" && // Blonde
                    pAnswer4 == "yes" && // Tweet
                    pAnswer5 == "yes")   // Fired
                {
                    // If Hard, from 50% -> 100%
                    gwc.dialogueLines = new string[] {
                        "Ah HA! You're Sean Spicer aren't ya?!"
                    };
                }
                else if (pAnswer1 == "yes" && // Wearing Blue
                         pAnswer2 == "yes" && // White House
                         pAnswer3 == "yes" && // Blonde
                         pAnswer4 == "yes" && // Tweet
                         pAnswer5 == "no")    // Fired
                {
                    // If Hard, from 50% -> 100%
                    gwc.dialogueLines = new string[] {
                        "Ah HA! You're Donald J Trump aren't ya?!"
                    };
                }
                else if (pAnswer1 == "yes" && // Wearing Blue
                         pAnswer2 == "yes" && // White House
                         pAnswer3 == "no" &&  // Blonde
                         pAnswer4 == "yes" && // Woman
                         pAnswer5 == "yes")   // Black Hair
                {
                    // If Hard, from 50% -> 100%
                    gwc.dialogueLines = new string[] {
                        "Ah HA! You're Omarosa aren't ya?!"
                    };
                }
                else if (pAnswer1 == "yes" && // Wearing Blue
                         pAnswer2 == "yes" && // White House
                         pAnswer3 == "no" &&  // Blonde
                         pAnswer4 == "yes" && // Woman
                         pAnswer5 == "no")    // Black Hair
                {
                    // If Hard, from 50% -> 100%
                    gwc.dialogueLines = new string[] {
                        "Ah HA! You're Hope Hicks aren't ya?!"
                    };
                }
                else if (pAnswer1 == "yes" && // Wearing Blue
                         pAnswer2 == "yes" && // White House
                         pAnswer3 == "yes" && // No-US Party
                         pAnswer4 == "yes" && // American
                         pAnswer5 == "yes")   // Media Member
                {
                    // If Hard, from 50% -> 100%
                    gwc.dialogueLines = new string[] {
                        "Ah HA! You're Alex Jones aren't ya?!"
                    };
                }
                else if (pAnswer1 == "yes" && // Wearing Blue
                         pAnswer2 == "yes" && // White House
                         pAnswer3 == "yes" && // No-US Party
                         pAnswer4 == "yes" && // American
                         pAnswer5 == "no")    // Media Member
                {
                    // If Hard, from 50% -> 100%
                    gwc.dialogueLines = new string[] {
                        "Ah HA! You're George Papadopoulos aren't ya?!"
                    };
                }
                else if (pAnswer1 == "yes" && // Wearing Blue
                         pAnswer2 == "yes" && // White House
                         pAnswer3 == "no" &&  // No-US Party
                         pAnswer4 == "yes" && // Red Tie
                         pAnswer5 == "no")    // Being Cohen
                {
                    // Incase they consider Mooch to wear blue
                    gwc.dialogueLines = new string[] {
                        "Ah HA! You're The Mooch aren't ya?!"
                    };
                }
                else if (pAnswer1 == "no" &&  // Wearing Blue
                         pAnswer2 == "yes" && // Republican
                         pAnswer3 == "yes" && // Looking Left
                         pAnswer4 == "yes" && // Woman
                         pAnswer5 == "yes")   // Brown Hair
                {
                    // If Hard, from 50% -> 100%
                    gwc.dialogueLines = new string[] {
                        "Ah HA! You're Sarah Huckabee Sanders aren't ya?!"
                    };
                }
                else if (pAnswer1 == "no" &&  // Wearing Blue
                         pAnswer2 == "yes" && // Republican
                         pAnswer3 == "yes" && // Looking Left
                         pAnswer4 == "yes" && // Woman
                         pAnswer5 == "no")   // Brown Hair
                {
                    // If Hard, from 50% -> 100%
                    gwc.dialogueLines = new string[] {
                        "Ah HA! You're Kellyanne Conway aren't ya?!"
                    };
                }
                else if (pAnswer1 == "no" &&  // Wearing Blue
                         pAnswer2 == "yes" && // Republican
                         pAnswer3 == "no" &&  // Looking Left
                         pAnswer4 == "yes" && // Fired
                         pAnswer5 == "yes")   // Glasses
                {
                    // If Hard, from 50% -> 100%
                    gwc.dialogueLines = new string[] {
                        "Ah HA! You're The Mooch aren't ya?!"
                    };
                }
                else if (pAnswer1 == "no" &&  // Wearing Blue
                         pAnswer2 == "yes" && // Republican
                         pAnswer3 == "no" &&  // Looking Left
                         pAnswer4 == "yes" && // Fired
                         pAnswer5 == "no")    // Glasses
                {
                    // If Hard, from 50% -> 100%
                    gwc.dialogueLines = new string[] {
                        "Ah HA! You're Steve Bannon aren't ya?!"
                    };
                }
                else if (pAnswer1 == "no" &&  // Wearing Blue
                         pAnswer2 == "yes" && // Republican
                         pAnswer3 == "no" &&  // Looking Left
                         pAnswer4 == "no" &&  // Fired
                         pAnswer5 == "yes")   // Piece of Shit
                {
                    // If Hard, from 50% -> 100%
                    gwc.dialogueLines = new string[] {
                        "Ah HA! You're Ajit Pai aren't ya?!"
                    };
                }
                else if (pAnswer1 == "no" &&  // Wearing Blue
                         pAnswer2 == "yes" && // Republican
                         pAnswer3 == "no" &&  // Looking Left
                         pAnswer4 == "no" &&  // Fired
                         pAnswer5 == "no")    // Piece of Shit
                {
                    // If Hard, from 50% -> 100%
                    gwc.dialogueLines = new string[] {
                        "Ah HA! You're Melania Trump aren't ya?!"
                    };
                }
                else if (pAnswer1 == "no" &&  // Wearing Blue
                         pAnswer2 == "no" &&  // Republican
                         pAnswer3 == "yes" && // No-US Party
                         pAnswer4 == "no" &&  // American
                         pAnswer5 == "yes")   // Facial Hair
                {
                    // If Hard, from 50% -> 100%
                    gwc.dialogueLines = new string[] {
                        "Ah HA! You're Mohammed Bin Salman aren't ya?!"
                    };
                }
                else if (pAnswer1 == "no" &&  // Wearing Blue
                         pAnswer2 == "no" &&  // Republican
                         pAnswer3 == "yes" && // No-US Party
                         pAnswer4 == "no" &&  // American
                         pAnswer5 == "no")   // Facial Hair
                {
                    // If Hard, from 50% -> 100%
                    gwc.dialogueLines = new string[] {
                        "Ah HA! You're Natalia Veselnitskaya aren't ya?!"
                    };
                }
                else if (pAnswer1 == "no" &&  // Wearing Blue
                         pAnswer2 == "no" &&  // Republican
                         pAnswer3 == "no" &&  // No-US Party
                         pAnswer4 == "yes" && // Independent
                         pAnswer5 == "yes")    // Purple Tie
                {
                    // If Hard, from 50% -> 100%
                    gwc.dialogueLines = new string[] {
                        "Ah HA! You're Sean Hannity aren't ya?!"
                    };
                }
                else if (pAnswer1 == "no" &&  // Wearing Blue
                         pAnswer2 == "no" &&  // Republican
                         pAnswer3 == "no" &&  // No-US Party
                         pAnswer4 == "yes" && // Independent
                         pAnswer5 == "no")    // Purple Tie
                {
                    // If Hard, from 50% -> 100%
                    gwc.dialogueLines = new string[] {
                        "Ah HA! You're Ivanka Trump aren't ya?!"
                    };
                }
                else 
                {
                    gwc.dialogueLines = new string[] {
                        "Did.. did you cheat?"
                    };
                }
            }
            else if (gwc.teamName == "Mueller")
            {
                if (pAnswer1 == "yes" && // DOJ
                    pAnswer2 == "yes" && // Democrat
                    pAnswer3 == "no" &&  // Republican
                    pAnswer4 == "no" &&  // Fired
                    pAnswer5 == "yes")   // Glasses
                {
                    // If Hard, from 50% -> 100%
                    gwc.dialogueLines = new string[] {
                        "Ah HA! You're Uzo Asonye aren't ya?!"
                    };
                }
                else if (pAnswer1 == "yes" && // DOJ
                         pAnswer2 == "yes" && // Democrat
                         pAnswer3 == "no" &&  // Republican
                         pAnswer4 == "no" &&  // Fired
                         pAnswer5 == "no")    // Glasses
                {
                    // If Hard, from 50% -> 100%
                    gwc.dialogueLines = new string[] {
                        "Ah HA! You're Zainab Ahmad aren't ya?!"
                    };
                }
                else if (pAnswer1 == "no" &&  // DOJ
                         pAnswer2 == "yes" && // Congress
                         pAnswer3 == "yes" && // Woman
                         pAnswer4 == "yes" && // Blonde
                         pAnswer5 == "yes")   // White House
                {
                    // If Hard, from 50% -> 100%
                    gwc.dialogueLines = new string[] {
                        "Ah HA! You're Hillary Clinton aren't ya?!"
                    };
                }
                else if (pAnswer1 == "no" &&  // DOJ
                         pAnswer2 == "yes" && // Congress
                         pAnswer3 == "yes" && // Woman
                         pAnswer4 == "yes" && // Blonde
                         pAnswer5 == "no")    // White House
                {
                    // If Hard, from 50% -> 100%
                    gwc.dialogueLines = new string[] {
                        "Ah HA! You're Elizabeth Warren aren't ya?!"
                    };
                }
                else if (pAnswer1 == "no" &&  // DOJ
                         pAnswer2 == "yes" && // Congress
                         pAnswer3 == "no" &&  // Woman
                         pAnswer4 == "yes" && // Right
                         pAnswer5 == "yes")   // Bald
                {
                    // If Hard, from 50% -> 100%
                    gwc.dialogueLines = new string[] {
                        "Ah HA! You're Elijah Cummings aren't ya?!"
                    };
                }
                else if (pAnswer1 == "no" &&  // DOJ
                         pAnswer2 == "yes" && // Congress
                         pAnswer3 == "no" &&  // Woman
                         pAnswer4 == "yes" && // Right
                         pAnswer5 == "no")    // Bald
                {
                    // If Hard, from 50% -> 100%
                    gwc.dialogueLines = new string[] {
                        "Ah HA! You're Mike Rogers aren't ya?!"
                    };
                }
                else if (pAnswer1 == "no" &&  // DOJ
                         pAnswer2 == "yes" && // Congress
                         pAnswer3 == "no" &&  // Woman
                         pAnswer4 == "no" &&  // Right
                         pAnswer5 == "yes")   // Black
                {
                    // If Hard, from 50% -> 100%
                    gwc.dialogueLines = new string[] {
                        "Ah HA! You're Barack Obama aren't ya?!"
                    };
                }
                else if (pAnswer1 == "no" &&  // DOJ
                         pAnswer2 == "yes" && // Congress
                         pAnswer3 == "no" &&  // Woman
                         pAnswer4 == "no" &&  // Right
                         pAnswer5 == "no")    // Black
                {
                    // If Hard, from 50% -> 100%
                    gwc.dialogueLines = new string[] {
                        "Ah HA! You're Adam Schiff aren't ya?!"
                    };
                }
                else if (pAnswer1 == "no" &&  // DOJ
                         pAnswer2 == "no" &&  // Congress
                         pAnswer3 == "yes" && // Red
                         pAnswer4 == "yes" && // White House
                         pAnswer5 == "yes")   // Grey Hair
                {
                    // If Hard, from 50% -> 100%
                    gwc.dialogueLines = new string[] {
                        "Ah HA! You're John Brennan aren't ya?!"
                    };
                }
                else if (pAnswer1 == "no" &&  // DOJ
                         pAnswer2 == "no" &&  // Congress
                         pAnswer3 == "yes" && // Red
                         pAnswer4 == "yes" && // White House
                         pAnswer5 == "no")    // Grey Hair
                {
                    // If Hard, from 50% -> 100%
                    gwc.dialogueLines = new string[] {
                        "Ah HA! You're Maggie Haberman aren't ya?!"
                    };
                }
                else if (pAnswer1 == "no" &&  // DOJ
                         pAnswer2 == "no" &&  // Congress
                         pAnswer3 == "yes" && // Red
                         pAnswer4 == "no" &&  // White House
                         pAnswer5 == "yes")   // British
                {
                    // If Hard, from 50% -> 100%
                    gwc.dialogueLines = new string[] {
                        "Ah HA! You're Christopher Steele aren't ya?!"
                    };
                }
                else if (pAnswer1 == "no" &&  // DOJ
                         pAnswer2 == "no" &&  // Congress
                         pAnswer3 == "yes" && // Red
                         pAnswer4 == "no" &&  // White House
                         pAnswer5 == "no")   // British
                {
                    // If Hard, from 50% -> 100%
                    gwc.dialogueLines = new string[] {
                        "Ah HA! You're Andrew McCabe aren't ya?!"
                    };
                }
                else if (pAnswer1 == "no" &&  // DOJ
                         pAnswer2 == "no" &&  // Congress
                         pAnswer3 == "no" &&  // Red
                         pAnswer4 == "yes" && // No-US Party
                         pAnswer5 == "yes")   // FBI
                {
                    // If Hard, from 50% -> 100%
                    gwc.dialogueLines = new string[] {
                        "Ah HA! You're Jason Alberts aren't ya?!"
                    };
                }
                else if (pAnswer1 == "no" &&  // DOJ
                         pAnswer2 == "no" &&  // Congress
                         pAnswer3 == "no" &&  // Red
                         pAnswer4 == "yes" && // No-US Party
                         pAnswer5 == "no")    // FBI
                {
                    // If Hard, from 50% -> 100%
                    gwc.dialogueLines = new string[] {
                        "Ah HA! You're Christopher Wylie aren't ya?!"
                    };
                }
                else if (pAnswer1 == "no" &&  // DOJ
                         pAnswer2 == "no" &&  // Congress
                         pAnswer3 == "no" &&  // Red
                         pAnswer4 == "no" &&  // No-US Party
                         pAnswer5 == "yes")   // Facial Hair
                {
                    // If Hard, from 50% -> 100%
                    gwc.dialogueLines = new string[] {
                        "Ah HA! You're James Clapper aren't ya?!"
                    };
                }
                else if (pAnswer1 == "no" &&  // DOJ
                         pAnswer2 == "no" &&  // Congress
                         pAnswer3 == "no" &&  // Red
                         pAnswer4 == "no" &&  // No-US Party
                         pAnswer5 == "no")    // Facial Hair
                {
                    // If Hard, from 50% -> 100%
                    gwc.dialogueLines = new string[] {
                        "Ah HA! You're Stormy Daniels aren't ya?!"
                    };
                }
                else
                {
                    gwc.dialogueLines = new string[] {
                        "Did.. did you cheat?"
                    };
                }
            }
            else
            {
                if (gwc.teamName == "Trump")
                {
                    randomInt = Random.Range(23, 47);
                }
                else if (gwc.teamName == "Mueller")
                {
                    randomInt = Random.Range(0, 23);
                }

                gwc.dialogueLines = new string[] {
                    "Umm.. Did you.... Nvm. Are you " + chars.characters[randomInt].charName + "?"
                };
            }
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
