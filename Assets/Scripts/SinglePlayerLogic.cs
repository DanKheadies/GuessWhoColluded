// CC 4.0 International License: Attribution--HolisticGaming.com--NonCommercial--ShareALike
// Authors: David W. Corso
// Start: 03/20/2019
// Last:  03/28/2019

using UnityEngine;

// Contains logic for single player mode
public class SinglePlayerLogic : MonoBehaviour
{
    public Characters chars;
    public GWC001 gwc;
    public DialogueManager dMan;
    public MoveOptionsMenuArrow moveOptsArw;
    public OptionsManager oMan;

    public bool bCheckingBoard;
    public bool bGuessingFTW;
    public bool bGuessingTrait;
    public bool bOppQ1;
    public bool bOppQ2;
    public bool bOppQ3;
    public bool bOppQ4;
    public bool bOppQ5;
    public bool bOppQ6;
    public bool bPauseQuestion;
    public bool bPlayerGuessing;
    public bool bPlayerMidGuess;
    public bool bPlayQ1;
    public bool bPlayQ2;
    public bool bPlayQ3;
    public bool bPlayQ4;
    public bool bPlayQ5;
    public bool bPlayQ6;
    public bool bTraitClothingColorO1;
    public bool bTraitClothingColorO2;
    public bool bTraitClothingColorO3;
    public bool bTraitCountryO1;
    public bool bTraitCountryO2;
    public bool bTraitHairColorO1;
    public bool bTraitHairColorO2;
    public bool bTraitHairColorO3;
    public bool bTraitHairLengthO1;
    public bool bTraitHairLengthO2;
    public bool bTraitIconsO1;
    public bool bTraitIconsO2;
    public bool bTraitIconsO3;
    public bool bTraitIconsO4;
    public bool bTraitIconsO5;
    public bool bTraitSkinColorO1;
    public bool bTraitSkinColorO2;

    public int playerGuessNumber;
    public int randomInt;
    public int traitInt;

    public float pauseTime;

    public string nameFTW;
    public string pAnswer1;
    public string pAnswer2;
    public string pAnswer3;
    public string pAnswer4;
    public string pAnswer5;
    public string pAnswer6;

    public string[] npcTrait;

    void Start()
    {
        // Initializers
        chars = FindObjectOfType<Characters>();
        dMan = FindObjectOfType<DialogueManager>();
        gwc = FindObjectOfType<GWC001>();
        moveOptsArw = FindObjectOfType<MoveOptionsMenuArrow>();
        oMan = FindObjectOfType<OptionsManager>();

        bTraitClothingColorO1 = bTraitCountryO1 = bTraitHairColorO1 = bTraitHairLengthO1 = bTraitIconsO1 = bTraitSkinColorO1 = true;

        pauseTime = 10f;
        traitInt = 5;

        npcTrait = new string[11];
        npcTrait[0] = "clothing color";
        npcTrait[1] = "country";
        npcTrait[2] = "direction";
        npcTrait[3] = "eye color";
        npcTrait[4] = "eye wear";
        npcTrait[5] = "facial hair";
        npcTrait[6] = "gender";
        npcTrait[7] = "hair color";
        npcTrait[8] = "hair length";
        npcTrait[9] = "icons";
        npcTrait[10] = "skin color";
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
            bPlayerMidGuess = true;
            bPlayQ1 = true;

            gwc.GWC_PromptRestrictions();

            // Avoid new Trait if checking board and reset board check
            if (!bCheckingBoard)
            {
                traitInt = traitInt + 1;

                if (traitInt >= 11)
                {
                    traitInt = 0;
                }
            }
            bCheckingBoard = false;

            gwc.dialogueLines = new string[] {
                "Hmmm.. Should I ask him about.. " + npcTrait[traitInt] + "?"
            };
            gwc.GWC_DialogueRestter();
            gwc.dPic.sprite = gwc.portPic[gwc.playerCharacter];

            gwc.optionsLines = new string[] {
                "Yes.",
                "Nah something else..",
                "Lemme check the board again.",
                "I know who he is!"
            };
            gwc.GWC_OptionsResetter_4Q();
        }
        // Single Player - Player's Second Guess
        else if (bPlayerGuessing &&
                 playerGuessNumber == 2 &&
                 !dMan.bDialogueActive)
        {
            bPlayerGuessing = false;
            bPlayerMidGuess = true;
            bPlayQ2 = true;

            gwc.GWC_PromptRestrictions();

            // Avoid new Trait if checking board and reset board check
            if (!bCheckingBoard)
            {
                traitInt = traitInt + 1;

                if (traitInt >= 11)
                {
                    traitInt = 0;
                }
            }
            bCheckingBoard = false;

            gwc.dialogueLines = new string[] {
                "Hmmm.. Should I ask him about.. " + npcTrait[traitInt] + "?"
            };
            gwc.GWC_DialogueRestter();
            gwc.dPic.sprite = gwc.portPic[gwc.playerCharacter];

            gwc.optionsLines = new string[] {
                "Yes.",
                "Nah something else..",
                "Lemme check the board again.",
                "I know who he is!"
            };
            gwc.GWC_OptionsResetter_4Q();
        }
        // Single Player - Player's Third Guess
        else if (bPlayerGuessing &&
                 playerGuessNumber == 3 &&
                 !dMan.bDialogueActive)
        {
            bPlayerGuessing = false;
            bPlayerMidGuess = true;
            bPlayQ1 = true;

            gwc.GWC_PromptRestrictions();

            // Avoid new Trait if checking board and reset board check
            if (!bCheckingBoard)
            {
                traitInt = traitInt + 1;

                if (traitInt >= 11)
                {
                    traitInt = 0;
                }
            }
            bCheckingBoard = false;

            gwc.dialogueLines = new string[] {
                "Hmmm.. Should I ask him about.. " + npcTrait[traitInt] + "?"
            };
            gwc.GWC_DialogueRestter();
            gwc.dPic.sprite = gwc.portPic[gwc.playerCharacter];

            gwc.optionsLines = new string[] {
                "Yes.",
                "Nah something else..",
                "Lemme check the board again.",
                "I know who he is!"
            };
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

        // Guessing FTW
        if (bGuessingFTW &&
            Input.GetMouseButtonUp(0))
        {
            if (nameFTW != "")
            {
                if (nameFTW == gwc.chars.characters[gwc.opponentCharacter].charGameName)
                {
                    Debug.Log("You did it! You win!!");
                }
                else
                {
                    // Use a forLoop to match nameFTW to char[].GameName and pull that charName
                    //gwc.dialogueLines = new string[] {
                    //    "So sorry.. I am not " + nameFTW
                    //};
                    //gwc.GWC_DialogueRestter();
                    //gwc.dPic.sprite = gwc.portPic[48];

                    Debug.Log("Nope..");
                    bPlayerMidGuess = false;

                    QuestionAdvancer();
                }

                // Reset
                nameFTW = "";
                bGuessingFTW = false;
            }
        }
    }

