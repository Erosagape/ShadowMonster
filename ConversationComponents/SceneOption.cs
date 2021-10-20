using System;
using System.Collections.Generic;
<<<<<<< HEAD
using System.Linq;
using System.Text;
using System.Threading.Tasks;
=======
using System.Text;
>>>>>>> 9d444d84de81f8a24139bc81c8b2f9f695ad0c9b

namespace ShadowMonsters.ConversationComponents
{
    public enum ActionType
    {
        Talk,
        End,
        Change,
        Quest,
        Teach,
        Shop,
        GiveItems,
        GiveKey,
        Battle,
        Rest,
    }
<<<<<<< HEAD

=======
>>>>>>> 9d444d84de81f8a24139bc81c8b2f9f695ad0c9b
    public class SceneAction
    {
        public ActionType Action;
        public string Parameter;
<<<<<<< HEAD

    }

=======
    }
>>>>>>> 9d444d84de81f8a24139bc81c8b2f9f695ad0c9b
    public class SceneOption
    {
        private string optionText;
        private string optionScene;
        private SceneAction optionAction;
<<<<<<< HEAD

=======
>>>>>>> 9d444d84de81f8a24139bc81c8b2f9f695ad0c9b
        public string OptionText
        {
            get { return optionText; }
            set { optionText = value; }
        }
<<<<<<< HEAD

=======
>>>>>>> 9d444d84de81f8a24139bc81c8b2f9f695ad0c9b
        public string OptionScene
        {
            get { return optionScene; }
            set { optionScene = value; }
        }
<<<<<<< HEAD

=======
>>>>>>> 9d444d84de81f8a24139bc81c8b2f9f695ad0c9b
        public SceneAction OptionAction
        {
            get { return optionAction; }
            set { optionAction = value; }
        }
<<<<<<< HEAD

        private SceneOption()
        {
        }

        public SceneOption(string text, string scene, SceneAction action)
=======
        private SceneOption()
        {

        }
        public SceneOption(string text,string scene,SceneAction action)
>>>>>>> 9d444d84de81f8a24139bc81c8b2f9f695ad0c9b
        {
            optionText = text;
            optionScene = scene;
            optionAction = action;
<<<<<<< HEAD
        }

=======
        }           
>>>>>>> 9d444d84de81f8a24139bc81c8b2f9f695ad0c9b
    }
}
