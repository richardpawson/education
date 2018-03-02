using NakedObjects;

namespace Academy.Model
{
    [Bounded]
    public class Subject
    {
        [NakedObjectsIgnore]
        public virtual int Id { get; set; }

        [Title]
        public virtual string Name { get; set; }
    }
}