    public void QuestionAdvancer()
    {
        if (bPlayQ1)
        {
            bPlayQ1 = false;
            bOppQ2 = true;
        }
        else if (bPlayQ2)
        {
            bPlayQ2 = false;
            bOppQ3 = true;
        }
        else if (bPlayQ3)
        {
            bPlayQ3 = false;
            bOppQ4 = true;
        }
        else if (bPlayQ4)
        {
            bPlayQ4 = false;
            bOppQ5 = true;
        }
        else if (bPlayQ5)
        {
            bPlayQ5 = false;
            bOppQ6 = true;
        }
        //else if (bPlayQ6)
        //{
        //    bPlayQ6 = false;
        //}
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
        else if (bPlayQ1 || bPlayQ2 || bPlayQ3 || bPlayQ4 || bPlayQ5)
        {
            if (moveOptsArw.currentPosition == MoveOptionsMenuArrow.ArrowPos.Opt1)
            {
                PlayerGuessYes(npcTrait[traitInt]);
            }
            else if (moveOptsArw.currentPosition == MoveOptionsMenuArrow.ArrowPos.Opt2)
            {
                PlayerGuessAnother();
                oMan.ResetOptions();
            }
            else if (moveOptsArw.currentPosition == MoveOptionsMenuArrow.ArrowPos.Opt3)
            {
                PlayerCheckBoard();
                oMan.ResetOptions();
            }
            else if (moveOptsArw.currentPosition == MoveOptionsMenuArrow.ArrowPos.Opt4)
            {
                PlayerGuessNPC();
                oMan.ResetOptions();
            }
        }
        else if (bPlayQ6)
        {
            if (moveOptsArw.currentPosition == MoveOptionsMenuArrow.ArrowPos.Opt1)
            {
                PlayerCheckBoard();
                oMan.ResetOptions();
            }
            else if (moveOptsArw.currentPosition == MoveOptionsMenuArrow.ArrowPos.Opt2)
            {
                PlayerGuessNPC();
                oMan.ResetOptions();
            }
        }
        //// Single Player - Player Question 2 
        //else if (bPlayQ2)
        //{
        //    if (moveOptsArw.currentPosition == MoveOptionsMenuArrow.ArrowPos.Opt1)
        //    {
        //        // "Yes";
        //    }
        //    else if (moveOptsArw.currentPosition == MoveOptionsMenuArrow.ArrowPos.Opt2)
        //    {
        //        // "No another"
        //    }
        //    else if (moveOptsArw.currentPosition == MoveOptionsMenuArrow.ArrowPos.Opt3)
        //    {
        //        // "Check the board"
        //    }
        //    else if (moveOptsArw.currentPosition == MoveOptionsMenuArrow.ArrowPos.Opt4)
        //    {
        //        // "Guess"
        //    }

        //    bPlayQ2 = false;
        //    bOppQ3 = true;
        //    PauseQuestion();

        //    oMan.ResetOptions();
        //}
        //// Single Player - Player Question 3 
        //else if (bPlayQ3)
        //{
        //    if (moveOptsArw.currentPosition == MoveOptionsMenuArrow.ArrowPos.Opt1)
        //    {
        //        // "Yes";
        //    }
        //    else if (moveOptsArw.currentPosition == MoveOptionsMenuArrow.ArrowPos.Opt2)
        //    {
        //        // "No another"
        //    }
        //    else if (moveOptsArw.currentPosition == MoveOptionsMenuArrow.ArrowPos.Opt3)
        //    {
        //        // "Check the board"
        //    }
        //    else if (moveOptsArw.currentPosition == MoveOptionsMenuArrow.ArrowPos.Opt4)
        //    {
        //        // "Guess"
        //    }

        //    bPlayQ3 = false;
        //    bOppQ4 = true;
        //    PauseQuestion();

        //    oMan.ResetOptions();
        //}
        //// Single Player - Player Question 4 
        //else if (bPlayQ4)
        //{
        //    if (moveOptsArw.currentPosition == MoveOptionsMenuArrow.ArrowPos.Opt1)
        //    {
        //        // "Yes";
        //    }
        //    else if (moveOptsArw.currentPosition == MoveOptionsMenuArrow.ArrowPos.Opt2)
        //    {
        //        // "No another"
        //    }
        //    else if (moveOptsArw.currentPosition == MoveOptionsMenuArrow.ArrowPos.Opt3)
        //    {
        //        // "Check the board"
        //    }
        //    else if (moveOptsArw.currentPosition == MoveOptionsMenuArrow.ArrowPos.Opt4)
        //    {
        //        // "Guess"
        //    }

        //    bPlayQ4 = false;
        //    bOppQ5 = true;
        //    PauseQuestion();

        //    oMan.ResetOptions();
        //}
        //// Single Player - Player Question 5 
        //else if (bPlayQ5)
        //{
        //    if (moveOptsArw.currentPosition == MoveOptionsMenuArrow.ArrowPos.Opt1)
        //    {
        //        // "Yes";
        //    }
        //    else if (moveOptsArw.currentPosition == MoveOptionsMenuArrow.ArrowPos.Opt2)
        //    {
        //        // "No another"
        //    }
        //    else if (moveOptsArw.currentPosition == MoveOptionsMenuArrow.ArrowPos.Opt3)
        //    {
        //        // "Check the board"
        //    }
        //    else if (moveOptsArw.currentPosition == MoveOptionsMenuArrow.ArrowPos.Opt4)
        //    {
        //        // "Guess"
        //    }

        //    bPlayQ5 = false;
        //    bOppQ6 = true;
        //    PauseQuestion();

        //    oMan.ResetOptions();
        //}
    }

    public void PlayerGuessYes(string trait)
    {
        bGuessingTrait = true;

        gwc.GWC_PromptRestrictions();

        if (trait == "clothing color")
        {
            gwc.dialogueLines = new string[] {
                "Hmmm... Are you wearing anything.."
            };
            gwc.GWC_DialogueRestter();

            if (bTraitClothingColorO1)
            {
                gwc.optionsLines = new string[] {
                    "Black",
                    "Brown",
                    "Blue",
                    "Nah, another color.."
                };
                gwc.GWC_OptionsResetter_4Q();
            }
            else if (bTraitClothingColorO2)
            {
                gwc.optionsLines = new string[] {
                    "Red",
                    "Purple",
                    "Yellow",
                    "Nah, another color.." 
                };
                gwc.GWC_OptionsResetter_4Q();
            }
            else if (bTraitClothingColorO3)
            {
                gwc.optionsLines = new string[] {
                    "White",
                    "Nevermind.. To the board"
                };
                gwc.GWC_OptionsResetter_2Q();
            }
        }
        else if (trait == "country")
        {
            gwc.dialogueLines = new string[] {
                "Hmmm... Are you from.."
            };
            gwc.GWC_DialogueRestter();

            if (bTraitCountryO1)
            {
                gwc.optionsLines = new string[] {
                    "The United States",
                    "The United Kingdom",
                    "Mother Russia",
                    "Nah, another place.."
                };
                    gwc.GWC_OptionsResetter_4Q();
            }
            else if (bTraitCountryO2)
            {
                gwc.optionsLines = new string[] {
                    "Saudi Arabia",
                    "Canada",
                    "Nevermind.. To the board"
                };
                gwc.GWC_OptionsResetter_3Q();
            }
        }
        else if (trait == "direction")
        {
            gwc.dialogueLines = new string[] {
                "Hmmm... Are you looking to.."
            };
            gwc.GWC_DialogueRestter();

            gwc.optionsLines = new string[] {
                "The left",
                "The right",
                "The center",
                "Nevermind.. To the board"
            };
            gwc.GWC_OptionsResetter_4Q();
        }
        else if (trait == "eye color")
        {
            gwc.dialogueLines = new string[] {
                "Hmmm... Are your eyes.."
            };
            gwc.GWC_DialogueRestter();

            gwc.optionsLines = new string[] {
                "Dark (brown / black)",
                "Blue or green (ish)",
                "White or n/a",
                "Nevermind.. To the board"
            };
            gwc.GWC_OptionsResetter_4Q();
        }
        else if (trait == "eye wear")
        {
            gwc.dialogueLines = new string[] {
                "Hmmm... Are wearing any kind of glasses.."
            };
            gwc.GWC_DialogueRestter();

            gwc.optionsLines = new string[] {
                "Yea",
                "Nevermind.. To the board"
            };
            gwc.GWC_OptionsResetter_3Q();
        }
        else if (trait == "facial hair")
        {
            gwc.dialogueLines = new string[] {
                "Hmmm... Do you have any facial hair.."
            };
            gwc.GWC_DialogueRestter();

            gwc.optionsLines = new string[] {
                "Yea",
                "Nevermind.. To the board"
            };
            gwc.GWC_OptionsResetter_3Q();
        }
        else if (trait == "gender")
        {
            gwc.dialogueLines = new string[] {
                "Hmmm... Are you a.."
            };
            gwc.GWC_DialogueRestter();

            gwc.optionsLines = new string[] {
                "Man",
                "Woman",
                "Nevermind.. To the board"
            };
            gwc.GWC_OptionsResetter_3Q();
        }
        else if (trait == "hair color")
        {
            gwc.dialogueLines = new string[] {
                "Hmmm... Is your hair color.."
            };
            gwc.GWC_DialogueRestter();

            if (bTraitHairColorO1)
            {
                gwc.optionsLines = new string[] {
                    "Black",
                    "Brown",
                    "Blonde",
                    "Nah, another color.."
                };
                gwc.GWC_OptionsResetter_4Q();
            }
            else if (bTraitHairColorO2)
            {
                gwc.optionsLines = new string[] {
                    "Grey",
                    "Black and grey",
                    "White",
                    "Nah, another color.."
                };
                gwc.GWC_OptionsResetter_4Q();
            }
            else if (bTraitHairColorO3)
            {
                gwc.optionsLines = new string[] {
                    "Red",
                    "Pink",
                    "N/a",
                    "Nevermind.. To the board"
                };
                gwc.GWC_OptionsResetter_4Q();
            }
        }
        else if (trait == "hair length")
        {
            gwc.dialogueLines = new string[] {
                "Hmmm... Is your hair.."
            };
            gwc.GWC_DialogueRestter();

            if (bTraitHairLengthO1)
            {
                gwc.optionsLines = new string[] {
                    "Long",
                    "Medium",
                    "Short",
                    "Nah, another length.."
                };
                gwc.GWC_OptionsResetter_4Q();
            }
            else if (bTraitHairLengthO2)
            {
                gwc.optionsLines = new string[] {
                    "None there",
                    "Nevermind.. To the board"
                };
                gwc.GWC_OptionsResetter_2Q();
            }
        }
        else if (trait == "icons")
        {
            gwc.dialogueLines = new string[] {
                "Hmmm..."
            };
            gwc.GWC_DialogueRestter();

            if (bTraitIconsO1)
            {
                gwc.optionsLines = new string[] {
                    "You fired by DJT",
                    "In a DJT tweet",
                    "A democrat in 2016",
                    "Nah, another icon.."
                };
                gwc.GWC_OptionsResetter_4Q();
            }
            else if (bTraitIconsO2)
            {
                gwc.optionsLines = new string[] {
                    "A republican in 2016",
                    "An independent in 2016",
                    "No US party in 2016",
                    "Nah, another icon.."
                };
                gwc.GWC_OptionsResetter_4Q();
            }
            else if (bTraitIconsO3)
            {
                gwc.optionsLines = new string[] {
                    "(Ex-) CIA",
                    "(Ex-) DOJ",
                    "(Ex-) FBI",
                    "Nah, another icon.."
                };
                gwc.GWC_OptionsResetter_4Q();
            }
            else if (bTraitIconsO4)
            {
                gwc.optionsLines = new string[] {
                    "(Ex-) NSA",
                    "(Ex-) White House",
                    "(Ex-) Congress",
                    "Nah, another icon.."
                };
                gwc.GWC_OptionsResetter_4Q();
            }
            else if (bTraitIconsO5)
            {
                gwc.optionsLines = new string[] {
                    "On Trump's campaign",
                    "On Mueller's team",
                    "Media member",
                    "Nevermind.. To the board"
                };
                gwc.GWC_OptionsResetter_4Q();
            }
        }
        else if (trait == "skin color")
        {
            gwc.dialogueLines = new string[] {
                "Hmmm... Is your skin.."
            };
            gwc.GWC_DialogueRestter();

            if (bTraitSkinColorO1)
            {
                gwc.optionsLines = new string[] {
                    "White",
                    "Black",
                    "Brown",
                    "Nah, another color.."
                };
                gwc.GWC_OptionsResetter_4Q();
            }
            else if (bTraitSkinColorO2)
            {
                gwc.optionsLines = new string[] {
                    "Purple",
                    "Grey",
                    "N/a",
                    "Nevermind.. To the board"
                };
                gwc.GWC_OptionsResetter_4Q();
            }
        }
        else
        {
            gwc.dialogueLines = new string[] {
                "Derp"
            };
            gwc.GWC_DialogueRestter();

            gwc.optionsLines = new string[] {
                "Derp",
                "Derp",
                "Derp",
                "Derp"
            };
            gwc.GWC_OptionsResetter_4Q();
        }
    }

