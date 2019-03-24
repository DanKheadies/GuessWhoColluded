// CC 4.0 International License: Attribution--HolisticGaming.com--NonCommercial--ShareALike
// Authors: David W. Corso
// Start: 03/20/2019
// Last:  03/22/2019

using UnityEngine;
using System.Collections.Generic;

// Contains info on traits and characters
public class Characters : MonoBehaviour
{
    public List<CharacterTraits> characters;

    void Start()
    {
        // Initializers
        characters = new List<CharacterTraits>();

        // "Full" List of Traits
        // Id
        // Name
        // ClothingColor[0] = "black";
        // ClothingColor[1] = "brown";
        // ClothingColor[2] = "blue";
        // ClothingColor[3] = "red";
        // ClothingColor[4] = "purple";
        // ClothingColor[5] = "yellow";
        // ClothingColor[6] = "white";
        // Country = "us";
        // Country = "uk";
        // Country = "russia";
        // Country = "sa";
        // Country = "canada";
        // Direction = "left";
        // Direction = "center";
        // Direction = "right";
        // EyeColor = "black"; // dark
        // EyeColor = "brown"; // dark
        // EyeColor = "blue"; // blue or green-ish
        // EyeColor = "teal-green"; // blue or green-ish
        // EyeColor = "white";
        // EyeColor = "black-white";
        // EyeColor = "n/a";
        // EyeWear = 0; // no
        // EyeWear = 1; // yes
        // FacialHair = 0; // no
        // FacialHair = 1; // yes
        // Gender = 0; // male
        // Gender = 1; // female
        // HairColor = "black";
        // HairColor = "brown";
        // HairColor = "blonde";
        // HairColor = "grey";
        // HairColor = "black-grey";
        // HairColor = "white";
        // HairColor = "red";
        // HairColor = "pink";
        // HairColor = "n/a";
        // HairLength = "long";
        // HairLength = "medium";
        // HairLength = "short";
        // HairLength = "none";
        // Icons[0] = "fired";
        // Icons[1] = "tweet";
        // Icons[2] = "democrat";
        // Icons[3] = "republican";
        // Icons[4] = "independent";
        // Icons[5] = "no-party";
        // Icons[6] = "cia";
        // Icons[7] = "doj";
        // Icons[8] = "fbi";
        // Icons[9] = "nsa";
        // Icons[10] = "white-house";
        // Icons[11] = "congress";
        // Icons[12] = "trump-campaign";
        // Icons[13] = "mueller-investigation";
        // Icons[14] = "media";
        // SkinColor = "white";
        // SkinColor = "black";
        // SkinColor = "brown";
        // SkinColor = "purple";
        // SkinColor = "grey";
        // SkinColor = "n/a";

        // Notes:
        // eye-color -> blue or green-ish
        // hair-color -> add black-grey
        // eye-color -> add black
        // hair-color -> add white
        // check country saudia arabia

        // Ahmad, Zainab (Mueller)
        characters.Add(new CharacterTraits(
            0,
            "Zainab Ahmad",
            new string[1] { "black" },
            "us",
            "left",
            "brown",
            0,
            0,
            1,
            "black",
            "long",
            new string[3] { "no-party", "doj", "mueller-investigation" },
            "brown"
        ));

        // Alberts, Jason (Mueller)
        characters.Add(new CharacterTraits(
            1,
            "Jason Alberts",
            new string[3] { "black", "white", "blue" },
            "us",
            "right",
            "brown",
            0,
            1,
            0,
            "red",
            "short",
            new string[3] { "no-party", "fbi", "mueller-investigation" },
            "white"
        ));

        // Asonye, Uzo (Mueller)
        characters.Add(new CharacterTraits(
            2,
            "Uzo Asoyne",
            new string[3] { "black", "white", "yellow" },
            "us",
            "left",
            "brown",
            1,
            1,
            0,
            "black",
            "short",
            new string[4] { "no-party", "doj", "mueller-investigation", "congress" },
            "black"
        ));

        // Brennan, John (Mueller)
        characters.Add(new CharacterTraits(
            3,
            "John Brennan",
            new string[3] { "black", "white", "red" },
            "us",
            "right",
            "brown",
            1,
            0,
            0,
            "black",
            "short",
            new string[4] { "no-party", "cia", "tweet", "white-house" },
            "white"
        ));

        // Clapper, James (Mueller)
        characters.Add(new CharacterTraits(
            4,
            "James Clapper",
            new string[3] { "black", "white", "purple" },
            "us",
            "left",
            "brown",
            1,
            1,
            0,
            "n/a",
            "none",
            new string[2] { "independent", "tweet" },
            "white"
        ));

        // Clinton, Hillary (Mueller)
        characters.Add(new CharacterTraits(
            5,
            "Hillary Clinton",
            new string[1] { "black" },
            "us",
            "left",
            "blue",
            0,
            0,
            1,
            "blonde",
            "long",
            new string[4] { "white-house", "tweet", "congress", "democrat" },
            "white"
        ));

        // Comey, James (Mueller)
        characters.Add(new CharacterTraits(
            6,
            "James Comey",
            new string[3] { "black", "white", "purple" },
            "us",
            "right",
            "brown",
            0,
            0,
            0,
            "black",
            "short",
            new string[5] { "fired", "tweet", "fbi", "doj", "independent" },
            "white"
        ));

        // Cummings, Elijah (Mueller)
        characters.Add(new CharacterTraits(
            7,
            "Elijah Cummings",
            new string[3] { "black", "white", "purple" },
            "us",
            "right",
            "brown",
            0,
            0,
            0,
            "n/a",
            "none",
            new string[2] { "democrat", "congress" },
            "black"
        ));

        // Cummings, Elijah (Mueller)
        characters.Add(new CharacterTraits(
            8,
            "Stormy Daniels",
            new string[1] { "blue" },
            "us",
            "left",
            "brown",
            0,
            0,
            1,
            "blonde",
            "long",
            new string[2] { "republican", "tweet" },
            "white"
        ));

        // Dreeban, Michael (Mueller)
        characters.Add(new CharacterTraits(
            9,
            "Michael Dreeban",
            new string[3] { "black", "white", "purple" },
            "us",
            "right",
            "brown",
            1,
            1,
            0,
            "grey",
            "short",
            new string[3] { "democrat", "mueller-investigation", "doj" },
            "white"
        ));

        // Haberman, Maggie (Mueller)
        characters.Add(new CharacterTraits(
            10,
            "Maggie Haberman",
            new string[2] { "black", "red" },
            "us",
            "right",
            "brown",
            1,
            0,
            1,
            "brown",
            "long",
            new string[4] { "white-house", "independent", "media", "tweet" },
            "white"
        ));

        // McCabe, Andrew (Mueller)
        characters.Add(new CharacterTraits(
            11,
            "Andrew McCabe",
            new string[3] { "black", "white", "red" },
            "us",
            "center",
            "brown",
            1,
            0,
            0,
            "black",
            "short",
            new string[4] { "fired", "republican", "fbi", "tweet" },
            "white"
        ));

        // Mueller, Robert S. III (Mueller)
        characters.Add(new CharacterTraits(
            12,
            "Robert S. Mueller III",
            new string[3] { "black", "white", "red" },
            "us",
            "left",
            "brown",
            0,
            0,
            0,
            "grey",
            "short",
            new string[5] { "doj", "republican", "fbi", "tweet", "mueller-investigation" },
            "white"
        ));

        // Obama, Barack (Mueller)
        characters.Add(new CharacterTraits(
            13,
            "Barack Obama",
            new string[3] { "black", "white", "blue" },
            "us",
            "center",
            "brown",
            0,
            0,
            0,
            "black",
            "short",
            new string[4] { "congress", "white-house", "democrat", "tweet" },
            "black"
        ));

        // Pelosi, Nancy (Mueller)
        characters.Add(new CharacterTraits(
            14,
            "Nancy Pelosi",
            new string[1] { "black" },
            "us",
            "center",
            "brown",
            0,
            0,
            1,
            "brown",
            "long",
            new string[3] { "congress", "democrat", "tweet" },
            "white"
        ));

        // Rhee, Jeannie (Mueller)
        characters.Add(new CharacterTraits(
            15,
            "Jeannie Rhee",
            new string[2] { "black", "white" },
            "us",
            "center",
            "brown",
            0,
            0,
            1,
            "brown",
            "long",
            new string[4] { "congress", "doj", "democrat", "mueller-investigation" },
            "white"
        ));

        // Rogers, Mike (Mueller)
        characters.Add(new CharacterTraits(
            16,
            "Mike Rogers",
            new string[3] { "black", "blue", "yellow" },
            "us",
            "right",
            "brown",
            0,
            0,
            0,
            "brown",
            "short",
            new string[4] { "congress", "fbi", "republican", "media" },
            "white"
        ));

        // Rosenstein, Rod (Mueller)
        characters.Add(new CharacterTraits(
            17,
            "Rod Rosenstein",
            new string[3] { "black", "white", "red" },
            "us",
            "left",
            "brown",
            1,
            0,
            0,
            "brown",
            "short",
            new string[3] { "doj", "republican", "tweet" },
            "white"
        ));

        // Schiff, Adam (Mueller)
        characters.Add(new CharacterTraits(
            18,
            "Adam Schiff",
            new string[3] { "black", "white", "blue" },
            "us",
            "center",
            "brown",
            0,
            0,
            0,
            "brown",
            "short",
            new string[3] { "democrat", "congress", "tweet" },
            "white"
        ));

        // Steele, Christopher (Mueller)
        characters.Add(new CharacterTraits(
            19,
            "Christopher Steele",
            new string[3] { "black", "white", "red" },
            "uk",
            "left",
            "brown",
            0,
            0,
            0,
            "grey",
            "short",
            new string[2] { "no-party", "tweet" },
            "white"
        ));

        // Warren, Elizabeth (Mueller)
        characters.Add(new CharacterTraits(
            20,
            "Elizabeth Warren",
            new string[2] { "black", "purple" },
            "us",
            "left",
            "blue",
            0,
            0,
            1,
            "blonde",
            "medium",
            new string[3] { "democrat", "tweet", "congress" },
            "white"
        ));

        // Weissmann, Andrew (Mueller)
        characters.Add(new CharacterTraits(
            21,
            "Andrew Weissmann",
            new string[3] { "black", "white", "purple" },
            "us",
            "center",
            "brown",
            0,
            0,
            0,
            "brown",
            "short",
            new string[4] { "doj", "fbi", "democrat", "mueller-investigation" },
            "white"
        ));

        // Wylie, Christopher (Mueller)
        characters.Add(new CharacterTraits(
            22,
            "Christopher Wylie",
            new string[1] { "black" },
            "canada",
            "right",
            "brown",
            1,
            1,
            0,
            "pink",
            "short",
            new string[1] { "no-party" },
            "white"
        ));

        // Yates, Sally (Mueller)
        characters.Add(new CharacterTraits(
            23,
            "Sally Yates",
            new string[1] { "black" },
            "us",
            "center",
            "brown",
            0,
            0,
            1,
            "brown",
            "medium",
            new string[1] { "no-party" },
            "white"
        ));

        // Bannon, Steve (Trump)
        characters.Add(new CharacterTraits(
            24,
            "Steve Bannon",
            new string[1] { "purple" },
            "us",
            "right",
            "white",
            0,
            0,
            0,
            "n/a",
            "none",
            new string[5] { "fired", "tweet", "republican", "white-house", "trump-campaign" },
            "n/a"
        ));

        // Cohen, Michael (Trump)
        characters.Add(new CharacterTraits(
            25,
            "Michael Cohen",
            new string[3] { "blue", "white", "red" },
            "us",
            "center",
            "brown",
            0,
            0,
            0,
            "black-grey",
            "short",
            new string[2] { "democrat", "tweet" },
            "white"
        ));

        // Conway, Kellyanne (Trump)
        characters.Add(new CharacterTraits(
            26,
            "Kellyanne Conway",
            new string[3] { "black", "grey", "red" },
            "us",
            "left",
            "black",
            0,
            0,
            1,
            "blonde",
            "long",
            new string[4] { "republican", "tweet", "white-house", "trump-campaign" },
            "grey"
        ));

        // Flynn, Michael (Trump)
        characters.Add(new CharacterTraits(
            27,
            "Michael Flynn",
            new string[3] { "brown", "white", "red" },
            "us",
            "left",
            "brown",
            0,
            0,
            0,
            "brown",
            "short",
            new string[5] { "democrat", "tweet", "fired", "white-house", "trump-campaign" },
            "white"
        ));

        // Giuliani, Rudy (Trump)
        characters.Add(new CharacterTraits(
            28,
            "Rudy Giuliani",
            new string[3] { "black", "white", "purple" },
            "us",
            "left",
            "brown",
            0,
            0,
            0,
            "grey",
            "short",
            new string[5] { "republican", "tweet", "doj", "white-house", "trump-campaign" },
            "white"
        ));

        // Hannity, Sean (Trump)
        characters.Add(new CharacterTraits(
            29,
            "Sean Hannity",
            new string[3] { "black", "white", "purple" },
            "us",
            "right",
            "brown",
            0,
            0,
            0,
            "black-grey",
            "short",
            new string[3] { "independent", "tweet", "media" },
            "white"
        ));

        // Hicks, Hope (Trump)
        characters.Add(new CharacterTraits(
            30,
            "Hope Hicks",
            new string[1] { "blue" },
            "us",
            "right",
            "brown",
            0,
            0,
            1,
            "brown",
            "long",
            new string[5] { "republican", "fired", "media", "white-house", "trump-campaign" },
            "white"
        ));

        // Jones, Alex (Trump)
        characters.Add(new CharacterTraits(
            31,
            "Alex Jones",
            new string[2] { "blue", "white" },
            "us",
            "left",
            "n/a",
            0,
            0,
            0,
            "brown",
            "short",
            new string[2] { "no-party", "media" },
            "purple"
        ));

        // Kushner, Jared (Trump)
        characters.Add(new CharacterTraits(
            32,
            "Jared Kushner",
            new string[3] { "black", "white", "brown" },
            "us",
            "center",
            "brown",
            0,
            0,
            0,
            "brown",
            "short",
            new string[4] { "no-party", "tweet", "white-house", "trump-campaign" },
            "white"
        ));

        // Mooch, The (Trump)
        characters.Add(new CharacterTraits(
            33,
            "The Mooch",
            new string[3] { "black", "white", "red" },
            "us",
            "right",
            "n/a",
            1,
            0,
            0,
            "brown",
            "short",
            new string[5] { "republican", "tweet", "white-house", "media", "fired" },
            "white"
        ));

        // Omarosa (Trump)
        characters.Add(new CharacterTraits(
            34,
            "Omarosa",
            new string[1] { "blue" },
            "us",
            "left",
            "brown",
            0,
            0,
            1,
            "black",
            "long",
            new string[5] { "republican", "tweet", "white-house", "trump-campaign", "fired" },
            "black"
        ));

        // Pai, Ajit (Trump)
        characters.Add(new CharacterTraits(
            35,
            "Ajit Pai",
            new string[4] { "black", "white", "yellow", "brown" },
            "us",
            "center",
            "black-white",
            0,
            0,
            0,
            "n/a",
            "none",
            new string[3] { "republican", "doj", "congress" },
            "brown"
        ));

        // Papadopoulos, George (Trump)
        characters.Add(new CharacterTraits(
            36,
            "George Papadopoulos",
            new string[2] { "blue", "white" },
            "us",
            "center",
            "brown",
            0,
            0,
            0,
            "brown",
            "short",
            new string[2] { "no-party", "trump-campaign" },
            "brown"
        ));

        // Pence, Mike (Trump)
        characters.Add(new CharacterTraits(
            37,
            "Mike Pence",
            new string[3] { "black", "white", "blue" },
            "us",
            "center",
            "blue",
            0,
            0,
            0,
            "white",
            "short",
            new string[5] { "republican", "white-house", "congress", "tweet", "trump-campaign" },
            "white"
        ));

        // Prince, Erik (Trump)
        characters.Add(new CharacterTraits(
            38,
            "Erik Prince",
            new string[3] { "brown", "white", "blue" },
            "us",
            "right",
            "blue",
            0,
            0,
            0,
            "blonde",
            "short",
            new string[3] { "independent", "white-house", "cia" },
            "white"
        ));

        // Putin, Vladimir (Trump)
        characters.Add(new CharacterTraits(
            39,
            "Vladimir Putin",
            new string[3] { "blue", "white", "red" },
            "russia",
            "left",
            "blue",
            0,
            0,
            0,
            "grey",
            "short",
            new string[2] { "no-party", "tweet" },
            "white"
        ));

        // Salman, Mohammed Bin (Trump)
        characters.Add(new CharacterTraits(
            40,
            "Mohammed Bin Salman",
            new string[3] { "red", "white", "brown" },
            "sa",
            "center",
            "brown",
            0,
            1,
            0,
            "black",
            "short",
            new string[2] { "no-party", "tweet" },
            "brown"
        ));

        // Sanders, Sarah Huckabee (Trump)
        characters.Add(new CharacterTraits(
            41,
            "Sarah Huckabee Sanders",
            new string[1] { "purple" },
            "us",
            "left",
            "brown",
            0,
            0,
            1,
            "brown",
            "long",
            new string[5] { "media", "tweet", "republican", "white-house", "trump-campaign" },
            "white"
        ));

        // Spicer, Sean (Trump)
        characters.Add(new CharacterTraits(
            42,
            "Sean Spicer",
            new string[3] { "black", "white", "blue" },
            "us",
            "center",
            "brown",
            0,
            0,
            0,
            "blonde",
            "short",
            new string[5] { "media", "tweet", "republican", "white-house", "fired" },
            "white"
        ));

        // Trump, Donald J (Trump)
        characters.Add(new CharacterTraits(
            43,
            "Donald J Trump",
            new string[3] { "black", "white", "blue" },
            "us",
            "right",
            "blue",
            0,
            0,
            0,
            "blonde",
            "short",
            new string[4] { "tweet", "republican", "white-house", "trump-campaign" },
            "white"
        ));

        // Trump, Donald Jr (Trump)
        characters.Add(new CharacterTraits(
            44,
            "Donald Trump Jr",
            new string[3] { "blue", "white", "purple" },
            "us",
            "right",
            "brown",
            0,
            0,
            0,
            "brown",
            "short",
            new string[3] { "tweet", "republican", "trump-campaign" },
            "white"
        ));

        // Trump, Ivanka (Trump)
        characters.Add(new CharacterTraits(
            45,
            "Ivanka Trump",
            new string[1] { "red" },
            "us",
            "left",
            "teal",
            0,
            0,
            1,
            "blonde",
            "long",
            new string[4] { "tweet", "independent", "trump-campaign", "white-house" },
            "white"
        ));

        // Trump, Melania (Trump)
        characters.Add(new CharacterTraits(
            46,
            "Melania Trump",
            new string[1] { "purple" },
            "us",
            "center",
            "blue",
            0,
            0,
            1,
            "brown",
            "long",
            new string[4] { "tweet", "republican", "trump-campaign", "white-house" },
            "white"
        ));

        // Veselnitskaya, Natalia (Trump)
        characters.Add(new CharacterTraits(
            47,
            "Natalia Veselnitskaya",
            new string[1] { "black" },
            "russia",
            "right",
            "brown",
            0,
            0,
            1,
            "brown",
            "long",
            new string[1] { "no-party" },
            "white"
        ));

        // Id = 0;
        // Name = "Zainab Ahmad";
        // ClothingColor[0] = "black";
        // Country = "us";
        // Direction = "left";
        // EyeColor = "brown";
        // EyeWear = 0;
        // FacialHair = 0;
        // Gender = 1;
        // HairColor = "black";
        // HairLength = "long";
        // Icons[0] = "no-party";
        // Icons[0] = "doj";
        // Icons[0] = "mueller-investigation";
        // SkinColor = "brown";
    }
}
