using NakedObjects;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Quadrivia
{
    public abstract class QuestionContent
    {
        #region Static functions
        public static readonly string[] DescriptionOfQuestionTypes = {MultiPart.FriendlyName };
        public static readonly Type[] QuestionTypes = { typeof(MultiPart)};

        public static Type GetQuestionType(string selection)
        {
            return QuestionTypes[Array.IndexOf(DescriptionOfQuestionTypes, selection)];
        }
        #endregion

        #region Properties

        [NakedObjectsIgnore]
        public virtual int Id { get; set; }

        //Text
        //Image
        //Sub Questions

        //Correct answer(if applicable)
        //Automated mark scheme(where there is a choice)
        //Mark scheme(optional)

        #endregion
        #region Actions
        //Auto-mark answers, when requested to
        #endregion
    }

    public class MultiPart : QuestionContent {


        public const string FriendlyName = "Multi-part";

        #region Actions
        //Create, Add, Remove sub-questions
        #endregion

    }
    //Multiple choice single answer
    //Multiple choice multi-answer
    //Option to limit number selected?
    //Mark schemes:  1 for each correct; same but -1 for each incorrect; to a maximum of
    //Numerical answer – decimal
    //Free-text answer
    //Responsibilities
    //Look up representative answers for different marks
    //Fill-in a table(some values complete)
    //(For a sub-question only) Explanatory material only
}