    public void PlayerGuessAnother()
    {
        bPlayerGuessing = true;
    }

    public void PlayerCheckBoard()
    {
        bCheckingBoard = true;
    }

    public void PlayerGuessNPC()
    {
        bGuessingFTW = true;
    }

    public void TraitTree()
    {
        // Clothing Color
        if (npcTrait[traitInt] == "clothing color")
        {
            if (bTraitClothingColorO1)
            {
                if (moveOptsArw.currentPosition == MoveOptionsMenuArrow.ArrowPos.Opt1)
                {
                    if (gwc.chars.characters[gwc.opponentCharacter].charClothingColor[0] == "black" ||
                        gwc.chars.characters[gwc.opponentCharacter].charClothingColor[1] == "black" ||
                        gwc.chars.characters[gwc.opponentCharacter].charClothingColor[2] == "black" ||
                        gwc.chars.characters[gwc.opponentCharacter].charClothingColor[3] == "black")
                    {
                        gwc.dialogueLines = new string[] {
                            "Yes, I am wearing black."
                        };
                    }
                    else
                    {
                        gwc.dialogueLines = new string[] {
                            "No, I am not wearing black."
                        };
                    }

                    SPL_TraitTreeConsolidator();
                }
                else if (moveOptsArw.currentPosition == MoveOptionsMenuArrow.ArrowPos.Opt2)
                {
                    if (gwc.chars.characters[gwc.opponentCharacter].charClothingColor[0] == "brown" ||
                        gwc.chars.characters[gwc.opponentCharacter].charClothingColor[1] == "brown" ||
                        gwc.chars.characters[gwc.opponentCharacter].charClothingColor[2] == "brown" ||
                        gwc.chars.characters[gwc.opponentCharacter].charClothingColor[3] == "brown")
                    {
                        gwc.dialogueLines = new string[] {
                            "Yes, I am wearing brown."
                        };
                    }
                    else
                    {
                        gwc.dialogueLines = new string[] {
                            "No, I am not wearing brown."
                        };
                    }

                    SPL_TraitTreeConsolidator();
                }
                else if (moveOptsArw.currentPosition == MoveOptionsMenuArrow.ArrowPos.Opt3)
                {
                    if (gwc.chars.characters[gwc.opponentCharacter].charClothingColor[0] == "blue" ||
                        gwc.chars.characters[gwc.opponentCharacter].charClothingColor[1] == "blue" ||
                        gwc.chars.characters[gwc.opponentCharacter].charClothingColor[2] == "blue" ||
                        gwc.chars.characters[gwc.opponentCharacter].charClothingColor[3] == "blue")
                    {
                        gwc.dialogueLines = new string[] {
                            "Yes, I am wearing blue."
                        };
                    }
                    else
                    {
                        gwc.dialogueLines = new string[] {
                            "No, I am not wearing brown."
                        };
                    }

                    SPL_TraitTreeConsolidator();
                }
                else if (moveOptsArw.currentPosition == MoveOptionsMenuArrow.ArrowPos.Opt4)
                {
                    bTraitClothingColorO1 = false;
                    bTraitClothingColorO2 = true;
                    PlayerGuessYes(npcTrait[traitInt]);
                }
            }
            else if (bTraitClothingColorO2)
            {
                if (moveOptsArw.currentPosition == MoveOptionsMenuArrow.ArrowPos.Opt1)
                {
                    if (gwc.chars.characters[gwc.opponentCharacter].charClothingColor[0] == "red" ||
                        gwc.chars.characters[gwc.opponentCharacter].charClothingColor[1] == "red" ||
                        gwc.chars.characters[gwc.opponentCharacter].charClothingColor[2] == "red" ||
                        gwc.chars.characters[gwc.opponentCharacter].charClothingColor[3] == "red")
                    {
                        gwc.dialogueLines = new string[] {
                            "Yes, I am wearing red."
                        };
                    }
                    else
                    {
                        gwc.dialogueLines = new string[] {
                            "No, I am not wearing red."
                        };
                    }

                    SPL_TraitTreeConsolidator();
                }
                else if (moveOptsArw.currentPosition == MoveOptionsMenuArrow.ArrowPos.Opt2)
                {
                    if (gwc.chars.characters[gwc.opponentCharacter].charClothingColor[0] == "purple" ||
                        gwc.chars.characters[gwc.opponentCharacter].charClothingColor[1] == "purple" ||
                        gwc.chars.characters[gwc.opponentCharacter].charClothingColor[2] == "purple" ||
                        gwc.chars.characters[gwc.opponentCharacter].charClothingColor[3] == "purple")
                    {
                        gwc.dialogueLines = new string[] {
                            "Yes, I am wearing purple."
                        };
                    }
                    else
                    {
                        gwc.dialogueLines = new string[] {
                            "No, I am not wearing purple."
                        };
                    }

                    SPL_TraitTreeConsolidator();
                }
                else if (moveOptsArw.currentPosition == MoveOptionsMenuArrow.ArrowPos.Opt3)
                {
                    if (gwc.chars.characters[gwc.opponentCharacter].charClothingColor[0] == "yellow" ||
                        gwc.chars.characters[gwc.opponentCharacter].charClothingColor[1] == "yellow" ||
                        gwc.chars.characters[gwc.opponentCharacter].charClothingColor[2] == "yellow" ||
                        gwc.chars.characters[gwc.opponentCharacter].charClothingColor[3] == "yellow")
                    {
                        gwc.dialogueLines = new string[] {
                            "Yes, I am wearing yellow."
                        };
                    }
                    else
                    {
                        gwc.dialogueLines = new string[] {
                            "No, I am not wearing yellow."
                        };
                    }

                    SPL_TraitTreeConsolidator();
                }
                else if (moveOptsArw.currentPosition == MoveOptionsMenuArrow.ArrowPos.Opt4)
                {
                    bTraitClothingColorO2 = false;
                    bTraitClothingColorO3 = true;
                    PlayerGuessYes(npcTrait[traitInt]);
                }
            }
            else if (bTraitClothingColorO3)
            {
                if (moveOptsArw.currentPosition == MoveOptionsMenuArrow.ArrowPos.Opt1)
                {
                    if (gwc.chars.characters[gwc.opponentCharacter].charClothingColor[0] == "white" ||
                        gwc.chars.characters[gwc.opponentCharacter].charClothingColor[1] == "white" ||
                        gwc.chars.characters[gwc.opponentCharacter].charClothingColor[2] == "white" ||
                        gwc.chars.characters[gwc.opponentCharacter].charClothingColor[3] == "white")
                    {
                        gwc.dialogueLines = new string[] {
                            "Yes, I am wearing white."
                        };
                    }
                    else
                    {
                        gwc.dialogueLines = new string[] {
                            "No, I am not wearing white."
                        };
                    }

                    SPL_TraitTreeConsolidator();
                }
                else if (moveOptsArw.currentPosition == MoveOptionsMenuArrow.ArrowPos.Opt2)
                {
                    bTraitClothingColorO3 = false;
                    bTraitClothingColorO1 = true;

                    bGuessingTrait = false;
                    bCheckingBoard = true;
                    oMan.ResetOptions();
                }
            }
        }
        // Country
        else if (npcTrait[traitInt] == "country")
        {
            if (bTraitCountryO1)
            {
                if (moveOptsArw.currentPosition == MoveOptionsMenuArrow.ArrowPos.Opt1)
                {
                    if (gwc.chars.characters[gwc.opponentCharacter].charCountry == "us")
                    {
                        gwc.dialogueLines = new string[] {
                            "Yes, I am from the United States."
                        };
                    }
                    else
                    {
                        gwc.dialogueLines = new string[] {
                            "No, I am not from the United States."
                        };
                    }

                    SPL_TraitTreeConsolidator();
                }
                else if (moveOptsArw.currentPosition == MoveOptionsMenuArrow.ArrowPos.Opt2)
                {
                    if (gwc.chars.characters[gwc.opponentCharacter].charCountry == "uk")
                    {
                        gwc.dialogueLines = new string[] {
                            "Yes, I am from the United Kingdom."
                        };
                    }
                    else
                    {
                        gwc.dialogueLines = new string[] {
                            "No, I am not from the United Kingdom."
                        };
                    }

                    SPL_TraitTreeConsolidator();
                }
                else if (moveOptsArw.currentPosition == MoveOptionsMenuArrow.ArrowPos.Opt3)
                {
                    if (gwc.chars.characters[gwc.opponentCharacter].charCountry == "russia")
                    {
                        gwc.dialogueLines = new string[] {
                            "Yes, I am from Russia."
                        };
                    }
                    else
                    {
                        gwc.dialogueLines = new string[] {
                            "No, I am not from Russia."
                        };
                    }

                    SPL_TraitTreeConsolidator();
                }
                else if (moveOptsArw.currentPosition == MoveOptionsMenuArrow.ArrowPos.Opt4)
                {
                    bTraitCountryO1 = false;
                    bTraitCountryO2 = true;
                    PlayerGuessYes(npcTrait[traitInt]);
                }
            }
            else if (bTraitCountryO2)
            {
                if (moveOptsArw.currentPosition == MoveOptionsMenuArrow.ArrowPos.Opt1)
                {
                    if (gwc.chars.characters[gwc.opponentCharacter].charCountry == "sa")
                    {
                        gwc.dialogueLines = new string[] {
                            "Yes, I am from Saudi Arabia."
                        };
                    }
                    else
                    {
                        gwc.dialogueLines = new string[] {
                            "No, I am not from Saudi Arabia."
                        };
                    }

                    SPL_TraitTreeConsolidator();
                }
                else if (moveOptsArw.currentPosition == MoveOptionsMenuArrow.ArrowPos.Opt2)
                {
                    if (gwc.chars.characters[gwc.opponentCharacter].charCountry == "canada")
                    {
                        gwc.dialogueLines = new string[] {
                            "Yes, I am from Canada."
                        };
                    }
                    else
                    {
                        gwc.dialogueLines = new string[] {
                            "No, I am not from Canada."
                        };
                    }

                    SPL_TraitTreeConsolidator();
                }
                else if (moveOptsArw.currentPosition == MoveOptionsMenuArrow.ArrowPos.Opt3)
                {
                    bTraitCountryO2 = false;
                    bTraitCountryO1 = true;

                    bGuessingTrait = false;
                    bCheckingBoard = true;
                    oMan.ResetOptions();
                }
            }
        }
        // Direction
        else if (npcTrait[traitInt] == "direction")
        {
            if (moveOptsArw.currentPosition == MoveOptionsMenuArrow.ArrowPos.Opt1)
            {
                if (gwc.chars.characters[gwc.opponentCharacter].charDirection == "left")
                {
                    gwc.dialogueLines = new string[] {
                        "Yes, I am looking to the left."
                    };
                }
                else
                {
                    gwc.dialogueLines = new string[] {
                        "No, I am not looking to the left."
                    };
                }

                SPL_TraitTreeConsolidator();
            }
            else if (moveOptsArw.currentPosition == MoveOptionsMenuArrow.ArrowPos.Opt2)
            {
                if (gwc.chars.characters[gwc.opponentCharacter].charDirection == "right")
                {
                    gwc.dialogueLines = new string[] {
                        "Yes, I am looking to the right."
                    };
                }
                else
                {
                    gwc.dialogueLines = new string[] {
                        "No, I am not looking to the right."
                    };
                }

                SPL_TraitTreeConsolidator();
            }
            else if (moveOptsArw.currentPosition == MoveOptionsMenuArrow.ArrowPos.Opt3)
            {
                if (gwc.chars.characters[gwc.opponentCharacter].charDirection == "center")
                {
                    gwc.dialogueLines = new string[] {
                        "Yes, I am looking to the center."
                    };
                }
                else
                {
                    gwc.dialogueLines = new string[] {
                        "No, I am not looking to the center."
                    };
                }

                SPL_TraitTreeConsolidator();
            }
            else if (moveOptsArw.currentPosition == MoveOptionsMenuArrow.ArrowPos.Opt4)
            {
                bGuessingTrait = false;
                bCheckingBoard = true;
                oMan.ResetOptions();
            }
        }
        // Eye Color
        else if (npcTrait[traitInt] == "eye color")
        {
            if (moveOptsArw.currentPosition == MoveOptionsMenuArrow.ArrowPos.Opt1)
            {
                if (gwc.chars.characters[gwc.opponentCharacter].charEyeColor == "black" ||
                    gwc.chars.characters[gwc.opponentCharacter].charEyeColor == "brown" ||
                    gwc.chars.characters[gwc.opponentCharacter].charEyeColor == "black-white")
                {
                    gwc.dialogueLines = new string[] {
                        "Yes, I have dark (brown / black) eyes."
                    };
                }
                else
                {
                    gwc.dialogueLines = new string[] {
                        "No, I do not have dark (brown / black) eyes."
                    };
                }

                SPL_TraitTreeConsolidator();
            }
            else if (moveOptsArw.currentPosition == MoveOptionsMenuArrow.ArrowPos.Opt2)
            {
                if (gwc.chars.characters[gwc.opponentCharacter].charEyeColor == "blue" ||
                    gwc.chars.characters[gwc.opponentCharacter].charEyeColor == "teal-green" ||
                    gwc.chars.characters[gwc.opponentCharacter].charEyeColor == "green")
                {
                    gwc.dialogueLines = new string[] {
                        "Yes, I have blue or green (ish) eyes."
                    };
                }
                else
                {
                    gwc.dialogueLines = new string[] {
                        "No, I do not have blue or green (ish) eyes."
                    };
                }

                SPL_TraitTreeConsolidator();
            }
            else if (moveOptsArw.currentPosition == MoveOptionsMenuArrow.ArrowPos.Opt3)
            {
                if (gwc.chars.characters[gwc.opponentCharacter].charEyeColor == "white" ||
                    gwc.chars.characters[gwc.opponentCharacter].charEyeColor == "n/a")
                {
                    gwc.dialogueLines = new string[] {
                        "Yes, I have white eyes or 'you can't tell' eyes."
                    };
                }
                else
                {
                    gwc.dialogueLines = new string[] {
                        "No, I do not have white eyes nor 'you can't tell' eyes."
                    };
                }

                SPL_TraitTreeConsolidator();
            }
            else if (moveOptsArw.currentPosition == MoveOptionsMenuArrow.ArrowPos.Opt4)
            {
                bGuessingTrait = false;
                bCheckingBoard = true;
                oMan.ResetOptions();
            }
        }
        // Eye Wear
        else if (npcTrait[traitInt] == "eye wear")
        {
            if (moveOptsArw.currentPosition == MoveOptionsMenuArrow.ArrowPos.Opt1)
            {
                if (gwc.chars.characters[gwc.opponentCharacter].charEyeWear == 1)
                {
                    gwc.dialogueLines = new string[] {
                        "Yes, I am wearing glasses of some kind."
                    };
                }
                else
                {
                    gwc.dialogueLines = new string[] {
                        "No, I am not wearing glasses of some kind."
                    };
                }

                SPL_TraitTreeConsolidator();
            }
            else if (moveOptsArw.currentPosition == MoveOptionsMenuArrow.ArrowPos.Opt2)
            {
                bGuessingTrait = false;
                bCheckingBoard = true;
                oMan.ResetOptions();
            }
        }
        // Facial Hair
        else if (npcTrait[traitInt] == "facial hair")
        {
            if (moveOptsArw.currentPosition == MoveOptionsMenuArrow.ArrowPos.Opt1)
            {
                if (gwc.chars.characters[gwc.opponentCharacter].charFacialHair == 1)
                {
                    gwc.dialogueLines = new string[] {
                        "Yes, I have facial hair of some kind."
                    };
                }
                else
                {
                    gwc.dialogueLines = new string[] {
                        "No, I do not have facial hair of some kind."
                    };
                }

                SPL_TraitTreeConsolidator();
            }
            else if (moveOptsArw.currentPosition == MoveOptionsMenuArrow.ArrowPos.Opt2)
            {
                bGuessingTrait = false;
                bCheckingBoard = true;
                oMan.ResetOptions();
            }
        }
        // Gender
        else if (npcTrait[traitInt] == "gender")
        {
            if (moveOptsArw.currentPosition == MoveOptionsMenuArrow.ArrowPos.Opt1)
            {
                if (gwc.chars.characters[gwc.opponentCharacter].charGender == 0)
                {
                    gwc.dialogueLines = new string[] {
                        "Yes, I am a man."
                    };
                }
                else
                {
                    gwc.dialogueLines = new string[] {
                        "No, I am not a man."
                    };
                }

                SPL_TraitTreeConsolidator();
            }
            else if (moveOptsArw.currentPosition == MoveOptionsMenuArrow.ArrowPos.Opt2)
            {
                if (gwc.chars.characters[gwc.opponentCharacter].charGender == 1)
                {
                    gwc.dialogueLines = new string[] {
                        "Yes, I am a woman."
                    };
                }
                else
                {
                    gwc.dialogueLines = new string[] {
                        "No, I am not a woman."
                    };
                }

                SPL_TraitTreeConsolidator();
            }
            else if (moveOptsArw.currentPosition == MoveOptionsMenuArrow.ArrowPos.Opt3)
            {
                bGuessingTrait = false;
                bCheckingBoard = true;
                oMan.ResetOptions();
            }
        }
        // Hair Color
        if (npcTrait[traitInt] == "hair color")
        {
            if (bTraitHairColorO1)
            {
                if (moveOptsArw.currentPosition == MoveOptionsMenuArrow.ArrowPos.Opt1)
                {
                    if (gwc.chars.characters[gwc.opponentCharacter].charHairColor == "black")
                    {
                        gwc.dialogueLines = new string[] {
                            "Yes, I have black hair."
                        };
                    }
                    else
                    {
                        gwc.dialogueLines = new string[] {
                            "No, I do not have black hair."
                        };
                    }

                    SPL_TraitTreeConsolidator();
                }
                else if (moveOptsArw.currentPosition == MoveOptionsMenuArrow.ArrowPos.Opt2)
                {
                    if (gwc.chars.characters[gwc.opponentCharacter].charHairColor == "brown")
                    {
                        gwc.dialogueLines = new string[] {
                            "Yes, I have brown hair."
                        };
                    }
                    else
                    {
                        gwc.dialogueLines = new string[] {
                            "No, I do not have brown hair."
                        };
                    }

                    SPL_TraitTreeConsolidator();
                }
                else if (moveOptsArw.currentPosition == MoveOptionsMenuArrow.ArrowPos.Opt3)
                {
                    if (gwc.chars.characters[gwc.opponentCharacter].charHairColor == "blonde")
                    {
                        gwc.dialogueLines = new string[] {
                            "Yes, I have blonde hair."
                        };
                    }
                    else
                    {
                        gwc.dialogueLines = new string[] {
                            "No, I do not have blonde hair."
                        };
                    }

                    SPL_TraitTreeConsolidator();
                }
                else if (moveOptsArw.currentPosition == MoveOptionsMenuArrow.ArrowPos.Opt4)
                {
                    bTraitHairColorO1 = false;
                    bTraitHairColorO2 = true;
                    PlayerGuessYes(npcTrait[traitInt]);
                }
            }
            else if (bTraitHairColorO2)
            {
                if (moveOptsArw.currentPosition == MoveOptionsMenuArrow.ArrowPos.Opt1)
                {
                    if (gwc.chars.characters[gwc.opponentCharacter].charHairColor == "grey")
                    {
                        gwc.dialogueLines = new string[] {
                            "Yes, I have grey hair."
                        };
                    }
                    else
                    {
                        gwc.dialogueLines = new string[] {
                            "No, I do not have grey hair."
                        };
                    }

                    SPL_TraitTreeConsolidator();
                }
                else if (moveOptsArw.currentPosition == MoveOptionsMenuArrow.ArrowPos.Opt2)
                {
                    if (gwc.chars.characters[gwc.opponentCharacter].charHairColor == "black-grey")
                    {
                        gwc.dialogueLines = new string[] {
                            "Yes, I have salt and pepper (black & grey) hair."
                        };
                    }
                    else
                    {
                        gwc.dialogueLines = new string[] {
                            "No, I do not have salt and pepper (black & grey) hair."
                        };
                    }

                    SPL_TraitTreeConsolidator();
                }
                else if (moveOptsArw.currentPosition == MoveOptionsMenuArrow.ArrowPos.Opt3)
                {
                    if (gwc.chars.characters[gwc.opponentCharacter].charHairColor == "white")
                    {
                        gwc.dialogueLines = new string[] {
                            "Yes, I have white hair."
                        };
                    }
                    else
                    {
                        gwc.dialogueLines = new string[] {
                            "No, I do not have white hair."
                        };
                    }

                    SPL_TraitTreeConsolidator();
                }
                else if (moveOptsArw.currentPosition == MoveOptionsMenuArrow.ArrowPos.Opt4)
                {
                    bTraitHairColorO2 = false;
                    bTraitHairColorO3 = true;
                    PlayerGuessYes(npcTrait[traitInt]);
                }
            }
            else if (bTraitHairColorO3)
            {
                if (moveOptsArw.currentPosition == MoveOptionsMenuArrow.ArrowPos.Opt1)
                {
                    if (gwc.chars.characters[gwc.opponentCharacter].charHairColor == "red")
                    {
                        gwc.dialogueLines = new string[] {
                            "Yes, I have red hair."
                        };
                    }
                    else
                    {
                        gwc.dialogueLines = new string[] {
                            "No, I do not have red hair."
                        };
                    }

                    SPL_TraitTreeConsolidator();
                }
                else if (moveOptsArw.currentPosition == MoveOptionsMenuArrow.ArrowPos.Opt2)
                {
                    if (gwc.chars.characters[gwc.opponentCharacter].charHairColor == "pink")
                    {
                        gwc.dialogueLines = new string[] {
                            "Yes, I have pink hair."
                        };
                    }
                    else
                    {
                        gwc.dialogueLines = new string[] {
                            "No, I do not have pink hair."
                        };
                    }

                    SPL_TraitTreeConsolidator();
                }
                else if (moveOptsArw.currentPosition == MoveOptionsMenuArrow.ArrowPos.Opt3)
                {
                    if (gwc.chars.characters[gwc.opponentCharacter].charHairColor == "n/a")
                    {
                        gwc.dialogueLines = new string[] {
                            "Yes, I can't determine my hair color."
                        };
                    }
                    else
                    {
                        gwc.dialogueLines = new string[] {
                            "No, I can determine my hair color."
                        };
                    }

                    SPL_TraitTreeConsolidator();
                }
                else if (moveOptsArw.currentPosition == MoveOptionsMenuArrow.ArrowPos.Opt4)
                {
                    bTraitHairColorO3 = false;
                    bTraitHairColorO1 = true;

                    bGuessingTrait = false;
                    bCheckingBoard = true;
                    oMan.ResetOptions();
                }
            }
        }
        // Hair Length
        else if (npcTrait[traitInt] == "hair length")
        {
            if (bTraitHairLengthO1)
            {
                if (moveOptsArw.currentPosition == MoveOptionsMenuArrow.ArrowPos.Opt1)
                {
                    if (gwc.chars.characters[gwc.opponentCharacter].charHairLength == "long")
                    {
                        gwc.dialogueLines = new string[] {
                            "Yes, I have long hair."
                        };
                    }
                    else
                    {
                        gwc.dialogueLines = new string[] {
                            "No, I do not have long hair."
                        };
                    }

                    SPL_TraitTreeConsolidator();
                }
                else if (moveOptsArw.currentPosition == MoveOptionsMenuArrow.ArrowPos.Opt2)
                {
                    if (gwc.chars.characters[gwc.opponentCharacter].charHairLength == "medium")
                    {
                        gwc.dialogueLines = new string[] {
                            "Yes, I have medium hair."
                        };
                    }
                    else
                    {
                        gwc.dialogueLines = new string[] {
                            "No, I do not have medium hair."
                        };
                    }

                    SPL_TraitTreeConsolidator();
                }
                else if (moveOptsArw.currentPosition == MoveOptionsMenuArrow.ArrowPos.Opt3)
                {
                    if (gwc.chars.characters[gwc.opponentCharacter].charHairLength == "short")
                    {
                        gwc.dialogueLines = new string[] {
                            "Yes, I have short hair."
                        };
                    }
                    else
                    {
                        gwc.dialogueLines = new string[] {
                            "No, I do not have short hair."
                        };
                    }

                    SPL_TraitTreeConsolidator();
                }
                else if (moveOptsArw.currentPosition == MoveOptionsMenuArrow.ArrowPos.Opt4)
                {
                    bTraitHairLengthO1 = false;
                    bTraitHairLengthO2 = true;
                    PlayerGuessYes(npcTrait[traitInt]);
                }
            }
            else if (bTraitHairLengthO2)
            {
                if (moveOptsArw.currentPosition == MoveOptionsMenuArrow.ArrowPos.Opt1)
                {
                    if (gwc.chars.characters[gwc.opponentCharacter].charHairLength == "none")
                    {
                        gwc.dialogueLines = new string[] {
                            "Yes, I have no hair."
                        };
                    }
                    else
                    {
                        gwc.dialogueLines = new string[] {
                            "No, I do have hair."
                        };
                    }

                    SPL_TraitTreeConsolidator();
                }
                else if (moveOptsArw.currentPosition == MoveOptionsMenuArrow.ArrowPos.Opt2)
                {
                    bTraitHairLengthO2 = false;
                    bTraitHairLengthO1 = true;

                    bGuessingTrait = false;
                    bCheckingBoard = true;
                    oMan.ResetOptions();
                }
            }
        }
        // Icons
        if (npcTrait[traitInt] == "icons")
        {
            if (bTraitIconsO1)
            {
                if (moveOptsArw.currentPosition == MoveOptionsMenuArrow.ArrowPos.Opt1)
                {
                    if (gwc.chars.characters[gwc.opponentCharacter].charIcons[0] == "fired" ||
                        gwc.chars.characters[gwc.opponentCharacter].charIcons[1] == "fired" ||
                        gwc.chars.characters[gwc.opponentCharacter].charIcons[2] == "fired" ||
                        gwc.chars.characters[gwc.opponentCharacter].charIcons[3] == "fired" ||
                        gwc.chars.characters[gwc.opponentCharacter].charIcons[4] == "fired")
                    {
                        gwc.dialogueLines = new string[] {
                            "Yes, I was 'fired' by Donald J. Trump."
                        };
                    }
                    else
                    {
                        gwc.dialogueLines = new string[] {
                            "No, I was not 'fired' by Donald J. Trump."
                        };
                    }

                    SPL_TraitTreeConsolidator();
                }
                else if (moveOptsArw.currentPosition == MoveOptionsMenuArrow.ArrowPos.Opt2)
                {
                    if (gwc.chars.characters[gwc.opponentCharacter].charIcons[0] == "tweet" ||
                        gwc.chars.characters[gwc.opponentCharacter].charIcons[1] == "tweet" ||
                        gwc.chars.characters[gwc.opponentCharacter].charIcons[2] == "tweet" ||
                        gwc.chars.characters[gwc.opponentCharacter].charIcons[3] == "tweet" ||
                        gwc.chars.characters[gwc.opponentCharacter].charIcons[4] == "tweet")
                    {
                        gwc.dialogueLines = new string[] {
                            "Yes, I was mentioned in a Donald J. Trump tweet."
                        };
                    }
                    else
                    {
                        gwc.dialogueLines = new string[] {
                            "No, I was not mentioned in a Donald J. Trump tweet."
                        };
                    }

                    SPL_TraitTreeConsolidator();
                }
                else if (moveOptsArw.currentPosition == MoveOptionsMenuArrow.ArrowPos.Opt3)
                {
                    if (gwc.chars.characters[gwc.opponentCharacter].charIcons[0] == "democrat" ||
                        gwc.chars.characters[gwc.opponentCharacter].charIcons[1] == "democrat" ||
                        gwc.chars.characters[gwc.opponentCharacter].charIcons[2] == "democrat" ||
                        gwc.chars.characters[gwc.opponentCharacter].charIcons[3] == "democrat" ||
                        gwc.chars.characters[gwc.opponentCharacter].charIcons[4] == "democrat")
                    {
                        gwc.dialogueLines = new string[] {
                            "Yes, I was a registered Democrat in 2016."
                        };
                    }
                    else
                    {
                        gwc.dialogueLines = new string[] {
                            "No, I was not a registered Democrat in 2016."
                        };
                    }

                    SPL_TraitTreeConsolidator();
                }
                else if (moveOptsArw.currentPosition == MoveOptionsMenuArrow.ArrowPos.Opt4)
                {
                    bTraitIconsO1 = false;
                    bTraitIconsO2 = true;
                    PlayerGuessYes(npcTrait[traitInt]);
                }
            }
            else if (bTraitIconsO2)
            {
                if (moveOptsArw.currentPosition == MoveOptionsMenuArrow.ArrowPos.Opt1)
                {
                    if (gwc.chars.characters[gwc.opponentCharacter].charIcons[0] == "republican" ||
                        gwc.chars.characters[gwc.opponentCharacter].charIcons[1] == "republican" ||
                        gwc.chars.characters[gwc.opponentCharacter].charIcons[2] == "republican" ||
                        gwc.chars.characters[gwc.opponentCharacter].charIcons[3] == "republican" ||
                        gwc.chars.characters[gwc.opponentCharacter].charIcons[4] == "republican")
                    {
                        gwc.dialogueLines = new string[] {
                            "Yes, I was a registered Republican in 2016."
                        };
                    }
                    else
                    {
                        gwc.dialogueLines = new string[] {
                            "No, I was not a registered Republican in 2016."
                        };
                    }

                    SPL_TraitTreeConsolidator();
                }
                else if (moveOptsArw.currentPosition == MoveOptionsMenuArrow.ArrowPos.Opt2)
                {
                    if (gwc.chars.characters[gwc.opponentCharacter].charIcons[0] == "independent" ||
                        gwc.chars.characters[gwc.opponentCharacter].charIcons[1] == "independent" ||
                        gwc.chars.characters[gwc.opponentCharacter].charIcons[2] == "independent" ||
                        gwc.chars.characters[gwc.opponentCharacter].charIcons[3] == "independent" ||
                        gwc.chars.characters[gwc.opponentCharacter].charIcons[4] == "independent")
                    {
                        gwc.dialogueLines = new string[] {
                            "Yes, I was a registered Independent in 2016."
                        };
                    }
                    else
                    {
                        gwc.dialogueLines = new string[] {
                            "No, I was not a registered Independent in 2016."
                        };
                    }

                    SPL_TraitTreeConsolidator();
                }
                else if (moveOptsArw.currentPosition == MoveOptionsMenuArrow.ArrowPos.Opt3)
                {
                    if (gwc.chars.characters[gwc.opponentCharacter].charIcons[0] == "no-party" ||
                        gwc.chars.characters[gwc.opponentCharacter].charIcons[1] == "no-party" ||
                        gwc.chars.characters[gwc.opponentCharacter].charIcons[2] == "no-party" ||
                        gwc.chars.characters[gwc.opponentCharacter].charIcons[3] == "no-party" ||
                        gwc.chars.characters[gwc.opponentCharacter].charIcons[4] == "no-party")
                    {
                        gwc.dialogueLines = new string[] {
                            "Yes, I had no US party affiliation in 2016."
                        };
                    }
                    else
                    {
                        gwc.dialogueLines = new string[] {
                            "No, I had a US party affiliation in 2016."
                        };
                    }

                    SPL_TraitTreeConsolidator();
                }
                else if (moveOptsArw.currentPosition == MoveOptionsMenuArrow.ArrowPos.Opt4)
                {
                    bTraitIconsO2 = false;
                    bTraitIconsO3 = true;
                    PlayerGuessYes(npcTrait[traitInt]);
                }
            }
            else if (bTraitIconsO3)
            {
                if (moveOptsArw.currentPosition == MoveOptionsMenuArrow.ArrowPos.Opt1)
                {
                    if (gwc.chars.characters[gwc.opponentCharacter].charIcons[0] == "cia" ||
                        gwc.chars.characters[gwc.opponentCharacter].charIcons[1] == "cia" ||
                        gwc.chars.characters[gwc.opponentCharacter].charIcons[2] == "cia" ||
                        gwc.chars.characters[gwc.opponentCharacter].charIcons[3] == "cia" ||
                        gwc.chars.characters[gwc.opponentCharacter].charIcons[4] == "cia")
                    {
                        gwc.dialogueLines = new string[] {
                            "Yes, I am or was in the Central Intelligence Agency."
                        };
                    }
                    else
                    {
                        gwc.dialogueLines = new string[] {
                            "No, I am not with the Central Intelligence Agency."
                        };
                    }

                    SPL_TraitTreeConsolidator();
                }
                else if (moveOptsArw.currentPosition == MoveOptionsMenuArrow.ArrowPos.Opt2)
                {
                    if (gwc.chars.characters[gwc.opponentCharacter].charIcons[0] == "doj" ||
                        gwc.chars.characters[gwc.opponentCharacter].charIcons[1] == "doj" ||
                        gwc.chars.characters[gwc.opponentCharacter].charIcons[2] == "doj" ||
                        gwc.chars.characters[gwc.opponentCharacter].charIcons[3] == "doj" ||
                        gwc.chars.characters[gwc.opponentCharacter].charIcons[4] == "doj")
                    {
                        gwc.dialogueLines = new string[] {
                            "Yes, I am or was in the Department of Justice."
                        };
                    }
                    else
                    {
                        gwc.dialogueLines = new string[] {
                            "No, I am not with the Department of Justice."
                        };
                    }

                    SPL_TraitTreeConsolidator();
                }
                else if (moveOptsArw.currentPosition == MoveOptionsMenuArrow.ArrowPos.Opt3)
                {
                    if (gwc.chars.characters[gwc.opponentCharacter].charIcons[0] == "fbi" ||
                        gwc.chars.characters[gwc.opponentCharacter].charIcons[1] == "fbi" ||
                        gwc.chars.characters[gwc.opponentCharacter].charIcons[2] == "fbi" ||
                        gwc.chars.characters[gwc.opponentCharacter].charIcons[3] == "fbi" ||
                        gwc.chars.characters[gwc.opponentCharacter].charIcons[4] == "fbi")
                    {
                        gwc.dialogueLines = new string[] {
                            "Yes, I am or was in the Federal Bureau of Investigation."
                        };
                    }
                    else
                    {
                        gwc.dialogueLines = new string[] {
                            "No, I am not with the Federal Bureau of Investigation."
                        };
                    }

                    SPL_TraitTreeConsolidator();
                }
                else if (moveOptsArw.currentPosition == MoveOptionsMenuArrow.ArrowPos.Opt4)
                {
                    bTraitIconsO3 = false;
                    bTraitIconsO4 = true;
                    PlayerGuessYes(npcTrait[traitInt]);
                }
            }
            else if (bTraitIconsO4)
            {
                if (moveOptsArw.currentPosition == MoveOptionsMenuArrow.ArrowPos.Opt1)
                {
                    if (gwc.chars.characters[gwc.opponentCharacter].charIcons[0] == "nsa" ||
                        gwc.chars.characters[gwc.opponentCharacter].charIcons[1] == "nsa" ||
                        gwc.chars.characters[gwc.opponentCharacter].charIcons[2] == "nsa" ||
                        gwc.chars.characters[gwc.opponentCharacter].charIcons[3] == "nsa" ||
                        gwc.chars.characters[gwc.opponentCharacter].charIcons[4] == "nsa")
                    {
                        gwc.dialogueLines = new string[] {
                            "Yes, I am or was in the National Security Agency."
                        };
                    }
                    else
                    {
                        gwc.dialogueLines = new string[] {
                            "No, I am not with the National Security Agency."
                        };
                    }

                    SPL_TraitTreeConsolidator();
                }
                else if (moveOptsArw.currentPosition == MoveOptionsMenuArrow.ArrowPos.Opt2)
                {
                    if (gwc.chars.characters[gwc.opponentCharacter].charIcons[0] == "white-house" ||
                        gwc.chars.characters[gwc.opponentCharacter].charIcons[1] == "white-house" ||
                        gwc.chars.characters[gwc.opponentCharacter].charIcons[2] == "white-house" ||
                        gwc.chars.characters[gwc.opponentCharacter].charIcons[3] == "white-house" ||
                        gwc.chars.characters[gwc.opponentCharacter].charIcons[4] == "white-house")
                    {
                        gwc.dialogueLines = new string[] {
                            "Yes, I am or was in the White House."
                        };
                    }
                    else
                    {
                        gwc.dialogueLines = new string[] {
                            "No, I am not nor was in the White House."
                        };
                    }

                    SPL_TraitTreeConsolidator();
                }
                else if (moveOptsArw.currentPosition == MoveOptionsMenuArrow.ArrowPos.Opt3)
                {
                    if (gwc.chars.characters[gwc.opponentCharacter].charIcons[0] == "congress" ||
                        gwc.chars.characters[gwc.opponentCharacter].charIcons[1] == "congress" ||
                        gwc.chars.characters[gwc.opponentCharacter].charIcons[2] == "congress" ||
                        gwc.chars.characters[gwc.opponentCharacter].charIcons[3] == "congress" ||
                        gwc.chars.characters[gwc.opponentCharacter].charIcons[4] == "congress")
                    {
                        gwc.dialogueLines = new string[] {
                            "Yes, I am or was in Congress."
                        };
                    }
                    else
                    {
                        gwc.dialogueLines = new string[] {
                            "No, I am not nor was in Congress."
                        };
                    }

                    SPL_TraitTreeConsolidator();
                }
                else if (moveOptsArw.currentPosition == MoveOptionsMenuArrow.ArrowPos.Opt4)
                {
                    bTraitIconsO4 = false;
                    bTraitIconsO5 = true;
                    PlayerGuessYes(npcTrait[traitInt]);
                }
            }
            else if (bTraitIconsO5)
            {
                if (moveOptsArw.currentPosition == MoveOptionsMenuArrow.ArrowPos.Opt1)
                {
                    if (gwc.chars.characters[gwc.opponentCharacter].charIcons[0] == "trump-campaign" ||
                        gwc.chars.characters[gwc.opponentCharacter].charIcons[1] == "trump-campaign" ||
                        gwc.chars.characters[gwc.opponentCharacter].charIcons[2] == "trump-campaign" ||
                        gwc.chars.characters[gwc.opponentCharacter].charIcons[3] == "trump-campaign" ||
                        gwc.chars.characters[gwc.opponentCharacter].charIcons[4] == "trump-campaign")
                    {
                        gwc.dialogueLines = new string[] {
                            "Yes, I was on the Trump Campaign team."
                        };
                    }
                    else
                    {
                        gwc.dialogueLines = new string[] {
                            "No, I was not on the Trump Campaign team."
                        };
                    }

                    SPL_TraitTreeConsolidator();
                }
                else if (moveOptsArw.currentPosition == MoveOptionsMenuArrow.ArrowPos.Opt2)
                {
                    if (gwc.chars.characters[gwc.opponentCharacter].charIcons[0] == "mueller-investigation" ||
                        gwc.chars.characters[gwc.opponentCharacter].charIcons[1] == "mueller-investigation" ||
                        gwc.chars.characters[gwc.opponentCharacter].charIcons[2] == "mueller-investigation" ||
                        gwc.chars.characters[gwc.opponentCharacter].charIcons[3] == "mueller-investigation" ||
                        gwc.chars.characters[gwc.opponentCharacter].charIcons[4] == "mueller-investigation")
                    {
                        gwc.dialogueLines = new string[] {
                            "Yes, I was on the Mueller investigation team."
                        };
                    }
                    else
                    {
                        gwc.dialogueLines = new string[] {
                            "No, I was not on the Mueller investigation team."
                        };
                    }

                    SPL_TraitTreeConsolidator();
                }
                else if (moveOptsArw.currentPosition == MoveOptionsMenuArrow.ArrowPos.Opt3)
                {
                    if (gwc.chars.characters[gwc.opponentCharacter].charIcons[0] == "media" ||
                        gwc.chars.characters[gwc.opponentCharacter].charIcons[1] == "media" ||
                        gwc.chars.characters[gwc.opponentCharacter].charIcons[2] == "media" ||
                        gwc.chars.characters[gwc.opponentCharacter].charIcons[3] == "media" ||
                        gwc.chars.characters[gwc.opponentCharacter].charIcons[4] == "media")
                    {
                        gwc.dialogueLines = new string[] {
                            "Yes, I am or was a media member."
                        };
                    }
                    else
                    {
                        gwc.dialogueLines = new string[] {
                            "No, I ain't nor was a media member."
                        };
                    }

                    SPL_TraitTreeConsolidator();
                }
                else if (moveOptsArw.currentPosition == MoveOptionsMenuArrow.ArrowPos.Opt4)
                {
                    bTraitIconsO5 = false;
                    bTraitIconsO1 = true;

                    bGuessingTrait = false;
                    bCheckingBoard = true;
                    oMan.ResetOptions();
                }
            }
        }
        // Skin Color
        else if (npcTrait[traitInt] == "skin color")
        {
            if (bTraitSkinColorO1)
            {
                if (moveOptsArw.currentPosition == MoveOptionsMenuArrow.ArrowPos.Opt1)
                {
                    if (gwc.chars.characters[gwc.opponentCharacter].charSkinColor == "white")
                    {
                        gwc.dialogueLines = new string[] {
                            "Yes, I am white."
                        };
                    }
                    else
                    {
                        gwc.dialogueLines = new string[] {
                            "No, I am not white."
                        };
                    }

                    SPL_TraitTreeConsolidator();
                }
                else if (moveOptsArw.currentPosition == MoveOptionsMenuArrow.ArrowPos.Opt2)
                {
                    if (gwc.chars.characters[gwc.opponentCharacter].charSkinColor == "black")
                    {
                        gwc.dialogueLines = new string[] {
                            "Yes, I am black."
                        };
                    }
                    else
                    {
                        gwc.dialogueLines = new string[] {
                            "No, I am not black."
                        };
                    }

                    SPL_TraitTreeConsolidator();
                }
                else if (moveOptsArw.currentPosition == MoveOptionsMenuArrow.ArrowPos.Opt3)
                {
                    if (gwc.chars.characters[gwc.opponentCharacter].charSkinColor == "brown")
                    {
                        gwc.dialogueLines = new string[] {
                            "Yes, I am brown."
                        };
                    }
                    else
                    {
                        gwc.dialogueLines = new string[] {
                            "No, I am not brown."
                        };
                    }

                    SPL_TraitTreeConsolidator();
                }
                else if (moveOptsArw.currentPosition == MoveOptionsMenuArrow.ArrowPos.Opt4)
                {
                    bTraitSkinColorO1 = false;
                    bTraitSkinColorO2 = true;
                    PlayerGuessYes(npcTrait[traitInt]);
                }
            }
            else if (bTraitSkinColorO2)
            {
                if (moveOptsArw.currentPosition == MoveOptionsMenuArrow.ArrowPos.Opt1)
                {
                    if (gwc.chars.characters[gwc.opponentCharacter].charSkinColor == "purple")
                    {
                        gwc.dialogueLines = new string[] {
                            "Yes, I am purple-ish blue."
                        };
                    }
                    else
                    {
                        gwc.dialogueLines = new string[] {
                            "No, I am not purple-ish blue."
                        };
                    }

                    SPL_TraitTreeConsolidator();
                }
                else if (moveOptsArw.currentPosition == MoveOptionsMenuArrow.ArrowPos.Opt2)
                {
                    if (gwc.chars.characters[gwc.opponentCharacter].charSkinColor == "grey")
                    {
                        gwc.dialogueLines = new string[] {
                            "Yes, I am grey."
                        };
                    }
                    else
                    {
                        gwc.dialogueLines = new string[] {
                            "No, I am not grey."
                        };
                    }

                    SPL_TraitTreeConsolidator();
                }
                else if (moveOptsArw.currentPosition == MoveOptionsMenuArrow.ArrowPos.Opt3)
                {
                    if (gwc.chars.characters[gwc.opponentCharacter].charSkinColor == "n/a")
                    {
                        gwc.dialogueLines = new string[] {
                            "Yes, I can't tell what my skin color is."
                        };
                    }
                    else
                    {
                        gwc.dialogueLines = new string[] {
                            "No, I can tell what my skin color is."
                        };
                    }

                    SPL_TraitTreeConsolidator();
                }
                else if (moveOptsArw.currentPosition == MoveOptionsMenuArrow.ArrowPos.Opt4)
                {
                    bTraitSkinColorO2 = false;
                    bTraitSkinColorO1 = true;

                    bGuessingTrait = false;
                    bCheckingBoard = true;
                    oMan.ResetOptions();
                }
            }
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
        pauseTime = 10f;
    }

    public void SPL_TraitTreeConsolidator()
    {
        gwc.GWC_DialogueRestter();
        gwc.dPic.sprite = gwc.portPic[48];
        oMan.ResetOptions();

        PauseQuestion();
        QuestionAdvancer();
        bGuessingTrait = false;
        bPlayerMidGuess = false;
    }
}
