using NakedObjects;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.ComponentModel.DataAnnotations;

namespace Quadrivia
{
    public class QuestionMetaData
    {
        #region Injected Services

        public IDomainObjectContainer Container { set; protected get; }

        public TeacherRepository TeacherRepository { set; protected get; }

        public SubjectRepository SubjectRepository { set; protected get; }


        #endregion


        #region Properties


        [NakedObjectsIgnore]
        public virtual int Id { get; set; }

        [MemberOrder(10), Title, Optionally]
        public virtual string Title { get; set; }

        #region Subject
        [MemberOrder(20)]
        public virtual Subject Subject { get; set; }


        public Subject DefaultSubject()
        {
            return TeacherRepository.CurrentUserAsTeacher().DefaultSubject;
        }

        public IList<Subject> ChoicesSubject()
        {
            return SubjectRepository.AllSubjects().ToList();
        }

        #endregion

        #region Level
        [MemberOrder(30)]
        public virtual Level Level { get; set; } //TODO: Needs more thought

        public Level DefaultLevel()
        {
            return TeacherRepository.CurrentUserAsTeacher().DefaultLevel;
        }
        #endregion

        [MemberOrder(40)]
        public virtual string TopicsCovered { get; set; }

        [MemberOrder(50)]
        public virtual int MarksAvailable { get; set; }

        [MemberOrder(60)]
        public virtual QStatus Status { get; set; }

        [MemberOrder(70)]
        public virtual int Version { get; set; }

        [Hidden(WhenTo.Always)]
        public virtual string CreatedBy { get; set; }


        [MemberOrder(80)]
        public virtual string Authorship { get; set; }
        
        [MemberOrder(90)]
        public virtual string Source { get; set; }


    

        #region Actions
        //Add Question content
        //Create a new version from this, and associate them(original author & moderator only)
        //Retrieve & summarise prior versions
        //Make a copy(for editing) no longer associated with this (anyone) - needs new metadata
        //Retrieve and/or store in summarised form: how many times question has been answered, and summarised results.
        //Auto-mark answers, when requested to
        //Capture a rating by a teacher, and summarise ratings
        #endregion
    }

    public enum QStatus
    {
        Draft, Final, Superseded
    }
}
