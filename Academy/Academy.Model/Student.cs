﻿using NakedObjects;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;

namespace Academy.Model
{
    public class Student
    {
        #region Injected Services

        public TeacherRepository Teachers { set; protected get; }

        public IDomainObjectContainer Container { set; protected get; }

        #endregion
        [NakedObjectsIgnore]//Indicates that this property will never be seen in the UI
        public virtual int Id { get; set; }

        [MemberOrder(1)]
        [Title]//This property will be used for the object's title at the top of the view and in a link
        public virtual string FullName { get; set; }

        [MemberOrder(2), Range(9, 13)]
        public virtual int CurrentYearGroup { get; set; }

        [MemberOrder(4), Optionally,]
        public virtual Teacher PersonalTutor { get; set; }

        public IList<Teacher> ChoicesPersonalTutor()
        {
            return Teachers.AllTeachers().ToList();
        }

        private ICollection<Set> _sets = new List<Set>();

        [MemberOrder(3)]
        [Eagerly(EagerlyAttribute.Do.Rendering)]
        [TableView(false, "Subject",  "SetName", "Teacher" )]
        public virtual ICollection<Set> Sets
        {
            get
            {
                return _sets;
            }
            set
            {
                _sets = value;
            }
        }

        public IQueryable<SubjectReport> ListRecentReports([Optionally] Subject forSubject)
        {
            int id = this.Id;
            var studentReps = Container.Instances<SubjectReport>().Where(sr => sr.Student.Id == id);
            if (forSubject != null)
            {
                var subjId = forSubject.Id;
                studentReps = studentReps.Where(sr => sr.Subject.Id == subjId);
            }
            return studentReps.OrderByDescending(sr => sr.Date);
        }

        public SubjectReport CreateNewReport(Subject sub)
        {
            var rep = Container.NewTransientInstance<SubjectReport>();
            rep.Student = this;
            rep.Subject = sub;
            return rep;
        }

        public string DisableCreateNewReport()
        {
            return Authorizer.DisableIfNotSysAdmin();
        }

        public void SendMessage(string subject, string message)
        {
            Container.InformUser("Message sent to " + FullName);
        }
    }
}